using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;
using static WisDot.Bos.ComputerResources.Core.Data.Constants;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class DistributionTreeRepository : IDistributionTreeRepository
    {
        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            TreeNode location = new TreeNode()
            {
                Text = String.Format(@"Location : {0}", computer.Location),
                Tag = ViewConst.COMPUTERINFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            computerNode.Nodes.Add(location);

            TreeNode yearNode = new TreeNode()
            {
                Text = String.Format(@"Install Year: {0}", computer.InstallFiscalYear),
                Tag = ViewConst.COMPUTERINFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            computerNode.Nodes.Add(yearNode);

            TreeNode swNode = new TreeNode()
            {
                Text = String.Format(@"Special S/W: {0}", computer.SpecialSoftware),
                Tag = ViewConst.COMPUTERINFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            computerNode.Nodes.Add(swNode);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            TreeNode phoneNode = new TreeNode()
            {
                Text = String.Format(@"Phone #: {0}", employee.PhoneNumber),
                Tag = ViewConst.EMPLOYEEINFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            employeeNode.Nodes.Add(phoneNode);

            TreeNode logonNode = new TreeNode()
            {
                Text = String.Format("Logon ID: {0}", employee.LogonID),
                Tag = ViewConst.EMPLOYEEINFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            employeeNode.Nodes.Add(logonNode);

            if (employee.IsLeader)
            {
                TreeNode leaderNode = new TreeNode()
                {
                    Text = "Leader",
                    Tag = ViewConst.EMPLOYEEINFONODETAG,
                    ImageIndex = 6
                };
                employeeNode.Nodes.Add(leaderNode);
            }
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            TreeNode compNode = new TreeNode()
            {
                Text = computer.ComputerName,
                Name = computer.ComputerName
            };
            if (computer.ComputerType == ComputerType.Laptop)
            {
                compNode.ImageIndex = 2;
                compNode.SelectedImageIndex = 2;
                compNode.Tag = ViewConst.LAPTOPNODETAG;
            }
            else
            {
                compNode.ImageIndex = 3;
                compNode.SelectedImageIndex = 3;
                compNode.Tag = ViewConst.DESKTOPNODETAG;
            }

            return compNode;
        }

        public TreeNode CreateDestinationPathTreeNode(string destinationPath)
        {
            TreeNode destinationPathNode = new TreeNode()
            {
                Text = "destination: " + destinationPath,
                Name = destinationPath,
                Tag = ViewConst.INFONODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            return destinationPathNode;
        }

        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            TreeNode empNode = new TreeNode()
            {
                Text = employee.LastName + ", " + employee.FirstName,
                Name = employee.EmployeeID.ToString(),
                Tag = ViewConst.EMPLOYEENODETAG
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

        public TreeNode CreateFolderTreeNode(DistributionFolder folder)
        {
            // Folder Node
            TreeNode folderNode = new TreeNode()
            {
                Name = folder.SourcePath,
                ToolTipText = folder.DestinationPath
            };
            if (folder.IsEntireFolderDistributed)
            {
                folderNode.Text = folder.Name;
                folderNode.Tag = ViewConst.FOLDERNODETAG;
                folderNode.ImageIndex = 0;
                folderNode.SelectedImageIndex = 0;
                folderNode.Nodes.Add(CreateOverwriteTreeNode(true));
            }
            else
            {
                folderNode.Text = folder.Name + "*";
                folderNode.Tag = ViewConst.FOLDERNODENOENTIREDISTRIBUTIONTAG;
                folderNode.ForeColor = Color.Red;
                folderNode.ImageIndex = 8;
                folderNode.SelectedImageIndex = 8;
            }

            // Source Path Node
            TreeNode sourcePathNode = new TreeNode()
            {
                Text = "source: " + folder.SourcePath,
                Name = folder.SourcePath,
                Tag = ViewConst.PATHNODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            folderNode.Nodes.Add(sourcePathNode);

            // Destination Path Node
            folderNode.Nodes.Add(CreateDestinationPathTreeNode(folder.DestinationPath));

            // TFS Source Node
            if (folder.TFSsource.Length > 0)
                folderNode.Nodes.Add(CreateSourceTreeNode(folder.TFSsource));

            // Last Modified Node
            if (folder.IsEntireFolderDistributed)
            {
                try
                {
                    DirectoryInfo sourcePath = new DirectoryInfo(folder.SourcePath);
                    FileInfo mostRecentFile = sourcePath.GetFiles("*", SearchOption.AllDirectories)
                                                .OrderByDescending(f => f.LastWriteTime).First();
                    DateTime modified = File.GetLastWriteTime(mostRecentFile.FullName);
                    folderNode.Nodes.Add(CreateModifiedTreeNode(modified));
                }
                catch { }
            }

            // Notes Node
            if (folder.Note.Length > 0)
                folderNode.Nodes.Add(CreateNoteTreeNode(folder.Note));

            // File Nodes
            foreach (var file in folder.DistributionFiles)
            {
                string path = folder.SourcePath + @"\" + file.FileName;
                TreeNode fileNode = new TreeNode()
                {
                    Name = path,
                    ToolTipText = folder.DestinationPath,
                    Text = file.FileName,
                    Tag = ViewConst.FILENODETAG,
                    ImageIndex = 7,
                    SelectedImageIndex = 7
                };
                fileNode.Nodes.Add(CreateOverwriteTreeNode(false));
                if (file.Source.Length > 0)
                    fileNode.Nodes.Add(CreateSourceTreeNode(file.Source));
                DateTime modified = File.GetLastWriteTime(path);
                fileNode.Nodes.Add(CreateModifiedTreeNode(modified));
                if (file.Note.Length > 0)
                    fileNode.Nodes.Add(CreateNoteTreeNode(file.Note));
                folderNode.Nodes.Add(fileNode);
            }

            return folderNode;
        }

        public TreeNode CreateModifiedTreeNode(DateTime date)
        {
            TreeNode noteNode = new TreeNode()
            {
                Text = "modified: " + date.ToString("d"),
                Name = "modified",
                Tag = ViewConst.INFONODETAG,
                ImageIndex = 10,
                SelectedImageIndex = 10
            };
            return noteNode;
        }

        public TreeNode CreateNoteTreeNode(string note)
        {
            TreeNode noteNode = new TreeNode()
            {
                Text = "note: " + note,
                Name = "note",
                Tag = ViewConst.INFONODETAG,
                ImageIndex = 11,
                SelectedImageIndex = 11
            };
            return noteNode;
        }

        public TreeNode CreateOverwriteTreeNode(bool isFolder)
        {
            string text = "Overwrite File / Delete File?";
            if (isFolder)
                text = "Overwrite Files / Delete Subdirectories?";
            TreeNode aNode = new TreeNode()
            {
                Name = "overwrite",
                Tag = ViewConst.OVERWRITENODETAG,
                Text = text,
                ImageIndex = 9,
                SelectedImageIndex = 9
            };
            return aNode;
        }

        public TreeNode CreateSourceTreeNode(string path)
        {
            string name;
            if (Path.GetExtension(path) == string.Empty)
            {
                name = path;
            }
            else
            {
                name = Path.GetDirectoryName(path);
            }
            TreeNode sourceNode = new TreeNode()
            {
                Text = "TFS source: " + path,
                Name = name,
                Tag = ViewConst.PATHNODETAG,
                ImageIndex = 6,
                SelectedImageIndex = 6
            };
            return sourceNode;
        }

        public void DisplayComputerTreeEmployeeView(TreeView treeViewComputers, BackgroundWorker loadingComputers)
        {
            treeViewComputers.Nodes.Clear();
            TreeNode loading = new TreeNode()
            {
                Name = "loading",
                Tag = ViewConst.INFONODETAG,
                Text = "Loading...",
                ImageIndex = 9,
                SelectedImageIndex = 9
            };
            treeViewComputers.Nodes.Add(loading);
            treeViewComputers.Enabled = false;

            loadingComputers.RunWorkerAsync();
        }

        public void DisplayDistributionFolderTree(TreeView treeViewDistributionFolders, BackgroundWorker loadingSources)
        {
            treeViewDistributionFolders.Nodes.Clear();
            TreeNode loading = new TreeNode()
            {
                Name = "loading",
                Tag = ViewConst.INFONODETAG,
                Text = "Loading...",
                ImageIndex = 9,
                SelectedImageIndex = 9
            };
            treeViewDistributionFolders.Nodes.Add(loading);
            treeViewDistributionFolders.Enabled = false;

            loadingSources.RunWorkerAsync();
        }
    }
}
