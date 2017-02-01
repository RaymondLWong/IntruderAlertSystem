using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    class FormProvider {
        private static Form form = null;

        public static Form getInstance() {
            if (form == null) {
                form = new Form();
            }

            return form;
        }
    }
}
