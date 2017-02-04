using System.Windows.Forms;

namespace IntruderAlertSystem {
    public partial class authenticated : Form {

        private static authenticated auth = null;

        public static Form getInstance() {
            if (auth == null) {
                auth = new authenticated();
            }

            return auth;
        }

        public authenticated() {
            InitializeComponent();
        }
    }
}
