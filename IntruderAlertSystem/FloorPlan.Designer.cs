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
            this.cboHouseLength = new System.Windows.Forms.ComboBox();
            this.cboHouseHeight = new System.Windows.Forms.ComboBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.gpbFloorPlan = new System.Windows.Forms.GroupBox();
            this.btnUpdateFloorPlan = new System.Windows.Forms.Button();
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
            // 
            // cboHouseLength
            // 
            this.cboHouseLength.FormattingEnabled = true;
            this.cboHouseLength.Location = new System.Drawing.Point(91, 25);
            this.cboHouseLength.Name = "cboHouseLength";
            this.cboHouseLength.Size = new System.Drawing.Size(36, 21);
            this.cboHouseLength.TabIndex = 1;
            // 
            // cboHouseHeight
            // 
            this.cboHouseHeight.FormattingEnabled = true;
            this.cboHouseHeight.Location = new System.Drawing.Point(91, 52);
            this.cboHouseHeight.Name = "cboHouseHeight";
            this.cboHouseHeight.Size = new System.Drawing.Size(36, 21);
            this.cboHouseHeight.TabIndex = 2;
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
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(19, 55);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(64, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Floor Height";
            // 
            // gpbFloorPlan
            // 
            this.gpbFloorPlan.Controls.Add(this.btnUpdateFloorPlan);
            this.gpbFloorPlan.Controls.Add(this.lblHeight);
            this.gpbFloorPlan.Controls.Add(this.cboHouseLength);
            this.gpbFloorPlan.Controls.Add(this.lblLength);
            this.gpbFloorPlan.Controls.Add(this.cboHouseHeight);
            this.gpbFloorPlan.Location = new System.Drawing.Point(546, 25);
            this.gpbFloorPlan.Name = "gpbFloorPlan";
            this.gpbFloorPlan.Size = new System.Drawing.Size(200, 126);
            this.gpbFloorPlan.TabIndex = 5;
            this.gpbFloorPlan.TabStop = false;
            this.gpbFloorPlan.Text = "Floor Plan";
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
            // FloorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 561);
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
        private System.Windows.Forms.ComboBox cboHouseLength;
        private System.Windows.Forms.ComboBox cboHouseHeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.GroupBox gpbFloorPlan;
        private System.Windows.Forms.Button btnUpdateFloorPlan;
    }
}