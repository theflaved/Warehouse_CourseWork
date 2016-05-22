namespace Warehouse
{
    partial class OneItemEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.QuanityLabel = new System.Windows.Forms.Label();
            this.PricePerItemLabel = new System.Windows.Forms.Label();
            this.UnitsPerItem = new System.Windows.Forms.Label();
            this.UnitTypeLabel = new System.Windows.Forms.Label();
            this.UnitFactorLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.QuanityTextBox = new System.Windows.Forms.TextBox();
            this.UnitTypeComboBox = new System.Windows.Forms.ComboBox();
            this.UnitFactorComboBox = new System.Windows.Forms.ComboBox();
            this.PricePerUnitTextBox = new System.Windows.Forms.TextBox();
            this.UnitsPerItemTextBox = new System.Windows.Forms.TextBox();
            this.EditAcceptButton = new System.Windows.Forms.Button();
            this.EditCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(141, 9);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(83, 13);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Наименование";
            // 
            // QuanityLabel
            // 
            this.QuanityLabel.AutoSize = true;
            this.QuanityLabel.Location = new System.Drawing.Point(148, 48);
            this.QuanityLabel.Name = "QuanityLabel";
            this.QuanityLabel.Size = new System.Drawing.Size(66, 13);
            this.QuanityLabel.TabIndex = 1;
            this.QuanityLabel.Text = "Количество";
            // 
            // PricePerItemLabel
            // 
            this.PricePerItemLabel.AutoSize = true;
            this.PricePerItemLabel.Location = new System.Drawing.Point(125, 127);
            this.PricePerItemLabel.Name = "PricePerItemLabel";
            this.PricePerItemLabel.Size = new System.Drawing.Size(121, 13);
            this.PricePerItemLabel.TabIndex = 2;
            this.PricePerItemLabel.Text = "Стоимость за единицу";
            // 
            // UnitsPerItem
            // 
            this.UnitsPerItem.AutoSize = true;
            this.UnitsPerItem.Location = new System.Drawing.Point(99, 166);
            this.UnitsPerItem.Name = "UnitsPerItem";
            this.UnitsPerItem.Size = new System.Drawing.Size(167, 13);
            this.UnitsPerItem.TabIndex = 3;
            this.UnitsPerItem.Text = "Единиц счета в единице товара";
            // 
            // UnitTypeLabel
            // 
            this.UnitTypeLabel.AutoSize = true;
            this.UnitTypeLabel.Location = new System.Drawing.Point(66, 87);
            this.UnitTypeLabel.Name = "UnitTypeLabel";
            this.UnitTypeLabel.Size = new System.Drawing.Size(65, 13);
            this.UnitTypeLabel.TabIndex = 7;
            this.UnitTypeLabel.Text = "Тип единиц";
            // 
            // UnitFactorLabel
            // 
            this.UnitFactorLabel.AutoSize = true;
            this.UnitFactorLabel.Location = new System.Drawing.Point(194, 87);
            this.UnitFactorLabel.Name = "UnitFactorLabel";
            this.UnitFactorLabel.Size = new System.Drawing.Size(122, 13);
            this.UnitFactorLabel.TabIndex = 8;
            this.UnitFactorLabel.Text = "Наименование единиц";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 25);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(334, 20);
            this.NameTextBox.TabIndex = 9;
            // 
            // QuanityTextBox
            // 
            this.QuanityTextBox.Location = new System.Drawing.Point(12, 64);
            this.QuanityTextBox.Name = "QuanityTextBox";
            this.QuanityTextBox.Size = new System.Drawing.Size(334, 20);
            this.QuanityTextBox.TabIndex = 10;
            // 
            // UnitTypeComboBox
            // 
            this.UnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitTypeComboBox.FormattingEnabled = true;
            this.UnitTypeComboBox.Items.AddRange(new object[] {
            "Вес",
            "Объем",
            "Количество"});
            this.UnitTypeComboBox.Location = new System.Drawing.Point(12, 103);
            this.UnitTypeComboBox.Name = "UnitTypeComboBox";
            this.UnitTypeComboBox.Size = new System.Drawing.Size(164, 21);
            this.UnitTypeComboBox.TabIndex = 11;
            this.UnitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.UnitTypeComboBox_SelectedIndexChanged);
            // 
            // UnitFactorComboBox
            // 
            this.UnitFactorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitFactorComboBox.FormattingEnabled = true;
            this.UnitFactorComboBox.Location = new System.Drawing.Point(182, 103);
            this.UnitFactorComboBox.Name = "UnitFactorComboBox";
            this.UnitFactorComboBox.Size = new System.Drawing.Size(164, 21);
            this.UnitFactorComboBox.TabIndex = 12;
            // 
            // PricePerUnitTextBox
            // 
            this.PricePerUnitTextBox.Location = new System.Drawing.Point(12, 143);
            this.PricePerUnitTextBox.Name = "PricePerUnitTextBox";
            this.PricePerUnitTextBox.Size = new System.Drawing.Size(334, 20);
            this.PricePerUnitTextBox.TabIndex = 13;
            // 
            // UnitsPerItemTextBox
            // 
            this.UnitsPerItemTextBox.Location = new System.Drawing.Point(12, 182);
            this.UnitsPerItemTextBox.Name = "UnitsPerItemTextBox";
            this.UnitsPerItemTextBox.Size = new System.Drawing.Size(334, 20);
            this.UnitsPerItemTextBox.TabIndex = 14;
            // 
            // EditAcceptButton
            // 
            this.EditAcceptButton.Location = new System.Drawing.Point(12, 208);
            this.EditAcceptButton.Name = "EditAcceptButton";
            this.EditAcceptButton.Size = new System.Drawing.Size(143, 23);
            this.EditAcceptButton.TabIndex = 16;
            this.EditAcceptButton.Text = "Принять";
            this.EditAcceptButton.UseVisualStyleBackColor = true;
            this.EditAcceptButton.Click += new System.EventHandler(this.EditAcceptButton_Click);
            // 
            // EditCancelButton
            // 
            this.EditCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EditCancelButton.Location = new System.Drawing.Point(197, 208);
            this.EditCancelButton.Name = "EditCancelButton";
            this.EditCancelButton.Size = new System.Drawing.Size(149, 23);
            this.EditCancelButton.TabIndex = 17;
            this.EditCancelButton.Text = "Отменить";
            this.EditCancelButton.UseVisualStyleBackColor = true;
            this.EditCancelButton.Click += new System.EventHandler(this.EditCancelButton_Click);
            // 
            // OneItemEditForm
            // 
            this.AcceptButton = this.EditAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EditCancelButton;
            this.ClientSize = new System.Drawing.Size(355, 240);
            this.Controls.Add(this.EditCancelButton);
            this.Controls.Add(this.EditAcceptButton);
            this.Controls.Add(this.UnitsPerItemTextBox);
            this.Controls.Add(this.PricePerUnitTextBox);
            this.Controls.Add(this.UnitFactorComboBox);
            this.Controls.Add(this.UnitTypeComboBox);
            this.Controls.Add(this.QuanityTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.UnitFactorLabel);
            this.Controls.Add(this.UnitTypeLabel);
            this.Controls.Add(this.UnitsPerItem);
            this.Controls.Add(this.PricePerItemLabel);
            this.Controls.Add(this.QuanityLabel);
            this.Controls.Add(this.ItemNameLabel);
            this.Name = "OneItemEditForm";
            this.Text = "Редактирование товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label QuanityLabel;
        private System.Windows.Forms.Label PricePerItemLabel;
        private System.Windows.Forms.Label UnitsPerItem;
        private System.Windows.Forms.Label UnitTypeLabel;
        private System.Windows.Forms.Label UnitFactorLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox QuanityTextBox;
        private System.Windows.Forms.ComboBox UnitTypeComboBox;
        private System.Windows.Forms.ComboBox UnitFactorComboBox;
        private System.Windows.Forms.TextBox PricePerUnitTextBox;
        private System.Windows.Forms.TextBox UnitsPerItemTextBox;
        private System.Windows.Forms.Button EditAcceptButton;
        private System.Windows.Forms.Button EditCancelButton;
    }
}