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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class ThongTinNhanVien : Form
    {
        private Employee employee;
        private Group group;
        private Division division = null;
        private readonly string employeeId;
        public ThongTinNhanVien(string employeeId)
        {
            this.employeeId = employeeId;
            InitializeComponent();
        }
        private void GetEmployeeByEmployeeId()
        {
            employee = EmployeeBLL.Instance.GetEmployeeByEmployeeId(employeeId);
        }
        private void GetGroupByEmployeeId()
        {
            group = EmployeeBLL.Instance.GetGroupByEmployeeId(employeeId);
        }
        private void GetDivisionByGroupId()
        {
            if (group != null)
            {
                division = GroupBLL.Instance.GetDivsionByGroupId(group.MaNhom);
            }
        }
        private void DisplayEmployeeeInfo()
        {
            // Hiện thông tin nhân viên
            GetGroupByEmployeeId();
            GetDivisionByGroupId();
            TXB_manv.Text = employee.MaNhanVien;
            TXB_ho.Text = employee.Ho;
            TXB_ten.Text = employee.Ten;
            TXB_ngaysinh.Text = employee.NgaySinh.ToString("dd/MM/yyyy");
            if (employee.GioiTinh == true)
            {
                TXB_gioitinh.Text = "Nam";
            }
            else
            {
                TXB_gioitinh.Text = "Nữ";
            }
            TXB_honnhan.Text = employee.TinhTrangHonNhan;
            TXB_loainv.Text = employee.LoaiNhanVien;
            if (employee.DaTungLamNhanVien)
            {
                CHB_tunglanv.Checked = true;
            }
            if (division != null)
            {
                TXB_phongban.Text = $"{division.MaBoPhan} - {division.TenBoPhan}";
            }
            else
            {
                TXB_phongban.Text = "";
            }
            if (group != null)
            {
                TXB_nhom.Text = group.MaNhom;
            }
            else
            {
                TXB_nhom.Text = "";
            }
            TXB_ngayhetHDLD.Text = employee.NgayHetHDLD.ToString("dd/MM/yyyy");
            TXB_ngaykyHDLD.Text = employee.NgayKyHDLD.ToString("dd/MM/yyyy");
            TXB_tinhtrangHDLD.Text = employee.TinhTrangHDLD;
            TXB_sdt.Text = employee.SoDienThoai;
            TXB_email.Text = employee.Email;
            TXB_cccd.Text = employee.MaDinhDanh;
            TXB_bhxh.Text = employee.MaSoBHXH;
            TXB_quequan.Text = employee.QueQuan;
            TXB_thuongtru.Text = employee.DiaChiThuongTru;
            TXB_tamtru.Text = employee.DiaChiTamTru;

            // Hiện thông tin tài khoản
            Account account = employee.TaiKhoanNguoiDung;
            TXB_manguoidung.Text = account.UserId;
            TXB_matkhau.Text = account.Password;
            TXB_matkhau.UseSystemPasswordChar = true;
        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            GetEmployeeByEmployeeId();
            DisplayEmployeeeInfo();
        }

        private void BTN_doimatkhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(employee.TaiKhoanNguoiDung);
            doiMatKhau.ShowDialog();
        }
    }
}
