namespace remember.UI
{
    partial class Main
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
            this.CreatTextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreatTextButton
            // 
            this.CreatTextButton.Location = new System.Drawing.Point(505, 429);
            this.CreatTextButton.Name = "CreatTextButton";
            this.CreatTextButton.Size = new System.Drawing.Size(75, 23);
            this.CreatTextButton.TabIndex = 0;
            this.CreatTextButton.Text = "テキスト追加";
            this.CreatTextButton.UseVisualStyleBackColor = true;
            this.CreatTextButton.Click += new System.EventHandler(this.CreatTextButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 489);
            this.Controls.Add(this.CreatTextButton);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreatTextButton;
    }
}