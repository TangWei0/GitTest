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
        static string fp_city = ".\\Record\\city\\city.csv";
        static string fp_city_default = ".\\Record\\cityDefault\\";
        static string fp_car_default = ".\\Record\\carDefault\\";
        static string fp_using_car = ".\\Record\\garage\\usingCar.csv";
        static string fp_unused_car = ".\\Record\\garage\\unusedCar.csv";
        static string fp_city_to_city = ".\\Record\\CityToCityTable\\city_to_city_";

        Parameter.City ReadCity = new Parameter.City();
        Parameter.Garage ReadCar = new Parameter.Garage();

        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);

        /// <summary>
        /// 读取账户信息
        /// </summary>
        /// <param name="custom"></param>
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
                            custom[0].cityVolume = Convert.ToUInt16(csv[column]);
                            break;
                        case 5:
                            custom[0].usingCarVolume = Convert.ToUInt16(csv[column]);
                            break;
                        case 6:
                            custom[0].unusedCarVolume = Convert.ToUInt16(csv[column]);
                            break;
                        case 7:
                            custom[0].carCount = Convert.ToUInt32(csv[column]);
                            break;
                        case 8:
                            custom[0].closeTime = DateTime.Parse(csv[column]);
                            break;
                        default:
                            break;
                    }
                }
            }

            sr.Close();
        }

        /// <summary>
        /// 保存账户信息
        /// </summary>
        /// <param name="custom"></param>
        public void UpdateCustomCsv(Parameter.Custom[] custom)
        {
            StreamWriter sw = new StreamWriter(fp_custom, false, System.Text.Encoding.Unicode);

            string rowCsvInfo = custom[0].level.ToString() + ","
                              + custom[0].levelValue.ToString() + ","
                              + custom[0].cash.ToString() + ","
                              + custom[0].coin.ToString() + ","
                              + custom[0].cityVolume.ToString() + ","
                              + custom[0].usingCarVolume.ToString() + ","
                              + custom[0].unusedCarVolume.ToString() + ","
                              + custom[0].carCount.ToString() + ","
                              + custom[0].closeTime.ToString();

            sw.Write(rowCsvInfo);
            sw.Write("\n");

            sw.Close();
        }

        /// <summary>
        /// 读取开通城市列表
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cityVolume"></param>
        public void ReadCityCsv(List<Parameter.City> city, UInt16 cityVolume)
        {
            StreamReader sr = new StreamReader(fp_city, System.Text.Encoding.Unicode);
            for (int i = 0; i < cityVolume; i++)
            {
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
                city.Add(ReadCity);
            }
            sr.Close();
        }

        /// <summary>
        /// 增加开通城市
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cityName"></param>
        public void SearchAddCity(List<Parameter.City> city, string cityName)
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

        /// <summary>
        /// 删除开通城市
        /// </summary>
        /// <param name="CityList"></param>
        /// <param name="city"></param>
        /// <param name="cityName"></param>
        public void SearchDelCity(List<Parameter.City> city, string cityName)
        {
            for (int i = 0; i < city.Count; i++)
            {
                if (city[i].cityName == cityName)
                {
                    ReadCity = city[i];
                    city.Remove(ReadCity);
                }
            }
        }

        /// <summary>
        /// 保存城市信息
        /// </summary>
        /// <param name="CityList"></param>
        /// <param name="city"></param>
        /// <param name="cityName"></param>
        public void UpdateCityCsv(List<Parameter.City> city)
        {
            StreamWriter sw = new StreamWriter(fp_city, false, System.Text.Encoding.Unicode);
            for (int i = 0; i < city.Count; i++)
            {
                string lin = city[i].cityIndex.ToString() + ","
                           + city[i].cityName + ","
                           + city[i].cityPeopleNumber.ToString() + ","
                           + city[i].cityStars.ToString() + ","
                           + city[i].cityLever.ToString() + ","
                           + city[i].cityValue.ToString() + "\r\n";

                sw.Write(lin);
            }
            sw.Close();
        }

        /// <summary>
        /// 读取火车详细信息
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="CarVolume"></param>
        /// <param name="car_check"></param>
        /// car_check==true 使用中火车列表
        /// car_check==false 仓库中火车列表
        public void ReadGarageCsv(List<Parameter.Garage> garage, UInt16 CarVolume, bool car_check)
        {
            StreamReader sr = new StreamReader();
            if (car_check)
            {
                sr = new StreamReader(fp_using_car, System.Text.Encoding.Unicode);
            }
            else
            {
                sr = new StreamReader(fp_unused_car, System.Text.Encoding.Unicode);
            }

            for (int i = 0; i < CarVolume; i++)
            {
                String lin = sr.ReadLine();
                if (lin != null)
                {
                    String[] csv = lin.Split(',');
                    for (int column = 0; column < csv.GetLength(0); column++)
                    {
                        switch (column)
                        {
                            case 0:
                                ReadCar.carName = csv[column];
                                break;
                            case 1:
                                ReadCar.carPeopleVolume = Convert.ToByte(csv[column]);
                                break;
                            case 2:
                                ReadCar.carCargoVolume = Convert.ToByte(csv[column]);
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
                                ReadCar.carTotalCash = Convert.ToUInt32(csv[column]);
                                break;
                            case 14:
                                ReadCar.carTotalCoin = Convert.ToUInt32(csv[column]);
                                break;
                            case 15:
                                ReadCar.carCost = Convert.ToUInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }              
                garage.Add(ReadCar);
            }
            sr.Close();
        }

        /// <summary>
        /// 从商城购入到仓库
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="carList"></param>
        /// <param name="carName"></param>
        public void BuyCarGarageCsv(List<Parameter.Garage> unusedGarage, string carName, UInt32 carNumber)
        {
            string fp_search = fp_car_default + carName + ".csv";
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
                            ReadCar.carName = csv[column] + carNumber.ToString("00000000");
                            break;
                        case 1:
                            ReadCar.carPeopleVolume = Convert.ToByte(csv[column]);
                            break;
                        case 2:
                            ReadCar.carCargoVolume = Convert.ToByte(csv[column]);
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
                            ReadCar.carCost = Convert.ToUInt32(csv[column]);
                            break;
                        default:
                            break;
                    }
                }

            }
            sr.Close();
            unusedGarage.Add(ReadCar);
        }

        /// <summary>
        /// 卖出仓库中的火车
        /// </summary>
        /// <param name="ususedGarage"></param>
        /// <param name="carName"></param>
        public void SaleCarGarageCsv(List<Parameter.Garage> unusedGarage, string carName)
        {
            for (int i = 0; i < unusedGarage.Count; i++)
            {
                if (unusedGarage[i].carName == carName)
                {
                    ReadCar = unusedGarage[i];
                    unusedGarage.Remove(ReadCar);
                }
            }
        }

        /// <summary>
        /// 仓库中火车⇔运行中火车
        /// </summary>
        /// <param name="unusedGarage"></param>
        /// <param name="usingGarage"></param>
        /// <param name="car_check"></param>
        /// <param name="carName"></param>
        /// car_check==true  仓库中⇒使用中
        /// car_check==false 使用中⇒仓库中
        public void ChangeGarageCsv(List<Parameter.Garage> unusedGarage, List<Parameter.Garage> usingGarage, bool car_check, string carName)
        {
            if (car_check)
            {
                for (int i = 0; i < unusedGarage.Count; i++)
                {
                    if (unusedGarage[i].carName == carName)
                    {
                        ReadCar = unusedGarage[i];
                        usingGarage.Add(ReadCar);
                        unusedGarage.Remove(ReadCar);
                    }
                }
            }
            else
            {
                for (int i = 0; i < usingGarage.Count; i++)
                {
                    if (usingGarage[i].carName == carName)
                    {
                        ReadCar = usingGarage[i];
                        unusedGarage.Add(ReadCar);
                        usingGarage.Remove(ReadCar);
                    }
                }
            }
        }

        /// <summary>
        /// 火车列表保存
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="car_check"></param>
        /// car_check==true  使用中火车列表保存
        /// car_check==false 仓库中火车列表保存
        public void UpdateGarageCsv(List<Parameter.Garage> garage, bool car_check)
        {
            StreamWriter sw = new StreamWriter();
            if (car_check)
            {
                sw = new StreamWriter(fp_using_car, false, System.Text.Encoding.Unicode);
            }
            else
            {
                sw = new StreamWriter(fp_unused_car, false, System.Text.Encoding.Unicode);
            }

            for (int i = 0; i < garage.Count; i++)
            {
                string lin = "";
                lin = garage[i].carName + ","
                    + garage[i].carPeopleVolume.ToString() + ","
                    + garage[i].carCargoVolume.ToString() + ","
                    + garage[i].carSpeed.ToString() + ","
                    + garage[i].carPower.ToString() + ","
                    + garage[i].carWeight.ToString() + ","
                    + garage[i].carDepartureCityIndex.ToString() + ","
                    + garage[i].carDepartureCityName + ","
                    + garage[i].carDepartureTime.ToString() + ","
                    + garage[i].carArrivalCityIndex.ToString() + ","
                    + garage[i].carArrivalCityName + ","
                    + garage[i].carArrivalTime.ToString() + ","
                    + garage[i].carstatus.ToString() + ","
                    + garage[i].carTotalFare.ToString() + ","
                    + garage[i].carCost.ToString() + "\r\n";
                sw.Write(lin);
            }
            sw.Close();

        }

        
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
