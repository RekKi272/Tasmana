using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Group
    {
        public string MaNhom {  get; set; }
        public string MaTruongNhom { get; set; }
        public string MaBoPhan { get; set; }
        public List<Employee> DanhSachNhanVien {  get; set; }

        public Group(string maNhom, string maTruongNhom, string maBoPhan, List<Employee> danhSachNhanVien) 
        {
            MaNhom = maNhom;
            MaTruongNhom = maTruongNhom;
            MaBoPhan = maBoPhan;
            DanhSachNhanVien = danhSachNhanVien;
        }

        public Group(string maNhom, string maTruongNhom, string maBoPhan)
        {
            MaNhom = maNhom;
            MaTruongNhom = maTruongNhom;
            MaBoPhan = maBoPhan;
        }
    }
}
