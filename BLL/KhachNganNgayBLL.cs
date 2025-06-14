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
    public class KhachNganNgayBLL
    {
        private static KhachNganNgayBLL instance;
        public static KhachNganNgayBLL Instance
        {
            get { if (instance == null) instance = new KhachNganNgayBLL(); return instance; }
            private set { instance = value; }
        }
        private KhachNganNgayBLL() { }
        public string GetNameByMaCuDan(string maCuDan)
        {
            DataTable dt = KhachNganNgayDAO.Instance.GetNameByMaCuDan(maCuDan);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["hoTen"].ToString();
            return "";
        }
        public List<KhachNganNgay> GetAllKhachNganNgay()
        {
            DataTable dt = KhachNganNgayDAO.Instance.GetAllKhachNganNgay();
            List<KhachNganNgay> list = new List<KhachNganNgay>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maCuDan = dt.Rows[i]["maCuDan"].ToString();
                string maCanHo = dt.Rows[i]["maCanHo"].ToString();
                string loaiCuDan = dt.Rows[i]["loaiCuDan"].ToString();
                string hoTen = dt.Rows[i]["hoTen"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[i]["ngayThangNamSinh"];
                string maDinhDanh = dt.Rows[i]["maDinhDanh"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string quocTich = dt.Rows[i]["quocTich"].ToString();
                string soTheTamTru = dt.Rows[i]["soTheTamTru"].ToString();
                DateTime ngayChuyenVao = (DateTime)dt.Rows[i]["ngayChuyenVao"];
                DateTime? ngayChuyenDi = dt.Rows[i]["ngayChuyenDi"] != DBNull.Value
                ? (DateTime)dt.Rows[i]["ngayChuyenDi"]
                : (DateTime?)null;
                string bienSoXeDangKy = dt.Rows[i]["bienSoXeDangKy"].ToString();
                string maCuDanLuuTruCung = dt.Rows[i]["maCuDanLuuTruCung"].ToString();
                int tinhTrangCongNo = (int)dt.Rows[i]["tinhTrangCongNo"];
                string duLieuDangKyThuNuoi = dt.Rows[i]["duLieuDangKyThuNuoi"].ToString();
                list.Add(new KhachNganNgay(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi, loaiCuDan));
            }
            return list;
        }
        public KhachNganNgay GetKhachNganNgayByMaCuDan(string maCuDan, string maCanHo)
        {
            DataTable dt = KhachNganNgayDAO.Instance.GetKhachByMaCuDan(maCuDan, maCanHo);
            string loaiCuDan = dt.Rows[0]["loaiCuDan"].ToString();
            string hoTen = dt.Rows[0]["hoTen"].ToString();
            DateTime ngaySinh = (DateTime)dt.Rows[0]["ngayThangNamSinh"];
            string maDinhDanh = dt.Rows[0]["maDinhDanh"].ToString();
            string soDienThoai = dt.Rows[0]["SDT"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            string quocTich = dt.Rows[0]["quocTich"].ToString();
            string soTheTamTru = dt.Rows[0]["soTheTamTru"].ToString();
            DateTime ngayChuyenVao = (DateTime)dt.Rows[0]["ngayChuyenVao"];
            DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
            ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
            : (DateTime?)null;
            string bienSoXeDangKy = dt.Rows[0]["bienSoXeDangKy"].ToString();
            string maCuDanLuuTruCung = dt.Rows[0]["maCuDanLuuTruCung"].ToString();
            int tinhTrangCongNo = (int)dt.Rows[0]["tinhTrangCongNo"];
            string duLieuDangKyThuNuoi = dt.Rows[0]["duLieuDangKyThuNuoi"].ToString();
            return new KhachNganNgay(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi, loaiCuDan);
        }
        public string DeleteKhachNganNgay(string maCuDan, string bienSo)
        {
            if (KhachNganNgayDAO.Instance.DeleteKhachNganNgay(maCuDan, bienSo))
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }
        public string AddKhachNganNgay(Dictionary<string, object> parameters)
        {
            if (KhachNganNgayDAO.Instance.AddKhachNganNgay(parameters))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string UpdateKhachNganNgay(Dictionary<string, object> parameters)
        {
            if (KhachNganNgayDAO.Instance.UpdateKhachNganNgay(parameters))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }
    }
}
