using System;
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
        private static Register register = null;

        public Register() {
            InitializeComponent();
        }

        public static Form getInstance() {
            if (register == null) {
                register = new Register();
            }

            return register;
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Login.getInstance().Show();
            this.Hide();
        }
    }
}
