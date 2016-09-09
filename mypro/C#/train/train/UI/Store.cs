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

namespace train
{
    public partial class Store : Form
    {
        string fp_car_default = ".\\Record\\carDefault\\";
        public DateTime target = new DateTime();
        TimeSpan span = new TimeSpan(0, 5, 0);
        public bool buy = false;
        string[] listName = new string[6]{setting.Default.list1,
                                          setting.Default.list2,
                                          setting.Default.list3,
                                          setting.Default.list4,
                                          setting.Default.list5,
                                          setting.Default.list6};
        public Store(DateTime storeTime)
        {
            InitializeComponent();

            //this.ControlBox = false;
            target = storeTime;
            if (DateTime.Now > target)
            {
                updateStore();
            }
            else
            {
                readList();
                timer1.Interval = ((target - DateTime.Now).Minutes * 60 + (target - DateTime.Now).Seconds) * 1000;
            }
            timer1.Enabled = true;
            timer1.Start();
        }

        private void updateStore()
        {
            StoreListBox.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(fp_car_default);
            var t = di.GetFiles();
            int newRandom = 0;
            int oldRandom = 0;
            Random r = new System.Random();
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    newRandom = r.Next(t.Length);
                } while (oldRandom == newRandom);
                oldRandom = newRandom;
                string p = t[oldRandom].Name;
                string[] fileName = p.Split('.');
                StoreListBox.Items.Add(fileName[0]);
            }
            timer1.Interval = 300000;
            target = DateTime.Now + span;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            updateStore();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("购买该列车吗？", "买", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                buy = true;
                saveList();
                this.Close();
            }
            else
            {
                Properties.Settings.Default.Save();
            }
        }

        private void readList()
        {
            for (int i = 0; i < 6; i++)
            {
                StoreListBox.Items.Add(listName[i]);
            }
        }

        private void saveList()
        {
            Properties.Settings.Default.list1 = StoreListBox.Items[0].ToString();
            Properties.Settings.Default.list2 = StoreListBox.Items[1].ToString();
            Properties.Settings.Default.list3 = StoreListBox.Items[2].ToString();
            Properties.Settings.Default.list4 = StoreListBox.Items[3].ToString();
            Properties.Settings.Default.list5 = StoreListBox.Items[4].ToString();
            Properties.Settings.Default.list6 = StoreListBox.Items[5].ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarDetailListBox.Items.Clear();
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

        private void Store_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
