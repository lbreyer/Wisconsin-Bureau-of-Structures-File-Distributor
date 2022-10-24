using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class CheckoutRepository : ICheckoutRepository
    {
        public void InitiateCheckout(ComboBox cbNames)
        {
            ViewConst.EMPS.OrderBy(e => e.LastName).ThenBy(e => e.FirstName);

            foreach (Employee emp in ViewConst.EMPS)
            {
                if (!emp.IsActive) continue;
                cbNames.Items.Add(emp.LastName + ", " + emp.FirstName);
                if (emp.LogonID.ToUpper() == ViewConst.LOGINID.ToUpper())
                {
                    cbNames.SelectedIndex = cbNames.Items.Count - 1;
                }
            }
        }

        public string UpdateAvailable(List<Computer> outLaptops, List<Computer> availableLaptops, List<string[]> outLaptopData)
        {
            string outLaptop = null;
            foreach (Computer lappy in ViewConst.LAPTOPS)
            {
                bool isAvailable = true;
                foreach (string[] data in outLaptopData)
                {
                    if (data[0].Contains(lappy.ComputerName))
                    {
                        isAvailable = false;
                        if (data[1].ToUpper().Contains(ViewConst.LOGINID.ToUpper()))
                            outLaptop = lappy.ComputerName;
                    }
                }
                if (isAvailable) availableLaptops.Add(lappy);
                else outLaptops.Add(lappy);
            }
            return outLaptop;
        }
    }
}
