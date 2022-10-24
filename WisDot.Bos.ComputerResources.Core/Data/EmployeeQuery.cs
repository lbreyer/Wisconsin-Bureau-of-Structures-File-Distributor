using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using System.Configuration;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class EmployeeQuery : IEmployeeQuery
    {
        private static string EmployeesXmlFilePath = ConfigurationManager.AppSettings["EmployeesXmlFilePath"].ToString();
        private static XElement EmployeesXml = XElement.Load(EmployeesXmlFilePath);

        public void ResetEmployeeXml(string filePath)
        {
            EmployeesXmlFilePath = filePath;
            EmployeesXml = XElement.Load(filePath);
        }

        public string ReturnFilePath()
        {
            return EmployeesXmlFilePath;
        }

        public XElement SelectEmployee(int employeeID)
        {
            XElement employee = null;
            IEnumerable<XElement> employees =
                (
                    from emp in EmployeesXml.Elements("Device_Owner")
                    where Convert.ToInt16(emp.Attribute("Owner_ID").Value) == employeeID
                    select emp
                );

            if (employees.Count() > 0)
            {
                employee = employees.First();
            }

            return employee;
        }

        public IEnumerable<XElement> SelectEmployees(int unitID, string sortField)
        {
            IEnumerable<XElement> employees = null;

            switch (sortField.ToUpper())
            {
                case "OWNERID":
                    employees =
                       (
                           from emp in EmployeesXml.Elements("Device_Owner")
                           where (!emp.Element("Located_In").Value.Equals(String.Empty) && Convert.ToInt16(emp.Element("Located_In").Value) == unitID)
                           orderby emp.Attribute("Owner_ID").Value
                           select emp
                       );
                    break;
                default:
                    employees =
                       (
                           from emp in EmployeesXml.Elements("Device_Owner")
                           where (!emp.Element("Located_In").Value.Equals(String.Empty) && Convert.ToInt16(emp.Element("Located_In").Value) == unitID)
                           orderby emp.Element("Last_Name").Value ascending, emp.Element("First_Name").Value ascending
                           select emp
                       );
                    break;

            }

            return employees;
        }

        public IEnumerable<XElement> SelectEmployees(string sortField)
        {
            IEnumerable<XElement> employees = null;

            switch (sortField.ToUpper())
            {
                case "OWNERID":
                    employees =
                        (
                            from emp in EmployeesXml.Elements("Device_Owner")
                            where emp.Element("Is_Active").Value.ToUpper().Equals("YES")
                            orderby emp.Attribute("Owner_ID").Value ascending
                            select emp
                        );
                    break;
                default:
                    employees =
                        (
                            from emp in EmployeesXml.Elements("Device_Owner")
                            where emp.Element("Is_Active").Value.ToUpper().Equals("YES")
                            orderby emp.Element("Last_Name").Value ascending, emp.Element("First_Name").Value ascending
                            select emp
                        );
                    break;
            }

            return employees;
        }
    }
}
