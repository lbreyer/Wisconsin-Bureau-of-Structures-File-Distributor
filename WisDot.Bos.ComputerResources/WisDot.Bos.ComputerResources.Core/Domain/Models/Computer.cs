using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data;

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    
    public class Computer
    {

        public string ComputerName { get; set; }
        public string ComputerAlias { get; set; }
        public string BackupPath { get; set; }
        public string InventoryNumber { get; set; }
        public int InstallFiscalYear { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnDistribution { get; set; }
        public bool IsOnPush { get; set; }
        public Constants.ComputerType ComputerType { get; set; }
        public bool IsCheckout { get; set; }
        public string SpecialSoftware { get; set; }
        public int OwnerID { get; set; }
        public string Notes { get; set; }
        public bool IsRemote { get; set; }
        public string AccUser { get; set; }

        public Computer(string computerName, string inventoryNumber, int installFiscalYear, string location,
                        bool isActive, Constants.ComputerType computerType, string specialSoftware, string notes, 
                        string computerAlias, bool isRemote, string accUser)
        {
            Initialize();
            ComputerName = computerName;
            InventoryNumber = inventoryNumber;
            InstallFiscalYear = installFiscalYear;
            Location = location;
            IsActive = IsActive;
            ComputerType = computerType;
            SpecialSoftware = specialSoftware;
            Notes = notes;
            ComputerAlias = computerAlias;
            IsRemote = isRemote;
            AccUser = accUser;
        }

        public Computer()
        {
            Initialize();
        }

        private void Initialize()
        {
            ComputerName = "";
            ComputerAlias = "";
            BackupPath = "";
            InventoryNumber = "";
            Location = "";
            ComputerType = Constants.ComputerType.Desktop;
            SpecialSoftware = "";
            Notes = "";
            AccUser = "";
        }

    }
}
