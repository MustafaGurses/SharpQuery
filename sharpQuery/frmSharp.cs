using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorCode;
using System.Diagnostics;

namespace sharpQuery
{
    public partial class frmSharp : Form
    {
        public frmSharp()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        public frmMain frm;
        public int i;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public string metin { get; set; }
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        void insert_func(string tableName,string query)
        {
            try
            {
                char add = '"';
                string addWithValue = "";
                string funcName = "public void insert"+tableName+"(";
                #region
                for (int i =0; i<param.Count; i++)
                {
                    if(param[i].ToString().Contains("date") == true)
                    {
                        funcName += "DateTime date" + i+",";
                        addWithValue+= "command.Parameters.AddWithValue(" + add+param[i]+add+", date"+i+",);\n";
                    }
                    if (param[i].ToString().Contains("int"))
                    {
                        funcName += "int integer" + i + ",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] + add+", integer" + i + ",);\n";
                    }
                    if(param[i].ToString().Contains("string"))
                    {
                        funcName += "string str" + i+",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] +add+ ", str" + i + ",);\n";
                    }
                    if (param[i].ToString().Contains("money"))
                    {
                        funcName+="Double double"+i+",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] + add+", double" + i + ",);\n";
                    }
                }
                if (param.Count > 0)
                {
                    funcName = funcName.Substring(0, funcName.Length - 1);
                    funcName += ")";
                }
                else
                {
                    funcName += ")";
                }
                #endregion
                string sharpCommand = funcName+"\n{\ntry\n{\nif(connection.State == System.Data.ConnectionState.Open){ connection.Close(); }\nconnection.Open();\nSqlCommand command = new SqlCommand("+add+query+add+",connection);\n"+
                    addWithValue+"\ncommand.ExecuteNonQuery();\nMessageBox.Show("+add+"insert is completed"+add+","+add+"insert complete"+add+",MessageBoxButtons.OK,MessageBoxIcon.Information);\ncommand.Dispose();\nconnection.Close();\n}\ncatch(Exception ex)\n{\nMessageBox.Show(ex.ToString());\n}\n}";
                string sourceCode = sharpCommand;
                string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);
                if (System.IO.Directory.Exists(Application.StartupPath + @"\SharpCode") == false)
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\SharpCode");
                }
                System.IO.File.Exists(Application.StartupPath + @"\SharpCode\" + "insert" + tableName + DateTime.Now.ToLongDateString() + ".html");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + @"\SharpCode\" + "insert" + tableName + DateTime.Now.ToLongDateString() + ".html", true);
                sw.WriteLine(colorizedSourceCode);
                sw.Close();
                Process.Start(Application.StartupPath + @"\SharpCode\"+"insert" + tableName + DateTime.Now.ToLongDateString() + ".html");
            }
            catch { }
        }
        void update_func(string tableName, string query)
        {
            try
            {
                char add = '"';
                string addWithValue = "";
                string funcName = "public void update" + tableName + "(";
                #region
                for (int i = 0; i < param.Count; i++)
                {
                    if (param[i].ToString().Contains("date") == true)
                    {
                        funcName += "DateTime date" + i + ",";
                        addWithValue += "command.Parameters.AddWithValue(" + add+ param[i] +add+ ", date" + i + ");\n";
                    }
                    if (param[i].ToString().Contains("int"))
                    {
                        funcName += "int integer" + i + ",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] +add+ ", integer" + i + ");\n";
                    }
                    if (param[i].ToString().Contains("string"))
                    {
                        funcName += "string str" + i + ",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] +add+ ", str" + i + ");\n";
                    }
                    if (param[i].ToString().Contains("money"))
                    {
                        funcName += "Double double" + i + ",";
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] +add+", double" + i + ");\n";
                    }
                }
                if (param.Count > 0)
                {
                    funcName = funcName.Substring(0, funcName.Length - 1);
                    funcName += ")";
                }
                else
                {
                    funcName += ")";
                }
                #endregion
                string sharpCommand = funcName + "\n{\ntry\n{\nif(connection.State == System.Data.ConnectionState.Open){ connection.Close(); }\nconnection.Open();\nSqlCommand command = new SqlCommand("+add + query +add+ ",connection);\n" +
                    addWithValue + "\ncommand.ExecuteNonQuery();\nMessageBox.Show("+add+"update is completed"+add+","+add+"update complete"+add+",MessageBoxButtons.OK,MessageBoxIcon.Information);\ncommand.Dispose();\nconnection.Close();\n}\ncatch(Exception ex)\n{\nMessageBox.Show(ex.ToString());\n}\n}";
                string sourceCode = sharpCommand;
                string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);
                if (System.IO.Directory.Exists(Application.StartupPath + @"\SharpCode") == false)
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\SharpCode");
                }
                System.IO.File.Exists(Application.StartupPath + @"\SharpCode\" + "update" + tableName + DateTime.Now.ToLongDateString() + ".html");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + @"\SharpCode\" + "update" + tableName + DateTime.Now.ToLongDateString() + ".html", true);
                sw.WriteLine(colorizedSourceCode);
                sw.Close();
                Process.Start(Application.StartupPath + @"\SharpCode\" + "update" + tableName + DateTime.Now.ToLongDateString() + ".html");
            }
            catch { }
        }
        void delete_func(string tableName, string query)
        {
            try
            {
                char add = '"';
                string addWithValue = "";
                string funcName = "public void delete" + tableName + "(";
                if (param.Count > 0)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        funcName += "string param" + i+",";
                        addWithValue += "command.Parameters.AddWithValue(" + add+ param[i] +add+ ",param" + i + ");\n";
                    }
                        funcName = funcName.Substring(0, funcName.Length - 1);
                        funcName += ")";
                }
                else
                {
                    funcName += ")";
                }
                string sharpCommand = funcName + "\n{\ntry\n{\nif(connection.State == System.Data.ConnectionState.Open){ connection.Close(); }\nconnection.Open();\nSqlCommand command = new SqlCommand("+ add + query + add + ",connection);\n" +
                addWithValue + "\ncommand.ExecuteNonQuery();\nMessageBox.Show("+add+"Delete is completed"+add+","+add+"deleted complete"+add+",MessageBoxButtons.OK,MessageBoxIcon.Information);\ncommand.Dispose();\nconnection.Close();\n}catch(Exception ex)\n{\nMessageBox.Show(ex.ToString());\n}\n}";
                string sourceCode = sharpCommand;
                string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);
                if (System.IO.Directory.Exists(Application.StartupPath + @"\SharpCode") == false)
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\SharpCode");
                }
                System.IO.File.Exists(Application.StartupPath + @"\SharpCode\" + "delete" + tableName + DateTime.Now.ToLongDateString() + ".html");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + @"\SharpCode\" + "delete" + tableName + DateTime.Now.ToLongDateString() + ".html", true);
                sw.WriteLine(colorizedSourceCode);
                sw.Close();
                Process.Start(Application.StartupPath + @"\SharpCode\" + "delete" + tableName + DateTime.Now.ToLongDateString() + ".html");
            }
            catch
            {
            }
        }
        void select_func(string tableName, string query)
        {
            try
            {
                char add = '"';
                string addWithValue = "";
                param.Clear();
                for (int k = 0; k < lstControl.Items.Count; k++)
                {
                    rName = lstControl.Items[k].ToString();
                    string[] str;
                    str = rName.Split('=');
                    foreach (string i in str)
                    {
                        gercek = i;
                    }
                    param.Add(gercek);
                }
                string funcName = "public DataTable select" + tableName + "(";
                if (param.Count > 0)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        funcName += "string param" + i + ",";
                        if(query.Contains(" where ") == false) { query += " where "; }
                        if (query.Contains(" where ") == true)
                        {
                            query += " "+lstControl.Items[i].ToString();
                        }
                        addWithValue += "command.Parameters.AddWithValue(" + add + param[i] + add+",param"+i+");\n";
                    }
                    funcName = funcName.Substring(0, funcName.Length - 1);
                    funcName += ")";
                }
                else
                {
                    funcName += ")";
                }
                string sharpCommand = funcName + "\n{\ntry\n{\nif(connection.State == System.Data.ConnectionState.Open){ connection.Close(); }\nconnection.Open();\nSqlCommand command = new SqlCommand("+add+ query +add+",connection);\n" +
                addWithValue + "\nSqlDataAdapter adp = new SqlDataAdapter(command);\nDataTable table = new DataTable();\n adp.Fill(table);\nconnection.Close();\nreturn table;\n}\ncatch(Exception ex)\n{\nMessageBox.Show(ex.ToString());\n return null;\n}\n}";
                string sourceCode = sharpCommand;
                string colorizedSourceCode = new CodeColorizer().Colorize(sourceCode, Languages.CSharp);
                if (System.IO.Directory.Exists(Application.StartupPath + @"\SharpCode")  == false)
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\SharpCode");
                }
                System.IO.File.Exists(Application.StartupPath + @"\SharpCode\" + "select" + tableName + DateTime.Now.ToLongDateString() + ".html");
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + @"\SharpCode\" + "select" + tableName + DateTime.Now.ToLongDateString() + ".html", true);
                sw.WriteLine(colorizedSourceCode);
                sw.Close();
                Process.Start(Application.StartupPath + @"\SharpCode\" + "select" + tableName + DateTime.Now.ToLongDateString() + ".html");
            }
            catch{ }
        }
        List<string> columns = new List<string>();
        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                columns.Clear();
                lblDelete.Text = "delete from " + cmbTable.SelectedItem + " where ";
                foreach (Control txt in pnlTable.Controls)
                {
                    if (txt is TextBox)
                    {
                        pnlTable.Controls.Remove(txt);
                    }
                }
                lstControl.Items.Clear();
                if (csTransactions.ServerItems.ConnectName == "Local")
                {
                    csDataBase.connectionString = @"Data Source = " + frm.serverList.Text.ToString() + "; " + "Initial Catalog = " + lblDbName.Text.ToString() + "; " + "Integrated Security = True; ";
                    csDataBase.connection.ConnectionString = csDataBase.connectionString;
                    var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", csDataBase.connection);
                    csDataBase.connection.Open();
                    using (var dr = command.ExecuteReader())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            columns.Add(dr.GetName(i));
                        }
                    }
                    for (int i = 0; i < columns.Count; i++)
                    {
                        var txt = new TextBox();
                        txt.Name = "txt" + columns[i];
                        txt.Text = columns[i];
                        txt.Size = new Size(194, 20);
                        txt.Location = new Point(3, 31 + (i * 28));
                        pnlTable.Controls.Add(txt);
                    }
                    csDataBase.connection.Close();
                    csDataBase.connectionString = null;
                    csDataBase.connection.ConnectionString = null;
                }
                if(csTransactions.ServerItems.ConnectName == "Remote")
                {
                    SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(lblDbName.Text.ToString()));
                    if(connect.State == ConnectionState.Open) { connect.Close(); }
                    var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", connect);
                    connect.Open();
                    using (var dr = command.ExecuteReader())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            columns.Add(dr.GetName(i));
                        }
                    }
                    for (int i = 0; i < columns.Count; i++)
                    {
                        var txt = new TextBox();
                        txt.Name = "txt" + columns[i];
                        txt.Text = columns[i];
                        txt.Size = new Size(194, 20);
                        txt.Location = new Point(3, 31 + (i * 28));
                        pnlTable.Controls.Add(txt);
                    }
                }
            }
            catch { csDataBase.connection.Close(); csDataBase.connectionString = null; csDataBase.connection.ConnectionString = null; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tableName = cmbTable.Text;
            switch (cmbQuery.SelectedItem.ToString())
            {
                case "Delete":
                    #region
                    param.Clear();
                    if (lblWhere.Text != "Heading is put;OR,AND,Between..")
                    {
                        lblDelete.Text += " "+txtWhere.Text + " = " + txtParam.Text+" ";
                        lblWhere.Text = "Heading is put;OR,AND,Between..";
                        lstControl.Items.Add(txtWhere.Text + " = " + txtParam.Text);
                    }
                    else
                    {
                        if (txtWhere.Text.Contains("or") == true || txtWhere.Text.Contains("OR") == true || txtWhere.Text.Contains("beetween") == true || txtWhere.Text.Contains("BEETWEEN") == true || txtWhere.Text.Contains("and") == true || txtWhere.Text.Contains("AND") == true || txtWhere.Text.Contains(">=") == true || txtWhere.Text.Contains("<=") == true || txtWhere.Text.Contains("<") == true || txtWhere.Text.Contains(">") == true || txtWhere.Text.Contains("like") == true || txtWhere.Text.Contains("LIKE") == true || txtWhere.Text.Contains("IN(") == true || txtWhere.Text.Contains("IN (") == true || txtWhere.Text.Contains("inner join") == true || txtWhere.Text.Contains("INNER JOIN") == true || txtWhere.Text.Contains("order by") == true || txtWhere.Text.Contains("ORDER BY") == true || txtWhere.Text.Contains("OUTER JOIN") == true || txtWhere.Text.Contains("order by") == true || txtWhere.Text.Contains("outer join") == true || txtWhere.Text.Contains("limit") == true || txtWhere.Text.Contains("LIMIT") == true || txtWhere.Text.Contains("inner join") == true)
                        {
                            lblDelete.Text += " " + txtWhere.Text + " = " + txtParam.Text+" ";
                            lblWhere.Text = "Heading is put;OR,AND,Between..";
                            lstControl.Items.Add(txtWhere.Text + " = " + txtParam.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please heading is put;or,and,beetwen,<,>,<=,>=,in -> Where", "Not heading detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion
                    break;
                case "Select":
                    #region
                    param.Clear();
                    if (lblWhere.Text != "Heading is put;OR,AND,Between..")
                    {
                        selecQuery +=" where "+ txtWhere.Text + " = " + txtParam.Text;
                        lblWhere.Text = "Heading is put;OR,AND,Between..";
                        lstControl.Items.Add(txtWhere.Text + " = " + txtParam.Text);
                    }
                    else
                    {
                        if (txtWhere.Text.Contains("or") == true || txtWhere.Text.Contains("OR") == true || txtWhere.Text.Contains("beetween") == true || txtWhere.Text.Contains("BEETWEEN") == true || txtWhere.Text.Contains("and") == true || txtWhere.Text.Contains("AND") == true || txtWhere.Text.Contains(">=") == true || txtWhere.Text.Contains("<=") == true || txtWhere.Text.Contains("<") == true || txtWhere.Text.Contains(">") == true || txtWhere.Text.Contains("like") == true || txtWhere.Text.Contains("LIKE") == true || txtWhere.Text.Contains("IN(") == true || txtWhere.Text.Contains("IN (") == true)
                        {
                            selecQuery += " " + txtWhere.Text + " = " + txtParam.Text;
                            lblWhere.Text = "Heading is put;OR,AND,Between..";
                            lstControl.Items.Add(txtWhere.Text + " = " + txtParam.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please heading is put;or,and,beetwen,<,>,<=,>=,in -> Where", "Not heading detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion
                    break;
                default:
                    lstControl.Items.Add(txtParam.Text);
                    txtParam.Text = "";
                    break;
            }
        }
        ArrayList param = new ArrayList();
        public string gercek { get; set; }
        public string rName { get; set; }
        public string columnName { get; set; }
        string selecQuery = "select ";
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTable.SelectedItem == null || cmbTable.Text == null)
                {
                    MessageBox.Show("Please select table name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cmbQuery.SelectedItem == "Insert")
                    {
                        #region
                        param.Clear();
                        string tableName = cmbTable.Text;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            csDataBase.connectionString = @"Data Source = " + frm.serverList.Text.ToString() + "; " + "Initial Catalog = " + lblDbName.Text.ToString() + "; " + "Integrated Security = True; ";
                            csDataBase.connection.ConnectionString = csDataBase.connectionString;
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", csDataBase.connection);
                            csDataBase.connection.Open();
                            string query = "Insert into " + tableName + " values(";
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    if (controlText.Text == string.Empty)
                                    {
                                        if (dr.GetDataTypeName(i).ToString() == "datetime" || dr.GetDataTypeName(i).ToString() == "date")
                                        {
                                            query += "@dateTime" + i + ",";
                                            param.Add("@dateTime" + i);
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("var") == true)
                                        {
                                            query += "@string" + i + ",";
                                            param.Add("@string" + i);
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("int") == true)
                                        {
                                            query += "@int" + i + ",";
                                            param.Add("@int" + i);
                                        }
                                        else
                                        {
                                            query += "@p" + i + ",";
                                        }
                                    }
                                    if (controlText.Text != string.Empty)
                                    {
                                        query += "'" + controlText.Text + "',";
                                    }
                                }
                            }
                            query = query.Substring(0, query.Length - 1);
                            query += ")";
                            insert_func(cmbTable.Text, query);

                            csDataBase.connection.Close();
                            csDataBase.connectionString = null;
                            csDataBase.connection.ConnectionString = null;
                        }
                        if(csTransactions.ServerItems.ConnectName == "Remote")
                        {
                            SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(lblDbName.Text));
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", connect);
                            if(connect.State == ConnectionState.Open) { connect.Close(); }
                            connect.Open();
                            string query = "Insert into " + tableName + " values(";
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    if (controlText.Text == string.Empty)
                                    {
                                        if (dr.GetDataTypeName(i).ToString() == "datetime" || dr.GetDataTypeName(i).ToString() == "date")
                                        {
                                            query += "@dateTime" + i + ",";
                                            param.Add("@dateTime" + i);
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("var") == true)
                                        {
                                            query += "@string" + i + ",";
                                            param.Add("@string" + i);
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("int") == true)
                                        {
                                            query += "@int" + i + ",";
                                            param.Add("@int" + i);
                                        }
                                        else
                                        {
                                            query += "@p" + i + ",";
                                        }
                                    }
                                    if (controlText.Text != string.Empty)
                                    {
                                        query += "'" + controlText.Text + "',";
                                    }
                                }
                            }
                            query = query.Substring(0, query.Length - 1);
                            query += ")";
                            insert_func(cmbTable.Text, query);
                            connect.Close();
                            command.Dispose();
                        }
                        #endregion
                    }
                    if (cmbQuery.SelectedItem == "Update")
                    {
                        #region
                        param.Clear();
                        string tableName = cmbTable.Text;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            csDataBase.connectionString = @"Data Source = " + frm.serverList.Text.ToString() + "; " + "Initial Catalog = " + lblDbName.Text.ToString() + "; " + "Integrated Security = True; ";
                            csDataBase.connection.ConnectionString = csDataBase.connectionString;
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", csDataBase.connection);
                            csDataBase.connection.Open();
                            string query = "Update " + tableName + " set ";
                            #region
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    if (controlText.Text == string.Empty)
                                    {
                                        if (dr.GetDataTypeName(i).ToString() == "datetime" || dr.GetDataTypeName(i).ToString() == "date")
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @dateTime" + i + ",";
                                                param.Add("@dateTime" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @dateTime" + i + ",";
                                                param.Add("@dateTime" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("var") == true)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @string" + i + ",";
                                                param.Add("@string" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " =  @string" + i + ",";
                                                param.Add("@string" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).Length == SqlDbType.Int.ToString().Length)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @int" + i + ",";
                                                param.Add("@int" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @int" + i + ",";
                                                param.Add("@int" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("money") == true)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @double" + i + ",";
                                                param.Add("@double" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @double" + i + ",";
                                                param.Add("@double" + i);
                                            }
                                            continue;
                                        }
                                        else
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @p" + i + ",";
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @p" + i + ",";
                                            }
                                            continue;
                                        }
                                    }
                                    if (controlText.Text != string.Empty && dr.GetDataTypeName(i).ToString() != "int" && dr.GetDataTypeName(i).ToString() != "money")
                                    {
                                        if (query.Contains("set") == false)
                                        {
                                            query += "set " + dr.GetName(i) + " = '" + controlText.Text + "',";
                                        }
                                        if (query.Contains("set") == true)
                                        {
                                            query += dr.GetName(i) + " = '" + controlText.Text + "',";
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        if (query.Contains("set") == false)
                                        {
                                            query += "set " + dr.GetName(i) + " = " + controlText.Text + ",";
                                        }
                                        if (query.Contains("set") == true)
                                        {
                                            query += dr.GetName(i) + " = " + controlText.Text + ",";
                                        }
                                        continue;
                                    }
                                }
                            }
                            #endregion
                            query = query.Substring(0, query.Length - 1);
                            query += ")";
                            update_func(cmbTable.Text, query);

                            csDataBase.connection.Close();
                            csDataBase.connectionString = null;
                            csDataBase.connection.ConnectionString = null;
                        }
                        if(csTransactions.ServerItems.ConnectName == "Remote")
                        {
                            SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(lblDbName.Text.ToString()));
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", connect);
                            if(connect.State == ConnectionState.Open) { connect.Close(); }
                            connect.Open();
                            string query = "Update " + tableName + " set ";
                            #region
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    if (controlText.Text == string.Empty)
                                    {
                                        if (dr.GetDataTypeName(i).ToString() == "datetime" || dr.GetDataTypeName(i).ToString() == "date")
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @dateTime" + i + ",";
                                                param.Add("@dateTime" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @dateTime" + i + ",";
                                                param.Add("@dateTime" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("var") == true)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @string" + i + ",";
                                                param.Add("@string" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " =  @string" + i + ",";
                                                param.Add("@string" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).Length == SqlDbType.Int.ToString().Length)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @int" + i + ",";
                                                param.Add("@int" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @int" + i + ",";
                                                param.Add("@int" + i);
                                            }
                                            continue;
                                        }
                                        else if (dr.GetDataTypeName(i).ToString().Contains("money") == true)
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @double" + i + ",";
                                                param.Add("@double" + i);
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @double" + i + ",";
                                                param.Add("@double" + i);
                                            }
                                            continue;
                                        }
                                        else
                                        {
                                            if (query.Contains("set") == false)
                                            {
                                                query += "set " + dr.GetName(i) + " = @p" + i + ",";
                                            }
                                            if (query.Contains("set") == true)
                                            {
                                                query += dr.GetName(i) + " = @p" + i + ",";
                                            }
                                            continue;
                                        }
                                    }
                                    if (controlText.Text != string.Empty && dr.GetDataTypeName(i).ToString() != "int" && dr.GetDataTypeName(i).ToString() != "money")
                                    {
                                        if (query.Contains("set") == false)
                                        {
                                            query += "set " + dr.GetName(i) + " = '" + controlText.Text + "',";
                                        }
                                        if (query.Contains("set") == true)
                                        {
                                            query += dr.GetName(i) + " = '" + controlText.Text + "',";
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        if (query.Contains("set") == false)
                                        {
                                            query += "set " + dr.GetName(i) + " = " + controlText.Text + ",";
                                        }
                                        if (query.Contains("set") == true)
                                        {
                                            query += dr.GetName(i) + " = " + controlText.Text + ",";
                                        }
                                        continue;
                                    }
                                }
                            }
                            #endregion
                            query = query.Substring(0, query.Length - 1);
                            query += ")";
                            update_func(cmbTable.Text, query);
                            connect.Close();
                        }
                        #endregion
                    }
                    if (cmbQuery.SelectedItem == "Delete")
                    {
                        #region
                        param.Clear();
                        for (int k = 0; k < lstControl.Items.Count; k++)
                        {
                            rName = lstControl.Items[k].ToString();
                            string[] str;
                            str = rName.Split('=');
                            foreach (string i in str)
                            {
                                gercek = i;
                            }
                            param.Add(gercek);
                        }
                        delete_func(cmbTable.Text, lblDelete.Text);
                        #endregion
                    }
                    if (cmbQuery.SelectedItem == "Select")
                    {
                        #region
                        string tableName = cmbTable.Text;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            csDataBase.connectionString = @"Data Source = " + frm.serverList.Text.ToString() + "; " + "Initial Catalog = " + lblDbName.Text.ToString() + "; " + "Integrated Security = True; ";
                            csDataBase.connection.ConnectionString = csDataBase.connectionString;
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", csDataBase.connection);
                            csDataBase.connection.Open();
                            selecQuery = "select ";
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    columnName = controlText.Text;
                                    if (columnName != string.Empty)
                                    {
                                        selecQuery += controlText.Text + ",";
                                    }
                                }
                                selecQuery = selecQuery.Substring(0, selecQuery.Length - 1);
                                if (selecQuery.Contains("where") == false)
                                {
                                    selecQuery += " from " + tableName + " ";
                                }
                            }
                            select_func(tableName, selecQuery);
                            csDataBase.connection.Close();
                            csDataBase.connectionString = null;
                            csDataBase.connection.ConnectionString = null;
                        }
                        if (csTransactions.ServerItems.ConnectName == "Remote")
                        {
                            SqlConnection connect = new SqlConnection(csTransactions.RemoteConnectString_Tables(lblDbName.Text.ToString()));
                            var command = new SqlCommand("select * from [" + cmbTable.SelectedItem.ToString() + "] where 1 = 2", connect);
                            if(connect.State == ConnectionState.Open) { connect.Close(); }
                            connect.Open();
                            selecQuery = "select ";
                            using (var dr = command.ExecuteReader())
                            {
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    string controlName = "txt" + dr.GetName(i);
                                    TextBox controlText = pnlTable.Controls.Find(controlName, true)[0] as TextBox;
                                    columnName = controlText.Text;
                                    if (columnName != string.Empty)
                                    {
                                        selecQuery += controlText.Text + ",";
                                    }
                                }
                                selecQuery = selecQuery.Substring(0, selecQuery.Length - 1);
                                if (selecQuery.Contains("where") == false)
                                {
                                    selecQuery += " from " + tableName + " ";
                                }
                            }
                            connect.Close();
                            select_func(tableName, selecQuery);
                        }
                        #endregion
                    }
                }
            }
            catch { csDataBase.connection.Close();csDataBase.connectionString = null; csDataBase.connection.ConnectionString = null; }
        }

        private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbQuery.SelectedItem.ToString())
            {
                case "Delete":
                    lblParam.Text = "Please enter param name (Ex : @param1)";
                    lblWhere.Text = "Write where:(Ex: columnName)";
                    lblWhere.Visible = true;
                    txtWhere.Visible = true;
                    lblParam.Visible = true;
                    txtParam.Visible = true;
                    addParam.Visible = true;
                    lstControl.Visible = true;
                    break;
                case "Select":
                    lblParam.Text = "Please enter param name (Ex : @param1)";
                    lblWhere.Text = "Write where:(Ex: columnName)";
                    lblWhere.Visible = true;
                    txtWhere.Visible = true;
                    lblParam.Visible = true;
                    txtParam.Visible = true;
                    addParam.Visible = true;
                    lstControl.Visible = true;
                    break;
                default:
                    lblWhere.Visible = false;
                    txtWhere.Visible = false;
                    lblParam.Visible = false;
                    txtParam.Visible = false;
                    addParam.Visible = false;
                    lstControl.Visible = false;
                    lblParam.Text = "Please enter control name (Ex : textBox1.\nText)";
                    lblWhere.Text = "Write where :(Ex: columnName)";
                    break;
            }
        }
        void allClear()
        {
            try
            {
                foreach(Control txt in pnlTable.Controls)
                {
                    if(txt is TextBox)
                    {
                        pnlTable.Controls.Remove(txt);
                    }
                }
                cmbQuery.Text = "SELECT QUERY";
                cmbQuery.SelectedItem = "";
                cmbTable.Text = "SELECT TABLE NAME";
                cmbTable.SelectedItem = "";
                txtWhere.Text = "";
                txtParam.Text = "";
                lstControl.Items.Clear();

                lblWhere.Visible = false;
                txtWhere.Visible = false;
                lblParam.Visible = false;
                txtParam.Visible = false;
                addParam.Visible = false;
                lstControl.Visible = false;
            }
            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            allClear();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch { }
        }
    }
}
