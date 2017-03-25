using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntruderAlertSystem
{

    /*
     *      ROOM RELATED ITEMS
     */

    public enum RoomCategory {
        End_Room,
        Middle_Room
    }

    public enum RoomType {
        Bedroom,
        Kitchen,
        Living_Room,
        Bathroom,
        Corridor
    }

    public class Room {
        int roomID;

        RoomCategory category;
        RoomType type;

        int length;
        int height;

        string doorLocations = "";

        Sensor[] sensors;

        public Room() { }

        public Room(RoomCategory category, RoomType type, int length, int height, string doorLocations) {
            this.category = category;
            this.type = type;
            this.length = length;
            this.height = height;
            this.doorLocations = doorLocations;
        }

        public int RoomID {
            get {
                return roomID;
            }

            set {
                roomID = value;
            }
        }

        public RoomCategory Category {
            get {
                return category;
            }

            set {
                category = value;
            }
        }

        public RoomType Type {
            get {
                return type;
            }

            set {
                type = value;
            }
        }

        public int Length {
            get {
                return length;
            }

            set {
                length = value;
            }
        }

        public int Height {
            get {
                return height;
            }

            set {
                height = value;
            }
        }

        public string DoorLocations {
            get {
                return doorLocations;
            }

            set {
                doorLocations = value;
            }
        }

        public Sensor[] Sensors {
            get {
                return sensors;
            }

            set {
                sensors = value;
            }
        }
    }
}
