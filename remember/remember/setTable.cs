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
        Excel.Worksheet xlSheet = null;

        string fileNameBasePath = "../../../";
        string cellRange = "";
        string cellFont = "";
        public string year;

        string[] dayWeek = new string[7] { "(日)", "(月)", "(火)", "(水)", "(木)", "(金)", "(土)" };
        string[] MonthCell = new string[12] { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
        string[] HolidayName = new string[18] { "元日", 
                                                "成人の日", 
                                                "建国記念の日", 
                                                "春分の日", 
                                                "昭和の日", 
                                                "憲法記念日", 
                                                "みどりの日", 
                                                "こどもの日", 
                                                "海の日", 
                                                "山の日", 
                                                "敬老の日", 
                                                "秋分の日", 
                                                "体育の日", 
                                                "文化の日", 
                                                "勤労感謝の日", 
                                                "天皇の誕生日", 
                                                "振替休日", 
                                                "年末年始"};

        bool fontColor;
        bool Transfer = false;

        int Year;
        int count;
        int springDay;
        int autumnalDay;
        int MondayCount;
        
        public void setting(string year, Excel.Worksheet xlsheet)
        {
            xlSheet = xlsheet;

            Year = int.Parse(year);

            xlSheet.Name = year;
            xlSheet.Cells[1, 1] = "[" + year + "年] カレンダー";

            setTableRange();
            count = DayWeekCalculation();

            springDay = SpringEquinoxDay();
            autumnalDay = AutumnalEquinoxDay();
            

            for (int i = 1; i <= 12; i++)
            {
                MondayCount = 0;
                cellRange = "";
                
                for (int j = 1; j <= DayMonth(i); j++)
                {
                    fontColor = false;

                    cellRange = MonthCell[i - 1] + (j + 3).ToString();
                    cellFont = i.ToString() + "/" + j.ToString() + " " + dayWeek[count % 7];

                    string fileName = CreatFile(i, j);

                    xlSheet.Hyperlinks.Add(xlSheet.Cells[j + 3, i + 1], fileName);

                    if ((i == 1) || (i == 7) || (i == 9) || (i == 10))
                    {
                        if (count % 7 == 1)
                        {
                            MondayCount++;
                        }
                    }

                    if (count % 7 == 0 || count % 7 == 6)
                    {
                        setHoliday();
                    }

                    selectHoliday(i, j);

                    xlSheet.Cells[j + 3, i + 1] = cellFont;

                    if (fontColor)
                    {
                        xlSheet.Range[cellRange].Font.Color = Color.Red;
                    }
                    else
                    {
                        xlSheet.Range[cellRange].Font.Color = Color.Black;
                    }

                    count++;
                }
            }

        }

        public void setTableRange()
        {
            if (Year % 4 != 0)
            {
                xlRange = xlSheet.Range["C32"];
                delectCells();
            }

        }

        private void delectCells()
        {
            xlRange.Interior.Color = Color.White;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            xlRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.White;

        }

        private void selectHoliday(int i,int j)
        {
            string date = i.ToString("00") + j.ToString("00");

            if (Transfer)
            {
                if (i == 5)
                {
                    fontColor = true;
                    xlSheet.Range[MonthCell[i - 1] + 9.ToString()].Interior.Color = Color.Aqua;
                }
                else
                {
                    setHoliday();
                }

                cellFont += "\r\n" + HolidayName[16];
                Transfer = false;
                return;
            }

            if (i == 3 && j == springDay)
            {
                HolidayCheck(3);
                return;
            }
            else if (i == 9 && j == autumnalDay)
            {
                HolidayCheck(11);
                return;
            }
            else if (MondayCount == 2 && i == 1)
            {
                setHoliday();
                cellFont += "\r\n" + HolidayName[1];
                MondayCount = 6;
                return;
            }
            else if (MondayCount == 3 && i == 7)
            {
                if (Year >= 2003)
                {
                    setHoliday();
                    cellFont += "\r\n" + HolidayName[8];
                    MondayCount = 6;
                    return;
                }
            }
            else if (MondayCount == 3 && i == 9)
            {
                if (Year >= 2003)
                {
                    setHoliday();
                    cellFont += "\r\n" + HolidayName[10];
                    MondayCount = 6;
                    return;
                }
            }
            else if (MondayCount == 2 && i == 10)
            {
                setHoliday();
                cellFont += "\r\n" + HolidayName[12];
                MondayCount = 6;
                return;
            }

            switch (date)
            {
                case "0101":
                    HolidayCheck(0);
                    break;
                case "0211":
                    HolidayCheck(2);
                    break;
                case "0429":
                    if (Year <= 2006)
                    {
                        HolidayCheck(6);
                    }
                    else
                    {
                        HolidayCheck(4);
                    }
                    break;
                case "0503":
                    HolidayCheck(5);
                    break;
                case "0504":
                    if (Year >= 2007)
                    {
                        HolidayCheck(6);
                    }
                    break;
                case "0505":
                    HolidayCheck(7);
                    break;
                case "0720":
                    if (Year <= 2002)
                    {
                        HolidayCheck(8);
                    }
                    break;
                case "0811":
                    if (Year >= 2016)
                    {
                        HolidayCheck(9);
                    }
                    break;
                case "0915":
                    if (Year <= 2002)
                    {
                        HolidayCheck(10);
                    }
                    break;
                case "1103":
                    HolidayCheck(13);
                    break;
                case "1123":
                    HolidayCheck(14);
                    break;
                case "1223":
                    HolidayCheck(15);
                    break;
                case "1229":
                case "1230":
                case "1231":
                case "0102":
                case "0103":
                    cellFont += "\r\n" + HolidayName[17];
                    setHoliday();
                    break;
                default:
                    break;
            }
            

        }

        private void HolidayCheck(int holidayIndex)
        {
            cellFont += "\r\n" + HolidayName[holidayIndex];

            if (count % 7 == 0)
            {
                Transfer = true;
            }
            else
            {
                setHoliday();
            }

        }

        private void setHoliday()
        {
            xlSheet.Range[cellRange].Interior.Color = Color.Aqua;
            fontColor = true;

        }

        private int DayWeekCalculation()
        {
            int dayIndex = 1;

            string date = year + "/01/01";

            DateTime dt = DateTime.Parse(date);
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

        private int DayMonth(int month)
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
                    if (Year % 4 == 0)
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

        private int SpringEquinoxDay()
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

        private int AutumnalEquinoxDay()
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

        private string CreatFile(int month, int day)
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
