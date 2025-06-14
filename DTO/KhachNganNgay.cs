using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachNganNgay : Resident
    {
        public string LoaiCuDan {  get; set; }
        public KhachNganNgay(string maCuDan, string maCanHo, string hoTen, DateTime ngaySinh, string maDinhDanh, string soDienThoai, string email, string quocTich, string soTheTamTru, DateTime ngayChuyenVao, DateTime? ngayChuyenDi, string maCuDanLuuTruCung, string bienSoXeDangKy, int tinhTrangCongNo, string duLieuDangKyThuNuoi, string loaiCuDan)
        : base(maCuDan, maCanHo, hoTen, ngaySinh, maDinhDanh, soDienThoai, email, quocTich, soTheTamTru, ngayChuyenVao, ngayChuyenDi, maCuDanLuuTruCung, bienSoXeDangKy, tinhTrangCongNo, duLieuDangKyThuNuoi)
        {
            LoaiCuDan = loaiCuDan;
        }
    }
}
