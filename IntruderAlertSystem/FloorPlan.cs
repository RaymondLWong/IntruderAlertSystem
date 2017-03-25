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
    public partial class FloorPlan : Form {

        private static FloorPlan floorPlan = null;

        public FloorPlan() {
            InitializeComponent();
        }
        public static Form getInstance() {
            if (floorPlan == null) {
                floorPlan = new FloorPlan();
            }

            return floorPlan;
        }

        private void setupFloorPlan(int length, int height) {
            // TODO: cell sizes don't change on update

            // setup number of rooms
            dgv.ColumnCount = length;
            dgv.RowCount = height;

            int CELL_HEIGHT = dgv.Height / dgv.RowCount;
            int CELL_WIDTH = dgv.Width / dgv.ColumnCount;

            // set cell lengths to be square and decently sized, so it represents a "room"
            foreach (DataGridViewColumn column in dgv.Columns) {
                column.Width = CELL_HEIGHT;
            }

            foreach (DataGridViewRow row in dgv.Rows) {
                row.Height = CELL_WIDTH;
            }
        }

        private void setComboboxSelectedItemToLast(ref ComboBox cbo) {
            cbo.SelectedIndex = cbo.Items.Count - 1;
        }

        private void setupDGV() {
            // Remove headings because we only want cells,
            // which makes the table look more like a floor plan.
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;

            // disable selection of mulitple rooms
            // and don't allow user to resize cells
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // remove the redundant scroll bars
            dgv.ScrollBars = ScrollBars.None;

            // add cell click event handler to dgv
            dgv.CellClick += new DataGridViewCellEventHandler(this.FloorPlan_CellClick);
        }

        private void FloorPlan_Load(object sender, EventArgs e) {
            // disallow user resizing or maximising of form
            // http://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-form
            getInstance().FormBorderStyle = FormBorderStyle.FixedSingle;
            getInstance().MaximizeBox = false;

            setupDGV();

            // setup floor plan cells and combobox values
            const int MAX_ROOMS = 5;
            setupFloorLengthsForComboBoxes(MAX_ROOMS);
            setupFloorPlan(MAX_ROOMS, MAX_ROOMS);

            setComboboxSelectedItemToLast(ref cboHouseHeight);
            setComboboxSelectedItemToLast(ref cboHouseLength);

            HomeConfig.getInstance().Show();
            HomeConfig.getInstance().Left = getInstance().Right;
        }

        private void setupFloorLengthsForComboBoxes(int limit) {
            int[] roomIndexes = new int[limit];

            for (int i = 0; i < roomIndexes.Length; i++) {
                roomIndexes[i] = i + 1;
            }

            cboHouseHeight.DataSource = roomIndexes.Clone();
            cboHouseLength.DataSource = roomIndexes.Clone();
        }

        private void FloorPlan_CellClick(object sender, DataGridViewCellEventArgs e) {
            Console.WriteLine($"x: {e.ColumnIndex}, y: {e.RowIndex}");
        }

        private void FloorPlan_FormClosing(object sender, FormClosingEventArgs e) {
            Common.confirmClose(ref e);
        }

        private void FloorPlan_LocationChanged(object sender, EventArgs e) {
            Form fp = getInstance();
            Point loc = fp.Location;
            Console.WriteLine($"x: {loc.X}, y: {loc.Y}");

            HomeConfig.getInstance().Left = fp.Right;
        }

        private void btnUpdateFloorPlan_Click(object sender, EventArgs e) {
            int length = (int)cboHouseLength.SelectedValue;
            int height = (int)cboHouseHeight.SelectedValue;
            setupFloorPlan(length, height);
        }
    }
}
