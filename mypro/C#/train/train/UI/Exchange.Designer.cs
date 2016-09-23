namespace train.UI
{
    partial class Exchange
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
            this.CashLabel = new System.Windows.Forms.Label();
            this.CoinLabel = new System.Windows.Forms.Label();
            this.CashValueLabel = new System.Windows.Forms.Label();
            this.CoinValueLabel = new System.Windows.Forms.Label();
            this.ExchangeTrackBar = new System.Windows.Forms.TrackBar();
            this.ExchangeCoinLabel = new System.Windows.Forms.Label();
            this.ExchangeCoinMinLabel = new System.Windows.Forms.Label();
            this.ExchangeCoinMaxLabel = new System.Windows.Forms.Label();
            this.ExchangeCoinTextBox = new System.Windows.Forms.TextBox();
            this.ExchangeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CashLabel
            // 
            this.CashLabel.AutoSize = true;
            this.CashLabel.Location = new System.Drawing.Point(39, 38);
            this.CashLabel.Name = "CashLabel";
            this.CashLabel.Size = new System.Drawing.Size(77, 12);
            this.CashLabel.TabIndex = 0;
            this.CashLabel.Text = "现持有的现金";
            // 
            // CoinLabel
            // 
            this.CoinLabel.AutoSize = true;
            this.CoinLabel.Location = new System.Drawing.Point(39, 92);
            this.CoinLabel.Name = "CoinLabel";
            this.CoinLabel.Size = new System.Drawing.Size(77, 12);
            this.CoinLabel.TabIndex = 1;
            this.CoinLabel.Text = "现持有的点券";
            // 
            // CashValueLabel
            // 
            this.CashValueLabel.AutoSize = true;
            this.CashValueLabel.Location = new System.Drawing.Point(163, 38);
            this.CashValueLabel.Name = "CashValueLabel";
            this.CashValueLabel.Size = new System.Drawing.Size(60, 12);
            this.CashValueLabel.TabIndex = 2;
            this.CashValueLabel.Text = "CashValue";
            // 
            // CoinValueLabel
            // 
            this.CoinValueLabel.AutoSize = true;
            this.CoinValueLabel.Location = new System.Drawing.Point(163, 92);
            this.CoinValueLabel.Name = "CoinValueLabel";
            this.CoinValueLabel.Size = new System.Drawing.Size(57, 12);
            this.CoinValueLabel.TabIndex = 3;
            this.CoinValueLabel.Text = "CoinValue";
            // 
            // ExchangeTrackBar
            // 
            this.ExchangeTrackBar.Location = new System.Drawing.Point(41, 192);
            this.ExchangeTrackBar.Maximum = 100;
            this.ExchangeTrackBar.Name = "ExchangeTrackBar";
            this.ExchangeTrackBar.Size = new System.Drawing.Size(459, 45);
            this.ExchangeTrackBar.TabIndex = 4;
            this.ExchangeTrackBar.TickFrequency = 5;
            this.ExchangeTrackBar.ValueChanged += new System.EventHandler(this.ExchangeTrackBar_ValueChanged);
            // 
            // ExchangeCoinLabel
            // 
            this.ExchangeCoinLabel.AutoSize = true;
            this.ExchangeCoinLabel.Location = new System.Drawing.Point(39, 151);
            this.ExchangeCoinLabel.Name = "ExchangeCoinLabel";
            this.ExchangeCoinLabel.Size = new System.Drawing.Size(89, 12);
            this.ExchangeCoinLabel.TabIndex = 5;
            this.ExchangeCoinLabel.Text = "需兑换点券数量";
            // 
            // ExchangeCoinMinLabel
            // 
            this.ExchangeCoinMinLabel.AutoSize = true;
            this.ExchangeCoinMinLabel.Location = new System.Drawing.Point(49, 225);
            this.ExchangeCoinMinLabel.Name = "ExchangeCoinMinLabel";
            this.ExchangeCoinMinLabel.Size = new System.Drawing.Size(11, 12);
            this.ExchangeCoinMinLabel.TabIndex = 6;
            this.ExchangeCoinMinLabel.Text = "0";
            // 
            // ExchangeCoinMaxLabel
            // 
            this.ExchangeCoinMaxLabel.AutoSize = true;
            this.ExchangeCoinMaxLabel.Location = new System.Drawing.Point(481, 225);
            this.ExchangeCoinMaxLabel.Name = "ExchangeCoinMaxLabel";
            this.ExchangeCoinMaxLabel.Size = new System.Drawing.Size(11, 12);
            this.ExchangeCoinMaxLabel.TabIndex = 7;
            this.ExchangeCoinMaxLabel.Text = "1";
            // 
            // ExchangeCoinTextBox
            // 
            this.ExchangeCoinTextBox.Location = new System.Drawing.Point(502, 192);
            this.ExchangeCoinTextBox.Name = "ExchangeCoinTextBox";
            this.ExchangeCoinTextBox.Size = new System.Drawing.Size(132, 19);
            this.ExchangeCoinTextBox.TabIndex = 8;
            this.ExchangeCoinTextBox.TextChanged += new System.EventHandler(this.ExchangeCoinTextBox_TextChanged);
            this.ExchangeCoinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExchangeCoinTextBox_KeyPress);
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.Location = new System.Drawing.Point(285, 269);
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.Size = new System.Drawing.Size(75, 29);
            this.ExchangeButton.TabIndex = 9;
            this.ExchangeButton.Text = "兑换";
            this.ExchangeButton.UseVisualStyleBackColor = true;
            this.ExchangeButton.Click += new System.EventHandler(this.ExchangeButton_Click);
            // 
            // Exchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 329);
            this.Controls.Add(this.ExchangeButton);
            this.Controls.Add(this.ExchangeCoinTextBox);
            this.Controls.Add(this.ExchangeCoinMaxLabel);
            this.Controls.Add(this.ExchangeCoinMinLabel);
            this.Controls.Add(this.ExchangeCoinLabel);
            this.Controls.Add(this.ExchangeTrackBar);
            this.Controls.Add(this.CoinValueLabel);
            this.Controls.Add(this.CashValueLabel);
            this.Controls.Add(this.CoinLabel);
            this.Controls.Add(this.CashLabel);
            this.Name = "Exchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exchange_FormClosing);
            this.Load += new System.EventHandler(this.Exchange_Load);
            this.SizeChanged += new System.EventHandler(this.Exchange_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CashLabel;
        private System.Windows.Forms.Label CoinLabel;
        private System.Windows.Forms.Label CashValueLabel;
        private System.Windows.Forms.Label CoinValueLabel;
        private System.Windows.Forms.TrackBar ExchangeTrackBar;
        private System.Windows.Forms.Label ExchangeCoinLabel;
        private System.Windows.Forms.Label ExchangeCoinMinLabel;
        private System.Windows.Forms.Label ExchangeCoinMaxLabel;
        private System.Windows.Forms.TextBox ExchangeCoinTextBox;
        private System.Windows.Forms.Button ExchangeButton;


    }
}