using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class DistributionNodeService : IDistributionNodeService
    {
        IDistributionNodeRepository repo = new DistributionNodeRepository();

        public int GetCheckedComputersNodes(TreeNodeCollection nodes, List<Machine> selectedMachines)
        {
            return repo.GetCheckedComputersNodes(nodes, selectedMachines);
        }

        public int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute, List<FileSource> selectedFileSources)
        {
            return repo.GetCheckedFileSourcesNodes(nodes, isDistribute, selectedFileSources);
        }
    }
}
