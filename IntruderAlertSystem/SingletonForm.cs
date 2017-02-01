using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public class SingletonForm : Form {
        // source: http://stackoverflow.com/questions/3005732/showing-a-hidden-form

        private static Form form = null;

        private static Form getInstance() {
            if (form == null) {
                form = new Form();
            }

            return form;
        }

        protected static void showForm() {
            getInstance().Show();
        }

        protected static void hideForm() {
            getInstance().Hide();
        }

        protected static void closeForm() {
            // TODO: is this method neccessary?
            getInstance().Close();
        }
    }
}
