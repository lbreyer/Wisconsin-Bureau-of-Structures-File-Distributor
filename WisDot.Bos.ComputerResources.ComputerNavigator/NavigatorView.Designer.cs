namespace WisDot.Bos.ComputerResources.ComputerNavigator
{
    partial class NavigatorView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorView));
            this.treeViewComputers = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAvailabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.radioButtonSearch = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonEmployeeView = new System.Windows.Forms.RadioButton();
            this.radioButtonOrganizationView = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbNavigator = new System.Windows.Forms.TabPage();
            this.tbCheckout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.tblCheckout = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbNames = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLaptop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtCheckIn = new System.Windows.Forms.DateTimePicker();
            this.pnlCheckIn = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtLaptopOut = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnAdminCheckIn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbLaptopsOut = new System.Windows.Forms.ComboBox();
            this.tblNoLaptops = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoLaptops = new System.Windows.Forms.Label();
            this.gvCheckedOut = new System.Windows.Forms.DataGridView();
            this.Laptop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbNavigator.SuspendLayout();
            this.tbCheckout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblCheckout.SuspendLayout();
            this.pnlCheckIn.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.tblNoLaptops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckedOut)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewComputers
            // 
            this.treeViewComputers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewComputers.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewComputers.ImageIndex = 0;
            this.treeViewComputers.ImageList = this.imageList1;
            this.treeViewComputers.Location = new System.Drawing.Point(0, 106);
            this.treeViewComputers.Margin = new System.Windows.Forms.Padding(6);
            this.treeViewComputers.Name = "treeViewComputers";
            this.treeViewComputers.SelectedImageIndex = 0;
            this.treeViewComputers.ShowNodeToolTips = true;
            this.treeViewComputers.Size = new System.Drawing.Size(307, 399);
            this.treeViewComputers.TabIndex = 9;
            this.treeViewComputers.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewComputers_BeforeCollapse);
            this.treeViewComputers.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewComputers_BeforeExpand);
            this.treeViewComputers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewComputers_NodeMouseClick);
            this.treeViewComputers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewComputers_NodeMouseDoubleClick);
            this.treeViewComputers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewComputers_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteConnectToolStripMenuItem,
            this.checkAvailabilityToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 48);
            // 
            // remoteConnectToolStripMenuItem
            // 
            this.remoteConnectToolStripMenuItem.Name = "remoteConnectToolStripMenuItem";
            this.remoteConnectToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.remoteConnectToolStripMenuItem.Text = "Remote Connect";
            this.remoteConnectToolStripMenuItem.Click += new System.EventHandler(this.remoteConnectToolStripMenuItem_Click);
            // 
            // checkAvailabilityToolStripMenuItem
            // 
            this.checkAvailabilityToolStripMenuItem.Name = "checkAvailabilityToolStripMenuItem";
            this.checkAvailabilityToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.checkAvailabilityToolStripMenuItem.Text = "Check Availability";
            this.checkAvailabilityToolStripMenuItem.Click += new System.EventHandler(this.checkAvailabilityToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "user.png");
            this.imageList1.Images.SetKeyName(2, "laptop.ico");
            this.imageList1.Images.SetKeyName(3, "computer.png");
            this.imageList1.Images.SetKeyName(4, "crown.png");
            this.imageList1.Images.SetKeyName(5, "cheguevara.png");
            this.imageList1.Images.SetKeyName(6, "information.png");
            this.imageList1.Images.SetKeyName(7, "call");
            this.imageList1.Images.SetKeyName(8, "Location");
            // 
            // panelCriteria
            // 
            this.panelCriteria.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCriteria.Controls.Add(this.comboBoxSearch);
            this.panelCriteria.Controls.Add(this.searchBox);
            this.panelCriteria.Controls.Add(this.radioButtonSearch);
            this.panelCriteria.Controls.Add(this.label4);
            this.panelCriteria.Controls.Add(this.btnMap);
            this.panelCriteria.Controls.Add(this.label3);
            this.panelCriteria.Controls.Add(this.label2);
            this.panelCriteria.Controls.Add(this.label1);
            this.panelCriteria.Controls.Add(this.radioButtonEmployeeView);
            this.panelCriteria.Controls.Add(this.radioButtonOrganizationView);
            this.panelCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCriteria.Location = new System.Drawing.Point(0, 0);
            this.panelCriteria.Name = "panelCriteria";
            this.panelCriteria.Size = new System.Drawing.Size(307, 106);
            this.panelCriteria.TabIndex = 8;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Name",
            "Cube #",
            "Logon ID",
            "Computer ID"});
            this.comboBoxSearch.Location = new System.Drawing.Point(139, 76);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(81, 21);
            this.comboBoxSearch.TabIndex = 11;
            this.comboBoxSearch.Text = "Name";
            this.comboBoxSearch.Visible = false;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(6, 76);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(120, 20);
            this.searchBox.TabIndex = 10;
            this.searchBox.Visible = false;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            // 
            // radioButtonSearch
            // 
            this.radioButtonSearch.AutoSize = true;
            this.radioButtonSearch.Location = new System.Drawing.Point(226, 15);
            this.radioButtonSearch.Name = "radioButtonSearch";
            this.radioButtonSearch.Size = new System.Drawing.Size(59, 17);
            this.radioButtonSearch.TabIndex = 9;
            this.radioButtonSearch.TabStop = true;
            this.radioButtonSearch.Text = "Search";
            this.radioButtonSearch.UseVisualStyleBackColor = true;
            this.radioButtonSearch.Click += new System.EventHandler(this.RadioButtonSearchView_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Click on a cube # to open a map.";
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(226, 76);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 7;
            this.btnMap.Text = "Cube Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.BtnMap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Or on person\'s name if person has only 1 computer.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Double-click on a computer to open its c-root.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Views";
            // 
            // radioButtonEmployeeView
            // 
            this.radioButtonEmployeeView.AutoSize = true;
            this.radioButtonEmployeeView.Checked = true;
            this.radioButtonEmployeeView.Location = new System.Drawing.Point(31, 17);
            this.radioButtonEmployeeView.Name = "radioButtonEmployeeView";
            this.radioButtonEmployeeView.Size = new System.Drawing.Size(76, 17);
            this.radioButtonEmployeeView.TabIndex = 2;
            this.radioButtonEmployeeView.TabStop = true;
            this.radioButtonEmployeeView.Text = "Employees";
            this.radioButtonEmployeeView.UseVisualStyleBackColor = true;
            this.radioButtonEmployeeView.Click += new System.EventHandler(this.RadioButtonEmployeeView_Click);
            // 
            // radioButtonOrganizationView
            // 
            this.radioButtonOrganizationView.AutoSize = true;
            this.radioButtonOrganizationView.Location = new System.Drawing.Point(129, 15);
            this.radioButtonOrganizationView.Name = "radioButtonOrganizationView";
            this.radioButtonOrganizationView.Size = new System.Drawing.Size(70, 17);
            this.radioButtonOrganizationView.TabIndex = 0;
            this.radioButtonOrganizationView.Text = "Org Chart";
            this.radioButtonOrganizationView.UseVisualStyleBackColor = true;
            this.radioButtonOrganizationView.Click += new System.EventHandler(this.RadioButtonOrganizationView_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbNavigator);
            this.tabControl1.Controls.Add(this.tbCheckout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(315, 531);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tbNavigator
            // 
            this.tbNavigator.Controls.Add(this.treeViewComputers);
            this.tbNavigator.Controls.Add(this.panelCriteria);
            this.tbNavigator.Location = new System.Drawing.Point(4, 22);
            this.tbNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.tbNavigator.Name = "tbNavigator";
            this.tbNavigator.Size = new System.Drawing.Size(307, 505);
            this.tbNavigator.TabIndex = 0;
            this.tbNavigator.Text = "Navigator";
            this.tbNavigator.UseVisualStyleBackColor = true;
            // 
            // tbCheckout
            // 
            this.tbCheckout.Controls.Add(this.tableLayoutPanel1);
            this.tbCheckout.Location = new System.Drawing.Point(4, 22);
            this.tbCheckout.Margin = new System.Windows.Forms.Padding(0);
            this.tbCheckout.Name = "tbCheckout";
            this.tbCheckout.Size = new System.Drawing.Size(307, 505);
            this.tbCheckout.TabIndex = 1;
            this.tbCheckout.Text = "Checkout Laptops";
            this.tbCheckout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbAdmin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblCheckout, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlCheckIn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbAdmin, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tblNoLaptops, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 505);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Checked = true;
            this.cbAdmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAdmin.Location = new System.Drawing.Point(3, 3);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(89, 17);
            this.cbAdmin.TabIndex = 15;
            this.cbAdmin.Text = "I\'m an Admin!";
            this.cbAdmin.UseVisualStyleBackColor = true;
            this.cbAdmin.Visible = false;
            this.cbAdmin.CheckedChanged += new System.EventHandler(this.CBAdmin_CheckedChanged);
            // 
            // tblCheckout
            // 
            this.tblCheckout.AutoSize = true;
            this.tblCheckout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblCheckout.ColumnCount = 2;
            this.tblCheckout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblCheckout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblCheckout.Controls.Add(this.label5, 0, 0);
            this.tblCheckout.Controls.Add(this.label6, 0, 1);
            this.tblCheckout.Controls.Add(this.dtCheckOut, 1, 0);
            this.tblCheckout.Controls.Add(this.label7, 0, 2);
            this.tblCheckout.Controls.Add(this.cbNames, 1, 2);
            this.tblCheckout.Controls.Add(this.label8, 0, 3);
            this.tblCheckout.Controls.Add(this.cbLaptop, 1, 3);
            this.tblCheckout.Controls.Add(this.label9, 0, 4);
            this.tblCheckout.Controls.Add(this.txtReason, 0, 5);
            this.tblCheckout.Controls.Add(this.btnSubmit, 1, 6);
            this.tblCheckout.Controls.Add(this.dtCheckIn, 1, 1);
            this.tblCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCheckout.Location = new System.Drawing.Point(3, 26);
            this.tblCheckout.Name = "tblCheckout";
            this.tblCheckout.RowCount = 7;
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCheckout.Size = new System.Drawing.Size(301, 235);
            this.tblCheckout.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Check-out Time";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Expected Check-in Time";
            // 
            // dtCheckOut
            // 
            this.dtCheckOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCheckOut.Enabled = false;
            this.dtCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCheckOut.Location = new System.Drawing.Point(132, 3);
            this.dtCheckOut.Name = "dtCheckOut";
            this.dtCheckOut.Size = new System.Drawing.Size(166, 20);
            this.dtCheckOut.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Name";
            // 
            // cbNames
            // 
            this.cbNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNames.Enabled = false;
            this.cbNames.FormattingEnabled = true;
            this.cbNames.Location = new System.Drawing.Point(132, 55);
            this.cbNames.Name = "cbNames";
            this.cbNames.Size = new System.Drawing.Size(121, 21);
            this.cbNames.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Laptop";
            // 
            // cbLaptop
            // 
            this.cbLaptop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaptop.FormattingEnabled = true;
            this.cbLaptop.Location = new System.Drawing.Point(132, 82);
            this.cbLaptop.Name = "cbLaptop";
            this.cbLaptop.Size = new System.Drawing.Size(121, 21);
            this.cbLaptop.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 109);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Reason for Checkout";
            // 
            // txtReason
            // 
            this.tblCheckout.SetColumnSpan(this.txtReason, 2);
            this.txtReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReason.Location = new System.Drawing.Point(3, 128);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(295, 75);
            this.txtReason.TabIndex = 8;
            this.txtReason.TextChanged += new System.EventHandler(this.TxtReason_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(223, 209);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // dtCheckIn
            // 
            this.dtCheckIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCheckIn.Location = new System.Drawing.Point(132, 29);
            this.dtCheckIn.Name = "dtCheckIn";
            this.dtCheckIn.Size = new System.Drawing.Size(166, 20);
            this.dtCheckIn.TabIndex = 10;
            // 
            // pnlCheckIn
            // 
            this.pnlCheckIn.AutoSize = true;
            this.pnlCheckIn.Controls.Add(this.btnCheckIn);
            this.pnlCheckIn.Controls.Add(this.txtLaptopOut);
            this.pnlCheckIn.Controls.Add(this.label10);
            this.pnlCheckIn.Location = new System.Drawing.Point(3, 267);
            this.pnlCheckIn.Name = "pnlCheckIn";
            this.pnlCheckIn.Size = new System.Drawing.Size(301, 58);
            this.pnlCheckIn.TabIndex = 1;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.AutoSize = true;
            this.btnCheckIn.Location = new System.Drawing.Point(94, 32);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(85, 23);
            this.btnCheckIn.TabIndex = 13;
            this.btnCheckIn.Text = "Return Laptop";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.BtnCheckIn_Click);
            // 
            // txtLaptopOut
            // 
            this.txtLaptopOut.Location = new System.Drawing.Point(174, 3);
            this.txtLaptopOut.Name = "txtLaptopOut";
            this.txtLaptopOut.ReadOnly = true;
            this.txtLaptopOut.Size = new System.Drawing.Size(100, 20);
            this.txtLaptopOut.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "You have checked out laptop";
            // 
            // gbAdmin
            // 
            this.gbAdmin.AutoSize = true;
            this.gbAdmin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbAdmin.Controls.Add(this.btnAdminCheckIn);
            this.gbAdmin.Controls.Add(this.label11);
            this.gbAdmin.Controls.Add(this.cbLaptopsOut);
            this.gbAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAdmin.Location = new System.Drawing.Point(3, 331);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(301, 88);
            this.gbAdmin.TabIndex = 2;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "Admin Control";
            // 
            // btnAdminCheckIn
            // 
            this.btnAdminCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdminCheckIn.Location = new System.Drawing.Point(209, 46);
            this.btnAdminCheckIn.Name = "btnAdminCheckIn";
            this.btnAdminCheckIn.Size = new System.Drawing.Size(86, 23);
            this.btnAdminCheckIn.TabIndex = 14;
            this.btnAdminCheckIn.Text = "Check In";
            this.btnAdminCheckIn.UseVisualStyleBackColor = true;
            this.btnAdminCheckIn.Click += new System.EventHandler(this.BtnAdminCheckIn_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Laptop";
            // 
            // cbLaptopsOut
            // 
            this.cbLaptopsOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaptopsOut.FormattingEnabled = true;
            this.cbLaptopsOut.Location = new System.Drawing.Point(89, 19);
            this.cbLaptopsOut.Name = "cbLaptopsOut";
            this.cbLaptopsOut.Size = new System.Drawing.Size(164, 21);
            this.cbLaptopsOut.TabIndex = 8;
            // 
            // tblNoLaptops
            // 
            this.tblNoLaptops.ColumnCount = 1;
            this.tblNoLaptops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblNoLaptops.Controls.Add(this.lblNoLaptops, 0, 0);
            this.tblNoLaptops.Controls.Add(this.gvCheckedOut, 0, 1);
            this.tblNoLaptops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblNoLaptops.Location = new System.Drawing.Point(3, 425);
            this.tblNoLaptops.Name = "tblNoLaptops";
            this.tblNoLaptops.RowCount = 2;
            this.tblNoLaptops.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblNoLaptops.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblNoLaptops.Size = new System.Drawing.Size(301, 100);
            this.tblNoLaptops.TabIndex = 3;
            // 
            // lblNoLaptops
            // 
            this.lblNoLaptops.AutoSize = true;
            this.lblNoLaptops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLaptops.Location = new System.Drawing.Point(3, 0);
            this.lblNoLaptops.Name = "lblNoLaptops";
            this.lblNoLaptops.Size = new System.Drawing.Size(271, 15);
            this.lblNoLaptops.TabIndex = 0;
            this.lblNoLaptops.Text = "Sorry, No laptops are available right now!";
            // 
            // gvCheckedOut
            // 
            this.gvCheckedOut.AllowUserToAddRows = false;
            this.gvCheckedOut.AllowUserToDeleteRows = false;
            this.gvCheckedOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCheckedOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Laptop,
            this.Return,
            this.UserName,
            this.Reason});
            this.gvCheckedOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCheckedOut.Location = new System.Drawing.Point(3, 18);
            this.gvCheckedOut.Name = "gvCheckedOut";
            this.gvCheckedOut.RowHeadersVisible = false;
            this.gvCheckedOut.Size = new System.Drawing.Size(295, 79);
            this.gvCheckedOut.TabIndex = 1;
            // 
            // Laptop
            // 
            this.Laptop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Laptop.HeaderText = "Laptop";
            this.Laptop.Name = "Laptop";
            this.Laptop.ReadOnly = true;
            this.Laptop.Width = 65;
            // 
            // Return
            // 
            this.Return.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Return.HeaderText = "Return Time";
            this.Return.Name = "Return";
            this.Return.ReadOnly = true;
            this.Return.Width = 90;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 60;
            // 
            // Reason
            // 
            this.Reason.HeaderText = "Reason";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NavigatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 531);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NavigatorView";
            this.Text = "Computer Navigator";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelCriteria.ResumeLayout(false);
            this.panelCriteria.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbNavigator.ResumeLayout(false);
            this.tbCheckout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblCheckout.ResumeLayout(false);
            this.tblCheckout.PerformLayout();
            this.pnlCheckIn.ResumeLayout(false);
            this.pnlCheckIn.PerformLayout();
            this.gbAdmin.ResumeLayout(false);
            this.gbAdmin.PerformLayout();
            this.tblNoLaptops.ResumeLayout(false);
            this.tblNoLaptops.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckedOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCriteria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonEmployeeView;
        private System.Windows.Forms.RadioButton radioButtonOrganizationView;
        private System.Windows.Forms.TreeView treeViewComputers;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbNavigator;
        private System.Windows.Forms.TabPage tbCheckout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblCheckout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtCheckOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbNames;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbLaptop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtCheckIn;
        private System.Windows.Forms.Panel pnlCheckIn;
        private System.Windows.Forms.TextBox txtLaptopOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnAdminCheckIn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbLaptopsOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TableLayoutPanel tblNoLaptops;
        private System.Windows.Forms.Label lblNoLaptops;
        private System.Windows.Forms.DataGridView gvCheckedOut;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Laptop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Return;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.RadioButton radioButtonSearch;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem remoteConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAvailabilityToolStripMenuItem;
    }
}

