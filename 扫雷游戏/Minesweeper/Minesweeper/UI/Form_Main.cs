using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using setting = Minesweeper.Properties.Settings;
using resources = Minesweeper.Properties.Resources;
using System.IO;

namespace Minesweeper.UI
{
    public partial class Form_Main : Form
    {
        public int nWidth;
        public int nHeight;
        public int nMineCnt;

        //雷区最大长和宽
        const int MAX_WIDTH = 32;
        const int MAX_HEIGHT = 18;

        int[,] mineInfo = new int[MAX_WIDTH, MAX_HEIGHT];
        int[,] mineState = new int[MAX_WIDTH, MAX_HEIGHT];

        const int XYOffsetNum = 8;
        int[] dx = new int[XYOffsetNum] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = new int[XYOffsetNum] { -1, 0, 1, -1, 1, -1, 0, 1 };

        Point MouseFocus;

        bool bMouseLeft;
        bool bMouseRight;

        public RecordInfo[] detail = new RecordInfo[10]
        {
            new RecordInfo{width = 10, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 11, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 12, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 13, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 14, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 15, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 16, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 17, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 18, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
            new RecordInfo{width = 19, height = 15, mine = 10, time = 100 , efficiencyValue = 19.2},
        };

        int[,] customRecord = new int[11, 4];
        double[] customRate = new double[11];

        public Form_Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            nWidth = setting.Default.width;
            nHeight = setting.Default.height;
            nMineCnt = setting.Default.minecnt;

            MouseFocus.X = 0;
            MouseFocus.Y = 0;
            UpdateSize();
            SelectLevel();
        }

        private void SetGame(int width, int height, int minecnt)
        {
            nWidth = width;
            nHeight = height;
            nMineCnt = minecnt;
            UpdateSize();
        }

        private void SetGameBeginner()
        {
            nWidth = 10;
            nHeight = 10;
            nMineCnt = 10;
            SetGame(nWidth, nHeight, nMineCnt);
        }

        private void SetGameIntermediate()
        {
            nWidth = 16;
            nHeight = 16;
            nMineCnt = 40;
            SetGame(nWidth, nHeight, nMineCnt);
        }

        private void SetGameExpert()
        {
            nWidth = 30;
            nHeight = 16;
            nMineCnt = 99;
            SetGame(nWidth, nHeight, nMineCnt);
        }

        private void Form_Main_Paint(object sender, PaintEventArgs e)
        {
            PaintGame(e.Graphics);
        }

