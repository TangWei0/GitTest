using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace remember
{
    class SetTable
    {
        Excel.Range xlRange = null;

        const int Num = 6;
        static string[] selectRange = new string[Num] { "C33", "C34", "E34", "G34", "J34", "L34" };

        public void setTableRange(string year,Excel.Worksheet xlSheet)
        {
            int i = int.Parse(year);
 
            if (i % 4 != 0)
            {
                xlRange = xlSheet.Range["C32"];
                delectCells(xlRange);
            }

            for (int j = 0; j < selectRange.Length; j++)
            {
                xlRange = xlSheet.Range[selectRange[j]];
                delectCells(xlRange);
            }

        }

        private void delectCells(Excel.Range xlRange)
        {
            xlRange.Interior.Color = Color.White;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.White;

        }

    }
}
