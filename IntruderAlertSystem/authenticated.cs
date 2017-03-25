using System;
using System.Linq;
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
            int size = (int)cboFloorSize.SelectedValue;

            FloorPlan.getInstance(size, size).Show();
        }

        private void authenticated_Load(object sender, System.EventArgs e) {
            setupFloorLengthsForComboBoxes(2, 5);

            setComboboxSelectedItemToLast(ref cboFloorSize);
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
