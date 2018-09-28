using System;
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

namespace sharpQuery
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
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
        private void pnlUst_MouseMove(object sender, MouseEventArgs e)
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
        string metinTut;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FastColoredTextBoxNS.FastColoredTextBox rtb = frm.tabControl1.SelectedTab.Controls.Find("rtb", true)[0] as FastColoredTextBoxNS.FastColoredTextBox;
                rtb.Text = richTextBox1.Text;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public frmMain frm;
        string noReplace;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text.Contains("set")==false)
                {
                    int index = cmbColumn.SelectedIndex;
                    if(txtSet.Visible == true)
                    {
                        richTextBox1.Text += " set " + cmbColumn.SelectedItem.ToString() + " = '" + txtSet.Text + "', ";
                    }
                    if (dateTimePicker1.Visible == true)
                    {
                        richTextBox1.Text += " set " + cmbColumn.SelectedItem.ToString() + " = '" + dateTimePicker1.Value + "', ";
                    }
                    cmbColumn.Items.RemoveAt(index);
                }
                else
                {
                    int index = cmbColumn.SelectedIndex;
                    if (txtSet.Visible == true)
                    {
                        richTextBox1.Text += cmbColumn.SelectedItem.ToString() + " = '" + txtSet.Text + "', ";
                    }
                    if(dateTimePicker1.Visible == true)
                    {
                        richTextBox1.Text += cmbColumn.SelectedItem.ToString() + " = '" + dateTimePicker1.Value + "', ";
                    }
                    cmbColumn.Items.RemoveAt(index);
                }
                button3.Enabled = true;
            }
            catch { }
        }

        private void cmbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                csDataBase.connectionString = @"Data Source = " + frm.serverList.Text.ToString() + "; " + "Initial Catalog = " + label5.Text + "; " + "Integrated Security = True; ";
                csDataBase.connection.ConnectionString = csDataBase.connectionString;
                csDataBase.connection.Open();
                var command = new SqlCommand("select * from [" + lblColumnName.Text.ToString() + "] where 1 = 2", csDataBase.connection);
                var columns = new List<string>();
                using (var dr = command.ExecuteReader())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (dr.GetName(i).ToString() == cmbColumn.SelectedItem.ToString())
                        {
                            if (dr.GetDataTypeName(i).ToString() == "datetime" || dr.GetDataTypeName(i).ToString() == "date")
                            {
                                txtSet.Visible = false;
                                dateTimePicker1.Visible = true;
                            }
                            else
                            {
                                txtSet.Visible = true;
                                dateTimePicker1.Visible = false;
                            }
                            break;
                        }
                    }
                }
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null;
            }
            catch (Exception ex)
            {
                csDataBase.connection.Close();
                csDataBase.connectionString = null;
                csDataBase.connection.ConnectionString = null; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("where") == false)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 2);
            }
            this.Close();
        }
        public int deger = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (deger == 0)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 2);
                richTextBox1.Text += " where " + txtWhere.Text;
            }
            deger++;
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            lblColumnName.Visible = false;
        }
    }
}
