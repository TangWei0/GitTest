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
    partial class Form_Setting : Form
    {
        Form_Main Main;

        public Form_Setting(Form_Main _Main)
        {
            InitializeComponent();

            Main = _Main;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Main.nWidth = Convert.ToInt32(NumericUpDown_Width.Value);
            Main.nHeight = Convert.ToInt32(NumericUpDown_Height.Value);
            Main.nMineCnt = Convert.ToInt32(NumericUpDown_Mine.Value);
            this.Close();
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            NumericUpDown_Width.Value = Convert.ToDecimal(Main.nWidth);
            NumericUpDown_Height.Value = Convert.ToDecimal(Main.nHeight);
            NumericUpDown_Mine.Value = Convert.ToDecimal(Main.nMineCnt);
        }
    }
}
