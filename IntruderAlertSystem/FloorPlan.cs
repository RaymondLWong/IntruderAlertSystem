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
            // https://msdn.microsoft.com/en-us/library/aa984255(v=vs.71).aspx
            DataGridView dgv = new DataGridView();
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;

            // setup dgv cells
            dgv.ColumnCount = 5;
            dgv.RowCount = 5;

            const int START_LOCATION = 25;
            dgv.Location = new Point(START_LOCATION, START_LOCATION);
            const int CELL_LENGTH = 100;

            foreach (DataGridViewColumn column in dgv.Columns) {
                column.Width = CELL_LENGTH;
            }

            foreach (DataGridViewRow row in dgv.Rows) {
                row.Height = CELL_LENGTH;
            }

            // set the size
            dgv.Width = (CELL_LENGTH / 4) + (dgv.ColumnCount * CELL_LENGTH);
            dgv.Height = (CELL_LENGTH / 4) + (dgv.RowCount * CELL_LENGTH);

            // add table to form
            getInstance().Controls.Add(dgv);
        }

        private void FloorPlan_FormClosing(object sender, FormClosingEventArgs e) {
            Common.confirmClose(ref e);
        }
    }
}
