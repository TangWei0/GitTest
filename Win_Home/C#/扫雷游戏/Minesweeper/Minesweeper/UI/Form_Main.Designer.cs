﻿namespace Minesweeper.UI
{
    partial class Form_Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rankRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_Mine = new System.Windows.Forms.PictureBox();
            this.pictureBox_Time = new System.Windows.Forms.PictureBox();
            this.Label_Mine = new System.Windows.Forms.Label();
            this.Label_Time = new System.Windows.Forms.Label();
            this.Timer_Main = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip_Main.SuspendLayout();
            this.TableLayoutPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.helpHToolStripMenuItem});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Size = new System.Drawing.Size(595, 26);
            this.MenuStrip_Main.TabIndex = 0;
            this.MenuStrip_Main.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameNToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerBToolStripMenuItem,
            this.intermediateIToolStripMenuItem,
            this.expertEToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingSToolStripMenuItem,
            this.toolStripSeparator3,
            this.rankRToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitEToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.newGameToolStripMenuItem.Text = "Game(&G)";
            // 
            // newGameNToolStripMenuItem
            // 
            this.newGameNToolStripMenuItem.Name = "newGameNToolStripMenuItem";
            this.newGameNToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newGameNToolStripMenuItem.Text = "New Game(&N)";
            this.newGameNToolStripMenuItem.Click += new System.EventHandler(this.newGameNToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // beginnerBToolStripMenuItem
            // 
            this.beginnerBToolStripMenuItem.Name = "beginnerBToolStripMenuItem";
            this.beginnerBToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beginnerBToolStripMenuItem.Text = "Beginner(&B)";
            this.beginnerBToolStripMenuItem.Click += new System.EventHandler(this.beginnerBToolStripMenuItem_Click);
            // 
            // intermediateIToolStripMenuItem
            // 
            this.intermediateIToolStripMenuItem.Name = "intermediateIToolStripMenuItem";
            this.intermediateIToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.intermediateIToolStripMenuItem.Text = "Intermediate(&I)";
            this.intermediateIToolStripMenuItem.Click += new System.EventHandler(this.intermediateIToolStripMenuItem_Click);
            // 
            // expertEToolStripMenuItem
            // 
            this.expertEToolStripMenuItem.Name = "expertEToolStripMenuItem";
            this.expertEToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.expertEToolStripMenuItem.Text = "Expert(&E)";
            this.expertEToolStripMenuItem.Click += new System.EventHandler(this.expertEToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // settingSToolStripMenuItem
            // 
            this.settingSToolStripMenuItem.Name = "settingSToolStripMenuItem";
            this.settingSToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.settingSToolStripMenuItem.Text = "Setting(&S)";
            this.settingSToolStripMenuItem.Click += new System.EventHandler(this.settingSToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // rankRToolStripMenuItem
            // 
            this.rankRToolStripMenuItem.Name = "rankRToolStripMenuItem";
            this.rankRToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rankRToolStripMenuItem.Text = "Rank(&R)";
            this.rankRToolStripMenuItem.Click += new System.EventHandler(this.rankRToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // exitEToolStripMenuItem
            // 
            this.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem";
            this.exitEToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitEToolStripMenuItem.Text = "Exit(&E)";
            this.exitEToolStripMenuItem.Click += new System.EventHandler(this.exitEToolStripMenuItem_Click);
            // 
            // helpHToolStripMenuItem
            // 
            this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            this.helpHToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.helpHToolStripMenuItem.Text = "Help(&H)";
            // 
            // TableLayoutPanel_Main
            // 
            this.TableLayoutPanel_Main.ColumnCount = 9;
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.TableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.TableLayoutPanel_Main.Controls.Add(this.pictureBox_Mine, 1, 0);
            this.TableLayoutPanel_Main.Controls.Add(this.pictureBox_Time, 7, 0);
            this.TableLayoutPanel_Main.Controls.Add(this.Label_Mine, 3, 0);
            this.TableLayoutPanel_Main.Controls.Add(this.Label_Time, 5, 0);
            this.TableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableLayoutPanel_Main.Location = new System.Drawing.Point(0, 524);
            this.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main";
            this.TableLayoutPanel_Main.RowCount = 1;
            this.TableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Main.Size = new System.Drawing.Size(595, 48);
            this.TableLayoutPanel_Main.TabIndex = 1;
            // 
            // pictureBox_Mine
            // 
            this.pictureBox_Mine.BackgroundImage = global::Minesweeper.Properties.Resources.mine;
            this.pictureBox_Mine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Mine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Mine.Location = new System.Drawing.Point(35, 3);
            this.pictureBox_Mine.Name = "pictureBox_Mine";
            this.pictureBox_Mine.Size = new System.Drawing.Size(42, 42);
            this.pictureBox_Mine.TabIndex = 0;
            this.pictureBox_Mine.TabStop = false;
            // 
            // pictureBox_Time
            // 
            this.pictureBox_Time.BackgroundImage = global::Minesweeper.Properties.Resources.timer;
            this.pictureBox_Time.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Time.Location = new System.Drawing.Point(517, 3);
            this.pictureBox_Time.Name = "pictureBox_Time";
            this.pictureBox_Time.Size = new System.Drawing.Size(42, 42);
            this.pictureBox_Time.TabIndex = 1;
            this.pictureBox_Time.TabStop = false;
            // 
            // Label_Mine
            // 
            this.Label_Mine.AutoSize = true;
            this.Label_Mine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Mine.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Mine.ForeColor = System.Drawing.Color.DarkRed;
            this.Label_Mine.Location = new System.Drawing.Point(99, 0);
            this.Label_Mine.Name = "Label_Mine";
            this.Label_Mine.Size = new System.Drawing.Size(179, 48);
            this.Label_Mine.TabIndex = 2;
            this.Label_Mine.Text = "Label_Mine";
            this.Label_Mine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Time
            // 
            this.Label_Time.AutoSize = true;
            this.Label_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Time.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Time.Location = new System.Drawing.Point(316, 0);
            this.Label_Time.Name = "Label_Time";
            this.Label_Time.Size = new System.Drawing.Size(179, 48);
            this.Label_Time.TabIndex = 3;
            this.Label_Time.Text = "Label_Time";
            this.Label_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer_Main
            // 
            this.Timer_Main.Interval = 1000;
            this.Timer_Main.Tick += new System.EventHandler(this.Timer_Main_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 572);
            this.Controls.Add(this.TableLayoutPanel_Main);
            this.Controls.Add(this.MenuStrip_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip_Main;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "Minesweeper";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Main_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseUp);
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            this.TableLayoutPanel_Main.ResumeLayout(false);
            this.TableLayoutPanel_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel_Main;
        private System.Windows.Forms.PictureBox pictureBox_Mine;
        private System.Windows.Forms.PictureBox pictureBox_Time;
        private System.Windows.Forms.Label Label_Mine;
        private System.Windows.Forms.Label Label_Time;
        private System.Windows.Forms.Timer Timer_Main;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameNToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beginnerBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertEToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem settingSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem rankRToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
    }
}

