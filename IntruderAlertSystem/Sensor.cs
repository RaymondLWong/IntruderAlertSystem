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
        SensorTypeEnum type;
        string value;

        public Sensor() { }
        public Sensor(SensorTypeEnum type, string value) {
            this.type = type;
            this.value = value;
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
    }
}
