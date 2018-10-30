
using MicroAccounts;
using MicroAccounts.Forms;
using MicroAccounts.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BJMicroAccounts.Reports;
using BJMicroAccounts.Forms;

namespace BJMicroAccounts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
