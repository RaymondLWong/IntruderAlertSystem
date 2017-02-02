using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
