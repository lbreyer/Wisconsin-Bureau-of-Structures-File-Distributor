using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Domain.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string LogonID { get; set; }
        public bool IsActive { get; set; }
        public bool IsFullTimeEmployee { get; set; }
        public string PhoneNumber { get; set; }
        public int UnitID { get; set; }
        public bool IsLeader { get; set; }
        public List<Computer> Computers { get; set; }

        public Employee(int employeeID, string lastName, string firstName, string logonID)
        {
            Initialize();
            EmployeeID = employeeID;
            LastName = lastName;
            FirstName = firstName;
            LogonID = logonID;
        }

        public Employee()
        {
            Initialize();
        }

        private void Initialize()
        {
            LastName = "";
            FirstName = "";
            LogonID = "";
            PhoneNumber = "";
            IsLeader = false;
            Computers = new List<Computer>();
        }
    }
}
