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
            this.Phone1Label = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Phone1TextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.SubjectNameLabel = new System.Windows.Forms.Label();
            this.SubjectNameComboBox = new System.Windows.Forms.ComboBox();
            this.MajorNameLabel = new System.Windows.Forms.Label();
            this.MajorNameComboBox = new System.Windows.Forms.ComboBox();
            this.DepartmentNameLabel = new System.Windows.Forms.Label();
            this.DepartmentNameComboBox = new System.Windows.Forms.ComboBox();
            this.StudyNameLabel = new System.Windows.Forms.Label();
            this.StudyNameComboBox = new System.Windows.Forms.ComboBox();
            this.Phone2Label = new System.Windows.Forms.Label();
            this.Phone2TextBox = new System.Windows.Forms.TextBox();
            this.EMail1Label = new System.Windows.Forms.Label();
            this.EMail2Label = new System.Windows.Forms.Label();
            this.EMail1TextBox = new System.Windows.Forms.TextBox();
            this.EMail2TextBox = new System.Windows.Forms.TextBox();
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
            this.GraduationYearLabel.Location = new System.Drawing.Point(286, 96);
            this.GraduationYearLabel.Name = "GraduationYearLabel";
            this.GraduationYearLabel.Size = new System.Drawing.Size(80, 16);
            this.GraduationYearLabel.TabIndex = 2;
            this.GraduationYearLabel.Text = "卒業年度 :";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.AddressLabel.Location = new System.Drawing.Point(80, 384);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(48, 16);
            this.AddressLabel.TabIndex = 3;
            this.AddressLabel.Text = "住所 :";
            // 
            // Phone1Label
            // 
            this.Phone1Label.AutoSize = true;
            this.Phone1Label.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Phone1Label.Location = new System.Drawing.Point(80, 240);
            this.Phone1Label.Name = "Phone1Label";
            this.Phone1Label.Size = new System.Drawing.Size(80, 16);
            this.Phone1Label.TabIndex = 4;
            this.Phone1Label.Text = "電話番号1";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.NameTextBox.Location = new System.Drawing.Point(166, 45);
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
            this.MaleRadioButton.Location = new System.Drawing.Point(166, 92);
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
            this.FemaleRadioButton.Location = new System.Drawing.Point(222, 92);
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
            // Phone1TextBox
            // 
            this.Phone1TextBox.Location = new System.Drawing.Point(166, 237);
            this.Phone1TextBox.Name = "Phone1TextBox";
            this.Phone1TextBox.Size = new System.Drawing.Size(121, 19);
            this.Phone1TextBox.TabIndex = 17;
            this.Phone1TextBox.TextChanged += new System.EventHandler(this.Phone1TextBox_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(166, 384);
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(339, 66);
            this.AddressTextBox.TabIndex = 18;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(166, 485);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 19;
            this.ConfirmButton.Text = "決定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(430, 485);
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
            this.SubjectNameLabel.Location = new System.Drawing.Point(302, 144);
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
            this.SubjectNameComboBox.Location = new System.Drawing.Point(384, 140);
            this.SubjectNameComboBox.Name = "SubjectNameComboBox";
            this.SubjectNameComboBox.Size = new System.Drawing.Size(175, 20);
            this.SubjectNameComboBox.TabIndex = 22;
            this.SubjectNameComboBox.SelectedIndexChanged += new System.EventHandler(this.SubjectNameComboBox_SelectedIndexChanged);
            // 
            // MajorNameLabel
            // 
            this.MajorNameLabel.AutoSize = true;
            this.MajorNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.MajorNameLabel.Location = new System.Drawing.Point(302, 192);
            this.MajorNameLabel.Name = "MajorNameLabel";
            this.MajorNameLabel.Size = new System.Drawing.Size(64, 16);
            this.MajorNameLabel.TabIndex = 23;
            this.MajorNameLabel.Text = "専攻名 :";
            // 
            // MajorNameComboBox
            // 
            this.MajorNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MajorNameComboBox.FormattingEnabled = true;
            this.MajorNameComboBox.Location = new System.Drawing.Point(384, 188);
            this.MajorNameComboBox.Name = "MajorNameComboBox";
            this.MajorNameComboBox.Size = new System.Drawing.Size(175, 20);
            this.MajorNameComboBox.TabIndex = 24;
            this.MajorNameComboBox.SelectedIndexChanged += new System.EventHandler(this.MajorNameComboBox_SelectedIndexChanged);
            // 
            // DepartmentNameLabel
            // 
            this.DepartmentNameLabel.AutoSize = true;
            this.DepartmentNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.DepartmentNameLabel.Location = new System.Drawing.Point(80, 144);
            this.DepartmentNameLabel.Name = "DepartmentNameLabel";
            this.DepartmentNameLabel.Size = new System.Drawing.Size(48, 16);
            this.DepartmentNameLabel.TabIndex = 25;
            this.DepartmentNameLabel.Text = "学部 :";
            // 
            // DepartmentNameComboBox
            // 
            this.DepartmentNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartmentNameComboBox.FormattingEnabled = true;
            this.DepartmentNameComboBox.Location = new System.Drawing.Point(166, 140);
            this.DepartmentNameComboBox.Name = "DepartmentNameComboBox";
            this.DepartmentNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.DepartmentNameComboBox.TabIndex = 26;
            this.DepartmentNameComboBox.SelectedIndexChanged += new System.EventHandler(this.DepartmentNameComboBox_SelectedIndexChanged);
            // 
            // StudyNameLabel
            // 
            this.StudyNameLabel.AutoSize = true;
            this.StudyNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.StudyNameLabel.Location = new System.Drawing.Point(80, 192);
            this.StudyNameLabel.Name = "StudyNameLabel";
            this.StudyNameLabel.Size = new System.Drawing.Size(80, 16);
            this.StudyNameLabel.TabIndex = 27;
            this.StudyNameLabel.Text = "研究科名 :";
            // 
            // StudyNameComboBox
            // 
            this.StudyNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudyNameComboBox.FormattingEnabled = true;
            this.StudyNameComboBox.Location = new System.Drawing.Point(166, 188);
            this.StudyNameComboBox.Name = "StudyNameComboBox";
            this.StudyNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.StudyNameComboBox.TabIndex = 28;
            this.StudyNameComboBox.SelectedIndexChanged += new System.EventHandler(this.StudyNameComboBox_SelectedIndexChanged);
            // 
            // Phone2Label
            // 
            this.Phone2Label.AutoSize = true;
            this.Phone2Label.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Phone2Label.Location = new System.Drawing.Point(302, 240);
            this.Phone2Label.Name = "Phone2Label";
            this.Phone2Label.Size = new System.Drawing.Size(80, 16);
            this.Phone2Label.TabIndex = 29;
            this.Phone2Label.Text = "電話番号2";
            // 
            // Phone2TextBox
            // 
            this.Phone2TextBox.Location = new System.Drawing.Point(384, 237);
            this.Phone2TextBox.Name = "Phone2TextBox";
            this.Phone2TextBox.Size = new System.Drawing.Size(121, 19);
            this.Phone2TextBox.TabIndex = 30;
            this.Phone2TextBox.TextChanged += new System.EventHandler(this.Phone2TextBox_TextChanged);
            // 
            // EMail1Label
            // 
            this.EMail1Label.AutoSize = true;
            this.EMail1Label.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.EMail1Label.Location = new System.Drawing.Point(80, 288);
            this.EMail1Label.Name = "EMail1Label";
            this.EMail1Label.Size = new System.Drawing.Size(62, 16);
            this.EMail1Label.TabIndex = 31;
            this.EMail1Label.Text = "Eメール1";
            // 
            // EMail2Label
            // 
            this.EMail2Label.AutoSize = true;
            this.EMail2Label.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.EMail2Label.Location = new System.Drawing.Point(80, 336);
            this.EMail2Label.Name = "EMail2Label";
            this.EMail2Label.Size = new System.Drawing.Size(62, 16);
            this.EMail2Label.TabIndex = 32;
            this.EMail2Label.Text = "Eメール2";
            // 
            // EMail1TextBox
            // 
            this.EMail1TextBox.Location = new System.Drawing.Point(166, 285);
            this.EMail1TextBox.Name = "EMail1TextBox";
            this.EMail1TextBox.Size = new System.Drawing.Size(339, 19);
            this.EMail1TextBox.TabIndex = 33;
            this.EMail1TextBox.TextChanged += new System.EventHandler(this.EMail1TextBox_TextChanged);
            // 
            // EMail2TextBox
            // 
            this.EMail2TextBox.Location = new System.Drawing.Point(166, 333);
            this.EMail2TextBox.Name = "EMail2TextBox";
            this.EMail2TextBox.Size = new System.Drawing.Size(339, 19);
            this.EMail2TextBox.TabIndex = 34;
            this.EMail2TextBox.TextChanged += new System.EventHandler(this.EMail2TextBox_TextChanged);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 554);
            this.Controls.Add(this.EMail2TextBox);
            this.Controls.Add(this.EMail1TextBox);
            this.Controls.Add(this.EMail2Label);
            this.Controls.Add(this.EMail1Label);
            this.Controls.Add(this.Phone2TextBox);
            this.Controls.Add(this.Phone2Label);
            this.Controls.Add(this.StudyNameComboBox);
            this.Controls.Add(this.StudyNameLabel);
            this.Controls.Add(this.DepartmentNameComboBox);
            this.Controls.Add(this.DepartmentNameLabel);
            this.Controls.Add(this.MajorNameComboBox);
            this.Controls.Add(this.MajorNameLabel);
            this.Controls.Add(this.SubjectNameComboBox);
            this.Controls.Add(this.SubjectNameLabel);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.Phone1TextBox);
            this.Controls.Add(this.YearNumericUpDown);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.FemaleRadioButton);
            this.Controls.Add(this.MaleRadioButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Phone1Label);
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
        private System.Windows.Forms.Label Phone1Label;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.NumericUpDown YearNumericUpDown;
        private System.Windows.Forms.TextBox Phone1TextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Label SubjectNameLabel;
        private System.Windows.Forms.ComboBox SubjectNameComboBox;
        private System.Windows.Forms.Label MajorNameLabel;
        private System.Windows.Forms.ComboBox MajorNameComboBox;
        private System.Windows.Forms.Label DepartmentNameLabel;
        private System.Windows.Forms.ComboBox DepartmentNameComboBox;
        private System.Windows.Forms.Label StudyNameLabel;
        private System.Windows.Forms.ComboBox StudyNameComboBox;
        private System.Windows.Forms.Label Phone2Label;
        private System.Windows.Forms.TextBox Phone2TextBox;
        private System.Windows.Forms.Label EMail1Label;
        private System.Windows.Forms.Label EMail2Label;
        private System.Windows.Forms.TextBox EMail1TextBox;
        private System.Windows.Forms.TextBox EMail2TextBox;
    }
}