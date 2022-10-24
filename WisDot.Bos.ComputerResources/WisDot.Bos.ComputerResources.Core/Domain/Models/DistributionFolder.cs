using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class DistributionFolder
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string SourcePath { get; set; }
        public bool IsEntireFolderDistributed { get; set; }
        public string DestinationPath { get; set; }
        public string TFSsource { get; set; }
        public string Note { get; set; }
        public List<DistributionFile> DistributionFiles { get; set; }

        public DistributionFolder(string name, bool isActive, string sourcePath,
            bool isEntireFolderDistributed, string destinationPath, string note, string tfsSource)
        {
            Initialize();
            Name = name;
            IsActive = isActive;
            SourcePath = sourcePath;
            IsEntireFolderDistributed = isEntireFolderDistributed;
            DestinationPath = destinationPath;
            TFSsource = tfsSource;
            Note = note;
        }
        public DistributionFolder()
        {
            Initialize();
        }

        private void Initialize()
        {
            Name = "";
            SourcePath = "";
            DestinationPath = "";
            TFSsource = "";
            Note = "";
            DistributionFiles = new List<DistributionFile>();
        }

    }
}
