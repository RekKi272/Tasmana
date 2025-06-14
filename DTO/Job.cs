using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    // Công việc
    public class Job
    {
        public string MaCongViec {  get; set; }
        public string NoiDung { get; set; }
        public string MaCanHo { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime ThoiHan {  get; set; }
        public DateTime NgayHoanThanh { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu {  get; set; }
        public int QuyenTruyCap { get; set; }
        public int PhiDichVu {  get; set; }
        public Job(string maCongViec, string noiDung, DateTime thoiHan, DateTime ngayHoanThanh ,string trangThai, string ghiChu)
        {
            MaCongViec = maCongViec;
            NoiDung = noiDung;
            ThoiHan = thoiHan;
            NgayHoanThanh = ngayHoanThanh;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
        public Job(string maCongViec, string noiDung, DateTime ngayGiao, DateTime thoiHan, DateTime ngayHoanThanh, DateTime ngayCapNhat, string trangThai, string ghiChu)
        {
            MaCongViec = maCongViec;
            NoiDung = noiDung;
            NgayGiao = ngayGiao;
            ThoiHan = thoiHan;
            NgayHoanThanh = ngayHoanThanh;
            NgayCapNhat = ngayCapNhat;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
        public Job(string maCongViec, string noiDung, DateTime ngayGiao, DateTime thoiHan, DateTime ngayHoanThanh, DateTime ngayCapNhat, string trangThai, string ghiChu, int quyenTruyCap)
        {
            MaCongViec = maCongViec;
            NoiDung = noiDung;
            NgayGiao = ngayGiao;
            NgayCapNhat = ngayCapNhat;
            ThoiHan = thoiHan;
            NgayHoanThanh = ngayHoanThanh;
            TrangThai = trangThai;
            GhiChu = ghiChu;
            QuyenTruyCap = quyenTruyCap;
        }
        public Job(string maCongViec, string noiDung, DateTime ngayGiao, DateTime thoiHan, DateTime ngayHoanThanh, DateTime ngayCapNhat, string trangThai, string ghiChu, int quyenTruyCap, int phiDichVu)
        {
            MaCongViec = maCongViec;
            NoiDung = noiDung;
            NgayGiao = ngayGiao;
            NgayCapNhat = ngayCapNhat;
            ThoiHan = thoiHan;
            NgayHoanThanh = ngayHoanThanh;
            TrangThai = trangThai;
            GhiChu = ghiChu;
            QuyenTruyCap = quyenTruyCap;
            PhiDichVu = phiDichVu;
        }
    }
}
