using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachThueKhuThuongMaiDAO
    {
        private static KhachThueKhuThuongMaiDAO instance;
        public static KhachThueKhuThuongMaiDAO Instance
        {
            get { if (instance == null) instance = new KhachThueKhuThuongMaiDAO(); return instance; }
            private set { instance = value; }
        }
        private KhachThueKhuThuongMaiDAO() { }
        public DataTable GetKhachThueById(string maKhachDangThue)
        {
            string query = $"select * from KhachThueKhuThuongMai where maKhachDangThue = '{maKhachDangThue}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllKhachThue()
        {
            string query = $"select * from KhachThueKhuThuongMai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetKhachThueKTMByMaKhach(string maKhachDangThue)
        {
            string query = $"select * from KhachThueKhuThuongMai where maKhachDangThue = '{maKhachDangThue}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool AddKhachThueKTM(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_ThemKhachThueKTM", parameters);
            return result > 0;
        }
        public bool DeleteKhachThueKTM(string maKhachDangThue, string bienSo)
        {
            string query = $"exec XoaKhachThueKTM @maKhachDangThue = '{maKhachDangThue}', @bienSo = '{bienSo}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool UpdateKhachThueKTM(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SuaKhachThueKTM", parameters);
            return result > 0;
        }
    }
}
