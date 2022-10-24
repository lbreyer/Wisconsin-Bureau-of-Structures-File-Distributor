using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using static WisDot.Bos.ComputerResources.Core.Data.Constants;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IFileSourceService
    {
        void AddMachine(Machine machine, DistributeResult result, FileSource source);
        void AddDistributeError(string error, FileSource source);
    }
}
