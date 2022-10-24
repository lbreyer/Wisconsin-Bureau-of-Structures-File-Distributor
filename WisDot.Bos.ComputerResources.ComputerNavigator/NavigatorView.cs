using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

using System.IO; // for File, Directory
using System.Diagnostics; // for invoking a process
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using WisDot.Bos.ComputerResources.Core.Domain.Models;
using WisDot.Bos.ComputerResources.Core.Domain.Services;
using WisDot.Bos.ComputerResources.Core.Data;
using System.Configuration;

namespace WisDot.Bos.ComputerResources.ComputerNavigator
{
    public partial class NavigatorView : Form, INavigatorView
    {
        private List<Computer> availableLaptops = new List<Computer>();
        private List<Computer> outLaptops = new List<Computer>();
        private List<string[]> checkoutData = new List<string[]>();
        private List<string[]> outLaptopData = new List<string[]>();
        private static string currDirectory = Environment.CurrentDirectory;
        private string outLaptop = "";
        private string RemotePC = "";
        private string IDUser = "";
        private string admins = ConfigurationManager.AppSettings["Administrators"].ToString();
        private bool isAdmin = false;
        private bool isDoubleClick = false;
        private NavigatorController controller;

        public NavigatorView()
        {
            controller = new NavigatorController(this);
            InitializeComponent();
            DisplayComputerTree();
            InitiateCheckout();
        }

