using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.FileDistributor
{
    interface IDistributionView
    {
        void DisplayDistributionFolderTree();
        TreeNode CreateOverwriteTreeNode(bool isFolder);
        TreeNode CreateDestinationPathTreeNode(string destinationPath);
        TreeNode CreateModifiedTreeNode(DateTime date);
        TreeNode CreateSourceTreeNode(string path);
        TreeNode CreateNoteTreeNode(string note);
        TreeNode CreateFolderTreeNode(DistributionFolder folder);
        void DisplayComputerTreeEmployeeView();
        TreeNode CreateEmployeeTreeNode(Employee employee);
        void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee);
        TreeNode CreateComputerTreeNode(Computer computer);
        void AddComputerInfoNodes(TreeNode computerNode, Computer computer);
        bool TestNetwork(string path);
        List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite);
        List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory,
            bool overwrite, List<FileInfo> specialFiles);
        List<string> DeleteFile(string machineFilePath);
        List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders,
            List<FileInfo> specialFiles = null);
        string LogException(Exception ex);
        int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute);
        int GetCheckedComputersNodes(TreeNodeCollection nodes);
        void OpenPath(string path);
        PingReply pingMachine(string machineName);
        void EditXML(string path);
        List<bool> ConnectionCheck();
        void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder,
            double currentFile);
        void MachineProgress(Machine machine, double currentMachine);


    }
}
