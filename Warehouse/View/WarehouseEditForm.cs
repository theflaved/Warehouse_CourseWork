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
    //TODO: Refactor form class
    public partial class WarehouseEditForm : Form
    {
        private Form1 n1;
        private Warehouse newEdit;
        public WarehouseEditForm()
        {
            InitializeComponent();
            newEdit = new Warehouse();
            MainEditDataView.DataSource = newEdit;
            n1 = new Form1();
            OldMainDataView.DataSource = n1.OuterAccessToDBView.DataSource;
            n1.SetDataFormats(OldMainDataView);
            CreateUnboundTextBoxColumn();
        }

        private void WarehouseEditForm_Load(object sender, EventArgs e)
        {
        }
        //TODO: Fix columns (google)
        private void CreateUnboundTextBoxColumn()
        {
            foreach (DataGridViewColumn column in MainEditDataView.Columns)
            {
                column.ReadOnly = false;
            }
            DataGridViewTextBoxColumn bc = new DataGridViewTextBoxColumn();
            bc.Name = "";
            bc.HeaderText = "Изменения в количестве";
            bc.ReadOnly = false;
            MainEditDataView.Columns.Insert(MainEditDataView.ColumnCount, bc);
        }
        private void CancelFormButton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Вы уверенны что хотите отменить все изменения?", "Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) ==
                DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void OldMainDataView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = OldMainDataView.SelectedCells[0].RowIndex;
            Item workingItem = (Item)OldMainDataView.Rows[rowIndex].DataBoundItem;
            if (newEdit.Contains(workingItem))
            {
                MessageBox.Show("Товар уже есть в списке изменяемых!");
            }
            else
            {
                newEdit.Add((Item)OldMainDataView.Rows[rowIndex].DataBoundItem);
                n1.RefreshDataView(MainEditDataView, newEdit);
            }
        }
    }
}
