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
        bool buyCityCheck = false;


        public CityManage(Main _main)
        {
            InitializeComponent();
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

            CityListBox.Items.Clear();

            DirectoryInfo TheFolder = new DirectoryInfo(fp_city_default + ProvinceListBox.SelectedItem.ToString());
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                CityListBox.Items.Add(NextFolder.Name);
                

                
            }

            CityListBox.DrawMode = DrawMode.OwnerDrawFixed;
            //CityListBox.DrawItem += new DrawItemEventHandler(CityListBox_DrawItem);
            //buyCityCheck = true;
            
        }

        private void CityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("################");
        }

        private void CityListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            CityListBox_SelectedIndexChanged(new object(), new EventArgs());
            //int i = 0;
            //if (buyCityCheck)
            //{
                e.DrawBackground();

                if (main.city.Exists(x => x.cityName == CityListBox.Items[e.Index].ToString()))
                {
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Red), e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                }
                e.DrawFocusRectangle();
                //i++;
                //if (i > CityListBox.Items.Count)
                //{
                //    buyCityCheck = false;
                //    return;
                //}
           
            
        }

        private void OpenCityOrCloseCityButton_Click(object sender, EventArgs e)
        {
            if (CityListBox.SelectedItem == null)
            {
                if (MessageBox.Show("你还没有选择城市", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    return;
                }
            }
            if (OpenCityOrCloseCityButton.Text == "开通城市")
            {
                Csv.AddCity(main.city, fp_city_default
                                     + ProvinceListBox.SelectedItem.ToString() + "\\"
                                     + CityListBox.SelectedItem.ToString() + "\\"
                                     + CityListBox.SelectedItem.ToString() + ".csv");
                //buyCityCheck = true;
                //ProvinceListBox_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {

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

        









    }
}
