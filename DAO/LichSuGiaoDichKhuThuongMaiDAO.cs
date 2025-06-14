using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LichSuGiaoDichKhuThuongMaiDAO
    {
        private static LichSuGiaoDichKhuThuongMaiDAO instance;
        public static LichSuGiaoDichKhuThuongMaiDAO Instance
        {
            get { if (instance == null) instance = new LichSuGiaoDichKhuThuongMaiDAO(); return instance; }
            private set { instance = value; }
        }
        private LichSuGiaoDichKhuThuongMaiDAO() { }
        public DataTable GetLichSuByKhuThuongMaiId(string maCanHo)
        {
            string query = $"select * from LichSuGiaoDichKhuThuongMai where maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
