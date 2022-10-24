using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class Machine
    {
        public string OwnerName { get; set; }
        public string MachineName { get; set; }
        public bool IsLapTop { get; set; }
        public List<string> DistributeErrors { get; set; }
        public Machine(string ownerName, string machineName, bool isLapTop)
        {
            Initialize();
            OwnerName = ownerName;
            MachineName = machineName;
            IsLapTop = isLapTop;
        }

        public Machine()
        {
            Initialize();
        }
        private void Initialize()
        {
            OwnerName = "";
            MachineName = "";
            DistributeErrors = new List<string>();
        }
    }
}
