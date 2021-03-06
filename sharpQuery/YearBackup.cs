﻿using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpQuery
{
    class YearBackup
    {
        private static YearBackup current;

        public static YearBackup Current
        {
            get { if (current == null) { current = new YearBackup(); } return current; }
            set { current = value; }
        }
        public YearBackup()
        {
            bgwBackupYear = new BackgroundWorker();
            bgwBackupYear.DoWork += BgwBackupYear_DoWork;
            bgwBackupYear.WorkerSupportsCancellation = true;

            YearTimer.Interval = 1;
            YearTimer.Enabled = false;
            YearTimer.Tick += DayTimer_Tick;

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
        public BackgroundWorker bgwBackupYear;
        csTransactions.CsNewBackup CNB = new csTransactions.CsNewBackup();
        public static int Year;
        public static int Month;
        public static int Day;
        public static int Hour;
        public static int Minute;
        public static int Second;
        public bool control = false;
        public void WriteYearDataBase(string DataBaseName)
        {
            string str = "\r\n" + DataBaseName;
            using (StreamWriter stream = new FileInfo(Application.StartupPath + @"\AutoBackup\YearDB.txt").AppendText())
            {
                stream.WriteLine(str);
            }
        }
        private void YearLog(string log)
        {
            using (StreamWriter sw = new FileInfo(Application.StartupPath + @"\AutoBackup\YearLog.txt").AppendText())
            {
                sw.WriteLine("\r\n" + log);
            }
        }
        public void ReadYearDataBase()
        {
            DataBases.Clear();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\YearDB.txt"))
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
        public System.Windows.Forms.Timer YearTimer = new System.Windows.Forms.Timer();
        private void DayTimer_Tick(object sender, EventArgs e)
        {
            if (!bgwBackupYear.IsBusy) { bgwBackupYear.RunWorkerAsync(); }
        }
        INIKaydet FAB = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
        public DateTime SettingsDate = new DateTime();
        public DateTime CurrentDate;
        TimeSpan TS;
        private void BgwBackupYear_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CurrentDate = DateTime.Now;
                if (control == false)
                {
                    string SettingsMonth = FAB.Oku("Year", "Tuned Year");
                    Year = Convert.ToInt16(SettingsMonth);
                    SettingsDate = CurrentDate.AddYears(Year);
                    control = true;
                }
                TS = SettingsDate - CurrentDate;
                Day = TS.Days;
                Hour = TS.Hours;
                Minute = TS.Minutes;
                Second = TS.Seconds;
                if (CurrentDate.Year == SettingsDate.Year && CurrentDate.Month == SettingsDate.Month && CurrentDate.Day == SettingsDate.Day && CurrentDate.Hour == SettingsDate.Hour && CurrentDate.Minute == SettingsDate.Minute && CurrentDate.Second == SettingsDate.Second)
                {
                    ReadYearDataBase();
                    foreach (string str in this.DataBases)
                    {
                        CNB.TxtName = "Year";
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
                string read = FAB.Oku("Month", "Tuned Month");
                Month = Convert.ToInt16(read);
            }
        }
        frmAutoBackup auto = new frmAutoBackup();
        public void BackupYearStart()
        {
            csTransactions.ServerItems.AutoBackupProcessName = "Year";
            YearTimer.Start();
        }
    }
}
