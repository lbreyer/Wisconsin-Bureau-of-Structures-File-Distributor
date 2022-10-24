using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces
{
    interface IDistributionFolderRepository
    {
        DistributionFolder CreateDistributionFolder(XElement folder);
        List<DistributionFolder> GetFolders(IEnumerable<XElement> selectedFolders);
        string GetNote(XElement elem);
        string GetSource(XElement elem);
    }
}
