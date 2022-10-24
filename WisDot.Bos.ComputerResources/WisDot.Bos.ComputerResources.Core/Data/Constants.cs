using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    public class Constants
    {
        public static string SECTION = "SECTION";
        public static string UNIT = "UNIT";

        public enum ComputerType
        {
            Laptop,
            Desktop,
        }
        public enum DistributeResult
        {
            Failure = 0,
            Success = 1,
            PartialSuccess = 2,
        }

    }
}
