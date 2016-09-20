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

        private void ExchangeCoinTextBox_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("请输入数字！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Handled = true;
            }
            ExchangeCoinTextBox_Validating(new object(), new CancelEventArgs());
        }

        private void ExchangeCoinTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int v = Convert.ToInt32(ExchangeCoinTextBox.Text);
                int w = Convert.ToInt32(ExchangeCoinMaxLabel.Text);
                if (v < 0 || v > w)
                {
                    MessageBox.Show("请输入正确数值范围", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            catch
            {
                MessageBox.Show("异常处理，请重新输入数字","异常提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }
}
