namespace sharpQuery
{
    partial class frmRemote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemote));
            this.txtServer = new ns1.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new ns1.BunifuMaterialTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnection = new ns1.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPw = new ns1.BunifuMaterialTextbox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServer.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtServer.ForeColor = System.Drawing.Color.White;
            this.txtServer.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtServer.HintText = "Server";
            this.txtServer.isPassword = false;
            this.txtServer.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtServer.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtServer.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtServer.LineThickness = 3;
            this.txtServer.Location = new System.Drawing.Point(43, 82);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(211, 29);
            this.txtServer.TabIndex = 50;
            this.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(40, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 52;
            this.label1.Text = "Sql server ip adress.\r\n(Ex: 190.xxx.xxx.xxx\\Server Name)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(40, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "User ID :";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUser.HintText = "User";
            this.txtUser.isPassword = false;
            this.txtUser.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtUser.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtUser.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtUser.LineThickness = 3;
            this.txtUser.Location = new System.Drawing.Point(43, 166);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(211, 29);
            this.txtUser.TabIndex = 53;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(40, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "User Password :";
            // 
            // btnConnection
            // 
            this.btnConnection.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnection.BorderRadius = 0;
            this.btnConnection.ButtonText = "                           Connect";
            this.btnConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnection.DisabledColor = System.Drawing.Color.Gray;
            this.btnConnection.Iconcolor = System.Drawing.Color.White;
            this.btnConnection.Iconimage = null;
            this.btnConnection.Iconimage_right = null;
            this.btnConnection.Iconimage_right_Selected = null;
            this.btnConnection.Iconimage_Selected = null;
            this.btnConnection.IconMarginLeft = 0;
            this.btnConnection.IconMarginRight = 0;
            this.btnConnection.IconRightVisible = true;
            this.btnConnection.IconRightZoom = 0D;
            this.btnConnection.IconVisible = true;
            this.btnConnection.IconZoom = 90D;
            this.btnConnection.IsTab = false;
            this.btnConnection.Location = new System.Drawing.Point(43, 306);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnection.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConnection.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConnection.selected = false;
            this.btnConnection.Size = new System.Drawing.Size(211, 34);
            this.btnConnection.TabIndex = 55;
            this.btnConnection.Text = "                           Connect";
            this.btnConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnection.Textcolor = System.Drawing.Color.White;
            this.btnConnection.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 33);
            this.panel1.TabIndex = 56;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 21);
            this.label2.TabIndex = 53;
            this.label2.Text = "Remote Connection";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(266, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(43, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 21);
            this.label5.TabIndex = 54;
            this.label5.Text = "Remote SQL Connected!";
            this.label5.Visible = false;
            // 
            // txtPw
            // 
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPw.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPw.ForeColor = System.Drawing.Color.White;
            this.txtPw.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPw.HintText = "Password";
            this.txtPw.isPassword = true;
            this.txtPw.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtPw.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtPw.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.txtPw.LineThickness = 3;
            this.txtPw.Location = new System.Drawing.Point(43, 255);
            this.txtPw.Margin = new System.Windows.Forms.Padding(4);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(211, 29);
            this.txtPw.TabIndex = 53;
            this.txtPw.Text = "Password";
            this.txtPw.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // frmRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(304, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRemote";
            this.Text = "SharpQuery Remote Connect MSSQL Server";
            this.Load += new System.EventHandler(this.frmRemote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public ns1.BunifuMaterialTextbox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public ns1.BunifuMaterialTextbox txtUser;
        private System.Windows.Forms.Label label4;
        private ns1.BunifuFlatButton btnConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        public ns1.BunifuMaterialTextbox txtPw;
    }
}