using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ResidentDAO
    {
        private static ResidentDAO instance;
        public static ResidentDAO Instance
        {
            get { if (instance == null) instance = new ResidentDAO(); return instance; }
            private set { instance = value; }
        }
        private ResidentDAO() { }
        public DataTable GetResidentByResidentId(string maCuDan)
        {
            string query = $"select * from CuDan where maCuDan = '{maCuDan}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllResidentID()
        {
            string query = $"select * from CuDan";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Lấy cư dân có quốc tịch không phải VN
        public DataTable GetAllForeignNational()
        {
            string query = "EXEC ThongKeCuDanNguocNgoai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Lấy cư dân có quốc tịch Việt Nam
        public DataTable GetVietResidents()
        {
            string query = "EXEC ThongKeCuDanVietNam";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable CheckMaCuDan(string maCuDan)
        {
            string query = $"DECLARE @exists BIT; EXEC [dbo].[KiemTraTrungMaCuDan] @maCuDan = '{maCuDan}', @exists = @exists OUTPUT; SELECT @exists AS exists_flag;";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool AddCuDan(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("AddCuDan", parameters);
            return result > 0;
        }

        public bool DeleteCuDan(string maCuDan)
        {
            string query = $"exec DeleteCuDan @maCuDan = '{maCuDan}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
