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

            if (DateTime.Compare(garage[0].carArrivalTime, System.DateTime.Now) < 0 && DateTime.Compare(garage[0].carArrivalTime, DefalutTime) != 0)
            {
                garage[0].carDepartureCity = "";
                garage[0].carArrivalCity = "";
                garage[0].carDepartureTime = DefalutTime;
                garage[0].carArrivalTime = DefalutTime;

                Csv.UpdateGarageCsv(garage, 1);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            garage[0].carDepartureCity = city[0].cityName;
            garage[0].carArrivalCity = city[1].cityName;
            garage[0].carDepartureTime = System.DateTime.Now;

            TimeSpan s = new TimeSpan(0, 3, 0);

            garage[0].carArrivalTime = garage[0].carDepartureTime + s;

            Csv.UpdateGarageCsv(garage, 1);



        }

    }
}
