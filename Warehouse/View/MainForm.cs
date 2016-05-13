using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        private WarehouseEditForm EditForm;
        public DataGridView OuterAccessToDBView => MainDataView;
        public object MainDataViewSource
        {
            get
            {
                return MainDataView.DataSource;
            }

            set
            {
                MainDataView.DataSource = value;
            }
        }
        private Warehouse _dataCollection;
        private BindingSource _data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Warehouse n = new Warehouse();
            _dataCollection = n;
            _data = new BindingSource();
            _data.DataSource = _dataCollection;
            MainDataViewSource = _data;
            MainPicDrawer.Image = Properties.Resources.buildings64;
            SetDataFormats(MainDataView);
        }
        private void EditItemButton_Click(object sender, EventArgs e)
        {
            
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
                    _data.Remove((Item)toDelete);
                    RefreshDataView(MainDataView,_data);
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
            //TODO: Implement DB parsing to Doc(x?) file (Microsoft.Office.Interop.Word)
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            _data.DataSource = _dataCollection.SearchName(SearchBox.Text);
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
                formatter.Serialize(stream, _data);
                stream.Close();
            }
        }
        private void DeliverToWarehouseButton_Click(object sender, EventArgs e)
        {
            EditForm = new WarehouseEditForm();
            EditForm.ShowDialog(this);
            RebindDataView(MainDataView,_dataCollection);
        }
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
        //TODO: Fix this govnocode
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
    }
}
