using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class ComputerQuery : IComputerQuery
    {

        private static string ComputersXmlFilePath = ConfigurationManager.AppSettings["ComputersXmlFilePath"].ToString();
        private static XElement ComputersXml = XElement.Load(ComputersXmlFilePath);

        public void ResetComputerXml(string filePath)
        {
            ComputersXmlFilePath = filePath;
            ComputersXml = XElement.Load(filePath);
        }

        public string ReturnFilePath()
        {
            return ComputersXmlFilePath;
        }

        public IEnumerable<XElement> SelectAllComputers()
        {
            IEnumerable<XElement> comps =
                (
                    from comp in ComputersXml.Elements("UniquePC")
                    orderby comp.Attribute("Name").Value ascending
                    select comp
                );

            return comps;
        }

        public XElement SelectComputer(string computerName)
        {
            IEnumerable<XElement> comps =
                (
                    from comp in ComputersXml.Elements("UniquePC")
                    where comp.Attribute("Name").Value.ToUpper().Equals(computerName.ToUpper())
                    select comp
                );

            if (comps.Count() > 0)
            {
                return comps.First();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<XElement> SelectEmployeeComputers(int employeeID)
        {
            IEnumerable<XElement> comps =
                (
                    from comp in ComputersXml.Elements("UniquePC")
                    where (!comp.Element("Owner").Attribute("Owner_ID").Value.Equals(String.Empty)
                            && Convert.ToInt16(comp.Element("Owner").Attribute("Owner_ID").Value) == employeeID
                            && comp.Element("Is_Active").Value.ToUpper().Equals("YES")
                          )
                    orderby comp.Attribute("Name").Value ascending
                    select comp
                );

            return comps;
        }
    }
}