        private void PaintGame(Graphics graph)
        {
            graph.Clear(Color.White);
            int offsetX = 6;
            int offsetY = 6 + MainMenuStrip.Height;
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (mineState[i, j] != 1)
                    {
                        if (i == MouseFocus.X && j == MouseFocus.Y)
                        {
                            graph.FillRectangle(Brushes.LightPink, new Rectangle(offsetX + 34 * (i - 1), offsetY + 34 * (j - 1), 32, 32));
                        }
                        else
                        {
                            graph.FillRectangle(Brushes.Orange, new Rectangle(offsetX + 34 * (i - 1), offsetY + 34 * (j - 1), 32, 32));
                        }

                        if (mineState[i, j] == 2)
                        {
                            graph.DrawImage(resources.flag, offsetX + 34 * (i - 1) + 4, offsetY + 34 * (j - 1) + 4);
                        }
                        if (mineState[i, j] == 3)
                        {
                            graph.DrawImage(resources.doubt, offsetX + 34 * (i - 1) + 4, offsetY + 34 * (j - 1) + 4);
                        }
                    }

                    if (mineState[i, j] == 1)
                    {
                        if (mineInfo[i, j] != -1)
                        {
                            if (i == MouseFocus.X && j == MouseFocus.Y)
                            {
                                graph.FillRectangle(Brushes.LightPink, new Rectangle(offsetX + 34 * (i - 1), offsetY + 34 * (j - 1), 32, 32));
                            }
                            else
                            {
                                graph.FillRectangle(Brushes.Orange, new Rectangle(offsetX + 34 * (i - 1), offsetY + 34 * (j - 1), 32, 32));
                            }

                            if (mineInfo[i, j] == 0)
                            {
                                graph.FillRectangle(Brushes.Gray, new Rectangle(offsetX + 34 * (i - 1), offsetY + 34 * (j - 1), 32, 32));
                            }
                            if (mineInfo[i, j] != 0)
                            {
                                Brush DrawBrush = new SolidBrush(Color.White);
                                switch (mineInfo[i, j])
                                {
                                    case 1:
                                        DrawBrush = new SolidBrush(Color.Blue);
                                        break;
                                    case 2:
                                        DrawBrush = new SolidBrush(Color.Green);
                                        break;
                                    case 3:
                                        DrawBrush = new SolidBrush(Color.Red);
                                        break;
                                    case 4:
                                        DrawBrush = new SolidBrush(Color.DarkBlue);
                                        break;
                                    case 5:
                                        DrawBrush = new SolidBrush(Color.DarkRed);
                                        break;
                                    case 6:
                                        DrawBrush = new SolidBrush(Color.DarkSeaGreen);
                                        break;
                                    case 7:
                                        DrawBrush = new SolidBrush(Color.Black);
                                        break;
                                    case 8:
                                        DrawBrush = new SolidBrush(Color.DarkGray);
                                        break;
                                    default:
                                        break;
                                }
                                SizeF Size = graph.MeasureString(mineInfo[i, j].ToString(), new Font("Consolas", 16));
                                float px = 6 + 34 * (i - 1) + (32 - Size.Width) / 2;
                                float py = 6 + MainMenuStrip.Height + 34 * (j - 1) + (32 - Size.Height) / 2;
                                string p = mineInfo[i, j].ToString();
                                graph.DrawString(p, new Font("Consolas", 16), DrawBrush, px, py);
                            }
                        }
                        else
                        {
                            graph.DrawImage(resources.mine1, offsetX + 34 * (i - 1), offsetY + 34 * (j - 1));
                        }
                    }

                }
            }            
        }

        private void UpdateSize()
        {
            int borderWidth = this.Width - this.ClientSize.Width;
            int borderHeight = this.Height - this.ClientSize.Height;
            int additionFunc = MainMenuStrip.Height + TableLayoutPanel_Main.Height;
            this.Width = 12 + 34 * nWidth + borderWidth;
            this.Height = 12 + 34 * nHeight + borderHeight + additionFunc;
            newGameNToolStripMenuItem_Click(new object(),new EventArgs());
        }

        private void SelectLevel()
        {
            if (nWidth == 10 && nHeight == 10 && nMineCnt == 10)
            {
                beginnerBToolStripMenuItem.Checked = true;
                intermediateIToolStripMenuItem.Checked = false;
                expertEToolStripMenuItem.Checked = false;
                settingSToolStripMenuItem.Checked = false;
            }
            else if (nWidth == 16 && nHeight == 16 && nMineCnt == 40)
            {
                beginnerBToolStripMenuItem.Checked = false;
                intermediateIToolStripMenuItem.Checked = true;
                expertEToolStripMenuItem.Checked = false;
                settingSToolStripMenuItem.Checked = false;
            }
            else if (nWidth == 30 && nHeight == 16 && nMineCnt == 99)
            {
                beginnerBToolStripMenuItem.Checked = false;
                intermediateIToolStripMenuItem.Checked = false;
                expertEToolStripMenuItem.Checked = true;
                settingSToolStripMenuItem.Checked = false;
            }
            else 
            {
                beginnerBToolStripMenuItem.Checked = false;
                intermediateIToolStripMenuItem.Checked = false;
                expertEToolStripMenuItem.Checked = false;
                settingSToolStripMenuItem.Checked = true;
            }
        }

        private void beginnerBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGameBeginner();
            SelectLevel();
        }

        private void intermediateIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGameIntermediate();
            SelectLevel();
        }

        private void expertEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGameExpert();
            SelectLevel();
        }

        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("结束游戏吗？", "结束游戏", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void aboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShellAbout(this.Handle, "Minesweeper", "A minesweeper game using CSharp language.", this.Icon.Handle);
        }

        private void settingSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Form_Setting setting = new UI.Form_Setting(this);
            setting.ShowDialog();
            UpdateSize();
        }

        private void newGameNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(mineInfo, 0, mineInfo.Length);
            Array.Clear(mineState, 0, mineState.Length);

            Random Rand = new Random();
            int cnt = 1;
            do
            {
                int x = Rand.Next(nWidth) + 1;
                int y = Rand.Next(nHeight) + 1;
                if (mineInfo[x, y] != -1)
                {
                    mineInfo[x, y] = -1;
                    cnt++;
                }

            } while (cnt <= nMineCnt);


            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (mineInfo[i, j] != -1)
                    {
                        for (int k = 0; k < XYOffsetNum; k++)
                        {
                            if (mineInfo[i + dx[k], j + dy[k]] == -1)
                            {
                                mineInfo[i, j]++;
                            }
                        }
                    }
                }
            }

            Label_Mine.Text = nMineCnt.ToString();
            Label_Time.Text = "0";
            Timer_Main.Enabled = false;
        }

        private void Form_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 6 || e.Y < 6 + MainMenuStrip.Height || e.X > 6 + 34 * nWidth || e.Y > 6 + 34 * nHeight + MainMenuStrip.Height)
            {
                MouseFocus.X = 0;
                MouseFocus.Y = 0;
                this.Refresh();
            }
            else
            {
                int x = (e.X - 6) / 34 + 1;
                int y = (e.Y - 6 - MainMenuStrip.Height) / 34 + 1;
                MouseFocus.X = x;
                MouseFocus.Y = y;
                this.Refresh();
            }
        }

        private void Timer_Main_Tick(object sender, EventArgs e)
        {
            Label_Time.Text = Convert.ToString(Convert.ToInt32(Label_Time.Text) + 1);
        }

        private void Form_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bMouseLeft = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                bMouseRight = true;
            }
        }

        private void Form_Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseFocus.X == 0 && MouseFocus.Y == 0)
            {
                return;
            }

            else
            {
                if (Timer_Main.Enabled == false)
                {
                    Timer_Main.Enabled = true;
                    setting.Default.TotalOrder++;
                    setting.Default.Save();
                }
 
                if (bMouseLeft && bMouseRight)
                {            
                    if (mineInfo[MouseFocus.X, MouseFocus.Y] == -1)
                    {
                        GameLost();
                    }
                    if (mineInfo[MouseFocus.X, MouseFocus.Y] > 0)
                    {
                        if (mineState[MouseFocus.X, MouseFocus.Y] == 1)
                        {
                            doubleClick(MouseFocus.X, MouseFocus.Y);
                        }
                    }

                }
                else if (bMouseLeft)
                {
                    if (mineInfo[MouseFocus.X, MouseFocus.Y] != -1)
                    {
                        if (mineState[MouseFocus.X, MouseFocus.Y] == 0)
                        {
                            dfs(MouseFocus.X, MouseFocus.Y);
                        }
                    }
                    else
                    {
                        GameLost();
                    }
                }
                else if (bMouseRight)
                {
                    if (mineState[MouseFocus.X, MouseFocus.Y] == 0)
                    {
                        mineState[MouseFocus.X, MouseFocus.Y] = 2;
                        Label_Mine.Text = Convert.ToString(Convert.ToInt32(Label_Mine.Text) - 1);
                    }
                    else if (mineState[MouseFocus.X, MouseFocus.Y] == 2)
                    {
                        mineState[MouseFocus.X, MouseFocus.Y] = 3;
                        Label_Mine.Text = Convert.ToString(Convert.ToInt32(Label_Mine.Text) + 1);
                    }
                    else if (mineState[MouseFocus.X, MouseFocus.Y] == 3)
                    {
                        mineState[MouseFocus.X, MouseFocus.Y] = 0;
                    }
                }            
            }
            this.Refresh();
            if (Convert.ToInt32(Label_Mine.Text) == 0)
            {
                GameWin();
            }
            bMouseLeft = bMouseRight = false;
        }

        private void dfs(int x, int y)
        {
            mineState[x, y] = 1;
            if (mineInfo[x, y] == 0)
            {
                for (int i = 0; i < XYOffsetNum; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if (px  >= 1 && px <= nWidth && py >= 1 && py <= nHeight && (mineState[px, py] == 0))
                    {
                        dfs(px, py);
                    }
                }
            }

        }

        private void doubleClick(int x, int y)
        {
            int nFlagCnt = 0;
            int nDoubtCnt = 0;
            int nMineCnt = mineInfo[x, y];
            int px, py;
            for (int i = 0; i < XYOffsetNum; i++)
            {
                px = py = 0;
                px = x + dx[i];
                py = y + dy[i];
                if (px > 0 && px <= nWidth && py > 0 && py <= nHeight)
                {
                    if (mineState[x + dx[i], y + dy[i]] == 2)
                    {
                        nFlagCnt++;
                    }
                    if (mineState[x + dx[i], y + dy[i]] == 3)
                    {
                        nDoubtCnt++;
                    }
                }
            }
            if (nFlagCnt == nMineCnt || nFlagCnt + nDoubtCnt == nMineCnt)
            {
                for (int i = 0; i < XYOffsetNum; i++)
                {
                    px = py = 0;
                    px = x + dx[i];
                    py = y + dy[i];
                    if (px > 0 && px <= nWidth && py > 0 && py <= nHeight)
                    {
                        if (mineState[px, py] == 0)
                        {
                            if (mineInfo[px, py] == -1)
                            {
                                GameLost();
                            }
                            else
                            {
                                dfs(px, py);
                            }
                        }
                    }
                }
            }
        }

        private void GameLost()
        {
            Timer_Main.Enabled = false;
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (mineState[i, j] != 1 && mineInfo[i, j] == -1)
                    {
                        mineState[i, j] = 1;
                    }
                }
            }
            if (MessageBox.Show("您踩着地雷了", "结束", MessageBoxButtons.RetryCancel,MessageBoxIcon.Stop) == DialogResult.Retry)
            {
                newGameNToolStripMenuItem_Click(new object(), new EventArgs());
            }
            else
            {
                Application.Exit();
            }
        }

        private void GameWin()
        {
            bool check = true;
            int nCnt = 0;
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (mineInfo[i, j] == -1 && mineState[i, j] == 2)
                    {
                        nCnt++;
                    }
                    if (mineInfo[i, j] != -1 && mineState[i, j] != 1)
                    {
                        check = false;
                        break;
                    }
                }
                if (!check)
                {
                    return;
                }
            }
            if (nCnt == nMineCnt && check)
            {
                Timer_Main.Enabled = false;
                MessageBox.Show(String.Format("游戏胜利！　时间：　{0}秒", Label_Time.Text), "恭喜", MessageBoxButtons.OK,MessageBoxIcon.Information);
                setting.Default.SuccessOrder++;
                setting.Default.Save();

                int time = Convert.ToInt32(Label_Time.Text);
                if (nWidth == 10 && nHeight == 10 && nMineCnt == 10)
                {
                    if (time < setting.Default.Beginner)
                    {
                        setting.Default.Beginner = time;
                        setting.Default.Save();
                        StandardToolStripMenuItem_Click(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("很遗憾，没能破记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (nWidth == 16 && nHeight == 16 && nMineCnt == 40)
                {
                    if (time < setting.Default.Intermediate)
                    {
                        setting.Default.Intermediate = time;
                        setting.Default.Save();
                        StandardToolStripMenuItem_Click(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("很遗憾，没能破记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (nWidth == 30 && nHeight == 16 && nMineCnt == 99)
                {
                    if (time < setting.Default.Expert)
                    {
                        setting.Default.Expert = time;
                        setting.Default.Save();
                        StandardToolStripMenuItem_Click(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("很遗憾，没能破记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    customRate[0] = (double)nMineCnt/ (double)(nWidth*nHeight*Convert.ToInt32(Label_Time.Text));
                    if (customRate[0] > customRate[10])
                    {
                        CustomToolStripMenuItem_Click(new object(), new EventArgs());
                    }
                    
                }

                if (MessageBox.Show("再来一盘？", "驰骋沙场", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Retry)
                {
                    newGameNToolStripMenuItem_Click(new object(), new EventArgs());
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void StandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Form_Rank_Standard rankStandard = new UI.Form_Rank_Standard();
            rankStandard.ShowDialog();
        }

        private void ClearHistorytoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清除历史记录吗？", "清除历史记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                setting.Default.TotalOrder = 0;
                setting.Default.SuccessOrder = 0;
                setting.Default.Save();
            }
        }

        private void CustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Form_Rank_Custom rankCustom = new UI.Form_Rank_Custom(this);
            rankCustom.ShowDialog();
        }

    }
}
