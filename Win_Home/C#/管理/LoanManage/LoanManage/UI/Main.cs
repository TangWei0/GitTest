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
    public partial class Main : Form
    {
        UI.LoginScreen Login;
        public Main(UI.LoginScreen _Login)
        {
            InitializeComponent();
            Login = _Login;
            if (Login.manage == false)
            {
                UserManageUToolStripMenuItem.Visible = false;
            }
        }

        private void ExitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("終了しますか？", "終了", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void PasswordChangeCToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            UI.PWChange pwChange = new UI.PWChange(Login);
            pwChange.StartPosition = FormStartPosition.CenterScreen;
            pwChange.Show();
        }

        private void NewUserNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.NewUser newUser = new UI.NewUser();
            newUser.StartPosition = FormStartPosition.CenterScreen;
            newUser.Show();
        }

        private void UserDeleteDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.UserDelete deleteUser = new UI.UserDelete();
            deleteUser.StartPosition = FormStartPosition.CenterScreen;
            deleteUser.Show();
        }

        private void UserEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.UserEdit editUser = new UI.UserEdit();
            editUser.StartPosition = FormStartPosition.CenterScreen;
            editUser.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

    }
}
