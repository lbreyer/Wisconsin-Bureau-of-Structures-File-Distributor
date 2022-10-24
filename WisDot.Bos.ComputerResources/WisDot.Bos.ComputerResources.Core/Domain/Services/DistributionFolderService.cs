using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class DistributionFolderService : IDistributionFolderService
    {
        private static IDistributionFolderQuery query = new DistributionFolderQuery();
        private static IDistributionFolderRepository repo = new DistributionFolderRepository();

        public DistributionFolder CreateDistributionFolder(XElement folder)
        {
            return repo.CreateDistributionFolder(folder);
        }

        public List<DistributionFolder> GetFolders(bool activeFoldersOnly)
        {
            IEnumerable<XElement> selectedFolders = SelectFolders(activeFoldersOnly);
            return repo.GetFolders(selectedFolders);
        }

        public string GetNote(XElement elem)
        {
            return repo.GetNote(elem);
        }

        public string GetSource(XElement elem)
        {
            return repo.GetSource(elem);
        }

        public void ResetDistributionSourceXml(string filePath)
        {
            query.ResetDistributionSourceXml(filePath);
        }

        public IEnumerable<XElement> SelectFolders(bool activeFoldersOnly)
        {
            return query.SelectFolders(activeFoldersOnly);
        }

        public string ReturnFilePath()
        {
            return query.ReturnFilePath();
        }
    }
}
