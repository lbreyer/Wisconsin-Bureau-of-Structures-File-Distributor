using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    class DistributionNodeRepository : IDistributionNodeRepository
    {
        public int GetCheckedComputersNodes(TreeNodeCollection nodes, List<Machine> selectedMachines)
        {
            int checkedNodesCount = 0;

            foreach (TreeNode currentNode in nodes)
            {
                if (currentNode.Checked && (currentNode.Tag.Equals(ViewConst.LAPTOPNODETAG) || currentNode.Tag.Equals(ViewConst.DESKTOPNODETAG)))
                {
                    checkedNodesCount++;

                    bool isLapTop = currentNode.Tag.Equals(ViewConst.LAPTOPNODETAG) ? true : false;
                    Machine aMachine = new Machine(currentNode.Parent.Text, currentNode.Name, isLapTop);
                    selectedMachines.Add(aMachine);
                }

                checkedNodesCount += GetCheckedComputersNodes(currentNode.Nodes, selectedMachines);
            }

            return checkedNodesCount;
        }

        public int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute, List<FileSource> selectedFileSources)
        {
            int checkedNodesCount = 0;

            foreach (TreeNode currentNode in nodes)
            {
                // Add child nodes
                checkedNodesCount += GetCheckedFileSourcesNodes(currentNode.Nodes, isDistribute, selectedFileSources);

                // Check if folder or file
                bool isFolder = currentNode.Tag.Equals(ViewConst.FOLDERNODETAG);
                bool isFile = currentNode.Tag.Equals(ViewConst.FILENODETAG);

                // Skip nodes if they are unchecked or if they are not files or folders
                if (!currentNode.Checked || (!isFolder && !isFile))
                    continue;

                // The "overwrite" node is always the first child of the current node
                bool overwrite = false;
                if (currentNode.Nodes["overwrite"].Checked)
                    overwrite = true;

                // Skip files if their parent is a folder and is checked
                // Do not skip if file has overwrite checked but parent does not (isDistribute only)
                if (currentNode.Parent != null)
                {
                    if (currentNode.Parent.Tag.Equals(ViewConst.FOLDERNODETAG) && currentNode.Parent.Checked)
                    {
                        bool parentOverwrite = currentNode.Parent.Nodes["overwrite"].Checked;
                        if (!parentOverwrite && overwrite && isDistribute) { }
                        else { continue; }
                    }
                }

                checkedNodesCount++;

                string sourcePath = currentNode.Name;
                string destinationPath = currentNode.ToolTipText;
                List<FileInfo> childFiles = new List<FileInfo>();
                // Save a list of child files that need to be processed differently from parent.
                if (isFolder)
                {
                    foreach (TreeNode childNode in currentNode.Nodes)
                    {
                        if (!childNode.Tag.Equals(ViewConst.FILENODETAG))
                            continue;
                        bool childOverwrite = childNode.Nodes["overwrite"].Checked;
                        if ((overwrite && !childOverwrite) ||
                            (!overwrite && !childOverwrite && !isDistribute))
                        {
                            childFiles.Add(new FileInfo(childNode.Name));
                        }
                    }
                }

                FileSource aFileSource = new FileSource(
                    currentNode.Text, sourcePath, destinationPath, overwrite, isFolder, childFiles);

                selectedFileSources.Add(aFileSource);
            }

            return checkedNodesCount;
        }
    }
}
