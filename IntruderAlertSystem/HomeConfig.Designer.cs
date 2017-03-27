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
            this.sensorsDataset = new IntruderAlertSystem.sensorsDataset();
            this.dgvSensorLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sensorsDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensorLog)).BeginInit();
            this.SuspendLayout();
            // 
            // sensorsDataset
            // 
            this.sensorsDataset.DataSetName = "sensorsDataset";
            this.sensorsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvSensorLog
            // 
            this.dgvSensorLog.Location = new System.Drawing.Point(126, 91);
            this.dgvSensorLog.Name = "dgvSensorLog";
            this.dgvSensorLog.Size = new System.Drawing.Size(240, 150);
            this.dgvSensorLog.TabIndex = 0;
            // 
            // HomeConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 456);
            this.Controls.Add(this.dgvSensorLog);
            this.MaximizeBox = false;
            this.Name = "HomeConfig";
            this.Text = "HomeConfig";
            ((System.ComponentModel.ISupportInitialize)(this.sensorsDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensorLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private sensorsDataset sensorsDataset;
        private System.Windows.Forms.DataGridView dgvSensorLog;
    }
}