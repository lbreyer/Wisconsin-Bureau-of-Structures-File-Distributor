using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces
{
    interface IEmployeeRepository
    {
        Employee CreateEmployee();
        Employee CreateEmployee(XElement selectEmployee);
        List<Computer> GetEmployeeComputers(int employeeID);
        List<Employee> GetEmployees(IEnumerable<XElement> selectedEmployees);
        bool IsEmployeeUnitLeader(int employeeID, int unitID);
    }
}
