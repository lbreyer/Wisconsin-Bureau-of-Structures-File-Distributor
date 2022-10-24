using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Domain.Services;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class TreeQuery : ITreeQuery
    {
        public void OpenPath(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    try
                    {
                        Process.Start("explorer.exe", path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Error opening directory path: {0} {1}", path, ex.Message));
                    }
                }
                else if (File.Exists(path))
                {
                    try
                    {
                        Process.Start(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Error opening file path: {0} {1}", path, ex.Message));
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("Path does not exist: {0}", path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error opening path: {0} {1}", path, ex.Message));
            }
        }

        public void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is null) return;
            string path = "";

            if (e.Node.Tag.Equals(ViewConst.NodeTags.Computer))
            {
                path = String.Format(@"\\{0}\c-root", e.Node.Name);
                OpenPath(path);
            }
            else if (e.Node.Tag.Equals(ViewConst.NodeTags.Employee))
            {
                List<TreeNode> computerNodes = new List<TreeNode>();
                computerNodes = new TreeService().GetComputerChildren(e.Node);

                if (computerNodes.Count == 1)
                {
                    path = String.Format(@"\\{0}\c-root", computerNodes[0].Name);
                    OpenPath(path);
                }
            }
        }
    }
}
