using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Warehouse.View;

namespace Warehouse
{
    //Главная форма приложения
    public partial class Form1 : Form
    {
        //Внешняя форма для регистрации отгрузки/поступления товара
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

        //Действия выполняемые при вызове формы
        private void Form1_Load(object sender, EventArgs e)
        {
            Warehouse n = new Warehouse();
            _dataCollection = n;
            MainDataViewSource = _dataCollection;
            SetDataFormats(MainDataView);
            _dataCollection.OnCollectionChange += () => RebindDataView(MainDataView,_dataCollection);
        }

        //Обработчки нажатия на кнопку удаления из базы данных склада
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

        //Вывод ведомости в HTML файл
        private void PrintDBToDocButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = @"report.htm",
                Filter = "All files (*.htm)|*.htm"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                object path = saveFile.FileName;
                using (FileStream fs = new FileStream(path.ToString(), FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.WriteLine("<h1 style=\"text-align: center\">Ведомость от " + DateTime.Now + "</h1>");
                        writer.Write("<table cellspacing=\"2\" border=\"1\" cellpadding=\"5\" style=\"text-align: center\">");
                        writer.WriteLine("<tr style=\"background-color: cyan\"><td>ID (Уникальный идентификатор товара на складе)</td>" +
                                     "<td>Название</td>" +
                                     "<td>Количество</td>" +
                                     "<td>Цена за единицу товара в упаковке</td>" +
                                     "<td>Общая цена товара на складе</td>" +
                                     "<td>Дата последнего изменения</td>" +
                                     "<td>Последнее изменение в количестве</td></tr>");
                        foreach (Item item in _dataCollection)
                        {
                            writer.WriteLine("<tr>" +
                                         "<td>№"+ item.ID + "</td>" +
                                         "<td>" + item.Name + "</td>" +
                                         "<td>" + item.Quanity + " шт. </td>" +
                                         "<td>" + item.Units.ToString() + "</td>" +
                                         "<td>" + item.CompletePriceSum + "грн. </td>" +
                                         "<td>" + item.LastEntry + "</td>" +
                                         "<td>" + item.LastQuanityChange + " шт. </td>" +
                                         "</tr>");
                        }
                        writer.Write("</table>");
                    }
                }
                MessageBox.Show(@"Ведомость создана");
            }
        }

        //Обработчик поля поиска, вызывается при изменении текста
        private void SearchBox_TextChanged(object sender, EventArgs e) => searchInWarehouseDGV(MainDataView,SearchBox);

        //Открытие файлы (Десериализация)
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
                _dataCollection.OnCollectionChange += () => RebindDataView(MainDataView, _dataCollection);
            }
        }

        //Сохранение файла (Сериализация)
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
                using (
                    FileStream stream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None)
                    )
                {
                    formatter.Serialize(stream, new Warehouse(_dataCollection, _dataCollection._idCounter));
                    stream.Close();
                }
            }
        }

        //Вызов формы отгрузки/прибытия товара и дальнейшее добавление/замена товаров в главной коллекции
        private void DeliverToWarehouseButton_Click(object sender, EventArgs e)
        {
            EditForm = new WarehouseEditForm();
            EditForm.ShowDialog(this);
            if(EditForm.DialogResult == DialogResult.OK)
                foreach (Item item in (Warehouse) EditForm.outerEdit)
                {
                    _dataCollection.AddWithID(item, true);
                }
        }

        //Обновления таблицы отображения
        public void RefreshDataView(DataGridView view, object data)
        {
            CurrencyManager cm = (CurrencyManager)(view.BindingContext[data]);
            if (cm != null)
            {
                cm.Refresh();
            }
            SetDataFormats(view);
        }

        //Аналогично предыдущему, но другим способом
        public void RebindDataView(DataGridView view, object data)
        {
            view.DataSource = null;
            view.DataSource = data;
            SetDataFormats(view);
        }

        //Установка форматов данных для отображения
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

        //Основной метод поиска в таблице отображения
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

        //Вызов окна "о программе"
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
    }
}
