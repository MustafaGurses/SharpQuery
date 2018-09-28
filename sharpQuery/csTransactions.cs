using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpQuery
{
    public class csTransactions
    {
        public static class ServerItems
        {
            public static string svName { get; set; }
            public static string dbName { get; set; }
            public static string AutoBackupProcessName { get; set; }
            public static string AutoBackupObjectName { get; set; }
            public static string UserID { get; set; }
            public static string UserPW { get; set; }
            public static string DataSource { get; set; }
            public static string ConnectName { get; set; }
        }
        public DataTable tables;
        public List<string>GetDbName()
        {
            try
            {
                var DbName = new List<string>();
                using (var con = new SqlConnection("Data Source="+csTransactions.ServerItems.svName+"; Integrated Security=True;"))
                {
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    foreach (DataRow database in databases.Rows)
                    {
                        String databaseName = database.Field<String>("database_name");
                        DbName.Add(databaseName);
                    }
                }
                return DbName;
            }
            catch { return null; }
        }
        public bool ControlDB = false;
        public List<string> DataBases = new List<string>();
        public List<string> RemoteDBName()
        {
                SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
                b.DataSource = csTransactions.ServerItems.DataSource;
                b.IntegratedSecurity = false;
                b.MultipleActiveResultSets = true;
                b.UserID = csTransactions.ServerItems.UserID;
                b.Password = csTransactions.ServerItems.UserPW;
                DataBases.Clear();
                SqlConnection connect = new SqlConnection(b.ConnectionString);
                    connect.Open();
                    DataTable databases = connect.GetSchema("Databases");
                    foreach (DataRow database in databases.Rows)
                    {
                        String databaseName = database.Field<String>("database_name");
                        DataBases.Add(databaseName);
                    }
                connect.Close();
                ControlDB = true;
                return DataBases;
        }
        public static string RemoteConnectString_Tables(string TableName)
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            b.DataSource = csTransactions.ServerItems.DataSource;
            b.IntegratedSecurity = false;
            b.MultipleActiveResultSets = true;
            b.InitialCatalog = TableName;
            b.UserID = csTransactions.ServerItems.UserID;
            b.Password = csTransactions.ServerItems.UserPW;
            return b.ConnectionString;
        }
        public SqlCommandBuilder RemoteUpdate_Tables(SqlDataAdapter Adaptor)
        {
            SqlCommandBuilder b = new SqlCommandBuilder(Adaptor);
            return b;
        }
        public static string RemoteConnectString()
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            b.DataSource = csTransactions.ServerItems.DataSource;
            b.IntegratedSecurity = false;
            b.MultipleActiveResultSets = true;
            b.UserID = csTransactions.ServerItems.UserID;
            b.Password = csTransactions.ServerItems.UserPW;
            return b.ConnectionString;
        }
        public List<string> GetIstanceName_ServerName()
        {
            var GetNames = new List<string>();
            try
            {
                RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    if (instanceKey != null)
                    {
                        foreach (var instanceName in instanceKey.GetValueNames())
                        {
                            GetNames.Add(Environment.MachineName + @"\" + instanceName);
                        }
                    }
                }
                return GetNames;
            }
            catch (FailedOperationException ex){ System.Windows.Forms.MessageBox.Show("Unkown Error" + ex.Message,"Unkown",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error); return null; }
        }
        public SqlConnection connection = new SqlConnection();
        public DataTable GetTables()
        {

            if (connection.State == ConnectionState.Open) { connection.Close(); }
            connection.Open();
            tables = connection.GetSchema("Tables");
            return tables;
        }
        public SqlConnection con = new SqlConnection();
        public DataTable GetRemoteTables()
        {
            var Table = new DataTable();
            if(con.State == ConnectionState.Open) { con.Close(); }
            con.Open();
            Table = con.GetSchema("Tables");
            return Table;
        }
        public string ChildNodeName { get; set; }
        public SqlCommand GetColumns()
        {
            if(connection.State == ConnectionState.Open) { connection.Close(); }
            connection.Open();
            var command = new SqlCommand("select * from [" + ChildNodeName + "] where 1 = 2", connection);
            return command;
        }
        public class CsRestoreDb
        {
            public string commandText { get; set; }
            System.Data.SqlClient.SqlCommand command;
            public System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();

            public System.Data.SqlClient.SqlCommand Restore()
            {
                if(this.connection.State == ConnectionState.Open) { this.connection.Close(); }
                this.connection.Open();
               command = new System.Data.SqlClient.SqlCommand(commandText,connection);
               return command;
            }
        }
        public class CsDeleteTable
        {
            public SqlConnection connection = new SqlConnection();
            public string commandText { get; set; }
            public SqlCommand com;
            public SqlCommand DeleteQuery()
            {
                if(connection.State == ConnectionState.Open) { this.connection.Close(); }
                connection.Open();
                com = new SqlCommand(commandText,connection);
                return com;
            }
        }
        public class CsNewDataBase
        {
            public SqlConnection connection = new SqlConnection();
            public string commandText { get; set; }
            public SqlCommand com;
            public SqlCommand NewDataBaseFunc()
            {
                if(connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();
                com = new SqlCommand(commandText,connection);
                return com;
            }
        }
        public class CsNewBackup
        {
            public string TxtName { get; set; }
            public string FileName { get; set; }
            public string DataBaseName { get; set; }
            public Microsoft.SqlServer.Management.Smo.Backup BackUp;
            public Microsoft.SqlServer.Management.Smo.Server srv;
            SqlCommand command;
            public Microsoft.SqlServer.Management.Smo.Backup BackupDb()
            {
                try
                {
                    if (csTransactions.ServerItems.ConnectName == "Local")
                    {
                        srv = new Server(ServerItems.svName);
                        BackUp = new Backup();
                        BackUp.Action = BackupActionType.Database;
                        BackUp.Database = this.DataBaseName;
                        BackUp.Devices.AddDevice(this.FileName, DeviceType.File);
                        BackUp.SqlBackup(srv);
                    }
                    if (csTransactions.ServerItems.ConnectName == "Remote")
                    {
                        SqlBackup sqlbak = new SqlBackup(csTransactions.RemoteConnectString_Tables(this.DataBaseName), this.FileName, true);
                        sqlbak.GetDBSize();
                        int fnum = sqlbak.CreateBakupFiles();
                        sqlbak.CreateTempDB();
                        for (int i = 0; i < fnum; i++)
                        {
                            sqlbak.InsertBakFile(i + 1);
                            sqlbak.DownloadBakFile(i + 1);
                            sqlbak.DeleteBakFile();
                        }
                        sqlbak.DeleteTempDB();
                        sqlbak.Dispose();
                    }
                    MinuteBackup.Current.MinuteLog("Database backup successfully completed date : " + timeClass.GetServerTime().ToString("yyyy-MM-dd-HH-mm-ss") + "\nDataBase Name : " + this.DataBaseName,this.TxtName);
                    return BackUp;
                }
                catch (Exception ex)
                {
                    MinuteBackup.Current.MinuteLog("database backup operation resulted in errors : " + ex.Message, this.TxtName); return null;
                }
            }
        }
    }
}
