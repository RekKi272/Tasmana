using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class LichSuKhuThuongMai : Form
    {
        private readonly KhuThuongMai khuThuongMai;
        public LichSuKhuThuongMai()
        {
            InitializeComponent();
        }
        public LichSuKhuThuongMai(KhuThuongMai khuThuongMai)
        {
            InitializeComponent();
            this.khuThuongMai = khuThuongMai;
        }
        private void DisplayLichSu()
        {
            TXB_congno.Text = khuThuongMai.LichSuGiaoDichKhuThuongMai.TinhTrangCongNo.ToString();
            TXB_dv.Text = khuThuongMai.LichSuGiaoDichKhuThuongMai.LichSuNopPhiDichVu.ToString();
            TXB_doxe.Text = khuThuongMai.LichSuGiaoDichKhuThuongMai.LichSuDangKyDoXe.ToString();
        }

        private void LichSuKhuThuongMai_Load(object sender, EventArgs e)
        {
            DisplayLichSu();
        }
    }
}
