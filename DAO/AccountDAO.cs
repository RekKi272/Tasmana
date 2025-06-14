using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool CheckAccountExistence(string userId)
        {
            string query = $"select * from TaiKhoan where maNguoiDung = '{userId}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public bool CheckAccountPasword(string userId, string password)
        {
            string query = $"select * from TaiKhoan where maNguoiDung = '{userId}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return password.Equals(result.Rows[0]["matKhau"].ToString());
        }
        public DataTable GetAccount(string userId)
        {
            string query = $"select * from TaiKhoan where maNguoiDung = '{userId}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetAccountByEmployeeId(string maNhanVien)
        {
            string query = $"select * from TaiKhoan where maNhanVien = '{maNhanVien}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool AddAccount(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_ThemTaiKhoan", parameters);
            return result > 0;
        }
        public bool UpdateAccount(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_SuaTaiKhoan", parameters);
            return result > 0;
        }
        public bool UpdatePassword(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_DoiMatKhau", parameters);
            return result > 0;
        }
        public bool UpdateRememberId(string maNguoiDung, bool remember)
        {
            int bit = 0;
            if (remember)
                bit = 1;
            string query = $"update TaiKhoan set rememberId = {bit} where maNguoiDung = '{maNguoiDung}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
