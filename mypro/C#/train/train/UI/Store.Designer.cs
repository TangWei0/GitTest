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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CarDetailListBox = new System.Windows.Forms.ListBox();
            this.BuyCarButton = new System.Windows.Forms.Button();
            this.StoreListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CarDetailListBox
            // 
            this.CarDetailListBox.BackColor = System.Drawing.SystemColors.Window;
            this.CarDetailListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarDetailListBox.ForeColor = System.Drawing.Color.Black;
            this.CarDetailListBox.FormattingEnabled = true;
            this.CarDetailListBox.ItemHeight = 12;
            this.CarDetailListBox.Location = new System.Drawing.Point(225, 24);
            this.CarDetailListBox.Name = "CarDetailListBox";
            this.CarDetailListBox.Size = new System.Drawing.Size(207, 84);
            this.CarDetailListBox.TabIndex = 1;
            // 
            // BuyCarButton
            // 
            this.BuyCarButton.Location = new System.Drawing.Point(185, 142);
            this.BuyCarButton.Name = "BuyCarButton";
            this.BuyCarButton.Size = new System.Drawing.Size(75, 23);
            this.BuyCarButton.TabIndex = 2;
            this.BuyCarButton.Text = "购买";
            this.BuyCarButton.UseVisualStyleBackColor = true;
            this.BuyCarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // StoreListBox
            // 
            this.StoreListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StoreListBox.FormattingEnabled = true;
            this.StoreListBox.ItemHeight = 12;
            this.StoreListBox.Location = new System.Drawing.Point(12, 24);
            this.StoreListBox.Name = "StoreListBox";
            this.StoreListBox.Size = new System.Drawing.Size(207, 84);
            this.StoreListBox.TabIndex = 3;
            this.StoreListBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 186);
            this.Controls.Add(this.StoreListBox);
            this.Controls.Add(this.BuyCarButton);
            this.Controls.Add(this.CarDetailListBox);
            this.Name = "Store";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Store_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox CarDetailListBox;
        private System.Windows.Forms.Button BuyCarButton;
        public System.Windows.Forms.ListBox StoreListBox;
    }
}