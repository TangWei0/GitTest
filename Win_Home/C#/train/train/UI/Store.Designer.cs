namespace train
{
    partial class Store
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
            this.components = new System.ComponentModel.Container();
            this.StoreUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.CarDetailListBox = new System.Windows.Forms.ListBox();
            this.BuyCarButton = new System.Windows.Forms.Button();
            this.StoreListBox = new System.Windows.Forms.ListBox();
            this.StoreLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StoreUpdateTimer
            // 
            this.StoreUpdateTimer.Tick += new System.EventHandler(this.StoreUpdateTimer_Tick);
            // 
            // CarDetailListBox
            // 
            this.CarDetailListBox.BackColor = System.Drawing.SystemColors.Window;
            this.CarDetailListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarDetailListBox.ForeColor = System.Drawing.Color.Black;
            this.CarDetailListBox.FormattingEnabled = true;
            this.CarDetailListBox.ItemHeight = 12;
            this.CarDetailListBox.Location = new System.Drawing.Point(225, 45);
            this.CarDetailListBox.Name = "CarDetailListBox";
            this.CarDetailListBox.Size = new System.Drawing.Size(207, 84);
            this.CarDetailListBox.TabIndex = 1;
            // 
            // BuyCarButton
            // 
            this.BuyCarButton.Location = new System.Drawing.Point(185, 150);
            this.BuyCarButton.Name = "BuyCarButton";
            this.BuyCarButton.Size = new System.Drawing.Size(75, 23);
            this.BuyCarButton.TabIndex = 2;
            this.BuyCarButton.Text = "购买";
            this.BuyCarButton.UseVisualStyleBackColor = true;
            this.BuyCarButton.Click += new System.EventHandler(this.BuyCarButton_Click);
            // 
            // StoreListBox
            // 
            this.StoreListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StoreListBox.FormattingEnabled = true;
            this.StoreListBox.ItemHeight = 12;
            this.StoreListBox.Location = new System.Drawing.Point(12, 45);
            this.StoreListBox.Name = "StoreListBox";
            this.StoreListBox.Size = new System.Drawing.Size(207, 84);
            this.StoreListBox.TabIndex = 3;
            this.StoreListBox.SelectedValueChanged += new System.EventHandler(this.StoreListBox_SelectedValueChanged);
            // 
            // StoreLabel
            // 
            this.StoreLabel.AutoSize = true;
            this.StoreLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StoreLabel.Location = new System.Drawing.Point(201, 18);
            this.StoreLabel.Name = "StoreLabel";
            this.StoreLabel.Size = new System.Drawing.Size(29, 12);
            this.StoreLabel.TabIndex = 4;
            this.StoreLabel.Text = "商城";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(363, 179);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "回主菜单";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 209);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StoreLabel);
            this.Controls.Add(this.StoreListBox);
            this.Controls.Add(this.BuyCarButton);
            this.Controls.Add(this.CarDetailListBox);
            this.Name = "Store";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Store_FormClosing);
            this.Load += new System.EventHandler(this.Store_Load);
            this.SizeChanged += new System.EventHandler(this.Store_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer StoreUpdateTimer;
        private System.Windows.Forms.ListBox CarDetailListBox;
        private System.Windows.Forms.Button BuyCarButton;
        public System.Windows.Forms.ListBox StoreListBox;
        private System.Windows.Forms.Label StoreLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}