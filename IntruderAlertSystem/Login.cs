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

            testDBConnection();
        }

        public void testDBConnection() {
            MySqlConnection con = Database.getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE UserId=@UID", con);
            cmd.Parameters.Add(new MySqlParameter("@UID", 23));

            con.Open();
            cmd.ExecuteNonQuery();

            DataSet ds = new DataSet();
            MySqlDataAdapter dAdap = new MySqlDataAdapter();
            dAdap.SelectCommand = cmd;
            dAdap.Fill(ds, "Username");

            MySqlDataReader reader;

            try {
                //string uname = ds.Tables["Username"].Rows[0].ToString();
                //Console.WriteLine(String.Format("username is: '{0}'", uname));

                reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    string s = reader.GetString("Username");
                    Console.WriteLine(String.Format("username is: '{0}'", s));
                }

                reader.Close();

            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }
        }

        public static Form getInstance() {
            if (login == null) {
                login = new Login();
            }

            return login;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            // compare values with db
            byte[] salt = Convert.FromBase64String("Np+OF2DR0RgHUj4qMaPzrAzlLMULxflcy+HtBnTCat0=");
            string target = PasswordHashWithPBKDF2.hashPasswordAsString("pass", salt);
            string pw1 = PasswordHashWithPBKDF2.hashPasswordAsString(txtUsername.Text, salt);
            Console.WriteLine(String.Format("{0} ; {1}", pw1, target));

            bool s = PasswordHashWithPBKDF2.compareWithStoredPassword("pass", "zJN8HKhBRQeOMI+7eprpNI2/BFY=", salt);
            Console.WriteLine(String.Format("Passwords are the same: " + s));

            //this.Hide();
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
