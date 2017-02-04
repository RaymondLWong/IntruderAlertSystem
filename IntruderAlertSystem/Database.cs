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

        public static bool checkUserDoesNotExist(string username) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT Username FROM users WHERE Username = @uname", con);

            MySqlParameter paramUsername = new MySqlParameter("@uname", MySqlDbType.VarChar);
            paramUsername.Value = username;
            cmd.Parameters.Add(paramUsername);

            bool userExists = false;
            MySqlDataReader reader;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    userExists = true;
                }

                reader.Close();
            } catch (MySqlException MySqlE) {
                throw MySqlE;
            } finally {
                con.Close();
            }

            return !userExists;
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

        public static bool authenticateUser(string username, string password) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT PasswordHash, PasswordSalt FROM users WHERE Username = @uname", con);
            cmd.Parameters.Add(new MySqlParameter("@uname", username));

            //Console.WriteLine(String.Format("sql: {0}", cmd.CommandText));

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
    }
}
