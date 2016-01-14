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
        DateTime date;
        public int year;
        public string name,sex,phone,address;

        public NewUser()
        {   
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            foreach (string departname in Information.DepartmentName)
            {
                DepartmentNameComboBox.Items.Add(departname);
            }
            NameTextBox.Text = "";
            MaleRadioButton.Checked = true;
            TodayResume();
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
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
            if (YearNumericUpDown.Value > now.Year + 4 || YearNumericUpDown.Value < 1900)
            {
                MessageBox.Show("正しい年数を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TodayResume();
            }
            year = Convert.ToInt32(YearNumericUpDown.Value);
        }

        private void TodayResume()
        {
            YearNumericUpDown.Value = now.Year;
            year = now.Year;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length > 20)
            {
                MessageBox.Show("正しい情報を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewUser_Load(new object(), new EventArgs());
                return;
            }
            name = NameTextBox.Text;
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {  
            if (!PhoneCheck(PhoneTextBox.Text) || PhoneTextBox.Text.Length > 11)
            {
                MessageBox.Show("正しい情報を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewUser_Load(new object(), new EventArgs());
                return;
            }
            phone = PhoneTextBox.Text;
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
            if (name == String.Empty || phone == String.Empty || address == String.Empty)
            {
                MessageBox.Show("未入力項目があります！", "入力情報エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet UserDataSet = DBConnect.DataSet(DBConnect.UserAdapter());
            DataTable UserDataTable = UserDataSet.Tables["ID"];
            DataRow addrow = UserDataTable.NewRow();
            addrow["Name"] = name;
            addrow["Sex"] = sex;
            addrow["Brithday"] = date;
            addrow["Address"] = address;
            addrow["Phone"] = phone;
            addrow["UserID"] = CreatUserID(UserDataTable.Rows.Count);
            addrow["Password"] = "12345678";
            foreach (DataRow data in UserDataTable.Rows)
            {
                if (data["Name"].ToString() == name && data["Sex"].ToString() == sex &&  data["Brithday"].ToString() == date.ToString())
                {
                    MessageBox.Show("入力情報が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NewUser_Load(new object(), new EventArgs());
                    return;
                }
            }
            UserDataTable.Rows.Add(addrow);
            DBConnect.dbUpdate(DBConnect.UserAdapter(), UserDataSet);
            this.Close();
        }

        private string CreatUserID(int ID)
        {
            string s;
            ID = ID + 1;
            s = "S" + ID.ToString("D7");
            return s; 
        }

        private bool PhoneCheck(string phoneNum)
        {
            if (phoneNum.Length == 0)
            {
                return true;
            }
            if (!Char.IsNumber(phoneNum, phoneNum.Length - 1))
            {
                return false;
            }           
            return true;
        }

        private void DepartmentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = DepartmentNameComboBox.Text;
            SubjectNameComboBox.Items.Clear();
            foreach (string subjectname in Information.SelectSubject(s))
            {
                SubjectNameComboBox.Items.Add(subjectname);
            }
        }


      
    }
}