using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sharpQuery
{
    public static class csDataBase
    {
        public static string connectionString;
        public static SqlConnection connection = new SqlConnection()
        {
            ConnectionString = connectionString
        };
    }
}
