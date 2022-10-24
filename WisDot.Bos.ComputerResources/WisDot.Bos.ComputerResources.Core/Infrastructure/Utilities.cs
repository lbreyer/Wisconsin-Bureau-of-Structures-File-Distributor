using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // for File, Directory
using System.Diagnostics; // for invoking a process

namespace WisDot.Bos.ComputerResources.Core.Infrastructure
{
    public class Utilities
    {
        public static void OpenUrl(string url)
        {
            Process.Start("IExplore.exe", url);
        }

        public static void OpenExecutable(string executablePath)
        {
            Process.Start(executablePath);
        }

        public static void OpenPath(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else if (File.Exists(path))
            {
                Process resource = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = path,
                        WorkingDirectory = Path.GetDirectoryName(path)
                    }
                };

                resource.Start();
            }
        }

        /// <summary>
        /// Returns true if the given file path is a folder.
        /// </summary>
        /// <param name="Path">File path</param>
        /// <returns>True if a folder</returns>
        public static bool IsFolder(string path)
        {
            return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
        }
    }
}
