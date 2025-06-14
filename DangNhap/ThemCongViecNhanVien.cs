using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
namespace DangNhap
{
    public partial class ThemCongViecNhanVien : Form
    {
        private readonly CongViecChung parent;
        private readonly Account currentAccount;
        public ThemCongViecNhanVien(CongViecChung parent, Account currentAccount)
        {
            InitializeComponent();
            this.parent = parent;
            this.currentAccount = currentAccount;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            currentFormChild?.Close();
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PN_hienthithemcongviec.Controls.Add(childForm);
            PN_hienthithemcongviec.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_nhanvien_Click(object sender, EventArgs e)
        {
            currentFormChild?.Close();
            BTN_nhanvien.BackColor = Color.FromArgb(51, 53, 55);
            BTN_nhom.BackColor = Color.Transparent;
            BTN_phongban.BackColor = Color.Transparent;
        }

        private void BTN_phongban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThemCongViecPhongBan(parent, currentAccount));
            BTN_phongban.BackColor = Color.FromArgb(51, 53, 55);
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_nhom.BackColor = Color.Transparent;
        }

        private void BTN_nhom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThemCongViecNhom(parent, currentAccount));
            BTN_nhom.BackColor = Color.FromArgb(51, 53, 55);
            BTN_phongban.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
        }
        //MoveForm
        int mov;
        int movX;
        int movY;
        private void ThemCongViecNhanVien_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ThemCongViecNhanVien_MousMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ThemCongViecNhanVien_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        public List<Division> GetPhongBan()
        {
            List<Division> listMaPB;
            listMaPB = DivisionBLL.Instance.GetDivisionList();
            return listMaPB;
        }
        private void ReadPhongBan()
        {
            List<Division> listPB;
            CBB_phongban.Enabled = true;
            CBB_phongban.Items.Clear();
            listPB = GetPhongBan();

            DataTable listQuanLy = EmployeeBLL.Instance.GetManager();
            bool isManager = false;
            bool isDV = false;
            string maBoPhan = "";

            foreach (DataRow row in listQuanLy.Rows)
            {
                if (row["maNhanVien"].ToString().Equals(currentAccount.EmployeeId) )
                {
                    isManager = true;
                    if (row["maNhanVien"].ToString().Split('-')[0].Equals("DV"))
                    {
                        isDV = true;
                    }
                    maBoPhan = row["maNhanVien"].ToString().Split('-')[0];
                    break;
                }
            }

            // Quản lý chỉ có thể thêm công việc cho Phòng ban mình quản lý và không phải DV
            if (isManager && !isDV)
            {
                for (int i = 0; i < listPB.Count; i++)
                {
                    if(!string.IsNullOrEmpty(maBoPhan))
                        if(listPB[i].MaBoPhan.Equals(maBoPhan))
                            CBB_phongban.Items.Add(listPB[i].MaBoPhan + "-" + listPB[i].TenBoPhan);
                }
                return;
            }
            // Nếu không phải quản lý và là DV
            for (int i = 0; i < listPB.Count; i++)
            {
                if (currentAccount.Level.Equals("DV") && listPB[i].MaBoPhan.Equals("TC"))
                    continue;
                CBB_phongban.Items.Add(listPB[i].MaBoPhan + "-" + listPB[i].TenBoPhan);
            }
        }

        private List<Group> GetNhom(string maBoPhan)
        {
            List<Group> list;
            list = GroupBLL.Instance.GetGroupListByDivisionId(maBoPhan);
            return list;
        }
        private void ReadNhom()
        {
            CBB_nhom.Enabled = true;
            CBB_nhom.Items.Clear();
            string maBoPhan = CBB_phongban.SelectedItem.ToString().Split('-')[0];
            List<Group> listNhom;
            listNhom = GetNhom(maBoPhan);
            for (int i = 0; i < listNhom.Count; i++)
            {
                CBB_nhom.Items.Add((listNhom[i].MaNhom));
            }
        }


        private List<Employee> GetNV(string maNhom)
        {
            List<Employee> list;
            list = EmployeeBLL.Instance.GetEmployeesByGroup(maNhom);
            return list;
        }
        private void ReadNV()
        {
            CBB_manhanvien.Enabled = true;
            CBB_manhanvien.Items.Clear();
            List<Employee> listNV;
            listNV = GetNV(CBB_nhom.SelectedItem.ToString());
            for (int i = 0; i < listNV.Count; i++)
            {
                CBB_manhanvien.Items.Add(listNV[i].MaNhanVien + "_" + listNV[i].Ten);
            }
        }

        private void ThemCongViecNhanVien_Load(object sender, EventArgs e)
        {
            ReadPhongBan();
        }


        private void CBB_nhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBB_nhom.SelectedIndex != -1)
            {
                ReadNV();
            }
        }

        private void CBB_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBB_phongban.SelectedIndex != -1)
            {
                ReadNhom();
            }
        }

        public string maCongViec;
        public byte[] buffer = null;
        public string fileName;
        private void GetNewestJobID()
        {
            maCongViec = JobBLL.Instance.GetNewJobID();
            TXB_MaCongViec.Text = maCongViec;
        }
        private void CBB_manhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBB_manhanvien.SelectedIndex != -1)
            {
                TXB_noidung.Enabled = true;
                TXB_macanho.Enabled = true;
                GetNewestJobID();
                BTN_file.Enabled = true;
                TXB_ghiChu.Enabled = true;
                CBB_QuyenTruyCap.Enabled = true;
                TXB_PhiDichVu.Enabled = true;   
            }
        }

        private void CBB_phongban_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CBB_phongban.SelectedIndex != -1)
            {
                CBB_nhom.SelectedIndex = -1;
                CBB_manhanvien.SelectedIndex = -1;
                ReadNhom();
            }
        }

        private void CBB_nhom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CBB_nhom.SelectedIndex != -1)
            {
                CBB_manhanvien.SelectedIndex = -1;
                ReadNV();
            }
        }

        private int GetQuyenTruyCap()
        {
            int ch = 0; // mặc định là riêng tư
            if(CBB_QuyenTruyCap.SelectedItem.ToString().Equals("Bộ phận") || CBB_QuyenTruyCap.SelectedItem.ToString().Equals("Division"))
            {
                ch = 1;
            }
            if(CBB_QuyenTruyCap.SelectedItem.ToString().Equals("Công ty") || CBB_QuyenTruyCap.SelectedItem.ToString().Equals("Company"))
            {
                ch = 2;
            }
            return ch;
        }
        // Tạo tham số cho bảng CongViec để truyền vào DataProvider
        
        private Dictionary<string, object> AddParameterCongViec()
        {
            string thoiHan = null;
            if (CB_thoihan.Checked == true)
            {
                thoiHan = DTP_ngay.Value.ToString("yyyy-MM-dd") + " " + DTP_gio.Text.Split(' ')[0].ToString();
            }
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@noiDung", TXB_noidung.Text},
                {"@ngayGiao", DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss")},
                {"@thoihan", thoiHan},
                {"@ngayHoanThanh", null},
                {"@ngayCapNhat", null},
                {"@trangThai", "Chưa bắt đầu"},
                {"@ghiChu", TXB_ghiChu.Text},
                {"@quyenTruyCap", GetQuyenTruyCap()},
                {"@phiDichVu", int.Parse(TXB_PhiDichVu.Text)}
            };
            return dict;
        }

        // Tạo tham số cho bảng CongViec_NhanVien để truyền vào DataProvider
        private Dictionary<string, object> AddParameterCongViec_NhanVien()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maNhanVien",  CBB_manhanvien.SelectedItem.ToString().Split('_')[0].ToString()},
                {"@maCongViec", TXB_MaCongViec.Text},
            };
            return dict;
        }
        // Tạo tham số cho bảng YeuCau để truyền vào DataProvider
        private Dictionary<string, object> AddParameterYeuCau()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maCongViec", TXB_MaCongViec.Text},
                {"@maCanHo", TXB_macanho.Text}
            };
            return dict;
        }

        private Dictionary<string, object> AddParameterPDF()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maCongViec", TXB_MaCongViec.Text},
                {"@pdffile", buffer},
                {"@tenFile", fileName },
                {"@fileExten", ".pdf" }
            };
            return dict;
        }
        private bool SaveCongViec()
        {
            if (JobBLL.Instance.AddJob(AddParameterCongViec()))
            {
                if (JobBLL.Instance.AddJob_Employee(AddParameterCongViec_NhanVien()))
                {
                    if (JobBLL.Instance.AddRequestFromCustom(AddParameterYeuCau()))
                    {
                        if (buffer != null)
                        {
                            if (JobBLL.Instance.AddJob_PDF(AddParameterPDF()))
                            {
                                return true;
                            }
                        }
                        else
                            return true;
                    }
                }
            }
            return false;
        }
        // Kiểm tra phí dịch vụ điền vào có phải là 1 số hợp lệ hay không
        private bool IsValidInteger(string input)
        {
            return int.TryParse(input, out _);
        }
        private void BTN_ok_Click(object sender, EventArgs e)
        {
            //Tiếng Anh
            if(LB_themcongviec.Text == "THÊM CÔNG VIỆC")
            {
                if (string.IsNullOrEmpty(TXB_noidung.Text))
                {
                    MessageBox.Show("Vui lòng điền nội dung công việc");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_macanho.Text))
                {
                    MessageBox.Show("Vui lòng điền mã căn hộ");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_MaCongViec.Text))
                {
                    MessageBox.Show("Vui lòng điền mã công việc");
                    return;
                }
                if (CBB_QuyenTruyCap.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn quyền hạn truy cập");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_PhiDichVu.Text))
                {
                    MessageBox.Show("Vui lòng điền phí dịch vụ");
                    TXB_PhiDichVu.Focus();
                    return;
                }
                if (!IsValidInteger(TXB_PhiDichVu.Text))
                {
                    MessageBox.Show("Vui lòng điền phí dịch vụ hợp lệ");
                    return;
                }
                if (SaveCongViec())
                {
                    MessageBox.Show("Thêm thành công");
                    parent.Display_GGC_nhanvien();
                    RestoreBTN();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            //Tiếng Anh
            else
            {
                if (string.IsNullOrEmpty(TXB_noidung.Text))
                {
                    MessageBox.Show("Please enter \"Content\"");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_macanho.Text))
                {
                    MessageBox.Show("Please enter \"Apartment ID\"");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_MaCongViec.Text))
                {
                    MessageBox.Show("Please enter \"Task ID\"");
                    return;
                }
                if (CBB_QuyenTruyCap.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select \"Access level\"");
                    return;
                }
                if (string.IsNullOrEmpty(TXB_PhiDichVu.Text))
                {
                    MessageBox.Show("Please enter \"Service fee\"");
                    TXB_PhiDichVu.Focus();
                    return;
                }
                if (!IsValidInteger(TXB_PhiDichVu.Text))
                {
                    MessageBox.Show("\"Service fee\" is invalid");
                    return;
                }
                if (SaveCongViec())
                {
                    MessageBox.Show("Added Successfully");
                    parent.Display_GGC_nhanvien();
                    RestoreBTN();
                }
                else
                {
                    MessageBox.Show("Added Failed");
                }
            }

        }

        private void BTN_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Tiếng Việt
                    if(LB_themcongviec.Text == "THÊM CÔNG VIỆC")
                    {
                        DialogResult dialog = MessageBox.Show("Bạn có chắc muốn upload file này chứ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            string file = dlg.FileName;
                            buffer = File.ReadAllBytes(file);
                            string[] words = file.Split('\\');
                            int length = words.Length;
                            fileName = words[length - 1];
                        }
                    }
                    //Tiếng Anh
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure to upload this file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            string file = dlg.FileName;
                            buffer = File.ReadAllBytes(file);
                            string[] words = file.Split('\\');
                            int length = words.Length;
                            fileName = words[length - 1];
                        }
                    }
                    
                }
            }
            LLB_hienfile.Text = fileName;
            LLB_hienfile.Show();
        }
        private void RestoreBTN()
        {
            CBB_QuyenTruyCap.SelectedIndex = -1;
            CBB_phongban.SelectedIndex = -1;
            CBB_nhom.SelectedIndex = -1;
            CBB_manhanvien.SelectedIndex = -1;
            TXB_noidung.Clear();
            TXB_MaCongViec.Clear();
            TXB_macanho.Clear();
            TXB_PhiDichVu.Clear();
            CBB_nhom.Enabled = false;
            CBB_manhanvien.Enabled = false;
            TXB_noidung.Enabled = false;
            TXB_macanho.Enabled = false;
            TXB_MaCongViec.Enabled = false;
            CB_thoihan.Checked = false;
            BTN_file.Enabled = false;
            TXB_ghiChu.Enabled = false;
            CBB_QuyenTruyCap.Enabled = false;
            TXB_PhiDichVu.Enabled = false;
        }
        private void BTN_huy_Click(object sender, EventArgs e)
        {
            RestoreBTN();
        }

        private void CB_thoihan_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_thoihan.Checked == true)
            {
                DTP_gio.Enabled = true;
                DTP_ngay.Enabled = true;
            }
            else
            {
                DTP_gio.Enabled = false;
                DTP_ngay.Enabled = false;
            }
        }
    }
}
