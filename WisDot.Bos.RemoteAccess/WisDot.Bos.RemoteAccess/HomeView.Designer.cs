using System.Configuration;

namespace WisDot.Bos.RemoteAccess
{
    partial class HomeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.textBoxRemotePc = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetLoggedInUsers = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.comboBoxRemotePc = new System.Windows.Forms.ComboBox();
            this.radioButtonEnterPc = new System.Windows.Forms.RadioButton();
            this.radioButtonSelectPc = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxRemotePc
            // 
            this.textBoxRemotePc.Location = new System.Drawing.Point(117, 49);
            this.textBoxRemotePc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRemotePc.Name = "textBoxRemotePc";
            this.textBoxRemotePc.Size = new System.Drawing.Size(138, 20);
            this.textBoxRemotePc.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(79, 23);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(150, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(79, 49);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(246, 23);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(70, 21);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(326, 23);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(70, 21);
            this.buttonDisconnect.TabIndex = 5;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Visible = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 79);
            this.panel2.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(917, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(212, 79);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network Drives";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(19, 51);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(27, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "(W:)";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(19, 27);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(24, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "(N:)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonDisconnect);
            this.groupBox2.Controls.Add(this.buttonConnect);
            this.groupBox2.Controls.Add(this.textBoxUsername);
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(423, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(494, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Network Credentials";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Don\'t Forget to Sign out...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonGetLoggedInUsers);
            this.groupBox1.Controls.Add(this.labelConnectionStatus);
            this.groupBox1.Controls.Add(this.comboBoxRemotePc);
            this.groupBox1.Controls.Add(this.radioButtonEnterPc);
            this.groupBox1.Controls.Add(this.radioButtonSelectPc);
            this.groupBox1.Controls.Add(this.textBoxRemotePc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(423, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote PC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(272, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = ConfigurationManager.AppSettings.Get("BrD Host 2");
            // 
            // buttonGetLoggedInUsers
            // 
            this.buttonGetLoggedInUsers.Location = new System.Drawing.Point(274, 7);
            this.buttonGetLoggedInUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGetLoggedInUsers.Name = "buttonGetLoggedInUsers";
            this.buttonGetLoggedInUsers.Size = new System.Drawing.Size(140, 21);
            this.buttonGetLoggedInUsers.TabIndex = 5;
            this.buttonGetLoggedInUsers.Tag = "";
            this.buttonGetLoggedInUsers.Text = "Anybody Logged-in?";
            this.buttonGetLoggedInUsers.UseVisualStyleBackColor = true;
            this.buttonGetLoggedInUsers.Visible = false;
            this.buttonGetLoggedInUsers.Click += new System.EventHandler(this.buttonGetLoggedInUsers_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionStatus.Location = new System.Drawing.Point(272, 32);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(151, 13);
            this.labelConnectionStatus.TabIndex = 0;
            this.labelConnectionStatus.Text = ConfigurationManager.AppSettings.Get("BrD Host 1");
            // 
            // comboBoxRemotePc
            // 
            this.comboBoxRemotePc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemotePc.FormattingEnabled = true;
            this.comboBoxRemotePc.Items.AddRange(Program.GetRemotePC());
            this.comboBoxRemotePc.Location = new System.Drawing.Point(117, 22);
            this.comboBoxRemotePc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxRemotePc.Name = "comboBoxRemotePc";
            this.comboBoxRemotePc.Size = new System.Drawing.Size(138, 21);
            this.comboBoxRemotePc.TabIndex = 2;
            // 
            // radioButtonEnterPc
            // 
            this.radioButtonEnterPc.AutoSize = true;
            this.radioButtonEnterPc.Location = new System.Drawing.Point(17, 50);
            this.radioButtonEnterPc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonEnterPc.Name = "radioButtonEnterPc";
            this.radioButtonEnterPc.Size = new System.Drawing.Size(101, 17);
            this.radioButtonEnterPc.TabIndex = 1;
            this.radioButtonEnterPc.TabStop = true;
            this.radioButtonEnterPc.Text = "Enter PC Name:";
            this.radioButtonEnterPc.UseVisualStyleBackColor = true;
            // 
            // radioButtonSelectPc
            // 
            this.radioButtonSelectPc.AutoSize = true;
            this.radioButtonSelectPc.Checked = true;
            this.radioButtonSelectPc.Location = new System.Drawing.Point(17, 24);
            this.radioButtonSelectPc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonSelectPc.Name = "radioButtonSelectPc";
            this.radioButtonSelectPc.Size = new System.Drawing.Size(75, 17);
            this.radioButtonSelectPc.TabIndex = 0;
            this.radioButtonSelectPc.TabStop = true;
            this.radioButtonSelectPc.Text = "Select PC:";
            this.radioButtonSelectPc.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 526);
            this.panel1.TabIndex = 7;
            // 
            // rdp
            // 
            this.rdp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(0, 0);
            this.rdp.Margin = new System.Windows.Forms.Padding(2);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(963, 526);
            this.rdp.TabIndex = 7;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HomeView";
            this.Text = "BOS Remote Access";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeView_FormClosing);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRemotePc;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Panel panel2;
        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxRemotePc;
        private System.Windows.Forms.RadioButton radioButtonEnterPc;
        private System.Windows.Forms.RadioButton radioButtonSelectPc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetLoggedInUsers;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
    }
}

