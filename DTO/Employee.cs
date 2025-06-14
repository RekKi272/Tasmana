using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        public string MaNhanVien { get; set; }
        public string Ho {  get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan {  get; set; }
        public string MaDinhDanh { get; set; }
        public string LoaiNhanVien { get; set; }
        public string TinhTrangHonNhan {  get; set; }
        public string MaSoBHXH {  get; set; }
        public bool DaTungLamNhanVien { get; set; }
        public DateTime NgayKyHDLD { get; set; }
        public DateTime NgayHetHDLD { get; set; }
        public string DiaChiThuongTru {  get; set; }
        public string DiaChiTamTru { get; set; }
        public string TinhTrangHDLD { get; set; }
        public string MaBoPhan { get; set; }
        public string MaNhom {  get; set; }
        public Account TaiKhoanNguoiDung {  get; set; }
        public List<Job> CongViec {  get; set; }
        public Employee(string maNhanVien, string email, string ho, string ten, string soDienThoai, DateTime ngaySinh, bool gioiTinh, string queQuan, string maDinhDanh, string loaiNhanVien, string tinhTrangHonNhan, string maSoBHXH, bool daTungLamNhanVien, DateTime ngayKyHDLD, DateTime ngayHetHDLD, string diaChiThuongTru, string diaChiTamTru, string tinhTrangHDLD, string maBoPhan, string maNhom, Account account)
        {
            MaNhanVien = maNhanVien;
            Email = email;
            Ho = ho;
            Ten = ten;
            SoDienThoai = soDienThoai;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            QueQuan = queQuan;
            MaDinhDanh = maDinhDanh;
            LoaiNhanVien = loaiNhanVien;
            TinhTrangHonNhan = tinhTrangHonNhan;
            MaSoBHXH = maSoBHXH;
            DaTungLamNhanVien = daTungLamNhanVien;
            NgayKyHDLD = ngayKyHDLD;
            NgayHetHDLD = ngayHetHDLD;
            DiaChiThuongTru = diaChiThuongTru;
            DiaChiTamTru = diaChiTamTru;
            TinhTrangHDLD = tinhTrangHDLD;
            MaBoPhan = maBoPhan;
            MaNhom = maNhom;
            TaiKhoanNguoiDung = account;
        }

        public Employee(string maNhanVien, string email, string ho, string ten, string soDienThoai, DateTime ngaySinh, bool gioiTinh, string queQuan, string maDinhDanh, string loaiNhanVien, string tinhTrangHonNhan, string maSoBHXH, bool daTungLamNhanVien, DateTime ngayKyHDLD, DateTime ngayHetHDLD, string diaChiThuongTru, string diaChiTamTru, string tinhTrangHDLD, string maBoPhan, string maNhom)
        {
            MaNhanVien = maNhanVien;
            Email = email;
            Ho = ho;
            Ten = ten;
            SoDienThoai = soDienThoai;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            QueQuan = queQuan;
            MaDinhDanh = maDinhDanh;
            LoaiNhanVien = loaiNhanVien;
            TinhTrangHonNhan = tinhTrangHonNhan;
            MaSoBHXH = maSoBHXH;
            DaTungLamNhanVien = daTungLamNhanVien;
            NgayKyHDLD = ngayKyHDLD;
            NgayHetHDLD = ngayHetHDLD;
            DiaChiThuongTru = diaChiThuongTru;
            DiaChiTamTru = diaChiTamTru;
            TinhTrangHDLD = tinhTrangHDLD;
            MaBoPhan = maBoPhan;
            MaNhom = maNhom;
        }
    }
}
