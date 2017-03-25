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
            this.cboFloorHeight = new System.Windows.Forms.ComboBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.cboFloorLength = new System.Windows.Forms.ComboBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnUpdateFloorPlan = new System.Windows.Forms.Button();
            this.gpbFloorPlan = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gpbFloorPlan.SuspendLayout();
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
            // cboFloorHeight
            // 
            this.cboFloorHeight.FormattingEnabled = true;
            this.cboFloorHeight.Location = new System.Drawing.Point(91, 52);
            this.cboFloorHeight.Name = "cboFloorHeight";
            this.cboFloorHeight.Size = new System.Drawing.Size(36, 21);
            this.cboFloorHeight.TabIndex = 2;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(19, 28);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(66, 13);
            this.lblLength.TabIndex = 3;
            this.lblLength.Text = "Floor Length";
            // 
            // cboFloorLength
            // 
            this.cboFloorLength.FormattingEnabled = true;
            this.cboFloorLength.Location = new System.Drawing.Point(91, 25);
            this.cboFloorLength.Name = "cboFloorLength";
            this.cboFloorLength.Size = new System.Drawing.Size(36, 21);
            this.cboFloorLength.TabIndex = 1;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(19, 55);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(64, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Floor Height";
            // 
            // btnUpdateFloorPlan
            // 
            this.btnUpdateFloorPlan.Location = new System.Drawing.Point(22, 85);
            this.btnUpdateFloorPlan.Name = "btnUpdateFloorPlan";
            this.btnUpdateFloorPlan.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateFloorPlan.TabIndex = 5;
            this.btnUpdateFloorPlan.Text = "Update floor plan";
            this.btnUpdateFloorPlan.UseVisualStyleBackColor = true;
            this.btnUpdateFloorPlan.Click += new System.EventHandler(this.btnUpdateFloorPlan_Click);
            // 
            // gpbFloorPlan
            // 
            this.gpbFloorPlan.Controls.Add(this.btnUpdateFloorPlan);
            this.gpbFloorPlan.Controls.Add(this.lblHeight);
            this.gpbFloorPlan.Controls.Add(this.cboFloorLength);
            this.gpbFloorPlan.Controls.Add(this.lblLength);
            this.gpbFloorPlan.Controls.Add(this.cboFloorHeight);
            this.gpbFloorPlan.Location = new System.Drawing.Point(546, 25);
            this.gpbFloorPlan.Name = "gpbFloorPlan";
            this.gpbFloorPlan.Size = new System.Drawing.Size(200, 126);
            this.gpbFloorPlan.TabIndex = 5;
            this.gpbFloorPlan.TabStop = false;
            this.gpbFloorPlan.Text = "Floor Plan";
            // 
            // FloorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 561);
            this.Controls.Add(this.gpbSensorInfo);
            this.Controls.Add(this.gpbRoomInfo);
            this.Controls.Add(this.gpbFloorPlan);
            this.Controls.Add(this.dgv);
            this.Name = "FloorPlan";
            this.Text = "FloorPlan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloorPlan_FormClosing);
            this.Load += new System.EventHandler(this.FloorPlan_Load);
            this.LocationChanged += new System.EventHandler(this.FloorPlan_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gpbFloorPlan.ResumeLayout(false);
            this.gpbFloorPlan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox gpbRoomInfo;
        private System.Windows.Forms.GroupBox gpbSensorInfo;
        private System.Windows.Forms.ComboBox cboFloorHeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.ComboBox cboFloorLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnUpdateFloorPlan;
        private System.Windows.Forms.GroupBox gpbFloorPlan;
    }
}