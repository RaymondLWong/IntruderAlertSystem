﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    class Common {
        // confirm if user wants to exit application
        public static void confirmClose(ref FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                DialogResult dr = MessageBox.Show("Are you sure you want to exit the application?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Console.WriteLine(dr);
                Console.WriteLine(e.CloseReason);
                if (dr == DialogResult.Yes) {
                    Application.Exit();
                } else {
                    e.Cancel = true;
                }
            }
        }
    }
}
