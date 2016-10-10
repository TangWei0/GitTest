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
        //int cityIndex = 0;
        ListViewItem itemx = new ListViewItem();

        public CityManage(Main _main)
        {
            InitializeComponent();
            CityListView.View = View.Details;
            //CityListView.HeaderStyle = ColumnHeaderStyle.None;
            CityListView.FullRowSelect = true;
            CityListView.Columns.Add("");
            CityListView.Columns[0].Width = CityListView.Width - 70;
            //CityListView.Scrollable = true;
            //CityListView.Columns.Add("");
            //CityListView.Columns[0].Width = CityListView.Width - 24;
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
                    int i = CityListView.Items.IndexOfKey(NextFolder.Name);
                    CityListView.Items[0].ForeColor = Color.Red; 
                }
            }
        }

        //private void CityListBox_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    Console.WriteLine("{0}", i);
        //    e.DrawBackground();

        //    if (main.city.Exists(x => x.cityName == CityListBox.Items[e.Index].ToString()))
        //    {
        //        e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Red), e.Bounds);
        //    }
        //    else
        //    {
        //        e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        //    }
        //    e.DrawFocusRectangle();
        //    i++;
        //}

        private void OpenCityOrCloseCityButton_Click(object sender, EventArgs e)
        {
            if (CityListView.SelectedItems == null)
            {
                if (MessageBox.Show("你还没有选择城市", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    return;
                }
            }
            if (OpenCityOrCloseCityButton.Text == "开通城市")
            {

                itemx = CityListView.SelectedItems[0];

                Csv.AddCity(main.city, fp_city_default
                                     + ProvinceListBox.SelectedItem.ToString() + "\\"
                                     + itemx.Text + "\\"
                                     + itemx.Text + ".csv");
                ProvinceListBox_SelectedIndexChanged(new object(), new EventArgs());
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
