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
    public class KhachThueKhuThuongMaiBLL
    {
        private static KhachThueKhuThuongMaiBLL instance;
        public static KhachThueKhuThuongMaiBLL Instance
        {
            get { if (instance == null) instance = new KhachThueKhuThuongMaiBLL(); return instance; }
            private set { instance = value; }
        }
        private KhachThueKhuThuongMaiBLL() { }
        public KhachThueKhuThuongMai GetKhachThueById(string maKhachDangThue)
        {
            DataTable dt = KhachThueKhuThuongMaiDAO.Instance.GetKhachThueById(maKhachDangThue);
            string tenCongTy = dt.Rows[0]["tenCongTy"].ToString();
            string hoTenNguoiDaiDien = dt.Rows[0]["hoTenNguoiDaiDien"].ToString();
            string maNhanVienPhuTrach = dt.Rows[0]["maNhanVienPhuTrach"].ToString();
            string soDienThoai = dt.Rows[0]["SDT"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            DateTime ngayKyHopDongThue = (DateTime)dt.Rows[0]["ngayKyHopDongThue"];
            DateTime ngayChuyenVao = (DateTime)dt.Rows[0]["ngayChuyenVao"];
            DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
            ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
            : (DateTime?)null;
            int phiQuanLy = (int)dt.Rows[0]["phiQuanLy"];
            string moTaKhuVucChoThue = dt.Rows[0]["moTaKhuVucChoThue"].ToString();
            string bienSoXeDangKy = dt.Rows[0]["bienSoXeDangKy"].ToString();
            return new KhachThueKhuThuongMai(maKhachDangThue, tenCongTy, hoTenNguoiDaiDien, maNhanVienPhuTrach, soDienThoai, email, ngayKyHopDongThue, ngayChuyenVao, ngayChuyenDi, phiQuanLy, moTaKhuVucChoThue, bienSoXeDangKy);
        }
        public List<KhachThueKhuThuongMai> GetAllKhachThue()
        {
            DataTable dt = KhachThueKhuThuongMaiDAO.Instance.GetAllKhachThue();
            List<KhachThueKhuThuongMai> list = new List<KhachThueKhuThuongMai> ();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maKhachDangThue = dt.Rows[i]["maKhachDangThue"].ToString();
                string tenCongTy = dt.Rows[i]["tenCongTy"].ToString();
                string hoTenNguoiDaiDien = dt.Rows[i]["hoTenNguoiDaiDien"].ToString();
                string maNhanVienPhuTrach = dt.Rows[i]["maNhanVienPhuTrach"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                DateTime ngayKyHopDongThue = (DateTime)dt.Rows[i]["ngayKyHopDongThue"];
                DateTime ngayChuyenVao = (DateTime)dt.Rows[i]["ngayChuyenVao"];
                DateTime? ngayChuyenDi = dt.Rows[i]["ngayChuyenDi"] != DBNull.Value
                ? (DateTime)dt.Rows[i]["ngayChuyenDi"]
                : (DateTime?)null;
                int phiQuanLy = (int)dt.Rows[i]["phiQuanLy"];
                string moTaKhuVucChoThue = dt.Rows[i]["moTaKhuVucChoThue"].ToString();
                string bienSoXeDangKy = dt.Rows[i]["bienSoXeDangKy"].ToString();
                list.Add(new KhachThueKhuThuongMai(maKhachDangThue, tenCongTy, hoTenNguoiDaiDien, maNhanVienPhuTrach, soDienThoai, email, ngayKyHopDongThue, ngayChuyenVao, ngayChuyenDi, phiQuanLy, moTaKhuVucChoThue, bienSoXeDangKy));
            }
            return list;
        }
        public KhachThueKhuThuongMai GetKhachThueKTMByMaKhach(string maKhachDangThue)
        {
            DataTable dt = KhachThueKhuThuongMaiDAO.Instance.GetKhachThueKTMByMaKhach(maKhachDangThue);
            string tenCongTy = dt.Rows[0]["tenCongTy"].ToString();
            string hoTenNguoiDaiDien = dt.Rows[0]["hoTenNguoiDaiDien"].ToString();
            string maNhanVienPhuTrach = dt.Rows[0]["maNhanVienPhuTrach"].ToString();
            string soDienThoai = dt.Rows[0]["SDT"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            DateTime ngayKyHopDongThue = (DateTime)dt.Rows[0]["ngayKyHopDongThue"];
            DateTime ngayChuyenVao = (DateTime)dt.Rows[0]["ngayChuyenVao"];
            DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
            ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
            : (DateTime?)null;
            int phiQuanLy = (int)dt.Rows[0]["phiQuanLy"];
            string moTaKhuVucChoThue = dt.Rows[0]["moTaKhuVucChoThue"].ToString();
            string bienSoXeDangKy = dt.Rows[0]["bienSoXeDangKy"].ToString();
            return new KhachThueKhuThuongMai(maKhachDangThue, tenCongTy, hoTenNguoiDaiDien, maNhanVienPhuTrach, soDienThoai, email, ngayKyHopDongThue, ngayChuyenVao, ngayChuyenDi, phiQuanLy, moTaKhuVucChoThue, bienSoXeDangKy);
        }
        public string AddKhachThueKTM(Dictionary<string, object> parameters)
        {
            if (KhachThueKhuThuongMaiDAO.Instance.AddKhachThueKTM(parameters))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string DeleteKhachThueKTM(string maKhachDangThue, string bienSo)
        {
            if (KhachThueKhuThuongMaiDAO.Instance.DeleteKhachThueKTM(maKhachDangThue, bienSo))
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }
        public string UpdateKhachThueKTM(Dictionary<string, object> parameters)
        {
            if (KhachThueKhuThuongMaiDAO.Instance.UpdateKhachThueKTM(parameters))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }
    }
}
