namespace IntruderAlertSystem {
    partial class authenticated {
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gpbFloorPlan = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.cboFloorSize = new System.Windows.Forms.ComboBox();
            this.gpbFloorPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Safe Home intruder alert system!";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(22, 87);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create floor plan";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // gpbFloorPlan
            // 
            this.gpbFloorPlan.Controls.Add(this.lblUnit);
            this.gpbFloorPlan.Controls.Add(this.btnCreate);
            this.gpbFloorPlan.Controls.Add(this.lblHeight);
            this.gpbFloorPlan.Controls.Add(this.cboFloorSize);
            this.gpbFloorPlan.Location = new System.Drawing.Point(172, 69);
            this.gpbFloorPlan.Name = "gpbFloorPlan";
            this.gpbFloorPlan.Size = new System.Drawing.Size(200, 126);
            this.gpbFloorPlan.TabIndex = 6;
            this.gpbFloorPlan.TabStop = false;
            this.gpbFloorPlan.Text = "Floor Plan";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(133, 55);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(19, 13);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "^2";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(19, 55);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(53, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Floor Size";
            // 
            // cboFloorSize
            // 
            this.cboFloorSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFloorSize.FormattingEnabled = true;
            this.cboFloorSize.Location = new System.Drawing.Point(91, 52);
            this.cboFloorSize.Name = "cboFloorSize";
            this.cboFloorSize.Size = new System.Drawing.Size(36, 21);
            this.cboFloorSize.TabIndex = 2;
            // 
            // authenticated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.gpbFloorPlan);
            this.Controls.Add(this.label1);
            this.Name = "authenticated";
            this.Text = "authenticated";
            this.Load += new System.EventHandler(this.authenticated_Load);
            this.gpbFloorPlan.ResumeLayout(false);
            this.gpbFloorPlan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox gpbFloorPlan;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.ComboBox cboFloorSize;
        private System.Windows.Forms.Label lblUnit;
    }
}