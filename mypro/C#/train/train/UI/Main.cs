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
using System.IO;
using System.Timers; 

namespace train
{
    public partial class Main : Form
    {
        AutoResizeForm asc = new AutoResizeForm();
        CSV Csv = new CSV();
        CalculatorTime calTime = new CalculatorTime();
        DateTime DefalutTime = new DateTime(0001, 01, 01, 00, 00, 00);

        Parameter.City ReadCity = new Parameter.City();
        //Parameter.Garage ReadGarage = new Parameter.Garage();
        //Parameter.Car ReadCar = new Parameter.Car();
        List<Parameter.CityToCity> item = new List<Parameter.CityToCity>();
        Parameter.CityToCity ele = new Parameter.CityToCity();

        public Parameter.Custom[] custom = new Parameter.Custom[1];
        List<Parameter.City> city = new List<Parameter.City>();
        public List<Parameter.Garage> garage = new List<Parameter.Garage>();
        List<Parameter.Car> car = new List<Parameter.Car>();
        List<List<Parameter.CityToCity>> citytocity = new List<List<Parameter.CityToCity>>();

        int count = 0;
        string s = "";
        bool text = false;
        int[] stationUpdateTimeArray = new int[2];
        
        public Main()
        {
            InitializeComponent();
            InitializeInformation();
            InitializeTime();
        }

        

        private void InitializeTime()
        {        
            PeopleAndCargoUpdateTimer.Enabled = true;
            PeopleAndCargoUpdateTimer.Start();
        }

        private void InitializeInformation()
        {
            //读取账户信息
            Csv.ReadCustomCsv(custom);
            //读取开通城市详细信息
            Csv.ReadCityCsv(city, custom[0].cityVolume);
            //读取使用中火车详细信息
            Csv.ReadCarCsv(car, custom[0].carVolume);
            //读取仓库中火车详细信息
            Csv.ReadGarageCsv(garage, custom[0].garageVolume);
            //读取城市与城市之间信息
            Csv.ReadCityToCityCsv(citytocity, city.Count);

            stationUpdateTimeArray = (int[])calTime.StationUpdateTimeArray(custom[0].closeTime);
            PeopleAndCargoUpdateTimer.Interval = stationUpdateTimeArray[0];

            if (stationUpdateTimeArray[1] != 0 && custom[0].cityVolume >= 2)
            {
                Csv.UpdateCityToCity(citytocity, city, stationUpdateTimeArray[1]);
            }
            
            //TimeSpan span = new TimeSpan(0, 0, 0);
            //span = DateTime.Now - custom[0].closeTime;
            //this.Text = (span.Days*24 +span.Hours).ToString();

            //if (car.Count > 0)
            //{
            //    for (int i = 0; i < car.Count; i++)
            //    {
            //        if (DateTime.Compare(car[i].carArrivalTime, System.DateTime.Now) < 0 && DateTime.Compare(car[i].carArrivalTime, DefalutTime) != 0)
            //        {
            //            ReadCar = car[i];
            //            ReadCar.carstatus = false;
            //            ReadCar.carDepartureCityIndex = car[i].carArrivalCityIndex;
            //            ReadCar.carDepartureCityName = car[i].carArrivalCityName;
            //            ReadCar.carDepartureTime = DefalutTime;
            //            ReadCar.carArrivalCityIndex = 0;
            //            ReadCar.carArrivalCityName = null;
            //            ReadCar.carArrivalTime = DefalutTime;
            //            custom[0].cash += (UInt64)ReadCar.carTotalCash;
            //            custom[0].coin += (UInt64)ReadCar.carTotalCoin;
            //            ReadCar.carTotalCash = 0;
            //            ReadCar.carTotalCoin = 0;
            //            ReadCar.carCost = 0;
            //            car[i] = ReadCar;
            //        }
            //    }
            //    carDisplay();
            //}
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
            {
                text = false;
                return;
            }
            else
            {
                s = textBox2.Text;
                text = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!text)
            {
                return;
            }
            else
            {
                text = false;
                if (!File.Exists(Csv.fp_city_default + s + ".csv"))
                {
                    MessageBox.Show("没有该城市",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                if (city.Exists(x => x.cityName == s))
                {
                    MessageBox.Show("已开通该城市",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                Csv.AddCity(city, s);
                custom[0].cityVolume++;
                Csv.CreatCityToCityCsv(citytocity, city);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!text)
            {
                return;
            }
            else
            {
                text = false;
                if (city.Count == 0)
                {
                    MessageBox.Show("你当前没有开通城市",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < city.Count; i++)
                {
                    if (city[i].cityName == s)
                    {
                        ReadCity = city[i];
                        city.Remove(ReadCity);
                        custom[0].cityVolume--;
                        item = citytocity[i];
                        citytocity.Remove(item);
                        if (city.Count == 0)
                        {
                            MessageBox.Show("你当前没有开通城市之间信息列表",
                                            "エラー",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }
                        for (int j = 0; j < city.Count; j++)
                        {
                            ele = citytocity[j][i];
                            citytocity[j].Remove(ele);
                        }
                        return;
                    }
                }
                MessageBox.Show("开通城市中没有你想删除的城市",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 进入商城界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreButton_Click(object sender, EventArgs e)
        {
            Store store = new Store(this);
            this.Visible = false;
            store.ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// 进入仓库界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GarageButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            custom[0].closeTime = DateTime.Now;
            Csv.SaveCustomCsv(custom);
            Csv.SaveCityCsv(city);
            Csv.SaveGarageCsv(garage);
            Csv.SaveCarCsv(car);
            Csv.SaveCityToCityCsv(citytocity);
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 车站人员和货物数量更新计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeopleAndCargoUpdateTimer_Tick(object sender, EventArgs e)
        {
            PeopleAndCargoUpdateTimer.Enabled = false;
            Csv.UpdateCityToCity(citytocity, city,1);
            PeopleAndCargoUpdateTimer.Interval = 600000;
            PeopleAndCargoUpdateTimer.Enabled = true; 
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 窗体和控件自适配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 记录窗体和其控件的初始位置和大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 取消窗体关闭按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
     
    }
}
