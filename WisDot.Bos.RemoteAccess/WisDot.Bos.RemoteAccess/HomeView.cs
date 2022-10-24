using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Management;
using System.Diagnostics;
using MSTSCLib;

namespace WisDot.Bos.RemoteAccess
{
    public partial class HomeView : Form
    {
        private string remotePcName = "";
        private string userName = System.Environment.UserName;
        private string password = "";

        public HomeView(string ComputerID)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();
            textBoxUsername.Text = userName;
            if(!String.IsNullOrEmpty(ComputerID))
            {
                radioButtonEnterPc.Checked = true;
                radioButtonSelectPc.Checked = false;
            }
            comboBoxRemotePc.SelectedIndex = 0;
            //buttonDisconnect.Enabled = false;
            textBoxRemotePc.Text = ComputerID;
        }

        private void connect()
        {
            if (radioButtonSelectPc.Checked)
            {
                remotePcName = comboBoxRemotePc.SelectedItem.ToString().Trim();
            }
            else
            {
                remotePcName = textBoxRemotePc.Text.Trim();
            }

            if (String.IsNullOrEmpty(remotePcName))
            {
                MessageBox.Show("Select or enter a remote PC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userName = textBoxUsername.Text.Trim();

            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Enter username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            password = textBoxPassword.Text.Trim();

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonConnect.Enabled = false;
            //labelConnectionStatus.Text = "Connecting...";

            try
            {
                try
                {
                    if (rdp.Connected.ToString() == "1")
                    {
                        rdp.Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("Error: {0}", ex.StackTrace);
                }

                rdp.Server = remotePcName;
                rdp.UserName = userName;
                MsRdpClient8NotSafeForScripting secured = (MsRdpClient8NotSafeForScripting)rdp.GetOcx();
                secured.AdvancedSettings8.ClearTextPassword = password;
                secured.AdvancedSettings8.EnableCredSspSupport = true;
                secured.FullScreen = true;
                secured.FullScreenTitle = rdp.Server;
                rdp.Connect();
                //labelConnectionStatus.Text = "Connected...";
                //buttonDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                //labelConnectionStatus.Text = "Not Connected...";
                //buttonConnect.Enabled = true;
                //buttonDisconnect.Enabled = false;
                MessageBox.Show("Error connecting. Try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonConnect.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (radioButtonSelectPc.Checked)
            {
                remotePcName = comboBoxRemotePc.SelectedItem.ToString().Trim();
            }
            else
            {
                remotePcName = textBoxRemotePc.Text.Trim();
            }

            if (String.IsNullOrEmpty(remotePcName))
            {
                MessageBox.Show("Select or enter a remote PC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userName = textBoxUsername.Text.Trim();

            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Enter username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            password = textBoxPassword.Text.Trim();

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdp.Connected.ToString() == "1")
                {
                    rdp.Disconnect();
                    //labelConnectionStatus.Text = "Not Connected...";
                    //buttonConnect.Enabled = true;
                    //buttonDisconnect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to disconnect.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HomeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rdp.Connected.ToString() == "1")
            {
                rdp.Disconnect();
            }
        }

        private void buttonGetLoggedInUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"\\mad00fph\n4public\bos\");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"\\mad00fp1\w4bhs\");
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connect();
            }
        }
    }
}
