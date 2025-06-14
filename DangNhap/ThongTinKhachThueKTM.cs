using BLL;
using DAO;
using DTO;
using Spire.Xls;
using Syncfusion.Windows.Shared;
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
    public partial class ThongTinKhachThueKTM : Form
    {
        private readonly CuDan parent;
        private readonly KhachThueKhuThuongMai khachKTM = null;
        public ThongTinKhachThueKTM(CuDan parent, KhachThueKhuThuongMai khachKTM)
        {
            InitializeComponent();
            this.parent = parent;
            this.khachKTM = khachKTM;
        }
        public ThongTinKhachThueKTM(CuDan parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void DisplayKhachKTM()
        {
            TXB_makhachthue.Text = khachKTM.MaKhachDangThue;
            TXB_tencongty.Text = khachKTM.TenCongTy;
            TXB_hotendaidien.Text = khachKTM.HoTenNguoiDaiDien;
            TXB_sdt.Text = khachKTM.SoDienThoai;
            TXB_email.Text = khachKTM.Email;
            DTP_ngaykyhd.Value = khachKTM.NgayKyHopDongThue;
            DTP_vao.Value = khachKTM.NgayChuyenVao;
            if (khachKTM.NgayChuyenDi != null)
            {
                DTP_di.Value = (DateTime)khachKTM.NgayChuyenDi;
            }
            else
            {
                DTP_di.Visible = false;
            }
            TXB_mota.Text = khachKTM.MoTaKhuVucChoThue;
            NUD_phiql.Value = khachKTM.PhiQuanLy;
            Vehicle phuongTien = VehicleBLL.Instance.GetVehicleByBienSo(khachKTM.BienSoXeDangKy);
            if (phuongTien != null)
            {
                TXB_bienso.Text = khachKTM.BienSoXeDangKy;
                TXB_loaixe.Text = phuongTien.ChungLoai;
                TXB_tinhtrangxe.Text = phuongTien.TinhTrangSoHuu;
            }
            
            CBB_manv.SelectedItem = khachKTM.MaNhanVienPhuTrach;
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongTinCuDan_Load(object sender, EventArgs e)
        {
            CBB_manv.DataSource = EmployeeBLL.Instance.GetEmployeeList()
                    .Select(i => i.MaNhanVien) 
                    .ToList();
            if (khachKTM != null)
            {
                DisplayKhachKTM();
            }
            else
            {
                BTN_xoa.Visible = false;
            }
        }
        private object[] values_k;
        private void InitializeValues_K()
        {
            values_k = new object[]
            {
                TXB_makhachthue.Text,
                TXB_tencongty.Text,
                TXB_hotendaidien.Text,
                CBB_manv.SelectedItem,
                TXB_sdt.Text,
                TXB_email.Text,
                DTP_ngaykyhd.Value,
                DTP_vao.Value,
                DTP_di.Value,
                (int)NUD_phiql.Value,
                TXB_mota.Text,
                TXB_bienso.Text == "" ? "" : TXB_bienso.Text
            };
        }

        // Tạo dictionary để truyền vào DataProvider
        private Dictionary<string, object> AddParameter_K()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maKhachDangThue", values_k[0] },
                { "@tenCongTy", values_k[1] },
                { "@hoTenNguoiDaiDien", values_k[2] },
                { "@maNhanVienPhuTrach", values_k[3] },
                { "@SDT", values_k[4] },
                { "@email", values_k[5] },
                { "@ngayKyHopDongThue", values_k[6] },
                { "@ngayChuyenVao", values_k[7] },
                { "@ngayChuyenDi", values_k[8] },
                { "@phiQuanLy", values_k[9] },
                { "@moTaKhuVucChoThue", values_k[10] },
                { "@bienSoXeDangKy", values_k[11] },
            };
            return dict;
        }
        private object[] values_pt;
        private void InitializeValues_PT()
        {
            values_pt = new object[]
            {
                TXB_bienso.Text,
                TXB_loaixe.Text,
                TXB_tinhtrangxe.Text
            };
        }

        // Tạo dictionary để truyền vào DataProvider
        private Dictionary<string, object> AddParameter_PT()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@bienSo", values_pt[0] },
                { "@chungLoai", values_pt[1] },
                { "@tinhTrangSoHuu", values_pt[2] },
            };
            return dict;
        }
        private void BTN_luu_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (string.IsNullOrEmpty(TXB_makhachthue.Text))
            {
                LB_errmakhachthue.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_tencongty.Text))
            {
                LB_errortencty.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_hotendaidien.Text))
            {
                LB_errhoten.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_sdt.Text))
            {
                LB_errorsdt.Visible = true;
                error++;
            }
            if (string.IsNullOrEmpty(TXB_email.Text))
            {
                LB_erroremail.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_errorloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_errortinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                if (khachKTM == null)
                {
                    InitializeValues_K();
                    MessageBox.Show(KhachThueKhuThuongMaiBLL.Instance.AddKhachThueKTM(AddParameter_K()));
                    if (!string.IsNullOrEmpty(TXB_bienso.Text))
                    {
                        InitializeValues_PT();
                        VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                    }
                    parent.DisplayGGC_khachthuektm();
                }
                else
                {
                    InitializeValues_K();
                    MessageBox.Show(KhachThueKhuThuongMaiBLL.Instance.UpdateKhachThueKTM(AddParameter_K()));
                    if (!string.IsNullOrEmpty(TXB_bienso.Text))
                    {
                        if (VehicleBLL.Instance.GetVehicleByBienSo(khachKTM.BienSoXeDangKy) != null)
                        {
                            InitializeValues_PT();
                            VehicleBLL.Instance.UpdateVehicle(AddParameter_PT());
                        }
                        else
                        {
                            InitializeValues_PT();
                            VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                        }
                        parent.DisplayGGC_khachthuektm();
                    }
                }
            }
        }

        private void TXB_makhachthue_TextChanged(object sender, EventArgs e)
        {
            LB_errmakhachthue.Visible = false;
        }

        private void TXB_tencongty_TextChanged(object sender, EventArgs e)
        {
            LB_errortencty.Visible = false;
        }

        private void TXB_hotendaidien_TextChanged(object sender, EventArgs e)
        {
            LB_errhoten.Visible = false;
        }

        private void TXB_sdt_TextChanged(object sender, EventArgs e)
        {
            LB_errorsdt.Visible = false;
        }

        private void TXB_email_TextChanged(object sender, EventArgs e)
        {
            LB_erroremail.Visible = false;
        }

        private void TXB_loaixe_TextChanged(object sender, EventArgs e)
        {
            LB_errorloaixe.Visible = false;
        }

        private void TXB_tinhtrangxe_TextChanged(object sender, EventArgs e)
        {
            LB_errortinhtrangxe.Visible = false;
        }

        private void BTN_xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách thuê khu thương mại này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string deleteMessage = KhachThueKhuThuongMaiBLL.Instance.DeleteKhachThueKTM(khachKTM.MaKhachDangThue, khachKTM.BienSoXeDangKy);
                parent.DisplayGGC_khachthuektm();
                MessageBox.Show(deleteMessage);
                Close();
            }
        }

        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void TTKTM_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void TTKTM_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void TTKTM_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
