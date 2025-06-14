using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhuThuongMaiDAO
    {
        private static KhuThuongMaiDAO instance;
        public static KhuThuongMaiDAO Instance
        {
            get { if (instance == null) instance = new KhuThuongMaiDAO(); return instance; }
            private set { instance = value; }
        }
        private KhuThuongMaiDAO() { }
        public DataTable GetAllKhuThuongMai()
        {
            string query = $"select * from KhuThuongMai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetKhuThuongMaiById(string maKhuThuongMai)
        {
            string query = $"select * from KhuThuongMai where maCanHo = '{maKhuThuongMai}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateKhuThuongMai(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_CapNhatKhuThuongMai", parameters);
            return result > 0;
        }
        public bool DeleteKhuThuongMai(string maKhuThuongMai)
        {
            string query = $"exec SP_XoaKhuThuongMai @maCanHo = '{maKhuThuongMai}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
