using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class DistributionFile
    {
        public string FileName { get; set; }
        public bool IsActive { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }

        public DistributionFile(string fileName, bool isActive, string source = "", string note = "")
        {
            Initialize();
            FileName = fileName;
            IsActive = isActive;
            Note = note;
            Source = source;
        }

        public DistributionFile()
        {
            Initialize();
        }

        private void Initialize()
        {
            FileName = "";
            Source = "";
            Note = "";
        }
    }
}
