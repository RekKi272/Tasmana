using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DTO
{
    public class Apartment
    {
        public string MaCanHo {  get; protected set; }
        public float DienTichGSA { get; set; }
        public float DienTichNSA { get; set; }
        public int ViTriTang { get; set; }
        public int SoLuongPhongNgu { get; set; }
        public int SoLuongToilet { get; set; }
        public Image SoDoMatBang { get; set; }
        public int MucPhiQuanLyHangThang {  get; set; }
        public int SoLuongTheThangMay {  get; set; }
        public LichSuGiaoDich LichSuGiaoDich {  get; set; }
        public string TinhTrangGiaoDichHienTai { get; set; }
        public int TinhTrangThanhToan {  get; set; }
        public string MaCuDan {  get; set; }

        public Apartment(string maCanHo, float dienTichGSA, float dienTichNSA, int viTriTang, int soLuongPhongNgu, int soLuongToilet, Image soDoMatBang, int mucPhiQuanLyHangThang, int soLuongTheThangMay, LichSuGiaoDich lichSuGiaoDich, string tinhTrangGiaoDichHienTai, int tinhTrangThanhToan, string maCuDan)
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
            LichSuGiaoDich = lichSuGiaoDich;
            TinhTrangGiaoDichHienTai = tinhTrangGiaoDichHienTai;
            TinhTrangThanhToan = tinhTrangThanhToan;
            MaCuDan = maCuDan;
        }
        public Apartment(string maCanHo, float dienTichGSA, float dienTichNSA, int viTriTang, int soLuongPhongNgu, int soLuongToilet, Image soDoMatBang, int mucPhiQuanLyHangThang, int soLuongTheThangMay, LichSuGiaoDich lichSuGiaoDich, int tinhTrangThanhToan, string maCuDan)
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
            LichSuGiaoDich = lichSuGiaoDich;
            TinhTrangThanhToan = tinhTrangThanhToan;
            MaCuDan = maCuDan;
        }

    }
}
