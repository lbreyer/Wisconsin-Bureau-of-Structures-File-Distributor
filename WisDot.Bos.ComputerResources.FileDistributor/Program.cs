using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WisDot.Bos.ComputerResources.FileDistributor
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
            Application.Run(new DistributionView());
        }
    }
}
