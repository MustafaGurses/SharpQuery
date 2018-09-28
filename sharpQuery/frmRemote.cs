using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace sharpQuery
{
    public partial class frmRemote : Form
    {
        public frmRemote()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            CheckForIllegalCrossThreadCalls = false;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public string metin { get; set; }
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmMain frm;
        csTransactions CT = new csTransactions();
        public int i { get; set; }
        public bool GetDataBase()
        {
            frm.treeData.Nodes.Clear();
            try
            {
                CT.RemoteDBName();
                if (CT.ControlDB == true)
                {
                    foreach (string Name in CT.DataBases)
                    {
                        frm.treeData.Nodes.Add(Name, Name, 0);
                    }
                    foreach (TreeNode Node in frm.treeData.Nodes)
                    {
                        string DataBaseName = Node.Text;
                        CT.con.Close();
                        CT.con.ConnectionString = csTransactions.RemoteConnectString_Tables(DataBaseName);
                        foreach (DataRow Row in CT.GetRemoteTables().Rows)
                        {
                            string tablename = (string)Row[2];
                            frm.treeData.Nodes[i].Nodes.Add(tablename, tablename, 1);
                        }
                        i++;
                        CT.con.Close();
                    }
                    i = 0;
                }
                if(CT.DataBases == null) { return false; }
                return true;
            }
            catch (Exception ex) { this.label5.Text = ""; btnConnection.Text = "                    Retry Connection"; i = 0; MessageBox.Show("Error: "+ ex.Message,"Error Connection",MessageBoxButtons.OK,MessageBoxIcon.Error); return false; }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != null && txtUser.Text != null && txtPw.Text != null)
            {
                csTransactions.ServerItems.DataSource = txtServer.Text;
                csTransactions.ServerItems.UserID = txtUser.Text;
                csTransactions.ServerItems.UserPW = txtPw.Text;
                try
                {
                    if (GetDataBase() == true && frm.Height == 33 && CT.ControlDB == true)
                    {
                        frm.panel1.Visible = true;
                        frm.serverList.Enabled = false;
                        frm.pictureBox1.Visible = true;
                        this.label5.Visible = true;
                        this.label5.Text = "Connecting...";
                        frm.btnConnectRemote.Enabled = false;
                        frm.btnLocalConnect.Enabled = false;
                        frm.btnRestore.Enabled = false;
                        frm.tmrLoging.Start();
                        csTransactions.ServerItems.ConnectName = "Remote";
                        btnConnection.Text = "                           Connect";
                        this.label5.Text = "Remote SQL Connected!";
                    }
                    csTransactions.ServerItems.ConnectName="Remote";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: "+ex.Message,"Error Remote Connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnConnection.Text = "                    Retry Connection";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm.btnConnectRemote.Enabled = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frmRemote_Load(object sender, EventArgs e)
        {
            txtPw.isPassword = true;
        }
    }
}
