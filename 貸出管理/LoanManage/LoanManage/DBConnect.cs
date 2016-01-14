using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LoanManage
{
    class DBConnect
    {
        public SqlConnection DBConnectPath()
        {
            string DBConnectPath = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "data.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(DBConnectPath);
            return con;
        }

        public SqlDataAdapter LoginAdapter()
        {      
            SqlDataAdapter loginAdapter = new SqlDataAdapter("Select UserID,Password From customer",  DBConnectPath());
            return loginAdapter;
        }

        public SqlDataAdapter UserAdapter()
        {
            SqlDataAdapter userAdapter = new SqlDataAdapter("Select * From customer", DBConnectPath());
            return userAdapter;
        }

        public DataSet DataSet(SqlDataAdapter Adapter)
        {
            DataSet dataset = new DataSet();
            Adapter.Fill(dataset,"ID");
            return dataset;
        }

        public void dbUpdate(SqlDataAdapter Adapter, DataSet Data)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(Adapter);
            Adapter.Update(Data, "ID");  
        }
    }

    
}
