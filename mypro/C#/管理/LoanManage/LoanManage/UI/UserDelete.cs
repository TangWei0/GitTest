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
    public partial class UserDelete : Form
    {
        public string ID;
        DBConnect DBConnect = new DBConnect();
        public UserDelete()
        {
            InitializeComponent();
        }

        private void UserDelete_Load(object sender, EventArgs e)
        {
            UserIDTextBox.Text = "";
        }

        private void UserIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text.Length > 8)
            {
                MessageBox.Show("正しい情報を入力してください。","入力エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                UserDelete_Load(new object(), new EventArgs());
                return;
            }
            ID = UserIDTextBox.Text;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ID == String.Empty)
            {
                MessageBox.Show("ユーザIDを入力してください。","入力エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(ID + "削除しますか", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool flag = false;
                DataSet UserDataSet = DBConnect.DataSet(DBConnect.UserAdapter());
                DataTable UserDataTable = UserDataSet.Tables["ID"];
                
                foreach (DataRow data in UserDataTable.Rows)
                {
                    if (data["UserID"].ToString() == ID)
                    {
                        flag = true;
                        data.Delete();
                        DBConnect.dbUpdate(DBConnect.LoginAdapter(), UserDataSet);
                        this.Close();
                    }
                }
                if (!flag)
                {
                    MessageBox.Show(ID + "が存在しません。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserDelete_Load(new object(), new EventArgs());
                    return;
                }
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
