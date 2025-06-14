using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Diagnostics;
using System.Data;

namespace BLL
{
    public class LichSuGiaoDichBLL
    {
        private static LichSuGiaoDichBLL instance;
        public static LichSuGiaoDichBLL Instance
        {
            get { if (instance == null) instance = new LichSuGiaoDichBLL(); return instance; }
            private set { instance = value; }
        }
        private LichSuGiaoDichBLL() { }
        public LichSuGiaoDich GetLichSuByApartmentId(string maCanHo)
        {
            DataTable dt = LichSuGiaoDichDAO.Instance.GetLichSuByApartmenId(maCanHo);
            if (dt.Rows.Count == 0) return null;

            string maCuDanHienTai = dt.Rows[0]["maCuDanHienTai"] != DBNull.Value
            ? dt.Rows[0]["maCuDanHienTai"].ToString()
            : string.Empty;

            string maCuDanTruoc = dt.Rows[0]["maCuDanTruoc"] != DBNull.Value
                ? dt.Rows[0]["maCuDanTruoc"].ToString()
                : string.Empty;
            string maKhachDangThue = dt.Rows[0]["maKhachDangThue"] != DBNull.Value
                ? dt.Rows[0]["maKhachDangThue"].ToString()
                : string.Empty;
            DateTime lichSuNopPhiDichVu = (DateTime)dt.Rows[0]["lichSuNopPhiDV"];
            DateTime lichSuDangKyDoXe = (DateTime)dt.Rows[0]["lichSuDangKyDoXe"];
            int tinhTrangCongNo = (int)dt.Rows[0]["tinhTrangCongNo"];
            return new LichSuGiaoDich(maCanHo, maCuDanHienTai, maCuDanTruoc, maKhachDangThue, lichSuNopPhiDichVu, lichSuDangKyDoXe, tinhTrangCongNo);
        }
    }
}
