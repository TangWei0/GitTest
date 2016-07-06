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
        Parameter.Custom[] custom = new Parameter.Custom[1];
        Parameter.City[] city = new Parameter.City[1];
        Parameter.Garage[] garage = new Parameter.Garage[1];

        CSV Csv = new CSV();

        System.Random r = new System.Random(1000);


        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);
        public Form1()
        {
            InitializeComponent();

            Csv.ReadCustomCsv(custom);

            if (city.Length != custom[0].cityVolume)
            {
                Array.Resize(ref city, custom[0].cityVolume);
            }
            if (garage.Length != custom[0].garageVolume)
            {
                Array.Resize(ref garage, custom[0].garageVolume);
            }

            Csv.ReadCityCsv(city, custom[0].cityVolume);
            Csv.ReadGarageCsv(garage, custom[0].garageVolume);
            for (int i = 0; i < custom[0].garageVolume; i++)
            {
                if (DateTime.Compare(garage[i].carArrivalTime, System.DateTime.Now) < 0 && DateTime.Compare(garage[i].carArrivalTime, DefalutTime) != 0)
                {
                    garage[i].carstatus = false;
                    garage[i].carDepartureCityIndex = garage[i].carArrivalCityIndex;
                    garage[i].carDepartureCityName = garage[i].carArrivalCityName;
                    garage[i].carDepartureTime = DefalutTime;
                    garage[i].carArrivalCityIndex = 0;
                    garage[i].carArrivalCityName = null;
                    garage[i].carArrivalTime = DefalutTime;
                    custom[0].cash += (UInt64)garage[i].carTotalFare;
                    Csv.UpdateCustomCsv(custom);
                    garage[i].carTotalFare = 0;
                    Csv.UpdateGarageCsv(garage, 1);
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            UInt16 next;
            for (int i = 0; i < custom[0].garageVolume; i++)
            {
                if (!garage[i].carstatus)
                {
                    UInt16 now;
                    now = serchCityIndex(i);

                    do
                    {
                        next = (UInt16)r.Next(custom[0].cityVolume);
                    } while (next == now);

                    UInt16 distance = Csv.ReadDistanceCsv(garage[i].carDepartureCityIndex, city[next].cityIndex);
                    UInt16 fare = Csv.ReadFareCsv(garage[i].carDepartureCityIndex, city[next].cityIndex);

                    garage[i].carArrivalCityIndex = city[next].cityIndex;
                    garage[i].carArrivalCityName = city[next].cityName;
                    garage[i].carDepartureTime = System.DateTime.Now;

                    int s1 = (distance * 3600) / garage[i].carSpeed;
                    TimeSpan s = new TimeSpan(0, 0, 0, s1);

                    garage[i].carArrivalTime = garage[i].carDepartureTime + s;
                    garage[i].carstatus = true;
                    garage[i].carTotalFare = (UInt32)(garage[i].carPeopleVolume + garage[i].carCargoVolume) * fare * 11 /10;

                    Csv.UpdateGarageCsv(garage, (UInt16)(i+1));
                }
            }

        }

        private UInt16 serchCityIndex(int i)
        {
            for (int j = 0; j < custom[0].cityVolume; j++)
            {
                if (city[j].cityIndex == garage[i].carDepartureCityIndex)
                {
                    return (UInt16)j;
                }

            }
            return 0;
        }

    }
}
