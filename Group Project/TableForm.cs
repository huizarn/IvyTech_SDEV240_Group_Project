using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class TableForm : Form
    {
        private MainForm mainForm;

        DataTable table;
        public TableForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Material", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Unit Cost", typeof(string));

            DataGridView1.DataSource = table;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int index = DataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                // Optionally validate inputs before updating

                // Update the DataTable
                table.Rows[index][0] = CategoryComboBox.Text;
                table.Rows[index][1] = ItemTextBox.Text;
                table.Rows[index][2] = MaterialTextBox.Text;
                table.Rows[index][3] = DescriptionTextBox.Text;
                table.Rows[index][4] = QuantityTextBox.Text;
                table.Rows[index][5] = UnitCostTextBox.Text;

                // Refresh the DataGridView if necessary (typically not needed if it's bound properly)
                DataGridView1.Refresh();
            
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            table.Rows.Add(CategoryComboBox.Text, ItemTextBox.Text, MaterialTextBox.Text, DescriptionTextBox.Text, QuantityTextBox.Text, UnitCostTextBox.Text);
            
            ItemTextBox.Clear();
            MaterialTextBox.Clear();
            DescriptionTextBox.Clear();
            QuantityTextBox.Clear();
            UnitCostTextBox.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = DataGridView1.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.homedepot.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.lowes.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.menards.com/main/home.html");
        }
    }
}
