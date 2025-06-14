using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;
        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set { instance = value; }
        }
        private AccountBLL() { }
        public bool CheckAccountExistence(string userId)
        {
            return AccountDAO.Instance.CheckAccountExistence(userId);
        }
        public bool CheckAccountPasword(string userId, string password)
        {
            return AccountDAO.Instance.CheckAccountPasword(userId, password);
        }
        public Account GetAccount(string userId)
        {
            DataTable dt = AccountDAO.Instance.GetAccount(userId);

            return new Account(userId, dt.Rows[0]["matKhau"].ToString(), dt.Rows[0]["maNhanVien"].ToString(), (bool)dt.Rows[0]["disable"], (bool)dt.Rows[0]["rememberId"]);
        }
        public bool AddAccount(Dictionary<string, object> parameters)
        {
            return AccountDAO.Instance.AddAccount(parameters);
        }
        public bool UpdateAccount(Dictionary<string, object> parameters)
        {
            return AccountDAO.Instance.UpdateAccount(parameters);
        }
        public string UpdatePassword(Dictionary<string, object> parameters)
        {
            if (AccountDAO.Instance.UpdatePassword(parameters))
            {
                return "Cập nhật mật khẩu thành công";
            }
            return "Cập nhật mật khẩu thất bại";
        }
        public bool UpdateRememberId(string maNguoiDung, bool remember)
        {
            return AccountDAO.Instance.UpdateRememberId(maNguoiDung, remember);
        }
    }
}
