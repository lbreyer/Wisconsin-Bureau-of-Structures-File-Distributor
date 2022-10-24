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
    public interface IComputerService
    {
        void ResetComputerXml(string filePath);
        Computer CreateComputer(XElement computer);
        IEnumerable<XElement> SelectAllComputers();
        XElement SelectComputer(string computerName);
        IEnumerable<XElement> SelectEmployeeComputers(int employeeID);
        List<Computer> GetEmployeeComputers(int employeeID);
        List<Computer> GetAllComputers();
        Computer GetComputer(string computerName);
        string ReturnFilePath();
    }
}
