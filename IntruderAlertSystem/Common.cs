using System;
using System.Windows.Forms;

namespace IntruderAlertSystem {
    class Common {
        // confirm if user wants to exit application
        public static void confirmClose(ref FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                DialogResult dr = MessageBox.Show("Are you sure you want to exit the application?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Console.WriteLine(String.Format("The user responded '{0}' when confirming to exit the application.", dr));
                Console.WriteLine("The form closed because of: " + e.CloseReason);
                if (dr == DialogResult.Yes) {
                    Application.Exit();
                } else {
                    e.Cancel = true;
                }
            }
        }

        public static void disableMaximiseButton(ref Form form) {
            form.MaximizeBox = false;
        }

        public static T convertMySQLEnumToCSharpEnum<T>(string value) {
            // get the MySQL enum and convert it to the appropriate C# enum
            // source: http://stackoverflow.com/questions/16100/how-should-i-convert-a-string-to-an-enum-in-c
            value = value.Replace(' ', '_'); // replace spaces with _ because C# enums can't have spaces
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
