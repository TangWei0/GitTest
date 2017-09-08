using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyManage
{
    public partial class MoneyManage : Form
    {
        public MoneyManage()
        {
            InitializeComponent();
            FixedValue FixedValue = new FixedValue();

            //MoneyManageCalculate m = new MoneyManageCalculate();

            DateTime date = System.DateTime.Now;
            MoneyManageLabel.Text = date.Year + "年度" + MoneyManageLabel.Text;

            MoneyManageDataGridView.ColumnCount = FixedValue.MONEYMANAGEVIEWCOLUMN;
            MoneyManageDataGridView.RowCount = FixedValue.MONTHS;

            for (int i = 0; i < FixedValue.MONTHS; i++)
            {
                MoneyManageDataGridView.Rows[i].Cells[0].Value = i + 1;
            }

            //MoneyManageDataGridView[0, 0].Value = 1;
            //MoneyManageDataGridView.Rows[0].Cells[0].Value = 1;
            //MoneyManageDataGridView.Rows[1].Cells[0].Value = 2;
            //MoneyManageDataGridView.Rows[2].Cells[0].Value = 3;

            System.Console.WriteLine(date.Month);
            //System.Console.WriteLine(m.cal(100000).ToString());
        }

    }
}
