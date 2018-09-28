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
    class HourBackup
    {
        private static HourBackup current;

        public static HourBackup Current
        {
            get { if (current == null) { current = new HourBackup(); } return current; }
            set { current = value; }
        }
        public HourBackup()
        {
            HourTimer.Interval = 1;
            HourTimer.Enabled = false;
            HourTimer.Tick += HourTimer_Tick;

            bgwBackupHour.DoWork += BgwBackupHour_DoWork;
            bgwBackupHour.WorkerSupportsCancellation = true;
        }
        frmAutoBackup auto = new frmAutoBackup();
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
        List<string> DataBases = new List<string>();
        public BackgroundWorker bgwBackupHour = new BackgroundWorker();
        csTransactions.CsNewBackup CNB = new csTransactions.CsNewBackup();
        public static int Hour;
        public static int Minute;
        public static int Second;
        public bool control = false;
        public void WriteHourDataBase(string DataBaseName)
        {
            string str = "\r\n" + DataBaseName;
            using (StreamWriter stream = new FileInfo(Application.StartupPath + @"\AutoBackup\HourDB.txt").AppendText())
            {
                stream.WriteLine(str);
            }
        }
        private void HourLog(string log)
        {
            using (StreamWriter sw = new FileInfo(Application.StartupPath + @"\AutoBackup\HourLog.txt").AppendText())
            {
                sw.WriteLine("\r\n" + log);
            }
        }
        public void ReadHourDataBase()
        {
            DataBases.Clear();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\HourDB.txt"))
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
        public Timer HourTimer = new Timer();
        private void HourTimer_Tick(object sender, EventArgs e)
        {
            if (!bgwBackupHour.IsBusy) { bgwBackupHour.RunWorkerAsync(); }
        }

        INIKaydet FAB = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
        DateTime SettingsDate = new DateTime();
        DateTime CurrentDate = new DateTime();
        TimeSpan TS = new TimeSpan();
        private void BgwBackupHour_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CurrentDate = DateTime.Now;
                if (control == false)
                {
                    string SettingsHour = FAB.Oku("Hour", "Tuned Hour");
                    Hour = Convert.ToInt16(SettingsHour); 
                    SettingsDate = CurrentDate.AddHours(Hour);
                    control = true;
                }
                TS = SettingsDate - CurrentDate;
                Hour = TS.Hours;
                Minute = TS.Minutes;
                Second = TS.Seconds;
                if (CurrentDate.Hour == SettingsDate.Hour && CurrentDate.Minute == SettingsDate.Minute && CurrentDate.Second == SettingsDate.Second)
                {
                    ReadHourDataBase();
                    foreach (string str in this.DataBases)
                    {
                        CNB.TxtName = "Hour";
                        CNB.FileName = "C:/temp/" + str + timeClass.GetServerTime().ToString("yyyy-MM-dd-HH-mm-ss") + ".bak";
                        CNB.DataBaseName = str;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            CNB.srv = new Server(csTransactions.ServerItems.svName);
                        }
                        CNB.BackupDb();
                        string ReadHour = FAB.Oku("Hour", "Tuned Hour");
                        Hour = Convert.ToInt16(ReadHour);
                    }
                    control = false;
                }
            }
            catch (Exception ex)
            {
                string read = FAB.Oku("Hour", "Tuned Hour");
                Hour = Convert.ToInt16(read);
            }
        }
        public void BackupHourStart()
        {
            csTransactions.ServerItems.AutoBackupProcessName = "Hour";
            HourTimer.Start();
        }
    }
}
