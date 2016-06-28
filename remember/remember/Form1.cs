using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace remember
{
    public partial class Form1 : Form
    {
        string excelName = "C://Users/itou1/Desktop/Sim/GitTest/remember/LOGGER.xlsx";
        Boolean status = false;
        string text;

        Excel.Application xlApp = null;
        Excel.Workbooks xlBooks = null;
        Excel.Workbook xlBook = null;
        Excel.Sheets xlSheets = null;
        Excel.Worksheet xlSheet = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void getOpeningExcelButton_Click(object sender, EventArgs e)
        {
            if (!status)
            {
                xlApp = new Excel.Application();

                xlBooks = xlApp.Workbooks;
                xlBook = xlBooks.Open(System.IO.Path.GetFullPath(@excelName));

                xlSheets = xlBook.Worksheets;
                xlSheet = xlSheets[1] as Excel.Worksheet;

                xlsheet = xlsheets[2];
                Messagebox.show(xlsheet.name);
                xlApp.Visible = true;

             

                status = true;
            }else{
                MessageBox.Show("xmlを開いている");
            }
            
        }

        private void setTextButton_Click(object sender, EventArgs e)
        {
            if (xlSheet == null)
            {
                return;
            }
            xlSheet.Cells[34, 13] = "10";

        }

        private void yearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }

        }

        private void CloseExcelButton_Click(object sender, EventArgs e)
        {
            if (status)
            {
                xlBooks.Close();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                status = false;
            }
            else{
                MessageBox.Show("xmlファイルを閉じている");
            }

        }

        private void yearBox_TextChanged(object sender, EventArgs e)
        {
            text = yearBox.Text;
        }

    }
}
