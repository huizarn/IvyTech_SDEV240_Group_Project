using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class TableForm : Form
    {
        private MainForm mainForm;
        private DataTable table;
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
            table = new DataTable();
            table.Columns.Add("Category", typeof(String));
            table.Columns.Add("Item", typeof(String));
            table.Columns.Add("Material", typeof(String));
            table.Columns.Add("Description", typeof(String));
            table.Columns.Add("Quantity", typeof(String));
            table.Columns.Add("UnitCost", typeof(String));
            table.Columns.Add("TotalUnitCost", typeof(String)); // Add a new column for total unit cost

            DataGridView1.DataSource = table;
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

            // Format unit cost to two decimal places
            unitCost = Convert.ToDecimal(unitCost.ToString("F2"));

            // Add a new row to the DataGridView
            table.Rows.Add(category, item, material, description, quantity, unitCost.ToString("C2"));

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

            //Find what category was selected and update the text box in the main form for that category
            if (CategoryComboBox.Text == "Floors")
            {
                mainForm.UpdateFloorTextBox(unitCost * quantity);
            }
            else if (CategoryComboBox.Text == "Walls")
            {
                mainForm.UpdateWallsTextBox(unitCost * quantity);
            }
            else if (CategoryComboBox.Text == "Openings")
            {
                mainForm.UpdateOpeningsTextBox(unitCost * quantity);
            }
            else
            {
                mainForm.UpdateRoofTextBox(unitCost * quantity);
            }

            //update the total cost text box in the main form
            mainForm.UpdateTotalCostTextBox(unitCost * quantity);

            // clear the input fields after adding the row
            CategoryComboBox.Text = "";
            ItemTextBox.Clear();
            MaterialTextBox.Clear();
            DescriptionTextBox.Clear();
            QuantityTextBox.Clear();
            UnitCostTextBox.Clear();
        }

        public void ExportToExcel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int i = 1; i <= table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = table.Columns[i - 1].ColumnName;
                }

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = table.Rows[i][j];
                    }
                }

                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                string filePath = Path.Combine(downloadsPath, "MaterialsCostTable.xlsx");

                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);

                MessageBox.Show($"File saved to: {filePath}");

                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }

        public void ClearTable()
        {
            //clear the table and reset totalUnitCost
            table.Clear();
            totalUnitCost = 0;
        }
    }
}
