using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace train
{
    public partial class Form1 : Form
    {
        CSV Csv = new CSV();
        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);
        
        public Parameter.Custom[] custom = new Parameter.Custom[1];
        List<Parameter.City> city = new List<Parameter.City>();
        List<Parameter.Garage> usingGarage = new List<Parameter.Garage>();
        List<Parameter.Garage> unusedGarage = new List<Parameter.Garage>();
        Parameter.CityToCity[] city_to_city = new Parameter.CityToCity[1];

        ulong carCount;
        

        //System.Random r = new System.Random(1000);
        //int count = 0;
        //int calCount;

        public Form1()
        {
            InitializeComponent();

            carCount = Properties.Settings.Default.carCount;
            //读取账户信息
            Csv.ReadCustomCsv(custom);
            //读取开通城市详细信息
            Csv.ReadCityCsv(city, custom[0].cityVolume);
            //读取使用中火车详细信息
            Csv.ReadGarageCsv(usingGarage, custom[0].usingCarVolume,true);
            //读取仓库中火车详细信息
            Csv.ReadGarageCsv(unusedGarage, custom[0].unusedCarVolume,false);

            //TimeSpan span = new TimeSpan(0,0,0);
            //span = DateTime.Now - custom[0].closeTime;
            ////this.Text = (span.Days*24 +span.Hours).ToString();

            //for (int i = 0; i < custom[0].garageVolume; i++)
            //{
            //    if (DateTime.Compare(garage[i].carArrivalTime, System.DateTime.Now) < 0 && DateTime.Compare(garage[i].carArrivalTime, DefalutTime) != 0)
            //    {
            //        garage[i].carstatus = false;
            //        garage[i].carDepartureCityIndex = garage[i].carArrivalCityIndex;
            //        garage[i].carDepartureCityName = garage[i].carArrivalCityName;
            //        garage[i].carDepartureTime = DefalutTime;
            //        garage[i].carArrivalCityIndex = 0;
            //        garage[i].carArrivalCityName = null;
            //        garage[i].carArrivalTime = DefalutTime;
            //        custom[0].cash += (UInt64)garage[i].carTotalFare;
            //        Csv.UpdateCustomCsv(custom);
            //        garage[i].carTotalFare = 0;
            //        garage[i].carCost = 0;
            //        Csv.UpdateGarageCsv(garage, i);
            //    }
            //}

            //carDisplay();

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

        //private void Next_Click(object sender, EventArgs e)
        //{
        //    count++;
        //    carDisplay();
        //}

        //private void Previous_Click(object sender, EventArgs e)
        //{
        //    count--;
        //    carDisplay();
        //}

        //private void carDisplay()
        //{
        //    calCount = count % custom[0].garageVolume;

        //    if (calCount < 0)
        //    {
        //        calCount = custom[0].garageVolume + calCount;
        //    }

        //    carNameText.Text = garage[calCount].carName;
        //    if (!garage[calCount].carstatus)
        //    {
        //        cityNameLabel.Text = garage[calCount].carDepartureCityName;
        //    }
        //    else
        //    {
        //        cityNameLabel.Text = "运行中";
        //    }

        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            custom[0].closeTime = DateTime.Now;
            Csv.UpdateCustomCsv(custom);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //string cityName1 = "上海";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cityName = "上海";
            Csv.SearchAddCity(city, cityName);
            custom[0].cityVolume = Convert.ToUInt16(city.Count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cityName = "广州";
            Csv.SearchDelCity(city, cityName);
            custom[0].cityVolume = Convert.ToUInt16(city.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Csv.UpdateCustomCsv(custom);
            Csv.UpdateCityCsv(city);
        }

    }
}