        #region General Tab Control
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                UpdateCheckout();
            }
        }
        #endregion

        #region Computer Tree

        #region Tree Control Methods
        public void DisplayComputerTree()
        {
            ClearComputerTree();

            if (radioButtonOrganizationView.Checked)
            {
                DisplayComputerTreeOrganizationView();
            }
            else if (radioButtonEmployeeView.Checked)
            {
                DisplayComputerTreeEmployeeView();
            }
            else if (radioButtonSearch.Checked)
            {
                DisplayComputerTreeSearchView();
            }
        }

        public void ClearComputerTree()
        {
            treeViewComputers.Nodes.Clear();
        }

        public void DisplayComputerTreeEmployeeView()
        {
            controller.DisplayComputerTreeEmployeeView(this.treeViewComputers);
        }

        public void DisplayComputerTreeOrganizationView()
        {
            controller.DisplayComputerTreeOrganizationView(this.treeViewComputers);
        }

        public void DisplayComputerTreeSearchView()
        {
            if (searchBox.Text == null)
            {
                controller.DisplayComputerTreeEmployeeView(this.treeViewComputers);
            }
            else
            {
                controller.DisplayComputerTreeSearchView(this.treeViewComputers, searchBox.Text, comboBoxSearch.Text);
            }
        }

        public void OpenMap(string search = null)
        {
            ViewConst.OpenMap(search);
        }
        #endregion

        #region Computer Tree User Interface Events
        private void RadioButtonOrganizationView_Click(object sender, EventArgs e)
        {
            ViewOrganize();
            DisplayComputerTree();
        }

        private void RadioButtonEmployeeView_Click(object sender, EventArgs e)
        {
            ViewOrganize();
            DisplayComputerTree();
        }

        private void RadioButtonSearchView_Click(object sender, EventArgs e)
        {
            ViewOrganize();
            DisplayComputerTree();
        }

        private void ViewOrganize()
        {
            if (radioButtonEmployeeView.Checked)
            {
                comboBoxSearch.Visible = false;
                searchBox.Visible = false;
                btnMap.Text = "Cube Map";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if (radioButtonOrganizationView.Checked)
            {
                
                comboBoxSearch.Visible = false;
                searchBox.Visible = false;
                btnMap.Text = "Cube Map";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                
            }
            else if (radioButtonSearch.Checked)
            {
                comboBoxSearch.Visible = true;
                searchBox.Visible = true;
                btnMap.Text = "Search";
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void CheckBoxShowEmployeeInfo_CheckedChanged(object sender, EventArgs e)
        {
            DisplayComputerTree();
        }

        private void CheckBoxShowComputerInfo_CheckedChanged(object sender, EventArgs e)
        {
            DisplayComputerTree();
        }

        private void TreeViewComputers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is null) return;
            string path = "";

            if (e.Node.Tag.Equals(ViewConst.NodeTags.Computer))
            {
                path = String.Format(@"\\{0}\c-root", e.Node.Name);
                controller.OpenPath(path);
            }
            else if (e.Node.Tag.Equals(ViewConst.NodeTags.Employee))
            {
                List<TreeNode> computerNodes = new List<TreeNode>();
                computerNodes = new TreeService().GetComputerChildren(e.Node);

                if (computerNodes.Count == 1)
                {
                    path = String.Format(@"\\{0}\c-root", computerNodes[0].Name);
                    controller.OpenPath(path);
                }
            }
        }

        // Returns the computer ID if found or the unchanged string
        private string TrimID(string ComputerName)
        {
            return controller.TrimID(ComputerName);
        }

        private void TreeViewComputers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is null) return;
            if (e.Node.Tag.Equals(ViewConst.NodeTags.RemoteComputer))
            {
                RemotePC = TrimID(e.Node.Text);
                contextMenuStrip1.Enabled = true;
                remoteConnectToolStripMenuItem.Enabled = true;
                checkAvailabilityToolStripMenuItem.Enabled = true;
            }
            else if ((e.Node.Tag.Equals(ViewConst.NodeTags.Computer) || e.Node.Tag.Equals(ViewConst.NodeTags.RemoteComputer))
                && admins.Contains(Environment.UserName.ToLower()))
            {
                RemotePC = TrimID(e.Node.Text);
                contextMenuStrip1.Enabled = true;
                remoteConnectToolStripMenuItem.Enabled = true;
                checkAvailabilityToolStripMenuItem.Enabled = true;
            }
            else if (e.Node.Tag.Equals(ViewConst.NodeTags.Computer) 
                && e.Node.Parent.Nodes[2].Text.Contains(Environment.UserName))
            {
                RemotePC = TrimID(e.Node.Text);
                contextMenuStrip1.Enabled = true;
                remoteConnectToolStripMenuItem.Enabled = true;
                checkAvailabilityToolStripMenuItem.Enabled = true;
            }
            else if (e.Node.Tag.Equals(ViewConst.NodeTags.Computer))
            {
                RemotePC = TrimID(e.Node.Text);
                contextMenuStrip1.Enabled = true;
                remoteConnectToolStripMenuItem.Enabled = false;
                checkAvailabilityToolStripMenuItem.Enabled = true;
            }
            else
            {
                contextMenuStrip1.Enabled = false;
                remoteConnectToolStripMenuItem.Enabled = false;
                checkAvailabilityToolStripMenuItem.Enabled = false;
            }
            if (e.Node.Tag.Equals(ViewConst.NodeTags.Location))
            {
                string cube = e.Node.Text.Replace("Cube #: ", "");
                OpenMap(cube);
            }
            
        }

        private bool IsRemoteComputerAvailable(string ComputerID)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = currDirectory + @"\query.exe";
            cmd.StartInfo.Arguments = "user /server:" + ComputerID;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            string output = cmd.StandardOutput.ReadToEnd();

            if (output.Contains("USERNAME"))
            {
                string temp = output.Substring(output.IndexOf('\n') + 1).Trim();
                IDUser = temp.Substring(0, temp.IndexOf(' '));
                return false;
            }
            else if (output.Length == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Fail");
            }
            return true;
        }

        private void remoteConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsRemoteComputerAvailable(RemotePC))
            {
                RemoteAccess.HomeView hv = new RemoteAccess.HomeView(RemotePC);
                hv.Show();
            }
            else
            {
                MessageBox.Show($"User {IDUser} is already logged in to the remote PC you have selected. Please try another PC.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkAvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string user = controller.GetUser(RemotePC);

            if (user == "Available")
            {
                MessageBox.Show($"No user detected for PC: {RemotePC}.", "Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"User {user} is already logged in to the remote PC you have selected. Please try another PC.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BtnMap_Click(object sender, EventArgs e)
        {
            if (btnMap.Text == "Search")
            {
                if (searchBox.Text != null)
                {
                    DisplayComputerTree();
                }
            }
            else
            {
                OpenMap();
            }
        }

        // Disable double-click to expand/collapse tree. This "feature" sometimes made it 
        // impossible to access computers at the bottom of the list.
        private void TreeViewComputers_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick && e.Action == TreeViewAction.Collapse)
                e.Cancel = true;
        }

        private void TreeViewComputers_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick && e.Action == TreeViewAction.Expand)
                e.Cancel = true;
        }

        private void TreeViewComputers_MouseDown(object sender, MouseEventArgs e)
        {
            isDoubleClick = e.Clicks > 1;
        }
        #endregion
        #endregion

        #region Checkout Laptops
        public void InitiateCheckout()
        {
            isAdmin = CheckAdmin();

            controller.InitiateCheckout(cbNames);
        }

        public void UpdateCheckout()
        {
            ReadCheckoutLog();

            if (outLaptop == "" && availableLaptops.Count > 0)
            {
                // Initiate check-out form
                pnlCheckIn.Visible = false;
                tblCheckout.Visible = true;
                dtCheckOut.CustomFormat = "dddM/d/yy  hh:mmtt";
                dtCheckIn.CustomFormat = "dddM/d/yy  hh:mmtt";
                dtCheckIn.Value = DateTime.Now;
                dtCheckIn.MinDate = dtCheckOut.Value;
                dtCheckIn.Value = dtCheckOut.Value.AddHours(2);

                if (isAdmin) cbNames.Enabled = true;
                else cbNames.Enabled = false;

                cbLaptop.Items.Clear();
                foreach (Computer lappy in availableLaptops)
                {
                    cbLaptop.Items.Add(lappy.ComputerName);
                }
                cbLaptop.SelectedIndex = 0;
            }
            else if (outLaptop != "")
            {
                // Initiate check-in form
                tblCheckout.Visible = false;
                pnlCheckIn.Visible = true;
                txtLaptopOut.Text = outLaptop;
            }
            else
            {
                tblCheckout.Visible = false;
                pnlCheckIn.Visible = false;
            }

            // Admin controls
            if (outLaptopData.Count > 0 && isAdmin)
            {
                gbAdmin.Visible = true;
                cbLaptopsOut.Items.Clear();
                foreach (string[] row in outLaptopData)
                {
                    cbLaptopsOut.Items.Add(row[0] + " - " + row[1].Replace("\"", ""));
                }
                cbLaptopsOut.SelectedIndex = 0;
            }
            else gbAdmin.Visible = false;

            if ((isAdmin || availableLaptops.Count < 1) && outLaptops.Count > 0)
            {
                tblNoLaptops.Visible = true;
                if (availableLaptops.Count > 0) lblNoLaptops.Visible = false;
                else lblNoLaptops.Visible = true;

                outLaptopData.OrderBy(d => DateTime.Parse(d[3]));
                gvCheckedOut.Rows.Clear();
                foreach (string[] data in outLaptopData)
                {
                    string name = "";
                    try
                    {
                        Employee emp = ViewConst.EMPS.Where(e => e.LogonID.ToUpper() == data[1].ToUpper()).ToArray()[0];
                        name = emp.FirstName + " " + emp.LastName;
                    }
                    catch { }

                    gvCheckedOut.Rows.Add(data[0], DateTime.Parse(data[3]), name, data[4]);
                }
            }
            else tblNoLaptops.Visible = false;
        }

        public void ReadCheckoutLog()
        {
            checkoutData.Clear();
            controller.readParser(checkoutData);
            outLaptopData = checkoutData.Where(data => data[5].Contains("false")).ToList();

            availableLaptops.Clear();
            outLaptops.Clear();
            outLaptop = "";
            foreach (Computer lappy in ViewConst.LAPTOPS)
            {
                bool isAvailable = true;
                foreach (string[] data in outLaptopData)
                {
                    if (data[0].Contains(lappy.ComputerName))
                    {
                        isAvailable = false;
                        if (data[1].ToUpper().Contains(ViewConst.LOGINID.ToUpper()))
                            outLaptop = lappy.ComputerName;
                    }
                }
                if (isAvailable) availableLaptops.Add(lappy);
                else outLaptops.Add(lappy);
            }
        }

        public void CheckIn(string computerName)
        {
            List<string[]> data = outLaptopData.Where(d => d[0].Contains(computerName)).ToList();
            Debug.Print(data.Count.ToString());
            controller.CheckIn(data, checkoutData);
            UpdateCheckout();
        }

        public string CreateCSVRow(string[] inputs)
        {
            return controller.CreateCSVRow(inputs);
        }

        #region User Interface Events
        private void TxtReason_TextChanged(object sender, EventArgs e)
        {
            if (!btnSubmit.Enabled)
            {
                if (cbNames.SelectedIndex >= 0 && txtReason.Text.Length > 0)
                    btnSubmit.Enabled = true;
            }
            else if (txtReason.Text.Length < 1)
                btnSubmit.Enabled = false;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>
            {
                availableLaptops[cbLaptop.SelectedIndex].ComputerName,
                ViewConst.EMPS[cbNames.SelectedIndex].LogonID,
                dtCheckOut.Value.ToString(),
                dtCheckIn.Value.ToString(),
                txtReason.Text,
                "false"
            };

            string submit = CreateCSVRow(data.ToArray());
            File.AppendAllText(ViewConst.CHECKOUTLOG, submit);
            UpdateCheckout();
        }

        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            CheckIn(outLaptop);
        }

        private void BtnAdminCheckIn_Click(object sender, EventArgs e)
        {
            string compName = outLaptopData[cbLaptopsOut.SelectedIndex][0];
            CheckIn(compName);
        }

        private void CBAdmin_CheckedChanged(object sender, EventArgs e)
        {
            isAdmin = cbAdmin.Checked;
            UpdateCheckout();
        }
        #endregion
        #endregion

        #region Find Admins
        public bool CheckAdmin()
        {
            return controller.CheckAdmin();
        }


        #endregion

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                DisplayComputerTree();
            }
        }
    }
}
