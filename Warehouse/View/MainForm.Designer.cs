namespace Warehouse
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainDataView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.WriteFileButton = new System.Windows.Forms.Button();
            this.ReadFileButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.PrintDBToDocButton = new System.Windows.Forms.Button();
            this.DeliverToWarehouseButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPicDrawer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicDrawer)).BeginInit();
            this.SuspendLayout();
            // 
            // MainDataView
            // 
            this.MainDataView.AccessibleName = "MainDataView";
            this.MainDataView.AllowUserToResizeRows = false;
            this.MainDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataView.Location = new System.Drawing.Point(12, 102);
            this.MainDataView.MultiSelect = false;
            this.MainDataView.Name = "MainDataView";
            this.MainDataView.ReadOnly = true;
            this.MainDataView.Size = new System.Drawing.Size(724, 227);
            this.MainDataView.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(578, 364);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(158, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить запись из БД";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // WriteFileButton
            // 
            this.WriteFileButton.Location = new System.Drawing.Point(533, 12);
            this.WriteFileButton.Name = "WriteFileButton";
            this.WriteFileButton.Size = new System.Drawing.Size(99, 23);
            this.WriteFileButton.TabIndex = 3;
            this.WriteFileButton.Text = "Сохранить БД";
            this.WriteFileButton.UseVisualStyleBackColor = true;
            this.WriteFileButton.Click += new System.EventHandler(this.WriteFileButton_Click);
            // 
            // ReadFileButton
            // 
            this.ReadFileButton.Location = new System.Drawing.Point(638, 12);
            this.ReadFileButton.Name = "ReadFileButton";
            this.ReadFileButton.Size = new System.Drawing.Size(98, 23);
            this.ReadFileButton.TabIndex = 4;
            this.ReadFileButton.Text = "Открыть БД";
            this.ReadFileButton.UseVisualStyleBackColor = true;
            this.ReadFileButton.Click += new System.EventHandler(this.ReadFileButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 76);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(724, 20);
            this.SearchBox.TabIndex = 7;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // EditItemButton
            // 
            this.EditItemButton.Location = new System.Drawing.Point(578, 335);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Size = new System.Drawing.Size(158, 23);
            this.EditItemButton.TabIndex = 9;
            this.EditItemButton.Text = "Редактировать запись";
            this.EditItemButton.UseVisualStyleBackColor = true;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_Click);
            // 
            // PrintDBToDocButton
            // 
            this.PrintDBToDocButton.Location = new System.Drawing.Point(12, 364);
            this.PrintDBToDocButton.Name = "PrintDBToDocButton";
            this.PrintDBToDocButton.Size = new System.Drawing.Size(257, 23);
            this.PrintDBToDocButton.TabIndex = 10;
            this.PrintDBToDocButton.Text = "Сформировать ведомость";
            this.PrintDBToDocButton.UseVisualStyleBackColor = true;
            this.PrintDBToDocButton.Click += new System.EventHandler(this.PrintDBToDocButton_Click);
            // 
            // DeliverToWarehouseButton
            // 
            this.DeliverToWarehouseButton.Location = new System.Drawing.Point(12, 335);
            this.DeliverToWarehouseButton.Name = "DeliverToWarehouseButton";
            this.DeliverToWarehouseButton.Size = new System.Drawing.Size(257, 23);
            this.DeliverToWarehouseButton.TabIndex = 11;
            this.DeliverToWarehouseButton.Text = "Регистрация отгрузки/поступления товара";
            this.DeliverToWarehouseButton.UseVisualStyleBackColor = true;
            this.DeliverToWarehouseButton.Click += new System.EventHandler(this.DeliverToWarehouseButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(82, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(62, 13);
            this.NameLabel.TabIndex = 13;
            this.NameLabel.Text = "Warehouse";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(82, 33);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(120, 13);
            this.VersionLabel.TabIndex = 14;
            this.VersionLabel.Text = "Version: v0.3a (Alpha 3)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Author: Oleksandr Torbiievskyii (c) 2016";
            // 
            // MainPicDrawer
            // 
            this.MainPicDrawer.InitialImage = global::Warehouse.Properties.Resources.buildings;
            this.MainPicDrawer.Location = new System.Drawing.Point(12, 6);
            this.MainPicDrawer.Name = "MainPicDrawer";
            this.MainPicDrawer.Size = new System.Drawing.Size(64, 64);
            this.MainPicDrawer.TabIndex = 12;
            this.MainPicDrawer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.MainPicDrawer);
            this.Controls.Add(this.DeliverToWarehouseButton);
            this.Controls.Add(this.PrintDBToDocButton);
            this.Controls.Add(this.EditItemButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.ReadFileButton);
            this.Controls.Add(this.WriteFileButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.MainDataView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Warehouse 0.3a";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicDrawer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainDataView;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button WriteFileButton;
        private System.Windows.Forms.Button ReadFileButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.Button PrintDBToDocButton;
        private System.Windows.Forms.Button DeliverToWarehouseButton;
        private System.Windows.Forms.PictureBox MainPicDrawer;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label1;
    }
}

