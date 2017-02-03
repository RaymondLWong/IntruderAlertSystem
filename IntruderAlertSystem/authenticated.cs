using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class authenticated : Form {

        private static authenticated auth = null;

        public static Form getInstance() {
            if (auth == null) {
                auth = new authenticated();
            }

            return auth;
        }

        public authenticated() {
            InitializeComponent();
        }
    }
}
