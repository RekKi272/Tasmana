using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BLL
{
    public class DivisionBLL
    {
        private static DivisionBLL instance;
        public static DivisionBLL Instance
        {
            get { if (instance == null) instance = new DivisionBLL(); return instance; }
            private set { instance = value; }
        }
        private DivisionBLL() { }
        public List<Division> GetDivisionList()
        {
            DataTable dt = DivisionDAO.Instance.GetAllDivision();
            List<Division> divisions = new List<Division>();

            for (int i = 0; i <  dt.Rows.Count; i++)
            {
                string maBoPhan = dt.Rows[i]["maBoPhan"].ToString();
                string tenBoPhan = dt.Rows[i]["tenPB"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                Division division = new Division(maBoPhan, tenBoPhan, soDienThoai, email);
                divisions.Add(division);
            }

            return divisions;
        }
        public DataTable GetAllDivision()
        {
            return DivisionDAO.Instance.GetAllDivision();
        }
        public Division GetDivisionByEmployeeId(string maNhanVien)
        {
            DataTable dt = DivisionDAO.Instance.GetDivisionByEmployeeId(maNhanVien);
            if(dt.Rows.Count > 0)
            {
                string maBoPhan = dt.Rows[0]["maBoPhan"].ToString();
                string tenBoPhan = dt.Rows[0]["tenPB"].ToString();
                string soDienThoai = dt.Rows[0]["SDT"].ToString();
                string email = dt.Rows[0]["email"].ToString();
                return new Division(maBoPhan, tenBoPhan, soDienThoai, email);
            }
            return null;
        }
        public bool EditDivision(Dictionary<string, object> parameters)
        {
            return DivisionDAO.Instance.EditDivision(parameters);
        }
    }
}
