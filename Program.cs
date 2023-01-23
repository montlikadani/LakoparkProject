using System;
using System.Windows.Forms;

namespace Lakopark {
    internal static class Program {

        [STAThread]
        static void Main() {
            _ = Database.SqlCommand;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
