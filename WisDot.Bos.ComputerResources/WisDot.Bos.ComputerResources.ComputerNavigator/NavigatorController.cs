using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.ComputerNavigator
{
    class NavigatorController
    {
        private INavigatorView view;
        private static ITreeService treeServ = new TreeService();
        private static ICheckoutService checkServ = new CheckoutService();

        public NavigatorController(INavigatorView view)
        {
            this.view = view;
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers)
        {
            treeServ.DisplayComputerTreeEmployeeView(treeViewComputers);
        }

        public void DisplayComputerTreeOrganizationView(TreeView treeViewComputers)
        {
            treeServ.DisplayComputerTreeOrganizationView(treeViewComputers);
        }

        public void DisplayComputerTreeSearchView(TreeView treeViewComputers, string search, string Case)
        {
            treeServ.DisplayComputerTreeSearchView(treeViewComputers, search, Case);
        }

        public void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeServ.TreeViewComputers_NodeMouseDoubleClick(sender, e);
        }

        public void InitiateCheckout(ComboBox cbNames)
        {
            checkServ.InitiateCheckout(cbNames);
        }

        public void readParser(List<string[]> checkoutData)
        {
            checkServ.ReadParser(checkoutData);
        }

        public string UpdateAvailable(List<Computer> outLaptops, List<Computer> availableLaptops, List<string[]> outLaptopData)
        {
            return checkServ.UpdateAvailable(outLaptops, availableLaptops, outLaptopData);
        }

        public void CheckIn(List<string[]> data, List<string[]> checkoutData)
        {
            checkServ.CheckIn(data, checkoutData);
        }
        public string CreateCSVRow(string[] inputs)
        {
            return checkServ.CreateCSVRow(inputs);
        }
        public bool CheckAdmin()
        {
            return checkServ.CheckAdmin();
        }

        public string TrimID(string ComputerName)
        {
            return treeServ.TrimID(ComputerName);
        }

        public void OpenPath(string path)
        {
            treeServ.OpenPath(path);
        }

        public void GetUser(Computer computer)
        {
            treeServ.GetUser(computer);
        }

        public string GetUser(string ComputerName)
        {
            return treeServ.GetUser(ComputerName);
        }
    }
}
