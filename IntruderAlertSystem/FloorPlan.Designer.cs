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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(25, 25);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(500, 500);
            this.dgv.TabIndex = 0;
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // gpbRoomInfo
            // 
            this.gpbRoomInfo.Location = new System.Drawing.Point(546, 157);
            this.gpbRoomInfo.Name = "gpbRoomInfo";
            this.gpbRoomInfo.Size = new System.Drawing.Size(200, 100);
            this.gpbRoomInfo.TabIndex = 6;
            this.gpbRoomInfo.TabStop = false;
            this.gpbRoomInfo.Text = "Room Information";
            // 
            // gpbSensorInfo
            // 
            this.gpbSensorInfo.Location = new System.Drawing.Point(546, 425);
            this.gpbSensorInfo.Name = "gpbSensorInfo";
            this.gpbSensorInfo.Size = new System.Drawing.Size(200, 100);
            this.gpbSensorInfo.TabIndex = 7;
            this.gpbSensorInfo.TabStop = false;
            this.gpbSensorInfo.Text = "Sensor Information";
            // 
            // FloorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 561);
            this.Controls.Add(this.gpbSensorInfo);
            this.Controls.Add(this.gpbRoomInfo);
            this.Controls.Add(this.dgv);
            this.Name = "FloorPlan";
            this.Text = "FloorPlan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloorPlan_FormClosing);
            this.Load += new System.EventHandler(this.FloorPlan_Load);
            this.LocationChanged += new System.EventHandler(this.FloorPlan_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gpbRoomInfo;
        private System.Windows.Forms.GroupBox gpbSensorInfo;
    }
}