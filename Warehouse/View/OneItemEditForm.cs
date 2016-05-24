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
    public partial class OneItemEditForm : Form
    {
        public object ReturnedItem => _innerItem;
        private Item _innerItem;
        public OneItemEditForm()
        {
            InitializeComponent();
        }

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

        public bool ValidateForm()
        {
            Regex nums = new Regex(@"^\d+$");
            bool expressionResult = (nums.IsMatch(QuanityTextBox.Text) &&
                                     nums.IsMatch(PricePerUnitTextBox.Text) &&
                                     nums.IsMatch(UnitsPerItemTextBox.Text));
            return expressionResult;
        }

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

        private void UnitTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: FIX THIS
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

        public void GetSelectedFromFatherForm(DataGridView DGV)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Ничего не выбрано");
            }
            else
            {
                Item worker = (Item) DGV.CurrentRow.DataBoundItem;
                NameTextBox.Text = worker.Name;
                UnitsPerItemTextBox.Text = worker.Units.Quanity.ToString();
                UnitFactorComboBox.Text = worker.Units.Factor;
                PricePerUnitTextBox.Text = worker.Units.Price.ToString();
                QuanityTextBox.Text = worker.Quanity.ToString();
                QuanityTextBox.ReadOnly = true;
            }
        }
    }
}
