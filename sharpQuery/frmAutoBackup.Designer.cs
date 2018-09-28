namespace sharpQuery
{
    partial class frmAutoBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoBackup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataBaseFromMinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSupport = new System.Windows.Forms.Label();
            this.changeCheck = new ns1.BunifuCheckbox();
            this.gbYear = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.dupYear = new System.Windows.Forms.DomainUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.gbMonth = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.dupMonth = new System.Windows.Forms.DomainUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.gbDay = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dupDay = new System.Windows.Forms.DomainUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.gbHour = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dupHour = new System.Windows.Forms.DomainUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.gbMinute = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dupMinute = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSettings = new System.Windows.Forms.ComboBox();
            this.tmrControl = new System.Windows.Forms.Timer(this.components);
            this.bgwControlDate = new System.ComponentModel.BackgroundWorker();
            this.tmrReadDB = new System.Windows.Forms.Timer(this.components);
            this.lbDataBase = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gbYear.SuspendLayout();
            this.gbMonth.SuspendLayout();
            this.gbDay.SuspendLayout();
            this.gbHour.SuspendLayout();
            this.gbMinute.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 26);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "AUTO BACKUP | SHARP QUERY";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(688, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(726, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBase :";
            // 
            // lblRemTime
            // 
            this.lblRemTime.AutoSize = true;
            this.lblRemTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRemTime.Location = new System.Drawing.Point(121, 53);
            this.lblRemTime.Name = "lblRemTime";
            this.lblRemTime.Size = new System.Drawing.Size(0, 13);
            this.lblRemTime.TabIndex = 4;
            this.lblRemTime.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Remaining Time :";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtbLog.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rtbLog.Location = new System.Drawing.Point(551, 54);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(203, 286);
            this.rtbLog.TabIndex = 5;
            this.rtbLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(549, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "LOG :";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(677, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 24);
            this.button3.TabIndex = 20;
            this.button3.Text = "Clear Log";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.lblSupport);
            this.groupBox1.Controls.Add(this.changeCheck);
            this.groupBox1.Controls.Add(this.gbYear);
            this.groupBox1.Controls.Add(this.gbMonth);
            this.groupBox1.Controls.Add(this.gbDay);
            this.groupBox1.Controls.Add(this.gbHour);
            this.groupBox1.Controls.Add(this.gbMinute);
            this.groupBox1.Controls.Add(this.cmbSettings);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(0, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 261);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "      Settings      ";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(417, 43);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 210);
            this.checkedListBox1.TabIndex = 20;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataBaseFromMinuteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // addDataBaseFromMinuteToolStripMenuItem
            // 
            this.addDataBaseFromMinuteToolStripMenuItem.AutoToolTip = true;
            this.addDataBaseFromMinuteToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addDataBaseFromMinuteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minuteToolStripMenuItem,
            this.hourToolStripMenuItem,
            this.dayToolStripMenuItem,
            this.monthToolStripMenuItem,
            this.yearToolStripMenuItem});
            this.addDataBaseFromMinuteToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.addDataBaseFromMinuteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addDataBaseFromMinuteToolStripMenuItem.Image")));
            this.addDataBaseFromMinuteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.addDataBaseFromMinuteToolStripMenuItem.Name = "addDataBaseFromMinuteToolStripMenuItem";
            this.addDataBaseFromMinuteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addDataBaseFromMinuteToolStripMenuItem.Text = "Save DataBases";
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.minuteToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.minuteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minuteToolStripMenuItem.Image")));
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.minuteToolStripMenuItem.Text = "Minute";
            this.minuteToolStripMenuItem.Click += new System.EventHandler(this.minuteToolStripMenuItem_Click);
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.hourToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hourToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hourToolStripMenuItem.Image")));
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.hourToolStripMenuItem.Text = "Hour";
            this.hourToolStripMenuItem.Click += new System.EventHandler(this.hourToolStripMenuItem_Click);
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dayToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dayToolStripMenuItem.Image")));
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.dayToolStripMenuItem.Text = "Day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.monthToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("monthToolStripMenuItem.Image")));
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.monthToolStripMenuItem.Text = "Month";
            this.monthToolStripMenuItem.Click += new System.EventHandler(this.monthToolStripMenuItem_Click);
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.yearToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.yearToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("yearToolStripMenuItem.Image")));
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.yearToolStripMenuItem.Text = "Year";
            this.yearToolStripMenuItem.Click += new System.EventHandler(this.yearToolStripMenuItem_Click);
            // 
            // lblSupport
            // 
            this.lblSupport.AutoSize = true;
            this.lblSupport.Location = new System.Drawing.Point(141, 15);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(150, 26);
            this.lblSupport.TabIndex = 19;
            this.lblSupport.Text = "Remaining time view: date \r\nNot support : Minute and Hour";
            this.lblSupport.Click += new System.EventHandler(this.label15_Click);
            // 
            // changeCheck
            // 
            this.changeCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.changeCheck.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.changeCheck.Checked = false;
            this.changeCheck.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.changeCheck.ForeColor = System.Drawing.Color.White;
            this.changeCheck.Location = new System.Drawing.Point(117, 20);
            this.changeCheck.Name = "changeCheck";
            this.changeCheck.Size = new System.Drawing.Size(20, 20);
            this.changeCheck.TabIndex = 18;
            // 
            // gbYear
            // 
            this.gbYear.Controls.Add(this.label14);
            this.gbYear.Controls.Add(this.button8);
            this.gbYear.Controls.Add(this.dupYear);
            this.gbYear.Controls.Add(this.label9);
            this.gbYear.Enabled = false;
            this.gbYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbYear.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbYear.Location = new System.Drawing.Point(144, 151);
            this.gbYear.Name = "gbYear";
            this.gbYear.Size = new System.Drawing.Size(131, 100);
            this.gbYear.TabIndex = 17;
            this.gbYear.TabStop = false;
            this.gbYear.Text = "Year";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 26);
            this.label14.TabIndex = 23;
            this.label14.Text = "Process start is \r\ncurrent year.";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(70, 66);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 23);
            this.button8.TabIndex = 22;
            this.button8.Text = "GO>>";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dupYear
            // 
            this.dupYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dupYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dupYear.ForeColor = System.Drawing.SystemColors.Info;
            this.dupYear.Items.Add("1");
            this.dupYear.Items.Add("2");
            this.dupYear.Items.Add("3");
            this.dupYear.Items.Add("4");
            this.dupYear.Items.Add("5");
            this.dupYear.Location = new System.Drawing.Point(82, 11);
            this.dupYear.Name = "dupYear";
            this.dupYear.ReadOnly = true;
            this.dupYear.Size = new System.Drawing.Size(41, 20);
            this.dupYear.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Select Year";
            // 
            // gbMonth
            // 
            this.gbMonth.Controls.Add(this.label13);
            this.gbMonth.Controls.Add(this.button7);
            this.gbMonth.Controls.Add(this.dupMonth);
            this.gbMonth.Controls.Add(this.label8);
            this.gbMonth.Enabled = false;
            this.gbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbMonth.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbMonth.Location = new System.Drawing.Point(7, 150);
            this.gbMonth.Name = "gbMonth";
            this.gbMonth.Size = new System.Drawing.Size(131, 100);
            this.gbMonth.TabIndex = 16;
            this.gbMonth.TabStop = false;
            this.gbMonth.Text = "Month";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 26);
            this.label13.TabIndex = 23;
            this.label13.Text = "Process start is \r\ncurrent month.";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(70, 66);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 23);
            this.button7.TabIndex = 22;
            this.button7.Text = "GO>>";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dupMonth
            // 
            this.dupMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dupMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dupMonth.ForeColor = System.Drawing.SystemColors.Info;
            this.dupMonth.Items.Add("1");
            this.dupMonth.Items.Add("2");
            this.dupMonth.Items.Add("3");
            this.dupMonth.Items.Add("4");
            this.dupMonth.Items.Add("5");
            this.dupMonth.Items.Add("6");
            this.dupMonth.Items.Add("7");
            this.dupMonth.Items.Add("8");
            this.dupMonth.Items.Add("9");
            this.dupMonth.Items.Add("10");
            this.dupMonth.Items.Add("11");
            this.dupMonth.Items.Add("12");
            this.dupMonth.Location = new System.Drawing.Point(82, 11);
            this.dupMonth.Name = "dupMonth";
            this.dupMonth.ReadOnly = true;
            this.dupMonth.Size = new System.Drawing.Size(41, 20);
            this.dupMonth.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Select Month";
            // 
            // gbDay
            // 
            this.gbDay.Controls.Add(this.label12);
            this.gbDay.Controls.Add(this.button6);
            this.gbDay.Controls.Add(this.dupDay);
            this.gbDay.Controls.Add(this.label7);
            this.gbDay.Enabled = false;
            this.gbDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbDay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbDay.Location = new System.Drawing.Point(281, 45);
            this.gbDay.Name = "gbDay";
            this.gbDay.Size = new System.Drawing.Size(131, 100);
            this.gbDay.TabIndex = 16;
            this.gbDay.TabStop = false;
            this.gbDay.Text = "Day";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 26);
            this.label12.TabIndex = 23;
            this.label12.Text = "Process start is \r\ncurrent day.";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(70, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "GO>>";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dupDay
            // 
            this.dupDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dupDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dupDay.ForeColor = System.Drawing.SystemColors.Info;
            this.dupDay.Items.Add("1");
            this.dupDay.Items.Add("2");
            this.dupDay.Items.Add("3");
            this.dupDay.Items.Add("4");
            this.dupDay.Items.Add("5");
            this.dupDay.Items.Add("6");
            this.dupDay.Items.Add("7");
            this.dupDay.Items.Add("8");
            this.dupDay.Items.Add("9");
            this.dupDay.Items.Add("10");
            this.dupDay.Items.Add("11");
            this.dupDay.Items.Add("12");
            this.dupDay.Items.Add("13");
            this.dupDay.Items.Add("14");
            this.dupDay.Items.Add("15");
            this.dupDay.Items.Add("16");
            this.dupDay.Items.Add("17");
            this.dupDay.Items.Add("18");
            this.dupDay.Items.Add("19");
            this.dupDay.Items.Add("20");
            this.dupDay.Items.Add("21");
            this.dupDay.Items.Add("22");
            this.dupDay.Items.Add("23");
            this.dupDay.Items.Add("24");
            this.dupDay.Items.Add("25");
            this.dupDay.Items.Add("26");
            this.dupDay.Items.Add("27");
            this.dupDay.Items.Add("28");
            this.dupDay.Items.Add("29");
            this.dupDay.Items.Add("30");
            this.dupDay.Location = new System.Drawing.Point(82, 11);
            this.dupDay.Name = "dupDay";
            this.dupDay.ReadOnly = true;
            this.dupDay.Size = new System.Drawing.Size(41, 20);
            this.dupDay.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Select Day";
            // 
            // gbHour
            // 
            this.gbHour.Controls.Add(this.label11);
            this.gbHour.Controls.Add(this.button5);
            this.gbHour.Controls.Add(this.dupHour);
            this.gbHour.Controls.Add(this.label6);
            this.gbHour.Enabled = false;
            this.gbHour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbHour.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbHour.Location = new System.Drawing.Point(144, 45);
            this.gbHour.Name = "gbHour";
            this.gbHour.Size = new System.Drawing.Size(131, 100);
            this.gbHour.TabIndex = 15;
            this.gbHour.TabStop = false;
            this.gbHour.Text = "Hour";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 26);
            this.label11.TabIndex = 23;
            this.label11.Text = "Process start is \r\ncurrent hour.";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(70, 66);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "GO>>";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dupHour
            // 
            this.dupHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dupHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dupHour.ForeColor = System.Drawing.SystemColors.Info;
            this.dupHour.Items.Add("1");
            this.dupHour.Items.Add("2");
            this.dupHour.Items.Add("3");
            this.dupHour.Items.Add("4");
            this.dupHour.Items.Add("5");
            this.dupHour.Items.Add("6");
            this.dupHour.Items.Add("7");
            this.dupHour.Items.Add("8");
            this.dupHour.Items.Add("9");
            this.dupHour.Items.Add("10");
            this.dupHour.Items.Add("11");
            this.dupHour.Items.Add("12");
            this.dupHour.Items.Add("13");
            this.dupHour.Items.Add("14");
            this.dupHour.Items.Add("15");
            this.dupHour.Items.Add("16");
            this.dupHour.Items.Add("17");
            this.dupHour.Items.Add("18");
            this.dupHour.Items.Add("19");
            this.dupHour.Items.Add("20");
            this.dupHour.Items.Add("21");
            this.dupHour.Items.Add("22");
            this.dupHour.Items.Add("23");
            this.dupHour.Items.Add("24");
            this.dupHour.Location = new System.Drawing.Point(82, 11);
            this.dupHour.Name = "dupHour";
            this.dupHour.ReadOnly = true;
            this.dupHour.Size = new System.Drawing.Size(41, 20);
            this.dupHour.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Select Hour";
            // 
            // gbMinute
            // 
            this.gbMinute.Controls.Add(this.label10);
            this.gbMinute.Controls.Add(this.button4);
            this.gbMinute.Controls.Add(this.dupMinute);
            this.gbMinute.Controls.Add(this.label5);
            this.gbMinute.Enabled = false;
            this.gbMinute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbMinute.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbMinute.Location = new System.Drawing.Point(7, 44);
            this.gbMinute.Name = "gbMinute";
            this.gbMinute.Size = new System.Drawing.Size(131, 100);
            this.gbMinute.TabIndex = 14;
            this.gbMinute.TabStop = false;
            this.gbMinute.Text = "Minute";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 26);
            this.label10.TabIndex = 20;
            this.label10.Text = "Process start is \r\ncurrent minute.";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(72, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "GO>>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dupMinute
            // 
            this.dupMinute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dupMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dupMinute.ForeColor = System.Drawing.SystemColors.Info;
            this.dupMinute.Items.Add("1");
            this.dupMinute.Items.Add("2");
            this.dupMinute.Items.Add("3");
            this.dupMinute.Items.Add("4");
            this.dupMinute.Items.Add("5");
            this.dupMinute.Items.Add("6");
            this.dupMinute.Items.Add("7");
            this.dupMinute.Items.Add("8");
            this.dupMinute.Items.Add("9");
            this.dupMinute.Items.Add("10");
            this.dupMinute.Items.Add("11");
            this.dupMinute.Items.Add("12");
            this.dupMinute.Items.Add("13");
            this.dupMinute.Items.Add("14");
            this.dupMinute.Items.Add("15");
            this.dupMinute.Items.Add("16");
            this.dupMinute.Items.Add("17");
            this.dupMinute.Items.Add("18");
            this.dupMinute.Items.Add("19");
            this.dupMinute.Items.Add("20");
            this.dupMinute.Items.Add("21");
            this.dupMinute.Items.Add("22");
            this.dupMinute.Items.Add("23");
            this.dupMinute.Items.Add("24");
            this.dupMinute.Items.Add("25");
            this.dupMinute.Items.Add("26");
            this.dupMinute.Items.Add("27");
            this.dupMinute.Items.Add("28");
            this.dupMinute.Items.Add("29");
            this.dupMinute.Items.Add("30");
            this.dupMinute.Items.Add("31");
            this.dupMinute.Items.Add("32");
            this.dupMinute.Items.Add("33");
            this.dupMinute.Items.Add("34");
            this.dupMinute.Items.Add("35");
            this.dupMinute.Items.Add("36");
            this.dupMinute.Items.Add("37");
            this.dupMinute.Items.Add("38");
            this.dupMinute.Items.Add("39");
            this.dupMinute.Items.Add("40");
            this.dupMinute.Items.Add("41");
            this.dupMinute.Items.Add("42");
            this.dupMinute.Items.Add("43");
            this.dupMinute.Items.Add("44");
            this.dupMinute.Items.Add("45");
            this.dupMinute.Items.Add("46");
            this.dupMinute.Items.Add("47");
            this.dupMinute.Items.Add("48");
            this.dupMinute.Items.Add("49");
            this.dupMinute.Items.Add("50");
            this.dupMinute.Items.Add("51");
            this.dupMinute.Items.Add("52");
            this.dupMinute.Items.Add("53");
            this.dupMinute.Items.Add("54");
            this.dupMinute.Items.Add("55");
            this.dupMinute.Items.Add("56");
            this.dupMinute.Items.Add("57");
            this.dupMinute.Items.Add("58");
            this.dupMinute.Items.Add("59");
            this.dupMinute.Items.Add("60");
            this.dupMinute.Location = new System.Drawing.Point(84, 16);
            this.dupMinute.Name = "dupMinute";
            this.dupMinute.ReadOnly = true;
            this.dupMinute.Size = new System.Drawing.Size(41, 20);
            this.dupMinute.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Minute";
            // 
            // cmbSettings
            // 
            this.cmbSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettings.Items.AddRange(new object[] {
            "Minute",
            "Hour",
            "Day",
            "Month",
            "Year"});
            this.cmbSettings.Location = new System.Drawing.Point(6, 19);
            this.cmbSettings.Name = "cmbSettings";
            this.cmbSettings.Size = new System.Drawing.Size(103, 21);
            this.cmbSettings.TabIndex = 13;
            this.cmbSettings.Text = "SELECT";
            this.cmbSettings.SelectedIndexChanged += new System.EventHandler(this.serverList_SelectedIndexChanged);
            // 
            // tmrControl
            // 
            this.tmrControl.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bgwControlDate
            // 
            this.bgwControlDate.WorkerSupportsCancellation = true;
            this.bgwControlDate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // tmrReadDB
            // 
            this.tmrReadDB.Interval = 1000;
            this.tmrReadDB.Tick += new System.EventHandler(this.tmrReadDB_Tick);
            // 
            // lbDataBase
            // 
            this.lbDataBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.lbDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDataBase.ForeColor = System.Drawing.Color.White;
            this.lbDataBase.Location = new System.Drawing.Point(76, 28);
            this.lbDataBase.Name = "lbDataBase";
            this.lbDataBase.ReadOnly = true;
            this.lbDataBase.Size = new System.Drawing.Size(461, 20);
            this.lbDataBase.TabIndex = 22;
            // 
            // frmAutoBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(758, 344);
            this.Controls.Add(this.lbDataBase);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.lblRemTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoBackup";
            this.Text = "DataBase Auto Backup | Sharp Query";
            this.Load += new System.EventHandler(this.frmAutoBackup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbYear.ResumeLayout(false);
            this.gbYear.PerformLayout();
            this.gbMonth.ResumeLayout(false);
            this.gbMonth.PerformLayout();
            this.gbDay.ResumeLayout(false);
            this.gbDay.PerformLayout();
            this.gbHour.ResumeLayout(false);
            this.gbHour.PerformLayout();
            this.gbMinute.ResumeLayout(false);
            this.gbMinute.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cmbSettings;
        private System.Windows.Forms.GroupBox gbDay;
        private System.Windows.Forms.GroupBox gbHour;
        private System.Windows.Forms.GroupBox gbMinute;
        private System.Windows.Forms.GroupBox gbYear;
        private System.Windows.Forms.GroupBox gbMonth;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DomainUpDown dupYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DomainUpDown dupMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DomainUpDown dupDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DomainUpDown dupHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DomainUpDown dupMinute;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblRemTime;
        private System.Windows.Forms.Timer tmrControl;
        private System.ComponentModel.BackgroundWorker bgwControlDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSupport;
        private ns1.BunifuCheckbox changeCheck;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDataBaseFromMinuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem;
        public System.Windows.Forms.Timer tmrReadDB;
        public System.Windows.Forms.TextBox lbDataBase;
    }
}