using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    public interface ITreeService
    {
        void DisplayComputerTreeEmployeeView(TreeView treeViewComputers);
        TreeNode CreateEmployeeTreeNode(Employee employee);
        void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee);
        TreeNode CreateComputerTreeNode(Computer computer);
        void AddComputerInfoNodes(TreeNode computerNode, Computer computer);
        void DisplayComputerTreeOrganizationView(TreeView treeViewComputers);
        void DisplayComputerTreeSearchView(TreeView treeViewComputers, string search, string Case);
        void AddUnitNode(Unit unit, TreeNode parentTreeNode, TreeView treeViewComputers);
        TreeNode CreateUnitTreeNode(Unit unit);
        void OpenPath(string path);
        List<TreeNode> GetComputerChildren(TreeNode node);
        void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e);
        string TrimID(string ComputerName);
        void GetUser(Computer computer);
        string GetUser(string ComputerName);
    }
}
