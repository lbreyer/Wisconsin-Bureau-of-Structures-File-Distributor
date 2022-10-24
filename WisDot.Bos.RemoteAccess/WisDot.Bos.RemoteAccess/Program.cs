using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WisDot.Bos.RemoteAccess
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
            Application.Run(new HomeView(""));
        }

        public static string[] GetRemotePC()
        {
            String[] remotePC;
            List<string> remote = new List<string>();
            XDocument computers = XDocument.Load(ConfigurationManager.AppSettings.Get("Computer List"));
            foreach (var computer in computers.Descendants("Is_Remote_Access"))
            {
                //MessageBox.Show(computer.Parent.Descendants("Is_Active").First().ToString().ToLower());
                if (computer.ToString().ToLower().Contains("yes") && computer.Parent.Descendants("Is_Active").First().ToString().ToLower().Contains("yes"))
                {
                    remote.Add(computer.Parent.FirstAttribute.ToString().Trim().Substring(5).Replace("\"", "").ToUpper());
                    //MessageBox.Show();
                }
            }

            return remotePC = remote.ToArray();
        }
    }
}
