using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace train
{    
    public class CSV
    {
        static string fp_custom = ".\\Record\\custom.csv";
        static string fp_city_list = ".\\Record\\city_list\\citylist.csv";
        static string fp_car_list = ".\\Record\\car_list\\";
        static string fp_city = ".\\Record\\city\\city_";
        static string fp_city_default = ".\\Record\\cityDefault\\";
        static string fp_using_car = ".\\Record\\garage\\using_car_";
        static string fp_unused_car = ".\\Record\\garage\\unused_car_";
        static string fp_city_to_city = ".\\Record\\CityToCityTable\\city_to_city_";

        Parameter.City ReadCity = new Parameter.City();
        Parameter.Garage ReadCar = new Parameter.Garage();

        public void ReadCustomCsv(Parameter.Custom[] custom)
        {
            StreamReader sr = new StreamReader(fp_custom, System.Text.Encoding.Unicode);
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
                            custom[0].closeTime = DateTime.Parse(csv[column]);
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
            StreamWriter sw = new StreamWriter(fp_custom, false, System.Text.Encoding.Unicode);

            string rowCsvInfo = "";
            rowCsvInfo += custom[0].level.ToString() + ",";
            rowCsvInfo += custom[0].levelValue.ToString() + ",";
            rowCsvInfo += custom[0].cash.ToString() + ",";
            rowCsvInfo += custom[0].coin.ToString() + ",";
            rowCsvInfo += custom[0].garageVolume.ToString() + ",";
            rowCsvInfo += custom[0].closeTime.ToString();

            sw.Write(rowCsvInfo);
            sw.Write("\n");

            sw.Close();

        }

        public void ReadCityList(List<UInt16> CityList)
        {
            StreamReader sr = new StreamReader(fp_city_list, System.Text.Encoding.Unicode);
            String lin = sr.ReadLine();
            if (lin != null)
            {
                String[] csv = lin.Split(',');
                for (int column = 0; column < csv.GetLength(0); column++)
                {
                    CityList.Add(Convert.ToUInt16(csv[column]));
                }
            }

            sr.Close();
        }

        public void UpdateCityList(List<UInt16> CityList)
        {
            StreamWriter sw = new StreamWriter(fp_city_list, false, System.Text.Encoding.Unicode);

            string rowCsvInfo = "";
            for (int i = 0; i < CityList.Count; i++)
            {
                if (i == CityList.Count - 1)
                {
                    rowCsvInfo += CityList[i].ToString();
                }
                else
                {
                    rowCsvInfo += CityList[i].ToString() + ",";
                }
            }

            sw.Write(rowCsvInfo);
            sw.Close();
        }

        public void ReadCityCsv(List<Parameter.City> city, List<UInt16> CityList)
        {
            for (int i = 0; i < CityList.Count; i++)
            {
                string fp = fp_city + (CityList[i]).ToString("00000") + ".csv";
                StreamReader sr = new StreamReader(fp, System.Text.Encoding.Unicode);

                String lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                ReadCity.cityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 1:
                                ReadCity.cityName = csv[column];
                                break;
                            case 2:
                                ReadCity.cityPeopleNumber = Convert.ToUInt32(csv[column]);
                                break;
                            case 3:
                                ReadCity.cityStars = Convert.ToByte(csv[column]);
                                break;
                            case 4:
                                ReadCity.cityLever = Convert.ToByte(csv[column]);
                                break;
                            case 5:
                                ReadCity.cityValue = Convert.ToUInt64(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                sr.Close();
                city.Add(ReadCity); 
            }
        }

        public void SearchAddCity(List<UInt16> CityList, List<Parameter.City> city, string cityName)
        {
            string fp_search = fp_city_default + cityName + ".csv";
            StreamReader sr = new StreamReader(fp_search, System.Text.Encoding.Unicode);

            String lin = sr.ReadLine();
            if (lin != null)
            {
                String[] csv = lin.Split(',');
                for (int column = 0; column < csv.GetLength(0); column++)
                {
                    switch (column)
                    {
                        case 0:
                            CityList.Add(Convert.ToUInt16(csv[column]));
                            ReadCity.cityIndex = Convert.ToUInt16(csv[column]);
                            string fp_copy = fp_city + Convert.ToUInt16(csv[column]).ToString("00000") + ".csv";
                            System.IO.File.Copy(fp_search, fp_copy, true);
                            UpdateCityList(CityList);
                            break;
                        case 1:
                            ReadCity.cityName = csv[column];
                            break;
                        case 2:
                            ReadCity.cityPeopleNumber = Convert.ToUInt32(csv[column]);
                            break;
                        case 3:
                            ReadCity.cityStars = Convert.ToByte(csv[column]);
                            break;
                        case 4:
                            ReadCity.cityLever = Convert.ToByte(csv[column]);
                            break;
                        case 5:
                            ReadCity.cityValue = Convert.ToUInt64(csv[column]);
                            break;
                        default:
                            break;
                    }
                }
                
            }
            sr.Close();
            city.Add(ReadCity);
        }

        public void SearchDelCity(List<UInt16> CityList, List<Parameter.City> city, string cityName)
        {
            for (int i = 0; i < CityList.Count; i++)
            {
                if (city[i].cityName == cityName)
                {
                    ReadCity = city[i];
                    string fp_search = fp_city + ReadCity.cityIndex.ToString("00000") + ".csv";
                    CityList.Remove(ReadCity.cityIndex);
                    UpdateCityList(CityList);
                    city.Remove(ReadCity);
                    System.IO.File.Delete(fp_search);
                    return;
                }
            }            
        }

        public void UpdateCityCsv(List<UInt16> CityList, List<Parameter.City> city, string cityName)
        {
            for (int i = 0; i < CityList.Count; i++)
            {
                if (city[i].cityName == cityName)
                {
                    string fp_update = fp_city + city[i].cityIndex.ToString("00000") + ".csv";

                    StreamWriter sw = new StreamWriter(fp_update, false, System.Text.Encoding.Unicode);

                    string lin = city[i].cityIndex.ToString() + ","
                               + city[i].cityName + ","
                               + city[i].cityPeopleNumber.ToString() + ","
                               + city[i].cityStars.ToString() + ","
                               + city[i].cityLever.ToString() + ","
                               + city[i].cityValue.ToString();

                    sw.Write(lin);
                    sw.Close();
                }
            } 

        }

        public void ReadCarList(List<UInt32> CarList,bool car_check)
        {
            string fp = "";
            if (car_check)
            {
                fp = fp_car_list + "usingcarlist.csv";
            }
            else
            {
                fp = fp_car_list + "unusedcarlist.csv";
            }
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.Unicode);
            String lin = sr.ReadLine();
            if (lin != null)
            {
                String[] csv = lin.Split(',');
                for (int column = 0; column < csv.GetLength(0); column++)
                {
                    CarList.Add(Convert.ToUInt32(csv[column]));
                }
            }

            sr.Close();
        }

        public void ReadGarageCsv(List<Parameter.Garage> garage, List<UInt32> carList, bool car_check)
        {
            for (int i = 0; i < carList.Count; i++)
            {
                string fp = "";
                if (car_check)
                {
                    fp = fp_using_car + carList[i].ToString("00000000") + ".csv";
                }
                else
                {
                    fp = fp_unused_car + carList[i].ToString("00000000") + ".csv";
                }

                StreamReader sr = new StreamReader(fp, System.Text.Encoding.Unicode);

                String lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                ReadCar.carIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 1:
                                ReadCar.carName = csv[column];
                                break;
                            case 2:
                                ReadCar.carPeopleVolume = Convert.ToByte(csv[column]);
                                break;
                            case 3:
                                ReadCar.carSpeed = Convert.ToUInt16(csv[column]);
                                break;
                            case 4:
                                ReadCar.carPower = Convert.ToUInt16(csv[column]);
                                break;
                            case 5:
                                ReadCar.carWeight = Convert.ToUInt16(csv[column]);
                                break;
                            case 6:
                                ReadCar.carDepartureCityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 7:
                                ReadCar.carDepartureCityName = csv[column];
                                break;
                            case 8:
                                ReadCar.carDepartureTime = DateTime.Parse(csv[column]);
                                break;
                            case 9:
                                ReadCar.carArrivalCityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 10:
                                ReadCar.carArrivalCityName = csv[column];
                                break;
                            case 11:
                                ReadCar.carArrivalTime = DateTime.Parse(csv[column]);
                                break;
                            case 12:
                                ReadCar.carstatus = Convert.ToBoolean(csv[column]);
                                break;
                            case 13:
                                ReadCar.carTotalFare = Convert.ToUInt32(csv[column]);
                                break;
                            case 14:
                                ReadCar.carCost = Convert.ToUInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }

                }
                sr.Close();
                garage.Add(ReadCar);
            }
        }

        //public void UpdateGarageCsv(Parameter.Garage[] garage, int garageRowIndex)
        //{
        //    string fp = fp_garage + (garageRowIndex + 1).ToString("00000000") + ".csv";

        //    StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.Unicode);

        //    string lin = garage[garageRowIndex].carIndex.ToString() + ","
        //               + garage[garageRowIndex].carName + ","
        //               + garage[garageRowIndex].carPeopleVolume.ToString() + ","
        //               + garage[garageRowIndex].carSpeed.ToString() + ","
        //               + garage[garageRowIndex].carPower.ToString() + ","
        //               + garage[garageRowIndex].carWeight.ToString() + ","
        //               + garage[garageRowIndex].carDepartureCityIndex.ToString() + ","
        //               + garage[garageRowIndex].carDepartureCityName + ","
        //               + garage[garageRowIndex].carDepartureTime.ToString() + ","
        //               + garage[garageRowIndex].carArrivalCityIndex.ToString() + ","
        //               + garage[garageRowIndex].carArrivalCityName + ","
        //               + garage[garageRowIndex].carArrivalTime.ToString() + ","
        //               + garage[garageRowIndex].carstatus.ToString() + ","
        //               + garage[garageRowIndex].carTotalFare.ToString() + ","
        //               + garage[garageRowIndex].carCost.ToString();

        //    sw.Write(lin);
        //    sw.Close();

        //}

        //public void DeleteGarageCsv(UInt16 garageVolume, UInt16 garageRowIndex)
        //{
        //    for (int i = garageRowIndex + 1; i <= garageVolume; i++)
        //    {
        //        string fp_old = fp_city + (i - 1).ToString("00000000") + ".csv";
        //        string fp_new = fp_city + i.ToString("00000000") + ".csv";
        //        System.IO.File.Copy(fp_new, fp_old, true);
        //    }

        //    string fp = fp_city + garageVolume.ToString("00000000") + ".csv";
        //    System.IO.File.Delete(fp);
        //}

        public void ReadCityToCityCsv(Parameter.CityToCity[] cityToCity, UInt16 departure, UInt16 arrvial)
        {
            if (departure > arrvial)
            {
                UInt16 tmp = departure;
                departure = arrvial;
                arrvial = tmp;
            }

            string fp = fp_city_to_city + departure.ToString("00000") + arrvial.ToString("00000") + ".csv";

            StreamReader sr = new StreamReader(fp, System.Text.Encoding.Unicode);
            String lin = sr.ReadLine();

            if (lin != null)
            {
                String[] csv = lin.Split(',');
                for (int column = 0; column < csv.GetLength(0); column++)
                {
                    switch (column)
                    {
                        case 0:
                            cityToCity[0].distance = Convert.ToInt32(csv[column]);
                            break;
                        case 1:
                            cityToCity[0].fare = Convert.ToInt32(csv[column]);
                            break;
                        case 2:
                            cityToCity[0].generationRate = Convert.ToInt32(csv[column]);
                            break;
                        case 3:
                            cityToCity[0].residenceNum = Convert.ToInt32(csv[column]);
                            break;
                        default:
                            break;
                    }
                }
            }

            sr.Close();
        }

        public void UpdateCityToCityCsv(Parameter.CityToCity[] cityToCity, UInt16 departure, UInt16 arrvial)
        {
            if (departure > arrvial)
            {
                UInt16 tmp = departure;
                departure = arrvial;
                arrvial = tmp;
            }

            string fp = fp_city_to_city + departure.ToString("00000") + arrvial.ToString("00000") + ".csv";

            StreamWriter sw = new StreamWriter(fp, false, System.Text.Encoding.Unicode);

            string lin = cityToCity[0].distance.ToString() + ","
                       + cityToCity[0].fare.ToString() + ","
                       + cityToCity[0].generationRate.ToString() + ","
                       + cityToCity[0].residenceNum.ToString();

            sw.Write(lin);
            sw.Close();

        }

    }

}
