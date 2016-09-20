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
    public partial class Exchange : Form
    {
        AutoResizeForm asc = new AutoResizeForm();
        Main main = new Main();

        public Exchange(Main _main, ulong exchangeCoin)
        {
            InitializeComponent();
            main = _main;
            CashValueLabel.Text = main.custom[0].cash.ToString();
            CoinValueLabel.Text = main.custom[0].coin.ToString();
            ExchangeTrackBar.Maximum = Convert.ToInt32(main.custom[0].cash / 1000000);
            ExchangeCoinMaxLabel.Text = ExchangeTrackBar.Maximum.ToString();
            ExchangeTrackBar.Value = Convert.ToInt32(exchangeCoin);
            ExchangeCoinTextBox.Text = exchangeCoin.ToString();
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 窗体关闭按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Store_FormClosing(object sender, FormClosingEventArgs e)
        {
            //    if (!buy)
            //    {
            //        if (MessageBox.Show("确定离开商城吗？", "离开商城提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //        {
            //            saveList();
            //            buy = false;
            //            this.Close();
            //        }
            //    }
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
