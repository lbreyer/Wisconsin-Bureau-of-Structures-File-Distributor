using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class DistributionProcessQuery : IDistributionProcessQuery
    {
        public List<bool> ConnectionCheck(List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            string[] progArgs = { "file", "", "Checking connected computers..." };
            backgroundWorker1.ReportProgress(0, progArgs);
            List<bool> computerList = new List<bool>();
            foreach (Machine machine in selectedMachines)
            {
                string[] compArgs = { "comp", "Checking:",
                        machine.MachineName + " - " + machine.OwnerName };
                double compProgress = (double)computerList.Count / (double)selectedMachines.Count * 100;
                backgroundWorker1.ReportProgress(Convert.ToInt32(compProgress), compArgs);
                string machineCroot = String.Format(@"\\{0}\c-root\", machine.MachineName);
                computerList.Add(TestNetwork(machineCroot));
                if (backgroundWorker1.CancellationPending)
                {
                    return computerList;
                }
            }
            return computerList;
        }

        public void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder, 
            double currentFile, List<FileSource> selectedFileSources, BackgroundWorker backgroundWorker1)
        {
            string[] fileArgs = { "file", "Copying ", fileSource.DestinationPath };
            if (!distribution)
                fileArgs[1] = "Deleting";
            if (isFileSourceAFolder)
                fileArgs[1] += "Folder:";
            else
            {
                fileArgs[1] += "File:";
                fileArgs[2] += "\\" + Path.GetFileName(fileSource.SourcePath);
            }
            double progress = currentFile / selectedFileSources.Count * 100;
            backgroundWorker1.ReportProgress(Convert.ToInt32(progress), fileArgs);
        }

        public void MachineProgress(Machine machine, double currentMachine, List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            string[] compArgs = { "comp", "Copying Files To:     Computer: ",
                        machine.MachineName + " Owner: " + machine.OwnerName };
            double compProgress = currentMachine / selectedMachines.Count * 100;
            backgroundWorker1.ReportProgress(Convert.ToInt32(compProgress), compArgs);
        }

        public bool TestNetwork(string path)
        {
            bool exists = true;
            Thread t = new Thread
            (
                new ThreadStart(delegate ()
                {
                    exists = Directory.Exists(path);
                })
            );
            t.Start();
            bool completed = t.Join(5000); // timeout after 500ms
            if (!completed) { exists = false; t.Abort(); }
            return exists;
        }
    }
}
