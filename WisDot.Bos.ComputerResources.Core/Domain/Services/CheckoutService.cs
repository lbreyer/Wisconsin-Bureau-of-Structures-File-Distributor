using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using Microsoft.VisualBasic.FileIO;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using System.IO;
using System.Xml;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class CheckoutService : ICheckoutService
    {
        private static ICheckoutQuery query = new CheckoutQuery();
        private static ICheckoutRepository repo = new CheckoutRepository();

        public bool CheckAdmin()
        {
            return query.CheckAdmin();
        }

        public void CheckIn(List<string[]> data, List<string[]> checkoutData)
        {
            query.CheckIn(data, checkoutData);
        }

        public string CreateCSVRow(string[] inputs)
        {
            return query.CreateCSVRow(inputs);
        }

        public void InitiateCheckout(ComboBox cbNames)
        {
            repo.InitiateCheckout(cbNames);
        }

        public void ReadParser(List<string[]> checkoutData)
        {
            query.ReadParser(checkoutData);
        }

        public string UpdateAvailable(List<Computer> outLaptops, List<Computer> availableLaptops, List<string[]> outLaptopData)
        {
            return repo.UpdateAvailable(outLaptops, availableLaptops, outLaptopData);
        }
    }
}
