using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class DistributionTreeService : IDistributionTreeService
    {
        IDistributionTreeRepository repo = new DistributionTreeRepository();

        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            repo.AddComputerInfoNodes(computerNode, computer);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            repo.AddEmployeeInfoNodes(employeeNode, employee);
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            return repo.CreateComputerTreeNode(computer);
        }

        public TreeNode CreateDestinationPathTreeNode(string destinationPath)
        {
            return repo.CreateDestinationPathTreeNode(destinationPath);
        }

        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            return repo.CreateEmployeeTreeNode(employee);
        }

        public TreeNode CreateFolderTreeNode(DistributionFolder folder)
        {
            return repo.CreateFolderTreeNode(folder);
        }

        public TreeNode CreateModifiedTreeNode(DateTime date)
        {
            return repo.CreateModifiedTreeNode(date);
        }

        public TreeNode CreateNoteTreeNode(string note)
        {
            return repo.CreateNoteTreeNode(note);
        }

        public TreeNode CreateOverwriteTreeNode(bool isFolder)
        {
            return repo.CreateOverwriteTreeNode(isFolder);
        }

        public TreeNode CreateSourceTreeNode(string path)
        {
            return repo.CreateSourceTreeNode(path);
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers, BackgroundWorker loadingComputers)
        {
            repo.DisplayComputerTreeEmployeeView(treeViewComputers, loadingComputers);
        }

        public void DisplayDistributionFolderTree(TreeView treeViewDistributionFolders, BackgroundWorker loadingSources)
        {
            repo.DisplayDistributionFolderTree(treeViewDistributionFolders, loadingSources);
        }
    }
}
