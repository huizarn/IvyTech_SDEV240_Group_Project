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

        //Create and open the TableForm
        private void OpenMaterialsListTableButton_Click(object sender, EventArgs e)
        {
            tableForm = new TableForm(this);
            tableForm.Show();
        }

        //These 5 Update functions take a cost as it parameter, then adds it to the appropriate TextBox
        public void UpdateFloorTextBox(decimal cost)
        {
            FloorTextBox.Text = (Convert.ToDecimal(FloorTextBox.Text) + cost).ToString("F2");
        }

        public void UpdateWallsTextBox(decimal cost)
        {
            WallsTextBox.Text = (Convert.ToDecimal(WallsTextBox.Text) + cost).ToString("F2");
        }

        public void UpdateOpeningsTextBox(decimal cost)
        {
            OpeningsTextBox.Text = (Convert.ToDecimal(OpeningsTextBox.Text) + cost).ToString("F2");
        }

        public void UpdateRoofTextBox(decimal cost)
        {
            RoofTextBox.Text = (Convert.ToDecimal(RoofTextBox.Text) + cost).ToString("F2");
        }

        public void UpdateTotalCostTextBox(decimal cost)
        {
            TotalCostTextBox.Text = (Convert.ToDecimal(TotalCostTextBox.Text) + cost).ToString("F2");
        }

        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            tableForm.ExportToExcel();
        }

        private void ClearTableButton_Click(object sender, EventArgs e)
        {
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
    }
}
