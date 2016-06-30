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

        string fileNameBasePath = "../../../";
        string[] dayWeek = new string[7] { "(日)", "(月)", "(火)", "(水)", "(木)", "(金)", "(土)" };
        string[] MonthCell = new string[12] { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };

        public void setTableRange(int year, Excel.Worksheet xlSheet)
        {
            if (year % 4 != 0)
            {
                xlRange = xlSheet.Range["C32"];
                delectCells(xlRange);
            }

        }

        private void delectCells(Excel.Range xlRange)
        {
            xlRange.Interior.Color = Color.White;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.White;

        }

        public void setting(string year, Excel.Worksheet xlSheet)
        {
            int Year = int.Parse(year);



            xlSheet.Name = year;
            xlSheet.Cells[1, 1] = "[" + year + "年] カレンダー";

            setTableRange(Year, xlSheet);

            int count = DayWeekCalculation(year);

            for (int i = 1; i <= 12; i++)
            {
                int MondayCount = 0;
                string cellRange = "";
                string fileName = "";
                bool Transfer = false;

                //string fileNamePath1 = CreateDirectory(year, i);
                for (int j = 1; j <= DayMonth(i, Year); j++)
                {
                    string cellFont = "";
                    cellRange = MonthCell[i - 1] + (j + 3).ToString();

                    fileName = CreatFile(year, i, j);
                    cellFont = i.ToString() + "/" + j.ToString() + " " + dayWeek[count % 7];

                    if ((i == 1) || (i == 7) || (i == 9) || (i == 10))
                    {
                        if (count % 7 == 1)
                        {
                            MondayCount++;
                        }
                    }

                    if (count % 7 == 0 || count % 7 == 6)
                    {
                        xlSheet.Range[cellRange].Interior.Color = Color.Red;
                    }

                    if (Transfer)
                    {
                        if (i == 5)
                        {
                            xlSheet.Range[MonthCell[i - 1] + 9.ToString()].Interior.Color = Color.Red;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }

                        cellFont += "\r\n振替休日";
                        Transfer = false;
                    }

                    if (i == 1 && j == 1)
                    {
                        cellFont += "\r\n元日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 2 && j == 11)
                    {
                        cellFont += "\r\n建国記念の日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 3 && j == SpringEquinoxDay(Year))
                    {
                        cellFont += "\r\n春分の日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 4 && j == 29)
                    {
                        if (Year <= 2006)
                        {
                            cellFont += "\r\nみどりの日";

                            if (count % 7 == 0)
                            {
                                Transfer = true;
                            }
                            else
                            {
                                xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            }
                        }

                    }

                    if (i == 5 && j == 3)
                    {
                        cellFont += "\r\n憲法記念日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;

                        }
                    }

                    if (i == 5 && j == 4)
                    {
                        if (Year >= 2007)
                        {
                            cellFont += "\r\nみどりの日";
                        }

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            if (Year >= 2007)
                            {
                                xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            }
                        }
                    }

                    if (i == 5 && j == 5)
                    {
                        cellFont += "\r\nこどもの日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 7 && j == 20)
                    {
                        if (Year <= 2002)
                        {
                            cellFont += "\r\n海の日";

                            if (count % 7 == 0)
                            {
                                Transfer = true;
                            }
                            else
                            {
                                xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            }
                        }

                    }

                    if (i == 8 && j == 11)
                    {
                        if (Year >= 2016)
                        {
                            cellFont += "\r\n山の日";

                            if (count % 7 == 0)
                            {
                                Transfer = true;
                            }
                            else
                            {
                                xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            }
                        }

                    }

                    if (i == 9 && j == 15)
                    {
                        if (Year <= 2002)
                        {
                            cellFont += "\r\n敬老の日";

                            if (count % 7 == 0)
                            {
                                Transfer = true;
                            }
                            else
                            {
                                xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            }
                        }

                    }

                    if (i == 9 && j == AutumnalEquinoxDay(Year))
                    {
                        cellFont += "\r\n秋分の日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 11 && j == 3)
                    {
                        cellFont += "\r\n文化の日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 11 && j == 23)
                    {
                        cellFont += "\r\n勤労感謝の日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }

                    if (i == 12 && j == 23)
                    {
                        cellFont += "\r\n天皇の誕生日";

                        if (count % 7 == 0)
                        {
                            Transfer = true;
                        }
                        else
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        }
                    }



                    if (MondayCount == 2 && i == 1)
                    {
                        xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        cellFont += "\r\n成人の日";
                        MondayCount = 0;
                    }
                    if (MondayCount == 3 && i == 7)
                    {
                        if (Year >= 2003)
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            cellFont += "\r\n海の日";
                            MondayCount = 0;
                        }
                    }
                    if (MondayCount == 3 && i == 9)
                    {
                        if (Year >= 2003)
                        {
                            xlSheet.Range[cellRange].Interior.Color = Color.Red;
                            cellFont += "\r\n敬老の日";
                            MondayCount = 0;
                        }
                    }
                    if (MondayCount == 2 && i == 10)
                    {
                        xlSheet.Range[cellRange].Interior.Color = Color.Red;
                        cellFont += "\r\n体育の日";
                        MondayCount = 0;
                    }

                    //会社の年末年始
                    if ((i == 1 && j == 2) || (i == 1 && j == 3))
                    {
                        xlSheet.Range[cellRange].Interior.Color = Color.Red;
                    }

                    if ((i == 12 && j == 29) || (i == 12 && j == 30) || (i == 12 && j == 31))
                    {
                        xlSheet.Range[cellRange].Interior.Color = Color.Red;
                    }

                    xlSheet.Cells[j + 3, i + 1] = cellFont;
                    xlSheet.Range[cellRange].Font.Color = Color.Black;

                    Console.WriteLine("####################" + CreatFile(year, i, j));
                    xlSheet.Hyperlinks.Add(xlSheet.Cells[j + 3, i + 1], CreatFile(year, i, j));
                    count++;
                }
            }

        }

        private int DayWeekCalculation(string year)
        {
            int dayIndex = 1;

            year += "/01/01";

            DateTime dt = DateTime.Parse(year);
            DayOfWeek dow = dt.DayOfWeek;

            switch (dow)
            {
                case DayOfWeek.Sunday:
                    dayIndex = 7;
                    break;
                case DayOfWeek.Monday:
                    dayIndex = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dayIndex = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dayIndex = 3;
                    break;
                case DayOfWeek.Thursday:
                    dayIndex = 4;
                    break;
                case DayOfWeek.Friday:
                    dayIndex = 5;
                    break;
                case DayOfWeek.Saturday:
                    dayIndex = 6;
                    break;
            }

            return dayIndex;
        }

        private int DayMonth(int month, int year)
        {
            int days = 31;

            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                case 2:
                    if (year % 4 == 0)
                    {
                        days = 29;
                    }
                    else
                    {
                        days = 28;
                    }
                    break;
            }

            return days;

        }

        private int SpringEquinoxDay(int Year)
        {
            int springEquinoxDay = 0;

            switch (Year % 4)
            {
                case 0:
                    if (Year >= 1900 && Year <= 1956)
                    {
                        springEquinoxDay = 21;
                    }
                    else if (Year >= 1960 && Year <= 2088)
                    {
                        springEquinoxDay = 20;
                    }
                    else if (Year >= 2092 && Year <= 2096)
                    {
                        springEquinoxDay = 19;
                    }
                    break;
                case 1:
                    if (Year >= 1901 && Year <= 1989)
                    {
                        springEquinoxDay = 21;
                    }
                    else if (Year >= 1993 && Year <= 2097)
                    {
                        springEquinoxDay = 20;
                    }
                    break;
                case 2:
                    if (Year >= 1902 && Year <= 2022)
                    {
                        springEquinoxDay = 21;
                    }
                    else if (Year >= 2026 && Year <= 2098)
                    {
                        springEquinoxDay = 20;
                    }
                    break;
                case 3:
                    if (Year >= 1903 && Year <= 1923)
                    {
                        springEquinoxDay = 22;
                    }
                    else if (Year >= 1927 && Year <= 2055)
                    {
                        springEquinoxDay = 21;
                    }
                    else if (Year >= 2059 && Year <= 2099)
                    {
                        springEquinoxDay = 20;
                    }
                    break;
            }

            return springEquinoxDay;
        }

        private int AutumnalEquinoxDay(int Year)
        {
            int autumnalEquinoxDay = 0;

            switch (Year % 4)
            {
                case 0:
                    if (Year >= 1900 && Year <= 2008)
                    {
                        autumnalEquinoxDay = 23;
                    }
                    else if (Year >= 2012 && Year <= 2096)
                    {
                        autumnalEquinoxDay = 22;
                    }
                    break;
                case 1:
                    if (Year >= 1901 && Year <= 1917)
                    {
                        autumnalEquinoxDay = 24;
                    }
                    else if (Year >= 1921 && Year <= 2041)
                    {
                        autumnalEquinoxDay = 23;
                    }
                    else if (Year >= 2045 && Year <= 2097)
                    {
                        autumnalEquinoxDay = 22;
                    }
                    break;
                case 2:
                    if (Year >= 1902 && Year <= 1946)
                    {
                        autumnalEquinoxDay = 24;
                    }
                    else if (Year >= 1950 && Year <= 2074)
                    {
                        autumnalEquinoxDay = 23;
                    }
                    else if (Year >= 2078 && Year <= 2098)
                    {
                        autumnalEquinoxDay = 22;
                    }
                    break;
                case 3:
                    if (Year >= 1903 && Year <= 1979)
                    {
                        autumnalEquinoxDay = 24;
                    }
                    else if (Year >= 1983 && Year <= 2099)
                    {
                        autumnalEquinoxDay = 23;
                    }
                    break;
            }

            return autumnalEquinoxDay;
        }

        private string CreateDirectory(string year, int month)
        {
            string fileNamePath = "";

            fileNamePath += fileNameBasePath + year + "/" + month.ToString("00") + "/";
            System.IO.Directory.CreateDirectory(@fileNamePath);

            return fileNamePath;

        }

        private string CreatFile(string year, int month, int day)
        {
            string fileNamePath = "";

            System.IO.StreamWriter writer = null;

            fileNamePath += fileNameBasePath + year + "/" + month.ToString("00") + "/";

            SafeCreateDirectory(fileNamePath);

            fileNamePath += year + month.ToString("00") + day.ToString("00") + ".txt";
            writer = new System.IO.StreamWriter(@fileNamePath, false, System.Text.Encoding.Default);

            writer.Close();

            return year + "/" + month.ToString("00") + "/" + year + month.ToString("00") + day.ToString("00") + ".txt";
        }

        private static System.IO.DirectoryInfo SafeCreateDirectory(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                return null;
            }
            return System.IO.Directory.CreateDirectory(path);
                
        }

    }
}
