using BLL;
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
    public partial class ChiTietHoaDonHangThang : Form
    {
        public ChiTietHoaDonHangThang()
        {
            InitializeComponent();
        }
        // Kiểm tra phí dịch vụ điền vào có phải là 1 số hợp lệ hay không
        private bool IsValidFloat(string input)
        {
            return double.TryParse(input, out _);
        }
        private bool IsValidInteger(string input)
        {
            return int.TryParse(input, out _);
        }
        private bool CheckPayState()
        {
            if(CBB_tinhTrangThanhToan.SelectedItem.Equals("Đã thanh toán"))
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, object> AddParameterChiPhiHangThang()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@billID", int.Parse(TXB_BilliD.Text)},
                {"@maCanHo", TXB_MaCanHo.Text},
                {"@soDienHangThang",  double.Parse(TXB_soDienHangThang.Text)},
                {"@soNuocHangThang", double.Parse(TXB_soNuocHangThang.Text)},
                {"@phiQuanLyHangThang", int.Parse(TXB_phiQuanLy.Text) },
                {"@tinhTrangThanhToan", CBB_tinhTrangThanhToan.SelectedItem.ToString()},
                {"@ngayGhi", DTP_ngay.Value},
                {"@ngayThanhToan", CheckPayState() ? (object)DateTime.Now : null}
            };
            return dict;
        }
        private bool EditHoaDon()
        {
            if (ApartmentBLL.Instance.EditMonthlyBill(AddParameterChiPhiHangThang()))
            {
                return true;
            }
            return false;
        }
        private void BTN_Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXB_soNuocHangThang.Text))
            {
                MessageBox.Show("Vui lòng điền chỉ số nước sử dụng hàng tháng");
                TXB_soNuocHangThang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TXB_soDienHangThang.Text))
            {
                MessageBox.Show("Vui lòng điền chỉ số điện sử dụng hàng tháng");
                TXB_soDienHangThang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TXB_phiQuanLy.Text))
            {
                MessageBox.Show("Vui lòng điền phí quản lý hàng tháng");
                TXB_phiQuanLy.Focus();
                return;
            }
            if (CBB_tinhTrangThanhToan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng thanh toán");
                CBB_tinhTrangThanhToan.Focus();
                return;
            }
            if (!IsValidFloat(TXB_soNuocHangThang.Text))
            {
                MessageBox.Show("Vui lòng điền chỉ số nước hợp lệ");
                TXB_soNuocHangThang.Focus();
                return;
            }
            if (!IsValidFloat(TXB_soDienHangThang.Text))
            {
                MessageBox.Show("Vui lòng điền số điện sử dụng hợp lệ");
                TXB_soDienHangThang.Focus();
                return;
            }
            if (!IsValidInteger(TXB_phiQuanLy.Text))
            {
                MessageBox.Show("Vui lòng điền phí quản lý hợp lệ");
                TXB_phiQuanLy.Focus();
                return;
            }
            if (EditHoaDon())
            {
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //MoveForm
        int mov;
        int movX;
        int movY;
        private void ChiTietHoaDon_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ChiTietHoaDon_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ChiTietHoaDon_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
