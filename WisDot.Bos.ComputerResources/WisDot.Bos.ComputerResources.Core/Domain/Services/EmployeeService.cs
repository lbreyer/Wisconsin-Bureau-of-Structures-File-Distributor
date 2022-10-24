using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static IEmployeeQuery query = new EmployeeQuery();
        private static IEmployeeRepository repo = new EmployeeRepository();

        public Employee CreateEmployee()
        {
            return repo.CreateEmployee();
        }

        public Employee CreateEmployee(int employeeID)
        {
            XElement selectEmployee = SelectEmployee(employeeID);
            return repo.CreateEmployee(selectEmployee);
        }

        public Employee GetEmployee(int employeeID)
        {
            return CreateEmployee(employeeID);
        }

        public List<Computer> GetEmployeeComputers(int employeeID)
        {
            return repo.GetEmployeeComputers(employeeID);
        }

        public List<Employee> GetEmployees(int unitID)
        {
            IEnumerable<XElement> selectedEmployees = SelectEmployees(unitID, "DEFAULT");
            return repo.GetEmployees(selectedEmployees);
        }

        public List<Employee> GetEmployees()
        {
            IEnumerable<XElement> selectedEmployees = SelectEmployees("DEFAULT");
            return repo.GetEmployees(selectedEmployees);
        }

        public bool IsEmployeeUnitLeader(int employeeID, int unitID)
        {
            return repo.IsEmployeeUnitLeader(employeeID, unitID);
        }

        public void ResetEmployeeXml(string filePath)
        {
            query.ResetEmployeeXml(filePath);
        }

        public string ReturnFilePath()
        {
            return query.ReturnFilePath();
        }

        public XElement SelectEmployee(int employeeID)
        {
            return query.SelectEmployee(employeeID);
        }

        public IEnumerable<XElement> SelectEmployees(int unitID, string sortField)
        {
            return query.SelectEmployees(unitID, sortField);
        }

        public IEnumerable<XElement> SelectEmployees(string sortField)
        {
            return query.SelectEmployees(sortField);
        }
    }
}
