using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IEmployeeService
    {
        void ResetEmployeeXml(string filePath);
        List<Computer> GetEmployeeComputers(int employeeID);
        Employee CreateEmployee();
        Employee CreateEmployee(int employeeID);
        XElement SelectEmployee(int employeeID);
        IEnumerable<XElement> SelectEmployees(int unitID, string sortField);
        IEnumerable<XElement> SelectEmployees(string sortField);
        Employee GetEmployee(int employeeID);
        List<Employee> GetEmployees();
        List<Employee> GetEmployees(int unitID);
        bool IsEmployeeUnitLeader(int employeeID, int unitID);
        string ReturnFilePath();
    }
}
