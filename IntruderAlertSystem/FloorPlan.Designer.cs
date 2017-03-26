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
            this.gpbSensorInfo = new System.Windows.Forms.GroupBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.txtRoomXLocation = new System.Windows.Forms.TextBox();
            this.txtRoomYLocation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFloorHeight = new System.Windows.Forms.TextBox();
            this.txtFloorLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gpbRoomInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(25, 25);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(500, 500);
            this.dgv.TabIndex = 0;
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // gpbRoomInfo
            // 
            this.gpbRoomInfo.Controls.Add(this.txtRoomYLocation);
            this.gpbRoomInfo.Controls.Add(this.txtRoomXLocation);
            this.gpbRoomInfo.Controls.Add(this.lblCoordinates);
            this.gpbRoomInfo.Location = new System.Drawing.Point(546, 163);
            this.gpbRoomInfo.Name = "gpbRoomInfo";
            this.gpbRoomInfo.Size = new System.Drawing.Size(273, 225);
            this.gpbRoomInfo.TabIndex = 6;
            this.gpbRoomInfo.TabStop = false;
            this.gpbRoomInfo.Text = "Room Information";
            // 
            // gpbSensorInfo
            // 
            this.gpbSensorInfo.Location = new System.Drawing.Point(546, 394);
            this.gpbSensorInfo.Name = "gpbSensorInfo";
            this.gpbSensorInfo.Size = new System.Drawing.Size(273, 131);
            this.gpbSensorInfo.TabIndex = 7;
            this.gpbSensorInfo.TabStop = false;
            this.gpbSensorInfo.Text = "Sensor Information";
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
            // groupBox1
            // 
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
            // txtFloorHeight
            // 
            this.txtFloorHeight.Location = new System.Drawing.Point(82, 13);
            this.txtFloorHeight.Name = "txtFloorHeight";
            this.txtFloorHeight.ReadOnly = true;
            this.txtFloorHeight.Size = new System.Drawing.Size(22, 20);
            this.txtFloorHeight.TabIndex = 5;
            this.txtFloorHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size";
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
    }
}