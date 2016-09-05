using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
        static string fp_city_to_city_default = ".\\Record\\CityToCityDefault\\city_to_city_";
        static string fp_city_to_city = ".\\Record\\CityToCity\\city_to_city.csv";
        //static string fp1 = ".\\Record\\CityToCity\\test.csv";

        Parameter.City ReadCity = new Parameter.City();
        Parameter.Garage ReadGarage = new Parameter.Garage();
        Parameter.Car ReadCar = new Parameter.Car();
        Parameter.CityToCity ele = new Parameter.CityToCity();
        List<Parameter.CityToCity> item = new List<Parameter.CityToCity>();

        Parameter.CityToCity eleDefalut = new Parameter.CityToCity
        {
            distance = -1,
            cashfare = -1,
            coinfare = -1,
            people = -1,
            cargo = -1
        };

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
                            custom[0].carVolume = Convert.ToUInt16(csv[column]);
                            break;
                        case 6:
                            custom[0].garageVolume = Convert.ToUInt16(csv[column]);
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
                              + custom[0].carVolume.ToString() + ","
                              + custom[0].garageVolume.ToString() + ","
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
            if (cityVolume == 0)
            {
                return;
            }

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
        public bool AddCity(List<Parameter.City> city, string cityName)
        {
            string fp_search = fp_city_default + cityName + ".csv";
            if (!File.Exists(fp_search))
            {
                MessageBox.Show("没有该城市",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
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
            return true;
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
            string lin = "";
            if (city.Count == 0)
            {
                sw.Write(lin);
                sw.Close();
                return;
            }
            for (int i = 0; i < city.Count; i++)
            {
                lin = "";
                lin = city[i].cityIndex.ToString() + ","
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
        /// 读取仓库火车详细信息
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="garageVolume"></param>
        public void ReadGarageCsv(List<Parameter.Garage> garage, UInt16 garageVolume)
        {
            if (garageVolume == 0)
            {
                return;
            }
            StreamReader sr = new StreamReader(fp_unused_car, System.Text.Encoding.Unicode);
            for (int i = 0; i < garageVolume; i++)
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
                                ReadGarage.carName = csv[column];
                                break;
                            case 1:
                                ReadGarage.carPeopleVolume = Convert.ToByte(csv[column]);
                                break;
                            case 2:
                                ReadGarage.carCargoVolume = Convert.ToByte(csv[column]);
                                break;
                            case 3:
                                ReadGarage.carSpeed = Convert.ToUInt16(csv[column]);
                                break;
                            case 4:
                                ReadGarage.carPower = Convert.ToUInt16(csv[column]);
                                break;
                            case 5:
                                ReadGarage.carWeight = Convert.ToUInt16(csv[column]);
                                break;
                            case 6:
                                ReadGarage.carValue = Convert.ToUInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                garage.Add(ReadGarage);
            }
            sr.Close();
        }

        /// <summary>
        /// 读取使用中火车详细信息
        /// </summary>
        /// <param name="car"></param>
        /// <param name="carVolume"></param>
        public void ReadCarCsv(List<Parameter.Car> car, UInt16 carVolume)
        {
            if (carVolume == 0)
            {
                return;
            }
            StreamReader sr = new StreamReader(fp_using_car, System.Text.Encoding.Unicode);
            for (int i = 0; i < carVolume; i++)
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
                                ReadCar.carCost = Convert.ToUInt32(csv[column]);
                                break;
                            case 7:
                                ReadCar.carDepartureCityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 8:
                                ReadCar.carDepartureCityName = csv[column];
                                break;
                            case 9:
                                ReadCar.carDepartureTime = DateTime.Parse(csv[column]);
                                break;
                            case 10:
                                ReadCar.carArrivalCityIndex = Convert.ToUInt16(csv[column]);
                                break;
                            case 11:
                                ReadCar.carArrivalCityName = csv[column];
                                break;
                            case 12:
                                ReadCar.carArrivalTime = DateTime.Parse(csv[column]);
                                break;
                            case 13:
                                ReadCar.carstatus = Convert.ToBoolean(csv[column]);
                                break;
                            case 14:
                                ReadCar.carTotalCash = Convert.ToUInt32(csv[column]);
                                break;
                            case 15:
                                ReadCar.carTotalCoin = Convert.ToUInt32(csv[column]);
                                break;
                            case 16:
                                ReadCar.carCost = Convert.ToUInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                    car.Add(ReadCar);
                }
                else
                {
                    return;
                }
            }
            sr.Close();
        }

        /// <summary>
        /// 从商城购入到仓库
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="carList"></param>
        /// <param name="carName"></param>
        public void BuyCarGarageCsv(List<Parameter.Garage> garage, string carName, UInt32 carCount)
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
                            ReadGarage.carName = csv[column] + carCount.ToString("00000000");
                            break;
                        case 1:
                            ReadGarage.carPeopleVolume = Convert.ToByte(csv[column]);
                            break;
                        case 2:
                            ReadGarage.carCargoVolume = Convert.ToByte(csv[column]);
                            break;
                        case 3:
                            ReadGarage.carSpeed = Convert.ToUInt16(csv[column]);
                            break;
                        case 4:
                            ReadGarage.carPower = Convert.ToUInt16(csv[column]);
                            break;
                        case 5:
                            ReadGarage.carWeight = Convert.ToUInt16(csv[column]);
                            break;
                        case 6:
                            ReadGarage.carValue = Convert.ToUInt32(csv[column]) * 1000000;
                            break;
                        default:
                            break;
                    }
                }
            }
            sr.Close();
            garage.Add(ReadGarage);
        }

        /// <summary>
        /// 仓库火车列表保存
        /// </summary>
        /// <param name="garage"></param>
        public void UpdateGarageCsv(List<Parameter.Garage> garage)
        {
            StreamWriter sw = new StreamWriter(fp_unused_car, false, System.Text.Encoding.Unicode);
            string lin = "";
            if (garage.Count == 0)
            {
                sw.Write(lin);
                sw.Close();
                return;
            }
            for (int i = 0; i < garage.Count; i++)
            {
                lin = "";
                lin = garage[i].carName + ","
                    + garage[i].carPeopleVolume.ToString() + ","
                    + garage[i].carCargoVolume.ToString() + ","
                    + garage[i].carSpeed.ToString() + ","
                    + garage[i].carPower.ToString() + ","
                    + garage[i].carWeight.ToString() + ","
                    + garage[i].carValue.ToString() + "\r\n";
                sw.Write(lin);
            }
            sw.Close();
        }

        /// <summary>
        /// 使用中火车列表保存
        /// </summary>
        /// <param name="car"></param>
        public void UpdateCarCsv(List<Parameter.Car> car)
        {
            StreamWriter sw = new StreamWriter(fp_using_car, false, System.Text.Encoding.Unicode);
            string lin = "";
            if (car.Count == 0)
            {
                sw.Write(lin);
                sw.Close();
                return;
            }
            for (int i = 0; i < car.Count; i++)
            {
                lin = "";
                lin = car[i].carName + ","
                    + car[i].carPeopleVolume.ToString() + ","
                    + car[i].carCargoVolume.ToString() + ","
                    + car[i].carSpeed.ToString() + ","
                    + car[i].carPower.ToString() + ","
                    + car[i].carWeight.ToString() + ","
                    + car[i].carValue.ToString() + ","
                    + car[i].carDepartureCityIndex.ToString() + ","
                    + car[i].carDepartureCityName + ","
                    + car[i].carDepartureTime.ToString() + ","
                    + car[i].carArrivalCityIndex.ToString() + ","
                    + car[i].carArrivalCityName + ","
                    + car[i].carArrivalTime.ToString() + ","
                    + car[i].carstatus.ToString() + ","
                    + car[i].carTotalCash.ToString() + ","
                    + car[i].carTotalCoin.ToString() + ","
                    + car[i].carCost.ToString() + "\r\n";
                sw.Write(lin);
            }
            sw.Close();
        }

        /// <summary>
        /// 读取城市之间信息表
        /// </summary>
        /// <param name="citytocity"></param>
        /// <param name="num"></param>
        public void ReadCityToCityCsv(List<List<Parameter.CityToCity>> citytocity, int cityCount)
        {
            if (cityCount == 0)
            {
                return;
            }
            StreamReader sr = new StreamReader(fp_city_to_city, System.Text.Encoding.Unicode);
            for (int i = 0; i < cityCount * cityCount; i++)
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
                                if (Convert.ToInt32(csv[column]) == -1)
                                {
                                    ele = eleDefalut;
                                }
                                else
                                {
                                    ele.distance = Convert.ToInt32(csv[column]);
                                }
                                break;
                            case 1:
                                ele.cashfare = Convert.ToInt32(csv[column]);
                                break;
                            case 2:
                                ele.coinfare = Convert.ToInt32(csv[column]);
                                break;
                            case 3:
                                ele.people = Convert.ToInt32(csv[column]);
                                break;
                            case 4:
                                ele.cargo = Convert.ToInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                item.Add(ele);
                if (item.Count == cityCount)
                {
                    citytocity.Add(item);
                    item = new List<Parameter.CityToCity>();
                }
            }
            sr.Close();
        
        }

        /// <summary>
        /// 添加城市之间信息
        /// </summary>
        /// <param name="citytocity"></param>
        public void CreatCityToCityCsv(List<List<Parameter.CityToCity>> citytocity, List<Parameter.City> city)
        {
            ele = new Parameter.CityToCity();
            item = new List<Parameter.CityToCity>();
            if (city.Count == 1)
            {
                item.Add(eleDefalut);
                citytocity.Add(item);
                return;
            }
            string fp = "";
            for (int i = 0; i < city.Count-1; i++)
            {
                if (city[i].cityIndex < city[city.Count-1].cityIndex)
                {
                    fp = fp_city_to_city_default + city[i].cityIndex.ToString("00000") + city[city.Count - 1].cityIndex.ToString("00000") + ".csv";
                }
                else
                {
                    fp = fp_city_to_city_default + city[city.Count - 1].cityIndex.ToString("00000") + city[i].cityIndex.ToString("00000") + ".csv";
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
                                ele.distance = Convert.ToInt32(csv[column]);
                                break;
                            case 1:
                                ele.cashfare = Convert.ToInt32(csv[column]);
                                break;
                            case 2:
                                ele.coinfare = Convert.ToInt32(csv[column]);
                                break;
                            default:
                                break;
                        }
                    }
                }

                sr.Close();
                ele.people = 0;
                ele.cargo = 0;
                item.Add(ele);
                citytocity[i].Add(ele);
            }

            item.Add(eleDefalut);
            citytocity.Add(item);
        }

        /// <summary>
        /// 更新城市之间信息
        /// </summary>
        /// <param name="citytocity"></param>
        /// <param name="num"></param>
        public void UpdateCityToCityCsv(List<List<Parameter.CityToCity>> citytocity)
        {
            StreamWriter sw = new StreamWriter(fp_city_to_city, false, System.Text.Encoding.Unicode);
            string lin = "";
            if (citytocity.Count == 0)
            {
                sw.Write(lin);
                sw.Close();
                return;
            }
            for (int i = 0; i < citytocity.Count; i++)
            {
                for (int j = 0; j < citytocity.Count; j++)
                {
                    lin = "";
                    if (i == j)
                    {
                        lin = (-1).ToString() + "\r\n";
                    }
                    else
                    {
                        lin = citytocity[i][j].distance.ToString() + ","
                            + citytocity[i][j].cashfare.ToString() + ","
                            + citytocity[i][j].coinfare.ToString() + ","
                            + citytocity[i][j].people.ToString() + ","
                            + citytocity[i][j].cargo.ToString() + "\r\n";
                    }
                    sw.Write(lin);
                }            
            }
            sw.Close();
        }
    }
}
