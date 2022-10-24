using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Services;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class EmployeeRepository : IEmployeeRepository
    {
        public Employee CreateEmployee()
        {
            Employee employee = new Employee();

            return employee;
        }

        public Employee CreateEmployee(XElement selectEmployee)
        {
            Employee employee = new Employee();

            if (selectEmployee != null)
            {
                employee.EmployeeID = Convert.ToInt16(selectEmployee.Attribute("Owner_ID").Value);
                employee.FirstName = selectEmployee.Element("First_Name").Value;
                employee.IsActive = selectEmployee.Element("Is_Active").Value.ToUpper().Equals("YES") ? true : false;
                employee.IsFullTimeEmployee = selectEmployee.Element("Is_FTE").Value.ToUpper().Equals("YES") ? true : false;
                employee.LastName = selectEmployee.Element("Last_Name").Value;
                employee.LogonID = selectEmployee.Element("Logon_ID").Value;
                employee.PhoneNumber = selectEmployee.Element("Phone").Value;
                employee.UnitID = Convert.ToInt16(selectEmployee.Element("Located_In").Value);

                if (IsEmployeeUnitLeader(employee.EmployeeID, employee.UnitID))
                {
                    employee.IsLeader = true;
                }

                employee.Computers.AddRange(GetEmployeeComputers(employee.EmployeeID));
            }

            return employee;
        }

        public List<Computer> GetEmployeeComputers(int employeeID)
        {
            List<Computer> employeeComps = new List<Computer>();
            employeeComps = new ComputerService().GetEmployeeComputers(employeeID);

            return employeeComps;
        }

        public List<Employee> GetEmployees(IEnumerable<XElement> selectedEmployees)
        {
            List<Employee> employees = new List<Employee>();

            foreach (var selectedEmployee in selectedEmployees)
            {
                Employee curEmp = new EmployeeService().CreateEmployee(Convert.ToInt16(selectedEmployee.Attribute("Owner_ID").Value));
                employees.Add(curEmp);
            }

            return employees;
        }

        public bool IsEmployeeUnitLeader(int employeeID, int unitID)
        {
            bool isEmployeeUnitLeader = false;
            int unitLeaderID = new UnitService().GetUnitLeader(unitID);

            if (unitLeaderID == employeeID)
            {
                isEmployeeUnitLeader = true;
            }

            return isEmployeeUnitLeader;
        }
    }
}
