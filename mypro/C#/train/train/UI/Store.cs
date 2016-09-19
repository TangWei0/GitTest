using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using setting = train.Properties.Settings;
using train.UI;

namespace train
{
    public partial class Store : Form
    {
        Main main = new Main();
        AutoResizeForm asc = new AutoResizeForm();
        CSV Csv = new CSV();
        CalculatorTime calTime = new CalculatorTime();
        string fp_car_default = ".\\Record\\carDefault\\";
        DateTime target = new DateTime();
        Parameter.Garage ReadGarage = new Parameter.Garage();
        TimeSpan span = new TimeSpan(0, 5, 0);
        public ulong exchangeCoin;
        public bool buy = false;
        /// <summary>
        /// 读取商城窗体信息
        /// </summary>
        /// <param name="_Main"></param>
        public Store(Main _main)
        {
            InitializeComponent();
            main = _main;
            StoreUpdateTimer.Interval = calTime.StoreUpdateTime(setting.Default.storeUpdateTime);
            InitializeTime();   
        }

        /// <summary>
        /// 商城更新时间初始化
        /// </summary>
        private void InitializeTime()
        {
            if (StoreUpdateTimer.Interval == 300000)
            {
                updateStore();
            }
            else
            {
                readList();
            }
            StoreUpdateTimer.Enabled = true;
            StoreUpdateTimer.Start();
        }

        /// <summary>
        /// 触发商城更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreUpdateTimer_Tick(object sender, EventArgs e)
        {
            StoreUpdateTimer.Enabled = false;
            updateStore();
            StoreUpdateTimer.Enabled = true;
        }

        /// <summary>
        /// 更新商城车辆列表
        /// </summary>
        private void updateStore()
        {
            StoreListBox.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(fp_car_default);
            var t = di.GetFiles();
            Random r = new System.Random();
            for (int i = 0; i < 6; i++)
            {
                int random = r.Next(t.Length);
                string p = t[random].Name;
                string[] fileName = p.Split('.');
                StoreListBox.Items.Add(fileName[0]);
            }
            StoreUpdateTimer.Interval = 300000;
            target = DateTime.Now + span;
        }

        /// <summary>
        /// 触发商城车辆详细列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetailListBox.Items.Clear();
            if (StoreListBox.SelectedItem == null || StoreListBox.SelectedItem.ToString() == "空")
            {
                return;
            }
            string fp_search = fp_car_default + StoreListBox.SelectedItem.ToString() + ".csv";
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
                            CarDetailListBox.Items.Add("列车名称:" + csv[column]);
                            break;
                        case 1:
                            CarDetailListBox.Items.Add("客运能力:" + csv[column]);
                            break;
                        case 2:
                            CarDetailListBox.Items.Add("货运能力:" + csv[column]);
                            break;
                        case 3:
                            CarDetailListBox.Items.Add("列车速度:" + csv[column]);
                            break;
                        case 4:
                            CarDetailListBox.Items.Add("列车电量:" + csv[column]);
                            break;
                        case 5:
                            CarDetailListBox.Items.Add("列车重量:" + csv[column]);
                            break;
                        case 6:
                            CarDetailListBox.Items.Add("列车价值:" + csv[column]);
                            break;
                        default:
                            break;
                    }
                }
            }
            sr.Close();
        }      

        /// <summary>
        /// 触发购买事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyCarButton_Click(object sender, EventArgs e)
        {
            if (StoreListBox.SelectedItem == null || StoreListBox.SelectedItem.ToString() == "空")
            {
                if (MessageBox.Show("你还没有选择车辆", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    return;
                }           
            }
            if (MessageBox.Show("购买该列车吗？", "购买提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                buy = true;
                ulong a = Convert.ToUInt64(CarInformation(CarDetailListBox.Items[6].ToString()));
                exchangeCoin = a - main.custom[0].coin;
                if (exchangeCoin > 0)
                {
                    if (MessageBox.Show("您当前点券不够,进入兑换界面吗？", "兑换提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        Exchange exchange = new Exchange(main.custom[0].cash, main.custom[0].coin,exchangeCoin);
                        this.Visible = false;
                        exchange.ShowDialog();
                        this.Visible = true;
                    }
                }
                BuyCar();               
                saveList();
                this.Close();
            }
        }       

        /// <summary>
        /// 购买车辆
        /// </summary>
        private void BuyCar()
        {
            for (int i = 0; i < CarDetailListBox.Items.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            ReadGarage.carName = CarInformation(CarDetailListBox.Items[0].ToString()) + "_" + Properties.Settings.Default.carCount.ToString("00000000");
                            break;
                        case 1:
                            ReadGarage.carPeopleVolume = Convert.ToByte(CarInformation(CarDetailListBox.Items[1].ToString()));
                            break;
                        case 2:
                            ReadGarage.carCargoVolume = Convert.ToByte(CarInformation(CarDetailListBox.Items[2].ToString()));
                            break;
                        case 3:
                            ReadGarage.carSpeed = Convert.ToUInt16(CarInformation(CarDetailListBox.Items[3].ToString()));
                            break;
                        case 4:
                            ReadGarage.carPower = Convert.ToUInt16(CarInformation(CarDetailListBox.Items[4].ToString()));
                            break;
                        case 5:
                            ReadGarage.carWeight = Convert.ToUInt16(CarInformation(CarDetailListBox.Items[5].ToString()));
                            break;
                        case 6:
                            ReadGarage.carValue = Convert.ToUInt64(CarInformation(CarDetailListBox.Items[6].ToString())) * 1000000;
                            break;
                        default:
                            break;
                    }
                }
            main.garage.Add(ReadGarage);
            setting.Default.carCount++;
            main.custom[0].garageVolume++;
            main.custom[0].coin -= Convert.ToUInt64(CarDetailListBox.Items[5].ToString());
            resetList();
        }

        /// <summary>
        /// 读取商城车辆列表
        /// </summary>
        private void readList()
        {
            StoreListBox.Items.Add(setting.Default.list1);
            StoreListBox.Items.Add(setting.Default.list2);
            StoreListBox.Items.Add(setting.Default.list3);
            StoreListBox.Items.Add(setting.Default.list4);
            StoreListBox.Items.Add(setting.Default.list5);
            StoreListBox.Items.Add(setting.Default.list6);
        }

        /// <summary>
        /// 买取车辆后重新设置商城车辆列表
        /// </summary>
        private void resetList()
        {
            int selIndex = StoreListBox.SelectedIndex;
            StoreListBox.Items.RemoveAt(selIndex);
            StoreListBox.Items.Add("空");
        }

        /// <summary>
        /// 保存商城车辆列表
        /// </summary>
        private void saveList()
        {
            setting.Default.list1 = StoreListBox.Items[0].ToString();
            setting.Default.list2 = StoreListBox.Items[1].ToString();
            setting.Default.list3 = StoreListBox.Items[2].ToString();
            setting.Default.list4 = StoreListBox.Items[3].ToString();
            setting.Default.list5 = StoreListBox.Items[4].ToString();
            setting.Default.list6 = StoreListBox.Items[5].ToString();
            setting.Default.storeUpdateTime = target;
            setting.Default.Save();
        }

        /// <summary>
        /// 车辆详细信息转换函数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CarInformation(string name)
        {
            string[] csv = name.Split(':');
            return csv[1];
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 窗体关闭按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Store_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buy)
            {
                if (MessageBox.Show("确定离开商城吗？", "离开商城提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    saveList();
                    buy = false;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 记录窗体和其控件的初始位置和大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Store_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 窗体和控件自适配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Store_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
