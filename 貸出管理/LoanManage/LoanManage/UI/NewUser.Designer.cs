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
            this.GraduationYearLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.SubjectNameLabel = new System.Windows.Forms.Label();
            this.SubjectNameComboBox = new System.Windows.Forms.ComboBox();
            this.MajorNameLabel = new System.Windows.Forms.Label();
            this.MajorNameComboBox = new System.Windows.Forms.ComboBox();
            this.DepartmentNameLabel = new System.Windows.Forms.Label();
            this.DepartmentNameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).BeginInit();
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
            // GraduationYearLabel
            // 
            this.GraduationYearLabel.AutoSize = true;
            this.GraduationYearLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.GraduationYearLabel.Location = new System.Drawing.Point(280, 98);
            this.GraduationYearLabel.Name = "GraduationYearLabel";
            this.GraduationYearLabel.Size = new System.Drawing.Size(80, 16);
            this.GraduationYearLabel.TabIndex = 2;
            this.GraduationYearLabel.Text = "卒業年度 :";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.AddressLabel.Location = new System.Drawing.Point(70, 379);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(48, 16);
            this.AddressLabel.TabIndex = 3;
            this.AddressLabel.Text = "住所 :";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.PhoneLabel.Location = new System.Drawing.Point(64, 338);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(80, 16);
            this.PhoneLabel.TabIndex = 4;
            this.PhoneLabel.Text = "電話番号 :";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.NameTextBox.Location = new System.Drawing.Point(134, 45);
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
            this.MaleRadioButton.Location = new System.Drawing.Point(134, 94);
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
            this.FemaleRadioButton.Location = new System.Drawing.Point(198, 94);
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
            this.YearLabel.Location = new System.Drawing.Point(434, 96);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(24, 16);
            this.YearLabel.TabIndex = 8;
            this.YearLabel.Text = "年";
            // 
            // YearNumericUpDown
            // 
            this.YearNumericUpDown.Location = new System.Drawing.Point(384, 96);
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
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(180, 335);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(88, 19);
            this.PhoneTextBox.TabIndex = 17;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(180, 365);
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(278, 30);
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
            // SubjectNameLabel
            // 
            this.SubjectNameLabel.AutoSize = true;
            this.SubjectNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.SubjectNameLabel.Location = new System.Drawing.Point(280, 146);
            this.SubjectNameLabel.Name = "SubjectNameLabel";
            this.SubjectNameLabel.Size = new System.Drawing.Size(64, 16);
            this.SubjectNameLabel.TabIndex = 21;
            this.SubjectNameLabel.Text = "学科名 :";
            // 
            // SubjectNameComboBox
            // 
            this.SubjectNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectNameComboBox.FormattingEnabled = true;
            this.SubjectNameComboBox.Items.AddRange(new object[] {
            ""});
            this.SubjectNameComboBox.Location = new System.Drawing.Point(384, 143);
            this.SubjectNameComboBox.Name = "SubjectNameComboBox";
            this.SubjectNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.SubjectNameComboBox.TabIndex = 22;
            // 
            // MajorNameLabel
            // 
            this.MajorNameLabel.AutoSize = true;
            this.MajorNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.MajorNameLabel.Location = new System.Drawing.Point(280, 197);
            this.MajorNameLabel.Name = "MajorNameLabel";
            this.MajorNameLabel.Size = new System.Drawing.Size(64, 16);
            this.MajorNameLabel.TabIndex = 23;
            this.MajorNameLabel.Text = "専攻名 :";
            // 
            // MajorNameComboBox
            // 
            this.MajorNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MajorNameComboBox.FormattingEnabled = true;
            this.MajorNameComboBox.Location = new System.Drawing.Point(384, 197);
            this.MajorNameComboBox.Name = "MajorNameComboBox";
            this.MajorNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.MajorNameComboBox.TabIndex = 24;
            // 
            // DepartmentNameLabel
            // 
            this.DepartmentNameLabel.AutoSize = true;
            this.DepartmentNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.DepartmentNameLabel.Location = new System.Drawing.Point(80, 147);
            this.DepartmentNameLabel.Name = "DepartmentNameLabel";
            this.DepartmentNameLabel.Size = new System.Drawing.Size(48, 16);
            this.DepartmentNameLabel.TabIndex = 25;
            this.DepartmentNameLabel.Text = "学部 :";
            // 
            // DepartmentNameComboBox
            // 
            this.DepartmentNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartmentNameComboBox.FormattingEnabled = true;
            this.DepartmentNameComboBox.Location = new System.Drawing.Point(134, 146);
            this.DepartmentNameComboBox.Name = "DepartmentNameComboBox";
            this.DepartmentNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.DepartmentNameComboBox.TabIndex = 26;
            this.DepartmentNameComboBox.SelectedIndexChanged += new System.EventHandler(this.DepartmentNameComboBox_SelectedIndexChanged);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 520);
            this.Controls.Add(this.DepartmentNameComboBox);
            this.Controls.Add(this.DepartmentNameLabel);
            this.Controls.Add(this.MajorNameComboBox);
            this.Controls.Add(this.MajorNameLabel);
            this.Controls.Add(this.SubjectNameComboBox);
            this.Controls.Add(this.SubjectNameLabel);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.YearNumericUpDown);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.FemaleRadioButton);
            this.Controls.Add(this.MaleRadioButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.GraduationYearLabel);
            this.Controls.Add(this.SexLlabel);
            this.Controls.Add(this.NameLabel);
            this.MaximizeBox = false;
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.Load += new System.EventHandler(this.NewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SexLlabel;
        private System.Windows.Forms.Label GraduationYearLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.NumericUpDown YearNumericUpDown;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Label SubjectNameLabel;
        private System.Windows.Forms.ComboBox SubjectNameComboBox;
        private System.Windows.Forms.Label MajorNameLabel;
        private System.Windows.Forms.ComboBox MajorNameComboBox;
        private System.Windows.Forms.Label DepartmentNameLabel;
        private System.Windows.Forms.ComboBox DepartmentNameComboBox;
    }
}