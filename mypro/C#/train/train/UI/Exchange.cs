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
    /// <summary>
    /// 兑换界面窗体
    /// </summary>
    public partial class Exchange : Form
    {
        AutoResizeForm asc = new AutoResizeForm();
        Main main = new Main();

        /// <summary>
        /// 启动兑换界面
        /// </summary>
        /// <param name="_main"></param>
        /// <param name="exchangeCoin"></param>
        public Exchange(Main _main, ulong exchangeCoin)
        {
            InitializeComponent();
            main = _main;
            InitializeInformation(exchangeCoin);
        }

        /// <summary>
        /// 各控件再设置
        /// </summary>
        /// <param name="exchangeCoin"></param>
        private void InitializeInformation(ulong exchangeCoin)
        {
            CashValueLabel.Text = main.custom[0].cash.ToString();
            CoinValueLabel.Text = main.custom[0].coin.ToString();
            ExchangeTrackBar.Maximum = Convert.ToInt32(main.custom[0].cash / 1000000);
            ExchangeCoinMaxLabel.Text = ExchangeTrackBar.Maximum.ToString();
            ExchangeCoinTextBox.Text = exchangeCoin.ToString();
        }

        /// <summary>
        /// 数值输入控制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeCoinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("请输入数字！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 数值框数值变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeCoinTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ExchangeCoinTextBox.Text == "")
            {
                ExchangeCoinTextBox.Text = ExchangeTrackBar.Minimum.ToString();
                return;
            }
            int v = Convert.ToInt32(ExchangeCoinTextBox.Text);
            if (v < 0 || v > Convert.ToInt32(ExchangeCoinMaxLabel.Text))
            {
                MessageBox.Show("请输入正确数值范围", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (v < 0)
                {
                    ExchangeCoinTextBox.Text = "0";
                }
                else
                {
                    ExchangeCoinTextBox.Text = ExchangeCoinMaxLabel.Text;
                }
                //e.Cancel = true;
            }
            else
            {
                ExchangeTrackBar.Value = Convert.ToInt32(ExchangeCoinTextBox.Text);
                return;
            }
        }

        /// <summary>
        /// 数值滑块变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ExchangeCoinTextBox.Text = ExchangeTrackBar.Value.ToString();
        }

        /// <summary>
        /// 兑换按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定兑换吗？", "兑换提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                main.custom[0].cash -= Convert.ToUInt64(ExchangeTrackBar.Value) * 1000000;
                main.custom[0].coin += Convert.ToUInt64(ExchangeTrackBar.Value);
                InitializeInformation(0);
            }
        }

        /* 以下为窗体设计程序 */
        /// <summary>
        /// 窗体关闭按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exchange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定离开兑换点券界面吗？", "离开提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
                //return;
            }
        }

        /// <summary>
        /// 记录窗体和其控件的初始位置和大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exchange_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 窗体和控件自适配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exchange_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
     
    }
}
