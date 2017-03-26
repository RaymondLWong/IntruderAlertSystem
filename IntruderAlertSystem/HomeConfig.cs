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
    public partial class HomeConfig : Form {
        private static HomeConfig homeConfig = null;

        public HomeConfig() {
            InitializeComponent();
        }
        public static Form getInstance() {
            if (homeConfig == null) {
                homeConfig = new HomeConfig();
            }

            return homeConfig;
        }
    }
}
