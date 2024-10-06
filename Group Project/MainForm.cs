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
    public partial class MainForm : Form
    {
        private TableForm tableForm;
        public MainForm()
        {
            InitializeComponent();
            InitializeTextBoxes();
        }

        //Create and open the TableForm or just show it if it is already created
        private void OpenMaterialsListTableButton_Click(object sender, EventArgs e)
        {
            if (tableForm == null)
            {
                tableForm = new TableForm(this);
            }
            tableForm.Show();
        }
        //this method is used to update the category text boxes 
        public void UpdateCategories(decimal floorCost, decimal wallsCost, decimal openingsCost, decimal roofCost, decimal totalCost)
        {
            FloorTextBox.Text = floorCost.ToString();
            WallsTextBox.Text = wallsCost.ToString();
            OpeningsTextBox.Text = openingsCost.ToString();
            RoofTextBox.Text = roofCost.ToString();
            TotalCostTextBox.Text = totalCost.ToString();
        }
        //this method saves the table to an excel sheet and opens the excel sheet
        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            if (tableForm == null)//ensure the table form is open before performing the save method
            {
                MessageBox.Show("The table has not been opened yet. Please ensure the table is open before trying to save it");
                return;
            }

            tableForm.ExportToExcel();
        }

        private void ClearTableButton_Click(object sender, EventArgs e)
        {
            if(tableForm == null)//ensure the table form is open before performing the clear method
            {
                MessageBox.Show("The table has not been opened yet. Please ensure the table is open before trying to clear it");
                return;
            }

            //create a message that warns the user that this action is permanent
            DialogResult result = MessageBox.Show("This action cannot be undone. Are you sure you wish to proceed?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)//if the user clicks ok
            {
                tableForm.ClearTable();
                
                //reset the textboxes to zero
                InitializeTextBoxes();
            }
        }

        private void InitializeTextBoxes()
        {
            //set the category text boxes to zero by default
            FloorTextBox.Text = "0";
            WallsTextBox.Text = "0";
            OpeningsTextBox.Text = "0";
            RoofTextBox.Text = "0";
            TotalCostTextBox.Text = "0";
        }

        //this function resets the forms to default by setting the textboxes to 0 and setting the tableForm to null so that it can be reopened again if closed
        public void ResetForms()
        {
            InitializeTextBoxes();
            tableForm = null;
        }
    }
}
