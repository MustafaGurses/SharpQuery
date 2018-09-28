using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpQuery
{
    public partial class frmAutoBackup : Form
    {
        private static frmAutoBackup current;

        public static frmAutoBackup Current
        {
            get { if (current == null) { current = new frmAutoBackup(); } return current; }
            set { current = value; }
        }
        public frmAutoBackup()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public string metin { get; set; }
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
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
        public int ControlDbLength { get; set; }
        private void ControlDataBaseName(string SettingsName, string DataBaseName)
        {
            try
            {
                var DataBases = new List<string>();
                DataBases.Clear();
                ControlDbLength = 0;
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\"+SettingsName+"DB.txt"))
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
                    foreach (string str in DataBases)
                    {
                        if (str == DataBaseName)
                        {
                            ControlDbLength++;
                        }
                    }
                }
            }
            catch { }
        }
        private void WriteDataBaseToList(string TxTName,string DataBaseName)
        {
            string str = "\r\n" + DataBaseName;
            using (StreamWriter stream = new FileInfo(Application.StartupPath + @"\AutoBackup\"+TxTName+"DB.txt").AppendText())
            {
                stream.WriteLine(str);
            }
        }
        private void serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSettings.SelectedItem.ToString())
            {
                case "Minute":
                    gbMinute.Enabled = true;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Hour":
                    gbHour.Enabled = true;
                    gbMinute.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Day":
                    gbDay.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Month":
                    gbMonth.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Year":
                    gbYear.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    break;
                case "Dakika":
                    gbMinute.Enabled = true;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Saat":
                    gbHour.Enabled = true;
                    gbMinute.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Gün":
                    gbDay.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbMonth.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Ay":
                    gbMonth.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbYear.Enabled = false;
                    break;
                case "Yıl":
                    gbYear.Enabled = true;
                    gbMinute.Enabled = false;
                    gbHour.Enabled = false;
                    gbDay.Enabled = false;
                    gbMonth.Enabled = false;
                    break;
            }
        }
        private int dupMinuteValue { get; set; }
        private int dupHourValue { get; set; }
   
        private void button4_Click(object sender, EventArgs e)
        {
            MinuteBackup.Current.control = false;
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            dupMinuteValue = Convert.ToInt16(dupMinute.Text);
            AutoSettings.Yaz("Auto", "Auto Settings", "Minute");
            Auto.Yaz("Minute", "Tuned Minute", dupMinuteValue.ToString());
            rtbLog.Text += "\nThe settings is saved, process is started.\n";
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Hour":
                    HourBackup.Current.HourTimer.Stop();
                    break;
                case "Day":
                    DayBackup.Current.DayTimer.Stop();
                    break;
                case "Month":
                    MonthBackup.Current.DayTimer.Stop();
                    break;
                case "Year":
                    YearBackup.Current.YearTimer.Stop();
                    break;
            }
            if (MinuteBackup.Current.MinuteTimer.Enabled == false)
            {
                MinuteBackup.Current.BackupMinute();
            }
        }
        public frmMain frm;
        private void frmAutoBackup_Load(object sender, EventArgs e)
        {
            tmrControl.Start();
            tmrReadDB.Start();
            lblRemTime.Visible = true;
            lbDataBase.Visible = true;
            if(frmMain.dil == "Turkish")
            {
                groupBox1.Text = "  Ayarlar  ";
                label5.Text = "Dakika : ";
                label6.Text = "Saat : ";
                label7.Text = "Gün : ";
                label8.Text = "Ay : ";
                label9.Text = "Yıl : ";
                label10.Text = "İşlem şuanki dakikadan\nbaşlar.";
                label11.Text = "İşlem şuanki saatten\nbaşlar.";
                label12.Text = "İşlem şuanki günden\nbaşlar.";
                label13.Text = "İşlem şuanki aydan\nbaşlar.";
                label14.Text = "İşlem şuanki yıldan\nbaşlar.";
                lblSupport.Text = "Kalan zaman görünümü: Tarih\nDesteklemez: Dakika ve Saat";
                gbMinute.Text = "Dakika";
                gbHour.Text = "Saat";
                gbDay.Text = "Gün";
                gbMonth.Text = "Ay";
                gbYear.Text = "Yıl";
                cmbSettings.Items.Clear();
                cmbSettings.Items.Add("Dakika");
                cmbSettings.Items.Add("Saat");
                cmbSettings.Items.Add("Gün");
                cmbSettings.Items.Add("Ay");
                cmbSettings.Items.Add("Yıl");
                label3.Text = "Kayıt";
                label4.Text = "Kalan Zaman : ";
                label2.Text = "Veritabanı : ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public string SettingsTime { get; set; }
        public bool control = false;
        public int Hour { get; set; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bgwControlDate.IsBusy) { bgwControlDate.RunWorkerAsync(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HourBackup.Current.control = false;
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            dupHourValue = Convert.ToInt16(dupHour.Text);
            AutoSettings.Yaz("Auto", "Auto Settings", "Hour");
            Auto.Yaz("Hour", "Tuned Hour", dupHourValue.ToString());
            rtbLog.Text += "\nThe settings is saved, process is started.\n";
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Minute":
                    MinuteBackup.Current.MinuteTimer.Stop();
                    break;
                case "Day":
                    DayBackup.Current.DayTimer.Stop();
                    break;
                case "Month":
                    MonthBackup.Current.DayTimer.Stop();
                    break;
                case "Year":
                    YearBackup.Current.YearTimer.Stop();
                    break;
            }
            if (HourBackup.Current.HourTimer.Enabled == false)
            {
                HourBackup.Current.BackupHourStart();
            }
        }
        DateTime CurrentDate = DateTime.Now;
        DateTime SettingsDate = DateTime.Now;
        TimeSpan TS;
        public int ReadAutoDate { get; set; }
        private static bool Control = false;
        private DateTime TargetDate = DateTime.Now;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            SettingsTime = AutoSettings.Oku("Auto", "Auto Settings");
            switch (SettingsTime)
            {
                case "Minute":
                    lblRemTime.Text = MinuteBackup.Minute.ToString() + " : " + MinuteBackup.Second.ToString();
                    break;
                case "Hour":
                    lblRemTime.Text = HourBackup.Hour.ToString() + " : " + HourBackup.Minute.ToString() + " : " + HourBackup.Second.ToString();
                    break;
                case "Day":
                    if (changeCheck.Checked == true)
                    {
                        if (control == false)
                        {
                            ReadAutoDate = Convert.ToInt16(Auto.Oku("Day", "Tuned Day"));
                            TargetDate = DateTime.Now.AddDays(ReadAutoDate);
                            control = true;
                        }
                        if(control == true)
                        {
                            lblRemTime.Text = "Target Date : " + TargetDate.ToString();
                        }
                    }
                    if (changeCheck.Checked == false)
                    {
                        lblRemTime.Text = DayBackup.Day.ToString() + " : " + DayBackup.Hour.ToString() + " : " + DayBackup.Minute.ToString() + " : " + DayBackup.Second.ToString();
                        control = false;
                    }
                    break;
                case "Month":
                    if (changeCheck.Checked == true)
                    {
                        if (control == false)
                        {
                            ReadAutoDate = Convert.ToInt16(Auto.Oku("Month", "Tuned Month"));
                            TargetDate = DateTime.Now.AddMonths(ReadAutoDate);
                            control = true;
                        }
                        if(control == true)
                        {
                            lblRemTime.Text = "Target Date : " + TargetDate.ToString();
                        }
                    }
                    if (changeCheck.Checked == false)
                    {
                        lblRemTime.Text = MonthBackup.Day.ToString() + " : " + MonthBackup.Hour.ToString() + " : " + MonthBackup.Minute.ToString() + " : " + MonthBackup.Second.ToString();
                        control = false;
                    }
                    break;
                case "Year":
                    if(changeCheck.Checked == true)
                    {
                        if (control == false)
                        {
                            ReadAutoDate = Convert.ToInt16(Auto.Oku("Year", "Tuned Year"));
                            TargetDate =  DateTime.Now.AddYears(ReadAutoDate);
                            control = true;
                        }
                        if(control == true)
                        {
                            lblRemTime.Text = "Target Date : " + TargetDate.ToString();
                        }
                    }
                    if(changeCheck.Checked == false)
                    {
                        lblRemTime.Text = YearBackup.Day.ToString() + " : " + YearBackup.Hour.ToString() + " : " + YearBackup.Minute.ToString() + " : " + YearBackup.Second.ToString();
                        control = false;
                    }
                    break;
            }
        }
        public int dupDayValue { get; set; }
        private void button6_Click(object sender, EventArgs e)
        {
            DayBackup.Current.control = false;
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            dupDayValue = Convert.ToInt16(dupDay.Text);
            AutoSettings.Yaz("Auto", "Auto Settings", "Day");
            Auto.Yaz("Day", "Tuned Day", dupDayValue.ToString());
            rtbLog.Text += "\nThe settings is saved, process is started.\n";
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Minute":
                    MinuteBackup.Current.MinuteTimer.Stop();
                    break;
                case "Hour":
                    HourBackup.Current.HourTimer.Stop();
                    break;
                case "Month":
                    MonthBackup.Current.DayTimer.Stop();
                    break;
                case "Year":
                    YearBackup.Current.YearTimer.Stop();
                    break;
            }
            if(DayBackup.Current.DayTimer.Enabled == false)
            {
                DayBackup.Current.BackupDayStart();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MonthBackup.Current.control = false;
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            dupDayValue = Convert.ToInt16(dupMonth.Text);
            AutoSettings.Yaz("Auto", "Auto Settings", "Month");
            Auto.Yaz("Month", "Tuned Month", dupDayValue.ToString());
            rtbLog.Text += "\nThe settings is saved, prcoess is started.\n";
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Minute":
                    MinuteBackup.Current.MinuteTimer.Stop();
                    break;
                case "Hour":
                    HourBackup.Current.HourTimer.Stop();
                    break;
                case "Day":
                    DayBackup.Current.DayTimer.Stop();
                    break;
                case "Year":
                    YearBackup.Current.YearTimer.Stop();
                    break;
            }
            if (MonthBackup.Current.DayTimer.Enabled == false)
            {
                MonthBackup.Current.BackupMonthStart();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            switch (changeCheck.Checked)
            {
                case false:
                    changeCheck.Checked = true;
                    break;
                case true:
                    changeCheck.Checked = false;
                    break;
            }
        }
        public int dupYearValue { get; set; }
        private void button8_Click(object sender, EventArgs e)
        {
            YearBackup.Current.control = false;
            INIKaydet Auto = new INIKaydet(Application.StartupPath + @"\AutoBackup\Auto.ini");
            INIKaydet AutoSettings = new INIKaydet(Application.StartupPath + @"\AutoBackup\AutoSettings.ini");
            dupYearValue = Convert.ToInt16(dupYear.Text);
            AutoSettings.Yaz("Auto", "Auto Settings", "Year");
            Auto.Yaz("Year", "Tuned Year", dupYearValue.ToString());
            rtbLog.Text += "\nThe settings is saved, process started\n";
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Minute":
                    MinuteBackup.Current.MinuteTimer.Stop();
                    break;
                case "Hour":
                    HourBackup.Current.HourTimer.Stop();
                    break;
                case "Day":
                    DayBackup.Current.DayTimer.Stop();
                    break;
                case "Month":
                    MonthBackup.Current.DayTimer.Stop();
                    break;
            }
            if (YearBackup.Current.YearTimer.Enabled == false)
            {
                YearBackup.Current.BackupYearStart();
            }
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(int index in checkedListBox1.CheckedIndices)
            {
                ControlDataBaseName("Minute", checkedListBox1.Items[index].ToString());
                if (ControlDbLength > 0)
                {
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' already exists on list : MinuteDB.txt\n";
                }
                if(ControlDbLength == 0)
                {
                    WriteDataBaseToList("Minute", checkedListBox1.Items[index].ToString());
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' added to list : MinuteDB.txt\n";
                }
            }
            for(int i=0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void hourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(int index in checkedListBox1.CheckedIndices)
            {
                ControlDataBaseName("Hour", checkedListBox1.Items[index].ToString());
                if (ControlDbLength > 0)
                {
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' already exists on list : HourDB.txt";
                }
                if (ControlDbLength == 0)
                {
                    WriteDataBaseToList("Hour", checkedListBox1.Items[index].ToString());
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' added to list : HourDB.txt";
                }
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                ControlDataBaseName("Day", checkedListBox1.Items[index].ToString());
                if (ControlDbLength > 0)
                {
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' already exists on list : DayDB.txt";
                }
                if (ControlDbLength == 0)
                {
                    WriteDataBaseToList("Day", checkedListBox1.Items[index].ToString());
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' added to list : DayDB.txt";
                }
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void monthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                ControlDataBaseName("Month", checkedListBox1.Items[index].ToString());
                if (ControlDbLength > 0)
                {
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' already exists on list : MonthDB.txt";
                }
                if (ControlDbLength == 0)
                {
                    WriteDataBaseToList("Month", checkedListBox1.Items[index].ToString());
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' added to list : MonthDB.txt";
                }
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void yearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                ControlDataBaseName("Year", checkedListBox1.Items[index].ToString());
                if (ControlDbLength > 0)
                {
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' already exists on list : YearDB.txt";
                }
                if (ControlDbLength == 0)
                {
                    WriteDataBaseToList("Year", checkedListBox1.Items[index].ToString());
                    rtbLog.Text += "\nDataBase : '" + checkedListBox1.Items[index].ToString() + "' added to list : YearDB.txt";
                }
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void tmrReadDB_Tick(object sender, EventArgs e)
        {
            const Int32 BufferSize = 128;
            switch (csTransactions.ServerItems.AutoBackupProcessName)
            {
                case "Minute":
                    lbDataBase.Text = "";
                    using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\MinuteDB.txt"))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 2)
                            {
                                lbDataBase.Text += " " + line;
                            }
                        }
                    }
                    break;
                case "Hour":
                    lbDataBase.Text = "";
                    using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\HourDB.txt"))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 2)
                            {
                                lbDataBase.Text += " " + line;
                            }
                        }
                    }
                    break;

                case "Day":
                    lbDataBase.Text = "";
                    using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\DayDB.txt"))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 2)
                            {
                                lbDataBase.Text += " " + line;
                            }
                        }
                        tmrReadDB.Stop();
                    }
                    break;
                case "Month":
                    lbDataBase.Text = "";
                    using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\MonthDB.txt"))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 2)
                            {
                                lbDataBase.Text += " " + line;
                            }
                        }
                    }
                    break;
                case "Year":
                    lbDataBase.Text = "";
                    using (var fileStream = File.OpenRead(Application.StartupPath + @"\AutoBackup\YearDB.txt"))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 2)
                            {
                                lbDataBase.Text += " " + line;
                            }
                        }
                    }
                    break;
                default:
                    lbDataBase.Text = "Waiting. . .";
                    break;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }
    }
}
