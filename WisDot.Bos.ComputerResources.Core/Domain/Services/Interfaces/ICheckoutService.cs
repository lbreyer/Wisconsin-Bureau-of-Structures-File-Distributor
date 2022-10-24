using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    public interface ICheckoutService
    {
        void InitiateCheckout(ComboBox cbNames);
        void ReadParser(List<string[]> checkoutData);
        string UpdateAvailable(List<Computer> outLaptops, List<Computer> availableLaptops, List<string[]> outLaptopData);
        void CheckIn(List<string[]> data, List<string[]> checkoutData);
        string CreateCSVRow(string[] inputs);
        bool CheckAdmin();
    }
}
