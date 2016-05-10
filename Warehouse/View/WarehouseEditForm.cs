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
            foreach (DataGridViewColumn column in MainEditDataView.Columns) column.ReadOnly = true;
            CreateUnboundTextBoxColumn();
            n1 = new Form1();
            OldMainDataView.DataSource = n1.OuterAccessToDBView.DataSource;
            n1.SetDataFormats(OldMainDataView);
        }
        private void WarehouseEditForm_Load(object sender, EventArgs e)
        {
        }
        private void CreateUnboundTextBoxColumn()
        {
            DataGridViewTextBoxColumn bc = new DataGridViewTextBoxColumn();
            bc.Name = "QChange";
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
                Close();
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
                List<int> temp= new List<int>();
                for (int i = 0; i < MainEditDataView.RowCount; i++) temp.Add(
                    Convert.ToInt32(MainEditDataView["QChange", i].Value));
                n1.RefreshDataView(MainEditDataView, newEdit);
                for (int i = 0; i < temp.Count; i++)
                    MainEditDataView["QChange", i].Value = temp[i];
            }
        }

        private void DeleteFromEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                object toDelete = MainEditDataView.CurrentRow.DataBoundItem; //Can cause exception
                if (MessageBox.Show("Вы уверены что хотите удалить выделеную запись?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    newEdit.Remove((Item)toDelete);
                    n1.RefreshDataView(MainEditDataView, newEdit);
                }
            }
            catch (NullReferenceException)
            {
                //TODO: Edit this ;D
                MessageBox.Show("Ничто не выбрано, все тлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void AddToEditButton_Click(object sender, EventArgs e)
        {
            OneItemEditForm editForm = new OneItemEditForm();
            editForm.ShowDialog();
            newEdit.Add((Item)editForm.ReturnedItem);
            n1.RefreshDataView(MainEditDataView, newEdit);
            MainEditDataView["QChange", MainEditDataView.RowCount - 1].ReadOnly = true;
        }

        private void NewSearchBox_TextChanged(object sender, EventArgs e)
        {
            OldMainDataView.DataSource = ((Warehouse)(n1.OuterAccessToDBView.DataSource)).SearchName(OldSearchBox.Text);

        }

        private void OldSearchBox_TextChanged(object sender, EventArgs e)
        {
            OldMainDataView.DataSource = ((Warehouse)(n1.OuterAccessToDBView.DataSource)).SearchName(OldSearchBox.Text);
        }
    }
}
