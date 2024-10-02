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
        }

        private void OpenMaterialsListTableButton_Click(object sender, EventArgs e)
        {
            tableForm = new TableForm(this);
            tableForm.Show();
        }
    }
}
