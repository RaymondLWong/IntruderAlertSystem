using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntruderAlertSystem {

    /*
     *      HOUSE RELATED ITEMS
     */

    public enum AlarmState {
        Enabled,
        Disabled,
        Triggered
    }

    public class Home {
        int homeID;
        AlarmState state;

        Room[] rooms;
        public Home() { }

        public Home(int homeID, AlarmState state) {
            this.homeID = homeID;
            this.state = state;
        }

        public int HomeID {
            get {
                return homeID;
            }

            set {
                homeID = value;
            }
        }

        public AlarmState State {
            get {
                return state;
            }

            set {
                state = value;
            }
        }

        public Room[] Rooms {
            get {
                return rooms;
            }

            set {
                rooms = value;
            }
        }
    }
}
