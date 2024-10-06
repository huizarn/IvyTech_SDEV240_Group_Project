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
        private decimal floorCost = 0, wallsCost = 0, openingsCost = 0, roofCost = 0, totalUnitCost = 0; // Fields to store the cost of categories as well as total cost

        public TableForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;


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
            table.Columns.Add("Cost", typeof(String)); // Add new column for Cost

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
            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(item) ||
                string.IsNullOrWhiteSpace(material) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) || string.IsNullOrWhiteSpace(UnitCostTextBox.Text))
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

            // Calculate the cost
            decimal cost = unitCost * quantity;

            // Add a new row to the DataGridView
            table.Rows.Add(category, item, material, description, quantity, unitCost.ToString("C2"), cost.ToString("C2"));

            // Update the total unit cost
            totalUnitCost += cost;

            //update the total cost text box
            TotalCostTextBox.Text = totalUnitCost.ToString();

            // Find what category was selected and update the cost value stored for that category
            if (CategoryComboBox.Text == "Floors")
            {
                floorCost += cost;
            }
            else if (CategoryComboBox.Text == "Walls")
            {
                wallsCost += cost;
            }
            else if (CategoryComboBox.Text == "Openings")
            {
                openingsCost += cost;
            }
            else
            {
                roofCost += cost;
            }

            // Update the category text boxes in the main form
            mainForm.UpdateCategories(floorCost, wallsCost, openingsCost, roofCost, totalUnitCost);

            // Clear the input fields after adding the row
            ItemTextBox.Clear();
            MaterialTextBox.Clear();
            DescriptionTextBox.Clear();
            QuantityTextBox.Clear();
            UnitCostTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;//set the category combo box to empty
        }

        public void ExportToExcel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                //add the column names to the excel worksheet
                for (int i = 1; i <= table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = table.Columns[i - 1].ColumnName;
                }

                //add all the rows in the data table to the excel worksheet
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = table.Rows[i][j];
                    }
                }

                int totalRow = table.Rows.Count + 2;//find the row below the last one in the data table
                
                //add total cost to the excel worksheet in the row below the last row in the data table
                worksheet.Cells[totalRow, 6].Value = "Total Cost";
                worksheet.Cells[totalRow, 7].Value = TotalCostTextBox.Text;

                //get the path to the users downloads folder and assign it to a variable
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                //combine the path to the downloads folder with the name of the file to get the path the file will be saved to
                string filePath = Path.Combine(downloadsPath, "MaterialsCostTable.xlsx");

                //save the file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);

                //open the file
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                MessageBox.Show($"File saved to: {filePath}");
            }
        }

        public void ClearTable()
        {
            // Clear the table and reset totalUnitCost
            table.Clear();
            floorCost = 0;
            wallsCost = 0;
            openingsCost = 0;
            roofCost = 0;
            totalUnitCost = 0;
        }

        private void UpdateButton_Click_1(object sender, EventArgs e)
        {
            int index = 0;

            //ensure a row is selected before trying to update and throw an error if one is not
            if (DataGridView1.CurrentCell != null)
            {
                index = DataGridView1.CurrentCell.RowIndex;
            }
            else
            {
                MessageBox.Show("Please ensure you have a row selected before trying to use the update button.");
                return;
            }

            if (index > -1)
            {
                int quantity;
                decimal unitCost;

                // Validate and parse quantity
                if (QuantityTextBox.Text != "")//ignore trying to parse if the text box is empty
                {
                    if (!int.TryParse(QuantityTextBox.Text, out quantity))
                    {
                        MessageBox.Show("Please enter a valid whole number for Quantity.");
                        return;
                    }
                }

                // Validate and parse unit cost
                if (UnitCostTextBox.Text != "")//ignore trying to parse if the text box is empty
                {
                    if (!decimal.TryParse(UnitCostTextBox.Text, out unitCost))
                    {
                        MessageBox.Show("Please enter a valid decimal number for Unit Cost.");
                        return;
                    }
                }

                // Update the DataTable
                if (ItemTextBox.Text != "")//if a text box is empty, dont update the value (so the user doesn't have to fill every field when updating)
                {
                    table.Rows[index][1] = ItemTextBox.Text;
                }
                if (MaterialTextBox.Text != "")
                {
                    table.Rows[index][2] = MaterialTextBox.Text;
                }
                if (DescriptionTextBox.Text != "")
                {
                    table.Rows[index][3] = DescriptionTextBox.Text;
                }
                if (QuantityTextBox.Text != "")
                {
                    table.Rows[index][4] = QuantityTextBox.Text;
                }
                if (UnitCostTextBox.Text != "")
                {
                    table.Rows[index][5] = decimal.Parse(UnitCostTextBox.Text).ToString("C2");
                }

                //set the unit cost and cost from the data table to a string and remove the first value from the string so the $ is removed from them and they can
                //be converted to decimal
                string unitCostString = table.Rows[index][5].ToString();
                string correctedUnitCost = unitCostString.Substring(1);
                string oldCost = table.Rows[index][6].ToString();
                string correctedOldCost = oldCost.Substring(1);

                //set costChange as the new cost to be updated to minus the old cost
                decimal costChange = (Convert.ToInt32(table.Rows[index][4]) * Convert.ToDecimal(correctedUnitCost) - Convert.ToDecimal(correctedOldCost));

                //update totalUnitcost based on cost change and update total cost text box
                totalUnitCost += costChange;
                TotalCostTextBox.Text = totalUnitCost.ToString();

                // Find what category the updated row had in it and update the cost value stored for that category
                if (table.Rows[index][0].ToString() == "Floors")
                {
                    floorCost += costChange;
                }
                else if (table.Rows[index][0].ToString() == "Walls")
                {
                    wallsCost += costChange;
                }
                else if (table.Rows[index][0].ToString() == "Openings")
                {
                    openingsCost += costChange;
                }
                else
                {
                    roofCost += costChange;
                }

                mainForm.UpdateCategories(floorCost, wallsCost, openingsCost, roofCost, totalUnitCost);// Update the category text boxes in the main form

                //set the cost to its new value based on the new quantity and unit cost
                table.Rows[index][6] = (Convert.ToInt32(table.Rows[index][4]) * Convert.ToDecimal(correctedUnitCost)).ToString("C2");

                // Refresh the DataGridView if necessary (typically not needed if it's bound properly)
                DataGridView1.Refresh();

                // Clear the input fields after updating the row
                ItemTextBox.Clear();
                MaterialTextBox.Clear();
                DescriptionTextBox.Clear();
                QuantityTextBox.Clear();
                UnitCostTextBox.Clear();
                CategoryComboBox.SelectedIndex = -1;//set the category combo box to empty
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //ensure a row is selected before trying to delete and throw an error if one is not
            int index = 0;

            if (DataGridView1.CurrentCell != null)
            {
                index = DataGridView1.CurrentCell.RowIndex;
            }
            else
            {
                MessageBox.Show("Please ensure you have a row selected before trying to use the delete button.");
                return;
            }

            //set the cost of the row to be deleted to a string and remove the first value of the string so the $ is removed and it can be parsed to a decimal value
            string cost = table.Rows[index][6].ToString();
            string correctedCost = cost.Substring(1);

            // Find what category the to be deleted row had in it and update the cost value stored for that category
            if (table.Rows[index][0].ToString() == "Floors")
            {
                floorCost -= decimal.Parse(correctedCost);
            }
            else if (table.Rows[index][0].ToString() == "Walls")
            {
                wallsCost -= decimal.Parse(correctedCost);
            }
            else if (table.Rows[index][0].ToString() == "Openings")
            {
                openingsCost -= decimal.Parse(correctedCost);
            }
            else
            {
                roofCost -= decimal.Parse(correctedCost);
            }

            totalUnitCost -= decimal.Parse(correctedCost);//update the total unit cost

            mainForm.UpdateCategories(floorCost, wallsCost, openingsCost, roofCost, totalUnitCost);// Update the category text boxes in the main form

            TotalCostTextBox.Text = totalUnitCost.ToString();//update the total cost text box

            table.Rows[index].Delete();//delete the row
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel1.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.homedepot.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel2.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.lowes.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel3.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.menards.com/main/home.html");
        }

        //this function gives a warning if the user tries to close the tableform, and resets the forms if they do
        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("If you close this window now, the tables data will be lost. Are you sure you wish to continue?",
                                         "Close Confirmation",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            mainForm.ResetForms();
        }
    }
}
