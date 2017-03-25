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
        private void FloorPlan_Load(object sender, EventArgs e) {
            // disallow user resizing or maximising of form
            // http://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-form
            getInstance().FormBorderStyle = FormBorderStyle.FixedSingle;
            getInstance().MaximizeBox = false;

            // use a table as base for floor plan visualisation
            DataGridView dgv = new DataGridView();
            // Remove headings because we only want cells,
            // which makes the table look more like a floor plan.
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;

            // disable selection of mulitple rooms
            // and don't allow user to resize cells
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // setup number of rooms
            dgv.ColumnCount = 5;
            dgv.RowCount = 5;

            // set start location to top-left corner
            const int START_LOCATION = 25;
            dgv.Location = new Point(START_LOCATION, START_LOCATION);

            // set cell lengths to be square and decently sized, so it represents a "room"
            const int CELL_LENGTH = 100;

            foreach (DataGridViewColumn column in dgv.Columns) {
                column.Width = CELL_LENGTH;
            }

            foreach (DataGridViewRow row in dgv.Rows) {
                row.Height = CELL_LENGTH;
            }

            // set the size of the table to be the perfect fit (no scroll bars / blank space)
            // http://stackoverflow.com/questions/7412098/fit-datagridview-size-to-rows-and-columnss-total-size
            // http://stackoverflow.com/questions/6651487/programmatically-resize-datagridview-to-remove-scroll-bars
            int borderOffset = (dgv.BorderStyle == BorderStyle.None) ? 0 : 2;

            int newHeight = dgv.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + borderOffset;
            int newWidth = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + borderOffset;

            // set the adjusted size and remove the redundant scroll bars
            dgv.ClientSize = new Size(newHeight, newWidth);
            dgv.ScrollBars = ScrollBars.None;

            // add cell click event to dgv
            dgv.CellClick += new DataGridViewCellEventHandler(this.FloorPlan_CellClick);

            // add table to form
            // Adding Controls to Windows Forms: https://msdn.microsoft.com/en-us/library/aa984255(v=vs.71).aspx
            getInstance().Controls.Add(dgv);

            // set the form size to be the table with some padding
            int padding = START_LOCATION * 2;
            getInstance().ClientSize = new Size(dgv.Height + padding, dgv.Width + padding);

            HomeConfig.getInstance().Show();
            HomeConfig.getInstance().Left = getInstance().Right;
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
    }
}
