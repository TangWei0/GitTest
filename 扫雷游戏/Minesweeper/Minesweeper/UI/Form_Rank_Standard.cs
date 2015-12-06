using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using setting = Minesweeper.Properties.Settings;
namespace Minesweeper
{
    public partial class Form_Rank_Standard : Form
    {
        int beginner = setting.Default.Beginner;
        int intermediate = setting.Default.Intermediate;
        int expert = setting.Default.Expert;
        double total = setting.Default.TotalOrder;
        int success = setting.Default.SuccessOrder;
        

        public Form_Rank_Standard()
        {
            InitializeComponent();
        }

        private void Form_Rank_Load(object sender, EventArgs e)
        {            
            Label_Beginner.Text = String.Format("Beginner:          {0}", beginner);
            Label_Intermediate.Text = String.Format("Intermediate:     {0}", intermediate);
            Label_Expert.Text = String.Format("Expert:             {0}", expert);
            String rate = "";
            if (total == 0)
            {
                rate = "NA";
            }
            else
            {
                double dir = (double)success / (double)total;
                //double dir = Convert.ToDouble(success) / Convert.ToDouble(total);
                rate = String.Format("{0:N2}%", dir*100);
            }
            Label_Success.Text = ("Total Order: " + Convert.ToString(total) +"\nSuccess Order: " + Convert.ToString(success) +"\nSuccess Rate: " + rate);
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            setting.Default.Beginner = 999;
            setting.Default.Intermediate = 999;
            setting.Default.Expert = 999;
            setting.Default.Save();
            beginner = setting.Default.Beginner;
            intermediate = setting.Default.Intermediate;
            expert = setting.Default.Expert;
            Label_Beginner.Text = String.Format("Beginner:          {0}", beginner);
            Label_Intermediate.Text = String.Format("Intermediate:     {0}", intermediate);
            Label_Expert.Text = String.Format("Expert:             {0}", expert);
        }

    }
}
