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
    public partial class CreatText : Form
    {
        FileCheck fileCheck = new FileCheck();
        SetTable setTable = new SetTable();

        Boolean status = false;
        string sheetName;

        Timer timer = new Timer();

        Excel.Application xlApp = null;
        Excel.Workbooks xlBooks = null;
        Excel.Workbook xlBook = null;
        Excel.Sheets xlSheets = null;
        Excel.Worksheet xlSheet = null;

        //public string year;

        public CreatText()
        {
            InitializeComponent();

            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }

        private void getOpeningExcelButton_Click(object sender, EventArgs e)
        {
            if (!status)
            {
                xlApp = new Excel.Application();

                xlBooks = xlApp.Workbooks;
                xlBook = xlBooks.Open(System.IO.Path.GetFullPath(@fileCheck.excelName));

                xlSheets = xlBook.Worksheets;
                xlSheet = xlSheets[1] as Excel.Worksheet;

                xlApp.Visible = true;

                sheetName = xlSheet.Name;
                status = true;

                //MessageBox.Show(xlSheets.Count.ToString());
            }
            else
            {
                MessageBox.Show("xmlを開いている");
            }

        }

        private void setTextButton_Click(object sender, EventArgs e)
        {            
            if (int.Parse(setTable.year) >= 1900 && int.Parse(setTable.year) < 2100)
            {
                int[] Index = fileCheck.sheetCheck(xlSheets, xlSheet, status, setTable.year);

                if (Index[0] == 1)
                {
                    this.Text = setTable.year + "ある";
                }
                else
                {
                    xlSheets[xlSheets.Count].Copy(xlSheets[Index[1] + 1]);
                    xlSheet = xlSheets[Index[1] + 1] as Excel.Worksheet;

                    setTable.setting(setTable.year, xlSheet);
                }
            }

            UI.Main main = new UI.Main();
            main.Show();
            this.Close();
        }

        private void yearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                e.Handled = true;
            }

        }

        private void CloseExcelButton_Click(object sender, EventArgs e)
        {
            if (status)
            {
                xlApp.ActiveWorkbook.Save();
                xlApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                status = false;
            }
            else
            {
                MessageBox.Show("xmlファイルを閉じている");
            }

        }

        private void yearBox_TextChanged(object sender, EventArgs e)
        {
            setTable.year = yearBox.Text;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fileCheck.IsFileInUse(fileCheck.excelName))
            {
                status = true;
            }
            else
            {
                status = false;
            }

        }

    }
}
