using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IDistributionProcessService
    {
        List<bool> ConnectionCheck(List<Machine> selectedMachines, BackgroundWorker backgroundWorker1);
        void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder,
            double currentFile, List<FileSource> selectedFileSources, BackgroundWorker backgroundWorker1);
        void MachineProgress(Machine machine, double currentMachine, List<Machine> selectedMachines, BackgroundWorker backgroundWorker1);
        bool TestNetwork(string path);
    }
}
