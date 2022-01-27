using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mockTest
{
    public partial class Login : Form
    {

        private string uname;
        private string upass;


        public Login()
        {
            InitializeComponent();
            uname = "Default";
            upass = "Default";
        }

        public string getUsername()
        {
            return uname;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            uname = inUsername.Text;
            upass = inPassword.Text;
            this.Close();
        }
    }
}
