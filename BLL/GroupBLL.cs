using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GroupBLL
    {
        private static GroupBLL instance;
        public static GroupBLL Instance
        {
            get { if (instance == null) instance = new GroupBLL(); return instance; }
            private set { instance = value; }
        }
        private GroupBLL() { }
        public List<Group> GetGroupListByDivisionId(string maBoPhan)
        {
            DataTable dt = GroupDAO.Instance.GetGroupsByDivisonId(maBoPhan);
            List<Group> groups = new List<Group>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maNhom = dt.Rows[i]["maNhom"].ToString();
                string maTruongNhom = dt.Rows[i]["maTruongNhom"].ToString();
                Group group = new Group(maNhom, maTruongNhom, maBoPhan);
                groups.Add(group);
            }
            return groups;
        }

        public Division GetDivsionByGroupId(string maNhom)
        {
            DataTable dt = GroupDAO.Instance.GetDivisionByGroupId(maNhom);
            string maBoPhan = dt.Rows[0]["maBoPhan"].ToString();
            string tenBoPhan = dt.Rows[0]["tenPB"].ToString();
            string soDienThoai = dt.Rows[0]["SDT"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            Division division = new Division(maBoPhan, tenBoPhan, soDienThoai, email);
            return division;
        }

        public bool AddGroup(Dictionary<string, object> parameters)
        {
            return GroupDAO.Instance.AddGroup(parameters);
        }
        public List<Group> GetGroupsList()
        {
            DataTable dt = GroupDAO.Instance.GetGroupsList();
            List<Group> groups = new List<Group>();
            foreach (DataRow dr in dt.Rows)
            {
                string MaNhom = dr["maNhom"].ToString();
                string MaTruongNhom = dr["maTruongNhom"].ToString();
                string maBoPhan = dr["maBoPhan"].ToString();
                Group gr = new Group(MaNhom, MaTruongNhom, maBoPhan);
                groups.Add(gr);
            }
            return groups;
        }

    }
}
