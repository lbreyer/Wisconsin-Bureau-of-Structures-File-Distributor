namespace WisDot.Bos.ComputerResources.FileDistributor
{
    partial class DistributionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeViewComputers = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonComputersUncheckAll = new System.Windows.Forms.Button();
            this.buttonComputersCheckAll = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeViewDistributionFolders = new System.Windows.Forms.TreeView();
            this.buttonFileSourcesUncheckAll = new System.Windows.Forms.Button();
            this.buttonFileSourcesCheckAll = new System.Windows.Forms.Button();
            this.buttonDistribute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxComputerFilePath = new System.Windows.Forms.TextBox();
            this.textBoxFileSourcesFilePath = new System.Windows.Forms.TextBox();
            this.toolTipSourcePathNode = new System.Windows.Forms.ToolTip(this.components);
            this.linkBOSBackupFiles = new System.Windows.Forms.LinkLabel();
            this.buttonEditFileSourcesXmlFile = new System.Windows.Forms.Button();
            this.buttonOpenFileSourcesXmlFile = new System.Windows.Forms.Button();
            this.buttonLoadComputerFile = new System.Windows.Forms.Button();
            this.buttonReloadFileSourcesXmlFile = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelProgressComputer = new System.Windows.Forms.Label();
            this.labelProgressFile = new System.Windows.Forms.Label();
            this.labelProgressComputerName = new System.Windows.Forms.Label();
            this.labelProgressFilePath = new System.Windows.Forms.Label();
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBarComputers = new System.Windows.Forms.ProgressBar();
            this.loadingSources = new System.ComponentModel.BackgroundWorker();
            this.loadingComputers = new System.ComponentModel.BackgroundWorker();
            this.buttonReloadComputersXmlFile = new System.Windows.Forms.Button();
            this.buttonEditComputersXmlFile = new System.Windows.Forms.Button();
            this.buttonReloadEmployeeXmlFile = new System.Windows.Forms.Button();
            this.buttonEditEmployeeXmlFile = new System.Windows.Forms.Button();
            this.buttonLoadEmployeeFile = new System.Windows.Forms.Button();
            this.textBoxEmployeeFilePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(619, 169);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewComputers);
            this.splitContainer1.Size = new System.Drawing.Size(272, 389);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Or on a person\'s name if person has only 1 computer.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Double-click on a computer to open its c-root.";
            // 
            // treeViewComputers
            // 
            this.treeViewComputers.CheckBoxes = true;
            this.treeViewComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewComputers.ImageIndex = 0;
            this.treeViewComputers.ImageList = this.imageList1;
            this.treeViewComputers.Location = new System.Drawing.Point(0, 0);
            this.treeViewComputers.Name = "treeViewComputers";
            this.treeViewComputers.SelectedImageIndex = 0;
            this.treeViewComputers.Size = new System.Drawing.Size(270, 334);
            this.treeViewComputers.TabIndex = 0;
            this.treeViewComputers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewComputers_AfterCheck);
            this.treeViewComputers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewComputers_NodeMouseDoubleClick);
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
            this.imageList1.Images.SetKeyName(7, "page.png");
            this.imageList1.Images.SetKeyName(8, "folder_error.png");
            this.imageList1.Images.SetKeyName(9, "help.png");
            this.imageList1.Images.SetKeyName(10, "Calendar_16x.png");
            this.imageList1.Images.SetKeyName(11, "StatusWarning.ico");
            // 
            // buttonComputersUncheckAll
            // 
            this.buttonComputersUncheckAll.Location = new System.Drawing.Point(703, 565);
            this.buttonComputersUncheckAll.Name = "buttonComputersUncheckAll";
            this.buttonComputersUncheckAll.Size = new System.Drawing.Size(75, 27);
            this.buttonComputersUncheckAll.TabIndex = 2;
            this.buttonComputersUncheckAll.Text = "Uncheck All";
            this.buttonComputersUncheckAll.UseVisualStyleBackColor = true;
            this.buttonComputersUncheckAll.Click += new System.EventHandler(this.buttonComputersUncheckAll_Click);
            // 
            // buttonComputersCheckAll
            // 
            this.buttonComputersCheckAll.Location = new System.Drawing.Point(621, 565);
            this.buttonComputersCheckAll.Name = "buttonComputersCheckAll";
            this.buttonComputersCheckAll.Size = new System.Drawing.Size(75, 27);
            this.buttonComputersCheckAll.TabIndex = 1;
            this.buttonComputersCheckAll.Text = "Check All";
            this.buttonComputersCheckAll.UseVisualStyleBackColor = true;
            this.buttonComputersCheckAll.Click += new System.EventHandler(this.buttonComputersCheckAll_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(30, 91);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox4);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox3);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeViewDistributionFolders);
            this.splitContainer2.Size = new System.Drawing.Size(485, 467);
            this.splitContainer2.SplitterDistance = 71;
            this.splitContainer2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "source: Double-click to open the directory.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.information;
            this.pictureBox4.Location = new System.Drawing.Point(145, 48);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Individual File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Entire folder can be distributed. Individual files, if any, can also be selected." +
    "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Entire folder cannot be distributed. Select individual files.";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.page;
            this.pictureBox3.Location = new System.Drawing.Point(20, 48);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.folder;
            this.pictureBox2.Location = new System.Drawing.Point(20, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.folder_error;
            this.pictureBox1.Location = new System.Drawing.Point(20, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // treeViewDistributionFolders
            // 
            this.treeViewDistributionFolders.CheckBoxes = true;
            this.treeViewDistributionFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDistributionFolders.ImageIndex = 0;
            this.treeViewDistributionFolders.ImageList = this.imageList1;
            this.treeViewDistributionFolders.Location = new System.Drawing.Point(0, 0);
            this.treeViewDistributionFolders.Name = "treeViewDistributionFolders";
            this.treeViewDistributionFolders.SelectedImageIndex = 0;
            this.treeViewDistributionFolders.Size = new System.Drawing.Size(483, 390);
            this.treeViewDistributionFolders.TabIndex = 0;
            this.treeViewDistributionFolders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDistributionFolders_AfterCheck);
            this.treeViewDistributionFolders.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewDistributionFolders_NodeMouseHover);
            this.treeViewDistributionFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDistributionFolders_NodeMouseDoubleClick);
            this.treeViewDistributionFolders.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeViewDistributionFolders_MouseMove);
            // 
            // buttonFileSourcesUncheckAll
            // 
            this.buttonFileSourcesUncheckAll.Location = new System.Drawing.Point(101, 565);
            this.buttonFileSourcesUncheckAll.Name = "buttonFileSourcesUncheckAll";
            this.buttonFileSourcesUncheckAll.Size = new System.Drawing.Size(75, 27);
            this.buttonFileSourcesUncheckAll.TabIndex = 1;
            this.buttonFileSourcesUncheckAll.Text = "Uncheck All";
            this.buttonFileSourcesUncheckAll.UseVisualStyleBackColor = true;
            this.buttonFileSourcesUncheckAll.Click += new System.EventHandler(this.buttonFileSourcesUncheckAll_Click);
            // 
            // buttonFileSourcesCheckAll
            // 
            this.buttonFileSourcesCheckAll.Location = new System.Drawing.Point(30, 565);
            this.buttonFileSourcesCheckAll.Name = "buttonFileSourcesCheckAll";
            this.buttonFileSourcesCheckAll.Size = new System.Drawing.Size(65, 27);
            this.buttonFileSourcesCheckAll.TabIndex = 0;
            this.buttonFileSourcesCheckAll.Text = "Check All";
            this.buttonFileSourcesCheckAll.UseVisualStyleBackColor = true;
            this.buttonFileSourcesCheckAll.Click += new System.EventHandler(this.buttonFileSourcesCheckAll_Click);
            // 
            // buttonDistribute
            // 
            this.buttonDistribute.Location = new System.Drawing.Point(521, 285);
            this.buttonDistribute.Name = "buttonDistribute";
            this.buttonDistribute.Size = new System.Drawing.Size(92, 39);
            this.buttonDistribute.TabIndex = 2;
            this.buttonDistribute.Text = "Copy >>";
            this.buttonDistribute.UseVisualStyleBackColor = true;
            this.buttonDistribute.Click += new System.EventHandler(this.buttonDistribute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(621, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Computers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Sources";
            // 
            // textBoxComputerFilePath
            // 
            this.textBoxComputerFilePath.Location = new System.Drawing.Point(621, 34);
            this.textBoxComputerFilePath.Name = "textBoxComputerFilePath";
            this.textBoxComputerFilePath.ReadOnly = true;
            this.textBoxComputerFilePath.Size = new System.Drawing.Size(271, 20);
            this.textBoxComputerFilePath.TabIndex = 5;
            // 
            // textBoxFileSourcesFilePath
            // 
            this.textBoxFileSourcesFilePath.Location = new System.Drawing.Point(30, 34);
            this.textBoxFileSourcesFilePath.Name = "textBoxFileSourcesFilePath";
            this.textBoxFileSourcesFilePath.ReadOnly = true;
            this.textBoxFileSourcesFilePath.Size = new System.Drawing.Size(485, 20);
            this.textBoxFileSourcesFilePath.TabIndex = 7;
            // 
            // toolTipSourcePathNode
            // 
            this.toolTipSourcePathNode.Tag = "";
            // 
            // linkBOSBackupFiles
            // 
            this.linkBOSBackupFiles.Location = new System.Drawing.Point(521, 429);
            this.linkBOSBackupFiles.Name = "linkBOSBackupFiles";
            this.linkBOSBackupFiles.Size = new System.Drawing.Size(92, 19);
            this.linkBOSBackupFiles.TabIndex = 29;
            this.linkBOSBackupFiles.TabStop = true;
            this.linkBOSBackupFiles.Text = "Log Files";
            this.linkBOSBackupFiles.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkBOSBackupFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBOSBackupFiles_LinkClicked);
            // 
            // buttonEditFileSourcesXmlFile
            // 
            this.buttonEditFileSourcesXmlFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.page_edit;
            this.buttonEditFileSourcesXmlFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditFileSourcesXmlFile.Location = new System.Drawing.Point(106, 60);
            this.buttonEditFileSourcesXmlFile.Name = "buttonEditFileSourcesXmlFile";
            this.buttonEditFileSourcesXmlFile.Size = new System.Drawing.Size(49, 25);
            this.buttonEditFileSourcesXmlFile.TabIndex = 30;
            this.buttonEditFileSourcesXmlFile.Text = "Edit";
            this.buttonEditFileSourcesXmlFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditFileSourcesXmlFile.UseVisualStyleBackColor = true;
            this.buttonEditFileSourcesXmlFile.Click += new System.EventHandler(this.buttonEditFileSourcesXmlFile_Click);
            // 
            // buttonOpenFileSourcesXmlFile
            // 
            this.buttonOpenFileSourcesXmlFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.folder_page;
            this.buttonOpenFileSourcesXmlFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenFileSourcesXmlFile.Location = new System.Drawing.Point(31, 60);
            this.buttonOpenFileSourcesXmlFile.Name = "buttonOpenFileSourcesXmlFile";
            this.buttonOpenFileSourcesXmlFile.Size = new System.Drawing.Size(68, 25);
            this.buttonOpenFileSourcesXmlFile.TabIndex = 8;
            this.buttonOpenFileSourcesXmlFile.Text = "Change";
            this.buttonOpenFileSourcesXmlFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOpenFileSourcesXmlFile.UseVisualStyleBackColor = true;
            this.buttonOpenFileSourcesXmlFile.Click += new System.EventHandler(this.buttonOpenFileSourcesXmlFile_Click);
            // 
            // buttonLoadComputerFile
            // 
            this.buttonLoadComputerFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.folder_page;
            this.buttonLoadComputerFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadComputerFile.Location = new System.Drawing.Point(621, 60);
            this.buttonLoadComputerFile.Name = "buttonLoadComputerFile";
            this.buttonLoadComputerFile.Size = new System.Drawing.Size(68, 25);
            this.buttonLoadComputerFile.TabIndex = 6;
            this.buttonLoadComputerFile.Text = "Change";
            this.buttonLoadComputerFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadComputerFile.UseVisualStyleBackColor = true;
            this.buttonLoadComputerFile.Click += new System.EventHandler(this.buttonLoadComputerFile_Click);
            // 
            // buttonReloadFileSourcesXmlFile
            // 
            this.buttonReloadFileSourcesXmlFile.Location = new System.Drawing.Point(161, 60);
            this.buttonReloadFileSourcesXmlFile.Name = "buttonReloadFileSourcesXmlFile";
            this.buttonReloadFileSourcesXmlFile.Size = new System.Drawing.Size(51, 25);
            this.buttonReloadFileSourcesXmlFile.TabIndex = 31;
            this.buttonReloadFileSourcesXmlFile.Text = "Reload";
            this.buttonReloadFileSourcesXmlFile.UseVisualStyleBackColor = true;
            this.buttonReloadFileSourcesXmlFile.Click += new System.EventHandler(this.buttonReloadFileSourcesXmlFile_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(521, 330);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(92, 39);
            this.buttonDelete.TabIndex = 32;
            this.buttonDelete.Text = "Delete >>";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelProgressComputer
            // 
            this.labelProgressComputer.Location = new System.Drawing.Point(36, 648);
            this.labelProgressComputer.Name = "labelProgressComputer";
            this.labelProgressComputer.Size = new System.Drawing.Size(106, 13);
            this.labelProgressComputer.TabIndex = 33;
            this.labelProgressComputer.Text = "Copying Files To:";
            this.labelProgressComputer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelProgressFile
            // 
            this.labelProgressFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgressFile.Location = new System.Drawing.Point(34, 606);
            this.labelProgressFile.Name = "labelProgressFile";
            this.labelProgressFile.Size = new System.Drawing.Size(108, 13);
            this.labelProgressFile.TabIndex = 34;
            this.labelProgressFile.Text = "Copying File:";
            this.labelProgressFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelProgressComputerName
            // 
            this.labelProgressComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgressComputerName.AutoSize = true;
            this.labelProgressComputerName.Location = new System.Drawing.Point(148, 648);
            this.labelProgressComputerName.Name = "labelProgressComputerName";
            this.labelProgressComputerName.Size = new System.Drawing.Size(51, 13);
            this.labelProgressComputerName.TabIndex = 35;
            this.labelProgressComputerName.Text = "computer";
            // 
            // labelProgressFilePath
            // 
            this.labelProgressFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgressFilePath.AutoSize = true;
            this.labelProgressFilePath.Location = new System.Drawing.Point(148, 606);
            this.labelProgressFilePath.Name = "labelProgressFilePath";
            this.labelProgressFilePath.Size = new System.Drawing.Size(41, 13);
            this.labelProgressFilePath.TabIndex = 36;
            this.labelProgressFilePath.Text = "filepath";
            // 
            // progressBarFile
            // 
            this.progressBarFile.Location = new System.Drawing.Point(30, 622);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(862, 23);
            this.progressBarFile.TabIndex = 37;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(521, 375);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 39);
            this.buttonCancel.TabIndex = 38;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBarComputers
            // 
            this.progressBarComputers.Location = new System.Drawing.Point(30, 664);
            this.progressBarComputers.Name = "progressBarComputers";
            this.progressBarComputers.Size = new System.Drawing.Size(862, 23);
            this.progressBarComputers.TabIndex = 39;
            // 
            // loadingSources
            // 
            this.loadingSources.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadingSources_DoWork);
            this.loadingSources.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadingSources_RunWorkerCompleted);
            // 
            // loadingComputers
            // 
            this.loadingComputers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadingComputers_DoWork);
            this.loadingComputers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadingComputers_RunWorkerCompleted);
            // 
            // buttonReloadComputersXmlFile
            // 
            this.buttonReloadComputersXmlFile.Location = new System.Drawing.Point(750, 60);
            this.buttonReloadComputersXmlFile.Name = "buttonReloadComputersXmlFile";
            this.buttonReloadComputersXmlFile.Size = new System.Drawing.Size(51, 25);
            this.buttonReloadComputersXmlFile.TabIndex = 41;
            this.buttonReloadComputersXmlFile.Text = "Reload";
            this.buttonReloadComputersXmlFile.UseVisualStyleBackColor = true;
            this.buttonReloadComputersXmlFile.Click += new System.EventHandler(this.buttonReloadComputersXmlFile_Click);
            // 
            // buttonEditComputersXmlFile
            // 
            this.buttonEditComputersXmlFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.page_edit;
            this.buttonEditComputersXmlFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditComputersXmlFile.Location = new System.Drawing.Point(695, 60);
            this.buttonEditComputersXmlFile.Name = "buttonEditComputersXmlFile";
            this.buttonEditComputersXmlFile.Size = new System.Drawing.Size(49, 25);
            this.buttonEditComputersXmlFile.TabIndex = 40;
            this.buttonEditComputersXmlFile.Text = "Edit";
            this.buttonEditComputersXmlFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditComputersXmlFile.UseVisualStyleBackColor = true;
            this.buttonEditComputersXmlFile.Click += new System.EventHandler(this.buttonEditComputersXmlFile_Click);
            // 
            // buttonReloadEmployeeXmlFile
            // 
            this.buttonReloadEmployeeXmlFile.Location = new System.Drawing.Point(750, 138);
            this.buttonReloadEmployeeXmlFile.Name = "buttonReloadEmployeeXmlFile";
            this.buttonReloadEmployeeXmlFile.Size = new System.Drawing.Size(51, 25);
            this.buttonReloadEmployeeXmlFile.TabIndex = 46;
            this.buttonReloadEmployeeXmlFile.Text = "Reload";
            this.buttonReloadEmployeeXmlFile.UseVisualStyleBackColor = true;
            this.buttonReloadEmployeeXmlFile.Click += new System.EventHandler(this.buttonReloadEmployeeXmlFile_Click);
            // 
            // buttonEditEmployeeXmlFile
            // 
            this.buttonEditEmployeeXmlFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.page_edit;
            this.buttonEditEmployeeXmlFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditEmployeeXmlFile.Location = new System.Drawing.Point(695, 138);
            this.buttonEditEmployeeXmlFile.Name = "buttonEditEmployeeXmlFile";
            this.buttonEditEmployeeXmlFile.Size = new System.Drawing.Size(49, 25);
            this.buttonEditEmployeeXmlFile.TabIndex = 45;
            this.buttonEditEmployeeXmlFile.Text = "Edit";
            this.buttonEditEmployeeXmlFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditEmployeeXmlFile.UseVisualStyleBackColor = true;
            this.buttonEditEmployeeXmlFile.Click += new System.EventHandler(this.buttonEditEmployeeXmlFile_Click);
            // 
            // buttonLoadEmployeeFile
            // 
            this.buttonLoadEmployeeFile.Image = global::WisDot.Bos.ComputerResources.FileDistributor.Properties.Resources.folder_page;
            this.buttonLoadEmployeeFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadEmployeeFile.Location = new System.Drawing.Point(621, 138);
            this.buttonLoadEmployeeFile.Name = "buttonLoadEmployeeFile";
            this.buttonLoadEmployeeFile.Size = new System.Drawing.Size(68, 25);
            this.buttonLoadEmployeeFile.TabIndex = 44;
            this.buttonLoadEmployeeFile.Text = "Change";
            this.buttonLoadEmployeeFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadEmployeeFile.UseVisualStyleBackColor = true;
            this.buttonLoadEmployeeFile.Click += new System.EventHandler(this.buttonLoadEmployeeFile_Click);
            // 
            // textBoxEmployeeFilePath
            // 
            this.textBoxEmployeeFilePath.Location = new System.Drawing.Point(621, 112);
            this.textBoxEmployeeFilePath.Name = "textBoxEmployeeFilePath";
            this.textBoxEmployeeFilePath.ReadOnly = true;
            this.textBoxEmployeeFilePath.Size = new System.Drawing.Size(271, 20);
            this.textBoxEmployeeFilePath.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(621, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "Employees";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 709);
            this.Controls.Add(this.buttonReloadEmployeeXmlFile);
            this.Controls.Add(this.buttonEditEmployeeXmlFile);
            this.Controls.Add(this.buttonLoadEmployeeFile);
            this.Controls.Add(this.textBoxEmployeeFilePath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonReloadComputersXmlFile);
            this.Controls.Add(this.buttonEditComputersXmlFile);
            this.Controls.Add(this.progressBarComputers);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBarFile);
            this.Controls.Add(this.labelProgressFilePath);
            this.Controls.Add(this.labelProgressComputerName);
            this.Controls.Add(this.labelProgressFile);
            this.Controls.Add(this.labelProgressComputer);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonReloadFileSourcesXmlFile);
            this.Controls.Add(this.buttonEditFileSourcesXmlFile);
            this.Controls.Add(this.linkBOSBackupFiles);
            this.Controls.Add(this.buttonOpenFileSourcesXmlFile);
            this.Controls.Add(this.textBoxFileSourcesFilePath);
            this.Controls.Add(this.buttonComputersUncheckAll);
            this.Controls.Add(this.buttonFileSourcesUncheckAll);
            this.Controls.Add(this.buttonComputersCheckAll);
            this.Controls.Add(this.buttonLoadComputerFile);
            this.Controls.Add(this.buttonFileSourcesCheckAll);
            this.Controls.Add(this.textBoxComputerFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDistribute);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "File Distributor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewComputers;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonDistribute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxComputerFilePath;
        private System.Windows.Forms.Button buttonLoadComputerFile;
        private System.Windows.Forms.TextBox textBoxFileSourcesFilePath;
        private System.Windows.Forms.Button buttonOpenFileSourcesXmlFile;
        private System.Windows.Forms.TreeView treeViewDistributionFolders;
        private System.Windows.Forms.Button buttonFileSourcesUncheckAll;
        private System.Windows.Forms.Button buttonFileSourcesCheckAll;
        private System.Windows.Forms.Button buttonComputersUncheckAll;
        private System.Windows.Forms.Button buttonComputersCheckAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTipSourcePathNode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkBOSBackupFiles;
        private System.Windows.Forms.Button buttonEditFileSourcesXmlFile;
        private System.Windows.Forms.Button buttonReloadFileSourcesXmlFile;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelProgressComputer;
        private System.Windows.Forms.Label labelProgressFile;
        private System.Windows.Forms.Label labelProgressComputerName;
        private System.Windows.Forms.Label labelProgressFilePath;
        private System.Windows.Forms.ProgressBar progressBarFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBarComputers;
        private System.ComponentModel.BackgroundWorker loadingSources;
        private System.ComponentModel.BackgroundWorker loadingComputers;
        private System.Windows.Forms.Button buttonReloadComputersXmlFile;
        private System.Windows.Forms.Button buttonEditComputersXmlFile;
        private System.Windows.Forms.Button buttonReloadEmployeeXmlFile;
        private System.Windows.Forms.Button buttonEditEmployeeXmlFile;
        private System.Windows.Forms.Button buttonLoadEmployeeFile;
        private System.Windows.Forms.TextBox textBoxEmployeeFilePath;
        private System.Windows.Forms.Label label9;
    }
}

