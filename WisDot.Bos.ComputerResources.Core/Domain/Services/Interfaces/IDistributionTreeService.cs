using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IDistributionTreeService
    {
        void DisplayDistributionFolderTree(TreeView treeViewDistributionFolders, BackgroundWorker loadingSources);
        TreeNode CreateOverwriteTreeNode(bool isFolder);
        TreeNode CreateDestinationPathTreeNode(string destinationPath);
        TreeNode CreateModifiedTreeNode(DateTime date);
        TreeNode CreateSourceTreeNode(string path);
        TreeNode CreateNoteTreeNode(string note);
        TreeNode CreateFolderTreeNode(DistributionFolder folder);
        void DisplayComputerTreeEmployeeView(TreeView treeViewComputers, BackgroundWorker loadingComputers);
        TreeNode CreateEmployeeTreeNode(Employee employee);
        void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee);
        TreeNode CreateComputerTreeNode(Computer computer);
        void AddComputerInfoNodes(TreeNode computerNode, Computer computer);
    }
}
