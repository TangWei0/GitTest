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
    public partial class UserEdit : Form
    {
        DBConnect DBConnect = new DBConnect();

        public string ID, PW;

        public UserEdit()
        {
            InitializeComponent();
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            UserIDTextBox.Text = "";
            NewPasswordTextBox.Text = "";
        }

        private void UserIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text.Length > 8)
            {
                MessageBox.Show("正しいユーザIDを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserEdit_Load(new object(), new EventArgs());
                return;
            }
            ID = UserIDTextBox.Text;
        }

        private void NewPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text.Length > 8)
            {
                MessageBox.Show("正しいパスワードを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserEdit_Load(new object(), new EventArgs());
                return;
            }
            PW = NewPasswordTextBox.Text;
        }      

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ID == String.Empty || PW == String.Empty)
            {
                MessageBox.Show("正しい項目を入力してください。","入力エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            bool flag = false;
            DataSet LoginDataSet = DBConnect.DataSet(DBConnect.LoginAdapter());
            DataTable LoginDataTable = LoginDataSet.Tables["ID"];

            foreach (DataRow data in LoginDataTable.Rows)
            {
                if (data["UserID"].ToString() == ID)
                {
                    flag = true;
                    data["Password"] = PW;
                    DBConnect.dbUpdate(DBConnect.LoginAdapter(), LoginDataSet);
                    this.Close();
                }
            }
            if (!flag)
            {
                MessageBox.Show("ユーザIDが存在しません。", "入力情報エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UserEdit_Load(new object(), new EventArgs());
                return;
            }
        }

    }
}
