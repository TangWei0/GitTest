using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace train
{
    public partial class Form1 : Form
    {
        CSV Csv = new CSV();
        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);

        Parameter.City ReadCity = new Parameter.City();
        Parameter.Garage ReadGarage = new Parameter.Garage();
        Parameter.Car ReadCar = new Parameter.Car();
        
        public Parameter.Custom[] custom = new Parameter.Custom[1];
        List<Parameter.City> city = new List<Parameter.City>();
        List<Parameter.Garage> garage = new List<Parameter.Garage>();
        List<Parameter.Car> car = new List<Parameter.Car>();
        //List<List<int>> cityToCity = new List<List<int>>();
        //Parameter.CityToCity[] city_to_city = new Parameter.CityToCity[1];


        System.Random r = new System.Random(1000);
        int count = 0;

        public Form1()
        {
            InitializeComponent();

            //读取账户信息
            Csv.ReadCustomCsv(custom);
            //读取开通城市详细信息
            Csv.ReadCityCsv(city, custom[0].cityVolume);
            //读取使用中火车详细信息
            Csv.ReadCarCsv(car, custom[0].carVolume);
            //读取仓库中火车详细信息
            Csv.ReadGarageCsv(garage, custom[0].garageVolume);
            //
            //Csv.ReadCityToCityCsv(cityToCity, city);

            TimeSpan span = new TimeSpan(0,0,0);
            span = DateTime.Now - custom[0].closeTime;
            this.Text = (span.Days*24 +span.Hours).ToString();

            for (int i = 0; i < car.Count; i++)
            {
                if (DateTime.Compare(car[i].carArrivalTime, System.DateTime.Now) < 0 && DateTime.Compare(car[i].carArrivalTime, DefalutTime) != 0)
                {
                    ReadCar = car[i];
                    ReadCar.carstatus = false;
                    ReadCar.carDepartureCityIndex = car[i].carArrivalCityIndex;
                    ReadCar.carDepartureCityName = car[i].carArrivalCityName;
                    ReadCar.carDepartureTime = DefalutTime;
                    ReadCar.carArrivalCityIndex = 0;
                    ReadCar.carArrivalCityName = null;
                    ReadCar.carArrivalTime = DefalutTime;
                    custom[0].cash += (UInt64)ReadCar.carTotalCash;
                    custom[0].coin += (UInt64)ReadCar.carTotalCoin;
                    ReadCar.carTotalCash = 0;
                    ReadCar.carTotalCoin = 0;
                    ReadCar.carCost = 0;
                    car[i] = ReadCar;
                }
            }


            carDisplay();

        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            custom[0].closeTime = DateTime.Now;
            Csv.UpdateCustomCsv(custom);
            Csv.UpdateCityCsv(city);
            Csv.UpdateGarageCsv(garage);
            Csv.UpdateCarCsv(car);
        }

        private void carDisplay()
        {
            if (count < 0)
            {
                count = car.Count - 1;
            }
            count = count % car.Count;

            carNameText.Text = car[count].carName;
            if (!car[count].carstatus)
            {
                cityNameLabel.Text = car[count].carDepartureCityName;
            }
            else
            {
                cityNameLabel.Text = "运行中";
            }

        }

        //public void button1_Click(object sender, EventArgs e)
        //{

        //    UInt16 next;
        //    for (int i = 0; i < custom[0].garageVolume; i++)
        //    {
        //        if (!garage[i].carstatus && garage[i].carPower != 0)
        //        {
        //            do
        //            {
        //                next = (UInt16)(r.Next(CityList.Count));
        //            } while (next==i);

        //            Csv.ReadCityToCityCsv(city_to_city, garage[i].carDepartureCityIndex, (UInt16)(next + 1));

        //            int s1 = (city_to_city[0].distance * 3600) / garage[i].carSpeed;
        //            if (garage[i].carPower > (s1 / 3600))
        //            {
        //                garage[i].carArrivalCityIndex = city[next].cityIndex;
        //                garage[i].carArrivalCityName = city[next].cityName;
        //                garage[i].carDepartureTime = DateTime.Now;

        //                TimeSpan s = new TimeSpan(0, 0, 0, s1);

        //                garage[i].carArrivalTime = garage[i].carDepartureTime + s;
        //                garage[i].carstatus = true;
        //                garage[i].carTotalFare = cal(i)[0];
        //                garage[i].carCost = cal(i)[1];
        //                garage[i].carPower -= (UInt16)(s1 / 3600);
        //                Csv.UpdateGarageCsv(garage, i);

        //                custom[0].cash -= garage[i].carCost;
        //                Csv.UpdateCustomCsv(custom);
        //            }
        //            else
        //            {
        //                this.Text = "遣り直す";
        //            }
        //        }
        //    }

        //}

        //private UInt32[] cal(int i)
        //{
        //    UInt32[] total = new UInt32[2] { 0, 0 };

        //    total[0] = (UInt32)(10 * garage[i].carPeopleVolume * city_to_city[0].fare + garage[i].carPeopleVolume * garage[i].carPeopleVolume * city_to_city[0].fare) / 10;
        //    total[1] = (UInt32)(garage[i].carPeopleVolume * garage[i].carWeight * city_to_city[0].distance / 5000);

        //    return total;
        //}

        

        

        

        public void button2_Click(object sender, EventArgs e)
        {
            //string cityName1 = "上海";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string cityName = "上海";
            //Csv.SearchAddCity(city, cityName);
            //custom[0].cityVolume = Convert.ToUInt16(city.Count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string cityName = "广州";
            //Csv.SearchDelCity(city, cityName);
            //custom[0].cityVolume = Convert.ToUInt16(city.Count);
        }

        private void Next_Click_1(object sender, EventArgs e)
        {
            count++;
            carDisplay();
        }

        private void Previous_Click_1(object sender, EventArgs e)
        {
            count--;
            carDisplay();
        }
    }
}
