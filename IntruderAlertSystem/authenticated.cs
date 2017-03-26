using System;
using System.Linq;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class authenticated : Form {

        private static authenticated auth = null;
        private static Home home = null;

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
            int size = 2; // set default floor size to 2x2

            // if the user has a home, load it
            // otherwise create a new one

            bool newHome = (home == null);

            if (newHome) {
                size = (int)cboFloorSize.SelectedValue;
            } else {
                // http://stackoverflow.com/questions/4106369/how-do-i-find-the-size-of-a-2d-array
                size = home.Rooms.GetLength(0);
            }

            FloorPlan.getInstance(size, size, newHome).Show();
            getInstance().Hide();
        }

        private void authenticated_Load(object sender, System.EventArgs e) {
            home = Database.getHome(User.UserID);

            // let the user create a new floor plan
            // if they don't have one
            // (TODO: allow user to choose homes and have more than one floor per home)
            if (home == null) {
                setupFloorLengthsForComboBoxes(2, 5);

                setComboboxSelectedItemToLast(ref cboFloorSize);
            } else {
                cboFloorSize.Enabled = false;
                btnCreate.Text = "Load existing floor plan";
                // http://stackoverflow.com/questions/3965694/how-to-resize-a-button-depending-on-its-text
                btnCreate.AutoSize = true;
                btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
        }

        private void setupFloorLengthsForComboBoxes(int min, int limit) {
            min -= 2;
            int[] roomIndexes = new int[limit];

            for (int i = min; i < roomIndexes.Length; i++) {
                roomIndexes[i] = i + 1;
            }

            // BUG: for some reason using Array.Clone() created an extra element at the start (0)
            // but using .skip(1) removes the fake 0 and the actual first element
            // so the minimum number has been decreased by an extra one to counteract the bug
            cboFloorSize.DataSource = roomIndexes.Skip(1).ToArray();
        }

        private void setComboboxSelectedItemToLast(ref ComboBox cbo) {
            cbo.SelectedIndex = cbo.Items.Count - 1;
        }
    }
}
