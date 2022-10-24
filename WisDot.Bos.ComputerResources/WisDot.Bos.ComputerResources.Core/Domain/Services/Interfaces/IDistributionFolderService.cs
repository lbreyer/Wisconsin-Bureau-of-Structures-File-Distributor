using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IDistributionFolderService
    {
        void ResetDistributionSourceXml(string filePath);
        List<DistributionFolder> GetFolders(bool activeFoldersOnly);
        DistributionFolder CreateDistributionFolder(XElement folder);
        string GetNote(XElement elem);
        string GetSource(XElement elem);
        IEnumerable<XElement> SelectFolders(bool activeFoldersOnly);
        string ReturnFilePath();

    }
}
