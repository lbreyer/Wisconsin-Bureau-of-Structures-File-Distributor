using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class FileSource
    {
        public string Name { get; set; }
        public bool IsOverwritten { get; set; }
        public string SourcePath { get; set; } // full path 
        public string DestinationPath { get; set; } //directory
        public bool IsFolder { get; set; }
        public List<Machine> FailMachines { get; set; }
        public List<Machine> PartialSuccessMachines { get; set; }
        public List<Machine> SuccessMachines { get; set; }
        public List<string> DistributeErrors { get; set; }
        public List<FileInfo> SpecialFiles { get; set; }

        public FileSource(string name, string sourcePath, string destinationPath,
            bool isOverwritten, bool isFolder, List<FileInfo> specialFiles = null)
        {
            Initialize();
            this.Name = name;
            this.SourcePath = sourcePath;
            this.DestinationPath = destinationPath;
            this.IsOverwritten = isOverwritten;
            this.IsFolder = isFolder;
            if (isFolder && specialFiles != null)
            {
                this.SpecialFiles = specialFiles;
            }
        }

        public FileSource()
        {
            Initialize();
        }

        private void Initialize()
        {
            Name = "";
            SourcePath = "";
            DestinationPath = "";
            FailMachines = new List<Machine>();
            PartialSuccessMachines = new List<Machine>();
            DistributeErrors = new List<string>();
            SuccessMachines = new List<Machine>();
            SpecialFiles = new List<FileInfo>();
        }
    }
}
