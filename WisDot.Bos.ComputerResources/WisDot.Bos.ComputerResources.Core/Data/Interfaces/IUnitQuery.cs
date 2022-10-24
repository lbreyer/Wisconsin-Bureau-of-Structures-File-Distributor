using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface IUnitQuery
    {
        void AddSubUnits(Unit parentUnit);
        IEnumerable<XElement> GetSections();
        int GetUnitLeader(int unitID);
        XElement SelectUnit(int locationID);
    }
}
