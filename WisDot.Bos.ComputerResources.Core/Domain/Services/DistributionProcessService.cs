using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class DistributionProcessService : IDistributionProcessService
    {
        IDistributionProcessQuery query = new DistributionProcessQuery();

        public List<bool> ConnectionCheck(List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            return query.ConnectionCheck(selectedMachines, backgroundWorker1);
        }

        public void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder, 
            double currentFile, List<FileSource> selectedFileSources, BackgroundWorker backgroundWorker1)
        {
            query.FileProgress(fileSource, distribution, isFileSourceAFolder, currentFile, selectedFileSources, backgroundWorker1);
        }

        public void MachineProgress(Machine machine, double currentMachine, List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            query.MachineProgress(machine, currentMachine, selectedMachines, backgroundWorker1);
        }

        public bool TestNetwork(string path)
        {
            return query.TestNetwork(path);
        }
    }
}
