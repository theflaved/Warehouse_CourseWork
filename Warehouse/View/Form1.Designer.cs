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
            this.MainDataView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.WriteFileButton = new System.Windows.Forms.Button();
            this.ReadFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.PrintDBToDocButton = new System.Windows.Forms.Button();
            this.DeliverToWarehouseButton = new System.Windows.Forms.Button();
            this.DeliverFromWarehouseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainDataView
            // 
            this.MainDataView.AccessibleName = "MainDataView";
            this.MainDataView.AllowUserToResizeRows = false;
            this.MainDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataView.Location = new System.Drawing.Point(12, 111);
            this.MainDataView.MultiSelect = false;
            this.MainDataView.Name = "MainDataView";
            this.MainDataView.ReadOnly = true;
            this.MainDataView.Size = new System.Drawing.Size(724, 227);
            this.MainDataView.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(93, 344);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(12, 344);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(75, 23);
            this.AddItemButton.TabIndex = 2;
            this.AddItemButton.Text = "Добавить";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // WriteFileButton
            // 
            this.WriteFileButton.Location = new System.Drawing.Point(637, 344);
            this.WriteFileButton.Name = "WriteFileButton";
            this.WriteFileButton.Size = new System.Drawing.Size(99, 23);
            this.WriteFileButton.TabIndex = 3;
            this.WriteFileButton.Text = "Сохранить БД";
            this.WriteFileButton.UseVisualStyleBackColor = true;
            this.WriteFileButton.Click += new System.EventHandler(this.WriteFileButton_Click);
            // 
            // ReadFileButton
            // 
            this.ReadFileButton.Location = new System.Drawing.Point(533, 344);
            this.ReadFileButton.Name = "ReadFileButton";
            this.ReadFileButton.Size = new System.Drawing.Size(98, 23);
            this.ReadFileButton.TabIndex = 4;
            this.ReadFileButton.Text = "Открыть БД";
            this.ReadFileButton.UseVisualStyleBackColor = true;
            this.ReadFileButton.Click += new System.EventHandler(this.ReadFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Warehouse Alpha";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 85);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(605, 20);
            this.SearchBox.TabIndex = 7;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(623, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 20);
            this.button5.TabIndex = 8;
            this.button5.Text = "Особый поиск";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditItemButton
            // 
            this.EditItemButton.Location = new System.Drawing.Point(174, 344);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Size = new System.Drawing.Size(158, 23);
            this.EditItemButton.TabIndex = 9;
            this.EditItemButton.Text = "Редактировать запись";
            this.EditItemButton.UseVisualStyleBackColor = true;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_Click);
            // 
            // PrintDBToDocButton
            // 
            this.PrintDBToDocButton.Location = new System.Drawing.Point(398, 26);
            this.PrintDBToDocButton.Name = "PrintDBToDocButton";
            this.PrintDBToDocButton.Size = new System.Drawing.Size(166, 23);
            this.PrintDBToDocButton.TabIndex = 10;
            this.PrintDBToDocButton.Text = "Сформировать ведомость";
            this.PrintDBToDocButton.UseVisualStyleBackColor = true;
            this.PrintDBToDocButton.Click += new System.EventHandler(this.PrintDBToDocButton_Click);
            // 
            // DeliverToWarehouseButton
            // 
            this.DeliverToWarehouseButton.Location = new System.Drawing.Point(570, 12);
            this.DeliverToWarehouseButton.Name = "DeliverToWarehouseButton";
            this.DeliverToWarehouseButton.Size = new System.Drawing.Size(166, 23);
            this.DeliverToWarehouseButton.TabIndex = 11;
            this.DeliverToWarehouseButton.Text = "Поступление товара";
            this.DeliverToWarehouseButton.UseVisualStyleBackColor = true;
            this.DeliverToWarehouseButton.Click += new System.EventHandler(this.DeliverToWarehouseButton_Click);
            // 
            // DeliverFromWarehouseButton
            // 
            this.DeliverFromWarehouseButton.Location = new System.Drawing.Point(570, 41);
            this.DeliverFromWarehouseButton.Name = "DeliverFromWarehouseButton";
            this.DeliverFromWarehouseButton.Size = new System.Drawing.Size(166, 23);
            this.DeliverFromWarehouseButton.TabIndex = 12;
            this.DeliverFromWarehouseButton.Text = "Отгрузка";
            this.DeliverFromWarehouseButton.UseVisualStyleBackColor = true;
            this.DeliverFromWarehouseButton.Click += new System.EventHandler(this.DeliverFromWarehouseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 379);
            this.Controls.Add(this.DeliverFromWarehouseButton);
            this.Controls.Add(this.DeliverToWarehouseButton);
            this.Controls.Add(this.PrintDBToDocButton);
            this.Controls.Add(this.EditItemButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReadFileButton);
            this.Controls.Add(this.WriteFileButton);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.MainDataView);
            this.Name = "Form1";
            this.Text = "Warehouse Alpha";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainDataView;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button WriteFileButton;
        private System.Windows.Forms.Button ReadFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.Button PrintDBToDocButton;
        private System.Windows.Forms.Button DeliverToWarehouseButton;
        private System.Windows.Forms.Button DeliverFromWarehouseButton;
    }
}

