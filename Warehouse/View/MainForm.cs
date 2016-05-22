using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        private WarehouseEditForm EditForm;
        public DataGridView OuterAccessToDBView => MainDataView;

        public object MainDataViewSource
        {
            get { return MainDataView.DataSource; }

            set { MainDataView.DataSource = value; }
        }

        private Warehouse _dataCollection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Warehouse n = new Warehouse();
            _dataCollection = n;
            MainDataViewSource = _dataCollection;
            MainPicDrawer.Image = Properties.Resources.buildings64;
            SetDataFormats(MainDataView);
            _dataCollection.OnCollectionChange += () => RefreshDataView(MainDataView,_dataCollection);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                object toDelete = MainDataView.CurrentRow.DataBoundItem; //Can cause exception
                if (MessageBox.Show("Вы уверены что хотите удалить выделеную запись?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _dataCollection.Remove((Item)toDelete);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("База данных не загружена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void PrintDBToDocButton_Click(object sender, EventArgs e)
        {
            if (_dataCollection.Count == 0)
            {
                MessageBox.Show("База данных не загружена, либо не создана!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            winword.ShowAnimation = false;
            winword.Visible = false;
            object missing = System.Reflection.Missing.Value;
            Document document = winword.Documents.Add(ref missing, ref missing,
                ref missing, ref missing);

            document.Content.SetRange(0, 0);

            //Add paragraph with Heading 1 style
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            object styleHeading1 = "Heading 1";
            para1.Range.set_Style(ref styleHeading1);
            para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            para1.Range.Text = "Отчет о складе " + DateTime.Now;
            para1.Range.InsertParagraphAfter();

            Table firstTable = document.Tables.Add(para1.Range, _dataCollection.Count + 1, 6, ref missing, ref missing);

            //firstTable.set_Style(ref);
            firstTable.Borders.Enable = 1;
            firstTable.Rows[1].Cells[1].Range.Text = "Название";
            firstTable.Rows[1].Cells[2].Range.Text = "Количество";
            firstTable.Rows[1].Cells[3].Range.Text = "Цена за единицу";
            firstTable.Rows[1].Cells[4].Range.Text = "Общая цена товара";
            firstTable.Rows[1].Cells[5].Range.Text = "Дата последнего изменения";
            firstTable.Rows[1].Cells[6].Range.Text = "Последнее изменение";
            int dataIndex = 0;
            Item current;
            foreach (Row row in firstTable.Rows)
            {
                if(row.Index == 1) continue;;
                if (dataIndex > _dataCollection.Count - 1) break;
                current = _dataCollection[dataIndex];
                row.Cells[1].Range.Text = current.Name;
                row.Cells[2].Range.Text = current.Quanity.ToString() + " шт.";
                row.Cells[3].Range.Text = current.Units.ToString();
                row.Cells[4].Range.Text = current.CompletePriceSum.ToString() + " грн.";
                row.Cells[5].Range.Text = current.LastEntry.ToString();
                row.Cells[6].Range.Text = current.LastQuanityChange.ToString() + " шт.";
                dataIndex++;
            }
            //Save the document
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    FileName = @"Some.docx",
                    Filter = "All files (*.docx)|*.docx"
                };
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    object path = saveFile.FileName;
                    document.SaveAs2(ref path);
                    document.Close(ref missing, ref missing, ref missing);
                    winword.Quit(ref missing, ref missing, ref missing);
                    MessageBox.Show(@"Ведомость создана");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"При формировании ведомости произошла ошибка. Повторите попытку еще раз.");
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            searchInWarehouseDGV(MainDataView,SearchBox);
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            OpenFileDialog openFile = new OpenFileDialog
            {
                FileName = "DB.bin",
                Filter = "Binary DB (*.bin)|*.bin|All files (*.*)|*.*"
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                _dataCollection = (Warehouse)formatter.Deserialize(stream);
                stream.Close();
                RebindDataView(MainDataView, _dataCollection);
            }
        }

        private void WriteFileButton_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = "United.bin",
                Filter = "Binary DB (*.bin)|*.bin|All files (*.*)|*.*"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, _dataCollection);
                stream.Close();
            }
        }

        private void DeliverToWarehouseButton_Click(object sender, EventArgs e)
        {
            EditForm = new WarehouseEditForm();
            EditForm.ShowDialog(this);
            foreach (Item item in (Warehouse)EditForm.outerEdit)
            {
                _dataCollection.AddWithID(item,true);
            }
            //RebindDataView(MainDataView,_dataCollection);
        }

        //TODO: Fix this (Have no idea how)
        public void RefreshDataView(DataGridView view, object data)
        {
            CurrencyManager cm = (CurrencyManager)(view.BindingContext[data]);
            if (cm != null)
            {
                cm.Refresh();
            }
            SetDataFormats(view);
        }

        public void RebindDataView(DataGridView view, object data)
        {
            view.DataSource = null;
            view.DataSource = data;
            SetDataFormats(view);
        }

        public void SetDataFormats(DataGridView DGV)
        {
            try
            {
                DGV.Columns["CompletePriceSum"].DefaultCellStyle.Format = ("#,###.00 грн.");
                DGV.Columns["Quanity"].DefaultCellStyle.Format = ("#,## шт.;(#,## шт.)");
                //DGV.Columns["LastQuanityChange"].DefaultCellStyle.Format = ("#,## шт.;(#,## шт.)");
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("Bad DGV");
            }
        }

        public void searchInWarehouseDGV(DataGridView view, TextBox box)
        {
            foreach (object row in view.Rows)
            {
                if(((DataGridViewRow)row).Index == -1) continue;
                ((DataGridViewRow)row).Visible = true;
            }
            if (box.Text == "") return;
            view.CurrentCell = null;
            for (int i = 0; i < view.RowCount; i++)
            {
                if (!((Item)view.Rows[i].DataBoundItem).Name.ToLower().Contains(box.Text.ToLower()))
                    view.Rows[i].Visible = false;
            }
        }
    }
}
