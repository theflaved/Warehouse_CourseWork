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
                Close();
            }
        }

        private void EditAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTextBox.Text == "" || QuanityTextBox.Text == "" || PricePerUnitTextBox.Text == "" ||
                    UnitsPerItemTextBox.Text == "") throw new DataException();
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
                _innerItem = new Item(NameTextBox.Text, Convert.ToDouble(QuanityTextBox.Text),type);
                this.Close();
            }
            catch(DataException)
            {
                MessageBox.Show("Не все поля заполнены, проверьте правильность ввода", "Уведомление",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        
        private void UnitTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: FIX THIS SHIT
            UnitFactorComboBox.Items.Clear();
            switch (UnitTypeComboBox.Text)
            {
                case "Вес":
                    foreach (var item in new Weight(1,1,"кг.").FactDictionary.Keys)
                    {
                        UnitFactorComboBox.Items.Add(item);
                        UnitFactorComboBox.Text = "кг.";
                    }
                    break;
                case "Объем":
                    foreach (var item in new Volume(1,1,"л.").FactDictionary.Keys)
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
    }
}
