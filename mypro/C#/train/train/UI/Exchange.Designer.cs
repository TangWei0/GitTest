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
            this.CashValueLabel.Size = new System.Drawing.Size(0, 12);
            this.CashValueLabel.TabIndex = 2;
            // 
            // CoinValueLabel
            // 
            this.CoinValueLabel.AutoSize = true;
            this.CoinValueLabel.Location = new System.Drawing.Point(163, 92);
            this.CoinValueLabel.Name = "CoinValueLabel";
            this.CoinValueLabel.Size = new System.Drawing.Size(0, 12);
            this.CoinValueLabel.TabIndex = 3;
            // 
            // Exchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 249);
            this.Controls.Add(this.CoinValueLabel);
            this.Controls.Add(this.CashValueLabel);
            this.Controls.Add(this.CoinLabel);
            this.Controls.Add(this.CashLabel);
            this.Name = "Exchange";
            this.Text = "Exchange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CashLabel;
        private System.Windows.Forms.Label CoinLabel;
        private System.Windows.Forms.Label CashValueLabel;
        private System.Windows.Forms.Label CoinValueLabel;


    }
}