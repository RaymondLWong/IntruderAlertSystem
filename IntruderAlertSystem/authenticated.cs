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
            int length = (int)cboFloorLength.SelectedValue;
            int height = (int)cboFloorHeight.SelectedValue;

            FloorPlan.getInstance(length, height).Show();
        }

        private void authenticated_Load(object sender, System.EventArgs e) {
            int[] roomIndexes = new int[5];

            for (int i = 0; i < roomIndexes.Length; i++) {
                roomIndexes[i] = i + 1;
            }

            cboFloorHeight.DataSource = roomIndexes.Clone();
            cboFloorLength.DataSource = roomIndexes.Clone();
        }
    }
}
