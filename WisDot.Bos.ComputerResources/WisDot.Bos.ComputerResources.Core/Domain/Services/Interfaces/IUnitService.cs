using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IUnitService
    {
        IEnumerable<XElement> GetSections();
        Unit CreateUnit(int locationID);
        XElement SelectUnit(int locationID);
        List<Unit> GetSectionUnits();
        void AddSubUnits(Unit parentUnit);
        void AddEmployees(Unit parentUnit);
        void AddEmployees();
        int GetUnitLeader(int unitID);

    }
}
