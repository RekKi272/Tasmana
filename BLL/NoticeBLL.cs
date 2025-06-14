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
    public class NoticeBLL
    {
        private static NoticeBLL instance;
        public static NoticeBLL Instance
        {
            get { if (instance == null) instance = new NoticeBLL(); return instance; }
            private set { instance = value; }
        }
        private NoticeBLL() { }
        public bool AddNotice(Dictionary<string, object> parameters)
        {
            if (NoticeDAO.Instance.AddNotice(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddNoticeWithout(Dictionary<string, object> parameters)
        {
            if (NoticeDAO.Instance.AddNoticeWithout(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddNoticeTo(Dictionary<string, object> parameters)
        {
            if (NoticeDAO.Instance.AddNoticeTo(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetSTT()
        {
            return NoticeDAO.Instance.GetSTT();
        }

        public List<Notice> GetNoticesPriority(Dictionary<string, object> parameters)
        {
            DataTable dt = NoticeDAO.Instance.GetNoticesPriority(parameters);
            List<Notice> list = new List<Notice>();
            foreach (DataRow dr in dt.Rows)
            {
                int STT = (int)dr["stt"];
                string Title = dr["title"].ToString();
                string Content = dr["content"].ToString();
                DateTime Date = (DateTime)dr["dateN"];
                string Author = dr["author"].ToString();
                byte[] File = null;
                if (dr["fileN"] == System.DBNull.Value)
                    File = null;
                else
                    File = (byte[])dr["fileN"];
                string FileName = dr["nameFile"].ToString();
                string FileExten = dr["fileExten"].ToString();
                bool priority = (bool)dr["priority"];
                Notice notice = new Notice(STT, Title, Content, Date, Author, File, FileName, FileExten, priority);
                list.Add(notice);
            }
            return list;
        }

        public List<Notice> GetAllNotices(Dictionary<string, object> parameters)
        {
            DataTable dt = NoticeDAO.Instance.GetAllNotices(parameters);
            List<Notice> list = new List<Notice>();
            foreach (DataRow dr in dt.Rows)
            {
                int STT = (int)dr["stt"];
                string Title = dr["title"].ToString();
                string Content = dr["content"].ToString();
                DateTime Date = (DateTime)dr["dateN"];
                string Author = dr["author"].ToString();
                byte[] File = null;
                if (dr["fileN"] == System.DBNull.Value)
                    File = null;
                else
                    File = (byte[])dr["fileN"];
                string FileName = dr["nameFile"].ToString();
                string FileExten = dr["fileExten"].ToString();
                bool priority = (bool)dr["priority"];
                Notice notice = new Notice(STT, Title, Content, Date, Author, File, FileName, FileExten, priority);
                list.Add(notice);
            }
            return list;
        }

        public List<Notice> GetNoticesSend(Dictionary<string, object> parameters)
        {
            DataTable dt = NoticeDAO.Instance.GetNoticesSend(parameters);
            List<Notice> list = new List<Notice>();
            foreach (DataRow dr in dt.Rows)
            {
                int STT = (int)dr["stt"];
                string Title = dr["title"].ToString();
                string Content = dr["content"].ToString();
                DateTime Date = (DateTime)dr["dateN"];
                string Author = dr["author"].ToString();
                byte[] File = null;
                if (dr["fileN"] == System.DBNull.Value)
                    File = null;
                else
                    File = (byte[])dr["fileN"];
                string FileName = dr["nameFile"].ToString();
                string FileExten = dr["fileExten"].ToString();
                bool priority = (bool)dr["priority"];
                Notice notice = new Notice(STT, Title, Content, Date, Author, File, FileName, FileExten, priority);
                list.Add(notice);
            }
            return list;
        }
    }
}
