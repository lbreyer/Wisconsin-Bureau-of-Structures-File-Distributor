using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using static WisDot.Bos.ComputerResources.Core.Data.Constants;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class FileSourceService : IFileSourceService
    {
        public void AddDistributeError(string error, FileSource source)
        {
            source.DistributeErrors.Add(error);
        }

        public void AddMachine(Machine machine, Constants.DistributeResult result, FileSource source)
        {
            switch (result)
            {
                case DistributeResult.Failure:
                    source.FailMachines.Add(machine);
                    break;
                case DistributeResult.Success:
                    source.SuccessMachines.Add(machine);
                    break;
                case DistributeResult.PartialSuccess:
                    source.PartialSuccessMachines.Add(machine);
                    break;
            }
        }
    }
}
