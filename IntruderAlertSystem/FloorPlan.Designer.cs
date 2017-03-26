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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gpbRoomInfo.SuspendLayout();
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
            this.gpbRoomInfo.Location = new System.Drawing.Point(546, 25);
            this.gpbRoomInfo.Name = "gpbRoomInfo";
            this.gpbRoomInfo.Size = new System.Drawing.Size(273, 225);
            this.gpbRoomInfo.TabIndex = 6;
            this.gpbRoomInfo.TabStop = false;
            this.gpbRoomInfo.Text = "Room Information";
            // 
            // gpbSensorInfo
            // 
            this.gpbSensorInfo.Location = new System.Drawing.Point(546, 256);
            this.gpbSensorInfo.Name = "gpbSensorInfo";
            this.gpbSensorInfo.Size = new System.Drawing.Size(273, 269);
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
            // FloorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 550);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gpbRoomInfo;
        private System.Windows.Forms.GroupBox gpbSensorInfo;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.TextBox txtRoomYLocation;
        private System.Windows.Forms.TextBox txtRoomXLocation;
    }
}