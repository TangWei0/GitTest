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
            this.UserManageUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserChangeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewUserNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserDeleteDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserDataGridView = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraduationYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraduationSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraduationMajor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuMToolStripMenuItem,
            this.UserManageUToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 26);
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
            // UserManageUToolStripMenuItem
            // 
            this.UserManageUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserChangeCToolStripMenuItem});
            this.UserManageUToolStripMenuItem.Name = "UserManageUToolStripMenuItem";
            this.UserManageUToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.UserManageUToolStripMenuItem.Text = "ユーザ管理(&U)";
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
            // UserDataGridView
            // 
            this.UserDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Sex,
            this.GraduationYear,
            this.GraduationSubject,
            this.GraduationMajor,
            this.Phone1,
            this.Phone2,
            this.Email1,
            this.Email2,
            this.Address});
            this.UserDataGridView.Location = new System.Drawing.Point(0, 29);
            this.UserDataGridView.Name = "UserDataGridView";
            this.UserDataGridView.RowTemplate.Height = 21;
            this.UserDataGridView.Size = new System.Drawing.Size(1300, 150);
            this.UserDataGridView.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Name.HeaderText = "姓名";
            this.Name.Name = "Name";
            this.Name.Width = 21;
            // 
            // Sex
            // 
            this.Sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Sex.HeaderText = "性別";
            this.Sex.Name = "Sex";
            this.Sex.Width = 21;
            // 
            // GraduationYear
            // 
            this.GraduationYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.GraduationYear.HeaderText = "卒業年度";
            this.GraduationYear.Name = "GraduationYear";
            this.GraduationYear.Width = 21;
            // 
            // GraduationSubject
            // 
            this.GraduationSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.GraduationSubject.HeaderText = "大学学科";
            this.GraduationSubject.Name = "GraduationSubject";
            this.GraduationSubject.Width = 21;
            // 
            // GraduationMajor
            // 
            this.GraduationMajor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.GraduationMajor.HeaderText = "大学院専攻";
            this.GraduationMajor.Name = "GraduationMajor";
            this.GraduationMajor.Width = 21;
            // 
            // Phone1
            // 
            this.Phone1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Phone1.HeaderText = "電話番号1";
            this.Phone1.Name = "Phone1";
            this.Phone1.Width = 21;
            // 
            // Phone2
            // 
            this.Phone2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Phone2.HeaderText = "電話番号2";
            this.Phone2.Name = "Phone2";
            this.Phone2.Width = 21;
            // 
            // Email1
            // 
            this.Email1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Email1.HeaderText = "Eメール1";
            this.Email1.Name = "Email1";
            this.Email1.Width = 21;
            // 
            // Email2
            // 
            this.Email2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Email2.HeaderText = "Eメール2";
            this.Email2.Name = "Email2";
            this.Email2.Width = 21;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Address.HeaderText = "住所";
            this.Address.Name = "Address";
            this.Address.Width = 21;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.UserDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserManageUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasswordChangeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ExitEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserChangeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewUserNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserDeleteDToolStripMenuItem;
        private System.Windows.Forms.DataGridView UserDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraduationYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraduationSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraduationMajor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}