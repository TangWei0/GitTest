using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trans
{
    public partial class Form1 : Form
    {
        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);

        Parameter.Custom[] custom = new Parameter.Custom[1];
        Parameter.City c = new Parameter.City();
        List<Parameter.City> city = new List<Parameter.City>();
        Parameter.Garage[] garage = new Parameter.Garage[1];
        Parameter.CityToCity[] city_to_city = new Parameter.CityToCity[1];

        public List<UInt16> CityList = new List<UInt16>();

        CSV Csv = new CSV();

        System.Random r = new System.Random(1000);
        int count = 0;
        int calCount;

        public Form1()
        {
            InitializeComponent();

            Csv.ReadCustomCsv(custom);
            Csv.ReadCityList(CityList);

            if (garage.Length != custom[0].garageVolume)
            {
                Array.Resize(ref garage, custom[0].garageVolume);
            }

            Csv.ReadCityCsv(city,CityList);
            Csv.ReadGarageCsv(garage, custom[0].garageVolume);
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

        public void button1_Click(object sender, EventArgs e)
        {

            UInt16 next;
            for (int i = 0; i < custom[0].garageVolume; i++)
            {
                if (!garage[i].carstatus && garage[i].carPower != 0)
                {
                    do
                    {
                        next = (UInt16)(r.Next(CityList.Count));
                    } while (next==i);

                    Csv.ReadCityToCityCsv(city_to_city, garage[i].carDepartureCityIndex, (UInt16)(next + 1));

                    int s1 = (city_to_city[0].distance * 3600) / garage[i].carSpeed;
                    if (garage[i].carPower > (s1 / 3600))
                    {
                        garage[i].carArrivalCityIndex = city[next].cityIndex;
                        garage[i].carArrivalCityName = city[next].cityName;
                        garage[i].carDepartureTime = DateTime.Now;

                        TimeSpan s = new TimeSpan(0, 0, 0, s1);

                        garage[i].carArrivalTime = garage[i].carDepartureTime + s;
                        garage[i].carstatus = true;
                        garage[i].carTotalFare = cal(i)[0];
                        garage[i].carCost = cal(i)[1];
                        garage[i].carPower -= (UInt16)(s1 / 3600);
                        Csv.UpdateGarageCsv(garage, i);

                        custom[0].cash -= garage[i].carCost;
                        Csv.UpdateCustomCsv(custom);
                    }
                    else
                    {
                        this.Text = "遣り直す";
                    }
                }
            }

        }

        private UInt32[] cal(int i)
        {
            UInt32[] total = new UInt32[2] { 0, 0 };

            total[0] = (UInt32)(10 * garage[i].carPeopleVolume * city_to_city[0].fare + garage[i].carPeopleVolume * garage[i].carPeopleVolume * city_to_city[0].fare) / 10;
            total[1] = (UInt32)(garage[i].carPeopleVolume * garage[i].carWeight * city_to_city[0].distance / 5000);

            return total;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            count++;
            carDisplay();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            count--;
            carDisplay();
        }

        private void carDisplay()
        {
            calCount = count % custom[0].garageVolume;

            if (calCount < 0)
            {
                calCount = custom[0].garageVolume + calCount;
            }

            carNameText.Text = garage[calCount].carName;
            if (!garage[calCount].carstatus)
            {
                cityNameLabel.Text = garage[calCount].carDepartureCityName;
            }
            else
            {
                cityNameLabel.Text = "运行中";
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            custom[0].closeTime = DateTime.Now;
            Csv.UpdateCustomCsv(custom);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            string cityName1 = "天津";
            string cityName2 = "上海";

            Csv.SearchAddCity(CityList, city, cityName1);

            Csv.SearchDelCity(CityList, city, cityName2);
            
            cityName1 = cityName2;
        }


    }
}
