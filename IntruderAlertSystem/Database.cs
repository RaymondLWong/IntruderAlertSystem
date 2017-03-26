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

        public static Home getHome(int userID) {
            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM home WHERE userID = @userID", con);
            cmd.Parameters.Add(new MySqlParameter("@userID", userID));

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

                    int length = reader.GetInt32("xLength");
                    int height = reader.GetInt32("YLength");

                    home.Rooms = new Room[length, height];
                } else {
                    Console.WriteLine($"No home with user ID of '{userID}' found.");
                }

                reader.Close();
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return home;
        }

        public static Home getHomeAndRooms(int userID) {
            Home home = getHome(userID);

            if (home != null) {
                Room[] rooms = getRoomsAndSensorsFromFloor(home.HomeID);

                foreach (Room room in rooms) {
                    home.Rooms[room.X, room.Y] = room;
                }
            }

            return home;
        }

        public static bool updateSensor(Sensor sensor) {
            // TODO: update sensor properties or just force user to add/remove instead?
            bool success = false;

            string s = "UPDATE `sensors` SET `roomID`=2,`type`='Entry',`state`='Enabled',`value`='value' WHERE sensorID = 7;";

            return success;
        }

        public static bool insertHomeIntoDB(Home home, out int homeID) {
            bool success = false;

            // http://stackoverflow.com/questions/4260207/how-do-you-get-the-width-and-height-of-a-multi-dimensional-array
            int length = home.Rooms.GetLength(0);
            int height = home.Rooms.GetLength(1);

            string state = Common.convertCSharpEnumToMySQLEnum(home.State);

            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand(@"
INSERT INTO home (
    `userID`,
    `xLength`,
    `yLength`, 
    `alarmState`
) VALUES (
    @userID, 
    @length,
    @height,
    @state
);", con);

            // http://stackoverflow.com/questions/17185739/saving-byte-array-to-mysql
            MySqlParameter paramUserID = new MySqlParameter("@userID", MySqlDbType.Int32);
            MySqlParameter paramLength = new MySqlParameter("@length", MySqlDbType.Int32);
            MySqlParameter paramHeight = new MySqlParameter("@height", MySqlDbType.Int32);
            MySqlParameter paramState = new MySqlParameter("@state", MySqlDbType.VarChar);

            paramUserID.Value = User.UserID;
            paramLength.Value = length;
            paramHeight.Value = height;
            paramState.Value = state;

            cmd.Parameters.Add(paramUserID);
            cmd.Parameters.Add(paramLength);
            cmd.Parameters.Add(paramHeight);
            cmd.Parameters.Add(paramState);

            try {
                con.Open();
                cmd.ExecuteNonQuery();
                homeID = (int)cmd.LastInsertedId;

                success = true;
            } catch (MySqlException MySqlE) {
                throw MySqlE;
            } finally {
                con.Close();
            }

            return success;
        }

        public static bool saveHomeToDB(Home home) {
            bool success = false;

            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand(@"
UPDATE `home` 
SET 
    `userID` = @userID,
    `xLength` = @length,
    `yLength` = @height,
    `alarmState` = @state
WHERE 
    homeID = @homeiD
", con);
            MySqlParameter paramHomeID = new MySqlParameter("@homeiD", MySqlDbType.Int32);
            MySqlParameter paramUserID = new MySqlParameter("@userID", MySqlDbType.Int32);
            MySqlParameter paramLength = new MySqlParameter("@length", MySqlDbType.Int32);
            MySqlParameter paramHeight = new MySqlParameter("@height", MySqlDbType.Int32);
            MySqlParameter paramState = new MySqlParameter("@state", MySqlDbType.VarChar);

            string state = Common.convertCSharpEnumToMySQLEnum(home.State);

            paramHomeID.Value = home.HomeID;
            paramUserID.Value = User.UserID;
            paramLength.Value = home.Rooms.GetLength(0);
            paramHeight.Value = home.Rooms.GetLength(1);
            paramState.Value = state;

            cmd.Parameters.Add(paramHomeID);
            cmd.Parameters.Add(paramUserID);
            cmd.Parameters.Add(paramLength);
            cmd.Parameters.Add(paramHeight);
            cmd.Parameters.Add(paramState);

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                success = true;
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return success;
        }

        public static bool saveRoom(int homeID, Room room) {
            // TODO: currently the room is insertered into the database
            // without checking for existing rooms (to save time).
            // this means that a retrieved room for a particular co-ordinate could
            // be overwritten by another room (same co-ords, different id and info)

            bool success = false;

            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand(@"
INSERT INTO `rooms` ( 
    `homeID`, 
    `xLocation`, 
    `yLocation`, 
    `category`, 
    `type`, 
    `doorLocations`
) VALUES (
    @homeID,
    @x,
    @y,
    @category,
    @type,
    @doorLocations
)
", con);
            MySqlParameter paramHomeID = new MySqlParameter("@homeiD", MySqlDbType.Int32);
            MySqlParameter paramX = new MySqlParameter("@x", MySqlDbType.Int32);
            MySqlParameter paramY = new MySqlParameter("@y", MySqlDbType.Int32);
            MySqlParameter paramCategory= new MySqlParameter("@category", MySqlDbType.VarChar);
            MySqlParameter paramType = new MySqlParameter("@type", MySqlDbType.VarChar);
            MySqlParameter paramDoorLocations = new MySqlParameter("@doorLocations", MySqlDbType.VarChar);
            
            paramHomeID.Value = homeID;
            paramX.Value = room.X;
            paramY.Value = room.Y;
            paramCategory.Value = Common.convertCSharpEnumToMySQLEnum(room.Category);
            paramType.Value = Common.convertCSharpEnumToMySQLEnum(room.Type);
            paramDoorLocations.Value = room.DoorLocations;

            cmd.Parameters.Add(paramHomeID);
            cmd.Parameters.Add(paramX);
            cmd.Parameters.Add(paramY);
            cmd.Parameters.Add(paramCategory);
            cmd.Parameters.Add(paramType);
            cmd.Parameters.Add(paramDoorLocations);

            try {
                con.Open();
                cmd.ExecuteNonQuery();

                success = true;
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return success;
        }

        public static bool addSensor(Sensor sensor, int roomID, out int sensorID) {
            bool success = false;

            MySqlConnection con = getDBConection();
            MySqlCommand cmd = new MySqlCommand(@"
INSERT INTO `sensors` (
    `roomID`, 
    `type`, 
    `state`, 
    `value`
) VALUES (
    @roomID,
    @type,
    @state,
    @value
)
", con);
            MySqlParameter paramRoomID = new MySqlParameter("@roomID", MySqlDbType.Int32);
            MySqlParameter paramType = new MySqlParameter("@type", MySqlDbType.VarChar);
            MySqlParameter paramState = new MySqlParameter("@state", MySqlDbType.VarChar);
            MySqlParameter paramValue = new MySqlParameter("@value", MySqlDbType.VarChar);

            paramRoomID.Value = roomID;
            paramType.Value = Common.convertCSharpEnumToMySQLEnum(sensor.Type);
            paramState.Value = Common.convertCSharpEnumToMySQLEnum(sensor.State);
            paramValue.Value = sensor.Value;

            cmd.Parameters.Add(paramRoomID);
            cmd.Parameters.Add(paramType);
            cmd.Parameters.Add(paramState);
            cmd.Parameters.Add(paramValue);

            try {
                con.Open();
                cmd.ExecuteNonQuery();
                sensorID = (int)cmd.LastInsertedId;

                success = true;
            } catch (Exception ex) {
                throw ex;
            } finally {
                con.Close();
            }

            return success;
        }
    }
}
