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
using Excel = Microsoft.Office.Interop.Excel;


namespace Minesweeper.UI
{
    public partial class Form_Rank_Custom : Form
    {
        Form_Main Main;
        private static string fp = "C:\\Users\\itou1\\Desktop\\OneDrive\\扫雷游戏\\Minesweeper\\Minesweeper\\data.csv";
        public Form_Rank_Custom(Form_Main _Main)
        {
            InitializeComponent();
            Main = _Main;
            ReadCsv(fp);
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
                for (int i = 0; i < 10; i++)
                {
                    dataGridView.Rows.RemoveAt(0);
                }
                SaveCsv(fp);
                this.Close();
            }
        }

        public void SaveCsv(String fp)
        {
            // CSVファイルオープン
            StreamWriter sw =
                new StreamWriter(fp, false,
                System.Text.Encoding.GetEncoding("SHIFT-JIS"));
            for (int r = 0; r < dataGridView.Rows.Count - 1; r++)
            {
                for (int c = 0; c <= dataGridView.Columns.Count - 1; c++)
                {
                    // DataGridViewのセルのデータ取得
                    String dt = "";
                    if (dataGridView.Rows[r].Cells[c].Value != null)
                    {
                        dt = dataGridView.Rows[r].Cells[c].Value.ToString();
                    }
                    if (c < dataGridView.Columns.Count - 1)
                    {
                        dt = dt + ",";
                    }
                    // CSVファイル書込
                    sw.Write(dt);
                }
                sw.Write("\r\n");
            }
            // CSVファイルクローズ
            sw.Close();
        }

        public void ReadCsv(String fp)
        {
            // CSVファイルオープン
            StreamReader sr =
                new StreamReader(fp,
                System.Text.Encoding.GetEncoding("SHIFT-JIS"));
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
            } while (lin != null);
            // CSVファイルクローズ
            sr.Close();
        }

    }  

}
