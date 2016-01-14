namespace LoanManage.UI
{
    partial class NewUser
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.SexLlabel = new System.Windows.Forms.Label();
            this.BiryhdayLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MonthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.DayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DayLabel = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameLabel.Location = new System.Drawing.Point(80, 48);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(48, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "姓名 :";
            // 
            // SexLlabel
            // 
            this.SexLlabel.AutoSize = true;
            this.SexLlabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.SexLlabel.Location = new System.Drawing.Point(80, 96);
            this.SexLlabel.Name = "SexLlabel";
            this.SexLlabel.Size = new System.Drawing.Size(48, 16);
            this.SexLlabel.TabIndex = 1;
            this.SexLlabel.Text = "性別 :";
            // 
            // BiryhdayLabel
            // 
            this.BiryhdayLabel.AutoSize = true;
            this.BiryhdayLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.BiryhdayLabel.Location = new System.Drawing.Point(80, 144);
            this.BiryhdayLabel.Name = "BiryhdayLabel";
            this.BiryhdayLabel.Size = new System.Drawing.Size(80, 16);
            this.BiryhdayLabel.TabIndex = 2;
            this.BiryhdayLabel.Text = "生年月日 :";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.AddressLabel.Location = new System.Drawing.Point(80, 240);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(48, 16);
            this.AddressLabel.TabIndex = 3;
            this.AddressLabel.Text = "住所 :";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.PhoneLabel.Location = new System.Drawing.Point(80, 192);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(80, 16);
            this.PhoneLabel.TabIndex = 4;
            this.PhoneLabel.Text = "電話番号 :";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.NameTextBox.Location = new System.Drawing.Point(180, 48);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(278, 23);
            this.NameTextBox.TabIndex = 5;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.MaleRadioButton.Location = new System.Drawing.Point(180, 96);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(58, 20);
            this.MaleRadioButton.TabIndex = 6;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "男性";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.MaleRadioButton_CheckedChanged);
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.FemaleRadioButton.Location = new System.Drawing.Point(270, 95);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(58, 20);
            this.FemaleRadioButton.TabIndex = 7;
            this.FemaleRadioButton.Text = "女性";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.YearLabel.Location = new System.Drawing.Point(233, 144);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(24, 16);
            this.YearLabel.TabIndex = 8;
            this.YearLabel.Text = "年";
            // 
            // YearNumericUpDown
            // 
            this.YearNumericUpDown.Location = new System.Drawing.Point(180, 144);
            this.YearNumericUpDown.Maximum = new decimal(new int[] {
            2900,
            0,
            0,
            0});
            this.YearNumericUpDown.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.YearNumericUpDown.Name = "YearNumericUpDown";
            this.YearNumericUpDown.Size = new System.Drawing.Size(47, 19);
            this.YearNumericUpDown.TabIndex = 11;
            this.YearNumericUpDown.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearNumericUpDown.ValueChanged += new System.EventHandler(this.YearNumericUpDown_ValueChanged);
            // 
            // MonthNumericUpDown
            // 
            this.MonthNumericUpDown.Location = new System.Drawing.Point(260, 144);
            this.MonthNumericUpDown.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.MonthNumericUpDown.Name = "MonthNumericUpDown";
            this.MonthNumericUpDown.Size = new System.Drawing.Size(35, 19);
            this.MonthNumericUpDown.TabIndex = 13;
            this.MonthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MonthNumericUpDown.ValueChanged += new System.EventHandler(this.MonthNumericUpDown_ValueChanged);
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MonthLabel.Location = new System.Drawing.Point(304, 144);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(24, 16);
            this.MonthLabel.TabIndex = 14;
            this.MonthLabel.Text = "月";
            // 
            // DayNumericUpDown
            // 
            this.DayNumericUpDown.Location = new System.Drawing.Point(334, 144);
            this.DayNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.DayNumericUpDown.Name = "DayNumericUpDown";
            this.DayNumericUpDown.Size = new System.Drawing.Size(35, 19);
            this.DayNumericUpDown.TabIndex = 15;
            this.DayNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DayNumericUpDown.ValueChanged += new System.EventHandler(this.DayNumericUpDown_ValueChanged);
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DayLabel.Location = new System.Drawing.Point(382, 144);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(24, 16);
            this.DayLabel.TabIndex = 16;
            this.DayLabel.Text = "日";
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(180, 189);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(88, 19);
            this.PhoneTextBox.TabIndex = 17;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(180, 237);
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(278, 158);
            this.AddressTextBox.TabIndex = 18;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(152, 451);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 19;
            this.ConfirmButton.Text = "決定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(307, 451);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(75, 23);
            this.cancleButton.TabIndex = 20;
            this.cancleButton.Text = "クリア";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 520);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.DayLabel);
            this.Controls.Add(this.DayNumericUpDown);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.MonthNumericUpDown);
            this.Controls.Add(this.YearNumericUpDown);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.FemaleRadioButton);
            this.Controls.Add(this.MaleRadioButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.BiryhdayLabel);
            this.Controls.Add(this.SexLlabel);
            this.Controls.Add(this.NameLabel);
            this.MaximizeBox = false;
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.Load += new System.EventHandler(this.NewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SexLlabel;
        private System.Windows.Forms.Label BiryhdayLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.NumericUpDown YearNumericUpDown;
        private System.Windows.Forms.NumericUpDown MonthNumericUpDown;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.NumericUpDown DayNumericUpDown;
        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button cancleButton;
    }
}