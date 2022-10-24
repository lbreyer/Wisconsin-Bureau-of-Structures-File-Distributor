using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string UnitLevel { get; set; }
        public int ParentID { get; set; }
        public int LeaderID { get; set; }
        public List<Employee> UnitEmployees { get; set; }
        public List<Unit> SubUnits { get; set; }

        public Unit(int unitID, string unitName, int parentID, int leaderID, string unitLevel)
        {
            Initialize();
            UnitID = unitID;
            UnitName = unitName;
            ParentID = parentID;
            LeaderID = leaderID;
            UnitLevel = unitLevel;
        }

        public Unit()
        {
            Initialize();
        }

        private void Initialize()
        {
            UnitName = "";
            UnitLevel = "";
            UnitEmployees = new List<Employee>();
            SubUnits = new List<Unit>();
        }
    }
}
