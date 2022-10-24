using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.ComputerResources.Core.Data;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;
using WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services
{
    public class DistributionFileService : IDistributionFileService
    {
        IDistributionFileQuery query = new DistributionFileQuery();

        public List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory, bool overwrite, List<FileInfo> specialFiles)
        {
            return query.CopyDir(sourceBaseDirectory, destinationBaseDirectory, overwrite, specialFiles);
        }

        public List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite)
        {
            return query.CopyFile(sourcePath, destinationPath, overwrite);
        }

        public List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders, List<FileInfo> specialFiles = null)
        {
            return query.DeleteDir(machineFolderPath, deleteSubFolders, specialFiles);
        }

        public List<string> DeleteFile(string machineFilePath)
        {
            return query.DeleteFile(machineFilePath);
        }

        public void EditXML(string path)
        {
            query.EditXML(path);
        }

        public string LogException(Exception ex)
        {
            return query.LogException(ex);
        }

        public void OpenPath(string path)
        {
            query.OpenPath(path);
        }
    }
}
