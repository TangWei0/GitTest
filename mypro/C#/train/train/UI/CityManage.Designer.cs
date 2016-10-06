namespace train.UI
{
    partial class CityManage
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.ProvinceListBox = new System.Windows.Forms.ListBox();
            this.CityListBox = new System.Windows.Forms.ListBox();
            this.OpenCityOrCloseCityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(573, 370);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "回主菜单";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ProvinceListBox
            // 
            this.ProvinceListBox.FormattingEnabled = true;
            this.ProvinceListBox.ItemHeight = 12;
            this.ProvinceListBox.Location = new System.Drawing.Point(21, 46);
            this.ProvinceListBox.Name = "ProvinceListBox";
            this.ProvinceListBox.Size = new System.Drawing.Size(120, 88);
            this.ProvinceListBox.TabIndex = 1;
            this.ProvinceListBox.SelectedIndexChanged += new System.EventHandler(this.ProvinceListBox_SelectedIndexChanged);
            // 
            // CityListBox
            // 
            this.CityListBox.FormattingEnabled = true;
            this.CityListBox.ItemHeight = 12;
            this.CityListBox.Location = new System.Drawing.Point(177, 46);
            this.CityListBox.Name = "CityListBox";
            this.CityListBox.Size = new System.Drawing.Size(120, 88);
            this.CityListBox.TabIndex = 2;
            this.CityListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CityListBox_DrawItem);
            this.CityListBox.SelectedIndexChanged += new System.EventHandler(this.CityListBox_SelectedIndexChanged);
            // 
            // OpenCityOrCloseCityButton
            // 
            this.OpenCityOrCloseCityButton.Location = new System.Drawing.Point(177, 350);
            this.OpenCityOrCloseCityButton.Name = "OpenCityOrCloseCityButton";
            this.OpenCityOrCloseCityButton.Size = new System.Drawing.Size(75, 23);
            this.OpenCityOrCloseCityButton.TabIndex = 3;
            this.OpenCityOrCloseCityButton.Text = "开通城市";
            this.OpenCityOrCloseCityButton.UseVisualStyleBackColor = true;
            this.OpenCityOrCloseCityButton.Click += new System.EventHandler(this.OpenCityOrCloseCityButton_Click);
            // 
            // CityManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 423);
            this.Controls.Add(this.OpenCityOrCloseCityButton);
            this.Controls.Add(this.CityListBox);
            this.Controls.Add(this.ProvinceListBox);
            this.Controls.Add(this.ExitButton);
            this.Name = "CityManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CityManage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CityManage_FormClosing);
            this.Load += new System.EventHandler(this.CityManage_Load);
            this.SizeChanged += new System.EventHandler(this.CityManage_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ListBox ProvinceListBox;
        private System.Windows.Forms.ListBox CityListBox;
        private System.Windows.Forms.Button OpenCityOrCloseCityButton;
    }
}