namespace LoanManage.UI
{
    partial class PWChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentPWTextBox = new System.Windows.Forms.TextBox();
            this.NewPWTextBox = new System.Windows.Forms.TextBox();
            this.NewPwConfirmTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "現在パスワード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新しいパスワード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新しいパスワード確認";
            // 
            // CurrentPWTextBox
            // 
            this.CurrentPWTextBox.Location = new System.Drawing.Point(247, 35);
            this.CurrentPWTextBox.Name = "CurrentPWTextBox";
            this.CurrentPWTextBox.Size = new System.Drawing.Size(219, 19);
            this.CurrentPWTextBox.TabIndex = 3;
            this.CurrentPWTextBox.TextChanged += new System.EventHandler(this.CurrentPWTextBox_TextChanged);
            // 
            // NewPWTextBox
            // 
            this.NewPWTextBox.Location = new System.Drawing.Point(247, 93);
            this.NewPWTextBox.Name = "NewPWTextBox";
            this.NewPWTextBox.Size = new System.Drawing.Size(219, 19);
            this.NewPWTextBox.TabIndex = 4;
            this.NewPWTextBox.TextChanged += new System.EventHandler(this.NewPWTextBox_TextChanged);
            // 
            // NewPwConfirmTextBox
            // 
            this.NewPwConfirmTextBox.Location = new System.Drawing.Point(247, 153);
            this.NewPwConfirmTextBox.Name = "NewPwConfirmTextBox";
            this.NewPwConfirmTextBox.Size = new System.Drawing.Size(219, 19);
            this.NewPwConfirmTextBox.TabIndex = 5;
            this.NewPwConfirmTextBox.TextChanged += new System.EventHandler(this.NewPwConfirmTextBox_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(93, 232);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(162, 41);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "決定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(304, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(162, 41);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "クリア";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PWChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 312);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.NewPwConfirmTextBox);
            this.Controls.Add(this.NewPWTextBox);
            this.Controls.Add(this.CurrentPWTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "PWChange";
            this.Text = "PWChange";
            this.Load += new System.EventHandler(this.PWChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CurrentPWTextBox;
        private System.Windows.Forms.TextBox NewPWTextBox;
        private System.Windows.Forms.TextBox NewPwConfirmTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}