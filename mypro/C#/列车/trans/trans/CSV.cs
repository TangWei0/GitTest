using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//System.Text.Encoding.GetEncoding("SHIFT-JIS")

namespace trans
{
    public class CSV
    {
        static string fp_custom = ".\\Record\\custom.csv";
        static string fp_city = ".\\Record\\city\\city_";
        static string fp_city = ".\\Record\\cityDefalut\\city_";
        static string fp_garage = ".\\Record\\garage\\garage_";
        //static string fp_garage = ".\\Record\\garage\\garage_";

        public void ReadCustomCsv(Parameter.Custom[] custom)
        {
            StreamReader sr = new StreamReader(fp_custom, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            String lin = sr.ReadLine();
            if (lin != null)
            {
                String[] csv = lin.Split(',');
                for (int column = 0; column < csv.GetLength(0); column++)
                {
                    switch (column)
                    {
                        case 0:
                            custom[0].level = Convert.ToUInt16(csv[column]);
                            break;
                        case 1:
                            custom[0].levelValue = Convert.ToUInt64(csv[column]);
                            break;
                        case 2:
                            custom[0].cash = Convert.ToUInt64(csv[column]);
                            break;
                        case 3:
                            custom[0].coin = Convert.ToUInt64(csv[column]);
                            break;
                        case 4:
                            custom[0].garageVolume = Convert.ToUInt16(csv[column]);
                            break;
                        case 5:
                            custom[0].cityVolume = Convert.ToUInt16(csv[column]);
                            break;
                        default:
                            break;
                    }
                }
            }

            sr.Close();
        }

        public void UpdateCustomCsv(Parameter.Custom[] custom)
        {
            StreamWriter sw = new StreamWriter(fp_custom, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

            string rowCsvInfo = "";
            rowCsvInfo += custom[0].level.ToString() + ",";
            rowCsvInfo += custom[0].levelValue.ToString() + ",";
            rowCsvInfo += custom[0].cash.ToString() + ",";
            rowCsvInfo += custom[0].coin.ToString() + ",";
            rowCsvInfo += custom[0].garageVolume.ToString() + ",";
            rowCsvInfo += custom[0].cityVolume.ToString();

            sw.Write(rowCsvInfo);
            sw.Write("\n");

            sw.Close();

        }

        public void ReadCityCsv(Parameter.City[] city, UInt16 cityVolume)
        {
            for (int i = 1; i <= cityVolume; i++)
            {
                string fp = fp_city + i.ToString("00000") + ".csv";
                StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

                String lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                city[i-1].cityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 1:
                                city[i-1].cityName = csv[column];
                                break;
                            case 2:
                                city[i-1].cityPeopleNumber = Convert.ToUInt32(csv[column]);
                                break;
                            case 3:
                                city[i-1].cityStars = Convert.ToByte(csv[column]);
                                break;
                            case 4:
                                city[i-1].cityLever = Convert.ToByte(csv[column]);
                                break;
                            case 5:
                                city[i-1].cityValue = Convert.ToUInt64(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                sr.Close();
            }
        }

        public void UpdateCityCsv(Parameter.City[] city, UInt16 cityRowIndex)
        {
            string fp = fp_city + cityRowIndex.ToString("00000") + ".csv";

            StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

            string lin = city[cityRowIndex - 1].cityIndex.ToString() + ","
                       + city[cityRowIndex - 1].cityName + ","
                       + city[cityRowIndex - 1].cityPeopleNumber.ToString() + ","
                       + city[cityRowIndex - 1].cityStars.ToString() + ","
                       + city[cityRowIndex - 1].cityLever.ToString() + ","
                       + city[cityRowIndex - 1].cityValue.ToString();

            sw.Write(lin);
            sw.Close();

        }

        public void DeleteCityCsv(UInt16 cityVolume, UInt16 cityRowIndex)
        {
            for (int i = cityRowIndex + 1; i <= cityVolume; i++)
            {
                string fp_old = fp_city + (i - 1).ToString("00000") + ".csv";
                string fp_new = fp_city + i.ToString("00000") + ".csv";
                System.IO.File.Copy(fp_new, fp_old, true);
            }

            string fp = fp_city + cityVolume.ToString("00000") + ".csv";
            System.IO.File.Delete(fp);
        }

        public void ReadGarageCsv(Parameter.Garage[] garage, UInt16 garageVolume)
        {
            for (int i = 1; i <= garageVolume; i++)
            {
                string fp = fp_garage + i.ToString("00000000") + ".csv";
                StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

                String lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                garage[i-1].carIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 1:
                                garage[i - 1].carName = csv[column];
                                break;
                            case 2:
                                garage[i - 1].carPeopleVolume = Convert.ToByte(csv[column]);
                                break;
                            case 3:
                                garage[i - 1].carCargoVolume = Convert.ToByte(csv[column]);
                                break;
                            case 4:
                                garage[i - 1].carSpeed = Convert.ToUInt16(csv[column]);
                                break;
                            case 5:
                                garage[i - 1].carPower = Convert.ToUInt16(csv[column]);
                                break;
                            case 6:
                                garage[i - 1].carDistance = Convert.ToUInt16(csv[column]);
                                break;
                            case 7:
                                garage[i - 1].carWeight = Convert.ToUInt16(csv[column]);
                                break;
                            case 8:
                                garage[1 - 1].carLever = Convert.ToByte(csv[column]);
                                break;
                            case 9:
                                garage[1 - 1].carDepartureCity = csv[column];
                                break;
                            case 10:
                                garage[1 - 1].carArrivalCity = csv[column];
                                break;
                            case 11:
                                garage[1 - 1].carDepartureTime = DateTime.Parse(csv[column]);
                                break;
                            case 12:
                                garage[1 - 1].carArrivalTime = DateTime.Parse(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }

                }
                sr.Close();
            }
        }

        public void UpdateGarageCsv(Parameter.Garage[] garage, UInt16 garageRowIndex)
        {
            string fp = fp_garage + garageRowIndex.ToString("00000000") + ".csv";

            StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.GetEncoding("SHIFT-JIS"));

            string lin = garage[garageRowIndex - 1].carIndex.ToString() + ","
                       + garage[garageRowIndex - 1].carName + ","
                       + garage[garageRowIndex - 1].carPeopleVolume.ToString() + ","
                       + garage[garageRowIndex - 1].carCargoVolume.ToString() + ","
                       + garage[garageRowIndex - 1].carSpeed.ToString() + ","
                       + garage[garageRowIndex - 1].carPower.ToString() + ","
                       + garage[garageRowIndex - 1].carDistance.ToString() + ","
                       + garage[garageRowIndex - 1].carWeight.ToString() + ","
                       + garage[garageRowIndex - 1].carLever.ToString() + ","
                       + garage[garageRowIndex - 1].carDepartureCity + ","
                       + garage[garageRowIndex - 1].carArrivalCity + ","
                       + garage[garageRowIndex - 1].carDepartureTime.ToString() + ","
                       + garage[garageRowIndex - 1].carArrivalTime.ToString();

            sw.Write(lin);
            sw.Close();

        }

        public void DeleteGarageCsv(UInt16 garageVolume, UInt16 garageRowIndex)
        {
            for (int i = garageRowIndex + 1; i <= garageVolume; i++)
            {
                string fp_old = fp_city + (i - 1).ToString("00000000") + ".csv";
                string fp_new = fp_city + i.ToString("00000000") + ".csv";
                System.IO.File.Copy(fp_new, fp_old, true);
            }

            string fp = fp_city + garageVolume.ToString("00000000") + ".csv";
            System.IO.File.Delete(fp);
        }
    }

}
