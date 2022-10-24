using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces
{
    interface ITreeRepository
    {
        void AddComputerInfoNodes(TreeNode computerNode, Computer computer);
        void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee);
        void AddUnitNode(Unit unit, TreeNode parentTreeNode, TreeView treeViewComputers);
        TreeNode CreateComputerTreeNode(Computer computer);
        TreeNode CreateEmployeeTreeNode(Employee employee);
        TreeNode CreateUnitTreeNode(Unit unit);
        void DisplayComputerTreeEmployeeView(TreeView treeViewComputers);
        void DisplayComputerTreeOrganizationView(TreeView treeViewComputers);
        void DisplayComputerTreeSearchView(TreeView treeViewComputers, string search, string Case);
        List<TreeNode> GetComputerChildren(TreeNode node);
        string TrimID(string ComputerName);
        void GetUser(Computer computer);
        string GetUser(string ComputerName);
    }
}
