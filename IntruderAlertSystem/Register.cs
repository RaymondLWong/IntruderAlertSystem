﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class Register : Form {
        public Register() {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
