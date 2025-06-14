using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GroupDAO
    {
        private static GroupDAO instance;
        public static GroupDAO Instance
        {
            get { if (instance == null) instance = new GroupDAO(); return instance; }
            private set { instance = value; }
        }
        private GroupDAO() { }
        public DataTable GetGroupsList()
        {
            string query = $"select * from Nhom";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetGroupsByDivisonId(string maBoPhan)
        {
            string query = $"select * from Nhom where maBoPhan = '{maBoPhan}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetDivisionByGroupId(string maNhom)
        {
            string query = "exec SP_LayPhongBanTheoMaNhom @maNhom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maNhom });
        }
        public bool AddGroup(Dictionary<string, object> parameters) 
        {
            return DataProvider.Instance.ExecuteStoredProcedure("SP_ThemNhom", parameters) > 0;
        }
    }
}
