using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IntruderAlertSystem {
    class Database {

        private static MySqlConnection con = null;

        public static MySqlConnection getDBConection() {
            if (con == null) {
                con = new MySqlConnection(Properties.Settings.Default.pdcConnectionString);
            }

            return con;
        }

        /*
         *      USER RELATED QUERIES 
         */

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

            bool unique = true;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

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

        /*
         *      ROOM RELATED QUERIES 
         */

        public static Sensor[] getSensorsFromRoom(int roomID) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sensors WHERE roomID = @roomID", con);
            cmd.Parameters.Add(new MySqlParameter("@roomID", roomID));

            Sensor[] sensors = null;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Sensor> sensorList = new List<Sensor>();

                while (reader.Read()) {
                    Sensor sensor = new Sensor();

                    sensor.SensorID = reader.GetInt32("sensorID");
                    sensor.Value = reader.GetString("value");

                    string t = reader.GetString("type");
                    sensor.Type = Common.convertMySQLEnumToCSharpEnum<SensorTypeEnum>(t);

                    string s = reader.GetString("state");
                    sensor.State = Common.convertMySQLEnumToCSharpEnum<AlarmState>(s);

                    sensorList.Add(sensor);
                }

                reader.Close();
                sensors = sensorList.ToArray();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return sensors;
        }

        public static Room[] getRoomsFromFloor(int homeID) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM rooms WHERE homeID = @homeID", con);
            cmd.Parameters.Add(new MySqlParameter("@homeID", homeID));

            Room[] rooms = null;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Room> roomList = new List<Room>();

                while (reader.Read()) {
                    Room room = new Room();

                    room.RoomID = reader.GetInt32("roomID");
                    room.X = reader.GetInt32("xLocation");
                    room.Y = reader.GetInt32("yLocation");
                    room.DoorLocations = reader.GetString("doorLocations");

                    string t = reader.GetString("type");
                    room.Type = Common.convertMySQLEnumToCSharpEnum<RoomType>(t);

                    string c = reader.GetString("category");
                    room.Category = Common.convertMySQLEnumToCSharpEnum<RoomCategory>(c);

                    roomList.Add(room);
                }

                reader.Close();
                rooms = roomList.ToArray();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return rooms;
        }

        public static Room[] getRoomsAndSensorsFromFloor(int homeID) {
            Room[] rooms = getRoomsFromFloor(homeID);

            if (rooms != null) {
                foreach (Room room in rooms) {
                    room.Sensors = getSensorsFromRoom(room.RoomID);
                }
            }

            return rooms;
        }

        public static Home getHome(int homeID) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM home WHERE homeID = @homeID", con);
            cmd.Parameters.Add(new MySqlParameter("@homeID", homeID));

            Home home = null;

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    home = new Home();
                    home.HomeID = reader.GetInt32("homeID");

                    string s = reader.GetString("alarmState");
                    home.State = Common.convertMySQLEnumToCSharpEnum<AlarmState>(s);
                } else {
                    Console.WriteLine($"No home with ID of '{homeID}' found.");
                }

                reader.Close();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return home;
        }
    }
}
