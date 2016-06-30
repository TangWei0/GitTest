namespace remember
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.getOpeningExcelButton = new System.Windows.Forms.Button();
            this.setTextButton = new System.Windows.Forms.Button();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.CloseExcelButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getOpeningExcelButton
            // 
            this.getOpeningExcelButton.Location = new System.Drawing.Point(24, 26);
            this.getOpeningExcelButton.Name = "getOpeningExcelButton";
            this.getOpeningExcelButton.Size = new System.Drawing.Size(248, 37);
            this.getOpeningExcelButton.TabIndex = 0;
            this.getOpeningExcelButton.Text = "Excel取得";
            this.getOpeningExcelButton.UseVisualStyleBackColor = true;
            this.getOpeningExcelButton.Click += new System.EventHandler(this.getOpeningExcelButton_Click);
            // 
            // setTextButton
            // 
            this.setTextButton.Location = new System.Drawing.Point(24, 187);
            this.setTextButton.Name = "setTextButton";
            this.setTextButton.Size = new System.Drawing.Size(75, 23);
            this.setTextButton.TabIndex = 1;
            this.setTextButton.Text = "文字セット";
            this.setTextButton.UseVisualStyleBackColor = true;
            this.setTextButton.Click += new System.EventHandler(this.setTextButton_Click);
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(155, 187);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(117, 19);
            this.yearBox.TabIndex = 2;
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            this.yearBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yearBox_KeyPress);
            // 
            // CloseExcelButton
            // 
            this.CloseExcelButton.Location = new System.Drawing.Point(24, 87);
            this.CloseExcelButton.Name = "CloseExcelButton";
            this.CloseExcelButton.Size = new System.Drawing.Size(248, 37);
            this.CloseExcelButton.TabIndex = 3;
            this.CloseExcelButton.Text = "Excel閉じる";
            this.CloseExcelButton.UseVisualStyleBackColor = true;
            this.CloseExcelButton.Click += new System.EventHandler(this.CloseExcelButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 293);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 214);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 563);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CloseExcelButton);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.setTextButton);
            this.Controls.Add(this.getOpeningExcelButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getOpeningExcelButton;
        private System.Windows.Forms.Button setTextButton;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Button CloseExcelButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

