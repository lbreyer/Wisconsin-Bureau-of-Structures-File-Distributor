using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface ICheckoutQuery
    {
        bool CheckAdmin();
        void CheckIn(List<string[]> data, List<string[]> checkoutData);
        string CreateCSVRow(string[] inputs);
        void ReadParser(List<string[]> checkoutData);
    }
}
