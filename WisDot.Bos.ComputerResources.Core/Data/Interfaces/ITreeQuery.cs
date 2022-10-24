using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WisDot.Bos.ComputerResources.Core.Data.Interfaces
{
    interface ITreeQuery
    {
        void OpenPath(string path);
        void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e);
    }
}
