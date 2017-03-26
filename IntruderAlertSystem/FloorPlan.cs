﻿using System;
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
        private static Home home = null;
        private const int MAX_ROOMS = 5;

        private static int START_LENGTH = 5;
        private static int START_HEIGHT = 5;

        private static int testX = 2;
        private static int testY = 3;

        public FloorPlan() {
            InitializeComponent();
        }

        public static Form getInstance(int length = -1, int height = -1) {
            if (floorPlan == null) {
                if (length != -1 && height != -1) {
                    START_LENGTH = length;
                    START_HEIGHT = height;
                }

                floorPlan = new FloorPlan();
            }

            return floorPlan;
        }

        private void mapHome() {
            home = new Home();

            home.HomeID = 1;

            Room r = new Room(1, RoomCategory.End_Room, RoomType.Bathroom, testX, testY, "NESW");

            home.Rooms = new Room[MAX_ROOMS, MAX_ROOMS];
            home.Rooms[r.X, r.Y] = r;
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

            // change the border style to allow custom painting of cell borders
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

            // add cell click event handler to dgv
            dgv.CellClick += new DataGridViewCellEventHandler(this.FloorPlan_CellClick);
        }

        private void test() {
            Sensor[] sList = Database.getSensorsFromRoom(1);

            foreach (Sensor s in sList) {
                Console.WriteLine($"sensor reading: {s.Value}");
            }

            Room[] rList = Database.getRoomsAndSensorsFromFloor(1);

            foreach (Room r in rList) {
                Console.WriteLine($"doors located at: {r.DoorLocations}");
                Console.WriteLine($"number of sensors in room: {r.Sensors.Length}");
            }

            // TODO: chain call so getFloorsFromHome/getHome gets all objects (including arrays)
            Home h = Database.getHomeAndRooms(User.UserID);

            Console.WriteLine($"Home alarm is {h.State}");
        }

        private void FloorPlan_Load(object sender, EventArgs e) {
            // disallow user resizing or maximising of form
            // http://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-form
            getInstance().FormBorderStyle = FormBorderStyle.FixedSingle;
            getInstance().MaximizeBox = false;

            setupDGV();

            // setup floor plan cells and combobox values
            setupFloorPlan(START_LENGTH, START_HEIGHT);

            // fetch the room information from the database
            test();
            mapHome();

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

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            // override cell border painting to allow custom borders for door locations
            // source: http://stackoverflow.com/questions/32154847/how-do-you-draw-a-border-around-a-datagridview-cell-while-its-being-edited

            if (e.ColumnIndex > -1 & e.RowIndex > -1) {

                Color DOOR_COLOUR = Color.Black;
                int DOOR_BORDER_WIDTH = 5;

                // Pen for left and top borders
                using (var backGroundPen = new Pen(e.CellStyle.BackColor, 1))
                // Pen for bottom and right borders
                using (var gridlinePen = new Pen(dgv.GridColor, 1))
                // Pen for selected cell borders
                using (var selectedPen = new Pen(DOOR_COLOUR, DOOR_BORDER_WIDTH)) {

                    var topLeftPoint = new Point(e.CellBounds.Left, e.CellBounds.Top);
                    var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                    var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    var bottomleftPoint = new Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);

                    // remove the if
                    if (e.ColumnIndex == testX && e.RowIndex == testY) {
                        string doorLocations = home.Rooms[e.ColumnIndex, e.RowIndex].DoorLocations;
                        Console.WriteLine($"Doors will be painted at the {doorLocations} side(s).");

                        bool north = doorLocations.Contains("N");
                        bool east = doorLocations.Contains("E");
                        bool south = doorLocations.Contains("S");
                        bool west = doorLocations.Contains("W");

                        // Paint all parts except borders.
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                        // Top border of first row cells should be in background color
                        if (e.RowIndex == 0) {
                            e.Graphics.DrawLine(backGroundPen, topLeftPoint, topRightPoint);
                        } else {
                            // Top border of non-first row cells should be in gridLine color, and they should be drawn here after right border
                            Pen borderPen = (north) ? selectedPen : backGroundPen;
                            if (e.RowIndex > 0) {
                                e.Graphics.DrawLine(borderPen, topLeftPoint, topRightPoint);
                            }
                        }

                        // Right border of last column cells should be in gridLine color
                        if (e.ColumnIndex == dgv.ColumnCount - 1) {
                            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);
                        } else {
                            //Right border of non-last column cells should be in background color
                            Pen borderPen = (east) ? selectedPen : backGroundPen;
                            e.Graphics.DrawLine(borderPen, bottomRightPoint, topRightPoint);
                        }

                        // Bottom border of last row cells should be in gridLine color
                        if (e.RowIndex == dgv.RowCount - 1) {
                            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, bottomleftPoint);
                        } else {
                            // Bottom border of non-last row cells should be in background color
                            Pen borderPen = (south) ? selectedPen : backGroundPen;
                            e.Graphics.DrawLine(borderPen, bottomleftPoint, bottomRightPoint);
                        }

                        // Left border of first column cells should be in background color
                        if (e.ColumnIndex == 0) {
                            e.Graphics.DrawLine(backGroundPen, topLeftPoint, bottomleftPoint);
                        } else {
                            // Left border of non-first column cells should be in gridLine color, and they should be drawn here after bottom border
                            Pen borderPen = (west) ? selectedPen : backGroundPen;
                            if (e.ColumnIndex > 0) {
                                e.Graphics.DrawLine(borderPen, topLeftPoint, bottomleftPoint);
                            }
                        }

                        // We handled painting for this cell, Stop default rendering.
                        e.Handled = true;
                    }
                }
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e) {
            // disable arrow key navigation to prevent the user from scrolling to far down
            // moving the cells one row up (hidin them) and showing blank space
            // https://www.codeproject.com/Questions/844000/How-do-I-disable-arrow-keys-while-editing-datagrid
            switch (e.KeyData & Keys.KeyCode) {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }
    }

    public enum CompassPoint {
        North,
        East,
        South,
        West
    }
}
