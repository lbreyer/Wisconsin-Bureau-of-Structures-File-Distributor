using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class ComputerService : IComputerService
    {

        private static IComputerQuery query = new ComputerQuery();
        private static IComputerRepository repo = new ComputerRepository();

        public void ResetComputerXml(string filePath)
        {
            query.ResetComputerXml(filePath);
        }

        public Computer CreateComputer(XElement computer)
        {
            return repo.CreateComputer(computer);
        }

        public IEnumerable<XElement> SelectAllComputers()
        {
            return query.SelectAllComputers();
        }

        public XElement SelectComputer(string computerName)
        {
            return query.SelectComputer(computerName);
        }

        public IEnumerable<XElement> SelectEmployeeComputers(int employeeID)
        {
            return query.SelectEmployeeComputers(employeeID);
        }

        public List<Computer> GetEmployeeComputers(int employeeID)
        {

            IEnumerable<XElement> comps = SelectEmployeeComputers(employeeID);
            return repo.GetComputers(comps);
        }

        public List<Computer> GetAllComputers()
        {
            IEnumerable<XElement> comps = SelectAllComputers();
            return repo.GetComputers(comps);
        }

        public Computer GetComputer(string computerName)
        {
            Computer aComputer = null;

            if (SelectComputer(computerName) != null)
            {
                aComputer = CreateComputer(SelectComputer(computerName));
            }

            return aComputer;
        }

        public string ReturnFilePath()
        {
            return query.ReturnFilePath();
        }
    }
}
