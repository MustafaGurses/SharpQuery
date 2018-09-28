namespace sharpQuery
{
    partial class frmSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSharp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lstControl = new System.Windows.Forms.ListBox();
            this.addParam = new System.Windows.Forms.Button();
            this.lblParam = new System.Windows.Forms.Label();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.lblWhere = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.cmbQuery = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlTable.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblDelete);
            this.panel1.Controls.Add(this.lblDbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 26);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Location = new System.Drawing.Point(22, 6);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(0, 13);
            this.lblDelete.TabIndex = 19;
            this.lblDelete.Visible = false;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(577, 9);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(0, 13);
            this.lblDbName.TabIndex = 18;
            this.lblDbName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(166, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Sharp Query -> C# Query code";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(507, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.AutoScroll = true;
            this.pnlTable.Controls.Add(this.cmbTable);
            this.pnlTable.Location = new System.Drawing.Point(3, 29);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(230, 378);
            this.pnlTable.TabIndex = 1;
            // 
            // cmbTable
            // 
            this.cmbTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTable.Location = new System.Drawing.Point(3, 3);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(137, 21);
            this.cmbTable.TabIndex = 13;
            this.cmbTable.Text = "SELECT TABLE NAME";
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.lstControl);
            this.pnlSettings.Controls.Add(this.addParam);
            this.pnlSettings.Controls.Add(this.lblParam);
            this.pnlSettings.Controls.Add(this.txtParam);
            this.pnlSettings.Controls.Add(this.lblWhere);
            this.pnlSettings.Controls.Add(this.txtWhere);
            this.pnlSettings.Controls.Add(this.cmbQuery);
            this.pnlSettings.Location = new System.Drawing.Point(239, 29);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(240, 378);
            this.pnlSettings.TabIndex = 14;
            // 
            // lstControl
            // 
            this.lstControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstControl.FormattingEnabled = true;
            this.lstControl.Location = new System.Drawing.Point(0, 157);
            this.lstControl.Name = "lstControl";
            this.lstControl.Size = new System.Drawing.Size(240, 221);
            this.lstControl.TabIndex = 27;
            this.lstControl.Visible = false;
            // 
            // addParam
            // 
            this.addParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.addParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addParam.Location = new System.Drawing.Point(199, 126);
            this.addParam.Name = "addParam";
            this.addParam.Size = new System.Drawing.Size(36, 23);
            this.addParam.TabIndex = 26;
            this.addParam.Text = "Add";
            this.addParam.UseVisualStyleBackColor = false;
            this.addParam.Visible = false;
            this.addParam.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblParam
            // 
            this.lblParam.AutoSize = true;
            this.lblParam.BackColor = System.Drawing.Color.Transparent;
            this.lblParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblParam.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblParam.Location = new System.Drawing.Point(3, 70);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(180, 30);
            this.lblParam.TabIndex = 25;
            this.lblParam.Text = "Please enter param name (Ex : \r\n@param1)";
            this.lblParam.Visible = false;
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(6, 103);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(231, 20);
            this.txtParam.TabIndex = 24;
            this.txtParam.Visible = false;
            // 
            // lblWhere
            // 
            this.lblWhere.AutoSize = true;
            this.lblWhere.BackColor = System.Drawing.Color.Transparent;
            this.lblWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWhere.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWhere.Location = new System.Drawing.Point(2, 27);
            this.lblWhere.Name = "lblWhere";
            this.lblWhere.Size = new System.Drawing.Size(181, 15);
            this.lblWhere.TabIndex = 21;
            this.lblWhere.Text = "Write where :(Ex: columnName)\r\n";
            this.lblWhere.Visible = false;
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(5, 45);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(231, 20);
            this.txtWhere.TabIndex = 20;
            this.txtWhere.Visible = false;
            // 
            // cmbQuery
            // 
            this.cmbQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuery.Items.AddRange(new object[] {
            "Insert",
            "Update",
            "Delete",
            "Select"});
            this.cmbQuery.Location = new System.Drawing.Point(3, 3);
            this.cmbQuery.Name = "cmbQuery";
            this.cmbQuery.Size = new System.Drawing.Size(234, 21);
            this.cmbQuery.TabIndex = 13;
            this.cmbQuery.Text = "SELECT QUERY";
            this.cmbQuery.SelectedIndexChanged += new System.EventHandler(this.cmbQuery_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(482, 29);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(61, 22);
            this.btnGo.TabIndex = 18;
            this.btnGo.Text = "Go Code";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(481, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 22);
            this.button2.TabIndex = 19;
            this.button2.Text = "All Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSharp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(543, 409);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSharp";
            this.Text = "Sharp Query -> C# Query code";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTable;
        public System.Windows.Forms.ComboBox cmbTable;
        public System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Panel pnlSettings;
        public System.Windows.Forms.ComboBox cmbQuery;
        private System.Windows.Forms.Label lblWhere;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Button addParam;
        private System.Windows.Forms.Label lblParam;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.ListBox lstControl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Button button2;
    }
}