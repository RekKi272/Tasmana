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
    public class LichSuGiaoDichKhuThuongMaiBLL
    {
        private static LichSuGiaoDichKhuThuongMaiBLL instance;
        public static LichSuGiaoDichKhuThuongMaiBLL Instance
        {
            get { if (instance == null) instance = new LichSuGiaoDichKhuThuongMaiBLL(); return instance; }
            private set { instance = value; }
        }
        private LichSuGiaoDichKhuThuongMaiBLL() { }
        public LichSuGiaoDichKhuThuongMai GetLichSuByKhuThuongMaiId(string maCanHo)
        {
            DataTable dt = LichSuGiaoDichKhuThuongMaiDAO.Instance.GetLichSuByKhuThuongMaiId(maCanHo);

            string maKhachDangThue = dt.Rows[0]["maKhachDangThue"] != DBNull.Value
                ? dt.Rows[0]["maKhachDangThue"].ToString()
                : string.Empty;
            DateTime lichSuNopPhiDichVu = (DateTime)dt.Rows[0]["lichSuNopPhiDV"];
            DateTime lichSuDangKyDoXe = (DateTime)dt.Rows[0]["lichSuDangKyDoXe"];
            int tinhTrangCongNo = (int)dt.Rows[0]["tinhTrangCongNo"];
            return new LichSuGiaoDichKhuThuongMai(maCanHo, maKhachDangThue, lichSuNopPhiDichVu, lichSuDangKyDoXe, tinhTrangCongNo);
        }
    }
}
