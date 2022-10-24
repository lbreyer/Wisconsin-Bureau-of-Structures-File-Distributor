using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO; // for File, Directory
using System.Diagnostics; // for invoking a process
using System.Threading;
using System.Net.NetworkInformation;

using static WisDot.Bos.ComputerResources.Core.Data.Constants;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Infrastructure;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using WisDot.Bos.ComputerResources.Core.Data;
using System.Configuration;

namespace WisDot.Bos.ComputerResources.FileDistributor
{
    public partial class DistributionView : Form, IDistributionView
    {
        private List<FileSource> selectedFileSources = new List<FileSource>();
        private List<Machine> selectedMachines = new List<Machine>();

        #region Services
        private static DistributionFolderService distServ = new DistributionFolderService();
        private static ComputerService compServ = new ComputerService();
        private static EmployeeService empServ = new EmployeeService();
        private static DistributionTreeService treeServ = new DistributionTreeService();
        private static FileSourceService fileServ = new FileSourceService();
        private static MachineService machServ = new MachineService();
        private static DistributionFileService distFileServ = new DistributionFileService();
        private static DistributionNodeService nodeServ = new DistributionNodeService();
        private static DistributionProcessService procServ = new DistributionProcessService();
        #endregion

        private static DistributionController controller = new DistributionController();

        private static string initialDirectory = ConfigurationManager.AppSettings["InitialDirectory"].ToString();
        private static string logFileDirectory = initialDirectory + @"FileDistributionLogFiles\";
        //private const string logFileDirectory = @"C:\Users\DOTLDB\source\repos\";
        private string logFilePath;

        private string workType;
        private bool working;
        private int origHeight;

        public DistributionView()
        {
            InitializeComponent();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            origHeight = Height;
            WorkInProgressToggle(false);
            DisplayDistributionFolderTree();
            DisplayComputerTreeEmployeeView();
            ResetFileSourcePath();
            ResetComputersPath();
            ResetEmployeePath();
        }

        #region Reset Path
        private void ResetFileSourcePath()
        {
            textBoxFileSourcesFilePath.Text = distServ.ReturnFilePath();
        }

        private void ResetComputersPath()
        {
            textBoxComputerFilePath.Text = compServ.ReturnFilePath();
        }

        private void ResetEmployeePath()
        {
            textBoxEmployeeFilePath.Text = empServ.ReturnFilePath();
        }
        #endregion

        #region Tree Handling
        public void DisplayDistributionFolderTree()
        {
            controller.DisplayDistributionFolderTree(this.treeViewDistributionFolders, this.loadingSources);
        }

        public TreeNode CreateOverwriteTreeNode(bool isFolder)
        {
            return controller.CreateOverwriteTreeNode(isFolder);
        }

        public TreeNode CreateDestinationPathTreeNode(string destinationPath)
        {
            return controller.CreateDestinationPathTreeNode(destinationPath);
        }

        public TreeNode CreateModifiedTreeNode(DateTime date)
        {
            return controller.CreateModifiedTreeNode(date);
        }

        public TreeNode CreateSourceTreeNode(string path)
        {
            return controller.CreateSourceTreeNode(path);
        }

        public TreeNode CreateNoteTreeNode(string note)
        {
            return controller.CreateNoteTreeNode(note);
        }

        public TreeNode CreateFolderTreeNode(DistributionFolder folder)
        {
            return controller.CreateFolderTreeNode(folder);
        }

        public void DisplayComputerTreeEmployeeView()
        {
            controller.DisplayComputerTreeEmployeeView(this.treeViewComputers, this.loadingComputers);
        }

        public TreeNode CreateEmployeeTreeNode(Employee employee)
        {
            return controller.CreateEmployeeTreeNode(employee);
        }

        public void AddEmployeeInfoNodes(TreeNode employeeNode, Employee employee)
        {
            controller.AddEmployeeInfoNodes(employeeNode, employee);
        }

