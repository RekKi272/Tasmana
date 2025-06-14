using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DTO
{
    public class KhuThuongMai
    {
        public string MaCanHo {  get; set; }
        public float DienTichGSA { get; set; }
        public float DienTichNSA { get; set; }
        public int ViTriTang { get; set; }
        public int SoLuongPhongNgu { get; set; }
        public int SoLuongToilet { get; set; }
        public Image SoDoMatBang { get; set; }
        public int MucPhiQuanLyHangThang { get; set; }
        public int SoLuongTheThangMay { get; set; }
        public LichSuGiaoDichKhuThuongMai LichSuGiaoDichKhuThuongMai { get; set; }
        public int TinhTrangThanhToan { get; set; }
        public string MaKhachDangThue { get; set; }

        public KhuThuongMai(string maCanHo, float dienTichGSA, float dienTichNSA, int viTriTang, int soLuongPhongNgu, int soLuongToilet, Image soDoMatBang, int mucPhiQuanLyHangThang, int soLuongTheThangMay, LichSuGiaoDichKhuThuongMai lichSuGiaoDichKhuThuongMai, int tinhTrangThanhToan, string maKhachDangThue)
        {
            MaCanHo = maCanHo;
            DienTichGSA = dienTichGSA;
            DienTichNSA = dienTichNSA;
            ViTriTang = viTriTang;
            SoLuongPhongNgu = soLuongPhongNgu;
            SoLuongToilet = soLuongToilet;
            SoDoMatBang = soDoMatBang;
            MucPhiQuanLyHangThang = mucPhiQuanLyHangThang;
            SoLuongTheThangMay = soLuongTheThangMay;
            LichSuGiaoDichKhuThuongMai = lichSuGiaoDichKhuThuongMai;
            TinhTrangThanhToan = tinhTrangThanhToan;
            MaKhachDangThue = maKhachDangThue;
        }
    }
}
