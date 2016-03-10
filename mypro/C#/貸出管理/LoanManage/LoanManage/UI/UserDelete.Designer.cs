namespace LoanManage.UI
{
    partial class UserDelete
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
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UserIDLabel.Location = new System.Drawing.Point(79, 53);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(53, 16);
            this.UserIDLabel.TabIndex = 0;
            this.UserIDLabel.Text = "UserID";
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UserIDTextBox.Location = new System.Drawing.Point(159, 50);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(155, 23);
            this.UserIDTextBox.TabIndex = 1;
            this.UserIDTextBox.TextChanged += new System.EventHandler(this.UserIDTextBox_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(82, 130);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(101, 34);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "決定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(213, 130);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(101, 34);
            this.cancleButton.TabIndex = 3;
            this.cancleButton.Text = "クリア";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // UserDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 226);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.UserIDTextBox);
            this.Controls.Add(this.UserIDLabel);
            this.MaximizeBox = false;
            this.Name = "UserDelete";
            this.Text = "UserDelete";
            this.Load += new System.EventHandler(this.UserDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button cancleButton;
    }
}