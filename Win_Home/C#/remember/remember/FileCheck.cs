using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace remember
{
    class FileCheck
    {
        public string excelName = "../../../LOGGER.xlsx";

        public bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.None);
                inUse = false;

            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;
        }

        public int[] sheetCheck(Excel.Sheets xlSheets, Excel.Worksheet xlSheet, bool status, string year)
        {
            int[] Index = new int[2] { 0, 0 };

            if (status && xlSheets.Count != 1)
            {
                for (int i = 1; i < xlSheets.Count; i++)
                {
                    xlSheet = xlSheets[i] as Excel.Worksheet;
                    if (xlSheet.Name == year)
                    {
                        Index[0] = 1;
                    }
                    if (int.Parse(xlSheet.Name) < int.Parse(year))
                    {
                        Index[1] = i;
                    }
                }
            }

            return Index;
        }

    }
}
