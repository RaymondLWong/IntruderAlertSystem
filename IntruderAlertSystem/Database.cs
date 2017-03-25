using MySql.Data.MySqlClient;
using System;

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
            MySqlCommand cmd = new MySqlCommand(@"
INSERT INTO users (
    Username, 
    PasswordHash, 
    PasswordSalt
) VALUES (
    @uname,
    @pw,
    @salt
)", con);

            // http://stackoverflow.com/questions/17185739/saving-byte-array-to-mysql
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

        public static bool authenticateUser(string username, string password) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT UserID, PasswordHash, PasswordSalt FROM users WHERE Username = @uname", con);
            cmd.Parameters.Add(new MySqlParameter("@uname", username));

            //Console.WriteLine(String.Format("sql: {0}", cmd.CommandText));

            MySqlDataReader reader;
            byte[] salt = null;
            byte[] storedPw = null;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    User.UserID = reader.GetInt32("UserID");

                    salt = (byte[])reader["PasswordSalt"];
                    storedPw = (byte[])reader["PasswordHash"];
                } else {
                    Console.WriteLine(String.Format("Username '{0}' not found.", username));
                }

                reader.Close();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            if (salt == null || storedPw == null) {
                return false;
            }

            return PasswordHashWithPBKDF2.compareWithStoredPassword(password, storedPw, salt);
        }

        public static bool checkUsernameUnique(string username) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT Username FROM users WHERE Username = @user", con);
            cmd.Parameters.Add(new MySqlParameter("@user", username));

            con.Open();
            cmd.ExecuteNonQuery();

            MySqlDataReader reader;
            bool unique = true;

            try {
                reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    unique = false;
                }

                reader.Close();

            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return unique;
        }
    }
}
