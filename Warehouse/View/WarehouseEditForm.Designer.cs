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
            this.components = new System.ComponentModel.Container();
            this.MainEditDataView = new System.Windows.Forms.DataGridView();
            this.warehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OldMainDataView = new System.Windows.Forms.DataGridView();
            this.OldSearchBox = new System.Windows.Forms.TextBox();
            this.NewSearchBox = new System.Windows.Forms.TextBox();
            this.AddToEditButton = new System.Windows.Forms.Button();
            this.DeleteFromEditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FinalizeFormButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.CreateDocFile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainEditDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Изменяемый товар";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Основная БД товаров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Нажмите два раза на товар чтобы создать запись о его прибытии или отгрузке";
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
            // CreateDocFile
            // 
            this.CreateDocFile.AutoSize = true;
            this.CreateDocFile.Location = new System.Drawing.Point(94, 519);
            this.CreateDocFile.Name = "CreateDocFile";
            this.CreateDocFile.Size = new System.Drawing.Size(126, 17);
            this.CreateDocFile.TabIndex = 11;
            this.CreateDocFile.Text = "Создать накладную";
            this.CreateDocFile.UseVisualStyleBackColor = true;
            // 
            // WarehouseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 545);
            this.Controls.Add(this.CreateDocFile);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.FinalizeFormButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteFromEditButton);
            this.Controls.Add(this.AddToEditButton);
            this.Controls.Add(this.NewSearchBox);
            this.Controls.Add(this.OldSearchBox);
            this.Controls.Add(this.OldMainDataView);
            this.Controls.Add(this.MainEditDataView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseEditForm";
            this.Text = "Регистрация отгрузки/завоза товара";
            this.Load += new System.EventHandler(this.WarehouseEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainEditDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FinalizeFormButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.CheckBox CreateDocFile;
        private System.Windows.Forms.BindingSource warehouseBindingSource;
    }
}