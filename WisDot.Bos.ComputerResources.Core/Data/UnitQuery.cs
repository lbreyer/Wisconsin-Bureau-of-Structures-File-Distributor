using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using WisDot.Bos.ComputerResources.Core.Infrastructure;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    public class UnitQuery : IUnitQuery
    {
        private static string UnitsXmlFilePath = ConfigurationManager.AppSettings["UnitsXmlFilePath"].ToString();
        private static XElement UnitsXml = XElement.Load(UnitsXmlFilePath);

        public void AddSubUnits(Unit parentUnit)
        {
            IEnumerable<XElement> subUnits =
                (
                    from units in UnitsXml.Descendants("Unit")
                    where Convert.ToInt16(units.Parent.Attribute("Location_ID").Value) == parentUnit.UnitID
                    select units
                );

            foreach (XElement subUnit in subUnits)
            {
                int leaderID;
                bool isLeaderIDValid = int.TryParse(subUnit.Element("Leader_ID").Value, out leaderID);

                Unit curUnit = new Unit(Convert.ToInt16(subUnit.Attribute("Location_ID").Value),
                                        subUnit.Element("Location_Name").Value,
                                        0,
                                        isLeaderIDValid ? leaderID : -1,
                                        Constants.UNIT);
                parentUnit.SubUnits.Add(curUnit);
                AddSubUnits(curUnit);
                new UnitRepository().AddEmployees(curUnit);
            }
        }

        public IEnumerable<XElement> GetSections()
        {
            var sections =
               (
                   from sects in UnitsXml.Elements("Section")
                   orderby sects.Element("Location_Name").Value ascending
                   select sects
               );

            return sections;
        }

        public int GetUnitLeader(int unitID)
        {
            int unitLeaderID = -1;
            var theUnit =
                (
                    from unit in UnitsXml.Descendants()
                    where (unit.Attribute("Location_ID") != null
                            && !unit.Attribute("Location_ID").Value.Equals(String.Empty)
                            && Convert.ToInt16(unit.Attribute("Location_ID").Value) == unitID
                          )
                    select unit
                );

            if (theUnit.Count() > 0 && !theUnit.First().Element("Leader_ID").Value.Equals(String.Empty))
            {
                unitLeaderID = Convert.ToInt16(theUnit.First().Element("Leader_ID").Value);
            }

            return unitLeaderID;
        }

        public XElement SelectUnit(int locationID)
        {
            XElement unit = null;
            IEnumerable<XElement> units =
                (
                    from un in UnitsXml.Descendants()
                    where (!un.Attribute("Location_ID").Value.Equals(String.Empty) && Convert.ToInt16(un.Attribute("Location_ID").Value) == locationID)
                    select un
                );

            if (units.Count() > 0)
            {
                unit = units.First();
            }

            return unit;
        }
    }
}
