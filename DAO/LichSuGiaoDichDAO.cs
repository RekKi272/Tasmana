using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;

namespace DAO
{
    public class LichSuGiaoDichDAO
    {
        private static LichSuGiaoDichDAO instance;
        public static LichSuGiaoDichDAO Instance
        {
            get { if (instance == null) instance = new LichSuGiaoDichDAO(); return instance; }
            private set { instance = value; }
        }
        private LichSuGiaoDichDAO() { }
        public DataTable GetLichSuByApartmenId(string maCanHo)
        {
            string query = $"select * from LichSuGiaoDich where maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
