namespace LoanManage.UI
{
    partial class LoginError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginError));
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // returnButton
            // 
            this.returnButton.BackgroundImage = global::LoanManage.Properties.Resources.returnButton;
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.Location = new System.Drawing.Point(203, 154);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(164, 44);
            this.returnButton.TabIndex = 0;
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // LoginError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoanManage.Properties.Resources.loginError;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(396, 210);
            this.Controls.Add(this.returnButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginError";
            this.Text = "LoginError";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button returnButton;
    }
}