using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using System.Diagnostics;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class TreeRepository : ITreeRepository
    {
        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            TreeNode location = new TreeNode
            {
                Text = String.Format(@"Cube #: {0}", computer.Location),
                Tag = ViewConst.NodeTags.Location,
                ImageIndex = 8,
                SelectedImageIndex = 8
            };
            computerNode.Nodes.Add(location);

            TreeNode yearNode = new TreeNode
            {
                Text = String.Format(@"Install Year: {0}", computer.InstallFiscalYear),
                Tag = ViewConst.NodeTags.ComputerInfo,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            computerNode.Nodes.Add(yearNode);

            TreeNode swNode = new TreeNode
            {
                Text = String.Format(@"Special S/W: {0}", computer.SpecialSoftware),
                Tag = ViewConst.NodeTags.ComputerInfo,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            computerNode.Nodes.Add(swNode);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            if (employee.FirstName == "BOS" && employee.LastName == "BOS")
            {
                return;
            }
            string empLocation = "";
            foreach (Computer computer in employee.Computers)
            {
                if (empLocation == "") empLocation = computer.Location;
                else if (empLocation != computer.Location) empLocation = "N/A";
            }

            TreeNode locationNode = new TreeNode
            {
                Text = string.Format(@"Cube #: {0}", empLocation),
                Tag = ViewConst.NodeTags.Location,
                ImageIndex = 8,
                SelectedImageIndex = 8
            };
            employeeNode.Nodes.Add(locationNode);

            TreeNode phoneNode = new TreeNode
            {
                Text = String.Format(@"Phone #: {0}", employee.PhoneNumber),
                Tag = ViewConst.NodeTags.Phone,
                ImageIndex = 7,
                SelectedImageIndex = 7
            };
            employeeNode.Nodes.Add(phoneNode);

            TreeNode logonNode = new TreeNode
            {
                Text = String.Format("Logon ID: {0}", employee.LogonID),
                Tag = ViewConst.NodeTags.EmployeeInfo,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            employeeNode.Nodes.Add(logonNode);

            if (employee.IsLeader)
            {
                TreeNode leaderNode = new TreeNode
                {
                    Text = "Leader",
                    Tag = ViewConst.NodeTags.EmployeeInfo,
                    ImageIndex = 6
                };
                employeeNode.Nodes.Add(leaderNode);
            }
        }

        public void AddUnitNode(Unit unit, TreeNode parentTreeNode, TreeView treeViewComputers)
        {
            TreeNode treeNode = CreateUnitTreeNode(unit);
            TreeNode newParentNode = null;

            if (parentTreeNode == null)
            {
                treeViewComputers.Nodes.Add(treeNode);
                newParentNode = treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1];
            }
            else
            {
                parentTreeNode.Nodes.Add(treeNode);
                newParentNode = parentTreeNode.Nodes[parentTreeNode.Nodes.Count - 1];
            }

            foreach (Employee emp in unit.UnitEmployees)
            {
                if (!emp.IsActive) continue;
                TreeNode empNode = CreateEmployeeTreeNode(emp);
                newParentNode.Nodes.Add(empNode);

                AddEmployeeInfoNodes(newParentNode.Nodes[newParentNode.Nodes.Count - 1], emp);

                bool isBosBos = (emp.FirstName == "BOS" && emp.LastName == "BOS") ? true : false;
                int BosOrdered = 2;

                comploop:
                foreach (Computer computer in emp.Computers)
                {
                    if (isBosBos && BosOrdered == 2 && !computer.ComputerAlias.Contains("[Remote PC]")) continue;
                    if (isBosBos && BosOrdered == 1 && !computer.ComputerAlias.Contains("Checkout")) continue;
                    if (isBosBos && BosOrdered == 0 &&
                        (computer.ComputerAlias.Contains("[Remote PC]") || computer.ComputerAlias.Contains("Checkout"))) continue;
                    if (computer.IsActive)
                    {

                        TreeNode compNode = CreateComputerTreeNode(computer);
                        newParentNode.Nodes[newParentNode.Nodes.Count - 1].Nodes.Add(compNode);

                        int computerIndex = newParentNode.Nodes[newParentNode.Nodes.Count - 1].Nodes.Count - 1;

                        TreeNode newComputerNode = newParentNode.Nodes[newParentNode.Nodes.Count - 1].Nodes[computerIndex];
                        AddComputerInfoNodes(newComputerNode, computer);

                    }
                }
                if (isBosBos && BosOrdered > 0)
                {
                    BosOrdered--;
                    goto comploop;
                }
            }

            foreach (Unit subUnit in unit.SubUnits)
            {
                AddUnitNode(subUnit, newParentNode, treeViewComputers);
            }
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            TreeNode compNode = new TreeNode
            {
                Text = computer.ComputerName
            };


            if (computer.ComputerAlias.Length > 0)
            {
                compNode.Text = String.Format(@"{0}: {1}", computer.ComputerAlias, computer.ComputerName);
            }

            compNode.Name = computer.ComputerName;
            if (computer.IsRemote)
            {
                compNode.Tag = ViewConst.NodeTags.RemoteComputer;
            }
            else
            {
                compNode.Tag = ViewConst.NodeTags.Computer;
            }

            if (computer.ComputerType == Constants.ComputerType.Laptop)
            {
                compNode.ImageIndex = 2;
                compNode.SelectedImageIndex = 2;
            }
            else
            {
                compNode.ImageIndex = 3;
                compNode.SelectedImageIndex = 3;
            }

            return compNode;
        }

        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            TreeNode empNode = new TreeNode
            {
                Text = employee.LastName + ", " + employee.FirstName,
                Name = employee.EmployeeID.ToString(),
                Tag = ViewConst.NodeTags.Employee
            };

            if (employee.IsLeader)
            {
                empNode.ImageIndex = 1;
                empNode.SelectedImageIndex = 1;
            }
            else
            {
                empNode.ImageIndex = 1;
                empNode.SelectedImageIndex = 1;
            }

            return empNode;
        }

        public TreeNode CreateUnitTreeNode(Unit unit)
        {
            TreeNode treeNode = new TreeNode
            {
                Text = unit.UnitName,
                Name = unit.UnitID.ToString(),
                Tag = unit.UnitLevel,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };

            return treeNode;
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers)
        {
            bool BosAdded = false;
            loop:
            foreach (Employee employee in ViewConst.EMPS)
            {
                bool isBosBos = (employee.FirstName == "BOS" && employee.LastName == "BOS") ? true : false;

                if (!BosAdded && !isBosBos) continue;
                if (BosAdded && isBosBos) continue;
                if (!employee.IsActive) continue;

                TreeNode empNode = CreateEmployeeTreeNode(employee);
                treeViewComputers.Nodes.Add(empNode);

                AddEmployeeInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1], employee);

                string empLocation = "";
                foreach (Computer computer in employee.Computers)
                {
                    if (empLocation == "") empLocation = computer.Location;
                    else if (empLocation != computer.Location) empLocation = "N/A";
                }

                if (isBosBos)
                {
                    int remoteOrdered = 2;
                    comploop:
                    foreach (Computer computer in employee.Computers)
                    {
                        if (remoteOrdered == 2 && !computer.ComputerAlias.Contains("[Remote PC]")) continue;
                        if (remoteOrdered == 1 && !computer.ComputerAlias.Contains("Checkout")) continue;
                        if (remoteOrdered == 0 && (computer.ComputerAlias.Contains("[Remote PC]") 
                            || computer.ComputerAlias.Contains("Checkout"))) continue;
                        TreeNode compNode = CreateComputerTreeNode(computer);
                        treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Add(compNode);

                        int computerIndex = treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Count - 1;

                        AddComputerInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes[computerIndex], computer);
                    }
                    if (remoteOrdered > 0)
                    {
                        remoteOrdered--;
                        goto comploop;
                    }
                }
                else
                {
                    foreach (Computer computer in employee.Computers)
                    {
                        TreeNode compNode = CreateComputerTreeNode(computer);
                        treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Add(compNode);

                        int computerIndex = treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Count - 1;

                        AddComputerInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes[computerIndex], computer);
                    }
                }

                if (!BosAdded)
                {
                    BosAdded = true;
                    goto loop;
                }
            }
        }

        public void DisplayComputerTreeSearchView(TreeView treeViewComputers, string search, string Case)
        {
            foreach (Employee employee in ViewConst.EMPS)
            {
                if (!employee.IsActive) continue;
                switch(Case)
                {
                    case ("Name"):
                        string fullName = employee.FirstName + " " + employee.LastName;
                        if (!fullName.ToLower().Contains(search.ToLower()))
                        {
                            continue;
                        }
                        break;
                    case ("Cube #"):
                        bool check = false;
                        foreach (Computer computer in employee.Computers)
                        {
                            if (computer.Location.ToLower().Contains(search.ToLower()))
                            {
                                check = true;
                            }
                        }
                        if (check)
                        {
                            break;
                        }
                        continue;
                    case ("Logon ID"):
                        if (!employee.LogonID.ToLower().Contains(search.ToLower()))
                        {
                            continue;
                        }
                        break;
                    case ("Computer ID"):
                        check = false;
                        foreach (Computer computer in employee.Computers)
                        {
                            if (computer.ComputerName.ToLower().Contains(search.ToLower()))
                            {
                                check = true;
                            }
                        }
                        if (check)
                        {
                            break;
                        }
                        continue;
                    default:
                        return;
                }

                TreeNode empNode = CreateEmployeeTreeNode(employee);
                treeViewComputers.Nodes.Add(empNode);

                AddEmployeeInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1], employee);

                string empLocation = "";
                foreach (Computer computer in employee.Computers)
                {
                    if (empLocation == "") empLocation = computer.Location;
                    else if (empLocation != computer.Location) empLocation = "N/A";
                }

                if (employee.FirstName == "BOS" && employee.LastName == "BOS")
                {
                    int remoteOrdered = 2;
                comploop:
                    foreach (Computer computer in employee.Computers)
                    {
                        if (remoteOrdered == 2 && !computer.ComputerAlias.Contains("[Remote PC]")) continue;
                        if (remoteOrdered == 1 && !computer.ComputerAlias.Contains("Checkout")) continue;
                        if (remoteOrdered == 0 && (computer.ComputerAlias.Contains("[Remote PC]")
                            || computer.ComputerAlias.Contains("Checkout"))) continue;
                        TreeNode compNode = CreateComputerTreeNode(computer);
                        treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Add(compNode);

                        int computerIndex = treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Count - 1;

                        AddComputerInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes[computerIndex], computer);
                    }
                    if (remoteOrdered > 0)
                    {
                        remoteOrdered--;
                        goto comploop;
                    }
                }
                else
                {
                    foreach (Computer computer in employee.Computers)
                    {
                        TreeNode compNode = CreateComputerTreeNode(computer);
                        treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Add(compNode);

                        int computerIndex = treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes.Count - 1;

                        AddComputerInfoNodes(treeViewComputers.Nodes[treeViewComputers.Nodes.Count - 1].Nodes[computerIndex], computer);
                    }
                }
            }
        }

        public void DisplayComputerTreeOrganizationView(TreeView treeViewComputers)
        {
            // Grab the sections and add them
            foreach (Unit unit in ViewConst.UNITS)
            {
                TreeNode treeNode = null;
                AddUnitNode(unit, treeNode, treeViewComputers);
            }
        }

        public List<TreeNode> GetComputerChildren(TreeNode node)
        {
            List<TreeNode> computerNodes = new List<TreeNode>();

            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Tag != null && (childNode.Tag.Equals(ViewConst.NodeTags.Computer)))
                {
                    computerNodes.Add(childNode);
                }
            }

            return computerNodes;
        }

        public void GetUser(Computer computer)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = Environment.CurrentDirectory + @"\query.exe";
            cmd.StartInfo.Arguments = "user /server:" + computer.ComputerName;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            string output = cmd.StandardOutput.ReadToEnd();

            if (output.Contains("USERNAME"))
            {
                string temp = output.Substring(output.IndexOf('\n') + 1).Trim();
                computer.AccUser = temp.Substring(0, temp.IndexOf(' '));
            }
            else 
            {
                computer.AccUser = "Available";
            }
        }

        public string GetUser(string ComputerName)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = Environment.CurrentDirectory + @"\query.exe";
            cmd.StartInfo.Arguments = "user /server:" + ComputerName;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            string output = cmd.StandardOutput.ReadToEnd();

            if (output.Contains("USERNAME"))
            {
                string temp = output.Substring(output.IndexOf('\n') + 1).Trim();
                return temp.Substring(0, temp.IndexOf(' '));
            }
            else
            {
                return "Available";
            }
        }

        public string TrimID(string ComputerName)
        {
            for (int i = 0; i < ComputerName.Length - 2; i++)
            {
                if (ComputerName.ElementAt(i) == 'm' && ComputerName.ElementAt(i + 1) == 'a'
                    && ComputerName.ElementAt(i + 2) == 'd')
                {
                    return ComputerName.Substring(i);
                }
            }
            return ComputerName;
        }
    }
}
