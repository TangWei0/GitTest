namespace LoanManage.UI
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.IDLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ManageRadioButton = new System.Windows.Forms.RadioButton();
            this.UsualRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // IDLabel
            // 
            this.IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.IDLabel.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IDLabel.Location = new System.Drawing.Point(82, 109);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(98, 19);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PasswordLabel.Location = new System.Drawing.Point(82, 155);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(98, 19);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(211, 109);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(180, 19);
            this.IDTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(211, 155);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(180, 19);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Transparent;
            this.LoginButton.Location = new System.Drawing.Point(211, 224);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "ログイン";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Location = new System.Drawing.Point(316, 224);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ManageRadioButton
            // 
            this.ManageRadioButton.AutoSize = true;
            this.ManageRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ManageRadioButton.Checked = true;
            this.ManageRadioButton.Location = new System.Drawing.Point(211, 194);
            this.ManageRadioButton.Name = "ManageRadioButton";
            this.ManageRadioButton.Size = new System.Drawing.Size(59, 16);
            this.ManageRadioButton.TabIndex = 6;
            this.ManageRadioButton.TabStop = true;
            this.ManageRadioButton.Text = "管理者";
            this.ManageRadioButton.UseVisualStyleBackColor = false;
            this.ManageRadioButton.CheckedChanged += new System.EventHandler(this.ManageRadioButton_CheckedChanged);
            // 
            // UsualRadioButton
            // 
            this.UsualRadioButton.AutoSize = true;
            this.UsualRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.UsualRadioButton.Location = new System.Drawing.Point(319, 194);
            this.UsualRadioButton.Name = "UsualRadioButton";
            this.UsualRadioButton.Size = new System.Drawing.Size(59, 16);
            this.UsualRadioButton.TabIndex = 7;
            this.UsualRadioButton.Text = "一般者";
            this.UsualRadioButton.UseVisualStyleBackColor = false;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoanManage.Properties.Resources.LoginScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(488, 283);
            this.Controls.Add(this.UsualRadioButton);
            this.Controls.Add(this.ManageRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.IDLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginScreen";
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton ManageRadioButton;
        private System.Windows.Forms.RadioButton UsualRadioButton;
    }
}