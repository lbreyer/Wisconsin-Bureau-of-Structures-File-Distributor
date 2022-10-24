using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class UnitService : IUnitService
    {
        private static IUnitQuery query = new UnitQuery();
        private static IUnitRepository repo = new UnitRepository();

        public void AddEmployees(Unit parentUnit)
        {
            repo.AddEmployees(parentUnit);
        }

        public void AddEmployees()
        {
            
        }

        public void AddSubUnits(Unit parentUnit)
        {
            query.AddSubUnits(parentUnit);
        }

        public Unit CreateUnit(int locationID)
        {
            return repo.CreateUnit(locationID);
        }

        public IEnumerable<XElement> GetSections()
        {
            return query.GetSections();
        }

        public List<Unit> GetSectionUnits()
        {
            return repo.GetSectionUnits();
        }

        public int GetUnitLeader(int unitID)
        {
            return query.GetUnitLeader(unitID);
        }

        public XElement SelectUnit(int locationID)
        {
            return query.SelectUnit(locationID);
        }
    }
}
