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
    class DayBackup
    {
        private static DayBackup current;

        public static DayBackup Current
        {
            get { if (current == null) { current = new DayBackup(); } return current; }
            set { current = value; }
        }
        public DayBackup()
        {
            DayTimer.Interval = 1;
            DayTimer.Enabled = false;
            DayTimer.Tick += DayTimer_Tick;

            bgwBackupDay = new BackgroundWorker();
            bgwBackupDay.DoWork += BgwBackupDay_DoWork;
            bgwBackupDay.WorkerSupportsCancellation = true;
        }
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
        public BackgroundWorker bgwBackupDay;
        csTransactions.CsNewBackup CNB = new csTransactions.CsNewBackup();
        public static int Day;
        public static int Hour;
        public static int Minute;
        public static int Second;
        public bool control = false;
        public void WriteDayDataBase(string DataBaseName)
        {
            string str = "\r\n" + DataBaseName;
            using (StreamWriter stream = new FileInfo(Application.StartupPath + @"\AutoBackup\DayDB.txt").AppendText())
            {
                stream.WriteLine(str);
            }
        }
        private void DayLog(string log)
        {
            using (StreamWriter sw = new FileInfo(Application.StartupPath + @"\AutoBackup\DayLog.txt").AppendText())
            {
                sw.WriteLine("\r\n" + log);
            }
        }
        public void ReadHourDataBase()
        {
            DataBases.Clear();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\DayDB.txt"))
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
        public Timer DayTimer = new Timer();
        private void DayTimer_Tick(object sender, EventArgs e)
        {
            if (!bgwBackupDay.IsBusy) { bgwBackupDay.RunWorkerAsync(); }
        }
        INIKaydet FAB = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
        public DateTime SettingsDate;
        public DateTime CurrentDate;
        TimeSpan TS;
        private void BgwBackupDay_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CurrentDate = DateTime.Now;
                if (control == false)
                {
                    string SettingsDay = FAB.Oku("Day", "Tuned Day");
                    Day = Convert.ToInt16(SettingsDay);
                    SettingsDate = CurrentDate.AddDays(Day);
                    control = true;
                }
                TS = SettingsDate - CurrentDate;
                Day = TS.Days;
                Hour = TS.Hours;
                Minute = TS.Minutes;
                Second = TS.Seconds;
                if (CurrentDate.Day == SettingsDate.Day &&CurrentDate.Hour == SettingsDate.Hour && CurrentDate.Minute == SettingsDate.Minute && CurrentDate.Second == SettingsDate.Second)
                {
                    ReadHourDataBase();
                    foreach (string str in this.DataBases)
                    {
                        CNB.TxtName = "Day";
                        CNB.FileName = "C:/temp/" + str + timeClass.GetServerTime().ToString("yyyy-MM-dd-HH-mm-ss") + ".bak";
                        CNB.DataBaseName = str;
                        if (csTransactions.ServerItems.ConnectName == "Local")
                        {
                            CNB.srv = new Server(csTransactions.ServerItems.svName);
                        }
                        CNB.BackupDb();
                    }
                    control = false;
                }
            }
            catch (Exception ex)
            {
                if (Second == 0 && Minute == 0)
                {
                    string read = FAB.Oku("Day", "Tuned Day");
                    Day = Convert.ToInt16(read);
                }
            }
        }
        frmAutoBackup auto = new frmAutoBackup();
        public void BackupDayStart()
        {
            csTransactions.ServerItems.AutoBackupProcessName = "Day";
            DayTimer.Start();
        }
    }
}
