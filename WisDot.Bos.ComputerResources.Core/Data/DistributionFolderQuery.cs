using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class DistributionFolderQuery : IDistributionFolderQuery
    {
        private static string DistributionSourceXmlFilePath = ConfigurationManager.AppSettings["DistributionSourceXmlFilePath"].ToString();
        private static XElement DistributionSourceXml = XElement.Load(DistributionSourceXmlFilePath);

        public void ResetDistributionSourceXml(string filePath)
        {
            DistributionSourceXmlFilePath = filePath;
            DistributionSourceXml = XElement.Load(filePath);
        }

        public IEnumerable<XElement> SelectFolders(bool activeFoldersOnly)
        {
            IEnumerable<XElement> folders = null;

            if (activeFoldersOnly)
            {
                folders =
                    (
                        from folder in DistributionSourceXml.Elements("folder")
                        where folder.Element("active").Value.ToUpper().Equals("TRUE")
                        orderby folder.Element("name").Value ascending
                        select folder
                    );
            }
            else
            {
                folders =
                    (
                        from folder in DistributionSourceXml.Elements("folder")
                        orderby folder.Element("name").Value ascending
                        select folder
                    );
            }

            return folders;
        }

        public string ReturnFilePath()
        {
            return DistributionSourceXmlFilePath;
        }
    }
}
