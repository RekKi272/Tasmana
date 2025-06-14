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
    public class ChuHoBLL
    {
        private static ChuHoBLL instance;
        public static ChuHoBLL Instance
        {
            get { if (instance == null) instance = new ChuHoBLL(); return instance; }
            private set { instance = value; }
        }
        private ChuHoBLL() { }
        public List<ChuHo> GetAllChuHo()
        {
            DataTable dt = ChuHoDAO.Instance.GetAllChuHo();
            List<ChuHo> list = new List<ChuHo>();
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
                DateTime ngayNhanBanGiaoCanHo = (DateTime)dt.Rows[i]["ngayNhanBanGiaoCanHo"];
                DateTime ngayChuyenVao = (DateTime)dt.Rows[i]["ngayChuyenVao"];
                DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
                ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
                : (DateTime?)null;
                float soDienNuocNgayBanGiao = dt.Rows[i]["soDienNuocNgayBanGiao"] != DBNull.Value ? Convert.ToSingle(dt.Rows[i]["soDienNuocNgayBanGiao"]) : 0.0f;
                string bienSoXeDangKy = dt.Rows[i]["bienSoXeDangKy"].ToString();
                string maCuDanBanGiao = dt.Rows[i]["banGiao_maCuDan"].ToString();
                string maCuDanLuuTruCung = dt.Rows[i]["maCuDanLuuTruCung"].ToString();
                int tinhTrangCongNo = (int)dt.Rows[i]["tinhTrangCongNo"];
                string duLieuDangKyThuNuoi = dt.Rows[i]["duLieuDangKyThuNuoi"].ToString();
                list.Add(new ChuHo(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi, loaiCuDan, ngayNhanBanGiaoCanHo, soDienNuocNgayBanGiao, maCuDanBanGiao));
            }
            return list;
        }
        public ChuHo GetChuHoByApartmentId(string maCanHo)
        {
            DataTable dt = ChuHoDAO.Instance.GetChuHoByApartmentId(maCanHo);
            if (dt.Rows.Count > 0)
            {
                string maCuDan = dt.Rows[0]["maCuDan"].ToString();
                string loaiCuDan = dt.Rows[0]["loaiCuDan"].ToString();
                string hoTen = dt.Rows[0]["hoTen"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[0]["ngayThangNamSinh"];
                string maDinhDanh = dt.Rows[0]["maDinhDanh"].ToString();
                string soDienThoai = dt.Rows[0]["SDT"].ToString();
                string email = dt.Rows[0]["email"].ToString();
                string quocTich = dt.Rows[0]["quocTich"].ToString();
                string soTheTamTru = dt.Rows[0]["soTheTamTru"].ToString();
                DateTime ngayNhanBanGiaoCanHo = (DateTime)dt.Rows[0]["ngayNhanBanGiaoCanHo"];
                DateTime ngayChuyenVao = (DateTime)dt.Rows[0]["ngayChuyenVao"];
                DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
                ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
                : (DateTime?)null;
                float soDienNuocNgayBanGiao = dt.Rows[0]["soDienNuocNgayBanGiao"] != DBNull.Value ? Convert.ToSingle(dt.Rows[0]["soDienNuocNgayBanGiao"]) : 0.0f;
                string bienSoXeDangKy = dt.Rows[0]["bienSoXeDangKy"].ToString();
                string maCuDanBanGiao = dt.Rows[0]["banGiao_maCuDan"].ToString();
                string maCuDanLuuTruCung = dt.Rows[0]["maCuDanLuuTruCung"].ToString();
                int tinhTrangCongNo = (int)dt.Rows[0]["tinhTrangCongNo"];
                string duLieuDangKyThuNuoi = dt.Rows[0]["duLieuDangKyThuNuoi"].ToString();
                return new ChuHo(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi, loaiCuDan, ngayNhanBanGiaoCanHo, soDienNuocNgayBanGiao, maCuDanBanGiao);
            }
            return null;
        }
        public ChuHo GetChuHoByMaCuDan(string maCuDan, string maCanHo)
        {
            DataTable dt = ChuHoDAO.Instance.GetChuHoByMaCuDan(maCuDan, maCanHo);
            string loaiCuDan = dt.Rows[0]["loaiCuDan"].ToString();
            string hoTen = dt.Rows[0]["hoTen"].ToString();
            DateTime ngaySinh = (DateTime)dt.Rows[0]["ngayThangNamSinh"];
            string maDinhDanh = dt.Rows[0]["maDinhDanh"].ToString();
            string soDienThoai = dt.Rows[0]["SDT"].ToString();
            string email = dt.Rows[0]["email"].ToString();
            string quocTich = dt.Rows[0]["quocTich"].ToString();
            string soTheTamTru = dt.Rows[0]["soTheTamTru"].ToString();
            DateTime ngayNhanBanGiaoCanHo = (DateTime)dt.Rows[0]["ngayNhanBanGiaoCanHo"];
            DateTime ngayChuyenVao = (DateTime)dt.Rows[0]["ngayChuyenVao"];
            DateTime? ngayChuyenDi = dt.Rows[0]["ngayChuyenDi"] != DBNull.Value
            ? (DateTime)dt.Rows[0]["ngayChuyenDi"]
            : (DateTime?)null;
            float soDienNuocNgayBanGiao = dt.Rows[0]["soDienNuocNgayBanGiao"] != DBNull.Value ? Convert.ToSingle(dt.Rows[0]["soDienNuocNgayBanGiao"]) : 0.0f;
            string bienSoXeDangKy = dt.Rows[0]["bienSoXeDangKy"].ToString();
            string maCuDanBanGiao = dt.Rows[0]["banGiao_maCuDan"].ToString();
            string maCuDanLuuTruCung = dt.Rows[0]["maCuDanLuuTruCung"].ToString();
            int tinhTrangCongNo = (int)dt.Rows[0]["tinhTrangCongNo"];
            string duLieuDangKyThuNuoi = dt.Rows[0]["duLieuDangKyThuNuoi"].ToString();
            return new ChuHo(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi, loaiCuDan, ngayNhanBanGiaoCanHo, soDienNuocNgayBanGiao, maCuDanBanGiao);
        }
        public string DeleteChuHo(string maCuDan, string bienSo)
        {
            if (ChuHoDAO.Instance.DeleteChuHo(maCuDan, bienSo))
            {
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }
        public string AddChuHo(Dictionary<string, object> parameters)
        {
            if (ChuHoDAO.Instance.AddChuHo(parameters))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string UpdateChuHo(Dictionary<string, object> parameters)
        {
            if (ChuHoDAO.Instance.UpdateChuHo(parameters))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }

    }
}
