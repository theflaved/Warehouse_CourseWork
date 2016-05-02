using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        private object MainView
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
        private Warehouse data;
        public Form1()
        {
            InitializeComponent();
            Warehouse n = new Warehouse();
            data = n;
            n.Add(new Item("Жарений кабанчик", 25, new Weight(20, 90, "кг.")));
            n.Add(new Item("Огурцы", 90, new Volume(20.53, 10, "л.")));
            n.Add(new Item("Помидоры", 33, new Volume(40, 33, "л.")));
            MainView = data;
            MainPicDrawer.Image = Properties.Resources.buildings64;
            MainDataView.Columns["CompletePriceSum"].DefaultCellStyle.Format = ("#,###.00 грн.");
            MainDataView.Columns["Quanity"].DefaultCellStyle.Format = ("#,## шт.;(#,## шт.)");
            MainDataView.Columns["LastQuanityChange"].DefaultCellStyle.Format = ("#,## шт.;(#,## шт.)");
        }
        private void RefreshDataView(DataGridView view, object data)
        {
            MainView = null;
            MainView = data;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void EditItemButton_Click(object sender, EventArgs e)
        {
            //TODO: Implement warehouse item editing
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
                    data.Remove((Item)toDelete);
                    RefreshDataView(MainDataView,data);
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
            MainView = data.SearchName(SearchBox.Text);
        }
        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "DB.bin";
            openFile.Filter = "Binary DB (*.bin)|*.bin|All files (*.*)|*.*";
            IFormatter formatter = new BinaryFormatter();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                data = (Warehouse)formatter.Deserialize(stream);
                stream.Close();
            }
            RefreshDataView(MainDataView, data);
        }
        private void WriteFileButton_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "United.bin";
            saveFile.Filter = "Binary DB (*.bin)|*.bin|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, data);
                stream.Close();
            }
        }
        private void DeliverToWarehouseButton_Click(object sender, EventArgs e)
        {
            //TODO: Income form implementation (!!!!!!!)
        }
    }
}
