﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool checkUsernameUnique() {
            return false;
        }

        private bool verifyPassword() {
            return txtPassword.Text == txtPassword2.Text;
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            bool uniqueUsername = checkUsernameUnique();
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

            } else {
                // create a new user in the database

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
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            returnToLogin();
        }
    }
}
