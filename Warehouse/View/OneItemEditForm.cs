using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    //Форма редактирования единичного товара
    public partial class OneItemEditForm : Form
    {
        // Свойство для доступа к возвращаемому товару из вне
        public object ReturnedItem => _innerItem;
        // Возвращаемый товар
        private Item _innerItem;
        public OneItemEditForm()
        {
            InitializeComponent();
        }

        // Обработчик кнопки отмены
        private void EditCancelButton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Вы действительно хотите отменить изменения?", "Предупреждение", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        // Проверка формы
        public bool ValidateForm()
        {
            Regex numsInt = new Regex(@"^\d+$");
            Regex numsFloat = new Regex(@"\-?\d+(\.\d{0,})?");
            bool expressionResult = (numsInt.IsMatch(QuanityTextBox.Text) &&
                                     numsFloat.IsMatch(PricePerUnitTextBox.Text) &&
                                     numsFloat.IsMatch(UnitsPerItemTextBox.Text));
            return expressionResult;
        }

        // Принятие изменений
        private void EditAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) throw new DataException();
                ADTUnits type;
                switch (UnitTypeComboBox.Text)
                {
                    case "Вес":
                        type = new Weight(Convert.ToDouble(PricePerUnitTextBox.Text),
                            Convert.ToDouble(UnitsPerItemTextBox.Text), UnitFactorComboBox.Text);
                        break;
                    case "Объем":
                        type = new Volume(Convert.ToDouble(PricePerUnitTextBox.Text),
                            Convert.ToDouble(UnitsPerItemTextBox.Text), UnitFactorComboBox.Text);
                        break;
                    case "Количество":
                        type = new UnitsOnly(Convert.ToDouble(PricePerUnitTextBox.Text),
                            Convert.ToDouble(UnitsPerItemTextBox.Text));
                        break;
                    default:
                        type = new UnitsOnly(Convert.ToDouble(PricePerUnitTextBox.Text),
                            Convert.ToDouble(UnitsPerItemTextBox.Text));
                        break;
                }
                _innerItem = new Item(NameTextBox.Text, Convert.ToDouble(QuanityTextBox.Text), type);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DataException)
            {
                MessageBox.Show("Проверьте правильность ввода полей", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        // События по изменению индекса
        private void UnitTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitFactorComboBox.Items.Clear();
            switch (UnitTypeComboBox.Text)
            {
                case "Вес":
                    foreach (var item in new Weight(1, 1, "кг.").FactDictionary.Keys)
                    {
                        UnitFactorComboBox.Items.Add(item);
                        UnitFactorComboBox.Text = "кг.";
                    }
                    break;
                case "Объем":
                    foreach (var item in new Volume(1, 1, "л.").FactDictionary.Keys)
                    {
                        UnitFactorComboBox.Items.Add(item);
                        UnitFactorComboBox.Text = "л.";
                    }
                    break;
                case "Количество":
                    UnitFactorComboBox.Items.Add("шт.");
                    UnitFactorComboBox.Text = "шт.";
                    break;
            }
        }

        // Метод для перехвата выбраной в таблице строки
        public void GetSelectedFromFatherForm(DataGridView DGV)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Ничего не выбрано");
                throw new NoNullAllowedException();
            }
            Item worker = (Item) DGV.CurrentRow.DataBoundItem;
            NameTextBox.Text = worker.Name;
            UnitsPerItemTextBox.Text = worker.Units.Quanity.ToString();
            UnitFactorComboBox.Text = worker.Units.Factor;
            PricePerUnitTextBox.Text = worker.Units.Price.ToString();
            QuanityTextBox.Text = worker.Quanity.ToString();
            QuanityTextBox.ReadOnly = true;
            Type unitType = worker.Units.GetType();
            switch (unitType.Name)
            {
                case "Volume":
                    UnitTypeComboBox.Text = "Объем";
                    break;
                case "Weight":
                    UnitTypeComboBox.Text = "Вес";
                    break;
                default:
                    UnitTypeComboBox.Text = "Количество";
                    break;
            }
            UnitFactorComboBox.Text = worker.Units.Factor;
        }
    }
}
