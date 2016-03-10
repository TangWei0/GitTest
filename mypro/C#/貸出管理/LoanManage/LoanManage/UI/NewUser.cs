using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManage.UI
{
    public partial class NewUser : Form
    {
        DBConnect DBConnect = new DBConnect();
        Information Information = new Information();
        

        DateTime now = DateTime.Now;
        public int year;
        string name, sex, graudeSubject, graudeMajor, DepartmentName, StudyName, phone1, phone2, email1, email2, address;

        public NewUser()
        {   
            InitializeComponent();

            YearNumericUpDown.Value = now.Year;
            foreach (string departname in Information.DepartmentName)
            {
                DepartmentNameComboBox.Items.Add(departname);
            }
            DepartmentNameComboBox.SelectedIndex = 0;
            foreach (string studyname in Information.StudyName)
            {
                StudyNameComboBox.Items.Add(studyname);
            }
            StudyNameComboBox.SelectedIndex = 0;
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            name = "";
            sex = "男性";
            year = now.Year;
            graudeSubject = "";
            graudeMajor = "";
            phone1 = "";
            phone2 = "";
            email1 = "";
            email2 = "";
            address = "";
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length > 20)
            {
                MessageBox.Show("正しい情報を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextBox.Text = "";
            }
            name = NameTextBox.Text;
        }

        private void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MaleRadioButton.Checked)
            {
                sex = "男性";
            }
            else
            {
                sex = "女性";
            }
        }

        private void YearNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (YearNumericUpDown.Value > now.Year + 4 || YearNumericUpDown.Value < 1950)
            {
                MessageBox.Show("正しい年数を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                YearNumericUpDown.Value = now.Year;
            }
            year = Convert.ToInt32(YearNumericUpDown.Value);
        }

        private void DepartmentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentName = DepartmentNameComboBox.Text;
            SubjectNameComboBox.Items.Clear();
            foreach (string subjectname in Information.SelectSubject(DepartmentNameComboBox.SelectedIndex))
            {
                SubjectNameComboBox.Items.Add(subjectname);
            }
            SubjectNameComboBox.SelectedIndex = 0;
        }

        private void SubjectNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentName != Information.DepartmentName[0] && SubjectNameComboBox.Text != Information.ChooseName[0])
            {
                graudeSubject = DepartmentName + SubjectNameComboBox.Text;
            }
            else
            {
                graudeSubject = "";
            }
        }

        private void StudyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudyName = StudyNameComboBox.Text;
            MajorNameComboBox.Items.Clear();
            foreach (string majorname in Information.SelectMajor(StudyNameComboBox.SelectedIndex))
            {
                MajorNameComboBox.Items.Add(majorname);
            }
            MajorNameComboBox.SelectedIndex = 0;
        }

        private void MajorNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudyName != Information.StudyName[0] && MajorNameComboBox.Text != Information.ChooseName[0])
            {
                graudeMajor = StudyName + MajorNameComboBox.Text;
            }
            else
            {
                graudeMajor = "";
            }
        }

        private void Phone1TextBox_TextChanged(object sender, EventArgs e)
        {
            if(!PhoneCheck(Phone1TextBox.Text))
            {
                MessageBox.Show("電話番号を正しく入力してください","入力エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Phone1TextBox.Text = "";
            }
            phone1 = Phone1TextBox.Text;
        }

        private void Phone2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!PhoneCheck(Phone2TextBox.Text))
            {
                MessageBox.Show("電話番号を正しく入力してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Phone2TextBox.Text = "";
            }
            phone2 = Phone2TextBox.Text;
        }

        private bool PhoneCheck(string phoneNum)
        {
            if (phoneNum.Length == 0)
            {
                return true;
            }
            if (phoneNum.Length == 1)
            {
                if (phoneNum == "+" || Char.IsNumber(phoneNum, phoneNum.Length - 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (!Char.IsNumber(phoneNum, phoneNum.Length - 1) || phoneNum.Length > 15)
            {
                return false;
            }
            return true;
        }

        private void EMail1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (EMail1TextBox.Text.Length > 50)
            {
                MessageBox.Show("正しいEメールを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EMail1TextBox.Text = "";
            }
            email1 = EMail1TextBox.Text;
        }

        private void EMail2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (EMail2TextBox.Text.Length > 50)
            {
                MessageBox.Show("正しいEメールを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EMail2TextBox.Text = "";
            }
            email2 = EMail2TextBox.Text;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            address = AddressTextBox.Text;
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (name == String.Empty)
            {
                MessageBox.Show("お名前を入力してください！", "入力情報エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (graudeMajor == "" && graudeSubject == "")
            {
                MessageBox.Show("卒業専門を選んでください。", "入力情報エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet UserDataSet = DBConnect.DataSet(DBConnect.UserAdapter());
            DataTable UserDataTable = UserDataSet.Tables["ID"];
            DataRow addrow = UserDataTable.NewRow();
            
            //Properties.Settings.Default.count = 1;
            //Properties.Settings.Default.Save();
            long count = Properties.Settings.Default.count;

            addrow["Name"] = name;
            addrow["Sex"] = sex;
            addrow["GraduationYear"] = year;
            addrow["GraduationSubject"] = graudeSubject;
            addrow["GraduationMajor"] = graudeMajor;
            addrow["Phone1"] = phone1;
            addrow["Phone2"] = phone2;
            addrow["Email1"] = email1;
            addrow["Email2"] = email2;
            addrow["Address"] = address;
            addrow["UserID"] = CreatUserID(count);
            addrow["Password"] = "12345678";
            foreach (DataRow data in UserDataTable.Rows)
            {
                if (data["Name"].ToString() == name && data["Sex"].ToString() == sex && data["GraduationYear"].ToString() == year.ToString())
                {
                    MessageBox.Show("入力情報が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NewUser_Load(new object(), new EventArgs());
                    return;
                }
            }

            if (MessageBox.Show("管理員になりますか？", "添加管理員", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                addrow["Manage"] = true;
            }
            else
            {
                addrow["Manage"] = false;
            }
            UserDataTable.Rows.Add(addrow);
            DBConnect.dbUpdate(DBConnect.UserAdapter(), UserDataSet);
            Properties.Settings.Default.count = count + 1;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private string CreatUserID(long ID)
        {
            string s;
            s = "S" + ID.ToString("D7");
            return s; 
        }

    }
}