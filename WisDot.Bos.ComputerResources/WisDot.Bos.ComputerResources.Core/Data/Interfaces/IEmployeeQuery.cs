using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // for XmlNodeType enumeration
using System.Xml.Linq; // for XNode and others

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface IEmployeeQuery
    {
        void ResetEmployeeXml(string filePath);
        XElement SelectEmployee(int employeeID);
        IEnumerable<XElement> SelectEmployees(int unitID, string sortField);
        IEnumerable<XElement> SelectEmployees(string sortField);
        string ReturnFilePath();
    }
}
