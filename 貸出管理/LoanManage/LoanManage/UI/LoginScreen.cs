using System;
using System.Data;
using System.Windows.Forms;

namespace LoanManage.UI
{
    public partial class LoginScreen : Form
    {
        DBConnect DBConnect = new DBConnect();
        public string user;
        public string userpass;
        public bool manage = true;

        public LoginScreen()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private bool check()
        {
            if (IDTextBox.Text == "")
            {
                return false;
            }
            if (PasswordTextBox.Text == "")
            {
                return false;
            }
            return true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("ログインエラー");
                return;
            }

            user = IDTextBox.Text;
            userpass = PasswordTextBox.Text;
            DataSet LoginDataSet = DBConnect.DataSet(DBConnect.LoginAdapter());
            DataTable LoginDataTable = LoginDataSet.Tables["ID"];
            bool ErrorCheck = true;

            foreach (DataRow data in LoginDataTable.Rows)
			{
                if (Convert.ToString(data["UserID"]) == IDTextBox.Text && Convert.ToString(data["Password"]) == PasswordTextBox.Text)
                {
                    if (manage == true)
                    {
                        if (Convert.ToBoolean(data["Manage"]) != true)
                        {
                            break;
                        }
                    }
                    ErrorCheck = false;
                    this.Hide();
                    UI.Main main = new UI.Main(this);
                    main.StartPosition = FormStartPosition.CenterScreen;
                    main.Show();
                }
			}

            if (ErrorCheck)
            {
                UI.LoginError loginErr = new UI.LoginError();
                loginErr.StartPosition = FormStartPosition.CenterScreen;
                loginErr.Show();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ManageRadioButton.Checked)
            {
                manage = true;
            }
            else
            {
                manage = false;
            }
        }
        
    }
}