using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NguoiDcUyQuyenChuHoDAO
    {
        private static NguoiDcUyQuyenChuHoDAO instance;
        public static NguoiDcUyQuyenChuHoDAO Instance
        {
            get { if (instance == null) instance = new NguoiDcUyQuyenChuHoDAO(); return instance; }
            private set { instance = value; }
        }
        private NguoiDcUyQuyenChuHoDAO() { }
        public DataTable GetAllNguoiUyQuyen()
        {
            string query = "select * from NguoiDcUyQuyenChuHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetNguoiUyQuyenByMaCuDan(string maCuDan, string maCanHo)
        {
            string query = $"select * from NguoiDcUyQuyenChuHo where maCuDan = '{maCuDan}' and maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool DeleteNguoiUyQuyen(string maCuDan, string bienSo)
        {
            string query = $"exec XoaNguoiUyQuyen @maCuDan = '{maCuDan}', @bienSo = '{bienSo}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool AddNguoiUyQuyen(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemNguoiUyQuyen", parameters);
            return result > 0;
        }
        public bool UpdateNguoiUyQuyen(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SuaNguoiUyQuyen", parameters);
            return result > 0;
        }
    }
}
