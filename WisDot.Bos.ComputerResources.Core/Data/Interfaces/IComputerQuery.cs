using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface IComputerQuery
    {
        IEnumerable<XElement> SelectAllComputers();
        XElement SelectComputer(string computerName);
        IEnumerable<XElement> SelectEmployeeComputers(int employeeID);
        void ResetComputerXml(string filePath);
        string ReturnFilePath();
    }
}
