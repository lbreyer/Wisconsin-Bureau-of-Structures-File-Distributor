using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    public class ViewConst
    {
        #region Computer Navigator Constants
        public static string BOSCUBEMAP = ConfigurationManager.AppSettings["BOSCUBEMAP"].ToString();
        public static string LOGINID = Environment.GetEnvironmentVariable("USERNAME");
        public static string CHECKOUTLOG = ConfigurationManager.AppSettings["CHECKOUTLOG"].ToString();
        public static List<Employee> EMPS = new EmployeeService().GetEmployees();
        public static List<Unit> UNITS = new UnitService().GetSectionUnits();
        public static List<Computer> LAPTOPS = new ComputerService().GetAllComputers().Where(c => c.IsCheckout).ToList();

        public enum NodeTags
        {
            Computer,
            ComputerInfo,
            Employee,
            EmployeeInfo,
            Phone,
            Email,
            Location,
            RemoteComputer
        }

        public static void OpenMap(string search = null)
        {
            if (!String.IsNullOrEmpty(search))
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = ConfigurationManager.AppSettings["SIFileName"].ToString();
                    p.StartInfo.Arguments = "/A \"zoom=300&search=" + search + "\" \"" + BOSCUBEMAP + "\"";
                    p.Start();
                    return;
                }
                catch { }
            }

            Process.Start(BOSCUBEMAP);
        }
        #endregion

        #region File Distributor Constants
        public const string COMPUTERNODETAG = "COMPUTER";
        public const string DESKTOPNODETAG = "DESKTOP";
        public const string LAPTOPNODETAG = "LAPTOP";
        public const string EMPLOYEENODETAG = "EMPLOYEE";
        public const string COMPUTERINFONODETAG = "COMPUTERINFO";
        public const string EMPLOYEEINFONODETAG = "EMPLOYEEINFO";

        public const string FOLDERNODETAG = "FOLDER";
        public const string FOLDERNODENOENTIREDISTRIBUTIONTAG = "FOLDERNOENTIREDISTRIBUTION";
        public const string FILENODETAG = "FILE";
        public const string INFONODETAG = "INFO";
        public const string PATHNODETAG = "PATH";
        public const string OVERWRITENODETAG = "OVERWRITE";
        #endregion
    }
}
