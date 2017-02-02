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

        private static Login login = null;

        public Login() {
            InitializeComponent();
        }

        public static Form getInstance() {
            if (login == null) {
                login = new Login();
            }

            return login;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            // compare values with db
            bool same = PasswordHashWithPBKDF2.compareWithStoredPassword(txtUsername.Text, PasswordHashWithPBKDF2.hashPassword("pass"));
            Console.WriteLine(same ? "Passwords are the same." : "Passwords are different.");

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Register.getInstance().Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) {
            Common.confirmClose(ref e);
        }
    }
}
