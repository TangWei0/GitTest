using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace train.UI
{
    public partial class CityManage : Form
    {
        Main main;
        AutoResizeForm asc = new AutoResizeForm();
        CSV Csv = new CSV();
        string fp_city_default = ".\\Record\\cityDefault\\";
        ListViewItem item = new ListViewItem();

        public CityManage(Main _main)
        {
            InitializeComponent();
            CityListView.View = View.Details;
            CityListView.FullRowSelect = true;
            CityListView.Columns.Add("");
            CityListView.Columns[0].Width = CityListView.Width - 70;
            main = _main;
            InitializeInformate();
        }

        private void InitializeInformate()
        {
            DirectoryInfo TheFolder = new DirectoryInfo(fp_city_default);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                ProvinceListBox.Items.Add(NextFolder.Name);
            }
        }

        private void ProvinceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinceListBox.SelectedItem == null)
            {
                return;
            }
            CityListView.Items.Clear();
            DirectoryInfo TheFolder = new DirectoryInfo(fp_city_default + ProvinceListBox.SelectedItem.ToString());
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {

                CityListView.Items.Add(NextFolder.Name);
                if (main.city.Exists(x => x.cityName == NextFolder.Name))
                {
                    ListViewItem foundItem = CityListView.FindItemWithText(NextFolder.Name, false, 0);
                    if (foundItem != null)
                    {
                        CityListView.TopItem = foundItem;  //定位到该项  
                        foundItem.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void CityListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CityListView.SelectedItems.Count == 0)
            {
                OpenCityOrCloseCityButton.Text = "未选中城市";
            }
            else
            {
                item = CityListView.SelectedItems[0];
                if (item.ForeColor == Color.Red)
                {
                    OpenCityOrCloseCityButton.Text = "关闭城市";
                }
                else
                {
                    OpenCityOrCloseCityButton.Text = "开通城市";
                }
            }
        }

        private void OpenCityOrCloseCityButton_Click(object sender, EventArgs e)
        {
            item = CityListView.SelectedItems[0];
            string selectCityPath = fp_city_default
                                  + ProvinceListBox.SelectedItem.ToString() + "\\"
                                  + item.Text + "\\"
                                  + item.Text + ".csv";
            if (OpenCityOrCloseCityButton.Text == "未选中城市")
            {
                if (MessageBox.Show("你还没有选择城市", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    return;
                }
            }
            if (OpenCityOrCloseCityButton.Text == "开通城市")
            {
                Csv.AddCity(main.city, selectCityPath);
                main.custom[0].cityVolume++;
                Csv.CreatCityToCityCsv(main.citytocity, main.city);
                item.ForeColor = Color.Red;
                CityListView.SelectedItems.Clear();
            }
            if (OpenCityOrCloseCityButton.Text == "关闭城市")
            {
                int cityIndex = main.city.FindIndex(x => x.cityName == item.Text);                
                main.city.Remove(main.city[cityIndex]);
                main.custom[0].cityVolume--;
                if (main.city.Count == 0)
                {
                    main.citytocity.Clear();
                }
                else
                {
                    main.citytocity.Remove(main.citytocity[cityIndex]);
                    for (int j = 0; j < main.city.Count; j++)
                    {
                        main.citytocity[j].Remove(main.citytocity[j][cityIndex]);
                    }
                }
                item.ForeColor = Color.Black;
                CityListView.SelectedItems.Clear();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定离开城市管理界面吗？", "离开提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 记录窗体和其控件的初始位置和大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityManage_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 窗体和控件自适配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityManage_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (main.city.Count == 0)
            {
                return;
            }
            for (int i = 0; i < main.city.Count; i++)
            {
                Console.WriteLine(main.city[i].cityName);
                for (int j = 0; j < main.city.Count; j++)
                {
                    Console.WriteLine("{0},{1},{2},{3}", main.citytocity[i][j].distance, main.citytocity[i][j].cashfare, main.citytocity[i][j].people, main.citytocity[i][j].cargo);
                }
            }
        }       
    }
}
