using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichSuGiaoDichKhuThuongMai
    {
        public string MaCanHo {  get; set; }
        public string MaKhachDangThue { get; set; }
        public DateTime LichSuNopPhiDichVu { get; set; }
        public DateTime LichSuDangKyDoXe { get; set; }
        public int TinhTrangCongNo {  get; set; }
        public LichSuGiaoDichKhuThuongMai(string maCanHo, string maKhachDangThue, DateTime lichSuNopPhiDichVu, DateTime lichSuDangKyDoXe, int tinhTrangCongNo)
        {
            MaCanHo = maCanHo;
            MaKhachDangThue = maKhachDangThue;
            LichSuNopPhiDichVu = lichSuNopPhiDichVu;
            LichSuDangKyDoXe = lichSuDangKyDoXe;
            TinhTrangCongNo = tinhTrangCongNo;
        }
    }
}
