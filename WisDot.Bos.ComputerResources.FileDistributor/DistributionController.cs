using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;

namespace WisDot.Bos.ComputerResources.FileDistributor
{
    class DistributionController
    {
        #region Services
        private static DistributionFolderService distServ = new DistributionFolderService();
        private static ComputerService compServ = new ComputerService();
        private static EmployeeService empServ = new EmployeeService();
        private static DistributionTreeService treeServ = new DistributionTreeService();
        private static FileSourceService fileServ = new FileSourceService();
        private static MachineService machServ = new MachineService();
        private static DistributionFileService distFileServ = new DistributionFileService();
        private static DistributionNodeService nodeServ = new DistributionNodeService();
        private static DistributionProcessService procServ = new DistributionProcessService();
        #endregion

        public void DisplayDistributionFolderTree(TreeView treeViewDistributionFolders, BackgroundWorker loadingSources)
        {
            treeServ.DisplayDistributionFolderTree(treeViewDistributionFolders, loadingSources);
        }
        public TreeNode CreateOverwriteTreeNode(bool isFolder)
        {
            return treeServ.CreateOverwriteTreeNode(isFolder);
        }
        public TreeNode CreateDestinationPathTreeNode(string destinationPath)
        {
            return treeServ.CreateDestinationPathTreeNode(destinationPath);
        }

        public TreeNode CreateModifiedTreeNode(DateTime date)
        {
            return treeServ.CreateModifiedTreeNode(date);
        }

        public TreeNode CreateSourceTreeNode(string path)
        {
            return treeServ.CreateSourceTreeNode(path);
        }

        public TreeNode CreateNoteTreeNode(string note)
        {
            return treeServ.CreateNoteTreeNode(note);
        }

        public TreeNode CreateFolderTreeNode(DistributionFolder folder)
        {
            return treeServ.CreateFolderTreeNode(folder);
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers, BackgroundWorker loadingComputers)
        {
            treeServ.DisplayComputerTreeEmployeeView(treeViewComputers, loadingComputers);
        }


        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            return treeServ.CreateEmployeeTreeNode(employee);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            treeServ.AddEmployeeInfoNodes(employeeNode, employee);
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            return treeServ.CreateComputerTreeNode(computer);
        }

        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            treeServ.AddComputerInfoNodes(computerNode, computer);
        }

        public bool TestNetwork(string path)
        {
            return procServ.TestNetwork(path);
        }

        public List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite)
        {
            return distFileServ.CopyFile(sourcePath, destinationPath, overwrite);
        }

        public List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory,
            bool overwrite, List<FileInfo> specialFiles)
        {
            return distFileServ.CopyDir(sourceBaseDirectory, destinationBaseDirectory, overwrite, specialFiles);
        }

        public List<string> DeleteFile(string machineFilePath)
        {
            return distFileServ.DeleteFile(machineFilePath);
        }

        public List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders,
            List<FileInfo> specialFiles = null)
        {
            return distFileServ.DeleteDir(machineFolderPath, deleteSubFolders, specialFiles);
        }

        public string LogException(Exception ex)
        {
            return distFileServ.LogException(ex);
        }

        public int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute, List<FileSource> selectedFileSources)
        {
            return nodeServ.GetCheckedFileSourcesNodes(nodes, isDistribute, selectedFileSources);
        }

        public int GetCheckedComputersNodes(TreeNodeCollection nodes, List<Machine> selectedMachines)
        {
            return nodeServ.GetCheckedComputersNodes(nodes, selectedMachines);
        }

        public void OpenPath(string path)
        {
            distFileServ.OpenPath(path);
        }

        public PingReply pingMachine(string machineName)
        {
            return machServ.pingMachine(machineName);
        }

        public void EditXML(string path)
        {
            distFileServ.EditXML(path);
        }

        public List<bool> ConnectionCheck(List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            return procServ.ConnectionCheck(selectedMachines, backgroundWorker1);
        }

        public void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder,
            double currentFile, List<FileSource> selectedFileSources, BackgroundWorker backgroundWorker1)
        {
            procServ.FileProgress(fileSource, distribution, isFileSourceAFolder, currentFile, selectedFileSources, backgroundWorker1);
        }

        public void MachineProgress(Machine machine, double currentMachine, List<Machine> selectedMachines, BackgroundWorker backgroundWorker1)
        {
            procServ.MachineProgress(machine, currentMachine, selectedMachines, backgroundWorker1);
        }


    }
}
