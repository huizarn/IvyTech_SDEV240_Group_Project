using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class TableForm : Form
    {
        private MainForm mainForm;
        private decimal totalUnitCost = 0; // Field to store the total unit cost

        public TableForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Set the DropDownStyle to allow user input
            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDown;

            // Add items to the CategoryComboBox
            CategoryComboBox.Items.Add("Floors");
            CategoryComboBox.Items.Add("Walls");
            CategoryComboBox.Items.Add("Openings");
            CategoryComboBox.Items.Add("Roof");

            // Add columns to the DataGridView
            DataGridView1.Columns.Add("Category", "Category");
            DataGridView1.Columns.Add("Item", "Item");
            DataGridView1.Columns.Add("Material", "Material");
            DataGridView1.Columns.Add("Description", "Description");
            DataGridView1.Columns.Add("Quantity", "Quantity");
            DataGridView1.Columns.Add("UnitCost", "Unit Cost (USD)");
            DataGridView1.Columns.Add("TotalUnitCost", "Total Unit Cost (USD)"); // Add a new column for total unit cost
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaterialTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Get the input values
            string category = CategoryComboBox.Text;
            string item = ItemTextBox.Text;
            string material = MaterialTextBox.Text;
            string description = DescriptionTextBox.Text;
            int quantity;
            decimal unitCost;

            // Check if all fields are empty
            if (string.IsNullOrWhiteSpace(category) && string.IsNullOrWhiteSpace(item) &&
                string.IsNullOrWhiteSpace(material) && string.IsNullOrWhiteSpace(description) &&
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) && string.IsNullOrWhiteSpace(UnitCostTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields before adding.");
                return;
            }

            // Validate and parse quantity
            if (!int.TryParse(QuantityTextBox.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid whole number for Quantity.");
                return;
            }

            // Validate and parse unit cost
            if (!decimal.TryParse(UnitCostTextBox.Text, out unitCost))
            {
                MessageBox.Show("Please enter a valid decimal number for Unit Cost.");
                return;
            }

            // Format unit cost to two decimal places and add dollar sign
            string formattedUnitCost = unitCost.ToString("C2");

            // Add a new row to the DataGridView
            DataGridView1.Rows.Add(category, item, material, description, quantity, formattedUnitCost);

            // Update the total unit cost
            totalUnitCost += unitCost * quantity;

            // Add or update the total unit cost row
            if (DataGridView1.Rows.Count > 1 && DataGridView1.Rows[DataGridView1.Rows.Count - 1].Cells[0].Value == null)
            {
                DataGridView1.Rows[DataGridView1.Rows.Count - 1].Cells["TotalUnitCost"].Value = totalUnitCost.ToString("C2");
            }
            else
            {
                DataGridView1.Rows.Add(null, null, null, null, null, null, totalUnitCost.ToString("C2"));
            }

            // lear the input fields after adding the row
            CategoryComboBox.Text = "";
            ItemTextBox.Clear();
            MaterialTextBox.Clear();
            DescriptionTextBox.Clear();
            QuantityTextBox.Clear();
            UnitCostTextBox.Clear();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UnitCostTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
