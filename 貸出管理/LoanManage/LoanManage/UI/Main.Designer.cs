namespace LoanManage.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainMenuMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasswordChangeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ユーザ管理UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserChangeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewUserNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserDeleteDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuMToolStripMenuItem,
            this.ユーザ管理UToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenuMToolStripMenuItem
            // 
            this.MainMenuMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PasswordChangeCToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ExitEToolStripMenuItem});
            this.MainMenuMToolStripMenuItem.Name = "MainMenuMToolStripMenuItem";
            this.MainMenuMToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.MainMenuMToolStripMenuItem.Text = "メインメーニュ(&M)";
            // 
            // PasswordChangeCToolStripMenuItem
            // 
            this.PasswordChangeCToolStripMenuItem.Name = "PasswordChangeCToolStripMenuItem";
            this.PasswordChangeCToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.PasswordChangeCToolStripMenuItem.Text = "パスワード変更(&C)";
            this.PasswordChangeCToolStripMenuItem.Click += new System.EventHandler(this.PasswordChangeCToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // ExitEToolStripMenuItem
            // 
            this.ExitEToolStripMenuItem.Name = "ExitEToolStripMenuItem";
            this.ExitEToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ExitEToolStripMenuItem.Text = "終了(&E)";
            this.ExitEToolStripMenuItem.Click += new System.EventHandler(this.ExitEToolStripMenuItem_Click);
            // 
            // ユーザ管理UToolStripMenuItem
            // 
            this.ユーザ管理UToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserChangeCToolStripMenuItem});
            this.ユーザ管理UToolStripMenuItem.Name = "ユーザ管理UToolStripMenuItem";
            this.ユーザ管理UToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ユーザ管理UToolStripMenuItem.Text = "ユーザ管理(&U)";
            // 
            // UserChangeCToolStripMenuItem
            // 
            this.UserChangeCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewUserNToolStripMenuItem,
            this.UserEditToolStripMenuItem,
            this.UserDeleteDToolStripMenuItem});
            this.UserChangeCToolStripMenuItem.Name = "UserChangeCToolStripMenuItem";
            this.UserChangeCToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.UserChangeCToolStripMenuItem.Text = "ユーザ変更(&C)";
            // 
            // NewUserNToolStripMenuItem
            // 
            this.NewUserNToolStripMenuItem.Name = "NewUserNToolStripMenuItem";
            this.NewUserNToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.NewUserNToolStripMenuItem.Text = "ユーザ新規(&N)";
            this.NewUserNToolStripMenuItem.Click += new System.EventHandler(this.NewUserNToolStripMenuItem_Click);
            // 
            // UserEditToolStripMenuItem
            // 
            this.UserEditToolStripMenuItem.Name = "UserEditToolStripMenuItem";
            this.UserEditToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.UserEditToolStripMenuItem.Text = "ユーザ変更(&C)";
            this.UserEditToolStripMenuItem.Click += new System.EventHandler(this.UserEditToolStripMenuItem_Click);
            // 
            // UserDeleteDToolStripMenuItem
            // 
            this.UserDeleteDToolStripMenuItem.Name = "UserDeleteDToolStripMenuItem";
            this.UserDeleteDToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.UserDeleteDToolStripMenuItem.Text = "ユーザ削除(&D)";
            this.UserDeleteDToolStripMenuItem.Click += new System.EventHandler(this.UserDeleteDToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 600);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ユーザ管理UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasswordChangeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ExitEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserChangeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewUserNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserDeleteDToolStripMenuItem;
    }
}