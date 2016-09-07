﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace train
{
    public partial class Store : Form
    {
        string fp_car_default = ".\\Record\\carDefault\\";
        public Store()
        {
            InitializeComponent();
           
            updateStore();
            timer1.Interval = 10000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void updateStore()
        {
            comboBox1.Items.Clear();          
            DirectoryInfo di = new DirectoryInfo(fp_car_default);
            var t = di.GetFiles();
            int newRandom = 0;
            int oldRandom = 0;
            Random r = new System.Random();
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    newRandom = r.Next(t.Length);
                } while (oldRandom == newRandom);
                oldRandom = newRandom;
                string p = t[oldRandom].Name;
                string[] fileName = p.Split('.');
                comboBox1.Items.Add(fileName[0]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string fp_search = fp_car_default + comboBox1.SelectedItem.ToString() + ".csv";
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
                            listBox1.Items.Add("列车名称:" + csv[column]);
                            break;
                        case 1:
                            listBox1.Items.Add("客运能力:" + csv[column]);
                            break;
                        case 2:
                            listBox1.Items.Add("货运能力:" + csv[column]);
                            break;
                        case 3:
                            listBox1.Items.Add("列车速度:" + csv[column]);
                            break;
                        case 4:
                            listBox1.Items.Add("列车电量:" + csv[column]);
                            break;
                        case 5:
                            listBox1.Items.Add("列车重量:" + csv[column]);
                            break;
                        case 6:
                            listBox1.Items.Add("列车价值:" + csv[column]);
                            break;
                        default:
                            break;
                    }
                }
            }
            sr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            updateStore();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = comboBox1.SelectedItem.ToString();
        }

    }
}
