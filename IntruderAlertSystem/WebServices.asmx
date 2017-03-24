<%@ WebService Language="C#" Class="WebService1" %>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Drawing;

//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

namespace IntruderAlertSystem {
    public class WebServices : System.Web.Services.WebService {
        public WebServices() {
            // TODO: Add any constructor code required
        }

        [WebMethod]
        public bool submitReading(int homeID, int roomID, int sensorID, string value, int notificationID = -1) {
            bool success = false;

            return success;
        }

        [WebMethod]
        public XmlDocument checkHome(int homeID) {
            return new XmlDocument();
        }

        [WebMethod]
        public bool resetSystem(int homeID) {
            bool success = false;

            return success;
        }

        [WebMethod]
        public bool toogleSystem(int homeID, bool enable) {
            bool success = false;

            Database.toggleAlarmState(homeID, enable);
                

            return success;
        }
    }

}
