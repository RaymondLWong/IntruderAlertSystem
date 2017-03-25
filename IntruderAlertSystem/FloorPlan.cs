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
        private const int START_LOCATION = 25;

        private static int floorLength = -1;
        private static int floorHeight = -1;

        private static bool createNewFloorPlan = true;

        public FloorPlan(int a, int b) {
            InitializeComponent();

            floorLength = a;
            floorHeight = b;
            Console.WriteLine($"constructor(); len: {floorLength}, height: {floorHeight}");
            setupNewFloorPlan(floorLength, floorHeight);
            if (newFloorPlan()) {
                //setupNewFloorPlan(floorLength, floorHeight);
            }
        }

        private bool newFloorPlan() {
            Console.WriteLine($"newFloorPlan(); len: {floorLength}, height: {floorHeight}");
            return (floorLength != -1 && floorHeight != -1);
        }

        public static Form getInstance(int length = -1, int height = -1) {
            if (floorPlan == null) {
                floorPlan = new FloorPlan(3, 3);
            }

            Console.WriteLine($"getInstance({length}, {height});");

            if (length != -1 && height != -1) {
                floorLength = length;
                floorHeight = height;
            }

            return floorPlan;
        }

        public static void reset() {
            floorPlan = null;
            createNewFloorPlan = true;
        }

        private DataGridView createFloorPlan(int length, int height) {
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
            dgv.ColumnCount = length;
            dgv.RowCount = height;

            // set start location to top-left corner
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

            return dgv;
        }

        private void setupNewFloorPlan(int length, int height) {
            if (!createNewFloorPlan) { return; }
            // dispose of the existing form
            //getInstance().Dispose();

            // sync values
            floorHeight = height;
            floorLength = length;

            // disallow user resizing or maximising of form
            // http://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-form
            getInstance().FormBorderStyle = FormBorderStyle.FixedSingle;
            getInstance().MaximizeBox = false;

            DataGridView dgv = createFloorPlan(length, height);

            // add table to form
            // Adding Controls to Windows Forms: https://msdn.microsoft.com/en-us/library/aa984255(v=vs.71).aspx
            getInstance().Controls.Add(dgv);

            // set the form size to be the table with some padding
            int padding = START_LOCATION * 2;
            getInstance().ClientSize = new Size(dgv.Height + padding, dgv.Width + padding);

            HomeConfig.getInstance().Show();

            // setup the config to dock to the Floor Plan
            HomeConfig.getInstance().Left = getInstance().Right;
            HomeConfig.getInstance().Top = getInstance().Top;
            getInstance().LocationChanged += FloorPlan_LocationChanged;

            createNewFloorPlan = false;
        }

        private void FloorPlan_Load(object sender, EventArgs e) {
            //if (!newFloorPlan()) {
            //    Console.WriteLine("new floor plan");
            //    setupNewFloorPlan(5, 5);
            //} else {
            //    Console.WriteLine("NO new floor plan");
            //}

            //setupNewFloorPlan(5, 5);
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
