using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Warehouse
{
    //TODO: Refactor form class
    public partial class WarehouseEditForm : Form
    {
        //Ссылка на основную форму
        private Form1 n1;
        //Коллекция которая содержит изменяемые элементы
        private Warehouse newEdit;
        //Реализация внешнего доступа к изменяемой коллекции
        public object outerEdit => newEdit;
        //Отключение кнопки "Закрыть"
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public WarehouseEditForm()
        {
            InitializeComponent();
        }

        //Действия которые необходимо совершить для загрузки и полноразмерной функциональности
        private void WarehouseEditForm_Load(object sender, EventArgs e)
        {
            newEdit = new Warehouse(((Warehouse)((Form1)Owner).MainDataViewSource).Count);
            MainEditDataView.DataSource = newEdit;
            foreach (DataGridViewColumn column in MainEditDataView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            n1 = new Form1();
            OldMainDataView.DataSource = ((Form1)Owner).MainDataViewSource;
            foreach (DataGridViewColumn column in MainEditDataView.Columns) column.ReadOnly = true;
            CreateUnboundTextBoxColumn();
            n1.SetDataFormats(OldMainDataView);
            newEdit.OnCollectionChange += () => RefreshMainEditDataView(newEdit);
        }

        //Создание не привязанной к данным колонки
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
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void OldMainDataView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (OldMainDataView.SelectedCells != null && OldMainDataView.SelectedCells.Count != 0)
            {
                int rowIndex = OldMainDataView.SelectedCells[0].RowIndex;
                if (rowIndex == -1) return;
                Item workingItem = (Item) OldMainDataView.Rows[rowIndex].DataBoundItem;
                if (newEdit.Contains(workingItem))
                {
                    MessageBox.Show("Товар уже есть в списке изменяемых!");
                }
                else
                {
                    newEdit.AddWithID((Item) OldMainDataView.Rows[rowIndex].DataBoundItem);
                    RefreshMainEditDataView(newEdit);
                }
            }
        }
        private void RefreshMainEditDataView(object source)
        {
            List<object> temp = new List<object>();
            List<bool> temp2 = new List<bool>();
            for (int i = 0; i < MainEditDataView.RowCount; i++)
            {
                var value = MainEditDataView["QChange", i].Value;
                if (value != null && value.ToString() != "")
                    temp.Add(Convert.ToInt32(MainEditDataView["QChange", i].Value));
                else temp.Add("");
                temp2.Add(Convert.ToBoolean(MainEditDataView["QChange", i].ReadOnly));
            }
            n1.RefreshDataView(MainEditDataView, source);
            for (int i = 0; i < temp.Count; i++)
            {
                MainEditDataView["QChange", i].Value = temp[i];
                MainEditDataView["QChange", i].ReadOnly = temp2[i];
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
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                newEdit.AddWithID((Item)editForm.ReturnedItem);
                RefreshMainEditDataView(newEdit);
                MainEditDataView["QChange", MainEditDataView.RowCount - 1].ReadOnly = true;
            }
        }
        private void NewSearchBox_TextChanged(object sender, EventArgs e) => n1.searchInWarehouseDGV(MainEditDataView, NewSearchBox);
        private void OldSearchBox_TextChanged(object sender, EventArgs e) => n1.searchInWarehouseDGV(OldMainDataView,OldSearchBox);
        private void FinalizeFormButton_Click(object sender, EventArgs e)
        {
            foreach (Item item in newEdit)
            {
                var value = MainEditDataView["QChange", MainEditDataView.RowCount - 1].Value;
                if (value != null && value.ToString() != "")
                try
                {
                    item.InvChangeNow(Convert.ToInt32(MainEditDataView["QChange", MainEditDataView.RowCount - 1].Value));

                }
                catch (InvalidDataException)
                {
                    MessageBox.Show("Неправильное количество позиции " + item.Name +
                                    ". Попробуйте изменить значение и попробовать еще раз.");
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditOnceButton_Click(object sender, EventArgs e)
        {
            OneItemEditForm dialog = new OneItemEditForm();
            dialog.GetSelectedFromFatherForm(MainEditDataView);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int? tmp = ((Item) MainEditDataView.CurrentRow.DataBoundItem).ID;
                ((Item) dialog.ReturnedItem).ID = tmp;
                newEdit.AddWithID((Item)dialog.ReturnedItem,true);
            }
        }
    }
}
