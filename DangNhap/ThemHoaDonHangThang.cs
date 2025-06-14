using BLL;
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
    public partial class ThemHoaDonHangThang : Form
    {
        public ThemHoaDonHangThang()
        {
            InitializeComponent();
        }

        private void LoadCanHo()
        {
            List<Apartment> list;
            list = ApartmentBLL.Instance.GetApartmentList();
            foreach (Apartment a in list)
            {
                CBB_MaCanHo.Items.Add(a.MaCanHo);
            }
        }
        private void ThemHoaDonHangThang_Load(object sender, EventArgs e)
        {
            // Load dữ liệu lên CBB căn hộ
            LoadCanHo();    
        }
        private bool CheckPayState()
        {
            if (CBB_tinhTrangThanhToan.SelectedItem.Equals("Đã thanh toán") || CBB_tinhTrangThanhToan.SelectedItem.Equals("Paid"))
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, object> AddParameterChiPhiHangThang()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maCanHo", CBB_MaCanHo.SelectedItem.ToString()},
                {"@soDienHangThang",  double.Parse(TXB_soDienHangThang.Text)},
                {"@soNuocHangThang", double.Parse(TXB_soNuocHangThang.Text)},
                {"@phiQuanLyHangThang", int.Parse(TXB_phiQuanLy.Text) },
                {"@tinhTrangThanhToan", CBB_tinhTrangThanhToan.SelectedItem.ToString()},
                {"@ngayGhi", DTP_ngay.Value},
                {"@ngayThanhToan", CheckPayState() ? (object)DateTime.Now : null}
            };
            return dict;
        }
        private bool ThemHoaDon()
        {
            if (ApartmentBLL.Instance.AddMonthlyBill(AddParameterChiPhiHangThang())){
                return true;
            }
            return false;
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
        private void BTN_ok_Click(object sender, EventArgs e)
        {
            //Tiếng Việt
            if(LB_BillHangThang.Text == "THÊM HÓA ĐƠN HÀNG THÁNG")
            {
                if(CBB_MaCanHo.SelectedIndex == -1) 
                {
                    MessageBox.Show("Vui lòng chọn mã căn hộ");
                    CBB_MaCanHo.Focus();
                    return;
                }
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
                if (string.IsNullOrEmpty(TXB_phiQuanLy.Text)){
                    MessageBox.Show("Vui lòng điền phí quản lý hàng tháng");
                    TXB_phiQuanLy.Focus();
                    return;
                }
                if(CBB_tinhTrangThanhToan.SelectedIndex == -1)
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
                if (ThemHoaDon())
                {
                    MessageBox.Show("Thêm thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            //Tiếng Anh
            else
            {
                if (CBB_MaCanHo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select \"Apartment ID\"");
                    CBB_MaCanHo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TXB_soNuocHangThang.Text))
                {
                    MessageBox.Show("Please enter \"Monthly water number\"");
                    TXB_soNuocHangThang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TXB_soDienHangThang.Text))
                {
                    MessageBox.Show("Please enter \"Monthly electricity number\"");
                    TXB_soDienHangThang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(TXB_phiQuanLy.Text))
                {
                    MessageBox.Show("Please enter \"Monthly management fee\"");
                    TXB_phiQuanLy.Focus();
                    return;
                }
                if (CBB_tinhTrangThanhToan.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select \"Payment status\"");
                    CBB_tinhTrangThanhToan.Focus();
                    return;
                }
                if (!IsValidFloat(TXB_soNuocHangThang.Text))
                {
                    MessageBox.Show("\"Monthly water number\" is invalid");
                    TXB_soNuocHangThang.Focus();
                    return;
                }
                if (!IsValidFloat(TXB_soDienHangThang.Text))
                {
                    MessageBox.Show("\"Monthly electricity number\" is invalid");
                    TXB_soDienHangThang.Focus();
                    return;
                }
                if (!IsValidInteger(TXB_phiQuanLy.Text))
                {
                    MessageBox.Show("\"Monthly management fee\" is invalid");
                    TXB_phiQuanLy.Focus();
                    return;
                }
                if (ThemHoaDon())
                {
                    MessageBox.Show("Added Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Added Failed");
                }
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
        private void ThemHoaDon_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ThemHoaDon_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ThemHoaDon_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
