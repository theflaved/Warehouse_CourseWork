namespace Warehouse
{
    partial class WarehouseEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseEditForm));
            this.MainEditDataView = new System.Windows.Forms.DataGridView();
            this.OldMainDataView = new System.Windows.Forms.DataGridView();
            this.OldSearchBox = new System.Windows.Forms.TextBox();
            this.NewSearchBox = new System.Windows.Forms.TextBox();
            this.AddToEditButton = new System.Windows.Forms.Button();
            this.DeleteFromEditButton = new System.Windows.Forms.Button();
            this.EditLabel = new System.Windows.Forms.Label();
            this.BDLabel = new System.Windows.Forms.Label();
            this.NoteLabel = new System.Windows.Forms.Label();
            this.FinalizeFormButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.EditOnceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldMainDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainEditDataView
            // 
            this.MainEditDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainEditDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainEditDataView.Location = new System.Drawing.Point(12, 48);
            this.MainEditDataView.Name = "MainEditDataView";
            this.MainEditDataView.Size = new System.Drawing.Size(929, 183);
            this.MainEditDataView.TabIndex = 0;
            // 
            // OldMainDataView
            // 
            this.OldMainDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OldMainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OldMainDataView.Location = new System.Drawing.Point(12, 313);
            this.OldMainDataView.Name = "OldMainDataView";
            this.OldMainDataView.ReadOnly = true;
            this.OldMainDataView.Size = new System.Drawing.Size(929, 183);
            this.OldMainDataView.TabIndex = 1;
            this.OldMainDataView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OldMainDataView_CellMouseDoubleClick);
            // 
            // OldSearchBox
            // 
            this.OldSearchBox.Location = new System.Drawing.Point(12, 287);
            this.OldSearchBox.Name = "OldSearchBox";
            this.OldSearchBox.Size = new System.Drawing.Size(929, 20);
            this.OldSearchBox.TabIndex = 2;
            this.OldSearchBox.TextChanged += new System.EventHandler(this.OldSearchBox_TextChanged);
            // 
            // NewSearchBox
            // 
            this.NewSearchBox.Location = new System.Drawing.Point(12, 22);
            this.NewSearchBox.Name = "NewSearchBox";
            this.NewSearchBox.Size = new System.Drawing.Size(929, 20);
            this.NewSearchBox.TabIndex = 3;
            this.NewSearchBox.TextChanged += new System.EventHandler(this.NewSearchBox_TextChanged);
            // 
            // AddToEditButton
            // 
            this.AddToEditButton.Location = new System.Drawing.Point(12, 237);
            this.AddToEditButton.Name = "AddToEditButton";
            this.AddToEditButton.Size = new System.Drawing.Size(192, 23);
            this.AddToEditButton.TabIndex = 4;
            this.AddToEditButton.Text = "Добавить новый товар";
            this.AddToEditButton.UseVisualStyleBackColor = true;
            this.AddToEditButton.Click += new System.EventHandler(this.AddToEditButton_Click);
            // 
            // DeleteFromEditButton
            // 
            this.DeleteFromEditButton.Location = new System.Drawing.Point(728, 237);
            this.DeleteFromEditButton.Name = "DeleteFromEditButton";
            this.DeleteFromEditButton.Size = new System.Drawing.Size(213, 23);
            this.DeleteFromEditButton.TabIndex = 5;
            this.DeleteFromEditButton.Text = "Удалить товар из списка изменяемых";
            this.DeleteFromEditButton.UseVisualStyleBackColor = true;
            this.DeleteFromEditButton.Click += new System.EventHandler(this.DeleteFromEditButton_Click);
            // 
            // EditLabel
            // 
            this.EditLabel.AutoSize = true;
            this.EditLabel.Location = new System.Drawing.Point(400, 6);
            this.EditLabel.Name = "EditLabel";
            this.EditLabel.Size = new System.Drawing.Size(107, 13);
            this.EditLabel.TabIndex = 6;
            this.EditLabel.Text = "Изменяемый товар";
            // 
            // BDLabel
            // 
            this.BDLabel.AutoSize = true;
            this.BDLabel.Location = new System.Drawing.Point(400, 271);
            this.BDLabel.Name = "BDLabel";
            this.BDLabel.Size = new System.Drawing.Size(120, 13);
            this.BDLabel.TabIndex = 7;
            this.BDLabel.Text = "Основная БД товаров";
            // 
            // NoteLabel
            // 
            this.NoteLabel.AutoSize = true;
            this.NoteLabel.Location = new System.Drawing.Point(9, 499);
            this.NoteLabel.Name = "NoteLabel";
            this.NoteLabel.Size = new System.Drawing.Size(415, 13);
            this.NoteLabel.TabIndex = 8;
            this.NoteLabel.Text = "Нажмите два раза на товар чтобы создать запись о его прибытии или отгрузке";
            // 
            // FinalizeFormButton
            // 
            this.FinalizeFormButton.Location = new System.Drawing.Point(12, 515);
            this.FinalizeFormButton.Name = "FinalizeFormButton";
            this.FinalizeFormButton.Size = new System.Drawing.Size(76, 23);
            this.FinalizeFormButton.TabIndex = 9;
            this.FinalizeFormButton.Text = "Завершить";
            this.FinalizeFormButton.UseVisualStyleBackColor = true;
            this.FinalizeFormButton.Click += new System.EventHandler(this.FinalizeFormButton_Click);
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Location = new System.Drawing.Point(860, 515);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(81, 23);
            this.CancelFormButton.TabIndex = 10;
            this.CancelFormButton.Text = "Отменить";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelFormButton_Click);
            // 
            // EditOnceButton
            // 
            this.EditOnceButton.Location = new System.Drawing.Point(576, 237);
            this.EditOnceButton.Name = "EditOnceButton";
            this.EditOnceButton.Size = new System.Drawing.Size(146, 23);
            this.EditOnceButton.TabIndex = 12;
            this.EditOnceButton.Text = "Редактировать запись";
            this.EditOnceButton.UseVisualStyleBackColor = true;
            this.EditOnceButton.Click += new System.EventHandler(this.EditOnceButton_Click);
            // 
            // WarehouseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 545);
            this.Controls.Add(this.EditOnceButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.FinalizeFormButton);
            this.Controls.Add(this.NoteLabel);
            this.Controls.Add(this.BDLabel);
            this.Controls.Add(this.EditLabel);
            this.Controls.Add(this.DeleteFromEditButton);
            this.Controls.Add(this.AddToEditButton);
            this.Controls.Add(this.NewSearchBox);
            this.Controls.Add(this.OldSearchBox);
            this.Controls.Add(this.OldMainDataView);
            this.Controls.Add(this.MainEditDataView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseEditForm";
            this.Text = "Регистрация отгрузки/завоза товара";
            this.Load += new System.EventHandler(this.WarehouseEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainEditDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldMainDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainEditDataView;
        private System.Windows.Forms.DataGridView OldMainDataView;
        private System.Windows.Forms.TextBox OldSearchBox;
        private System.Windows.Forms.TextBox NewSearchBox;
        private System.Windows.Forms.Button AddToEditButton;
        private System.Windows.Forms.Button DeleteFromEditButton;
        private System.Windows.Forms.Label EditLabel;
        private System.Windows.Forms.Label BDLabel;
        private System.Windows.Forms.Label NoteLabel;
        private System.Windows.Forms.Button FinalizeFormButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button EditOnceButton;
    }
}