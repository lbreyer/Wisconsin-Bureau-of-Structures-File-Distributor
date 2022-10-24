using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IDistributionNodeService
    {
        int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute, List<FileSource> selectedFileSources);
        int GetCheckedComputersNodes(TreeNodeCollection nodes, List<Machine> selectedMachines);
    }
}
