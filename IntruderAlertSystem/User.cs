using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntruderAlertSystem {
    public class User {
        private static int userID = -1;

        public static int UserID {
            get {
                return userID;
            }

            set {
                userID = value;
            }
        }
    }
}
