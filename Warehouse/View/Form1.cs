using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
            n.Add(new Item("Some item1", 2.242, new Weight(202, "кг.")));
            n.Add(new Item("Some item4", 2.212, new Weight(230, "кг.")));
            n.Add(new Item("Some item2", 2.222, new Weight(21, "кг.")));
            n.Add(new Item("Some item3", 2.222, new Weight(70, "кг.")));
            data = n;
            MainView = data;
        }
        private void RefreshDataView(DataGridView view, object data)
        {
            MainView = null;
            MainView = data;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Do more research (if isn't needed - delete)
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //TODO: Implement (or not?) special search method
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
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            //TODO: Implement item adding
        }
        private void PrintDBToDocButton_Click(object sender, EventArgs e)
        {
            //TODO: Implement DB parsing to Doc(x?) file (Microsoft.Office.Interop.Word)
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            MainView = data.SearchName(SearchBox.Text);
        }
        private void MainDataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            data = data.OrderBy(x => x.Name).ToList().ToWarehouse();
            RefreshDataView(MainDataView, data);
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
            //TODO: Implement multiple item editing/adding form
        }
        private void DeliverFromWarehouseButton_Click(object sender, EventArgs e)
        {
            //TODO: Implement multiple item deletion/editing form
        }
    }
}
