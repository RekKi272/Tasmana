using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;
using DTO;

namespace DangNhap
{
    public partial class ThongTinCaNhan : Form
    {
        private readonly NhanVien parent;
        private List<Division> divisions = new List<Division>();
        private List<DTO.Group> groups = new List<DTO.Group>();
        private readonly Employee employee = null;
        private DTO.Group group;
        private Division division = null;
        public ThongTinCaNhan()
        {
            InitializeComponent();
        }
        public ThongTinCaNhan(NhanVien parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public ThongTinCaNhan(NhanVien parent, Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.parent = parent;
            this.FormClosing += new FormClosingEventHandler(this.ThongTinCaNhan_FormClosing);
        }
        private void GetGroupByEmployeeId()
        {
            group = EmployeeBLL.Instance.GetGroupByEmployeeId(employee.MaNhanVien);
        }
        private void GetDivisionByEmployeeId()
        {
            if (employee != null)
            {
                division = DivisionBLL.Instance.GetDivisionByEmployeeId(employee.MaNhanVien);
            }
        } 

        // Hàm khởi tạo danh sách giá trị truyền vào SP
        private object[] values_nv;
        private void InitializeValues_NV()
        {
            values_nv = new object[]
            {
                TXB_manv.Text,
                TXB_email.Text,
                TXB_ho.Text,
                TXB_ten.Text,
                TXB_sdt.Text,
                DTP_ngaysinh.Value,
                Rad_nam.Checked ? 1 : 0,
                TXB_quequan.Text,
                TXB_cccd.Text,
                CBB_loainv.SelectedItem.ToString(),
                TXB_honnhan.Text,
                TXB_bhxh.Text,
                CHB_tunglanv.Checked ? 1 : 0,
                DTP_ngaykyHDLD.Value,
                DTP_ngayhetHDLD.Value,
                TXB_thuongtru.Text,
                TXB_tamtru.Text,
                TXB_tinhtrangHDLD.Text,
                CBB_phongban.SelectedItem?.ToString().Split('-')[0],
                CBB_nhom.SelectedItem,
            };
        }

        // Tạo dictionary để truyền vào DataProvider
        private Dictionary<string, object> AddParameter_NV()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maNhanVien", values_nv[0] },
                { "@email", values_nv[1] },
                { "@ho", values_nv[2] },
                { "@ten", values_nv[3] },
                { "@SDT", values_nv[4] },
                { "@ngaySinh", values_nv[5] },
                { "@gioiTinh", values_nv[6] },
                { "@queQuan", values_nv[7] },
                { "@maDinhDanh", values_nv[8] },
                { "@loaiNhanVien", values_nv[9] },
                { "@tinhTrangHonNhan", values_nv[10] },
                { "@maSoBHXH", values_nv[11] },
                { "@daTungLamNV", values_nv[12] },
                { "@ngayKyHDLD", values_nv[13] },
                { "@ngayHetHDLD", values_nv[14] },
                { "@dChiThuongTru", values_nv[15] },
                { "@dChiTamTru", values_nv[16] },
                { "@tinhTrangHDLD", values_nv[17] },
                { "@maBoPhan", values_nv[18] },
                { "@maNhom", values_nv[19] }
            };
            return dict;
        }
        private object[] values_tk;
        private void InitializeValues_TK()
        {
            values_tk = new object[]
            {
                TXB_manguoidung.Text,
                TXB_matkhau.Text,
                TXB_manv.Text,
                CHB_vohieuhoa.Checked ? 1 : 0 // Khi tạo tài khoản mặc định disabled là 0
            };
        }
        private Dictionary<string, object> AddParameter_TK()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maNguoiDung", values_tk[0] },
                { "@matKhau", values_tk[1] },
                { "@maNhanVien", values_tk[2] },
                { "@disable", values_tk[3] }
            };
            return dict;
        }
        // Thêm nhân viên vào CSDL
        private string AddEmployee(Dictionary<string, object> parameters)
        {
            return EmployeeBLL.Instance.AddEmployee(parameters);
        }
        private bool AddAccount(Dictionary<string, object> parameters)
        {
            return AccountBLL.Instance.AddAccount(parameters);
        }
        private bool UpdateAccount(Dictionary<string, object> parameters)
        {
            return AccountBLL.Instance.UpdateAccount(parameters);
        }
        // Cập nhật thông tin nhân viên vào CSDL
        private string UpdateEmployee(Dictionary<string, object> parameters)
        {
            return EmployeeBLL.Instance.UpdateEmployee(parameters);
        }
        // Lấy danh sách phòng ban
        private void GetDivisionList()
        {
            divisions = DivisionBLL.Instance.GetDivisionList();
        }
        // Hiện danh sách phòng ban lên CBB_phongban
        private void DisplayDivisionsToCBB_phongban()
        {
            CBB_phongban.Enabled = true;
            CBB_phongban.Items.Clear();
            GetDivisionList();
            foreach (var division in divisions)
            {
                CBB_phongban.Items.Add(division.MaBoPhan + "-" + division.TenBoPhan);
            }
        }
        // Lấy danh sách nhóm
        private void GetGroupList()
        {
            string maBoPhan = CBB_phongban.SelectedItem.ToString().Split('-')[0];
            groups = GroupBLL.Instance.GetGroupListByDivisionId(maBoPhan);
        }
        // Hiện danh sách nhóm lên CBB_nhom
        private void DisplayGroupToCBB_nhom()
        {
            CBB_nhom.Enabled = true;
            CBB_nhom.Items.Clear();
            GetGroupList();
            foreach (var group in groups)
            {
                CBB_nhom.Items.Add(group.MaNhom);
            }
        }
        //Chuyển tiếng Việt sang tiếng Anh cho tên nhân viên
        private string ConvertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        // Tạo userId theo quy tắc trong file QA
        private void GenerateUserId()
        {
            string ten = ConvertToUnSign3(TXB_ten.Text.Substring(TXB_ten.Text.LastIndexOf(' ') + 1).ToUpper());
            string output = $"{TXB_manv.Text.Trim()}.{ten.Trim()}.{TXB_sdt.Text.Trim()}";
            TXB_manguoidung.Text = output;
        }
        // Kiểm tra các trường hợp khi ấn nút lưu

        private void BTN_luu_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (string.IsNullOrEmpty(TXB_manv.Text))
            {
                LB_emanv.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_ho.Text))
            {
                LB_eho.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_ten.Text))
            {
                LB_eten.Visible = true;
                error++;
            }
            if (!Rad_nam.Checked && !Rad_nu.Checked)
            {
                LB_egioitinh.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_honnhan.Text))
            {
                LB_ehonnhan.Visible = true;
                error++;
            }
            if (CBB_loainv.SelectedIndex == -1)
            {
                LB_eloainv.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_tinhtrangHDLD.Text))
            {
                LB_ehdld.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_sdt.Text))
            {
                LB_esdt.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_email.Text))
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_cccd.Text))
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_bhxh.Text))
            {
                LB_ebaohiem.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_quequan.Text))
            {
                LB_equequan.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_thuongtru.Text))
            {
                LB_ethuongtru.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_matkhau.Text))
            {
                LB_emk.Visible = true;
                error++;
            }
            if (error > 0)
            {
                return;
            }
            InitializeValues_NV();
            InitializeValues_TK();
            // Trường hợp tạo nhân viên mới
            if (employee == null)
            {
                MessageBox.Show(AddEmployee(AddParameter_NV()));
                AddAccount(AddParameter_TK());
                string maCEO = TXB_manv.Text.Split('-')[0];
                if (maCEO == "GD")
                {
                    EmployeeBLL.Instance.AddCEO(TXB_manv.Text);
                }
            }
            else // Trường hợp chỉnh sửa nhân viên
            {
                MessageBox.Show(UpdateEmployee(AddParameter_NV()));
                UpdateAccount(AddParameter_TK());
            }
        }
        private void TXB_manv_TextChanged(object sender, EventArgs e)
        {
            LB_emanv.Visible = false;
            GenerateUserId();
        }

        private void TXB_ten_TextChanged(object sender, EventArgs e)
        {
            LB_eten.Visible = false;
            GenerateUserId();
        }

        private void TXB_sdt_TextChanged(object sender, EventArgs e)
        {
            LB_esdt.Visible = false;
            GenerateUserId();
        }

        private void CBB_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBB_phongban.SelectedIndex != -1)
            {
                DisplayGroupToCBB_nhom();
            }
        }
        
        // Hiện loại nhân viên từ mảng loaiNV vào CBB_loainv
        private readonly string[] loaiNV = { "Intern / Trainne", "Part-time", "Full-time" };
        // Hiện thông tin chỉnh sửa nhân viên và tài khoản của nhân viên này lên các input tương ứng
        private void DisplayEmployeeeInfo()
        {
            // Hiện thông tin nhân viên
            GetGroupByEmployeeId();
            GetDivisionByEmployeeId();
            TXB_manv.Text = employee.MaNhanVien;
            TXB_ho.Text = employee.Ho;
            TXB_ten.Text = employee.Ten;
            DTP_ngaysinh.Value = employee.NgaySinh;
            if (employee.GioiTinh == true)
            {
                Rad_nam.Checked = true;
            }
            else
            {
                Rad_nu.Checked = true;
            }
            TXB_honnhan.Text = employee.TinhTrangHonNhan;
            CBB_loainv.SelectedIndex = Array.IndexOf(loaiNV, employee.LoaiNhanVien);
            if (employee.DaTungLamNhanVien)
            {
                CHB_tunglanv.Checked = true;
            }
            if (division != null)
            {
                CBB_phongban.SelectedIndex = CBB_phongban.Items.IndexOf(division.MaBoPhan + "-" + division.TenBoPhan);
            }
            else
            {
                CBB_phongban.SelectedIndex = -1;
            }
            CBB_nhom.Enabled = true;
            if (group != null)
            {
                CBB_nhom.SelectedIndex = CBB_nhom.Items.IndexOf(group.MaNhom);
            }
            else
            {
                CBB_nhom.SelectedIndex = -1;
            }
            DTP_ngayhetHDLD.Value = employee.NgayHetHDLD;
            DTP_ngaykyHDLD.Value = employee.NgayKyHDLD;
            TXB_tinhtrangHDLD.Text = employee.TinhTrangHDLD;
            TXB_sdt.Text = employee.SoDienThoai;
            TXB_email.Text = employee.Email;
            TXB_cccd.Text = employee.MaDinhDanh;
            TXB_bhxh.Text = employee.MaSoBHXH;
            TXB_quequan.Text = employee.QueQuan;
            TXB_thuongtru.Text = employee.DiaChiThuongTru;
            TXB_tamtru.Text = employee.DiaChiTamTru;
            // Không cho chỉnh sửa mã nhân viên
            TXB_manv.Enabled = false;

            // Hiện thông tin tài khoản
            Account account = employee.TaiKhoanNguoiDung;
            if (account.IsDisabled)
            {
                CHB_vohieuhoa.Checked = true;
            }
            TXB_matkhau.Text = account.Password;
            TXB_matkhau.UseSystemPasswordChar = true;
        }
        
        private void DisplayEmployeeType()
        {
            CBB_loainv.DataSource = loaiNV;
            CBB_loainv.SelectedIndex = -1;
        }
        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            // Nếu double click
            DisplayDivisionsToCBB_phongban();
            DisplayEmployeeType();
            if (employee != null)
            {
                DisplayEmployeeeInfo();
                CHB_vohieuhoa.Enabled = true;
                CHB_vohieuhoa.Visible = true;
            }
        }

        private void ThongTinCaNhan_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Refresh();
        }

        private void CHB_matkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_matkhau.Checked)
            {
                TXB_matkhau.UseSystemPasswordChar = false;
            }
            else
            {
                TXB_matkhau.UseSystemPasswordChar = true;
            }
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void ThongTinCaNhan_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ThongTinCaNhan_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ThongTinCaNhan_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_x_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXB_matkhau_TextChanged(object sender, EventArgs e)
        {
            LB_emk.Visible = false;
        }

        private void TXB_email_TextChanged(object sender, EventArgs e)
        {
            LB_eemail.Visible = false;
        }

        private void TXB_cccd_TextChanged(object sender, EventArgs e)
        {
            LB_ecccd.Visible = false;
        }

        private void TXB_bhxh_TextChanged(object sender, EventArgs e)
        {
            LB_ebaohiem.Visible = false;
        }

        private void TXB_quequan_TextChanged(object sender, EventArgs e)
        {
            LB_equequan.Visible = false;
        }

        private void TXB_thuongtru_TextChanged(object sender, EventArgs e)
        {
            LB_ethuongtru.Visible = false;
        }

        private void TXB_ho_TextChanged(object sender, EventArgs e)
        {
            LB_eho.Visible = false;
        }

        private void TXB_honnhan_TextChanged(object sender, EventArgs e)
        {
            LB_ehonnhan.Visible = false;
        }

        private void Rad_nam_CheckedChanged(object sender, EventArgs e)
        {
            LB_egioitinh.Visible = false;
        }

        private void Rad_nu_CheckedChanged(object sender, EventArgs e)
        {
            LB_egioitinh.Visible = false;
        }

        private void CBB_loainv_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_eloainv.Visible = false;
        }

        private void TXB_tinhtrangHDLD_TextChanged(object sender, EventArgs e)
        {
            LB_ehdld.Visible = false;
        }
    }
}
