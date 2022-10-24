using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class UnitRepository : IUnitRepository
    {
        private static IEmployeeService serv = new EmployeeService();
        private static IUnitService uServ = new UnitService();

        public void AddEmployees(Unit parentUnit)
        {
            List<Employee> unitEmployees = serv.GetEmployees(parentUnit.UnitID);

            foreach (Employee emp in unitEmployees)
            {
                parentUnit.UnitEmployees.Add(emp);
            }
        }

        public Unit CreateUnit(int locationID)
        {
            Unit aUnit = new Unit();

            return aUnit;
        }

        public List<Unit> GetSectionUnits()
        {
            Unit aUnit = new Unit();
            List<Unit> units = new List<Unit>();
            IEnumerable<XElement> sections = uServ.GetSections();

            foreach (XElement section in sections)
            {
                int leaderID;
                bool isLeaderIDValid = int.TryParse(section.Element("Leader_ID").Value, out leaderID);

                Unit curUnit = new Unit(Convert.ToInt16(section.Attribute("Location_ID").Value),
                                        section.Element("Location_Name").Value,
                                        0,
                                        isLeaderIDValid ? leaderID : -1,
                                        Constants.SECTION);
                uServ.AddSubUnits(curUnit);
                AddEmployees(curUnit);

                units.Add(curUnit);
            }

            return units;
        }
    }
}
