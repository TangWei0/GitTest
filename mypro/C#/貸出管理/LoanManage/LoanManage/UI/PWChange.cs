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
    public partial class PWChange : Form
    {
        DBConnect DBConnect = new DBConnect();
        UI.LoginScreen Login;
        public string currentPW, newPW, confirmPW;

        public PWChange(UI.LoginScreen _Login)
        {
            Login = _Login;
            InitializeComponent();
        }

        private void PWChange_Load(object sender, EventArgs e)
        {
            CurrentPWTextBox.Text = "";
            NewPWTextBox.Text = "";
            NewPwConfirmTextBox.Text = "";
        }

        private bool check()
        {
            if (currentPW == String.Empty || newPW == String.Empty || confirmPW == String.Empty)
            {
                return false;
            }
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("入力パスワードを確認してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PWChange_Load(new object(),new EventArgs());
                return;
            }
            if (CurrentPWTextBox.Text != Login.userpass)
            {
                MessageBox.Show("現在パスワードを確認してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PWChange_Load(new object(), new EventArgs());
                return;
            }
            if (NewPWTextBox.Text == Login.userpass)
            {
                MessageBox.Show("新しいパスワードと現在パスワード一致しました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PWChange_Load(new object(), new EventArgs());
                return;
            }
            if (NewPWTextBox.Text != NewPwConfirmTextBox.Text)
            {
                MessageBox.Show("入力パスワード不一致です、もう一度確認してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PWChange_Load(new object(), new EventArgs());
                return;
            }

            DataSet LoginDataSet = DBConnect.DataSet(DBConnect.LoginAdapter());
            DataTable LoginDataTable = LoginDataSet.Tables["ID"];

            foreach (DataRow data in LoginDataTable.Rows)
            {
                if (data["UserID"].ToString() == Login.user)
                {
                    data["Password"] = newPW;
                }
            }
            DBConnect.dbUpdate(DBConnect.LoginAdapter(), LoginDataSet);
            Login.userpass = newPW;
            this.Close();
        }

        private void CurrentPWTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentPWTextBox.Text.Length > 8)
            {
                MessageBox.Show("パスワードが8桁を超えました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CurrentPWTextBox.Text = "";
                return;
            }
            else
            {
                currentPW = CurrentPWTextBox.Text;
            }
        }

        private void NewPWTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NewPWTextBox.Text.Length > 8)
            {
                MessageBox.Show("パスワードが8桁を超えました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewPWTextBox.Text = "";
                return;
            }
            else
            {
                newPW = NewPWTextBox.Text;
            }
        }

        private void NewPwConfirmTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NewPwConfirmTextBox.Text.Length > 8)
            {
                MessageBox.Show("パスワードが8桁を超えました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewPwConfirmTextBox.Text = "";
                return;
            }
            else
            {
                confirmPW = NewPwConfirmTextBox.Text;
            }
        }

    }
}
