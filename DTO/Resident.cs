using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Resident
    {
        public string MaCuDan {  get; set; }
        public string MaCanHo {  get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaDinhDanh {  get; set; }
        public string SoDienThoai {  get; set; }
        public string Email { get; set; }
        public string QuocTich {  get; set; }
        public string SoTheTamTru { get; set; }
        public DateTime NgayChuyenVao { get; set; }
        public DateTime? NgayChuyenDi {  get; set; }
        public string MaCuDanLuuTruCung {  get; set; }
        public string BienSoXeDangKy { get; set; }
        public int TinhTrangCongNo { get; set; }
        public string DuLieuDangKyThuNuoi { get; set; }
        public Resident(string maCuDan, string maCanHo, string hoTen, DateTime ngaySinh, string maDinhDanh, string soDienThoai, string email, string quocTich, string soTheTamTru, DateTime ngayChuyenVao, DateTime? ngayChuyenDi, string maCuDanLuuTruCung, string bienSoXeDangKy, int tinhTrangCongNo, string duLieuDangKyThuNuoi)
        {
            MaCuDan = maCuDan;
            MaCanHo = maCanHo;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            MaDinhDanh = maDinhDanh;
            SoDienThoai = soDienThoai;
            Email = email;
            QuocTich = quocTich;
            SoTheTamTru = soTheTamTru;
            NgayChuyenVao = ngayChuyenVao;
            NgayChuyenDi = ngayChuyenDi;
            MaCuDanLuuTruCung = maCuDanLuuTruCung;
            BienSoXeDangKy = bienSoXeDangKy;
            TinhTrangCongNo = tinhTrangCongNo;
            DuLieuDangKyThuNuoi = duLieuDangKyThuNuoi;
        }
    }
}
