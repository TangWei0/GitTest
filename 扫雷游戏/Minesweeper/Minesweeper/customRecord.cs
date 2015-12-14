using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Minesweeper
{
    public struct RecordInfo
    {
        public int width;
        public int height;
        public int mine;
        public int time;
        public double efficiencyValue;
    }

    public class Csv
    {
        public static int recordMaxNum = 10;
        public static string fp = ".\\Record\\data.csv";

        public void ReadCsv(RecordInfo[] detail)
        {
            // CSVファイルオープン
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            // CSVファイルの各セルをDataGridViewに表示
            int r = 0;
            String lin = "";
            do
            {
                lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int c = 0; c <= csv.GetLength(0) - 1; c++)
                    {
                        switch (c)
                        {
                            case 0:
                                detail[r].efficiencyValue = Convert.ToDouble(csv[c]);
                                break;
                            case 1:
                                detail[r].mine = Convert.ToInt32(csv[c]);
                                break;
                            case 2:
                                detail[r].width = Convert.ToInt32(csv[c]);
                                break;
                            case 3:
                                detail[r].height = Convert.ToInt32(csv[c]);
                                break;
                            case 4:
                                detail[r].time = Convert.ToInt32(csv[c]);
                                break;
                            default:
                                break;
                        }
                    }
                    r += 1;
                }
                else
                {
                    detail[r].efficiencyValue = 0.0;
                    detail[r].mine = 0;
                    detail[r].width = 0;
                    detail[r].height = 0;
                    detail[r].time = 0;
                    r += 1;
                }
            } while (r < recordMaxNum);
            sr.Close();
        }

        public void SaveCsv(RecordInfo[] detail)
        {
            // CSVファイルオープン
            StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            // DataGridViewのセルのデータ取得
            for (int r = 0; r < recordMaxNum; r++)
            {
                String dt = "";
                dt = detail[r].efficiencyValue.ToString() + "," + detail[r].mine.ToString() + "," + detail[r].width.ToString() + "," + detail[r].height.ToString() + "," + detail[r].time.ToString();
                sw.Write(dt);
                sw.Write("\r\n");
            }
            // CSVファイルクローズ
            sw.Close();
        }

    }
}

