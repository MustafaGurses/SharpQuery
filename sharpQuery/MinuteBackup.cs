using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace sharpQuery
{
    public class MinuteBackup
    {
        private static MinuteBackup current;

        public static MinuteBackup Current
        {
            get { if (current == null) { current = new MinuteBackup(); } return current; }
            set { current = value; }
        }
        public MinuteBackup()
        {
            bgwBackupMinute.DoWork += BgwBackupMinute_DoWork;
            bgwBackupMinute.WorkerSupportsCancellation = true;

            MinuteTimer.Interval = 1000;
            MinuteTimer.Enabled = false;
            MinuteTimer.Tick += MinuteTimer_Tick;
        }
        public BackgroundWorker bgwBackupMinute = new BackgroundWorker();
        public Timer MinuteTimer = new Timer();
        csTransactions.CsNewBackup CNB = new csTransactions.CsNewBackup();
        List<string> DataBases = new List<string>();
        public static int Minute { get; set; }
        public static int Second = 0;
        public int LastMinute { get; set; }

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
        public void WriteMinuteDataBase(string DataBaseName)
        {
            string str = "\r\n"+DataBaseName;
            using (StreamWriter stream = new FileInfo(Application.StartupPath + @"\AutoBackup\MinuteDB.txt").AppendText())
            {
                stream.WriteLine(str);
            }
        }
        public void ReadMinuteDataBase()
        {
            DataBases.Clear();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\MinuteDB.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length > 2)
                    {
                        DataBases.Add(line);
                    }
                }
            }
        }
        DateTime CurrentDate = new DateTime();
        DateTime SettingsDate = new DateTime();
        public bool control = false;
        TimeSpan TS = new TimeSpan();
        private void BgwBackupMinute_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CurrentDate = DateTime.Now;
                if (control == false)
                {
                    string SettingsHour = FAB.Oku("Minute", "Tuned Minute");
                    Minute = Convert.ToInt16(SettingsHour);
                    SettingsDate = CurrentDate.AddMinutes(Minute);
                    control = true;
                }
                TS = SettingsDate - CurrentDate;
                Minute = TS.Minutes;
                Second = TS.Seconds;
                if (CurrentDate.Minute == SettingsDate.Minute && CurrentDate.Second == SettingsDate.Second)
                {
                    ReadMinuteDataBase();
                    foreach (string str in this.DataBases)
                    {
                        CNB.TxtName = "Minute";
                        CNB.FileName = "C:/temp/" + str + timeClass.GetServerTime().ToString("yyyy-MM-dd-HH-mm-ss") + ".bak";
                        CNB.DataBaseName = str;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            CNB.srv = new Server(csTransactions.ServerItems.svName);
                        }
                        CNB.BackupDb();
                        string ReadMinute = FAB.Oku("Minute", "Tuned Minute");
                        Minute = Convert.ToInt16(ReadMinute);
                    }
                    control = false;
                }
            }
            catch (Exception ex)
            {
                string read = FAB.Oku("Minute", "Tuned Minute");
                Minute = Convert.ToInt16(read);
                control = false;
            }
        }

        public void MinuteLog(string log,string txtName)
        {
            using (StreamWriter sw = new FileInfo(Application.StartupPath + @"\AutoBackup\"+txtName+"Log.txt").AppendText())
            {
                sw.WriteLine("\r\n"+log);
            }
        }
        INIKaydet FAB = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
        private void MinuteTimer_Tick(object sender, EventArgs e)
        {
            if (!bgwBackupMinute.IsBusy)
            {
                bgwBackupMinute.RunWorkerAsync();
            }
        }
        frmAutoBackup auto = new frmAutoBackup();
        public void BackupMinute()
        {
            csTransactions.ServerItems.AutoBackupProcessName = "Minute";
            MinuteTimer.Start();
        }
    }
}
