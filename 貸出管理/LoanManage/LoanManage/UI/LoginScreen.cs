using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoanManage.UI
{
    public partial class LoginScreen : Form
    {
        DBConnect DBConnect = new DBConnect();
        public string user;
        public string userpass;

        

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
                if (data["UserID"].ToString() == IDTextBox.Text && data["Password"].ToString() == PasswordTextBox.Text)
                {
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

        
    }
}