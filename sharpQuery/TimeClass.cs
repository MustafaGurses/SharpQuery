using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace sharpQuery
{
    internal class timeClass
    {
        public static DateTime GetServerTime()
        {
            DateTime now = DateTime.Now;
            string[] strArray = new string[] { "time-c.nist.gov", "time-d.nist.gov", "nist1-macon.macon.ga.us", "wolfnisttime.com", "nist.netservicesgroup.com", "nisttime.carsoncity.k12.mi.us", "nist1-lnk.binary.net", "wwv.nist.gov", "time.nist.gov", "utcnist.colorado.edu", "utcnist2.colorado.edu", "nist-time-server.eoni.com", "nist-time-server.eoni.com" };
            Random rnd = new Random();
            foreach (string str in (from x in strArray
                                    orderby rnd.NextDouble()
                                    select x).Take<string>(9))
            {
                try
                {
                    string str2 = string.Empty;
                    TcpClient client = new TcpClient();
                    if (client.ConnectAsync(str, 13).Wait(0x3e8))
                    {
                        using (StreamReader reader = new StreamReader(client.GetStream()))
                        {
                            str2 = reader.ReadToEnd();
                        }
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        string[] strArray2 = str2.Split(new char[] { ' ' });
                        if (strArray2.Length >= 6)
                        {
                            string str3 = strArray2[5];
                            if (str3 == "0")
                            {
                                string[] strArray3 = strArray2[1].Split(new char[] { '-' });
                                string[] strArray4 = strArray2[2].Split(new char[] { ':' });
                                DateTime time2 = new DateTime(Convert.ToInt32(strArray3[0]) + 0x7d0, Convert.ToInt32(strArray3[1]), Convert.ToInt32(strArray3[2]), Convert.ToInt32(strArray4[0]), Convert.ToInt32(strArray4[1]), Convert.ToInt32(strArray4[2]));
                                return time2.ToLocalTime();
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            return now;
        }

        public DateTime guncelSaat() =>
            GetServerTime();
    }
}
