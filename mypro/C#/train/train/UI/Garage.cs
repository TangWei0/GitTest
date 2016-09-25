using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace train.UI
{
    public partial class Garage : Form
    {
        AutoResizeForm asc = new AutoResizeForm();
        Main main = new Main();

        public Garage(Main _main)
        {
            InitializeComponent();
            main = _main;
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 窗体关闭按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定离开车库吗？", "离开提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 记录窗体和其控件的初始位置和大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garage_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 窗体和控件自适配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garage_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }        
    }
}
