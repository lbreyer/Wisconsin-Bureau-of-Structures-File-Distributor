using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces
{
    interface ICheckoutRepository
    {
        void InitiateCheckout(ComboBox cbNames);
        string UpdateAvailable(List<Computer> outLaptops, List<Computer> availableLaptops, List<string[]> outLaptopData);
    }
}
