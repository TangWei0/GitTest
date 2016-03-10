using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.UI
{
    public partial class Form_User : Form
    {
        public string usename = "";
        bool closeState = false;
        public Form_User()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            usename = TextBoxName.Text;
            if (usename != "")
            {
                closeState = true;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("您还没输入名字\r\n请输入名字后，点击[确定]按钮", "名字未输入", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_User_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!closeState)
            {
                MessageBox.Show("您还没输入名字\r\n请输入名字后，点击[确定]按钮", "名字未输入", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

    }
}
