using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class MachineService : IMachineService
    {
        public void AddDistributeError(string error, Machine machine)
        {
            machine.DistributeErrors.Add(error);
        }

        public PingReply pingMachine(string machineName)
        {
            Ping pingSender = new Ping();
            PingOptions pingOptions = new PingOptions()
            {
                // Use the default Tt1 value which is 128,
                // but change the fragmentation behavior.
                DontFragment = true
            };

            // Create a buffer of 32 bytes of data to be transmitted
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;

            PingReply pingReply = null;

            try
            {
                pingReply = pingSender.Send(machineName, timeout, buffer, pingOptions);
            }
            catch { }

            return pingReply;
        }
    }
}
