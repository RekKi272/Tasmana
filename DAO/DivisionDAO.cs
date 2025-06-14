using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DivisionDAO
    {
        private static DivisionDAO instance;
        public static DivisionDAO Instance
        {
            get { if (instance == null) instance = new DivisionDAO(); return instance; }
            private set { instance = value; }
        }
        private DivisionDAO() { }
        public DataTable GetAllDivision()
        {
            string query = "select * from PhongBan";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetDivisionByEmployeeId(string maNhanVien)
        {
            string query = "exec SP_LayPhongBanTheoMaNhanVien @maNhanVien";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maNhanVien });
        }
        public bool EditDivision(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_EditPhongBan", parameters);
            return result > 0;
        }
    }
}
