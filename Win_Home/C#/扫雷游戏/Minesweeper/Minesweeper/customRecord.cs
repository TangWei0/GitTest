﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Minesweeper
{
    public struct RecordInfo
    {
        public string user;
        public double efficiencyValue;
        public int width;
        public int height;
        public int mine;
        public int time;
        public int success;
        public int total;
        public double successRate;
        public string date;
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
            int row = 0;
            String lin = "";
            do
            {
                lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                detail[row].user = csv[column];
                                break;
                            case 1:
                                detail[row].mine = Convert.ToInt32(csv[column]);
                                break;
                            case 2:
                                detail[row].width = Convert.ToInt32(csv[column]);
                                break;
                            case 3:
                                detail[row].height = Convert.ToInt32(csv[column]);
                                break;
                            case 4:
                                detail[row].time = Convert.ToInt32(csv[column]);
                                break;
                            case 5:
                                detail[row].success = Convert.ToInt32(csv[column]);
                                break;
                            case 6:
                                detail[row].total = Convert.ToInt32(csv[column]);
                                break;
                            case 7:
                                detail[row].date = csv[column];
                                break;
                            default:
                                break;
                        }
                    }
                    detail[row].efficiencyValue = (double)(detail[row].width * detail[row].height) /(double)(detail[row].mine * detail[row].time);
                    if (detail[row].total == 0)
                    {
                        detail[row].successRate = 0.0;
                    }
                    else
                    {
                        detail[row].successRate = (double)detail[row].success / (double)detail[row].total;
                    }
                    row += 1;
                }
                else
                {
                    detail[row] = new RecordInfo();
                    row += 1;
                }
            } while (row < recordMaxNum);
            sr.Close();
        }

        public void SaveRowsCsv(RecordInfo[] detail)
        {
            StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            for (int row = 0; row < recordMaxNum; row++)
            {
                if (detail[row].user == null)
                {
                    sw.Close();
                    return;
                }
                string rowCsvInfo = "";
                rowCsvInfo = RowCsvCreat(detail, row);
                sw.Write(rowCsvInfo);
                sw.Write("\n");
            }
            sw.Close();
        }

        private string RowCsvCreat(RecordInfo[] detail,int row)
        {
            string rowCsvInfo = "";
            rowCsvInfo += detail[row].user + ",";
            rowCsvInfo += detail[row].mine.ToString() + ",";
            rowCsvInfo += detail[row].width.ToString() + ",";
            rowCsvInfo += detail[row].height.ToString() + ",";
            rowCsvInfo += detail[row].time.ToString() + ",";
            rowCsvInfo += detail[row].success.ToString() + ",";
            rowCsvInfo += detail[row].total.ToString() + ",";
            rowCsvInfo += detail[row].date;
            return rowCsvInfo;
        }

    }
}

