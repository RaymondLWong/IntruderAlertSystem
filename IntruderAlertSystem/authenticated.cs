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

        private void btnCreate_Click(object sender, System.EventArgs e) {
            FloorPlan.getInstance(5, 5).Show();
        }
    }
}
