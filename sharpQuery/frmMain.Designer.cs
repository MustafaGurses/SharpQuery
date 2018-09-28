namespace sharpQuery
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cntxDataBase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRestore = new ns1.BunifuFlatButton();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.bgwRestoreDB = new System.ComponentModel.BackgroundWorker();
            this.lblDataBases = new System.Windows.Forms.Label();
            this.btnCreate = new ns1.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.btnAutoBackup = new ns1.BunifuFlatButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeData = new System.Windows.Forms.TreeView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cntxQuery = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExecute = new ns1.BunifuFlatButton();
            this.cntxTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTop200RowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRUNCATETABLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setPrimaryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePrimaryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrLoging = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnConnectRemote = new ns1.BunifuFlatButton();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLocalConnect = new ns1.BunifuFlatButton();
            this.serverList = new System.Windows.Forms.ComboBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.cntxQueryCode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.ınsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enlargeMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwApplication = new System.ComponentModel.BackgroundWorker();
            this.BgwMarquee = new System.ComponentModel.BackgroundWorker();
            this.cntxDataBase.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.cntxQuery.SuspendLayout();
            this.cntxTable.SuspendLayout();
            this.cntxKey.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cntxQueryCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntxDataBase
            // 
            this.cntxDataBase.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cntxDataBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQueryToolStripMenuItem,
            this.newTableToolStripMenuItem,
            this.backupDataBaseToolStripMenuItem,
            this.deleteDataBaseToolStripMenuItem});
            this.cntxDataBase.Name = "contextMenuStrip2";
            this.cntxDataBase.Size = new System.Drawing.Size(165, 92);
            // 
            // newQueryToolStripMenuItem
            // 
            this.newQueryToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newQueryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newQueryToolStripMenuItem.Image")));
            this.newQueryToolStripMenuItem.Name = "newQueryToolStripMenuItem";
            this.newQueryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newQueryToolStripMenuItem.Text = "New Query";
            this.newQueryToolStripMenuItem.Click += new System.EventHandler(this.newQueryToolStripMenuItem_Click);
            // 
            // newTableToolStripMenuItem
            // 
            this.newTableToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newTableToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newTableToolStripMenuItem.Image")));
            this.newTableToolStripMenuItem.Name = "newTableToolStripMenuItem";
            this.newTableToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newTableToolStripMenuItem.Text = "New Table";
            this.newTableToolStripMenuItem.Click += new System.EventHandler(this.newTableToolStripMenuItem_Click);
            // 
            // backupDataBaseToolStripMenuItem
            // 
            this.backupDataBaseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backupDataBaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backupDataBaseToolStripMenuItem.Image")));
            this.backupDataBaseToolStripMenuItem.Name = "backupDataBaseToolStripMenuItem";
            this.backupDataBaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backupDataBaseToolStripMenuItem.Text = "Backup DataBase";
            this.backupDataBaseToolStripMenuItem.Click += new System.EventHandler(this.backupDataBaseToolStripMenuItem_Click);
            // 
            // deleteDataBaseToolStripMenuItem
            // 
            this.deleteDataBaseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteDataBaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteDataBaseToolStripMenuItem.Image")));
            this.deleteDataBaseToolStripMenuItem.Name = "deleteDataBaseToolStripMenuItem";
            this.deleteDataBaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteDataBaseToolStripMenuItem.Text = "Delete DataBase";
            this.deleteDataBaseToolStripMenuItem.Click += new System.EventHandler(this.deleteDataBaseToolStripMenuItem_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestore.BorderRadius = 0;
            this.btnRestore.ButtonText = "         Restore Database From ...";
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.DisabledColor = System.Drawing.Color.Gray;
            this.btnRestore.Iconcolor = System.Drawing.Color.White;
            this.btnRestore.Iconimage = null;
            this.btnRestore.Iconimage_right = null;
            this.btnRestore.Iconimage_right_Selected = null;
            this.btnRestore.Iconimage_Selected = null;
            this.btnRestore.IconMarginLeft = 0;
            this.btnRestore.IconMarginRight = 0;
            this.btnRestore.IconRightVisible = true;
            this.btnRestore.IconRightZoom = 0D;
            this.btnRestore.IconVisible = true;
            this.btnRestore.IconZoom = 90D;
            this.btnRestore.IsTab = false;
            this.btnRestore.Location = new System.Drawing.Point(711, 0);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRestore.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRestore.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRestore.selected = false;
            this.btnRestore.Size = new System.Drawing.Size(179, 21);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "         Restore Database From ...";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Textcolor = System.Drawing.Color.White;
            this.btnRestore.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // bgwBackup
            // 
            this.bgwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // bgwRestoreDB
            // 
            this.bgwRestoreDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.bgwRestoreDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // lblDataBases
            // 
            this.lblDataBases.AutoSize = true;
            this.lblDataBases.Location = new System.Drawing.Point(4, 5);
            this.lblDataBases.Name = "lblDataBases";
            this.lblDataBases.Size = new System.Drawing.Size(59, 13);
            this.lblDataBases.TabIndex = 4;
            this.lblDataBases.Text = "DataBases";
            // 
            // btnCreate
            // 
            this.btnCreate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.BorderRadius = 0;
            this.btnCreate.ButtonText = "         Create DB";
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.DisabledColor = System.Drawing.Color.Gray;
            this.btnCreate.Iconcolor = System.Drawing.Color.White;
            this.btnCreate.Iconimage = null;
            this.btnCreate.Iconimage_right = null;
            this.btnCreate.Iconimage_right_Selected = null;
            this.btnCreate.Iconimage_Selected = null;
            this.btnCreate.IconMarginLeft = 0;
            this.btnCreate.IconMarginRight = 0;
            this.btnCreate.IconRightVisible = true;
            this.btnCreate.IconRightZoom = 0D;
            this.btnCreate.IconVisible = true;
            this.btnCreate.IconZoom = 90D;
            this.btnCreate.IsTab = false;
            this.btnCreate.Location = new System.Drawing.Point(896, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCreate.selected = false;
            this.btnCreate.Size = new System.Drawing.Size(110, 21);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "         Create DB";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Textcolor = System.Drawing.Color.White;
            this.btnCreate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Click += new System.EventHandler(this.bunifuFlatButton4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblMarquee);
            this.panel1.Controls.Add(this.btnAutoBackup);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.lblDeveloper);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Controls.Add(this.btnRestore);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Location = new System.Drawing.Point(-1, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 469);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.BackColor = System.Drawing.Color.Transparent;
            this.lblMarquee.ForeColor = System.Drawing.Color.Cyan;
            this.lblMarquee.Location = new System.Drawing.Point(3, 445);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(60, 13);
            this.lblMarquee.TabIndex = 23;
            this.lblMarquee.Text = "DUYURU: ";
            // 
            // btnAutoBackup
            // 
            this.btnAutoBackup.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAutoBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAutoBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoBackup.BorderRadius = 0;
            this.btnAutoBackup.ButtonText = "      Auto Backup";
            this.btnAutoBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoBackup.DisabledColor = System.Drawing.Color.Gray;
            this.btnAutoBackup.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAutoBackup.Iconimage = null;
            this.btnAutoBackup.Iconimage_right = null;
            this.btnAutoBackup.Iconimage_right_Selected = null;
            this.btnAutoBackup.Iconimage_Selected = null;
            this.btnAutoBackup.IconMarginLeft = 0;
            this.btnAutoBackup.IconMarginRight = 0;
            this.btnAutoBackup.IconRightVisible = true;
            this.btnAutoBackup.IconRightZoom = 0D;
            this.btnAutoBackup.IconVisible = true;
            this.btnAutoBackup.IconZoom = 90D;
            this.btnAutoBackup.IsTab = false;
            this.btnAutoBackup.Location = new System.Drawing.Point(595, 0);
            this.btnAutoBackup.Name = "btnAutoBackup";
            this.btnAutoBackup.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAutoBackup.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAutoBackup.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAutoBackup.selected = false;
            this.btnAutoBackup.Size = new System.Drawing.Size(110, 21);
            this.btnAutoBackup.TabIndex = 22;
            this.btnAutoBackup.Text = "      Auto Backup";
            this.btnAutoBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoBackup.Textcolor = System.Drawing.Color.White;
            this.btnAutoBackup.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoBackup.Click += new System.EventHandler(this.btnAutoBackup_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(970, 439);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(932, 439);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDeveloper.Location = new System.Drawing.Point(725, 445);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(201, 13);
            this.lblDeveloper.TabIndex = 19;
            this.lblDeveloper.Text = "Application developer: Mustafa GÜRSES";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.treeData);
            this.panel2.Controls.Add(this.lblDataBases);
            this.panel2.Location = new System.Drawing.Point(3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 430);
            this.panel2.TabIndex = 18;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // treeData
            // 
            this.treeData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeData.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeData.Location = new System.Drawing.Point(0, 22);
            this.treeData.Name = "treeData";
            this.treeData.Size = new System.Drawing.Size(189, 408);
            this.treeData.TabIndex = 16;
            this.treeData.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeData_AfterLabelEdit);
            this.treeData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeData_AfterSelect);
            this.treeData.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeData_NodeMouseClick);
            this.treeData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeData_MouseDown_1);
            this.treeData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeData_MouseUp);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.ImageList = this.imageList;
            this.tabControl2.Location = new System.Drawing.Point(194, 201);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(814, 236);
            this.tabControl2.TabIndex = 17;
            this.tabControl2.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 209);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Khaki;
            this.panel3.Controls.Add(this.txtQuery);
            this.panel3.Controls.Add(this.txtDataBase);
            this.panel3.Controls.Add(this.txtConnect);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(3, 183);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 23);
            this.panel3.TabIndex = 9;
            this.panel3.Visible = false;
            // 
            // txtQuery
            // 
            this.txtQuery.BackColor = System.Drawing.Color.Khaki;
            this.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuery.Enabled = false;
            this.txtQuery.Location = new System.Drawing.Point(700, 5);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(100, 13);
            this.txtQuery.TabIndex = 4;
            this.txtQuery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDataBase
            // 
            this.txtDataBase.BackColor = System.Drawing.Color.Khaki;
            this.txtDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataBase.Enabled = false;
            this.txtDataBase.Location = new System.Drawing.Point(589, 5);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(100, 13);
            this.txtDataBase.TabIndex = 3;
            this.txtDataBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtConnect
            // 
            this.txtConnect.BackColor = System.Drawing.Color.Khaki;
            this.txtConnect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConnect.Enabled = false;
            this.txtConnect.Location = new System.Drawing.Point(481, 5);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(100, 13);
            this.txtConnect.TabIndex = 2;
            this.txtConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Query executed successfully";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.Size = new System.Drawing.Size(800, 174);
            this.dataGridView1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 209);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox2.Location = new System.Drawing.Point(6, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(795, 175);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Black;
            this.imageList.Images.SetKeyName(0, "database.ico");
            this.imageList.Images.SetKeyName(1, "__TemplateIcon.ico");
            this.imageList.Images.SetKeyName(2, "columns.png");
            this.imageList.Images.SetKeyName(3, "tık.png");
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.cntxQuery;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.Location = new System.Drawing.Point(195, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(813, 179);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.Visible = false;
            // 
            // cntxQuery
            // 
            this.cntxQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSqlToolStripMenuItem,
            this.openSqlToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.cntxQuery.Name = "contextMenuStrip3";
            this.cntxQuery.Size = new System.Drawing.Size(123, 70);
            // 
            // saveSqlToolStripMenuItem
            // 
            this.saveSqlToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveSqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveSqlToolStripMenuItem.Image")));
            this.saveSqlToolStripMenuItem.Name = "saveSqlToolStripMenuItem";
            this.saveSqlToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveSqlToolStripMenuItem.Text = "Save Sql";
            this.saveSqlToolStripMenuItem.Click += new System.EventHandler(this.saveSqlToolStripMenuItem_Click);
            // 
            // openSqlToolStripMenuItem
            // 
            this.openSqlToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openSqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openSqlToolStripMenuItem.Image")));
            this.openSqlToolStripMenuItem.Name = "openSqlToolStripMenuItem";
            this.openSqlToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openSqlToolStripMenuItem.Text = "Open Sql";
            this.openSqlToolStripMenuItem.Click += new System.EventHandler(this.openSqlToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExecute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExecute.BorderRadius = 0;
            this.btnExecute.ButtonText = "       Execute(F5)";
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecute.DisabledColor = System.Drawing.Color.Gray;
            this.btnExecute.Iconcolor = System.Drawing.Color.White;
            this.btnExecute.Iconimage = null;
            this.btnExecute.Iconimage_right = null;
            this.btnExecute.Iconimage_right_Selected = null;
            this.btnExecute.Iconimage_Selected = null;
            this.btnExecute.IconMarginLeft = 0;
            this.btnExecute.IconMarginRight = 0;
            this.btnExecute.IconRightVisible = true;
            this.btnExecute.IconRightZoom = 0D;
            this.btnExecute.IconVisible = true;
            this.btnExecute.IconZoom = 90D;
            this.btnExecute.IsTab = false;
            this.btnExecute.Location = new System.Drawing.Point(195, 0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExecute.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExecute.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExecute.selected = false;
            this.btnExecute.Size = new System.Drawing.Size(110, 21);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "       Execute(F5)";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Textcolor = System.Drawing.Color.White;
            this.btnExecute.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // cntxTable
            // 
            this.cntxTable.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cntxTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTop200RowsToolStripMenuItem,
            this.getColumnsToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.tRUNCATETABLEToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cntxTable.Name = "contextMenuStrip1";
            this.cntxTable.Size = new System.Drawing.Size(172, 114);
            // 
            // editTop200RowsToolStripMenuItem
            // 
            this.editTop200RowsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.editTop200RowsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editTop200RowsToolStripMenuItem.Image")));
            this.editTop200RowsToolStripMenuItem.Name = "editTop200RowsToolStripMenuItem";
            this.editTop200RowsToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.editTop200RowsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editTop200RowsToolStripMenuItem.Text = "Edit Top 200 Rows";
            this.editTop200RowsToolStripMenuItem.Click += new System.EventHandler(this.editTop200RowsToolStripMenuItem_Click);
            // 
            // getColumnsToolStripMenuItem
            // 
            this.getColumnsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.getColumnsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("getColumnsToolStripMenuItem.Image")));
            this.getColumnsToolStripMenuItem.Name = "getColumnsToolStripMenuItem";
            this.getColumnsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.getColumnsToolStripMenuItem.Text = "Get Columns";
            this.getColumnsToolStripMenuItem.Click += new System.EventHandler(this.getColumnsToolStripMenuItem_Click_1);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.renameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripMenuItem.Image")));
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // tRUNCATETABLEToolStripMenuItem
            // 
            this.tRUNCATETABLEToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tRUNCATETABLEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tRUNCATETABLEToolStripMenuItem.Image")));
            this.tRUNCATETABLEToolStripMenuItem.Name = "tRUNCATETABLEToolStripMenuItem";
            this.tRUNCATETABLEToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.tRUNCATETABLEToolStripMenuItem.Text = "TRUNCATE TABLE";
            this.tRUNCATETABLEToolStripMenuItem.Click += new System.EventHandler(this.tRUNCATETABLEToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cntxKey
            // 
            this.cntxKey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPrimaryKeyToolStripMenuItem,
            this.removePrimaryKeyToolStripMenuItem});
            this.cntxKey.Name = "contextMenuStrip4";
            this.cntxKey.Size = new System.Drawing.Size(184, 48);
            // 
            // setPrimaryKeyToolStripMenuItem
            // 
            this.setPrimaryKeyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.setPrimaryKeyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setPrimaryKeyToolStripMenuItem.Image")));
            this.setPrimaryKeyToolStripMenuItem.Name = "setPrimaryKeyToolStripMenuItem";
            this.setPrimaryKeyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.setPrimaryKeyToolStripMenuItem.Text = "Set Primary Key";
            this.setPrimaryKeyToolStripMenuItem.Click += new System.EventHandler(this.setPrimaryKeyToolStripMenuItem_Click);
            // 
            // removePrimaryKeyToolStripMenuItem
            // 
            this.removePrimaryKeyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.removePrimaryKeyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removePrimaryKeyToolStripMenuItem.Image")));
            this.removePrimaryKeyToolStripMenuItem.Name = "removePrimaryKeyToolStripMenuItem";
            this.removePrimaryKeyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.removePrimaryKeyToolStripMenuItem.Text = "Remove Primary Key";
            this.removePrimaryKeyToolStripMenuItem.Click += new System.EventHandler(this.removePrimaryKeyToolStripMenuItem_Click);
            // 
            // tmrLoging
            // 
            this.tmrLoging.Tick += new System.EventHandler(this.tmrLoging_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.webBrowser1);
            this.panel4.Controls.Add(this.btnConnectRemote);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btnLocalConnect);
            this.panel4.Controls.Add(this.serverList);
            this.panel4.Controls.Add(this.lblConnection);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1012, 33);
            this.panel4.TabIndex = 11;
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(907, 7);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(20, 20);
            this.webBrowser1.TabIndex = 24;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted_1);
            // 
            // btnConnectRemote
            // 
            this.btnConnectRemote.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnectRemote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnectRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnectRemote.BorderRadius = 0;
            this.btnConnectRemote.ButtonText = "    Connect Remote";
            this.btnConnectRemote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnectRemote.DisabledColor = System.Drawing.Color.Gray;
            this.btnConnectRemote.Iconcolor = System.Drawing.Color.White;
            this.btnConnectRemote.Iconimage = null;
            this.btnConnectRemote.Iconimage_right = null;
            this.btnConnectRemote.Iconimage_right_Selected = null;
            this.btnConnectRemote.Iconimage_Selected = null;
            this.btnConnectRemote.IconMarginLeft = 0;
            this.btnConnectRemote.IconMarginRight = 0;
            this.btnConnectRemote.IconRightVisible = true;
            this.btnConnectRemote.IconRightZoom = 0D;
            this.btnConnectRemote.IconVisible = true;
            this.btnConnectRemote.IconZoom = 90D;
            this.btnConnectRemote.IsTab = false;
            this.btnConnectRemote.Location = new System.Drawing.Point(338, 7);
            this.btnConnectRemote.Name = "btnConnectRemote";
            this.btnConnectRemote.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnectRemote.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnectRemote.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConnectRemote.selected = false;
            this.btnConnectRemote.Size = new System.Drawing.Size(122, 21);
            this.btnConnectRemote.TabIndex = 18;
            this.btnConnectRemote.Text = "    Connect Remote";
            this.btnConnectRemote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectRemote.Textcolor = System.Drawing.Color.White;
            this.btnConnectRemote.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectRemote.Click += new System.EventHandler(this.btnConnectRemote_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(554, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Şuanda sharp query açılıyor, yer değiştiremezsiniz.";
            this.label5.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(933, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(971, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(501, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnLocalConnect
            // 
            this.btnLocalConnect.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLocalConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLocalConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocalConnect.BorderRadius = 0;
            this.btnLocalConnect.ButtonText = "       Connection";
            this.btnLocalConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalConnect.DisabledColor = System.Drawing.Color.Gray;
            this.btnLocalConnect.Iconcolor = System.Drawing.Color.White;
            this.btnLocalConnect.Iconimage = null;
            this.btnLocalConnect.Iconimage_right = null;
            this.btnLocalConnect.Iconimage_right_Selected = null;
            this.btnLocalConnect.Iconimage_Selected = null;
            this.btnLocalConnect.IconMarginLeft = 0;
            this.btnLocalConnect.IconMarginRight = 0;
            this.btnLocalConnect.IconRightVisible = true;
            this.btnLocalConnect.IconRightZoom = 0D;
            this.btnLocalConnect.IconVisible = true;
            this.btnLocalConnect.IconZoom = 90D;
            this.btnLocalConnect.IsTab = false;
            this.btnLocalConnect.Location = new System.Drawing.Point(240, 7);
            this.btnLocalConnect.Name = "btnLocalConnect";
            this.btnLocalConnect.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLocalConnect.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLocalConnect.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLocalConnect.selected = false;
            this.btnLocalConnect.Size = new System.Drawing.Size(92, 21);
            this.btnLocalConnect.TabIndex = 13;
            this.btnLocalConnect.Text = "       Connection";
            this.btnLocalConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalConnect.Textcolor = System.Drawing.Color.White;
            this.btnLocalConnect.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalConnect.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // serverList
            // 
            this.serverList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serverList.Items.AddRange(new object[] {
            ".\\SQLEXPRESS"});
            this.serverList.Location = new System.Drawing.Point(57, 7);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(177, 21);
            this.serverList.TabIndex = 12;
            this.serverList.Text = "SELECT CONNECTİON NAME";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConnection.Location = new System.Drawing.Point(3, 12);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(53, 13);
            this.lblConnection.TabIndex = 11;
            this.lblConnection.Text = "Connect :";
            // 
            // cntxQueryCode
            // 
            this.cntxQueryCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectTSM,
            this.ınsertToolStripMenuItem,
            this.deleteToolStripMenuItem1,
            this.updateToolStripMenuItem,
            this.cQueryToolStripMenuItem,
            this.enlargeMeToolStripMenuItem,
            this.minimizeMeToolStripMenuItem});
            this.cntxQueryCode.Name = "contextMenuStrip5";
            this.cntxQueryCode.Size = new System.Drawing.Size(144, 158);
            // 
            // selectTSM
            // 
            this.selectTSM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.selectTSM.Image = ((System.Drawing.Image)(resources.GetObject("selectTSM.Image")));
            this.selectTSM.Name = "selectTSM";
            this.selectTSM.Size = new System.Drawing.Size(143, 22);
            this.selectTSM.Text = "Select->";
            // 
            // ınsertToolStripMenuItem
            // 
            this.ınsertToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ınsertToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ınsertToolStripMenuItem.Image")));
            this.ınsertToolStripMenuItem.Name = "ınsertToolStripMenuItem";
            this.ınsertToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ınsertToolStripMenuItem.Text = "Insert->";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem1.Image")));
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.deleteToolStripMenuItem1.Text = "Delete->";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.updateToolStripMenuItem.Text = "Update->";
            // 
            // cQueryToolStripMenuItem
            // 
            this.cQueryToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cQueryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cQueryToolStripMenuItem.Image")));
            this.cQueryToolStripMenuItem.Name = "cQueryToolStripMenuItem";
            this.cQueryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cQueryToolStripMenuItem.Text = "C# Query";
            this.cQueryToolStripMenuItem.Click += new System.EventHandler(this.cQueryToolStripMenuItem_Click);
            // 
            // enlargeMeToolStripMenuItem
            // 
            this.enlargeMeToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.enlargeMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enlargeMeToolStripMenuItem.Image")));
            this.enlargeMeToolStripMenuItem.Name = "enlargeMeToolStripMenuItem";
            this.enlargeMeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.enlargeMeToolStripMenuItem.Text = "Enlarge me";
            this.enlargeMeToolStripMenuItem.Click += new System.EventHandler(this.enlargeMeToolStripMenuItem_Click);
            // 
            // minimizeMeToolStripMenuItem
            // 
            this.minimizeMeToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.minimizeMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minimizeMeToolStripMenuItem.Image")));
            this.minimizeMeToolStripMenuItem.Name = "minimizeMeToolStripMenuItem";
            this.minimizeMeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.minimizeMeToolStripMenuItem.Text = "Minimize me";
            this.minimizeMeToolStripMenuItem.Click += new System.EventHandler(this.minimizeMeToolStripMenuItem_Click);
            // 
            // bgwApplication
            // 
            this.bgwApplication.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.bgwApplication.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // BgwMarquee
            // 
            this.BgwMarquee.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwMarquee_DoWork);
            this.BgwMarquee.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwMarquee_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(194)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(1010, 499);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sharp Query - Basit veritabanı yönetim aracı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.cntxDataBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.cntxQuery.ResumeLayout(false);
            this.cntxTable.ResumeLayout(false);
            this.cntxKey.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cntxQueryCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cntxDataBase;
        private System.Windows.Forms.ToolStripMenuItem backupDataBaseToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwBackup;
        private System.ComponentModel.BackgroundWorker bgwRestoreDB;
        private System.Windows.Forms.ToolStripMenuItem deleteDataBaseToolStripMenuItem;
        private System.Windows.Forms.Label lblDataBases;
        private ns1.BunifuFlatButton btnCreate;
        private System.Windows.Forms.ToolStripMenuItem newQueryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntxQuery;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTableToolStripMenuItem;
        private ns1.BunifuFlatButton btnExecute;
        private System.Windows.Forms.ContextMenuStrip cntxTable;
        private System.Windows.Forms.ToolStripMenuItem editTop200RowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getColumnsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntxKey;
        private System.Windows.Forms.ToolStripMenuItem setPrimaryKeyToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem tRUNCATETABLEToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox serverList;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ToolStripMenuItem removePrimaryKeyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntxQueryCode;
        private System.Windows.Forms.ToolStripMenuItem selectTSM;
        private System.Windows.Forms.ToolStripMenuItem ınsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripMenuItem cQueryToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem enlargeMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeMeToolStripMenuItem;
        private ns1.BunifuFlatButton btnAutoBackup;
        public System.Windows.Forms.Timer tmrLoging;
        public System.ComponentModel.BackgroundWorker bgwApplication;
        public System.Windows.Forms.TreeView treeData;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public ns1.BunifuFlatButton btnConnectRemote;
        public ns1.BunifuFlatButton btnLocalConnect;
        public ns1.BunifuFlatButton btnRestore;
        public System.Windows.Forms.Label lblMarquee;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.ComponentModel.BackgroundWorker BgwMarquee;
    }
}

