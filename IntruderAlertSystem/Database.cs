using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntruderAlertSystem {
    class Database {

        private static MySqlConnection con = null;

        public static MySqlConnection getDBConection() {
            if (con == null) {
                con = new MySqlConnection(Properties.Settings.Default.pdcConnectionString);
            }

            return con;
        }

        public static void createUser(string username, byte[] password, byte[] salt) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO users (Username, PasswordHash, PasswordSalt) VALUES (@uname, @pw, @salt);", con);

            MySqlParameter paramUsername = new MySqlParameter("@uname", MySqlDbType.VarChar);
            MySqlParameter paramPw = new MySqlParameter("@pw", MySqlDbType.VarBinary);
            MySqlParameter paramSalt = new MySqlParameter("@salt", MySqlDbType.VarBinary);

            paramUsername.Value = username;
            paramPw.Value = password;
            paramSalt.Value = salt;

            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPw);
            cmd.Parameters.Add(paramSalt);

            try {
                con.Open();
                cmd.ExecuteNonQuery();
            } catch (MySqlException MySqlE) {
                throw MySqlE;
            } finally {
                con.Close();
            }

        }

        public static void testCreateUser() {
            byte[] salt = PasswordHashWithPBKDF2.generateSalt();
            byte[] pw = PasswordHashWithPBKDF2.hashPassword("pass", salt);

            Console.WriteLine(String.Format("salt: {0} ; pw: {1}", Convert.ToBase64String(salt), Convert.ToBase64String(pw)));

            createUser("testUser123", pw, salt);
        }

        public static void testUserLogin() {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT PasswordHash, PasswordSalt FROM users WHERE Username = 'testUser123'", con);

            con.Open();
            cmd.ExecuteNonQuery();

            MySqlDataReader reader;
            byte[] salt = null;
            byte[] storedPw = null;

            try {
                reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    salt = (byte[])reader["PasswordSalt"];
                    storedPw = (byte[])reader["PasswordHash"];
                }

                reader.Close();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            bool pw = PasswordHashWithPBKDF2.compareWithStoredPassword("pass", storedPw, salt);
            Console.WriteLine("password is the same: " + pw);
        }

        public static void testDBConnection() {
            MySqlConnection con = getDBConection();
            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE UserId=@UID", con);
            //cmd.Parameters.Add(new MySqlParameter("@UID", 23));
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", con);

            con.Open();
            cmd.ExecuteNonQuery();

            //DataSet ds = new DataSet();
            //MySqlDataAdapter dAdap = new MySqlDataAdapter();
            //dAdap.SelectCommand = cmd;
            //dAdap.Fill(ds, "Username");

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
    }
}
