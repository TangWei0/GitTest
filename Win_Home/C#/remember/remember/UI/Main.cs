using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace remember.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CreatTextButton_Click(object sender, EventArgs e)
        {
            CreatText creatText = new CreatText();
            this.Visible = false;
            creatText.Show();
            
        }

    }
}
