using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChuHoDAO
    {
        private static ChuHoDAO instance;
        public static ChuHoDAO Instance
        {
            get { if (instance == null) instance = new ChuHoDAO(); return instance; }
            private set { instance = value; }
        }
        private ChuHoDAO() { }
        public DataTable GetAllChuHo()
        {
            string query = $"select * from ChuHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetChuHoByApartmentId(string maCanHo)
        {
            string query = $"select * from ChuHo where maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetChuHoByMaCuDan(string maCuDan, string maCanHo)
        {
            string query = $"select * from ChuHo where maCuDan = '{maCuDan}' and maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool DeleteChuHo(string maCuDan, string bienSo)
        {
            string query = $"exec XoaChuHo @maCuDan = '{maCuDan}', @bienSo = '{bienSo}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool AddChuHo(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemChuHo", parameters);
            return result > 0;
        }
        public bool UpdateChuHo(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SuaChuHo", parameters);
            return result > 0;
        }
    }
}
