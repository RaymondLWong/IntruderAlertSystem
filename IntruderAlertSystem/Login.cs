using MySql.Data.MySqlClient;
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
            handleLogin();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Register.getInstance().Show();
            getInstance().Hide();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) {
            Common.confirmClose(ref e);
        }

        private void handleLogin() {
            if (txtUsername.Text == "" || txtPassword.Text == "") {
                MessageBox.Show("Both Username and Password fields are mandatory, please fill them in.",
                    "Username or password fields are blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool validUser = Database.authenticateUser(txtUsername.Text, txtPassword.Text);
            Console.WriteLine($"user id is: {User.UserID}");

            if (validUser) {
                getInstance().Hide();
                authenticated.getInstance().Show();
            } else {
                MessageBox.Show("Your username or password is incorrect, please try again or register a new account.",
                    "Username or password incorrect.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                handleLogin();
            }
        }
    }
}
