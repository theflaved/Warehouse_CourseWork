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
            //NameTextBox;
            //QuanityTextBox;
        }
    }
}
