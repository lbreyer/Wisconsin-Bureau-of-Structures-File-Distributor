using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.ComputerResources.Core.Data.Interfaces;

namespace WisDot.Bos.ComputerResources.Core.Data
{
    class DistributionFileQuery : IDistributionFileQuery
    {
        public List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory, bool overwrite, List<FileInfo> specialFiles)
        {
            List<string> errors = new List<string>();
            Stack<string> sourceDirectories = new Stack<string>();

            sourceDirectories.Push(sourceBaseDirectory);

            while (sourceDirectories.Count > 0)
            {
                string currentSourceDirectory = sourceDirectories.Pop();
                string currentDestinationDirectory = "";

                if (currentSourceDirectory.ToUpper().Equals(sourceBaseDirectory.ToUpper()))
                {
                    currentDestinationDirectory = destinationBaseDirectory;
                }
                else
                {
                    string pathToAdd = currentSourceDirectory.Substring(sourceBaseDirectory.Length + 1);
                    currentDestinationDirectory = Path.Combine(destinationBaseDirectory, pathToAdd);
                }

                // Create the current destination as necessary
                if (!Directory.Exists(currentDestinationDirectory))
                {
                    try
                    {
                        Directory.CreateDirectory(currentDestinationDirectory);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(LogException(ex));
                        continue;
                    }
                }

                // Copy files in the current source directory
                string[] files = null;

                try
                {
                    files = Directory.GetFiles(currentSourceDirectory);
                }
                catch (Exception ex)
                {
                    errors.Add(LogException(ex));
                }

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    bool fileOverwrite = overwrite;

                    if (specialFiles != null)
                    {
                        foreach (FileInfo specialFile in specialFiles)
                        {
                            if (specialFile.Name == fileName)
                            {
                                fileOverwrite = false;
                                break;
                            }
                        }
                    }

                    errors.AddRange(CopyFile(file, Path.Combine(currentDestinationDirectory, fileName), fileOverwrite));
                }

                string[] subSourceDirectories = null;
                try
                {
                    subSourceDirectories = Directory.GetDirectories(currentSourceDirectory);
                }
                catch (Exception ex)
                {
                    errors.Add(LogException(ex));
                }

                foreach (string subSourceDirectory in subSourceDirectories)
                {
                    sourceDirectories.Push(subSourceDirectory);
                }
            } // end while

            return errors;
        }

        public List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite)
        {
            List<string> errors = new List<string>();
            string destinationDirectoryPath = Path.GetDirectoryName(destinationPath);
            FileInfo sourceFileInfo = new FileInfo(sourcePath);

            if (File.Exists(destinationPath))
            {
                if (overwrite)
                {
                    try
                    {
                        FileInfo destFileInfo = new FileInfo(destinationPath);
                        if (destFileInfo.IsReadOnly)
                        {
                            destFileInfo.IsReadOnly = false;
                        }

                        sourceFileInfo.CopyTo(destinationPath, true);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(LogException(ex));
                    }
                }
                else
                {
                    try
                    {
                        FileInfo destFileInfo = new FileInfo(destinationPath);
                        if (sourceFileInfo.LastWriteTime > destFileInfo.LastWriteTime)
                        {
                            if (destFileInfo.IsReadOnly)
                            {
                                destFileInfo.IsReadOnly = false;
                            }

                            sourceFileInfo.CopyTo(destinationPath, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.Add(LogException(ex));
                    }
                }
            }
            else
            {
                try
                {
                    if (!Directory.Exists(destinationDirectoryPath))
                    {
                        Directory.CreateDirectory(destinationDirectoryPath);
                    }

                    sourceFileInfo.CopyTo(destinationPath);
                }
                catch (Exception ex)
                {
                    errors.Add(LogException(ex));
                }
            }

            return errors;
        }

        public List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders, List<FileInfo> specialFiles = null)
        {
            List<string> errors = new List<string>();
            DirectoryInfo directory = new DirectoryInfo(machineFolderPath);

            if (deleteSubFolders && specialFiles.Count == 0)
            {
                try { directory.Delete(true); }
                catch (Exception ex)
                {
                    errors.Add(LogException(ex));
                }
            }
            else
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    bool deleteFile = true;
                    if (specialFiles != null)
                    {
                        foreach (FileInfo specialFile in specialFiles)
                        {
                            if (specialFile.Name == file.Name)
                            {
                                deleteFile = false;
                                break;
                            }
                        }
                    }
                    if (deleteFile)
                    {
                        foreach (string error in DeleteFile(file.FullName))
                        {
                            errors.Add(error);
                        }
                    }
                }
                if (deleteSubFolders)
                {
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                    {
                        foreach (string error in DeleteDir(subDirectory.FullName, deleteSubFolders))
                        {
                            errors.Add(error);
                        }
                    }
                }
            }

            return errors;
        }

        public List<string> DeleteFile(string machineFilePath)
        {
            List<string> errors = new List<string>();
            FileInfo file = new FileInfo(machineFilePath);

            try { file.Delete(); }
            catch (Exception ex)
            {
                errors.Add(LogException(ex));
            }

            return errors;
        }

        public void EditXML(string path)
        {
            try
            {
                Process prc = new Process();
                ProcessStartInfo procInfo = new ProcessStartInfo("notepad.exe")
                {
                    Arguments = path
                };
                prc.StartInfo = procInfo;
                prc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Error opening {0} file. Exception Type: {1} Message: {2}",
                    path, ex.GetType(), ex.Message));
            }
        }

        public string LogException(Exception ex)
        {
            return String.Format(@"Exception type: {0}. Exception message: {1}",
                ex.GetType().ToString(), ex.Message);
        }

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
    }
}
