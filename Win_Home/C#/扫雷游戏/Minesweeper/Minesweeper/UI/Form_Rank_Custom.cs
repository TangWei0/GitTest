using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Setting = Minesweeper.Properties.Settings; 


namespace Minesweeper.UI
{
    public partial class Form_Rank_Custom : Form
    {
        Form_Main Main;
        public bool update = false;

        public Form_Rank_Custom(Form_Main _Main)
        {
            InitializeComponent();
            Main = _Main;
            dataGridViewRead(Main.detail);
        }

        private void dataGridViewRead(RecordInfo[] detail)
        {
            for (int i = 0; i < Csv.recordMaxNum; i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    switch (j)
                    {
                        case 0:
                            dataGridView.Rows[i].Cells[j].Value = i + 1;
                            break;
                        case 1:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].user;
                            break;
                        case 2:
                            dataGridView.Rows[i].Cells[j].Value = Convert.ToString(Main.detail[i].efficiencyValue);
                            break;
                        case 3:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].mine;
                            break;
                        case 4:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].width;
                            break;
                        case 5:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].height;
                            break;
                        case 6:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].time;
                            break;
                        case 7:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].success;
                            break;
                        case 8:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].total;
                            break;
                        case 9:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].successRate.ToString("P");
                            break;
                        case 10:
                            dataGridView.Rows[i].Cells[j].Value = Main.detail[i].date;
                            break;
                        default:
                            break;
                    }
                }
            }
            dataGridView.Rows[Csv.recordMaxNum].Cells[1].Value = "目前排行榜只能选取前十的成绩";
        }
        
        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清空数据吗？", "清空数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                update = true;
                for (int i = 0; i < Csv.recordMaxNum; i++)
                {
                    Main.detail[i] = new RecordInfo();
                }
                this.Close();
            }
        }
    
    }  

}
