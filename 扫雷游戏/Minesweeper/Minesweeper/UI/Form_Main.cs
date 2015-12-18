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
        Csv csv = new Csv();
        Form_User user = new Form_User();

        public int message;
        public int nWidth;
        public int nHeight;
        public int nMineCnt;

        //雷区最大长和宽
        const int MAX_WIDTH = 52;
        const int MAX_HEIGHT = 52;

        int[,] mineInfo = new int[MAX_WIDTH, MAX_HEIGHT];
        int[,] mineState = new int[MAX_WIDTH, MAX_HEIGHT];

        const int XYOffsetNum = 8;
        int[] dx = new int[XYOffsetNum] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = new int[XYOffsetNum] { -1, 0, 1, -1, 1, -1, 0, 1 };

        Point MouseFocus;

        bool bMouseLeft;
        bool bMouseRight;


        string Date = System.DateTime.Now.ToString("D");
        public RecordInfo[] detail = new RecordInfo[Csv.recordMaxNum + 1];        

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

            
            csv.ReadCsv(detail);
            

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
                }
 
                if (bMouseLeft && bMouseRight)
                {            
                    if (mineInfo[MouseFocus.X, MouseFocus.Y] == -1)
                    {
                        MineView();
                        this.Refresh();
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
                        MineView();
                        this.Refresh();
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

        private void MineView()
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
        }

        private void GameLost()
        {
            if (MessageBox.Show("您踩着地雷了\r\n不要气馁，请留下你的大名，再战江湖", "结束", MessageBoxButtons.OK,MessageBoxIcon.Stop) == DialogResult.OK)
            {
                user.ShowDialog();
                int row = SearchName(detail,user.usename);
                if (row == Csv.recordMaxNum)
                {
                    message = 3;
                    GameDialog(message);
                }
                else
                {
                    detail[row].total++;
                    detail[row].date = Date;
                    csv.SaveRowsCsv(detail);
                    detail[row].successRate = (double)detail[row].success / (double)detail[row].total;
                    message = 4;
                    GameDialog(message);
                }            
            }
        }

        private void GameWin()
        {
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (mineInfo[i, j] == -1 && mineState[i, j] != 2)
                    {
                        return;
                    }
                }
            }

            Timer_Main.Enabled = false;
            int time = Convert.ToInt32(Label_Time.Text);
            MessageBox.Show(String.Format("游戏胜利！　时间：　{0}秒", Label_Time.Text), "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("您挑战成功，留下您的大名吧", "成功", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                user.ShowDialog();
                double efficiency = Math.Round(((double) nMineCnt/(double)(nWidth * nHeight * time)), 2, MidpointRounding.AwayFromZero);
                
                int nameRow = SearchName(detail,user.usename);
                int efficiencyRow = SearchEfficiency(detail,efficiency);
                if (nameRow == Csv.recordMaxNum && efficiencyRow == Csv.recordMaxNum)
                {
                    message = 3;
                    GameDialog(message);
                }

                else if (nameRow == Csv.recordMaxNum && efficiencyRow < Csv.recordMaxNum)
                {
                    for (int i= Csv.recordMaxNum-1 ; i>efficiencyRow ;i--)
                    {
                        detail[i] = detail[i-1];
                    }
                    detail[efficiencyRow].user = user.usename;
                    detail[efficiencyRow].efficiencyValue = efficiency;
                    detail[efficiencyRow].mine = nMineCnt;
                    detail[efficiencyRow].width = nWidth;
                    detail[efficiencyRow].height = nHeight;
                    detail[efficiencyRow].time = time;
                    detail[efficiencyRow].success = 1;
                    detail[efficiencyRow].total = 1;
                    detail[efficiencyRow].successRate = 1.0;
                    detail[efficiencyRow].date = Date;
                    csv.SaveRowsCsv(detail);

                    message = 2;
                    GameDialog(message);
                }

                else if (nameRow < Csv.recordMaxNum && efficiencyRow == Csv.recordMaxNum)
                {
                    detail[nameRow].success++;
                    detail[nameRow].total++;
                    detail[nameRow].date = Date;
                    csv.SaveRowsCsv(detail);
                    detail[nameRow].successRate = (double)detail[nameRow].success / (double)detail[nameRow].total;

                    message = 1;
                    GameDialog(message);
                }

                else
                {
                    detail[nameRow].efficiencyValue = efficiency;
                    detail[nameRow].width = nWidth;
                    detail[nameRow].height = nHeight;
                    detail[nameRow].time = time;
                    detail[nameRow].success++;
                    detail[nameRow].total++;
                    detail[nameRow].successRate =  (double)detail[nameRow].success / (double)detail[nameRow].total;
                    detail[nameRow].date = Date;
                    if (detail[nameRow].efficiencyValue == detail[efficiencyRow].efficiencyValue)
                    {
                        int successRateRow = SearchSuccessRate(detail, nameRow, efficiencyRow);
                        if (successRateRow < efficiencyRow)
                        {
                            detail[Csv.recordMaxNum] = detail[nameRow];
                            for (int i = nameRow; i > efficiencyRow; i--)
                            {
                                detail[i] = detail[i - 1];
                            }
                            detail[efficiencyRow] = detail[Csv.recordMaxNum];
                        }
                    }
                    else
                    {
                        detail[Csv.recordMaxNum] = detail[nameRow];
                        for (int i = nameRow; i > efficiencyRow; i++)
                        {
                            detail[i] = detail[i - 1];
                        }
                        detail[efficiencyRow] = detail[Csv.recordMaxNum];
                    }
                    csv.SaveRowsCsv(detail);
                    
                    message = 0;
                    GameDialog(message);

                    
                }
            }
        }

        private void rankRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Form_Rank_Custom rankCustom = new UI.Form_Rank_Custom(this);
            rankCustom.ShowDialog();
            if (rankCustom.update)
            {
                csv.SaveRowsCsv(detail);
            }
        }

        private int SearchEfficiency(RecordInfo[] detail, double val)
        {
            for (int i = 0; i < Csv.recordMaxNum; i++)
            {
                if (val >= detail[i].efficiencyValue)
                {
                    return i;
                }
            }
            return Csv.recordMaxNum;
        }

        private int SearchName(RecordInfo[] detail, string name)
        {
            for (int i = 0; i < Csv.recordMaxNum; i++)
            {
                if (name == detail[i].user || detail[i].user == null)
                {
                    return i;
                }
            }
            return Csv.recordMaxNum;
        }

        private int SearchSuccessRate(RecordInfo[] detail, int nameRow, int efficiencyRow)
        {
            do
            {
                if (detail[nameRow].successRate > detail[efficiencyRow].successRate)
                {
                    return efficiencyRow;
                }
                else
                {
                    efficiencyRow++;
                }
            } while (efficiencyRow >= nameRow);

            return nameRow;
        }

        private void GameDialog(int message)
        {
            string dialogMessage = "";
            string dialogTitle ="";
            switch (message)
            {
                case 0:
                    dialogMessage = "恭喜您已突破自己。\r\n点击[OK]乘热打铁再来一盘，让您的成绩百尺竿头更进一步！\r\n点击[Cancel]养精蓄锐重振雄风";
                    dialogTitle = "恭喜";
                    break;
                case 1:
                    dialogMessage = "很遗憾您未能突破自己。\r\n点击[OK]再来一盘，让您的成绩百尺竿头更进一步！\r\n点击[Cancel]养精蓄锐重振雄风";
                    dialogTitle = "";
                    break;
                case 2:
                    dialogMessage = "恭喜您已进入扫雷风云榜。\r\n点击[OK]再来一盘，让您的成绩百尺竿头更进一步！\r\n点击[Cancel]养精蓄锐重振雄风";
                    dialogTitle = "恭喜";
                    break;
                case 3:
                    dialogMessage = "很遗憾，江湖风云榜中还没有您的大名。\r\n点击[OK]再来一盘，让您的大名留名千史吧！\r\n点击[Cancel]养精蓄锐重振雄风";
                    dialogTitle = "很遗憾";
                    break;
                case 4:
                    dialogMessage = "很遗憾，江湖风云榜没有发生变化。\r\n点击[OK]再来一盘，让您的大名留名千史吧！\r\n点击[Cancel]养精蓄锐重振雄风";
                    dialogTitle = "很遗憾";
                    break;
                default:
                    break;
            }
            if (MessageBox.Show(dialogMessage, dialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                newGameNToolStripMenuItem_Click(new object(), new EventArgs());
            }
            else
            {
                Application.Exit();
            }

        }
    
    }
}
