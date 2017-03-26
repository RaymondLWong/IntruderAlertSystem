using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntruderAlertSystem {

    /*
     *      SENSOR RELATED ITEMS
     */

    public enum SensorTypeEnum {
        Motion,
        Fire,
        Vibration,
        Glass_break,
        Entry
    }
    public class Sensor {
        int sensorID = -1;
        SensorTypeEnum type;
        AlarmState state;
        string value;

        public Sensor() { }
        public Sensor(int sensorID, SensorTypeEnum type, AlarmState state, string value) {
            this.sensorID = sensorID;
            this.type = type;
            this.state = state;
            this.value = value;
        }

        public int SensorID {
            get {
                return sensorID;
            }

            set {
                sensorID = value;
            }
        }

        public SensorTypeEnum Type {
            get {
                return type;
            }

            set {
                type = value;
            }
        }

        public string Value {
            get {
                return value;
            }

            set {
                this.value = value;
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
    }
}
