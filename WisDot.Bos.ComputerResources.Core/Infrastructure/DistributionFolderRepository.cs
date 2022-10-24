using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class DistributionFolderRepository : IDistributionFolderRepository
    {
        public DistributionFolder CreateDistributionFolder(XElement folder)
        {
            DistributionFolder newFolder = new DistributionFolder()
            {
                Name = folder.Element("name").Value.Trim(),
                SourcePath = folder.Element("path").Value.Trim(),
                DestinationPath = folder.Element("destination").Value.Trim(),
                TFSsource = GetSource(folder),
                Note = GetNote(folder)
            };
            if (folder.Element("active").Value.ToUpper().Equals("TRUE"))
            {
                newFolder.IsActive = true;
            }
            else
            {
                newFolder.IsActive = false;
            }

            if (folder.Element("distribute_all").Value.ToUpper().Equals("TRUE"))
            {
                newFolder.IsEntireFolderDistributed = true;
            }
            else
            {
                newFolder.IsEntireFolderDistributed = false;
            }

            try
            {
                if (folder.Element("files").Elements("file").Where(f => f.Element("active").Value.ToUpper().Equals("TRUE")) != null)
                {
                    foreach (var file in folder.Element("files").Elements("file").Where(f => f.Element("active").Value.ToUpper().Equals("TRUE")).OrderBy(g => g.Element("path").Value))
                    {
                        DistributionFile curFile = new DistributionFile()
                        {
                            FileName = file.Element("path").Value.Trim(),
                            IsActive = true,
                            Source = GetSource(file),
                            Note = GetNote(file)
                        };
                        newFolder.DistributionFiles.Add(curFile);
                    }
                }
            }
            catch
            {

            }

            return newFolder;
        }

        public List<DistributionFolder> GetFolders(IEnumerable<XElement> selectedFolders)
        {
            List<DistributionFolder> distributionFolders = new List<DistributionFolder>();

            foreach (XElement selectedFolder in selectedFolders)
            {
                DistributionFolder curFolder = CreateDistributionFolder(selectedFolder);

                distributionFolders.Add(curFolder);
            }

            return distributionFolders;
        }

        public string GetNote(XElement elem)
        {
            var noteEl = elem.Element("note");
            string note;
            if (noteEl != null)
            {
                note = noteEl.Value;
            }
            else
            {
                note = "";
            }
            return note;
        }

        public string GetSource(XElement elem)
        {
            var sourceEl = elem.Element("source");
            string source;
            if (sourceEl != null)
            {
                source = sourceEl.Value;
            }
            else
            {
                source = "";
            }
            return source;
        }
    }
}
