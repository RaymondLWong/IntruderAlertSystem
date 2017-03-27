namespace IntruderAlertSystem {
    partial class FloorPlan {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.gpbRoomInfo = new System.Windows.Forms.GroupBox();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.lblDoorLocations = new System.Windows.Forms.Label();
            this.clbDoorLocations = new System.Windows.Forms.CheckedListBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtRoomYLocation = new System.Windows.Forms.TextBox();
            this.txtRoomXLocation = new System.Windows.Forms.TextBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.gpbSensorInfo = new System.Windows.Forms.GroupBox();
            this.btnSaveSensor = new System.Windows.Forms.Button();
            this.cboSensorState = new System.Windows.Forms.ComboBox();
            this.btnRemoveSensor = new System.Windows.Forms.Button();
            this.cboSensorType = new System.Windows.Forms.ComboBox();
            this.btnAddSensor = new System.Windows.Forms.Button();
            this.lblSensorValue = new System.Windows.Forms.Label();
            this.txtSensorValue = new System.Windows.Forms.TextBox();
            this.lblSensorState = new System.Windows.Forms.Label();
            this.lblSensorType = new System.Windows.Forms.Label();
            this.lblSensor = new System.Windows.Forms.Label();
            this.cboSensorList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAlarmState = new System.Windows.Forms.ComboBox();
            this.lblHomeState = new System.Windows.Forms.Label();
            this.btnSaveHouse = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.txtFloorHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFloorLength = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gpbRoomInfo.SuspendLayout();
            this.gpbSensorInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(25, 25);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(500, 500);
            this.dgv.TabIndex = 0;
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // gpbRoomInfo
            // 
            this.gpbRoomInfo.Controls.Add(this.btnSaveRoom);
            this.gpbRoomInfo.Controls.Add(this.lblDoorLocations);
            this.gpbRoomInfo.Controls.Add(this.clbDoorLocations);
            this.gpbRoomInfo.Controls.Add(this.cboType);
            this.gpbRoomInfo.Controls.Add(this.lblType);
            this.gpbRoomInfo.Controls.Add(this.cboCategory);
            this.gpbRoomInfo.Controls.Add(this.lblCategory);
            this.gpbRoomInfo.Controls.Add(this.txtRoomYLocation);
            this.gpbRoomInfo.Controls.Add(this.txtRoomXLocation);
            this.gpbRoomInfo.Controls.Add(this.lblCoordinates);
            this.gpbRoomInfo.Location = new System.Drawing.Point(546, 163);
            this.gpbRoomInfo.Name = "gpbRoomInfo";
            this.gpbRoomInfo.Size = new System.Drawing.Size(273, 201);
            this.gpbRoomInfo.TabIndex = 6;
            this.gpbRoomInfo.TabStop = false;
            this.gpbRoomInfo.Text = "Room Information";
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Location = new System.Drawing.Point(10, 161);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRoom.TabIndex = 22;
            this.btnSaveRoom.Text = "Save room";
            this.btnSaveRoom.UseVisualStyleBackColor = true;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // lblDoorLocations
            // 
            this.lblDoorLocations.AutoSize = true;
            this.lblDoorLocations.Location = new System.Drawing.Point(13, 105);
            this.lblDoorLocations.Name = "lblDoorLocations";
            this.lblDoorLocations.Size = new System.Drawing.Size(79, 13);
            this.lblDoorLocations.TabIndex = 8;
            this.lblDoorLocations.Text = "Door Locations";
            // 
            // clbDoorLocations
            // 
            this.clbDoorLocations.FormattingEnabled = true;
            this.clbDoorLocations.Location = new System.Drawing.Point(98, 105);
            this.clbDoorLocations.Name = "clbDoorLocations";
            this.clbDoorLocations.Size = new System.Drawing.Size(88, 79);
            this.clbDoorLocations.TabIndex = 7;
            this.clbDoorLocations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDoorLocations_ItemCheck);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(65, 77);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(10, 80);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(65, 50);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 4;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 53);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category";
            // 
            // txtRoomYLocation
            // 
            this.txtRoomYLocation.Location = new System.Drawing.Point(110, 17);
            this.txtRoomYLocation.Name = "txtRoomYLocation";
            this.txtRoomYLocation.ReadOnly = true;
            this.txtRoomYLocation.Size = new System.Drawing.Size(22, 20);
            this.txtRoomYLocation.TabIndex = 2;
            this.txtRoomYLocation.Text = "0";
            this.txtRoomYLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRoomXLocation
            // 
            this.txtRoomXLocation.Location = new System.Drawing.Point(82, 17);
            this.txtRoomXLocation.Name = "txtRoomXLocation";
            this.txtRoomXLocation.ReadOnly = true;
            this.txtRoomXLocation.Size = new System.Drawing.Size(22, 20);
            this.txtRoomXLocation.TabIndex = 1;
            this.txtRoomXLocation.Text = "0";
            this.txtRoomXLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Location = new System.Drawing.Point(7, 20);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(69, 13);
            this.lblCoordinates.TabIndex = 0;
            this.lblCoordinates.Text = "Cor-ordinates";
            // 
            // gpbSensorInfo
            // 
            this.gpbSensorInfo.Controls.Add(this.btnSaveSensor);
            this.gpbSensorInfo.Controls.Add(this.cboSensorState);
            this.gpbSensorInfo.Controls.Add(this.btnRemoveSensor);
            this.gpbSensorInfo.Controls.Add(this.cboSensorType);
            this.gpbSensorInfo.Controls.Add(this.btnAddSensor);
            this.gpbSensorInfo.Controls.Add(this.lblSensorValue);
            this.gpbSensorInfo.Controls.Add(this.txtSensorValue);
            this.gpbSensorInfo.Controls.Add(this.lblSensorState);
            this.gpbSensorInfo.Controls.Add(this.lblSensorType);
            this.gpbSensorInfo.Controls.Add(this.lblSensor);
            this.gpbSensorInfo.Controls.Add(this.cboSensorList);
            this.gpbSensorInfo.Location = new System.Drawing.Point(546, 370);
            this.gpbSensorInfo.Name = "gpbSensorInfo";
            this.gpbSensorInfo.Size = new System.Drawing.Size(273, 155);
            this.gpbSensorInfo.TabIndex = 7;
            this.gpbSensorInfo.TabStop = false;
            this.gpbSensorInfo.Text = "Sensor Information";
            // 
            // btnSaveSensor
            // 
            this.btnSaveSensor.Enabled = false;
            this.btnSaveSensor.Location = new System.Drawing.Point(170, 104);
            this.btnSaveSensor.Name = "btnSaveSensor";
            this.btnSaveSensor.Size = new System.Drawing.Size(97, 23);
            this.btnSaveSensor.TabIndex = 19;
            this.btnSaveSensor.Text = "Save sensor";
            this.btnSaveSensor.UseVisualStyleBackColor = true;
            this.btnSaveSensor.Click += new System.EventHandler(this.btnUpdateSensor_Click);
            // 
            // cboSensorState
            // 
            this.cboSensorState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSensorState.FormattingEnabled = true;
            this.cboSensorState.Location = new System.Drawing.Point(59, 79);
            this.cboSensorState.Name = "cboSensorState";
            this.cboSensorState.Size = new System.Drawing.Size(100, 21);
            this.cboSensorState.TabIndex = 18;
            // 
            // btnRemoveSensor
            // 
            this.btnRemoveSensor.Enabled = false;
            this.btnRemoveSensor.Location = new System.Drawing.Point(170, 63);
            this.btnRemoveSensor.Name = "btnRemoveSensor";
            this.btnRemoveSensor.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveSensor.TabIndex = 17;
            this.btnRemoveSensor.Text = "Remove sensor";
            this.btnRemoveSensor.UseVisualStyleBackColor = true;
            this.btnRemoveSensor.Click += new System.EventHandler(this.btnRemoveSensor_Click);
            // 
            // cboSensorType
            // 
            this.cboSensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSensorType.FormattingEnabled = true;
            this.cboSensorType.Location = new System.Drawing.Point(59, 50);
            this.cboSensorType.Name = "cboSensorType";
            this.cboSensorType.Size = new System.Drawing.Size(100, 21);
            this.cboSensorType.TabIndex = 9;
            this.cboSensorType.SelectedIndexChanged += new System.EventHandler(this.cboSensorType_SelectedIndexChanged);
            // 
            // btnAddSensor
            // 
            this.btnAddSensor.Location = new System.Drawing.Point(170, 19);
            this.btnAddSensor.Name = "btnAddSensor";
            this.btnAddSensor.Size = new System.Drawing.Size(97, 23);
            this.btnAddSensor.TabIndex = 16;
            this.btnAddSensor.Text = "Add new sensor";
            this.btnAddSensor.UseVisualStyleBackColor = true;
            this.btnAddSensor.Click += new System.EventHandler(this.btnAddSensor_Click);
            // 
            // lblSensorValue
            // 
            this.lblSensorValue.AutoSize = true;
            this.lblSensorValue.Location = new System.Drawing.Point(13, 109);
            this.lblSensorValue.Name = "lblSensorValue";
            this.lblSensorValue.Size = new System.Drawing.Size(34, 13);
            this.lblSensorValue.TabIndex = 15;
            this.lblSensorValue.Text = "Value";
            // 
            // txtSensorValue
            // 
            this.txtSensorValue.Location = new System.Drawing.Point(59, 106);
            this.txtSensorValue.Name = "txtSensorValue";
            this.txtSensorValue.Size = new System.Drawing.Size(100, 20);
            this.txtSensorValue.TabIndex = 14;
            // 
            // lblSensorState
            // 
            this.lblSensorState.AutoSize = true;
            this.lblSensorState.Location = new System.Drawing.Point(13, 82);
            this.lblSensorState.Name = "lblSensorState";
            this.lblSensorState.Size = new System.Drawing.Size(32, 13);
            this.lblSensorState.TabIndex = 13;
            this.lblSensorState.Text = "State";
            // 
            // lblSensorType
            // 
            this.lblSensorType.AutoSize = true;
            this.lblSensorType.Location = new System.Drawing.Point(13, 53);
            this.lblSensorType.Name = "lblSensorType";
            this.lblSensorType.Size = new System.Drawing.Size(31, 13);
            this.lblSensorType.TabIndex = 11;
            this.lblSensorType.Text = "Type";
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Location = new System.Drawing.Point(13, 22);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(40, 13);
            this.lblSensor.TabIndex = 9;
            this.lblSensor.Text = "Sensor";
            // 
            // cboSensorList
            // 
            this.cboSensorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSensorList.FormattingEnabled = true;
            this.cboSensorList.Location = new System.Drawing.Point(59, 19);
            this.cboSensorList.Name = "cboSensorList";
            this.cboSensorList.Size = new System.Drawing.Size(36, 21);
            this.cboSensorList.TabIndex = 0;
            this.cboSensorList.SelectedIndexChanged += new System.EventHandler(this.cboSensorList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAlarmState);
            this.groupBox1.Controls.Add(this.lblHomeState);
            this.groupBox1.Controls.Add(this.btnSaveHouse);
            this.groupBox1.Controls.Add(this.lblX);
            this.groupBox1.Controls.Add(this.txtFloorHeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFloorLength);
            this.groupBox1.Location = new System.Drawing.Point(546, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 131);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Floor Information";
            // 
            // cboAlarmState
            // 
            this.cboAlarmState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarmState.FormattingEnabled = true;
            this.cboAlarmState.Location = new System.Drawing.Point(114, 39);
            this.cboAlarmState.Name = "cboAlarmState";
            this.cboAlarmState.Size = new System.Drawing.Size(100, 21);
            this.cboAlarmState.TabIndex = 21;
            // 
            // lblHomeState
            // 
            this.lblHomeState.AutoSize = true;
            this.lblHomeState.Location = new System.Drawing.Point(10, 42);
            this.lblHomeState.Name = "lblHomeState";
            this.lblHomeState.Size = new System.Drawing.Size(98, 13);
            this.lblHomeState.TabIndex = 20;
            this.lblHomeState.Text = "Alarm System State";
            // 
            // btnSaveHouse
            // 
            this.btnSaveHouse.Location = new System.Drawing.Point(56, 75);
            this.btnSaveHouse.Name = "btnSaveHouse";
            this.btnSaveHouse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveHouse.TabIndex = 7;
            this.btnSaveHouse.Text = "Save house";
            this.btnSaveHouse.UseVisualStyleBackColor = true;
            this.btnSaveHouse.Click += new System.EventHandler(this.btnSaveHouse_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(68, 16);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(12, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "x";
            // 
            // txtFloorHeight
            // 
            this.txtFloorHeight.Location = new System.Drawing.Point(82, 13);
            this.txtFloorHeight.Name = "txtFloorHeight";
            this.txtFloorHeight.ReadOnly = true;
            this.txtFloorHeight.Size = new System.Drawing.Size(22, 20);
            this.txtFloorHeight.TabIndex = 5;
            this.txtFloorHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size";
            // 
            // txtFloorLength
            // 
            this.txtFloorLength.Location = new System.Drawing.Point(40, 13);
            this.txtFloorLength.Name = "txtFloorLength";
            this.txtFloorLength.ReadOnly = true;
            this.txtFloorLength.Size = new System.Drawing.Size(22, 20);
            this.txtFloorLength.TabIndex = 4;
            this.txtFloorLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FloorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbSensorInfo);
            this.Controls.Add(this.gpbRoomInfo);
            this.Controls.Add(this.dgv);
            this.Name = "FloorPlan";
            this.Text = "FloorPlan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloorPlan_FormClosing);
            this.Load += new System.EventHandler(this.FloorPlan_Load);
            this.LocationChanged += new System.EventHandler(this.FloorPlan_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gpbRoomInfo.ResumeLayout(false);
            this.gpbRoomInfo.PerformLayout();
            this.gpbSensorInfo.ResumeLayout(false);
            this.gpbSensorInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gpbRoomInfo;
        private System.Windows.Forms.GroupBox gpbSensorInfo;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.TextBox txtRoomYLocation;
        private System.Windows.Forms.TextBox txtRoomXLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtFloorHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFloorLength;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.CheckedListBox clbDoorLocations;
        private System.Windows.Forms.Label lblDoorLocations;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.ComboBox cboSensorList;
        private System.Windows.Forms.Label lblSensorValue;
        private System.Windows.Forms.TextBox txtSensorValue;
        private System.Windows.Forms.Label lblSensorState;
        private System.Windows.Forms.Label lblSensorType;
        private System.Windows.Forms.Button btnAddSensor;
        private System.Windows.Forms.Button btnRemoveSensor;
        private System.Windows.Forms.ComboBox cboSensorType;
        private System.Windows.Forms.ComboBox cboSensorState;
        private System.Windows.Forms.Button btnSaveSensor;
        private System.Windows.Forms.Button btnSaveHouse;
        private System.Windows.Forms.ComboBox cboAlarmState;
        private System.Windows.Forms.Label lblHomeState;
        private System.Windows.Forms.Button btnSaveRoom;
    }
}