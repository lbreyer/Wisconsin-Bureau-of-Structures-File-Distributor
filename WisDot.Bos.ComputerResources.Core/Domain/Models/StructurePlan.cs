using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class StructurePlan
    {
        private static string BridgePlansDirectory = ConfigurationManager.AppSettings["BridgePlansDirectory"].ToString();

        public StructurePlan(string bridgePlansDirectory)
        {
            if (Directory.Exists(bridgePlansDirectory))
            {
                BridgePlansDirectory = bridgePlansDirectory;
            }
        }


        public static string[] SearchPlansDirectory(string searchPattern, SearchOption searchOption)
        {
            string[] matchingDirs = Directory.GetDirectories(BridgePlansDirectory, searchPattern, searchOption);
            return matchingDirs;
        }
    }
}
