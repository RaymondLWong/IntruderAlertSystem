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
        private static Home home = null;

        // hard-cap the max-dimension of a floor
        private const int MAX_ROOMS = 5;
        // set the default floor size to 5x5
        private static int FLOOR_LENGTH = 5;
        private static int FLOOR_HEIGHT = 5;

        // setup some constants that denote the type of room
        // which is a sub-category of a Rom Category
        RoomType[] END_ROOMS = {
            RoomType.Bedroom,
            RoomType.Bathroom,
            RoomType.Kitchen
        };

        RoomType[] MIDDLE_ROOMS = {
            RoomType.Corridor,
            RoomType.Living_Room
        };

        public FloorPlan() {
            InitializeComponent();
        }

        public static Form getInstance(int length = -1, int height = -1, bool newHome = false) {
            // this substitutes the constructor call as a Singleton pattern is used
            if (floorPlan == null) {
                // if a new FloorPlan is requested, change it to the requested size
                if (length != -1 && height != -1) {
                    FLOOR_LENGTH = length;
                    FLOOR_HEIGHT = height;
                }

                // if the user already has a home, fetch the existing one
                // later this can change so the user can select an existing one / create a new one
                // but for now dealing with one per user is easier
                if (newHome) {
                    FloorPlan.home = new Home();
                } else {
                    FloorPlan.home = Database.getHomeAndRooms(User.UserID);
                }

                floorPlan = new FloorPlan();
            }

            return floorPlan;
        }

        private void setupFloorPlan(int length, int height) {
            // TODO: non-square cell sizes don't always change on update
            txtFloorLength.Text = length.ToString();
            txtFloorHeight.Text = height.ToString();

            // setup number of rooms
            dgv.ColumnCount = length;
            dgv.RowCount = height;

            int CELL_HEIGHT = dgv.Height / dgv.RowCount;
            int CELL_WIDTH = dgv.Width / dgv.ColumnCount;

            // make font relative to cell width
            // font properties copied from designer auto-gen code, with Font Size changed
            int FONT_SIZE = (int)Math.Round(CELL_WIDTH * 0.08);
            Font CELL_FONT = new Font("Verdana", FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // set cell lengths to be square and decently sized, so it represents a "room"
            // also set the cell text to be centred in the middle
            // https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridviewcellstyle.alignment(v=vs.110).aspx
            foreach (DataGridViewColumn column in dgv.Columns) {
                column.Width = CELL_HEIGHT;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Font = CELL_FONT;
            }

            foreach (DataGridViewRow row in dgv.Rows) {
                row.Height = CELL_WIDTH;
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.DefaultCellStyle.Font = CELL_FONT;
            }

            loopThroughRoomsAndExtractOverview();
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

        private void FloorPlan_Load(object sender, EventArgs e) {
            // disallow user resizing or maximising of form
            // http://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-form
            getInstance().FormBorderStyle = FormBorderStyle.FixedSingle;
            getInstance().MaximizeBox = false;

            setupDGV();

            // setup floor plan cells and textbox values
            setupFloorPlan(FLOOR_LENGTH, FLOOR_HEIGHT);

            // setup combo box for home's alarm state
            Common.fillComboBoxFromEnum<AlarmState>(ref cboAlarmState);
            if (home.HomeID != -1) {
                // load the state from the DB if the home previously existed
                cboAlarmState.SelectedItem = home.State;
            }

            // fetch the room information from the database
            Common.fillComboBoxFromEnum<RoomCategory>(ref cboCategory);
            Common.fillListBoxFromEnum<CompassPoint>(ref clbDoorLocations);

            int x = dgv.SelectedCells[0].ColumnIndex;
            int y = dgv.SelectedCells[0].RowIndex;

            setupRoomInformation(x, y);

            HomeConfig.getInstance().Show();
            HomeConfig.getInstance().Left = getInstance().Right;
        }

        private void preventDoorSelectionAtEdges() {
            // limit doors to inside the house (no doors at edges)

            int cellX;
            int cellY;

            // get the cell locations to compare with edges
            Common.getDGVSelectedIndexes(dgv, out cellX, out cellY);

            // http://stackoverflow.com/questions/3816718/how-to-get-an-array-of-all-enum-values-in-c
            List<CompassPoint> compassPoints = Enum.GetValues(typeof(CompassPoint)).Cast<CompassPoint>().ToList();

            // left-hand edges can't have doors on the left wall,
            // right-hand edge can't have doors on right wall etc.

            // prevent doors at left edge
            if (cellX == 0) {
                compassPoints.Remove(CompassPoint.West);
            }

            // prevent doors at right edge
            if (cellX == dgv.ColumnCount - 1) {
                compassPoints.Remove(CompassPoint.East);
            }

            // prevent doors at top edge
            if (cellY == 0) {
                compassPoints.Remove(CompassPoint.North);
            }

            // prevent doors at bottom edge
            if (cellY == dgv.RowCount - 1) {
                compassPoints.Remove(CompassPoint.South);
            }

            clbDoorLocations.DataSource = compassPoints;
        }

        private void checkItemIfExists(ref CheckedListBox clb, Enum e) {
            // http://stackoverflow.com/questions/370820/how-do-i-programmatically-check-an-item-in-a-checkedlistbox-in-c-sharp
            if (clb.Items.Contains(e)) {
                int i = clb.Items.IndexOf(e);
                clb.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void uncheckCheckListBoxItems(ref CheckedListBox clb) {
            // uncheck list items in the specified CheckedListBox
            while (clb.CheckedIndices.Count > 0) {
                clb.SetItemChecked(clb.CheckedIndices[0], false);
            }
        }

        private void setDoorsFromString(string doorLocations) {
            // uncheck all checked items
            uncheckCheckListBoxItems(ref clbDoorLocations);

            // check door in 
            if (doorLocations.Contains("N")) {
                checkItemIfExists(ref clbDoorLocations, CompassPoint.North);
            }

            if (doorLocations.Contains("E")) {
                checkItemIfExists(ref clbDoorLocations, CompassPoint.East);
            }

            if (doorLocations.Contains("S")) {
                checkItemIfExists(ref clbDoorLocations, CompassPoint.South);
            }

            if (doorLocations.Contains("W")) {
                checkItemIfExists(ref clbDoorLocations, CompassPoint.West);
            }
        }

        private void loadRoomInformation(int x, int y) {
            // retrieve the room information form the object (if the info exists)
            // and load them into the appropriate controls
            if (home.Rooms == null) { return; }
            Room room = home.Rooms[x, y];

            if (room == null) { return; }

            cboCategory.SelectedItem = room.Category;
            cboType.SelectedItem = room.Type;

            setDoorsFromString(room.DoorLocations);

            loadSensorIDsFromSensors(ref room);
        }

        private void loadSensorIDsFromSensors(ref Room room) {
            // extract sensor IDs from array and stick them in the drop down
            // http://stackoverflow.com/questions/4765084/convert-a-list-of-objects-to-an-array-of-one-of-the-objects-properties
            cboSensorList.DataSource = room.Sensors.Select((sensor) => sensor.SensorID).ToArray();
        }

        private void setupRoomInformation(int x, int y) {
            // setup the room's information, including hididing invlaid door placement
            preventDoorSelectionAtEdges();
            loadRoomInformation(x, y);
            setupSensorProperties();
        }

        private void FloorPlan_CellClick(object sender, DataGridViewCellEventArgs e) {
            int x = e.ColumnIndex;
            int y = e.RowIndex;

            // show cell location in textboxes
            txtRoomXLocation.Text = x.ToString();
            txtRoomYLocation.Text = y.ToString();

            setupRoomInformation(x, y);
        }

        private void FloorPlan_FormClosing(object sender, FormClosingEventArgs e) {
            Common.confirmClose(ref e);
        }

        private void FloorPlan_LocationChanged(object sender, EventArgs e) {
            Form fp = getInstance();
            Point loc = fp.Location;

            HomeConfig.getInstance().Left = fp.Right;
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            // override cell border painting to allow custom borders for door locations
            // source: http://stackoverflow.com/questions/32154847/how-do-you-draw-a-border-around-a-datagridview-cell-while-its-being-edited

            if (e.ColumnIndex > -1 & e.RowIndex > -1) {

                // set door pen options
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

                    string doorLocations = "";

                    if (home.Rooms != null && home.Rooms[e.ColumnIndex, e.RowIndex] != null) {
                        doorLocations = home.Rooms[e.ColumnIndex, e.RowIndex].DoorLocations;
                    }

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
                        Pen borderPen = (north) ? selectedPen : gridlinePen;
                        if (e.RowIndex > 0) {
                            e.Graphics.DrawLine(borderPen, topLeftPoint, topRightPoint);
                        }
                    }

                    // Right border of last column cells should be in gridLine color
                    if (e.ColumnIndex == dgv.ColumnCount - 1) {
                        e.Graphics.DrawLine(backGroundPen, bottomRightPoint, topRightPoint);
                    } else {
                        //Right border of non-last column cells should be in background color
                        Pen borderPen = (east) ? selectedPen : gridlinePen;
                        e.Graphics.DrawLine(borderPen, bottomRightPoint, topRightPoint);
                    }

                    // Bottom border of last row cells should be in gridLine color
                    if (e.RowIndex == dgv.RowCount - 1) {
                        e.Graphics.DrawLine(backGroundPen, bottomRightPoint, bottomleftPoint);
                    } else {
                        // Bottom border of non-last row cells should be in background color
                        Pen borderPen = (south) ? selectedPen : gridlinePen;
                        e.Graphics.DrawLine(borderPen, bottomleftPoint, bottomRightPoint);
                    }

                    // Left border of first column cells should be in background color
                    if (e.ColumnIndex == 0) {
                        e.Graphics.DrawLine(backGroundPen, topLeftPoint, bottomleftPoint);
                    } else {
                        // Left border of non-first column cells should be in gridLine color, and they should be drawn here after bottom border
                        Pen borderPen = (west) ? selectedPen : gridlinePen;
                        if (e.ColumnIndex > 0) {
                            e.Graphics.DrawLine(borderPen, topLeftPoint, bottomleftPoint);
                        }
                    }

                    // We handled painting for this cell, Stop default rendering.
                    e.Handled = true;
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

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e) {
            RoomCategory category = (RoomCategory) cboCategory.SelectedValue;
            if (category == RoomCategory.End_Room) {
                cboType.DataSource = END_ROOMS.Clone();
            } else if (category == RoomCategory.Middle_Room) {
                cboType.DataSource = MIDDLE_ROOMS.Clone();
            }
        }

        private void clbDoorLocations_ItemCheck(object sender, ItemCheckEventArgs e) {
            // TODO: save to room
        }

        private bool checkDoorIsValid(Room room) {
            // check if corresponding room has corresponding door
            return true;
        }

        private bool checkFloorPlanIsValid() {
            // loop through each room
            // and check door locations

            return true;
        }

        private void cboSensorList_SelectedIndexChanged(object sender, EventArgs e) {
            // load sensor information
            int x, y;
            Common.getDGVSelectedIndexes(dgv, out x, out y);
            Room room = home.Rooms[x, y];
            loadSensorInformation(room, cboSensorList.SelectedIndex);
        }

        private void updateSensorInfo() {
            int x, y;
            Common.getDGVSelectedIndexes(dgv, out x, out y);

            string newSensorValue = txtSensorValue.Text;

            int index = cboSensorList.SelectedIndex;
            if (home.Rooms[x, y].Sensors[index].Type != (SensorTypeEnum)cboSensorType.SelectedValue) {
                newSensorValue = "";
            }

            home.Rooms[x, y].Sensors[index].Type = (SensorTypeEnum)cboSensorType.SelectedValue;
            home.Rooms[x, y].Sensors[index].State = (AlarmState)cboSensorState.SelectedValue;
            home.Rooms[x, y].Sensors[index].Value = newSensorValue;
            txtSensorValue.Text = newSensorValue;
        }

        private void setupSensorProperties() {
            Common.fillComboBoxFromEnum<SensorTypeEnum>(ref cboSensorType);
            Common.fillComboBoxFromEnum<AlarmState>(ref cboSensorState);
        }

        private void loadSensorInformation(Room room, int index) {
            Sensor sensor = room.Sensors[index];

            cboSensorType.SelectedItem = sensor.Type;
            cboSensorState.SelectedItem = sensor.State; // TODO: this doesn't load properly
            txtSensorValue.Text = sensor.Value;
        }

        private void btnAddSensor_Click(object sender, EventArgs e) {
            int x, y;
            Common.getDGVSelectedIndexes(dgv, out x, out y);

            List<Sensor> sensors = home.Rooms[x, y].Sensors.ToList();

            Sensor sensor = new Sensor();
            sensor.Type = (SensorTypeEnum)cboSensorType.SelectedItem;
            sensor.State = (AlarmState)cboSensorState.SelectedItem;
            sensor.Value = txtSensorValue.Text;

            // insert sensor into db and get sensorID
            int newSensorID;
            Database.addSensor(sensor, home.Rooms[x, y].RoomID, out newSensorID);
            sensor.SensorID = newSensorID;

            sensors.Add(sensor);

            home.Rooms[x, y].Sensors = sensors.ToArray();
            loadSensorIDsFromSensors(ref home.Rooms[x, y]);
            cboSensorList.SelectedIndex = cboSensorList.Items.Count - 1;
        }

        private void btnRemoveSensor_Click(object sender, EventArgs e) {
            // TODO
        }

        private void btnUpdateSensor_Click(object sender, EventArgs e) {
            // update sensor type and clear sensor value
            saveRoom();
            updateSensorInfo();
        }

        private void cboSensorType_SelectedIndexChanged(object sender, EventArgs e) {
            // auto update on change?
        }

        private void addRoomsToHouse() {
            if (home.Rooms == null) {
                int length = dgv.ColumnCount;
                int height = dgv.RowCount;
                home.Rooms = new Room[length, height];
            }

            home.State = (AlarmState)cboAlarmState.SelectedValue;
        }

        private void saveHouse() {
            // if the homeID is the default (invalid) -1 then create a new DB record
            // otherwise, update the existing record

            bool dbUpdated = false;

            if (home.HomeID == -1) {
                int newHomeID;
                dbUpdated = Database.insertHomeIntoDB(home, out newHomeID);
                home.HomeID = newHomeID;
            } else {
                dbUpdated = Database.saveHomeToDB(home);
            }

            string dbSuccessText = (dbUpdated) ? "successfully" : "failed to";

            MessageBox.Show($"Database {dbSuccessText} updated.");
        }

        private void btnSaveHouse_Click(object sender, EventArgs e) {
            addRoomsToHouse();

            saveHouse();
        }

        private void saveRoom() {
            int x, y;
            Common.getDGVSelectedIndexes(dgv, out x, out y);

            Room room = new Room();

            if (home.Rooms[x, y] != null) {
                room = home.Rooms[x, y];
            }

            room.Category = (RoomCategory)cboCategory.SelectedItem;
            room.Type = (RoomType)cboType.SelectedItem;
            room.X = x;
            room.Y = y;
            room.DoorLocations = gatherDoorLocations(); ;

            home.Rooms[x, y] = room;

            // sync changes to cell overview
            showRoomOverviewAtCell(x, y);

            if (home.HomeID == -1) {
                saveHouse();
            }

            // TODO: get roomID from query and stick back into object
            Database.saveRoom(home.HomeID, room);
        }

        private void btnSaveRoom_Click(object sender, EventArgs e) {
            saveRoom();
        }

        private string gatherDoorLocations() {
            string doorLocations = "";

            foreach (int index in clbDoorLocations.CheckedIndices) {
                doorLocations += clbDoorLocations.Items[index].ToString().Substring(0, 1);
            }

            return doorLocations;
        }

        public void showRoomOverviewAtCell(int x, int y) {
            if (home.Rooms != null && home.Rooms[x, y] != null) {
                Room room = home.Rooms[x, y];
                int numberOfSensors = (room.Sensors != null) ? room.Sensors.Length : 0;
                dgv[x, y].Value = $"{room.Type.ToString()} ({numberOfSensors})";
            }
        }

        public void loopThroughRoomsAndExtractOverview() {
            foreach (Room room in home.Rooms) {
                if (room != null) {
                    showRoomOverviewAtCell(room.X, room.Y);
                }
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
