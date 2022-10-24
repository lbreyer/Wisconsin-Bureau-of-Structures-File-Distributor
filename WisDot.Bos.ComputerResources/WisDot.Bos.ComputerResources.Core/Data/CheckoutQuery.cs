using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Data;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class CheckoutQuery : ICheckoutQuery
    {
        public bool CheckAdmin()
        {
            try
            {
                XmlDocument adminDoc = new XmlDocument { PreserveWhitespace = false };
                adminDoc.Load(ConfigurationManager.AppSettings["AdminDoc"].ToString());
                foreach (XmlNode node in adminDoc.SelectNodes("/users/category"))
                {
                    if (node.Attributes["name"].InnerText == "Admin")
                    {
                        foreach (XmlNode user in node.ChildNodes)
                        {
                            if (user.Attributes["id"].InnerText.ToUpper() == ViewConst.LOGINID.ToUpper())
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            catch { }

            return false;
        }

        public void CheckIn(List<string[]> data, List<string[]> checkoutData)
        {
            if (data.Count > 0)
            {
                int i = checkoutData.IndexOf(data[0]);
                checkoutData[i][5] = "true";
                string output = "";
                foreach (string[] line in checkoutData)
                {
                    output += CreateCSVRow(line);
                }
                File.WriteAllText(ViewConst.CHECKOUTLOG, output);
            }
        }

        public string CreateCSVRow(string[] inputs)
        {
            return "\"" + string.Join("\", \"", inputs) + "\"" + Environment.NewLine;
        }

        public void ReadParser(List<string[]> checkoutData)
        {
            using (TextFieldParser parser = new TextFieldParser(ViewConst.CHECKOUTLOG))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    checkoutData.Add(parser.ReadFields());
                }
            }
        }
    }
}
