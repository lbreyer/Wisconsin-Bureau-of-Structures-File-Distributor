using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class TreeService : ITreeService
    {
        private static ITreeQuery query = new TreeQuery();
        private static ITreeRepository repo = new TreeRepository();

        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            repo.AddComputerInfoNodes(computerNode, computer);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            repo.AddEmployeeInfoNodes(employeeNode, employee);
        }

        public void AddUnitNode(Unit unit, TreeNode parentTreeNode, TreeView treeViewComputers)
        {
            repo.AddUnitNode(unit, parentTreeNode, treeViewComputers);
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            return repo.CreateComputerTreeNode(computer);
        }

        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            return repo.CreateEmployeeTreeNode(employee);
        }

        public TreeNode CreateUnitTreeNode(Unit unit)
        {
            return repo.CreateUnitTreeNode(unit);
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers)
        {
            repo.DisplayComputerTreeEmployeeView(treeViewComputers);
        }

        public void DisplayComputerTreeOrganizationView(TreeView treeViewComputers)
        {
            repo.DisplayComputerTreeOrganizationView(treeViewComputers);
        }
        public void DisplayComputerTreeSearchView(TreeView treeViewComputers, string search, string Case)
        {
            repo.DisplayComputerTreeSearchView(treeViewComputers, search, Case);
        }


        public List<TreeNode> GetComputerChildren(TreeNode node)
        {
            return repo.GetComputerChildren(node);
        }

        public void OpenPath(string path)
        {
            query.OpenPath(path);
        }

        public void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            query.TreeViewComputers_NodeMouseDoubleClick(sender, e);
        }

        public string TrimID(string ComputerName)
        {
            return repo.TrimID(ComputerName);
        }

        public void GetUser(Computer computer)
        {
            repo.GetUser(computer);
        }

        public string GetUser(string ComputerName)
        {
            return repo.GetUser(ComputerName);
        }
    }
}
