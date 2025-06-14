using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    // Phòng ban
    public class Division
    {
        public string MaBoPhan {  get; set; }
        public string TenBoPhan { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public List<Group> DanhSachNhom {  get; set; }

        public Division(string maBoPhan, string tenBoPhan, string soDienThoai, string email, List<Group> danhSachNhom)
        {
            MaBoPhan = maBoPhan;
            TenBoPhan = tenBoPhan;
            SoDienThoai = soDienThoai;
            Email = email;
            DanhSachNhom = danhSachNhom;
        }
        public Division(string maBoPhan, string tenBoPhan, string soDienThoai, string email)
        {
            MaBoPhan = maBoPhan;
            TenBoPhan = tenBoPhan;
            SoDienThoai = soDienThoai;
            Email = email;
        }
    }
}
