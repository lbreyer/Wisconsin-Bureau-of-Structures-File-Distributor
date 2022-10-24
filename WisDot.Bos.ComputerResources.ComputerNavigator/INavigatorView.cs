using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.ComputerNavigator
{
    public interface INavigatorView
    {
        void DisplayComputerTree();
        void ClearComputerTree();
        void DisplayComputerTreeEmployeeView();
        void DisplayComputerTreeOrganizationView();
        void OpenMap(string search = null);
        void InitiateCheckout();
        void UpdateCheckout();
        void ReadCheckoutLog();
        void CheckIn(string computerName);
        string CreateCSVRow(string[] inputs);
        bool CheckAdmin();
    }
}
