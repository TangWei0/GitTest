namespace Minesweeper.UI
{
    partial class Form_Rank_Custom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Rank_Custom));
            this.Label_Rank = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.efficiencyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Rank
            // 
            this.Label_Rank.AutoSize = true;
            this.Label_Rank.Location = new System.Drawing.Point(26, 23);
            this.Label_Rank.Name = "Label_Rank";
            this.Label_Rank.Size = new System.Drawing.Size(74, 12);
            this.Label_Rank.TabIndex = 0;
            this.Label_Rank.Text = "Custom Rank";
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(364, 377);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 1;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.Location = new System.Drawing.Point(133, 377);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(75, 23);
            this.Button_Reset.TabIndex = 2;
            this.Button_Reset.Text = "Reset";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.efficiencyValue,
            this.mine,
            this.width,
            this.height,
            this.time});
            this.dataGridView.Location = new System.Drawing.Point(28, 37);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(543, 255);
            this.dataGridView.TabIndex = 4;
            // 
            // efficiencyValue
            // 
            this.efficiencyValue.HeaderText = "效率";
            this.efficiencyValue.Name = "efficiencyValue";
            // 
            // mine
            // 
            this.mine.HeaderText = "地雷数";
            this.mine.Name = "mine";
            // 
            // width
            // 
            this.width.HeaderText = "长";
            this.width.Name = "width";
            // 
            // height
            // 
            this.height.HeaderText = "宽";
            this.height.Name = "height";
            // 
            // time
            // 
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            // 
            // Form_Rank_Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(606, 435);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Label_Rank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Rank_Custom";
            this.Text = "Form_Rank_Custom";
            this.Load += new System.EventHandler(this.Form_Rank_Custom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Rank;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn efficiencyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn mine;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
    }
}