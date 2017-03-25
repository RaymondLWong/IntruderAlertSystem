namespace IntruderAlertSystem {
    partial class HomeConfig {
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
            this.cboHouseLength = new System.Windows.Forms.ComboBox();
            this.cboHouseHeight = new System.Windows.Forms.ComboBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnUpdateSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboHouseLength
            // 
            this.cboHouseLength.FormattingEnabled = true;
            this.cboHouseLength.Location = new System.Drawing.Point(235, 99);
            this.cboHouseLength.Name = "cboHouseLength";
            this.cboHouseLength.Size = new System.Drawing.Size(37, 21);
            this.cboHouseLength.TabIndex = 0;
            // 
            // cboHouseHeight
            // 
            this.cboHouseHeight.FormattingEnabled = true;
            this.cboHouseHeight.Location = new System.Drawing.Point(359, 99);
            this.cboHouseHeight.Name = "cboHouseHeight";
            this.cboHouseHeight.Size = new System.Drawing.Size(37, 21);
            this.cboHouseHeight.TabIndex = 1;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(189, 102);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "Length";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(313, 102);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // btnUpdateSize
            // 
            this.btnUpdateSize.Location = new System.Drawing.Point(316, 197);
            this.btnUpdateSize.Name = "btnUpdateSize";
            this.btnUpdateSize.Size = new System.Drawing.Size(122, 23);
            this.btnUpdateSize.TabIndex = 4;
            this.btnUpdateSize.Text = "Update house size";
            this.btnUpdateSize.UseVisualStyleBackColor = true;
            this.btnUpdateSize.Click += new System.EventHandler(this.btnUpdateSize_Click);
            // 
            // HomeConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 456);
            this.Controls.Add(this.btnUpdateSize);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.cboHouseHeight);
            this.Controls.Add(this.cboHouseLength);
            this.Name = "HomeConfig";
            this.Text = "HomeConfig";
            this.Load += new System.EventHandler(this.HomeConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHouseLength;
        private System.Windows.Forms.ComboBox cboHouseHeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnUpdateSize;
    }
}