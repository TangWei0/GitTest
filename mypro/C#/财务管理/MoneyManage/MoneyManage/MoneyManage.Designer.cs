namespace MoneyManage
{
    partial class MoneyManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MoneyManageLabel = new System.Windows.Forms.Label();
            this.MoneyManageDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyManageDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MoneyManageLabel
            // 
            this.MoneyManageLabel.AutoSize = true;
            this.MoneyManageLabel.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MoneyManageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MoneyManageLabel.Location = new System.Drawing.Point(29, 27);
            this.MoneyManageLabel.Name = "MoneyManageLabel";
            this.MoneyManageLabel.Size = new System.Drawing.Size(103, 18);
            this.MoneyManageLabel.TabIndex = 0;
            this.MoneyManageLabel.Text = " 月初预算表";
            // 
            // MoneyManageDataGridView
            // 
            this.MoneyManageDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MoneyManageDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MoneyManageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MoneyManageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonth,
            this.ColumnMoneyIn,
            this.ColumnMoneyOut,
            this.ColumnPlan});
            this.MoneyManageDataGridView.Location = new System.Drawing.Point(32, 61);
            this.MoneyManageDataGridView.Name = "MoneyManageDataGridView";
            this.MoneyManageDataGridView.RowTemplate.Height = 21;
            this.MoneyManageDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MoneyManageDataGridView.Size = new System.Drawing.Size(382, 260);
            this.MoneyManageDataGridView.TabIndex = 1;
            // 
            // ColumnMonth
            // 
            this.ColumnMonth.HeaderText = "月份";
            this.ColumnMonth.Name = "ColumnMonth";
            // 
            // ColumnMoneyIn
            // 
            this.ColumnMoneyIn.HeaderText = "收入";
            this.ColumnMoneyIn.Name = "ColumnMoneyIn";
            // 
            // ColumnMoneyOut
            // 
            this.ColumnMoneyOut.HeaderText = "支出";
            this.ColumnMoneyOut.Name = "ColumnMoneyOut";
            // 
            // ColumnPlan
            // 
            this.ColumnPlan.HeaderText = "预算";
            this.ColumnPlan.Name = "ColumnPlan";
            // 
            // MoneyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 464);
            this.Controls.Add(this.MoneyManageDataGridView);
            this.Controls.Add(this.MoneyManageLabel);
            this.Name = "MoneyManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "月初预算表";
            ((System.ComponentModel.ISupportInitialize)(this.MoneyManageDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MoneyManageLabel;
        private System.Windows.Forms.DataGridView MoneyManageDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlan;
    }
}

