using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.ComputerResources.Core.Domain.Services.Interfaces
{
    interface IDistributionFileService
    {
        List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite);
        List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory,
            bool overwrite, List<FileInfo> specialFiles);
        List<string> DeleteFile(string machineFilePath);
        List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders,
            List<FileInfo> specialFiles = null);
        string LogException(Exception ex);
        void OpenPath(string path);
        void EditXML(string path);
    }
}
