using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachThueKhuThuongMai
    {
        public string MaKhachDangThue {  get; set; }
        public string TenCongTy {  get; set; }
        public string HoTenNguoiDaiDien {  get; set; }
        public string MaNhanVienPhuTrach {  get; set; }
        public string SoDienThoai {  get; set; }
        public string Email {  get; set; }
        public DateTime NgayKyHopDongThue { get; set; }
        public DateTime NgayChuyenVao { get; set; }
        public DateTime? NgayChuyenDi {  get; set; }
        public int PhiQuanLy {  get; set; }
        public string MoTaKhuVucChoThue { get; set; }
        public string BienSoXeDangKy {  get; set; }
        public KhachThueKhuThuongMai(string maKhachDangThue, string tenCongTy, string hoTenNguoiDaiDien, string maNhanVienPhuTrach, string soDienThoai, string email, DateTime ngayKyHopDongThue, DateTime ngayChuyenVao, DateTime? ngayChuyenDi, int phiQuanLy, string moTaKhuVucChoThue, string bienSoXeDangKy)
        {
            MaKhachDangThue = maKhachDangThue;
            TenCongTy = tenCongTy;
            HoTenNguoiDaiDien = hoTenNguoiDaiDien;
            MaNhanVienPhuTrach = maNhanVienPhuTrach;
            SoDienThoai = soDienThoai;
            Email = email;
            NgayKyHopDongThue = ngayKyHopDongThue;
            NgayChuyenVao = ngayChuyenVao;
            NgayChuyenDi = ngayChuyenDi;
            PhiQuanLy = phiQuanLy;
            MoTaKhuVucChoThue = moTaKhuVucChoThue;
            BienSoXeDangKy = bienSoXeDangKy;
        }
    }
}
