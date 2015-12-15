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

        public Form_Rank_Custom(Form_Main _Main)
        {
            InitializeComponent();
            Main = _Main;
            ReadCsv(Csv.fp);
        }

        public void Form_Rank_Custom_Load(object sender, EventArgs e)
        {

        }
        
        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清空数据吗？", "清空数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                for (int i = 0; i < Csv.recordMaxNum; i++)
                {
                    Main.detail[i] = new RecordInfo();
                }
                    this.Close();
            }
        }


        public void ReadCsv(String fp)
        {
            // CSVファイルオープン
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            // CSVファイルの各セルをDataGridViewに表示
            dataGridView.Rows.Clear();
            int r = 0;
            String lin = "";
            do
            {
                lin = sr.ReadLine();
                if (lin != null)
                {
                    dataGridView.Rows.Add();
                    String[] csv = lin.Split(',');
                    for (int c = 0; c <= csv.GetLength(0) - 1; c++)
                    {
                        if (c < dataGridView.Columns.Count)
                        {
                            dataGridView.Rows[r].Cells[c].Value = csv[c];
                        }
                    }
                    r += 1;
                }
                 else
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[r].Cells[0].Value = 0.0;
                    dataGridView.Rows[r].Cells[1].Value = 0;
                    dataGridView.Rows[r].Cells[2].Value = 0;
                    dataGridView.Rows[r].Cells[3].Value = 0;
                    dataGridView.Rows[r].Cells[4].Value = 0;
                    r += 1;
                }
            } while (r < Csv.recordMaxNum);
            // CSVファイルクローズ
            sr.Close();
        }

    }  

}
