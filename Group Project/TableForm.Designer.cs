namespace Group_Project
{
    partial class TableForm
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
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.ItemTextBox = new System.Windows.Forms.TextBox();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.UnitCostTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.MaterialTextBox = new System.Windows.Forms.TextBox();
            this.UnitCostLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.MaterialLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CategoryComboBox.Location = new System.Drawing.Point(248, 116);
            this.CategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(160, 24);
            this.CategoryComboBox.TabIndex = 0;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.Location = new System.Drawing.Point(287, 92);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(76, 20);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "Category";
            // 
            // ItemTextBox
            // 
            this.ItemTextBox.Location = new System.Drawing.Point(51, 266);
            this.ItemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ItemTextBox.Name = "ItemTextBox";
            this.ItemTextBox.Size = new System.Drawing.Size(132, 22);
            this.ItemTextBox.TabIndex = 2;
            this.ItemTextBox.TextChanged += new System.EventHandler(this.ItemTextBox_TextChanged);
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLabel.Location = new System.Drawing.Point(93, 242);
            this.ItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(41, 20);
            this.ItemLabel.TabIndex = 3;
            this.ItemLabel.Text = "Item";
            // 
            // UnitCostTextBox
            // 
            this.UnitCostTextBox.Location = new System.Drawing.Point(372, 388);
            this.UnitCostTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnitCostTextBox.Name = "UnitCostTextBox";
            this.UnitCostTextBox.Size = new System.Drawing.Size(132, 22);
            this.UnitCostTextBox.TabIndex = 4;
            this.UnitCostTextBox.TextChanged += new System.EventHandler(this.UnitCostTextBox_TextChanged);
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(148, 388);
            this.QuantityTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(132, 22);
            this.QuantityTextBox.TabIndex = 5;
            this.QuantityTextBox.TextChanged += new System.EventHandler(this.QuantityTextBox_TextChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(471, 266);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(132, 22);
            this.DescriptionTextBox.TabIndex = 6;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
            // 
            // MaterialTextBox
            // 
            this.MaterialTextBox.Location = new System.Drawing.Point(264, 266);
            this.MaterialTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaterialTextBox.Name = "MaterialTextBox";
            this.MaterialTextBox.Size = new System.Drawing.Size(132, 22);
            this.MaterialTextBox.TabIndex = 7;
            this.MaterialTextBox.TextChanged += new System.EventHandler(this.MaterialTextBox_TextChanged);
            // 
            // UnitCostLabel
            // 
            this.UnitCostLabel.AutoSize = true;
            this.UnitCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitCostLabel.Location = new System.Drawing.Point(397, 364);
            this.UnitCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UnitCostLabel.Name = "UnitCostLabel";
            this.UnitCostLabel.Size = new System.Drawing.Size(79, 20);
            this.UnitCostLabel.TabIndex = 8;
            this.UnitCostLabel.Text = "Unit Cost";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLabel.Location = new System.Drawing.Point(181, 364);
            this.QuantityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(71, 20);
            this.QuantityLabel.TabIndex = 9;
            this.QuantityLabel.Text = "Quantity";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(489, 242);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(95, 20);
            this.DescriptionLabel.TabIndex = 10;
            this.DescriptionLabel.Text = "Description";
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.AutoSize = true;
            this.MaterialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialLabel.Location = new System.Drawing.Point(296, 242);
            this.MaterialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(69, 20);
            this.MaterialLabel.TabIndex = 11;
            this.MaterialLabel.Text = "Material";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(69, 505);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 28);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(489, 505);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 28);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(269, 505);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 28);
            this.UpdateButton.TabIndex = 14;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(700, 2);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 51;
            this.DataGridView1.Size = new System.Drawing.Size(1000, 620);
            this.DataGridView1.TabIndex = 15;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(982, 623);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MaterialLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.UnitCostLabel);
            this.Controls.Add(this.MaterialTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.UnitCostTextBox);
            this.Controls.Add(this.ItemLabel);
            this.Controls.Add(this.ItemTextBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TableForm";
            this.Text = "Materials List Table";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox ItemTextBox;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.TextBox UnitCostTextBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox MaterialTextBox;
        private System.Windows.Forms.Label UnitCostLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label MaterialLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        public System.Windows.Forms.DataGridView DataGridView1;
    }
}