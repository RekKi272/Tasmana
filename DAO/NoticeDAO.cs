using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Security.Cryptography;
using System.Data;

namespace DAO
{
    public class NoticeDAO
    {
        private static NoticeDAO instance;
        public static NoticeDAO Instance
        {
            get { if (instance == null) instance = new NoticeDAO(); return instance; }
            private set { instance = value; }
        }
        private NoticeDAO() { }

        public bool AddNotice(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemThongBao", parameters);
            return result > 0;
        }
        public bool AddNoticeWithout(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemThongBaoWithout", parameters);
            return result > 0;
        }
        public bool AddNoticeTo(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemNguoiNhan", parameters);
            return result > 0;
        }
        public int GetSTT()
        {
            string query = $"SELECT MAX(stt) AS max_stt FROM Notice";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable GetNoticesPriority(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("GetNoticesPriority",parameters);
        }

        public DataTable GetAllNotices(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("GetAllNotices", parameters);
        }

        public DataTable GetNoticesSend(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("GetNoticesSend", parameters);
        }
    }
}
