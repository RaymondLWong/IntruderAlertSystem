using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Register r = new Register();
            r.Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
