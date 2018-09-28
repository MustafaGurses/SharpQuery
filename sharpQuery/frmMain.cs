using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using FastColoredTextBoxNS;
using System.Net.NetworkInformation;

namespace sharpQuery
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            CheckForIllegalCrossThreadCalls = false;
            ToolStripMenuItem selectQuery = (cntxQueryCode.Items[0] as ToolStripMenuItem);
            ToolStripMenuItem insertQuery = (cntxQueryCode.Items[1] as ToolStripMenuItem);
            ToolStripMenuItem deleteQuery = (cntxQueryCode.Items[2] as ToolStripMenuItem);
            ToolStripMenuItem updateQuery = (cntxQueryCode.Items[3] as ToolStripMenuItem);
            selectQuery.DropDownItemClicked += SelectQuery_DropDownItemClicked;
            insertQuery.DropDownItemClicked += InsertQuery_DropDownItemClicked;
            deleteQuery.DropDownItemClicked += DeleteQuery_DropDownItemClicked;
            updateQuery.DropDownItemClicked += UpdateQuery_DropDownItemClicked;
            csDataBase.connection.InfoMessage += new SqlInfoMessageEventHandler(Connection_InfoMessage);
            treeData.ImageList = imageList;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ayar.ini"))
            {
                INIKaydet ini = new INIKaydet(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ayar.ini");
                dil = ini.Oku("Dil", "Ayarlanmış Dil");
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Trap WM_ACTIVATE when we get active
            if (m.Msg == 6 && m.WParam.ToInt32() == 1)
            {
                if (Control.FromHandle(m.LParam) == null)
                {
                    remote.WindowState = FormWindowState.Normal;
                }
            }
        }
        //variables, classes, forms here
        #region
        frmRemote remote = new frmRemote();
        frmSharp sharp = new frmSharp();
        frmUpdate up = new frmUpdate();
        csTransactions.CsDeleteTable CDT = new csTransactions.CsDeleteTable();
        csTransactions.CsRestoreDb CRDB = new csTransactions.CsRestoreDb();
        csTransactions.CsNewBackup CNB = new csTransactions.CsNewBackup();
        csTransactions CSC = new csTransactions();
        DataTable table = new DataTable();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        frmAutoBackup Auto = new frmAutoBackup();
        private int xPos;
        private int yPos;
        string fileName;
        string dosyaLink;
        string nodeName;
        int indexNumber;
        string childNode_name;
        int childNode_number;
        int j = 0;
        int primaryIndex;
        int count;
        private TreeNode mySelectedNode;
        private string beforeLabel;
        public static string dil { get; set; }
        public string createDB { get; set; }
        public int length { get; set; }
        public int itemLength { get; set; }
        public string insertCommand { get; set; }
        public int i { get; set; }
        public bool controlTab_Page = false;
        public string newTable { get; set; }
        public string edit { get; set; }
        private const int GWL_STYLE = -16;
        private const int WS_VSCROLL = 0x00200000;
        private const int WS_HSCROLL = 0x00100000;
        #endregion
        [DllImport("user32.dll", ExactSpelling = false, CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		
                        ReleaseCapture();
                        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public class INIKaydet
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIKaydet(string dosyaYolu)
            {
                DOSYAYOLU = dosyaYolu;
            }
            private string DOSYAYOLU = String.Empty;
            public string Varsayilan { get; set; }
            public string Oku(string bolum, string ayaradi)
            {
                Varsayilan = Varsayilan ?? string.Empty;
                StringBuilder StrBuild = new StringBuilder(256);
                GetPrivateProfileString(bolum, ayaradi, Varsayilan, StrBuild, 255, DOSYAYOLU);
                return StrBuild.ToString();
            }
            public long Yaz(string bolum, string ayaradi, string deger)
            {
                return WritePrivateProfileString(bolum, ayaradi, deger, DOSYAYOLU);
            }
        }

        public bool connect()
        {
            treeData.Nodes.Clear();
            try
            {
                if (serverList.SelectedItem == null) { return false; }
                csTransactions.ServerItems.svName = serverList.Text.ToString();
                foreach (string db_Name in CSC.GetDbName())
                {
                    treeData.Nodes.Add(db_Name, db_Name, 0);
                }
                foreach (TreeNode name in treeData.Nodes)
                {
                    string dbName = name.Text.ToString();
                    csTransactions.ServerItems.dbName = dbName;
                    CSC.connection.Close();
                    CSC.connection.ConnectionString = @"Data Source=" + csTransactions.ServerItems.svName + ";" + "Initial Catalog=" + csTransactions.ServerItems.dbName + "; Integrated Security=True;Trusted_Connection=True;";
                    foreach (DataRow row in CSC.GetTables().Rows)
                    {
                        string tablename = (string)row[2];
                        treeData.Nodes[i].Nodes.Add(tablename, tablename, 1);
                    }
                    CSC.connection.Close();
                    i++;
                }
                csTransactions.ServerItems.dbName = null;
                i = 0;
                treeData.AfterExpand += (s, ea) =>
                {
                    int style = GetWindowLong(treeData.Handle, GWL_STYLE);
                    while ((style & WS_HSCROLL) != 0)
                    {
                        treeData.Width++;
                        style = GetWindowLong(treeData.Handle, GWL_STYLE);
                    }
                };
                return true;
            }
            catch(Exception ex)
            {
                if (dil == "English")
                {
                    MessageBox.Show("Error connection!"+ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dil == "Turkish")
                {
                    MessageBox.Show("Bağlantı sırasında hata."+ex.Message,"Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            csTransactions.ServerItems.svName = serverList.Text.ToString();
            if (connect() == true && this.Height == 33)
            {
                pictureBox1.Visible = true;
                panel1.Visible = true;
                serverList.Enabled = false;
                this.tmrLoging.Start();
            }
            csTransactions.ServerItems.ConnectName = "Local";
        }
        public string SettingsTime { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (dil == "Turkish")
                {
                    this.Text = "SharpQuery basit veritabanı yönetim aracı";
                }
                if(dil == "English")
                {
                    this.Text = "SharpQuery Simple and easy";
                }
                webBrowser1.AllowNavigation = true;
                if (dil == "Turkish")
                {
                    lblMarquee.Text = "DUYURU: ";
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/turkce.html");
                    webBrowser1.Url = new Uri("http://www.mustafagurses.epizy.com/turkce.html");
                }
                if (dil == "English")
                {
                    lblMarquee.Text = "NOTICE: ";
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/english.html");
                    webBrowser1.Url = new Uri("http://www.mustafagurses.epizy.com/english.html");
                }
                remote.txtPw.isPassword = true;
                remote.frm = this;
                remote.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                remote.Location = new Point(this.Left + this.Width, this.Top);
                remote.Show();
                this.Height = 33;
                foreach (string str in CSC.GetIstanceName_ServerName())
                {
                    serverList.Items.Add(str);
                }
                INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
                SettingsTime = AutoSettings.Oku("Auto", "Auto Settings");
                switch (SettingsTime)
                {
                    case "Minute":
                        MinuteBackup.Current.BackupMinute();
                        csTransactions.ServerItems.AutoBackupObjectName = "Minute";
                        break;
                    case "Hour":
                        HourBackup.Current.BackupHourStart();
                        csTransactions.ServerItems.AutoBackupObjectName = "Hour";
                        break;
                    case "Day":
                        DayBackup.Current.BackupDayStart();
                        csTransactions.ServerItems.AutoBackupObjectName = "Day";
                        break;
                    case "Month":
                        MonthBackup.Current.BackupMonthStart();
                        csTransactions.ServerItems.AutoBackupObjectName = "Month";
                        break;
                    case "Year":
                        YearBackup.Current.BackupYearStart();
                        csTransactions.ServerItems.AutoBackupObjectName = "Year";
                        break;
                    default:
                        Auto.lblRemTime.Text = "Ayarlanmamış.";
                        Auto.lbDataBase.Text = "Ayarlanmamış.";
                        break;
                }
            }
            catch { }
        }

        public void tablola()
        {
            try
            {
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    CSC.connection.Close();
                    CSC.connection.ConnectionString = @"Data Source = " + csTransactions.ServerItems.svName + "; " + "Initial Catalog = " + nodeName + "; " + "Integrated Security = True; ";
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CSC.connection.Close();
                    CSC.connection.ConnectionString = csTransactions.RemoteConnectString_Tables(nodeName);
                }
                CSC.ChildNodeName = childNode_name;
                using (var dr = CSC.GetColumns().ExecuteReader())
                {
                    var columns = new List<string>();

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        columns.Add(dr.GetName(i) + "(" + dr.GetDataTypeName(i) + ")");
                    }
                    foreach (string delete in columns)
                    {
                        treeData.Nodes[indexNumber].Nodes[childNode_number].Nodes.Clear();
                    }
                    foreach (string name in columns)
                    {
                        treeData.Nodes[indexNumber].Nodes[childNode_number].Nodes.Add(name, name, 2);
                    }
                    columns.Clear();
                }
            }
            catch (Exception err) { MessageBox.Show("Unkown Error : " + err.Message, "Unkown", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public string reName_nodes()
        {
            try
            {
                string dbName = tabControl1.SelectedTab.Text.ToString();
                string changeDb_name = dbName.Substring(10);
                return changeDb_name;
            }
            catch { return null; }
        }

        void runQuery()
        {
            try
            {
                richTextBox2.Text = "";
                SqlCommand command;
                string[] str = { "insert", "INSERT", "update", "UPDATE", "DELETE", "delete" };
                FastColoredTextBoxNS.FastColoredTextBox ctl = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    csDataBase.connectionString = @"Data Source=" + csTransactions.ServerItems.svName + ";" + "Initial Catalog=" + reName_nodes() + ";" + "Integrated Security=True;";
                    csDataBase.connection.ConnectionString = csDataBase.connectionString;
                    csDataBase.connection.FireInfoMessageEventOnUserErrors = true;
                    csDataBase.connection.Open();
                    command = new SqlCommand(ctl.Text, csDataBase.connection);

                    var query = command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (ctl.Text.Contains(str[i].ToString()) == true)
                        {
                            length++;
                        }
                    }
                    if (length == 0)
                    {
                        SqlDataAdapter adp = new SqlDataAdapter(command);
                        adp.Fill(table);
                    }
                    if (dil == "English")
                    {
                        label3.Text = "Query executed successfully";
                    }
                    if (dil == "Turkish")
                    {
                        label3.Text = "Sorgu başarıyla gerçekleştirildi"; ;
                    }
                    length = 0;
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\succes.png");
                    if (csTransactions.ServerItems.ConnectName == "Local") { txtConnect.Text = serverList.Text; }
                    if (csTransactions.ServerItems.ConnectName == "Remote") { txtConnect.Text = "Remote Server"; }
                    txtDataBase.Text = reName_nodes();
                    txtQuery.Text = table.Rows.Count.ToString();
                    panel3.Visible = true;
                    tabControl2.Visible = true;
                    dataGridView1.DataSource = table;
                    csDataBase.connection.FireInfoMessageEventOnUserErrors = false;
                    csDataBase.connection.Close();
                    csDataBase.connectionString = null;
                    csDataBase.connection.ConnectionString = null;
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    SqlConnection connection = new SqlConnection(csTransactions.RemoteConnectString_Tables(reName_nodes()));
                    if (connection.State == ConnectionState.Open) { connection.Close(); }
                    connection.FireInfoMessageEventOnUserErrors = true;
                    command = new SqlCommand(ctl.Text, connection);
                    connection.Open();
                    var query = command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (ctl.Text.Contains(str[i].ToString()) == true)
                        {
                            length++;
                        }
                    }
                    if (length == 0)
                    {
                        SqlDataAdapter adp = new SqlDataAdapter(command);
                        adp.Fill(table);
                    }
                    if (dil == "English")
                    {
                        label3.Text = "Query executed successfully";
                    }
                    if (dil == "Turkish")
                    {
                        label3.Text = "Sorgu başarıyla gerçekleştirildi"; ;
                    }
                    length = 0;
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\succes.png");
                    if (csTransactions.ServerItems.ConnectName == "Local") { txtConnect.Text = serverList.Text; }
                    if (csTransactions.ServerItems.ConnectName == "Remote") { txtConnect.Text = "Remote Server"; }
                    txtDataBase.Text = reName_nodes();
                    txtQuery.Text = table.Rows.Count.ToString();
                    panel3.Visible = true;
                    tabControl2.Visible = true;
                    dataGridView1.DataSource = table;
                    connection.Close();
                }
            }
            catch (SqlException err)
            {
                richTextBox2.Text = err.Message;
                length = 0;
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
                panel3.Visible = true;
                if (dil == "English")
                {
                    label3.Text = "Query completed with errors";
                }
                if (dil == "Turkish")
                {
                    label3.Text = "Sorgu hatalarla tamamlandı";
                }
                pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\error.png");
                if (csTransactions.ServerItems.ConnectName == "Local") { txtConnect.Text = serverList.Text; }
                if (csTransactions.ServerItems.ConnectName == "Remote") { txtConnect.Text = "Remote Server"; }
                txtDataBase.Text = reName_nodes();
                txtQuery.Text = "0";
            }
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            try
            {
                richTextBox2.Text += e.Message.ToString() + "\n";
                tabControl2.SelectedTab = tabControl2.TabPages[1];
            }
            catch { }
        }

        private void backupDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bgwBackup.IsBusy)
            {
                bgwBackup.RunWorkerAsync();
                pictureBox1.Visible = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    CNB.FileName = "C:/temp/" + nodeName + ".bak";
                    CNB.DataBaseName = nodeName;
                    CNB.srv = new Server(serverList.Text);
                    CNB.BackupDb();
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CNB.FileName = "C:/temp/" + nodeName + ".bak";
                    CNB.DataBaseName = nodeName;
                    CNB.BackupDb();
                }
                pictureBox1.Visible = false;
                if (dil == "English")
                {
                    DialogResult onay = MessageBox.Show("Backup succesful, open folder?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        Process.Start(@"C:\Temp");
                    }
                }
                if (dil == "Turkish")
                {
                    DialogResult onay = MessageBox.Show("Yedek alma işlemi başarılı, dosya konumu açılsın mı?", "Yedekleme işlemi sonucu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        Process.Start(@"C:\Temp");
                    }
                }
            }
            catch (Exception ex) { pictureBox1.Visible = false; if (ex.Message.Contains("bulk") == true) { MessageBox.Show("Error:" + ex.Message + "\n" + "-Start SQL Server Managament Studio\n-Expand Security->Logins\n-Locate your user, right click on it and take Properties\n-Open Server Roles tab\n-Make sure that bulkadmin is checked\n-There you can experiment with other roles if bulkadmin doesn't work for you.\n-Click OK.", "Error: Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error); } else { MessageBox.Show(ex.ToString(), "Unkown Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Backup Files |*.bak";
            open.FilterIndex = 1;
            if (!bgwRestoreDB.IsBusy && open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Visible = true;
                fileName = System.IO.Path.GetFileNameWithoutExtension(open.FileName);
                dosyaLink = open.FileName;
                bgwRestoreDB.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CRDB.connection.Close();
                CRDB.connection.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=master; Integrated Security=True;";
                CRDB.commandText = "RESTORE DATABASE [" + fileName +
                   "] FROM DISK = '" + dosyaLink + "' ;";
                using (CRDB.Restore())
                {
                    CRDB.Restore().ExecuteNonQuery();
                    if (dil == "English")
                    {
                        MessageBox.Show("Restore dabase succesful", "Restored Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (dil == "Turkish")
                    {
                        MessageBox.Show("Veritabanı geri yükleme işlemi başarılı.", "Veritabanı geri yüklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                CRDB.connection.Close();
            }
            catch (Exception hata) { MessageBox.Show("" + hata.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); pictureBox1.Visible = false; }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            connect();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    if (tabControl1.TabPages.Count > 0)
                    {
                        if (tabControl1.SelectedTab.Text.Contains("New DataBase") || tabControl1.SelectedTab.Text.Contains("Yeni Veritabanı") == true)
                        {
                            newDB();
                        }
                        if (tabControl1.SelectedTab.Text.Contains("Query") == true || tabControl1.SelectedTab.Text.Contains("Sorgu") == true)
                        {
                            runQuery();
                        }
                    }
                }
            }
            catch{ }
        }

        private void deleteDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    CDT.connection.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Integrated Security=True;";
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CDT.connection.ConnectionString = csTransactions.RemoteConnectString();
                }
                using (CDT.connection)
                {
                    CDT.connection.Open();
                    CDT.commandText = @"USE master; ALTER DATABASE [" + nodeName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE[" + nodeName + "]";
                    if (dil == "English")
                    {
                        DialogResult dialog = MessageBox.Show("Deleting database ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            var query = CDT.DeleteQuery().ExecuteNonQuery();
                            if (query != 0) { MessageBox.Show("Database deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                    if (dil == "Turkish")
                    {
                        DialogResult dialog = MessageBox.Show("Veritabanı silinsin mi?", "Veritabanı silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            var query = CDT.DeleteQuery().ExecuteNonQuery();
                            if (query != 0) { MessageBox.Show("Veritabanı başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                }
                pictureBox1.Visible = false;
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    connect();
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    remote.GetDataBase();
                }
            }
            catch (SqlException err) { MessageBox.Show("" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); pictureBox1.Visible = false; }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ///<summary>
                ///This is a dynamic tool for new database
                /// </summary>
                #region
                controlTab_Page = false;
                if (dil == "English")
                {
                    createDB = "New DataBase";
                }
                if (dil == "Turkish")
                {
                    createDB = "Yeni Veritabanı";
                }
                FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
                j++;
                rtb.Size = new Size(802, 147);
                rtb.BorderStyle = BorderStyle.None;
                if (dil == "English")
                {
                    rtb.Text = "CREATE DATABASE [DB_NAME_HERE]";
                }
                if (dil == "Turkish")
                {
                    rtb.Text = "CREATE DATABASE [Veritabanı_adını_giriniz]";
                }
                TabPage tp = new TabPage();
                tp.Size = new Size(805, 150);
                tp.Controls.Add(rtb);
                tp.Text = createDB;
                tabControl1.Visible = true;
                tp.Name = j + "tp";
                tp.ContextMenuStrip = cntxQuery;
                rtb.Name = "rtb";
                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (page.Text == createDB)
                    {
                        tabControl1.SelectedTab = page;
                        controlTab_Page = true;
                        break;
                    }
                }
                if (controlTab_Page == false)
                {
                    tabControl1.TabPages.Add(tp);
                }
                #endregion
            }
            catch { }
        }

        private void treeData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeData.SelectedNode != null && treeData.SelectedNode.Parent == null)
                {
                    nodeName = e.Node.Text;
                    indexNumber = e.Node.Index;
                }
                if (treeData.SelectedNode != null && treeData.SelectedNode.Parent != null)
                {
                    childNode_name = e.Node.Text;
                    childNode_number = e.Node.Index;
                }
            }
            catch { }
        }

        private void newQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
                rtb.BorderStyle = BorderStyle.None;
                rtb.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.ChangedRange;
                rtb.Language = FastColoredTextBoxNS.Language.SQL;
                rtb.AutoCompleteBrackets = true;
                rtb.Dock = DockStyle.Fill;
                j++;
                rtb.Size = new Size(802, 147);
                rtb.BorderStyle = BorderStyle.None;
                rtb.ContextMenuStrip = cntxQueryCode;
                rtb.MouseDown += Rtb_MouseDown;
                TabPage tp = new TabPage();
                tp.Size = new Size(805, 150);
                tp.Controls.Add(rtb);
                if (dil == "English")
                {
                    tp.Text = "Query to: " + nodeName;
                }
                if (dil == "Turkish")
                {
                    tp.Text = "Sorgu :   " + nodeName;
                }
                tabControl1.TabPages.Add(tp);
                tabControl1.Visible = true;
                tp.Name = j + "tp";
                tp.ContextMenuStrip = cntxQuery;
                rtb.Name = "rtb";
                #endregion
            }
            catch { }
        }

        private void Rtb_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ToolStripMenuItem item;
                if (e.Button == MouseButtons.Right)
                {
                    (cntxQueryCode.Items[0] as ToolStripMenuItem).DropDownItems.Clear();
                    (cntxQueryCode.Items[1] as ToolStripMenuItem).DropDownItems.Clear();
                    (cntxQueryCode.Items[2] as ToolStripMenuItem).DropDownItems.Clear();
                    (cntxQueryCode.Items[3] as ToolStripMenuItem).DropDownItems.Clear();
                    //select
                    #region
                    foreach (TreeNode node in treeData.Nodes[reName_nodes()].Nodes)
                    {
                        itemLength++;
                        item = new ToolStripMenuItem();
                        item.Name = "selectItem" + itemLength;
                        item.Text = "Select * from " + node.Text.ToString();
                        (cntxQueryCode.Items[0] as ToolStripMenuItem).DropDownItems.Add(item);
                    }
                    #endregion
                    itemLength = 0;
                    //insert
                    #region
                    SqlConnection connect = new SqlConnection();
                    if (csTransactions.ServerItems.ConnectName == "Local")
                    {
                        csDataBase.connectionString = @"Data Source = " + serverList.Text.ToString() + "; " + "Initial Catalog = " + reName_nodes() + "; " + "Integrated Security = True; ";
                        csDataBase.connection.ConnectionString = csDataBase.connectionString;
                    }
                    if (csTransactions.ServerItems.ConnectName == "Remote")
                    {
                        connect.ConnectionString = csTransactions.RemoteConnectString_Tables(reName_nodes());
                        if (connect.State == ConnectionState.Open) { connect.Close(); }
                    }
                    var columns = new List<string>();
                    foreach (TreeNode node in treeData.Nodes[reName_nodes()].Nodes)
                    {
                        itemLength++;
                        item = new ToolStripMenuItem();
                        item.Name = "insertItem" + itemLength;
                        insertCommand = "insert into " + node.Text + " values(";
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            var command = new SqlCommand("select * from [" + node.Text + "] where 1 = 2", csDataBase.connection);
                            csDataBase.connection.Open();
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    if (dr.GetDataTypeName(i).Contains("char") || dr.GetDataTypeName(i).Contains("text") || dr.GetDataTypeName(i).Contains("string"))
                                    {
                                        insertCommand += "'textData',";
                                    }
                                    else
                                    {
                                        insertCommand += " intData,";
                                    }
                                }
                                insertCommand += ")";
                                insertCommand = insertCommand.Substring(0, insertCommand.Length - 2);
                                insertCommand += ")";
                            }
                            item.Text = insertCommand;
                            (cntxQueryCode.Items[1] as ToolStripMenuItem).DropDownItems.Add(item);
                            csDataBase.connection.Close();
                        }
                        if (csTransactions.ServerItems.ConnectName == "Remote")
                        {
                            var command = new SqlCommand("select * from [" + node.Text + "] where 1 = 2", connect);
                            connect.Open();
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    if (dr.GetDataTypeName(i).Contains("char") || dr.GetDataTypeName(i).Contains("text") || dr.GetDataTypeName(i).Contains("string"))
                                    {
                                        insertCommand += "'textData',";
                                    }
                                    else
                                    {
                                        insertCommand += " intData,";
                                    }
                                }
                                insertCommand += ")";
                                insertCommand = insertCommand.Substring(0, insertCommand.Length - 2);
                                insertCommand += ")";
                            }
                            item.Text = insertCommand;
                            (cntxQueryCode.Items[1] as ToolStripMenuItem).DropDownItems.Add(item);
                            connect.Close();
                        }
                    }
                    csDataBase.connectionString = null;
                    csDataBase.connection.ConnectionString = null;
                    #endregion
                    //update
                    itemLength = 0;
                    #region
                    foreach (TreeNode node in treeData.Nodes[reName_nodes()].Nodes)
                    {
                        itemLength++;
                        item = new ToolStripMenuItem();
                        item.Name = "updateItem" + itemLength;
                        item.Text = "update " + node.Text.ToString();
                        (cntxQueryCode.Items[3] as ToolStripMenuItem).DropDownItems.Add(item);
                    }
                    #endregion
                    //delete
                    #region
                    foreach (TreeNode node in treeData.Nodes[reName_nodes()].Nodes)
                    {
                        itemLength++;
                        item = new ToolStripMenuItem();
                        item.Name = "deleteItem" + itemLength;
                        item.Text = "delete from " + node.Text.ToString() + " where ";
                        (cntxQueryCode.Items[2] as ToolStripMenuItem).DropDownItems.Add(item);
                    }
                    #endregion
                }
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
            }
            catch (Exception err)
            {
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
            }

        }

        private void DeleteQuery_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                FastColoredTextBoxNS.FastColoredTextBox rtb = this.tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                rtb.Text = e.ClickedItem.Text;
            }
            catch { }
        }

        private void UpdateQuery_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string replace = e.ClickedItem.Text.Substring(7);
                up.lblColumnName.Text = replace;
                up.cmbColumn.Items.Clear();
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    csDataBase.connectionString = @"Data Source = " + serverList.Text.ToString() + "; " + "Initial Catalog = " + reName_nodes() + "; " + "Integrated Security = True; ";
                    csDataBase.connection.ConnectionString = csDataBase.connectionString;
                    csDataBase.connection.Open();
                    var command = new SqlCommand("select * from [" + replace + "] where 1 = 2", csDataBase.connection);
                    var columns = new List<string>();
                    using (var dr = command.ExecuteReader())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            columns.Add(dr.GetName(i));
                        }
                        foreach (string name in columns)
                        {
                            up.cmbColumn.Items.Add(name);
                        }
                    }
                    up.richTextBox1.Text = "update " + replace;
                    up.label5.Text = nodeName;
                    csDataBase.connection.Close();
                    csDataBase.connectionString = null;
                    csDataBase.connection.ConnectionString = null;
                    up.frm = this;
                    up.deger = 0;
                    up.button3.Enabled = false;
                    up.ShowDialog();
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(reName_nodes()));
                    if (connect.State == ConnectionState.Open) { connect.Close(); }
                    connect.Open();
                    var command = new SqlCommand("select * from [" + replace + "] where 1 = 2", connect);
                    var columns = new List<string>();
                    using (var dr = command.ExecuteReader())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            columns.Add(dr.GetName(i));
                        }
                        foreach (string name in columns)
                        {
                            up.cmbColumn.Items.Add(name);
                        }
                    }
                    up.richTextBox1.Text = "update " + replace;
                    up.label5.Text = nodeName;
                    up.frm = this;
                    up.deger = 0;
                    up.button3.Enabled = false;
                    up.ShowDialog();
                }
            }
            catch (Exception err)
            {
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
            }
        }

        private void InsertQuery_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                FastColoredTextBoxNS.FastColoredTextBox rtb = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                rtb.Text = e.ClickedItem.Text.ToString();
            }
            catch { }
        }

        private void SelectQuery_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                FastColoredTextBoxNS.FastColoredTextBox rtb = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                rtb.Text = e.ClickedItem.Text.ToString();
                runQuery();
            }
            catch { }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            tabControl1.TabPages.RemoveAt(index);
            dataGridView1.DataSource = null;
            richTextBox2.Text = "";
            if (tabControl1.TabPages.Count == 0)
            {
                tabControl1.Visible = false;
                tabControl2.Visible = false;
            }
        }

        private void saveSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Contains("Query") == true || tabControl1.SelectedTab.Text.Contains("Sorgu") || tabControl1.SelectedTab.Text.Contains("New DataBase") || tabControl1.SelectedTab.Text.Contains("Yeni Veritabanı") == true)
            {
                string saveText = tabControl1.SelectedTab.Text.ToString();
                FastColoredTextBoxNS.FastColoredTextBox ctl = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Application.StartupPath + @"\Saved Sql";
                save.Filter = "SQL Files(*.sql)|*.sql";
                save.FileName = reName_nodes();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                        sw.WriteLine(ctl.Text);
                }
            }
            else
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ayar.ini"))
                {
                    INIKaydet ini = new INIKaydet(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ayar.ini");
                    dil = ini.Oku("Dil", "Ayarlanmış Dil");
                }
                if (dil == "English")
                {
                    MessageBox.Show("Not query,please select query.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dil == "Turkish")
                {
                    MessageBox.Show("Sorgu seçmediniz, lütfen sorgu seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Contains("Query") == true || tabControl1.SelectedTab.Text.Contains("New DataBase") || tabControl1.SelectedTab.Text.Contains("Sorgu") == true || tabControl1.SelectedTab.Text.Contains("Yeni Veritabanı") == true)
            {
                FastColoredTextBoxNS.FastColoredTextBox ctl = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = Application.StartupPath + @"\Saved Sql";
                open.Filter = "SQL Files(*.sql)|*.sql";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    var cmds = File.ReadAllText(open.FileName).Split(new string[] { "GO", "go" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cmd in cmds)
                    {
                        ctl.Text += cmd;
                    }
                }
            }
            else
            {
                if (dil == "English")
                {
                    MessageBox.Show("Not query,please select query.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dil == "Turkish")
                {
                    MessageBox.Show("Sorgu seçmediniz, lütfen sorgu seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void newDB()
        {
            FastColoredTextBoxNS.FastColoredTextBox ctl = tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
            csTransactions.CsNewDataBase CNB = new csTransactions.CsNewDataBase();
            if (csTransactions.ServerItems.ConnectName == "Local")
            {
                CNB.connection.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=master; Integrated Security=True;";
            }
            if (csTransactions.ServerItems.ConnectName == "Remote")
            {
                CNB.connection.ConnectionString = csTransactions.RemoteConnectString_Tables("master");
            }
            try
            {
                CNB.commandText = ctl.Text;
                var query = CNB.NewDataBaseFunc().ExecuteNonQuery();
                if (query != 0)
                {
                    if (dil == "English")
                    {
                        richTextBox2.Text = "Command(s) completed successfully.";
                        label3.Text = "Query executed successfully";
                    }
                    if (dil == "Turkish")
                    {
                        richTextBox2.Text = "Komut (lar) başarıyla tamamlandı.";
                        label3.Text = "Sorgu başarıyla gerçekleştirildi";
                    }
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\succes.png");
                    txtConnect.Text = serverList.Text;
                    txtDataBase.Text = reName_nodes();
                    panel3.Visible = true;
                    tabControl2.Visible = true;
                }
                CNB.connection.Close();
                connect();
            }
            catch (SqlException err)
            {
                panel3.Visible = true;
                if (dil == "English")
                {
                    label3.Text = "Query completed with errors";
                }
                if (dil == "Turkish")
                {
                    label3.Text = "Sorgu hatalarla tamamlandı";
                }
                richTextBox2.Text = err.Message.ToString(); tabControl2.Visible = true; tabControl2.SelectedTab = tabControl2.TabPages[1];
                pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\error.png");
                txtConnect.Text = serverList.Text;
                txtDataBase.Text = reName_nodes();
                txtQuery.Text = "0";
                if (richTextBox2.Text.Contains("Could not obtain exclusive lock on database 'model'."))
                {
                    if (dil == "English")
                    {
                        richTextBox2.Text += "\n Please restart mssql server service, and try again.";
                    }
                    if (dil == "Turkish")
                    {
                        richTextBox2.Text += "\n Lütfen mssql sunucu hizmetini yeniden başlatın ve tekrar deneyin.";
                    }
                    Process.Start("services.msc");
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    if (tabControl1.SelectedTab.Text.Contains("New DataBase") || tabControl1.SelectedTab.Text.Contains("Yeni Veritabanı") == true)
                    {
                        newDB();
                    }
                    if (tabControl1.SelectedTab.Text.Contains("Query") == true || tabControl1.SelectedTab.Text.Contains("Sorgu") == true)
                    {
                        runQuery();
                    }
                }
            }
            catch { }
        }

        private void newTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ///<summary>
                ///This is a dynamic tool for new table
                /// </summary>
                #region
                controlTab_Page = false;
                if (dil == "English")
                {
                    newTable = "New table from - " + nodeName;
                }
                if (dil == "Turkish")
                {
                    newTable = "Yeni tablo     - " + nodeName;
                }
                Button addButton = new Button();
                addButton.Size = new Size(75, 23);
                addButton.Location = new Point(727, 4);
                addButton.Name = "addButton";
                if (dil == "English")
                {
                    addButton.Text = "Add Table";
                }
                if (dil == "Turkish")
                {
                    addButton.Text = "Kaydet";
                }
                addButton.Click += AddButton_Click;
                TextBox addText = new TextBox();
                addText.Size = new Size(100, 20);
                addText.Location = new Point(621, 7);
                addText.Name = "addText";
                if (dil == "English")
                {
                    addText.Text = "Tablo Adı";
                }
                DataType typee = new DataType();
                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.Items.Add("int");
                cmb.Items.Add("varchar(50)");
                cmb.Items.Add("text");
                cmb.Items.Add("money");
                cmb.Items.Add("datetime");
                cmb.Name = "dataType";
                cmb.DataPropertyName = "dataType";
                cmb.HeaderText = "Data Type";
                cmb.AutoComplete = true;
                cmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                DataGridViewCheckBoxColumn ch = new DataGridViewCheckBoxColumn();
                ch.Name = "allowNulls";
                ch.HeaderText = "Allow Nulls";
                ch.DataPropertyName = "allowNulls";
                DataGridViewCheckBoxColumn ch2 = new DataGridViewCheckBoxColumn();
                ch2.Name = "setIdenity";
                ch2.HeaderText = "Set Idenity";
                ch2.DataPropertyName = "setIdenity";
                DataGridView dgw = new DataGridView();
                if (dgw.Columns.Count <= 0)
                {
                    dgw.Columns.Add("columnName", "Column Name");
                    dgw.Columns.Add(cmb);
                    dgw.Columns.Add(ch);
                    dgw.Columns.Add(ch2);
                    dgw.Columns["columnName"].DataPropertyName = "columnName";
                }
                dgw.ScrollBars = ScrollBars.Vertical;
                dgw.AllowUserToAddRows = false;
                dgw.AllowUserToDeleteRows = true;
                dgw.Name = "newTable";
                dgw.BackgroundColor = Color.White;
                dgw.BorderStyle = BorderStyle.None;
                dgw.Size = new Size(453, 180);
                dgw.ContextMenuStrip = cntxKey;
                dgw.CellClick += Dgw_CellClick;
                dgw.KeyDown += Dgw_KeyDown;
                dgw.Dock = DockStyle.Left;
                TabPage tp = new TabPage();
                tp.Size = new Size(805, 150);
                tp.Controls.Add(dgw);
                tp.Controls.Add(addButton);
                tp.Controls.Add(addText);
                tp.Text = newTable;
                tp.ImageIndex = 1;
                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (page.Text == newTable)
                    {
                        tabControl1.SelectedTab = page;
                        controlTab_Page = true;
                        break;
                    }
                }
                dgw.RowsAdded += Dgw_RowsAdded;
                if (controlTab_Page == false)
                {
                    tabControl1.TabPages.Add(tp);
                }
                tabControl1.Visible = true;
                #endregion
            }
            catch { }
        }

        private void Dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
            foreach (DataGridViewRow row in dgw.Rows)
            {
                row.Cells["allowNulls"].Value = false;
                row.Cells["setIdenity"].Value = false;
            }
        }

        private void Dgw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
                    dgw.Rows.Add();
                }
            }
            catch { }
        }
        private void Dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        break;
                    }
                    else
                    {
                        primaryIndex = e.RowIndex;
                    }
                }
            }
            catch { }
        }

        public string CreateTABLE(string tableName, DataTable table)
        {
            try
            {
                DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
                string sqlsc;
                sqlsc = "CREATE TABLE " + tableName + "(";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                    string columnType = table.Columns[i].DataType.ToString();
                    switch (columnType)
                    {
                        case "System.Int32":
                            sqlsc += " int ";
                            break;
                        case "System.Int64":
                            sqlsc += " bigint ";
                            break;
                        case "System.Int16":
                            sqlsc += " smallint";
                            break;
                        case "System.Byte":
                            sqlsc += " tinyint";
                            break;
                        case "System.Decimal":
                            sqlsc += " decimal ";
                            break;
                        case "System.DateTime":
                            sqlsc += " datetime ";
                            break;
                        case "System.Double":
                            sqlsc += " money";
                            break;
                        case "System.String":
                        default:
                            sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                            break;
                    }
                    if (table.Columns[i].AutoIncrement)
                    {
                        sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                    }
                    if (!table.Columns[i].AllowDBNull)
                    {
                        sqlsc += " NOT NULL ";
                    }
                    if (dgw.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        sqlsc += " PRIMARY KEY (" + dgw.Rows[i].Cells["columnName"].Value.ToString() + ") ";
                    }
                    sqlsc += ",";
                }
                return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
            }
            catch { return null; }
        }

        public string reName()
        {
            try
            {
                string dbName = tabControl1.SelectedTab.Text.ToString();
                string changeDb_name = dbName.Substring(17);
                return changeDb_name;
            }
            catch { return null; }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ///<summary>
                ///This is new table process
                ///<para> this function detects the entered values </para>
                ///<para> developed by mustafa gürses</para>
                /// </summary>
                #region
                string error1 = "";
                string error2 = "";
                string error3 = "";
                string error4 = "";
                string error5 = "";
                table.PrimaryKey = null;
                table.Rows.Clear();
                table.Columns.Clear();
                DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
                TextBox txt = tabControl1.SelectedTab.Controls.Find("addText", true)[0] as TextBox;
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    count++;
                    string dataType = row.Cells["dataType"].Value.ToString();
                    string columnName = row.Cells["columnName"].Value.ToString();
                    string allowNulls = row.Cells["allowNulls"].Value.ToString();
                    string idenity = row.Cells["setIdenity"].Value.ToString();
                    if (dataType != null && columnName != null && allowNulls != null)
                    {
                        switch (dataType.ToString())
                        {
                            case "int":
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("The null property and the identity property can not be activated, please change it. From table :" + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Null özelliği ile artan sıra özelliği aktif edilemez lütfen null özelliğini kaldırınız, tabo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "True" && row.DefaultCellStyle.BackColor == Color.Yellow || row.DefaultCellStyle.BackColor == Color.Empty)
                                {
                                    table.Columns.Add(columnName.ToString()).AutoIncrement = true;
                                    table.PrimaryKey = new DataColumn[] { table.Columns[columnName] };
                                }
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "False" && row.DefaultCellStyle.BackColor == Color.Empty)
                                {
                                    table.Columns.Add(columnName.ToString(), typeof(int)).AllowDBNull = true;
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "False" && row.DefaultCellStyle.BackColor == Color.Empty)
                                {
                                    table.Columns.Add(columnName, typeof(int));
                                }
                                break;
                            case "varchar(50)":
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("The null property and the identity property can not be activated, please change it. From table :" + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Null özelliği ile artan sıra özelliği aktif edilemez lütfen null özelliğini kaldırınız, tablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is varchar, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error2 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi varchar olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "False")
                                {
                                    table.Columns.Add(columnName.ToString(), typeof(String)).AllowDBNull = false;
                                }
                                if (allowNulls == "False" && idenity == "False")
                                {
                                    table.Columns.Add(columnName, typeof(String));
                                }
                                break;
                            case "datetime":
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("The null property and the identity property can not be activated, please change it. From table :" + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Null özelliği ile artan sıra özelliği aktif edilemez lütfen null özelliğini kaldırınız, tablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is datetime, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error3 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi datetime olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "False")
                                {
                                    table.Columns.Add(columnName.ToString(), typeof(DateTime)).AllowDBNull = false;
                                }
                                if (allowNulls == "False" && idenity == "False")
                                {
                                    table.Columns.Add(columnName, typeof(DateTime));
                                }
                                break;
                            case "money":
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is money, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error3 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi money olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is money, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error3 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi money olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "False")
                                {
                                    table.Columns.Add(columnName.ToString(), typeof(double)).AllowDBNull = false;
                                }
                                if (allowNulls == "False" && idenity == "False")
                                {
                                    table.Columns.Add(columnName, typeof(double));
                                }
                                break;
                            case "text":
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is money, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error3 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi money olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "False" && idenity.ToString() == "True")
                                {
                                    if (dil == "English")
                                    {
                                        MessageBox.Show("If the data type is money, identity cannot be set : " + columnName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error3 = "error";
                                    }
                                    if (dil == "Turkish")
                                    {
                                        MessageBox.Show("Veri tipi text olarak ayarladıysanız artan sıra ayarlayamazsınız,artan sıra özelliğini kaldırınız.\nTablo adı :" + columnName, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        error1 = "error";
                                    }
                                }
                                if (allowNulls.ToString() == "True" && idenity.ToString() == "False")
                                {
                                    table.Columns.Add(columnName.ToString(), typeof(String)).AllowDBNull = false;
                                }
                                if (allowNulls == "False" && idenity == "False")
                                {
                                    table.Columns.Add(columnName, typeof(String));
                                }
                                break;
                        }
                    }
                }
                if (error1 == string.Empty && error2 == string.Empty && error3 == string.Empty && error4 == string.Empty && error5 == string.Empty)
                {
                    if (csTransactions.ServerItems.ConnectName == "Local")
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + reName() + ";" + "Integrated Security=True;");
                        SqlCommand command = new SqlCommand(CreateTABLE(txt.Text, table), conn);
                        conn.Open();
                        var commandTrue = command.ExecuteNonQuery();
                        tabControl2.Visible = true;
                        if (dil == "English")
                        {
                            richTextBox2.Text = "Command Successfull : \n" + CreateTABLE(txt.Text, table);
                            if (commandTrue != 0) { MessageBox.Show("Table created successfull : " + txt.Text); }
                        }
                        if (dil == "Turkish")
                        {
                            richTextBox2.Text = "Komut Başarılı : \n" + CreateTABLE(txt.Text, table);
                            if (commandTrue != 0) { MessageBox.Show("Tablo başarılı bir şekilde oluşturuldu.\nOluşturulan tablo adı : " + txt.Text); }
                        }
                    }
                    if (csTransactions.ServerItems.ConnectName == "Remote")
                    {
                        SqlConnection conn = new SqlConnection(csTransactions.RemoteConnectString_Tables(reName()));
                        SqlCommand command = new SqlCommand(CreateTABLE(txt.Text, table), conn);
                        if (conn.State == ConnectionState.Open) { conn.Close(); }
                        conn.Open();
                        var commandTrue = command.ExecuteNonQuery();
                        tabControl2.Visible = true;
                        if (dil == "English")
                        {
                            richTextBox2.Text = "Command Successfull : \n" + CreateTABLE(txt.Text, table);
                            if (commandTrue != 0) { MessageBox.Show("Table created successfull : " + txt.Text); }
                        }
                        if (dil == "Turkish")
                        {
                            richTextBox2.Text = "Komut Başarılı : \n" + CreateTABLE(txt.Text, table);
                            if (commandTrue != 0) { MessageBox.Show("Tablo başarılı bir şekilde oluşturuldu.\nOluşturulan tablo adı : " + txt.Text); }
                        }
                    }
                }
                #endregion
            }
            catch (SqlException err)
            {
                table.Clear();
                tabControl2.SelectedTab = tabControl2.TabPages[1];
                richTextBox2.Text = err.Message;
            }
        }

        private void treeData_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Select the clicked node
                    treeData.SelectedNode = treeData.GetNodeAt(e.X, e.Y);

                    if (treeData.SelectedNode != null && treeData.SelectedNode.Parent == null)
                    {
                        cntxDataBase.Show(treeData, e.Location);
                    }
                    if (treeData.SelectedNode == null && treeData.SelectedNode.Parent != null)
                    {
                        cntxTable.Show(treeData, e.Location);
                    }
                }
            }
            catch { }
        }

        private void setPrimaryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
                if (dgw.Rows[primaryIndex].Cells["dataType"].Value.ToString() == "int")
                {
                    int varmi = 0;
                    for (int i = 0; i < dgw.Rows.Count; i++)
                    {
                        if (dgw.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            varmi++;
                        }
                    }
                    if (varmi == 0)
                    {
                        dgw.Rows[primaryIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    if (dil == "English")
                    {
                        MessageBox.Show("Please datatype set : int", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (dil == "Turkish")
                    {
                        MessageBox.Show("Lütfen veri tipini 'int' olarak ayarlayın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void getColumnsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (childNode_name != null)
            {
                tablola();
            }
            else
            {
                if (dil == "English")
                {
                    MessageBox.Show("Please checked is column name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dil == "Turkish")
                {
                    MessageBox.Show("Lütfen kolon adı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void treeData_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    treeData.SelectedNode = e.Node;
                }

                if (e.Node.Level == 0)
                {
                    e.Node.ContextMenuStrip = cntxDataBase;
                }
                else if (e.Node.Level == 1)
                {
                    e.Node.ContextMenuStrip = cntxTable;
                }
                else if (e.Node.Level == 2)
                {
                    e.Node.ContextMenuStrip = null;
                }
            }
            catch { }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mySelectedNode != null && mySelectedNode.Parent != null)
                {
                    treeData.SelectedNode = mySelectedNode;
                    treeData.LabelEdit = true;
                    if (!mySelectedNode.IsEditing)
                    {
                        mySelectedNode.BeginEdit();
                    }
                }
            }
            catch { }
        }

        private void TreeData_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    e.Node.BeginEdit();
                }
                this.BeginInvoke(new Action(() => afterAfterEdit(e.Node)));
            }
        }

        private void afterAfterEdit(TreeNode node)
        {
            try
            {
                string txt = node.Text;   // Now it is updated
                                          // etc..
                if (beforeLabel != txt)
                {
                    if (csTransactions.ServerItems.ConnectName == "Local")
                    {
                        var conn = new SqlConnection(@"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + nodeName + ";" + "Integrated Security=True;");
                        conn.Open();
                        SqlCommand command = new SqlCommand(@"EXEC sp_rename '" + beforeLabel + "','" + txt + "'", conn);
                        var query = command.ExecuteNonQuery();
                        if (query != 0)
                        {
                            if (dil == "English")
                            {
                                MessageBox.Show("Table name is changed\nBefore table name : " + beforeLabel + "\nAfter changed is table name :" + txt, "Table Name Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }
                            if (dil == "Turkish")
                            {
                                MessageBox.Show("Tablo adı değiştirildi\nÖnceki tablo adı : " + beforeLabel + "\nDeğiştirildiği tablo adı :" + txt, "Tablo adı değiştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }
                        }
                    }
                    if (csTransactions.ServerItems.ConnectName == "Remote")
                    {
                        var conn = new SqlConnection(csTransactions.RemoteConnectString_Tables(nodeName));
                        if (conn.State == ConnectionState.Open) { conn.Close(); }
                        conn.Open();
                        SqlCommand command = new SqlCommand(@"EXEC sp_rename '" + beforeLabel + "','" + txt + "'", conn);
                        var query = command.ExecuteNonQuery();
                        if (query != 0)
                        {
                            if (dil == "English")
                            {
                                MessageBox.Show("Table name is changed\nBefore table name : " + beforeLabel + "\nAfter changed is table name :" + txt, "Table Name Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }
                            if (dil == "Turkish")
                            {
                                MessageBox.Show("Tablo adı değiştirildi\nÖnceki tablo adı : " + beforeLabel + "\nDeğiştirildiği tablo adı :" + txt, "Tablo adı değiştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (SqlException err) { MessageBox.Show("" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    CDT.connection.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + nodeName + ";" + "Integrated Security=True;";
                    CDT.commandText = "DROP TABLE " + childNode_name + ";";
                    CDT.connection.Open();
                    DialogResult dialog = MessageBox.Show("Delete table?", "Table is delete process detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var query = CDT.DeleteQuery().ExecuteNonQuery();
                        if (query != 0)
                        {
                            if (dil == "English")
                            {
                                MessageBox.Show("Table is deleted.", "Delete process is completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CDT.connection.Close();
                                connect();
                            }
                            if (dil == "Turkish")
                            {
                                MessageBox.Show("Tablo başarılı bir şekilde silindi.", "Silme işlemi başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CDT.connection.Close();
                                connect();
                            }
                        }
                    }
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CDT.connection.ConnectionString = csTransactions.RemoteConnectString_Tables(nodeName);
                    CDT.commandText = "DROP TABLE " + childNode_name + ";";
                    CDT.connection.Open();
                    DialogResult dialog = MessageBox.Show("Delete table?", "Table is delete process detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var query = CDT.DeleteQuery().ExecuteNonQuery();
                        if (query != 0)
                        {
                            if (dil == "English")
                            {
                                MessageBox.Show("Table is deleted.", "Delete process is completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CDT.connection.Close();
                                remote.GetDataBase();
                            }
                            if (dil == "Turkish")
                            {
                                MessageBox.Show("Tablo başarılı bir şekilde silindi.", "Silme işlemi başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CDT.connection.Close();
                                remote.GetDataBase();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void editTop200RowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///This is a dynamic tool for edit top 200 rows
            /// </summary>
            #region
            try
            {
                if (dil == "English")
                {
                    edit = "Edit top 200 rows to : " + childNode_name + " from :" + nodeName;
                }
                if (dil == "Turkish")
                {
                    edit = "Satır düzenleme işlemi : " + childNode_name + " veritabanı :" + nodeName;
                }
                Button saveBtn = new Button();
                if (dil == "English")
                {
                    saveBtn.Text = "Save Changes";
                }
                if (dil == "Turkish")
                {
                    saveBtn.Text = "Kaydet";
                }
                saveBtn.Name = "saveBtn";
                saveBtn.Location = new Point(727, 4);
                saveBtn.Click += SaveBtn_Click;
                saveBtn.FlatStyle = FlatStyle.Flat;
                DataGridView data = new DataGridView();
                data.Name = "editRows";
                data.Size = new Size(700, 132);
                data.Location = new Point(3, 9);
                data.AllowUserToAddRows = true;
                data.AllowUserToDeleteRows = true;
                data.BackgroundColor = Color.White;
                data.BorderStyle = BorderStyle.None;
                TabPage tp = new TabPage();
                tp.Size = new Size(805, 150);
                tp.Text = edit;
                tp.Controls.Add(data);
                tp.Controls.Add(saveBtn);
                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (page.Text == edit)
                    {
                        tabControl1.SelectedTab = page;
                        controlTab_Page = true;
                        break;
                    }
                }
                if (controlTab_Page == false)
                {
                    ds.Clear();
                    tabControl1.TabPages.Add(tp);
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    if (csTransactions.ServerItems.ConnectName == "Local")
                    {
                        con.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + nodeName + ";" + "Integrated Security=True;";
                        cmd.CommandText = "select * from " + childNode_name;
                        cmd.Connection = con;
                        con.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds, childNode_name);
                        data.DataSource = ds.Tables[childNode_name];
                        con.Close();
                    }
                    if (csTransactions.ServerItems.ConnectName == "Remote")
                    {
                        con.ConnectionString = csTransactions.RemoteConnectString_Tables(nodeName);
                        cmd.CommandText = "select * from " + childNode_name;
                        cmd.Connection = con;
                        con.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds, childNode_name);
                        data.DataSource = ds.Tables[childNode_name];
                        con.Close();
                    }
                }
                tabControl1.Visible = true;
                controlTab_Page = false;
            }
            catch (SqlException err)
            {
                if (dil == "English")
                {
                    MessageBox.Show("Please select database name before click 'Edit Top 200 Rows'\nSQL Exception : " + err.Message, "DataBase name not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dil == "Turkish")
                {
                    MessageBox.Show("Lütfen öncelikle veritabanı ismine tıklayınız daha sonrasında ise  'Edit Top 200 Rows' tıklayınız.\nSQL Hatası : " + err.Message, "Veritabanı ismi seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///Save edit top 200 rows columns
            /// </summary>
            #region
            if (csTransactions.ServerItems.ConnectName == "Local")
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                try
                {
                    da.Update(ds, childNode_name);
                    if (dil == "English")
                    {
                        MessageBox.Show("Update succesfully");
                    }
                    if (dil == "Turkish")
                    {
                        MessageBox.Show("Güncelleme işlemi başarılı");
                    }
                }
                catch (SqlException err) { MessageBox.Show("" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            if (csTransactions.ServerItems.ConnectName == "Remote")
            {
                csTransactions ct = new csTransactions();
                ct.RemoteUpdate_Tables(da);
                try
                {
                    da.Update(ds, childNode_name);
                    if (dil == "English")
                    {
                        MessageBox.Show("Update succesfully");
                    }
                    if (dil == "Turkish")
                    {
                        MessageBox.Show("Güncelleme işlemi başarılı");
                    }
                }
                catch (SqlException err) { MessageBox.Show("" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            #endregion
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ///<summary>
            ///get mouse location -> panel2
            /// </summary>
            #region
            Panel p = sender as Panel;
            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos);
                    p.Left += (e.X - xPos);
                    if (panel2.Left <= 1 && panel2.Left <= -100)
                    {
                        panel2.Location = new Point(1, 5);
                    }
                    if (panel2.Left >= 1000)
                    {
                        panel2.Location = new Point(818, 0);
                    }
                    if (panel2.Top <= 0)
                    {
                        panel2.Location = new Point(1, 5);
                    }
                    if (panel2.Top >= 426)
                    {
                        panel2.Location = new Point(1, 5);
                    }
                    if (panel2.Left >= 1 && panel2.Left <= 20)
                    {
                        btnExecute.Location = new Point(195, 0);
                        btnCreate.Location = new Point(896, 0);
                        tabControl1.Location = new Point(195, 22);
                        tabControl2.Location = new Point(194, 201);
                        btnRestore.Location = new Point(711, 0);
                        btnAutoBackup.Location = new Point(595, 0);
                    }
                    if (panel2.Left >= 688 && panel2.Left <= 818)
                    {
                        btnRestore.Location = new Point(311, 0);
                        btnExecute.Location = new Point(3, 0);
                        btnCreate.Location = new Point(704, 0);
                        tabControl1.Location = new Point(3, 21);
                        tabControl2.Location = new Point(2, 200);
                        btnAutoBackup.Location = new Point(510, 0);
                    }
                }
            }
            #endregion
        }

        private void tRUNCATETABLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///This is truncate process
            /// </summary>
            #region
            try
            {
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    CDT.connection.Close();
                    CDT.connection.ConnectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + nodeName + ";" + "Integrated Security=True;";
                    CDT.commandText = "TRUNCATE TABLE " + childNode_name + ";";
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CDT.connection.Close();
                    CDT.connection.ConnectionString = csTransactions.RemoteConnectString_Tables(nodeName);
                    CDT.commandText = "TRUNCATE TABLE " + childNode_name + ";";
                }
                if (dil == "English")
                {
                    DialogResult dialog = MessageBox.Show("This operation zeroes the ascending sequence and deletes the data", "Table is delete process detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var query = CDT.DeleteQuery().ExecuteNonQuery();
                        if (query != 0)
                        {
                            MessageBox.Show("Truncate table is successfully", "TRUNCATE TABLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CDT.connection.Close();
                        }
                    }
                }
                if (dil == "Turkish")
                {
                    DialogResult dialog = MessageBox.Show("Uyarı!! Bu işlem artan sırayı 0 yapar ve verilerinizi siler, işlem onaylansın mı?", "Tablo silme işlemi algılandı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var query = CDT.DeleteQuery().ExecuteNonQuery();
                        if (query != 0)
                        {
                            MessageBox.Show("Truncate komutu tablo için başarılı bir şekilde uygulandı.", "TRUNCATE İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CDT.connection.Close();
                        }
                    }
                }
            }
            catch
            {
                CDT.connection.Close();
            }
            #endregion
        }

        private void tmrLoging_Tick(object sender, EventArgs e)
        {
            if (!bgwApplication.IsBusy)
            {
                bgwApplication.RunWorkerAsync();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.facebook.com/mustafa.gursess");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.youtube.com/c/MustafaGürses");
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            ///<summary>
            ///Get mouse location -> panel4
            /// </summary>
            #region
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.Height != 498)
                    {
                        label5.Visible = true;
                        if (dil == "English")
                        {
                            label5.Text = "Sharp query opens on the screen, you can not move.";
                        }
                        if (dil == "Turkish")
                        {
                            label5.Text = "Şuanda sharp query açılıyor, yer değiştiremezsiniz.";
                        }
                    }
                    if (this.Height >= 498)
                    {
                        label5.Visible = false;
                        ReleaseCapture();
                        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                        remote.Location = new Point(this.Left + this.Width, this.Top);
                    }
                }
                if (e.Button == MouseButtons.None) { label5.Visible = false; }
            }
            catch { }
            #endregion
        }

        private void treeData_MouseDown_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && nodeName != null)
                {
                    mySelectedNode = treeData.GetNodeAt(e.X, e.Y);
                    beforeLabel = treeData.GetNodeAt(e.X, e.Y).Text.ToString();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            remote.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dil == "English")
            {
                DialogResult onay = MessageBox.Show("Are you sure you want to closed the application?", "Application is closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            if (dil == "Turkish")
            {
                DialogResult onay = MessageBox.Show("Uygulamayı kapatmak istediğine eminmisin?", "Uygulamayı kapatma işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void removePrimaryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgw = tabControl1.SelectedTab.Controls.Find("newTable", true)[0] as DataGridView;
            try
            {
                dgw.Rows[primaryIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
            catch { }
        }

        private void cQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                sharp.frm = this;
                sharp.cmbTable.Items.Clear();
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    csDataBase.connectionString = @"Data Source=" + serverList.Text.ToString() + ";" + "Initial Catalog=" + reName_nodes() + ";" + "Integrated Security=True;";
                    csDataBase.connection.ConnectionString = csDataBase.connectionString;
                    csDataBase.connection.Open();
                    DataTable dt = csDataBase.connection.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[2];
                        sharp.cmbTable.Items.Add(tablename);
                    }
                    csDataBase.connection.Close();
                    csDataBase.connectionString = null;
                    csDataBase.connection.ConnectionString = null;
                    sharp.lblDbName.Text = reName_nodes();
                    sharp.Show();
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(reName_nodes()));
                    if (connect.State == ConnectionState.Open) { connect.Close(); }
                    connect.Open();
                    DataTable dt = connect.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[2];
                        sharp.cmbTable.Items.Add(tablename);
                    }
                    sharp.lblDbName.Text = reName_nodes();
                    sharp.Show();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
            }
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.Height >= 33 && this.Height <= 538)
            {
                this.Height += 15;
                if (this.Height >= 496)
                {
                    pictureBox1.Visible = false;
                    tmrLoging.Stop();
                }
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label5.Visible = false;
            if (this.Height >= 496)
            {
                tmrLoging.Stop();
            }
        }
        private void minimizeMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel2.Left >= -106 && panel2.Left <= 40)
            {
                tabControl1.Size = new Size(813, 179);
                tabControl2.Size = new Size(814, 236);
                tabControl2.Location = new Point(194, 201);
            }
            if (panel2.Left >= 400 && panel2.Left <= 1000)
            {
                tabControl2.Size = new Size(814, 236);
                tabControl1.Size = new Size(813, 179);
                tabControl2.Location = new Point(2, 200);
            }
        }
        private void enlargeMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel2.Left >= -106 && panel2.Left <= 40)
            {
                tabControl2.Size = new Size(814, 20);
                tabControl1.Size = new Size(813, 395);
                tabControl2.Location = new Point(194, 411);
            }
            if (panel2.Left >= 400 && panel2.Left <= 1000)
            {
                tabControl2.Size = new Size(814, 20);
                tabControl1.Size = new Size(813, 395);
                tabControl2.Location = new Point(2, 411);
            }
        }

        private void btnAutoBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    Auto.checkedListBox1.Items.Clear();
                    foreach (string str in CSC.GetDbName())
                    {
                        if (str != "model" && str != "master" && str != "msdb" && str != "tempdb")
                        {
                            Auto.checkedListBox1.Items.Add(str);
                        }
                    }
                    Auto.Show();
                    Auto.frm = this;
                }
                if (csTransactions.ServerItems.ConnectName == "Remote")
                {
                    CSC.RemoteDBName();
                    if (CSC.ControlDB == true)
                    {
                        Auto.checkedListBox1.Items.Clear();
                        foreach(string str in CSC.DataBases)
                        {
                            if (str != "model" && str != "master" && str != "msdb" && str != "tempdb")
                            {
                                Auto.checkedListBox1.Items.Add(str);
                            }
                        }
                        Auto.Show();
                        Auto.frm = this;
                    }
                }
            }
            catch { }
        }

        private void btnConnectRemote_Click(object sender, EventArgs e)
        {
            remote.frm = this;
            remote.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            remote.Location = new Point(this.Left + this.Width, this.Top);
            remote.Show();
        }
        string Text;
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (CheckNet() == true)
            {
                var links = webBrowser1.Document.GetElementsByTagName("div");
                foreach (HtmlElement link in links)
                {
                    if (link.GetAttribute("className") == "div1")
                    {
                        Text = link.InnerText;
                        MessageBox.Show(Text);
                    }
                }
            }
            if (!BgwMarquee.IsBusy) { BgwMarquee.RunWorkerAsync(); }
        }

        private void BgwMarquee_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (CheckNet() == true)
                {
                    if (dil == "English")
                    {
                        lblMarquee.Text = "#### NOTICE #### Network connection status is online, please wait.";
                        System.Threading.Thread.Sleep(1000);
                        lblMarquee.Text = "NOTICE: ";
                        char[] textToChar = Text.ToCharArray();
                        for (int i = 0; i < Text.Length; i++)
                        {
                            if (lblMarquee.Text.Length != 140)
                            {
                                lblMarquee.Text += textToChar[i].ToString();
                                System.Threading.Thread.Sleep(100);
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(2000);
                                lblMarquee.Text = "NOTICE: ";
                            }
                        }
                        System.Threading.Thread.Sleep(2000);
                        lblMarquee.Text = "NOTICE: ";
                        System.Threading.Thread.Sleep(25000);
                        webBrowser1.AllowNavigation = true;
                        webBrowser1.Navigate("http://www.mustafagurses.epizy.com/english.html");
                    }
                    if (dil == "Turkish")
                    {
                        lblMarquee.Text = "#### DUYURU #### Ağ bağlantısı şuanda açık, lütfen bekle.";
                        System.Threading.Thread.Sleep(1000);
                        lblMarquee.Text = "DUYURU: ";
                        char[] textToChar = Text.ToCharArray();
                        for (int i = 0; i < Text.Length; i++)
                        {
                            if (lblMarquee.Text.Length != 140)
                            {
                                lblMarquee.Text += textToChar[i].ToString();
                                System.Threading.Thread.Sleep(100);
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(2000);
                                lblMarquee.Text = "DUYURU: ";
                            }
                        }
                        System.Threading.Thread.Sleep(2000);
                        lblMarquee.Text = "DUYURU: ";
                        System.Threading.Thread.Sleep(10000);
                        webBrowser1.AllowNavigation = true;
                        webBrowser1.Navigate("http://www.mustafagurses.epizy.com/turkce.html");
                    }
                }
                else
                {
                    if (dil == "English")
                    {
                        lblMarquee.Text = "#### NOTICE #### Network connection status is offline";
                    }
                    if (dil == "Turkish")
                    {
                        lblMarquee.Text = "#### DUYURU #### Ağ bağlantısı şuanda kapalı";
                    }
                }
            }
            catch (Exception ex)
            {
                webBrowser1.AllowNavigation = true;
                if (dil == "Turkish")
                {
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/turkce.html");
                }
                if(dil == "English")
                {
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/english.html");
                }
            }
        }

        private void BgwMarquee_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            webBrowser1.AllowNavigation = true;
            if (CheckNet() == true)
            {
                if (dil == "Turkish")
                {
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/turkce.html");
                }
                if (dil == "English")
                {
                    webBrowser1.Navigate("http://www.mustafagurses.epizy.com/english.html");
                }
            }
            if (CheckNet() == false)
            {
                if (!BgwMarquee.IsBusy)
                {
                    BgwMarquee.RunWorkerAsync();
                }
            }
        }
    }
}
