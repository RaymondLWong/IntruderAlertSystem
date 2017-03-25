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

        private void btnUpdateSize_Click(object sender, EventArgs e) {
            int length = (int)cboHouseLength.SelectedValue;
            int height = (int)cboHouseHeight.SelectedValue;
            Console.WriteLine($"length: {length}, height: {height}");

            FloorPlan.reset();
            FloorPlan.getInstance(length, height);
        }

        private void HomeConfig_Load(object sender, EventArgs e) {
            int MAX_ROOMS = 5;
            int[] roomIndexes = new int[MAX_ROOMS];

            for (int i = 0; i < roomIndexes.Length; i++) {
                roomIndexes[i] = i + 1;
            }

            cboHouseHeight.DataSource = roomIndexes.Clone();
            cboHouseLength.DataSource = roomIndexes.Clone();
        }
    }
}
