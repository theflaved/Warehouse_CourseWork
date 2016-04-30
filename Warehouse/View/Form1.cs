using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            Warehouse n = new Warehouse();
            n.Add(new Item("Some item", 2.242, new Weight(202, "кг.")));
            n.Add(new Item("Some item1", 2.212, new Weight(230, "кг.")));
            n.Add(new Item("Some item2", 2.222, new Weight(21, "кг.")));
            n.Add(new Item("Some item3", 2.222, new Weight(70, "кг.")));
            MainDataView.DataSource = n.SearchName("s");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MainDataView.DataSource = ((Warehouse)(MainDataView.DataSource)).SearchName(Text);
        }
    }
}
