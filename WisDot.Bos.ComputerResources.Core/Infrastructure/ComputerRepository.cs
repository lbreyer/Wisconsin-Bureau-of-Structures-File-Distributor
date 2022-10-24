using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class ComputerRepository : IComputerRepository
    {
        public Computer CreateComputer(XElement computer)
        {
            Computer newComp = new Computer()
            {
                ComputerName = computer.Attribute("Name").Value,
                BackupPath = computer.Element("Backup_Path").Value
            };

            newComp.ComputerAlias = computer.Attribute("Alias") != null ? computer.Attribute("Alias").Value : "";


            bool isInstallFiscalYearValid = int.TryParse(computer.Element("Install_FY").Value, out int installFiscalYear);
            newComp.InstallFiscalYear = isInstallFiscalYearValid ? installFiscalYear : -1;

            newComp.Location = computer.Element("Location").Value;


            newComp.IsActive = (computer.Element("Is_Active").Value.ToUpper().Equals("YES")
                                || computer.Element("Is_Active").Value.ToUpper().Equals("TRUE")) ? true : false;

            newComp.IsOnDistribution = (computer.Element("Is_On_Distribution").Value.ToUpper().Equals("YES")
                                || computer.Element("Is_On_Distribution").Value.ToUpper().Equals("TRUE")) ? true : false;

            newComp.IsOnPush = (computer.Element("Is_On_Push").Value.ToUpper().Equals("YES")
                                || computer.Element("Is_On_Push").Value.ToUpper().Equals("TRUE")) ? true : false;

            newComp.ComputerType = (computer.Element("Is_Laptop").Value.ToUpper().Equals("YES")
                                    || computer.Element("Is_Laptop").Value.ToUpper().Equals("TRUE")) ? Constants.ComputerType.Laptop : Constants.ComputerType.Desktop;
            newComp.IsCheckout = (computer.Element("Is_Checkout").Value.ToUpper().Equals("YES")
                                    || computer.Element("Is_Checkout").Value.ToUpper().Equals("TRUE")) ? true : false;
            newComp.SpecialSoftware = computer.Element("Special_Software").Value;

            bool isOwnerIDValid = int.TryParse(computer.Element("Owner").Attribute("Owner_ID").Value, out int ownerID);
            newComp.OwnerID = isOwnerIDValid ? ownerID : -1;

            newComp.Notes = computer.Element("Note").Value;

            newComp.IsRemote = (computer.Element("Is_Remote_Access").Value.ToUpper().Equals("YES")
                                || computer.Element("Is_Remote_Access").Value.ToUpper().Equals("TRUE")) ? true : false;

            return newComp;
        }

        public List<Computer> GetComputers(IEnumerable<XElement> comps)
        {
            List<Computer> computers = new List<Computer>();

            foreach (XElement comp in comps)
            {
                computers.Add(CreateComputer(comp));
            }

            return computers;
        }
    }
}