        public TreeNode CreateComputerTreeNode(Computer computer)
        {
            return controller.CreateComputerTreeNode(computer);
        }

        public void AddComputerInfoNodes(TreeNode computerNode, Computer computer)
        {
            controller.AddComputerInfoNodes(computerNode, computer);
        }

        public void treeViewDistributionFolders_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Disable if working and the user tried to check the node
            if (e.Action != TreeViewAction.Unknown && working)
            {
                e.Node.Checked = !e.Node.Checked;
            }
            else
            {
                SetCheck(e.Node, e.Node.Checked);
            }
        }

        #endregion

        #region Button Handling
        private void SetCheck(TreeNode node, bool check)
        {
            foreach (TreeNode n in node.Nodes)
            {
                n.Checked = check;

                // Recurse
                if (n.Nodes.Count != 0)
                    SetCheck(n, check);
            }
        }

        private void SetCheckAll(TreeView inTreeView, bool check)
        {
            foreach (TreeNode tNode in inTreeView.Nodes)
            {
                tNode.Checked = check;
            }
        }

        private void treeViewComputers_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Disable if working and the user tried to check the node
            if (e.Action != TreeViewAction.Unknown && working)
                e.Node.Checked = !e.Node.Checked;
            else
                SetCheck(e.Node, e.Node.Checked);
        }

        private void buttonFileSourcesCheckAll_Click(object sender, EventArgs e)
        {
            SetCheckAll(treeViewDistributionFolders, true);
        }

        private void buttonFileSourcesUncheckAll_Click(object sender, EventArgs e)
        {
            SetCheckAll(treeViewDistributionFolders, false);
        }

        private void buttonComputersCheckAll_Click(object sender, EventArgs e)
        {
            SetCheckAll(treeViewComputers, true);
        }

        private void buttonComputersUncheckAll_Click(object sender, EventArgs e)
        {
            SetCheckAll(treeViewComputers, false);
        }

        private void buttonDistribute_Click(object sender, EventArgs e)
        {
            DoWork(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Continue with the delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
                DoWork(false);
        }
        #endregion

        #region File Handling
        /// <summary>
        /// Starts a new thread to attempt to connect. Aborts thread after timeout
        /// </summary>
        /// <returns>Was connection made before timeout</returns>
        public bool TestNetwork(string path)
        {
            return controller.TestNetwork(path);
        }

        /// <summary>
        /// Copies source file to destination
        /// </summary>
        /// <returns>List of errors</returns>
        public List<string> CopyFile(string sourcePath, string destinationPath, bool overwrite)
        {
            return controller.CopyFile(sourcePath, destinationPath, overwrite);
        }

        /// <summary>
        /// Copies source directiory to destination
        /// </summary>
        /// <returns>List of errors</returns>
        public List<string> CopyDir(string sourceBaseDirectory, string destinationBaseDirectory, 
            bool overwrite, List<FileInfo> specialFiles)
        {
            return controller.CopyDir(sourceBaseDirectory, destinationBaseDirectory, overwrite, specialFiles);
        }

        public List<string> DeleteFile (string machineFilePath)
        {
            return controller.DeleteFile(machineFilePath);
        }

        public List<string> DeleteDir(string machineFolderPath, bool deleteSubFolders, 
            List<FileInfo> specialFiles = null)
        {
            return controller.DeleteDir(machineFolderPath, deleteSubFolders, specialFiles);
        }
        #endregion

        #region Node Handling
        public string LogException(Exception ex)
        {
            return controller.LogException(ex);
        }

        public int GetCheckedFileSourcesNodes(TreeNodeCollection nodes, bool isDistribute)
        {
            return controller.GetCheckedFileSourcesNodes(nodes, isDistribute, selectedFileSources);
        }

        public int GetCheckedComputersNodes(TreeNodeCollection nodes)
        {
            return controller.GetCheckedComputersNodes(nodes, selectedMachines);
        }
        #endregion

        #region Click Events
        private void treeViewDistributionFolders_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void treeViewDistributionFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.Equals(ViewConst.PATHNODETAG))
            {
                Utilities.OpenPath(e.Node.Name);
            }
            else if (e.Node.Tag.Equals(ViewConst.FOLDERNODETAG) || e.Node.Tag.Equals(ViewConst.FOLDERNODENOENTIREDISTRIBUTIONTAG))
            {
                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    if (childNode.Tag.Equals(ViewConst.PATHNODETAG))
                    {
                        Utilities.OpenPath(childNode.Name);
                        break;

                    }
                }
            }
        }

        private void treeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = "";

            if (e.Node.Tag.Equals(ViewConst.DESKTOPNODETAG) || e.Node.Tag.Equals(ViewConst.LAPTOPNODETAG))
            {
                path = String.Format(@"\\{0}\c-root", e.Node.Name);

                PingReply pingReply = pingMachine(e.Node.Name);

                if (pingReply != null && pingReply.Status == IPStatus.Success)
                {
                    OpenPath(path);
                }
                else
                {
                    MessageBox.Show(String.Format(@"{0} is not available.", e.Node.Name));
                }
                
            }
            else if (e.Node.Tag.Equals(ViewConst.EMPLOYEENODETAG))
            {
                int employeeComputerCount = 0;
                TreeNode employeeComputerNode = new TreeNode();

                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    if (childNode.Tag.Equals(ViewConst.DESKTOPNODETAG) || childNode.Tag.Equals(ViewConst.LAPTOPNODETAG))
                    {
                        employeeComputerCount++;
                        employeeComputerNode = childNode;
                    }
                }

                if (employeeComputerCount == 1)
                {
                    path = String.Format(@"\\{0}\c-root", employeeComputerNode.Name);
                    PingReply pingReply = pingMachine(employeeComputerNode.Name);

                    if (pingReply != null && pingReply.Status == IPStatus.Success)
                    {
                        OpenPath(path);
                    }
                    else
                    {
                        MessageBox.Show(String.Format(@"{0} is not available.", employeeComputerNode.Name));
                    }
                }
            }
        }

        public void OpenPath(string path)
        {
            controller.OpenPath(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\dir1\dir2\dir3");
        }

        private void treeViewComputers_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

        }

        public PingReply pingMachine(string machineName)
        {
            return controller.pingMachine(machineName);
        }

        private void treeViewDistributionFolders_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

        }

        private void treeViewDistributionFolders_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void buttonOpenFileSourcesXmlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog()
            {
                InitialDirectory = Path.GetDirectoryName(textBoxFileSourcesFilePath.Text),
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                textBoxFileSourcesFilePath.Text = openFD.FileName;
                new DistributionFolderService().ResetDistributionSourceXml(openFD.FileName);
                DisplayDistributionFolderTree();
            }
        }

        private void linkBOSBackupFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenPath(logFileDirectory);
        }

        private void buttonEditFileSourcesXmlFile_Click(object sender, EventArgs e)
        {
            EditXML(textBoxFileSourcesFilePath.Text);
        }

        public void EditXML(string path)
        {
            controller.EditXML(path);
        }

        private void buttonReloadFileSourcesXmlFile_Click(object sender, EventArgs e)
        {
            new DistributionFolderService().ResetDistributionSourceXml(textBoxFileSourcesFilePath.Text);
            DisplayDistributionFolderTree();
        }
        #endregion

        #region Work Events
        private void DoWork(bool isDistribution)
        {
            selectedFileSources.Clear();
            selectedMachines.Clear();

            int checkedFileSourcesCount = 
                GetCheckedFileSourcesNodes(treeViewDistributionFolders.Nodes, isDistribution);
            if (checkedFileSourcesCount == 0)
            {
                MessageBox.Show("Select at least 1 file.");
                return;
            }

            int checkedComputersCount = GetCheckedComputersNodes(treeViewComputers.Nodes);
            if (checkedComputersCount == 0)
            {
                MessageBox.Show("Select at least 1 computer.");
                return;
            }

            WorkInProgressToggle(true);
            backgroundWorker1.RunWorkerAsync(isDistribution);
        }

        private void WorkInProgressToggle(bool working)
        {
            this.working = working;
            if (working)
                Height = origHeight;
            else
                Height = Convert.ToInt32(origHeight*0.85);

            buttonLoadComputerFile.Enabled = !working;
            buttonEditFileSourcesXmlFile.Enabled = !working;
            buttonReloadFileSourcesXmlFile.Enabled = !working;
            buttonFileSourcesCheckAll.Enabled = !working;
            buttonFileSourcesUncheckAll.Enabled = !working;

            buttonDistribute.Enabled = !working;
            buttonDelete.Enabled = !working;
            buttonCancel.Enabled = working;
           
            buttonLoadComputerFile.Enabled = !working;
            buttonComputersUncheckAll.Enabled = !working;
            
        }
        #endregion

        #region Process Methods
        /// <summary>
        /// Attempts to connect to each computer in selectedMachines
        /// </summary>
        /// <returns>true for each computer connected, false for no connection</returns>
        public List<bool> ConnectionCheck()
        {
            return controller.ConnectionCheck(selectedMachines, backgroundWorker1);
        }

        /// <summary>
        /// Reports file progress to background worker.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="distribution"></param>
        /// <param name="isFileSourceAFolder"></param>
        /// <param name="currentFile"></param>
        /// <param name="totalFiles"></param>
        public void FileProgress(FileSource fileSource, bool distribution, bool isFileSourceAFolder,
            double currentFile)
        {
            controller.FileProgress(fileSource, distribution, isFileSourceAFolder, currentFile, selectedFileSources, backgroundWorker1);
        }

        /// <summary>
        /// Reports machine progress to background worker
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="currentMachine"></param>
        public void MachineProgress(Machine machine, double currentMachine)
        {
            controller.MachineProgress(machine, currentMachine, selectedMachines, backgroundWorker1);
        }

        /// <summary>
        /// Handles writing to logWriter
        /// </summary>
        /// <param name="cancel"></param>
        private void LogResults(StreamWriter logWriter, bool cancel, DateTime dateTimeStart)
        {
            int desktopCount = selectedMachines.Where(m => !m.IsLapTop).Count();
            int laptopCount = selectedMachines.Where(m => m.IsLapTop).Count();

            logWriter.WriteLine("{0} starting on {1:MM-dd-yyyy HH:mm:ss:FFFF}", workType, dateTimeStart);
            logWriter.WriteLine("\tTotal # selected machines: {0} \t# desktops: {1} \t# laptops: {2}",
                selectedMachines.Count(), desktopCount, laptopCount);
            logWriter.WriteLine();

            int fileSourceCounter = 0;
            foreach (FileSource fileSource in selectedFileSources)
            {
                fileSourceCounter++;
                logWriter.WriteLine("{0}. {1}", fileSourceCounter, fileSource.Name);
                logWriter.WriteLine("\tSource Path: {0} \tDestination Path: {1}",
                    fileSource.SourcePath, fileSource.DestinationPath);
                logWriter.WriteLine("\tOverwrite? {0}", fileSource.IsOverwritten);

                int failMachinesCount = fileSource.FailMachines.Count();
                int successMachinesCount = fileSource.SuccessMachines.Count();
                int partialSuccessMachinesCount = fileSource.PartialSuccessMachines.Count();

                logWriter.WriteLine(
                    "\tResults: \t# Failed: {0} \t# Partial Success: {1} \t# Full Success: {2} ",
                    failMachinesCount, partialSuccessMachinesCount, successMachinesCount);
                logWriter.WriteLine();

                // Failed:
                int failMachinesCounter = 0;
                logWriter.WriteLine("\tFailed: {0}", failMachinesCount);
                foreach (Machine machine in fileSource.FailMachines)
                {
                    failMachinesCounter++;
                    logWriter.WriteLine("\t{0}. Machine: {1} \tOwner: {2} \t{3}",
                        failMachinesCounter, machine.MachineName, machine.OwnerName,
                        (machine.IsLapTop ? "LAPTOP" : ""));
                    logWriter.WriteLine("\t\tErrors:");

                    int machineErrorCounter = 0;
                    foreach (string error in machine.DistributeErrors)
                    {
                        machineErrorCounter++;
                        logWriter.WriteLine("\t\t{0}. {1}", machineErrorCounter, error);
                    }

                    logWriter.WriteLine();
                }

                if (failMachinesCount == 0)
                    logWriter.WriteLine();

                // Partial Success:
                int partialSuccessMachinesCounter = 0;
                logWriter.WriteLine("\tPartial Success: {0}", partialSuccessMachinesCount);
                foreach (Machine machine in fileSource.PartialSuccessMachines)
                {
                    partialSuccessMachinesCounter++;
                    logWriter.WriteLine("\t{0}. Machine: {1} \tOwner: {2} \t{3}",
                        partialSuccessMachinesCounter, machine.MachineName, machine.OwnerName,
                        (machine.IsLapTop ? "LAPTOP" : ""));
                    logWriter.WriteLine("\t\tErrors:");

                    int machineErrorCounter = 0;
                    foreach (string error in machine.DistributeErrors)
                    {
                        machineErrorCounter++;
                        logWriter.WriteLine("\t\t{0}. {1}", machineErrorCounter, error);
                    }

                    logWriter.WriteLine();
                }

                if (partialSuccessMachinesCount == 0)
                    logWriter.WriteLine();

                // Full Success:
                int successMachinesCounter = 0;
                logWriter.WriteLine("\tSuccess: {0}", successMachinesCount);
                foreach (Machine machine in fileSource.SuccessMachines)
                {
                    successMachinesCounter++;
                    logWriter.WriteLine("\t{0}. Machine: {1} \tOwner: {2} \t{3}",
                        successMachinesCounter, machine.MachineName, machine.OwnerName,
                        (machine.IsLapTop ? "LAPTOP" : ""));
                }

                logWriter.WriteLine();
            }

            if (cancel)
            {
                logWriter.WriteLine();
                logWriter.WriteLine("The " + workType + " was cancelled.");
            }
            logWriter.WriteLine();
            DateTime dateTimeEnd = DateTime.Now;
            logWriter.WriteLine("{0} ending on {1:MM-dd-yyyy HH:mm:ss:FFFF}", workType, dateTimeEnd);
            logWriter.Close();
        }
        
        /// <summary>
        /// e.Argument takes true/false. True for distribution, false for deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            DateTime dateTimeStart = DateTime.Now;
            logFilePath = Path.Combine(logFileDirectory,
                String.Format(@"log_{0:MM}-{1:dd}-{2:yyyy}-{3:HH}h{4:mm}m{5:ss}s.txt",
                dateTimeStart, dateTimeStart, dateTimeStart, dateTimeStart, dateTimeStart, dateTimeStart));

            bool isDistribution;
            if ((bool)e.Argument)
            {
                workType = "Distribution";
                isDistribution = true;
            }
            else
            {
                workType = "Deletion";
                isDistribution = false;
            }

            StreamWriter logWriter;
            try
            {
               logWriter = new StreamWriter(logFilePath, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(
                    @"{0} will be aborted. Exception type: {1}. Exception message: {2}",
                    workType, ex.GetType().ToString(), ex.Message));
                return;
            }

            // Check each computer to see if it's connected
            List<bool> isComputerConnected = ConnectionCheck();
            
            int fileSourceCounter = 0;
            foreach (FileSource fileSource in selectedFileSources)
            {
                // Check for cancel
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    goto LogResults;
                }

                // File or folder
                bool isFileSourceAFolder = fileSource.IsFolder;
                if (isDistribution)
                {
                    bool exists;
                    if (isFileSourceAFolder)
                        exists = Directory.Exists(fileSource.SourcePath);
                    else
                        exists = File.Exists(fileSource.SourcePath);

                    if (!exists)
                    {
                        // Log error and continue;
                        fileServ.AddDistributeError(
                            String.Format("File source does not exist- {0}", fileSource.SourcePath), selectedFileSources[fileSourceCounter]);
                        fileSourceCounter++;
                        continue;
                    }
                }

                // Report progress to progress bars
                FileProgress(fileSource, (bool)e.Argument, isFileSourceAFolder, fileSourceCounter);
                
                int machineCounter = 0;
                foreach (Machine machine in selectedMachines)
                {
                    string machineDestinationPath = "";
                    List<string> errors = new List<string>();
                    Machine newMachine =
                        new Machine(machine.OwnerName, machine.MachineName, machine.IsLapTop);
                    var machineCroot = String.Format(@"\\{0}\c-root\", machine.MachineName);

                    // Check for cancel, log and continue.
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        machServ.AddDistributeError(workType + " cancelled.", newMachine);
                        fileServ.AddMachine(
                            newMachine, DistributeResult.Failure, selectedFileSources[fileSourceCounter]);
                        continue;
                    }

                    // Report progress to progress bars
                    MachineProgress(machine, machineCounter);

                    // Check if the machine is connected
                    bool connected = false;
                    if (isComputerConnected[machineCounter])
                    {
                        // Double check connection first
                        if (TestNetwork(machineCroot))
                            connected = true;
                        else
                            isComputerConnected[machineCounter] = false;
                    }
                    machineCounter++;

                    // Log errors if machine not connected and go to next machine
                    if (!connected)
                    {
                        machServ.AddDistributeError(@"Cannot find machine's c-root.", newMachine);
                        fileServ.AddMachine(
                            newMachine, DistributeResult.Failure, selectedFileSources[fileSourceCounter]);
                        continue;
                    }

                    if (isFileSourceAFolder)
                    {
                        machineDestinationPath = String.Format(@"\\{0}\c-root\{1}",
                            machine.MachineName, fileSource.DestinationPath);
                        if (isDistribution)
                            errors = CopyDir(fileSource.SourcePath, machineDestinationPath,
                                fileSource.IsOverwritten, fileSource.SpecialFiles);
                        else
                            DeleteDir(machineDestinationPath, fileSource.IsOverwritten, 
                                fileSource.SpecialFiles);
                    }
                    else // file source is a file
                    {
                        string fileName = Path.GetFileName(fileSource.SourcePath);
                        machineDestinationPath = String.Format(@"\\{0}\c-root\{1}",
                            machine.MachineName, Path.Combine(fileSource.DestinationPath, fileName));
                        if (isDistribution)
                            errors = CopyFile(fileSource.SourcePath, machineDestinationPath,
                                fileSource.IsOverwritten);
                        else
                            errors = DeleteFile(machineDestinationPath);
                    }
                    
                    if (errors.Count > 0)
                    {
                        foreach (string error in errors)
                        {
                            machServ.AddDistributeError(error, newMachine);
                        }

                        if (isFileSourceAFolder)
                            fileServ.AddMachine(
                                newMachine, DistributeResult.PartialSuccess, selectedFileSources[fileSourceCounter]);
                        else
                            fileServ.AddMachine(
                                newMachine, DistributeResult.Failure, selectedFileSources[fileSourceCounter]);
                    }
                    else
                        fileServ.AddMachine(
                            newMachine, DistributeResult.Success, selectedFileSources[fileSourceCounter]);

                } // end inner foreach

                fileSourceCounter++;
            } // end outer foreach

            LogResults:
            LogResults(logWriter, e.Cancel, dateTimeStart);
        }

        /// <summary>
        /// e.UserState takes an array with 3 arguments:
        /// 0: "file" or "comp" for upper progress bar or lower
        /// 1: String for first label
        /// 2: String for second label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar progBar;
            Label processType;
            Label processName;
            string[] args = e.UserState as string[];
            if (args[0] == "file")
            {
                progBar = progressBarFile;
                processType = labelProgressFile;
                processName = labelProgressFilePath;
            }
            else
            {
                progBar = progressBarComputers;
                processType = labelProgressComputer;
                processName = labelProgressComputerName;
            }
            
            progBar.Value = e.ProgressPercentage;
            processType.Text = args[1];
            processName.Text = args[2];
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkInProgressToggle(false);
            MessageBox.Show(workType + " has completed.");
            OpenPath(logFilePath);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            buttonCancel.Enabled = false;
        }

        private void loadingSources_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DistributionFolder> folders = distServ.GetFolders(true);
            List<TreeNode> folderNodes = new List<TreeNode>();

            foreach (var folder in folders)
            {
                folderNodes.Add(CreateFolderTreeNode(folder));
            }

            e.Result = folderNodes;
        }

        private void loadingComputers_DoWork(object sender, DoWorkEventArgs e)
        {
            // Grab the employees and add them
            List<Employee> employees = empServ.GetEmployees();
            List<TreeNode> employeeNodes = new List<TreeNode>();

            foreach (Employee employee in employees)
            {
                TreeNode employeeNode = CreateEmployeeTreeNode(employee);
                AddEmployeeInfoNodes(employeeNode, employee);

                foreach (Computer computer in employee.Computers)
                {
                    if (computer.IsOnDistribution)
                    {
                        TreeNode compNode = CreateComputerTreeNode(computer);
                        AddComputerInfoNodes(compNode, computer);
                        employeeNode.Nodes.Add(compNode);
                    }
                }
                employeeNodes.Add(employeeNode);
            }

            e.Result = employeeNodes;
        }

        private void loadingSources_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeViewDistributionFolders.Nodes.Clear();

            List<TreeNode> folderNodes = (List<TreeNode>)e.Result;

            foreach(TreeNode folderNode in folderNodes)
            {
                treeViewDistributionFolders.Nodes.Add(folderNode);
            }
            treeViewDistributionFolders.Enabled = true;
        }

        private void loadingComputers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeViewComputers.Nodes.Clear();

            List<TreeNode> employeeNodes = (List<TreeNode>)e.Result;

            foreach (TreeNode employeeNode in employeeNodes)
            {
                treeViewComputers.Nodes.Add(employeeNode);
            }
            treeViewComputers.Enabled = true;
        }
        #endregion

        #region Other Click Events
        private void buttonLoadComputerFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog()
            {
                InitialDirectory = Path.GetDirectoryName(textBoxComputerFilePath.Text),
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                textBoxComputerFilePath.Text = openFD.FileName;
                compServ.ResetComputerXml(openFD.FileName);
                DisplayComputerTreeEmployeeView();
            }
        }

        private void buttonEditComputersXmlFile_Click(object sender, EventArgs e)
        {
            EditXML(textBoxComputerFilePath.Text);
        }

        private void buttonReloadComputersXmlFile_Click(object sender, EventArgs e)
        {
            compServ.ResetComputerXml(textBoxComputerFilePath.Text);
            DisplayComputerTreeEmployeeView();
        }

        private void buttonLoadEmployeeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog()
            {
                InitialDirectory = Path.GetDirectoryName(textBoxEmployeeFilePath.Text),
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                textBoxEmployeeFilePath.Text = openFD.FileName;
                empServ.ResetEmployeeXml(openFD.FileName);
                DisplayComputerTreeEmployeeView();
            }
        }

        private void buttonEditEmployeeXmlFile_Click(object sender, EventArgs e)
        {
            EditXML(textBoxEmployeeFilePath.Text);
        }

        private void buttonReloadEmployeeXmlFile_Click(object sender, EventArgs e)
        {
            empServ.ResetEmployeeXml(textBoxEmployeeFilePath.Text);
            DisplayComputerTreeEmployeeView();
        }
        #endregion
    }
}
