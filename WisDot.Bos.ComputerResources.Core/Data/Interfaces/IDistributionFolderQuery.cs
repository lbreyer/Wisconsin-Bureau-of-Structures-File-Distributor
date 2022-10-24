using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface IDistributionFolderQuery
    {
        void ResetDistributionSourceXml(string filePath);
        IEnumerable<XElement> SelectFolders(bool activeFoldersOnly);
        string ReturnFilePath();
    }
}
