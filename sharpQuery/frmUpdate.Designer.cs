namespace sharpQuery
{
    partial class frmUpdate
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
            this.pnlUst = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColmn = new System.Windows.Forms.Label();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.txtSet = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlUst.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.Gray;
            this.pnlUst.Controls.Add(this.label5);
            this.pnlUst.Controls.Add(this.lblColumnName);
            this.pnlUst.Controls.Add(this.button1);
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(335, 25);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 19;
            this.label5.Visible = false;
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.BackColor = System.Drawing.Color.Transparent;
            this.lblColumnName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblColumnName.Location = new System.Drawing.Point(12, 6);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(0, 13);
            this.lblColumnName.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(299, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtWhere);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblColmn);
            this.panel1.Controls.Add(this.cmbColumn);
            this.panel1.Controls.Add(this.txtSet);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 191);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(263, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "GO>>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(143, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 20);
            this.dateTimePicker1.TabIndex = 30;
            this.dateTimePicker1.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(186, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Add Where";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(4, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "QUERY :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(2, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(331, 93);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Where :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(146, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Add Value :";
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(66, 47);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(114, 20);
            this.txtWhere.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(108, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "set = ";
            // 
            // lblColmn
            // 
            this.lblColmn.AutoSize = true;
            this.lblColmn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblColmn.Location = new System.Drawing.Point(4, 3);
            this.lblColmn.Name = "lblColmn";
            this.lblColmn.Size = new System.Drawing.Size(78, 13);
            this.lblColmn.TabIndex = 22;
            this.lblColmn.Text = "Select Column:";
            // 
            // cmbColumn
            // 
            this.cmbColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbColumn.Location = new System.Drawing.Point(3, 20);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(99, 21);
            this.cmbColumn.TabIndex = 21;
            this.cmbColumn.SelectedIndexChanged += new System.EventHandler(this.cmbColumn_SelectedIndexChanged);
            // 
            // txtSet
            // 
            this.txtSet.Location = new System.Drawing.Point(143, 19);
            this.txtSet.Name = "txtSet";
            this.txtSet.Size = new System.Drawing.Size(114, 20);
            this.txtSet.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(263, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Add Query";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 215);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.Text = "Sharp Query - Update Column";
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cmbColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblColmn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSet;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button3;
    }
}