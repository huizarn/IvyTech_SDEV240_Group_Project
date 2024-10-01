using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;


namespace Group_Project
{
    public partial class TableForm : Form
    {
        private MainForm mainForm;
        public TableForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void ExportToExcel()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dataTable.Columns[i - 1].ColumnName;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                    }
                }

                FileInfo fileInfo = new FileInfo(@"...\Downloads\MaterialsEstimate.xlsx");
                package.SaveAs(fileInfo);
            }
        }
    }
}
