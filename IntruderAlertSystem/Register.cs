using System;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class Register : Form {
        private static Register register = null;

        public Register() {
            InitializeComponent();
        }

        public static Form getInstance() {
            if (register == null) {
                register = new Register();
            }

            return register;
        }

        private bool verifyPassword() {
            return txtPassword.Text == txtPassword2.Text;
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtPassword2.Text == "") {
                MessageBox.Show("All fields are mandatory, please fill them in.", "One or more fields are blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            bool uniqueUsername = Database.checkUserDoesNotExist(txtUsername.Text);
            bool passwordSame = verifyPassword();

            // show an error message displaying incorrect requirements
            if (!uniqueUsername || !passwordSame) {
                string errorMessage = "";

                if (!uniqueUsername) {
                    errorMessage += String.Format("Username '{0}' is already taken, please choose another username.", txtUsername.Text);
                }

                if (!passwordSame) {
                    errorMessage += String.Format("The passwords do not match. Please re-enter your password and ensure they are identical.");
                }

                string title = "Incorrect username or password requirements";
                MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            } else {
                // create a new user in the database
                byte[] salt = PasswordHashWithPBKDF2.generateSalt();
                byte[] pw = PasswordHashWithPBKDF2.hashPassword(txtPassword.Text, salt);
                // create a new salt, hash password and store both in db
                Database.createUser(txtUsername.Text, pw, salt);

                MessageBox.Show("Your acccount has been created successfully. You may now login.",
                    "Account created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // clear the data so a new user can login
                clearData();
            }

            returnToLogin();
        }

        private void clearData() {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtPassword2.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e) {
            clearData();
        }

        private void returnToLogin() {
            Login.getInstance().Show();
            getInstance().Hide();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            returnToLogin();
        }
    }
}
