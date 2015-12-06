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

namespace Minesweeper.UI
{
    
    public partial class Form_Rank_Custom : Form
    {
        
        public Form_Rank_Custom()
        {
            InitializeComponent();
        }

        private void Form_Rank_Custom_Load(object sender, EventArgs e)
        {

        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            load();
            for (int i = 0; i < LoadFileData.Count; i++)//ジェネリックの出力
            {
                foreach (string data in LoadFileData[i])
                {
                    textBox1.Text += data + " ";
                }
                textBox1.Text += "\n";
            }
        }

        List<List<string>> LoadFileData = new List<List<string>>();
        public List<List<string>> load()
        {

            string filepath = "./record.txt";
            try
            {
                using (StreamReader sr = new StreamReader(filepath, Encoding.GetEncoding("utf-8")))
                {
                    //sr.ReadLine(); 最初の一行分(表のヘッダ部分)を飛ばしたい場合
                    while (!sr.EndOfStream)
                    {
                        List<string> addData = new List<string>();
                        string line = sr.ReadLine();//一行ずつ読み込む
                        string[] splitData = line.Split(' ');
                        for (int i = 0; i < splitData.Length; i++)
                        {
                            addData.Add(splitData[i]);//追加用のList<string>の作成
                        }
                        addData.Add("\n");
                        LoadFileData.Add(addData);//List<List<string>>のList<string>部分の追加
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return LoadFileData;
        }


    }
}
