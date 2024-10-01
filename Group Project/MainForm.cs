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

            FloorTextBox.Text = "0";
            WallsTextBox.Text = "0";
            OpeningsTextBox.Text = "0";
            RoofTextBox.Text = "0";
            TotalCostTextBox.Text = "0";
        }

        private void OpenMaterialsListTableButton_Click(object sender, EventArgs e)
        {
            tableForm = new TableForm(this);
            tableForm.Show();
        }

        public void UpdateFloorTextBox(double Cost)
        {
            FloorTextBox.Text = (double.Parse(FloorTextBox.Text) + Cost).ToString();
        }

        public void UpdateWallsTextBox(double Cost)
        {
            WallsTextBox.Text = (double.Parse(WallsTextBox.Text) + Cost).ToString();
        }

        public void UpdateOpeningsTextBox(double Cost)
        {
            OpeningsTextBox.Text = (double.Parse(OpeningsTextBox.Text) + Cost).ToString();
        }

        public void UpdateRoofTextBox(double Cost)
        {
            RoofTextBox.Text = (double.Parse(RoofTextBox.Text) + Cost).ToString();
        }

        public void UpdateTotalCostTextBox(double Cost)
        {
            TotalCostTextBox.Text = (double.Parse(TotalCostTextBox.Text) + Cost).ToString();
        }

        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            tableForm.ExportToExcel();
        }

        private void ClearTableButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action cannot be undone. Are you sure you wish to proceed?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {

            }
        }
    }
}
