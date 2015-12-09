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
        public Form_Rank_Custom(Form_Main _Main)
        {
            InitializeComponent();
            Main = _Main;
            for (int i = 0; i < 10; i++)
            {
                dataGridView.Rows.Add(Convert.ToString(Main.detail[i].efficiencyValue),
                                      Convert.ToString(Main.detail[i].mine),
                                      Convert.ToString(Main.detail[i].width),
                                      Convert.ToString(Main.detail[i].height),
                                      Convert.ToString(Main.detail[i].time));
            }

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
            print(dataGridView);
            if (MessageBox.Show("清空数据吗？", "清空数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                for (int i = 0; i < 10; i++)
                {
                    Main.detail[i].width = 0;
                    Main.detail[i].height = 0;
                    Main.detail[i].mine = 0;
                    Main.detail[i].time = 0;
                    Main.detail[i].efficiencyValue = 0.0;
                }
                this.Close();
            }
        }
        public void print(DataGridView dataGridView1)
        {
            //导出到execl  
            try
            {
                //没有数据的话就不往下执行  
                if (dataGridView1.Rows.Count == 0)
                    return;
                //实例化一个Excel.Application对象
                Excel.Application excel = new Excel.Application();

                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
                excel.Visible = false;

                //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
                excel.Application.Workbooks.Add(true);
                //生成Excel中列头名称  
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                //把DataGridView当前页的数据保存在Excel中  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1[j, i].ValueType == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                        }
                    }
                }

                //设置禁止弹出保存和覆盖的询问提示框  
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;

                //保存工作簿  
                excel.Application.Workbooks.Add(true).Save();
                //保存excel文件  
                excel.Save("..\\data.xls");

                //确保Excel进程关闭  
                excel.Quit();
                excel = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }
    }  

}
