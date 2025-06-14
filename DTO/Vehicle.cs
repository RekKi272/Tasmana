using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vehicle
    {
        public string BienSo {  get; set; }
        public string ChungLoai { get; set; }
        public string TinhTrangSoHuu { get; set; }
        public Vehicle(string bienSo, string chungLoai, string tinhTrangSoHuu)
        {
            BienSo = bienSo;
            ChungLoai = chungLoai;
            TinhTrangSoHuu = tinhTrangSoHuu;
        }
    }
}
