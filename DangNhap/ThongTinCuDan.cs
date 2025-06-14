using BLL;
using DAO;
using DTO;
using Spire.Xls;
using Syncfusion.Windows.Shared;
using Syncfusion.XlsIO.Parser.Biff_Records;
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
    public partial class ThongTinCuDan : Form
    {
        private readonly CuDan parent;
        private readonly ChuHo chuHo = null;
        private readonly NguoiDcUyQuyenChuHo nguoiDcUyQuyen = null;
        private readonly KhachNganNgay khachNganNgay = null;
        private readonly int type;
        public ThongTinCuDan(CuDan parent, int type)
        {
            InitializeComponent();
            this.parent = parent;
            this.type = type;
        }
        public ThongTinCuDan(CuDan parent, ChuHo chuHo)
        {
            InitializeComponent();
            this.parent = parent;
            this.chuHo = chuHo;
        }
        public ThongTinCuDan(CuDan parent, NguoiDcUyQuyenChuHo nguoiDcUyQuyen)
        {
            InitializeComponent();
            this.parent = parent;
            this.nguoiDcUyQuyen = nguoiDcUyQuyen;
        }
        public ThongTinCuDan(CuDan parent, KhachNganNgay khachNganNgay)
        {
            InitializeComponent();
            this.parent = parent;
            this.khachNganNgay = khachNganNgay;
        }
        public void DisplayChuHo()
        {
            TXB_macanho.Text = chuHo.MaCanHo;
            TXB_macd.Text = chuHo.MaCuDan;
            CBB_loaicd.SelectedItem = chuHo.LoaiCuDan;
            TXB_hovaten.Text = chuHo.HoTen;
            TXB_quoctich.Text = chuHo.QuocTich;
            DTP_ngaysinh.Value = chuHo.NgaySinh;
            TXB_madinhdanh.Text = chuHo.MaDinhDanh;
            TXB_sdt.Text = chuHo.SoDienThoai;
            TXB_email.Text = chuHo.Email;
            TXB_sothetamtru.Text = chuHo.SoTheTamTru;
            DTP_vao.Value = chuHo.NgayChuyenVao;
            if (chuHo.NgayChuyenDi != null)
            {
                DTP_di.Value = (DateTime)chuHo.NgayChuyenDi;
            }
            else
            {
                DTP_di.Visible = false;
            }
            DTP_bangiao.Value = chuHo.NgayNhanBanGiaoCanHo;
            TXB_diennuoc.Text = chuHo.SoDienNuocNgayBanGiao.ToString();
            NUD_congno.Value = chuHo.TinhTrangCongNo;
            TXB_thunuoi.Text = chuHo.DuLieuDangKyThuNuoi;
            CBB_nguoithan.SelectedItem = chuHo.MaCuDanLuuTruCung;
            Vehicle phuongTien = VehicleBLL.Instance.GetVehicleByBienSo(chuHo.BienSoXeDangKy);
            if (phuongTien != null)
            {
                TXB_bienso.Text = chuHo.BienSoXeDangKy;
                TXB_loaixe.Text = phuongTien.ChungLoai;
                TXB_tinhtrangxe.Text = phuongTien.TinhTrangSoHuu;
            }
        }
        private void DisplayNguoiUyQuyen()
        {
            TXB_macanho.Text = nguoiDcUyQuyen.MaCanHo;
            TXB_macd.Text = nguoiDcUyQuyen.MaCuDan;
            CBB_loaicd.SelectedItem = nguoiDcUyQuyen.LoaiCuDan;
            TXB_hovaten.Text = nguoiDcUyQuyen.HoTen;
            TXB_quoctich.Text = nguoiDcUyQuyen.QuocTich;
            DTP_ngaysinh.Value = nguoiDcUyQuyen.NgaySinh;
            TXB_madinhdanh.Text = nguoiDcUyQuyen.MaDinhDanh;
            TXB_sdt.Text = nguoiDcUyQuyen.SoDienThoai;
            TXB_email.Text = nguoiDcUyQuyen.Email;
            TXB_sothetamtru.Text = nguoiDcUyQuyen.SoTheTamTru;
            DTP_vao.Value = nguoiDcUyQuyen.NgayChuyenVao;
            if (nguoiDcUyQuyen.NgayChuyenDi != null)
            {
                DTP_di.Value = (DateTime)nguoiDcUyQuyen.NgayChuyenDi;
            }
            else
            {
                DTP_di.Visible = false;
            }
            NUD_congno.Value = nguoiDcUyQuyen.TinhTrangCongNo;
            TXB_thunuoi.Text = nguoiDcUyQuyen.DuLieuDangKyThuNuoi;
            CBB_nguoithan.SelectedItem = nguoiDcUyQuyen.MaCuDanLuuTruCung;
            Vehicle phuongTien = VehicleBLL.Instance.GetVehicleByBienSo(nguoiDcUyQuyen.BienSoXeDangKy);
            if (phuongTien != null)
            {
                TXB_bienso.Text = nguoiDcUyQuyen.BienSoXeDangKy;
                TXB_loaixe.Text = phuongTien.ChungLoai;
                TXB_tinhtrangxe.Text = phuongTien.TinhTrangSoHuu;
            }

            LB_bangiao.Visible = false;
            LB_diennuoc.Visible = false;
            DTP_bangiao.Visible = false;
            TXB_diennuoc.Visible = false;
            LB_nguoithan.Location = new Point(LB_bangiao.Location.X, LB_bangiao.Location.Y);
            CBB_nguoithan.Location = new Point(DTP_bangiao.Location.X, DTP_bangiao.Location.Y);
            LB_congno.Location = new Point(LB_diennuoc.Location.X, LB_diennuoc.Location.Y + 10);
            NUD_congno.Location = new Point(TXB_diennuoc.Location.X, TXB_diennuoc.Location.Y + 10);
            LB_thunuoi.Location = new Point(LB_congno.Location.X, LB_congno.Location.Y + 50);
            TXB_thunuoi.Location = new Point(NUD_congno.Location.X, NUD_congno.Location.Y + 50);
            LB_bienso.Location = new Point(LB_thunuoi.Location.X, LB_thunuoi.Location.Y + 50);
            TXB_bienso.Location = new Point(TXB_thunuoi.Location.X, TXB_thunuoi.Location.Y + 50);
            LB_loaixe.Location = new Point(LB_bienso.Location.X, LB_bienso.Location.Y + 50);
            TXB_loaixe.Location = new Point(TXB_bienso.Location.X, TXB_bienso.Location.Y + 50);
            LB_tinhtrangxe.Location = new Point(LB_loaixe.Location.X, LB_loaixe.Location.Y + 50);
            TXB_tinhtrangxe.Location = new Point(TXB_loaixe.Location.X, TXB_loaixe.Location.Y + 50);
        }
        private void DisplayKhachNganNgay()
        {
            TXB_macanho.Text = khachNganNgay.MaCanHo;
            TXB_macd.Text = khachNganNgay.MaCuDan;
            CBB_loaicd.SelectedItem = khachNganNgay.LoaiCuDan;
            TXB_hovaten.Text = khachNganNgay.HoTen;
            TXB_quoctich.Text = khachNganNgay.QuocTich;
            DTP_ngaysinh.Value = khachNganNgay.NgaySinh;
            TXB_madinhdanh.Text = khachNganNgay.MaDinhDanh;
            TXB_sdt.Text = khachNganNgay.SoDienThoai;
            TXB_email.Text = khachNganNgay.Email;
            TXB_sothetamtru.Text = khachNganNgay.SoTheTamTru;
            DTP_vao.Value = khachNganNgay.NgayChuyenVao;
            if (khachNganNgay.NgayChuyenDi != null)
            {
                DTP_di.Value = (DateTime)khachNganNgay.NgayChuyenDi;
            }
            else
            {
                DTP_di.Visible = false;
            }
            NUD_congno.Value = khachNganNgay.TinhTrangCongNo;
            TXB_thunuoi.Text = khachNganNgay.DuLieuDangKyThuNuoi;
            CBB_nguoithan.SelectedItem = khachNganNgay.MaCuDanLuuTruCung;
            Vehicle phuongTien = VehicleBLL.Instance.GetVehicleByBienSo(khachNganNgay.BienSoXeDangKy);
            if (phuongTien != null)
            {
                TXB_bienso.Text = khachNganNgay.BienSoXeDangKy;
                TXB_loaixe.Text = phuongTien.ChungLoai;
                TXB_tinhtrangxe.Text = phuongTien.TinhTrangSoHuu;
            }

            LB_bangiao.Visible = false;
            LB_diennuoc.Visible = false;
            DTP_bangiao.Visible = false;
            TXB_diennuoc.Visible = false;

            LB_nguoithan.Location = new Point(LB_bangiao.Location.X, LB_bangiao.Location.Y);
            CBB_nguoithan.Location = new Point(DTP_bangiao.Location.X, DTP_bangiao.Location.Y);
            LB_congno.Location = new Point(LB_diennuoc.Location.X, LB_diennuoc.Location.Y + 10);
            NUD_congno.Location = new Point(TXB_diennuoc.Location.X, TXB_diennuoc.Location.Y + 10);
            LB_thunuoi.Location = new Point(LB_congno.Location.X, LB_congno.Location.Y + 50);
            TXB_thunuoi.Location = new Point(NUD_congno.Location.X, NUD_congno.Location.Y + 50);
            LB_bienso.Location = new Point(LB_thunuoi.Location.X, LB_thunuoi.Location.Y + 50);
            TXB_bienso.Location = new Point(TXB_thunuoi.Location.X, TXB_thunuoi.Location.Y + 50);
            LB_loaixe.Location = new Point(LB_bienso.Location.X, LB_bienso.Location.Y + 50);
            TXB_loaixe.Location = new Point(TXB_bienso.Location.X, TXB_bienso.Location.Y + 50);
            LB_tinhtrangxe.Location = new Point(LB_loaixe.Location.X, LB_loaixe.Location.Y + 50);
            TXB_tinhtrangxe.Location = new Point(TXB_loaixe.Location.X, TXB_loaixe.Location.Y + 50);
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongTinCuDan_Load(object sender, EventArgs e)
        {
            CBB_nguoithan.DataSource = ResidentBLL.Instance.GetAllResidentID();
            CBB_nguoithan.SelectedIndex = -1;
                    
            if (chuHo != null && nguoiDcUyQuyen == null && khachNganNgay == null)
            {
                DisplayChuHo();
            }
            else if (chuHo == null && nguoiDcUyQuyen != null && khachNganNgay == null)
            {
                DisplayNguoiUyQuyen();
            }
            else if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay != null)
            {
                DisplayKhachNganNgay();
            }
            else if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay == null)
            {
                if (type == 1 || type == 2)
                {
                    LB_bangiao.Visible = false;
                    LB_diennuoc.Visible = false;
                    DTP_bangiao.Visible = false;
                    TXB_diennuoc.Visible = false;

                    LB_nguoithan.Location = new Point(LB_bangiao.Location.X, LB_bangiao.Location.Y);
                    CBB_nguoithan.Location = new Point(DTP_bangiao.Location.X, DTP_bangiao.Location.Y);
                    LB_congno.Location = new Point(LB_diennuoc.Location.X, LB_diennuoc.Location.Y + 10);
                    NUD_congno.Location = new Point(TXB_diennuoc.Location.X, TXB_diennuoc.Location.Y + 10);
                    LB_thunuoi.Location = new Point(LB_congno.Location.X, LB_congno.Location.Y + 50);
                    TXB_thunuoi.Location = new Point(NUD_congno.Location.X, NUD_congno.Location.Y + 50);
                    LB_bienso.Location = new Point(LB_thunuoi.Location.X, LB_thunuoi.Location.Y + 50);
                    TXB_bienso.Location = new Point(TXB_thunuoi.Location.X, TXB_thunuoi.Location.Y + 50);
                    LB_loaixe.Location = new Point(LB_bienso.Location.X, LB_bienso.Location.Y + 50);
                    TXB_loaixe.Location = new Point(TXB_bienso.Location.X, TXB_bienso.Location.Y + 50);
                    LB_tinhtrangxe.Location = new Point(LB_loaixe.Location.X, LB_loaixe.Location.Y + 50);
                    TXB_tinhtrangxe.Location = new Point(TXB_loaixe.Location.X, TXB_loaixe.Location.Y + 50);
                }
                if (type == 0)
                {
                    CBB_loaicd.SelectedIndex = 0;
                    CBB_loaicd.Enabled = false;
                }
                else if (type == 1)
                {
                    CBB_loaicd.SelectedIndex = 1;
                    CBB_loaicd.Enabled = false;
                }
                else
                {
                    CBB_loaicd.DataSource = new string[] { "Khách ngắn ngày", "Khách vãng lai", "Nhân viên của chủ hộ"};
                    CBB_loaicd.SelectedIndex = -1;
                }
            }
        }

        private void BTN_xoa_Click(object sender, EventArgs e)
        {
            //Tiếng Việt
            if(BTN_xoa.Text == "Xóa")
            {
                if (chuHo != null && nguoiDcUyQuyen == null && khachNganNgay == null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa cư dân này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = ChuHoBLL.Instance.DeleteChuHo(chuHo.MaCuDan, chuHo.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(chuHo.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_chuho();
                        Close();
                    }
                }
                else if (chuHo == null && nguoiDcUyQuyen != null && khachNganNgay == null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa cư dân này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = NguoiDcUyQuyenChuHoBLL.Instance.DeleteNguoiUyQuyen(nguoiDcUyQuyen.MaCuDan, nguoiDcUyQuyen.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(nguoiDcUyQuyen.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_uyquyen();
                        Close();
                    }
                }
                else if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa cư dân này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = KhachNganNgayBLL.Instance.DeleteKhachNganNgay(khachNganNgay.MaCuDan, khachNganNgay.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(khachNganNgay.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_khachnganngay();
                        Close();
                    }
                }
            }
            //Tiếng Anh
            else
            {
                if (chuHo != null && nguoiDcUyQuyen == null && khachNganNgay == null)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this resident?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = ChuHoBLL.Instance.DeleteChuHo(chuHo.MaCuDan, chuHo.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(chuHo.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_chuho();
                        Close();
                    }
                }
                else if (chuHo == null && nguoiDcUyQuyen != null && khachNganNgay == null)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this resident?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = NguoiDcUyQuyenChuHoBLL.Instance.DeleteNguoiUyQuyen(nguoiDcUyQuyen.MaCuDan, nguoiDcUyQuyen.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(nguoiDcUyQuyen.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_uyquyen();
                        Close();
                    }
                }
                else if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this resident?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string deleteMessage = KhachNganNgayBLL.Instance.DeleteKhachNganNgay(khachNganNgay.MaCuDan, khachNganNgay.BienSoXeDangKy);
                        ResidentBLL.Instance.DeleteCuDan(khachNganNgay.MaCuDan);
                        MessageBox.Show(deleteMessage);
                        parent.DisplayGGC_khachnganngay();
                        Close();
                    }
                }
            }

        }
        private object[] values_ch;
        private void InitializeValues_CH()
        {
            values_ch = new object[]
            {
                TXB_macd.Text,
                TXB_macanho.Text,
                CBB_loaicd.SelectedItem,
                TXB_hovaten.Text,
                DTP_ngaysinh.Value,
                TXB_madinhdanh.Text,
                TXB_sdt.Text,
                TXB_email.Text,
                TXB_quoctich.Text,
                TXB_sothetamtru.Text,
                DTP_bangiao.Value,
                DTP_vao.Value,
                DTP_di.Value,
                Convert.ToDouble(TXB_diennuoc.Text),
                TXB_bienso.Text == "" ? "" : TXB_bienso.Text,
                "",
                CBB_nguoithan.SelectedItem,
                (int)NUD_congno.Value,
                TXB_thunuoi.Text
            };
        }

        // Tạo dictionary để truyền vào DataProvider
        private Dictionary<string, object> AddParameter_CH()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCuDan", values_ch[0] },
                { "@maCanHo", values_ch[1] },
                { "@loaiCuDan", values_ch[2] },
                { "@hoTen", values_ch[3] },
                { "@ngayThangNamSinh", values_ch[4] },
                { "@maDinhDanh", values_ch[5] },
                { "@SDT", values_ch[6] },
                { "@email", values_ch[7] },
                { "@quocTich", values_ch[8] },
                { "@soTheTamTru", values_ch[9] },
                { "@ngayNhanBanGiaoCanHo", values_ch[10] },
                { "@ngayChuyenVao", values_ch[11] },
                { "@ngayChuyenDi", values_ch[12] },
                { "@soDienNuocNgayBanGiao", values_ch[13] },
                { "@bienSoXeDangKy", values_ch[14] },
                { "@banGiao_maCuDan", values_ch[15] },
                { "@maCuDanLuuTruCung", values_ch[16] },
                { "@tinhTrangCongNo", values_ch[17] },
                { "@duLieuDangKyThuNuoi", values_ch[18] }

            };
            return dict;
        }

        // Tạo Dictionary cho Cư dân
        private Dictionary<string, object> AddParameter_CuDan_CH()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCuDan", values_ch[0] },
                { "@hoTen", values_ch[3] },
                { "@ngaySinh", values_ch[4] },
                { "@maDinhDanh", values_ch[5] },
                { "@SDT", values_ch[6] },
                { "@email", values_ch[7] },
                { "@soTheTamTru", values_ch[9] },
                { "@ngayChuyenVao", values_ch[11] },
                { "@ngayChuyenDi", values_ch[12] },
                { "@soDienNuocHangThang", values_ch[13] },
                { "@tinhTrangCongNo", values_ch[17] },
                { "@duLieuDangKyThuNuoi", values_ch[18] },
                { "@quocTich", values_ch[8] },
                { "@maCuDanNguoiThan", values_ch[16] },

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
        private void ThemChuHo()
        {
            
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_diennuoc.Text == "")
            {
                LB_ediennuoc.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_CH();
                ResidentBLL.Instance.AddCuDan(AddParameter_CuDan_CH());
                MessageBox.Show(ChuHoBLL.Instance.AddChuHo(AddParameter_CH()));
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_chuho();
            }
        }
        private object[] values_both;
        private void InitializeValues_Both()
        {
            values_both = new object[]
            {
                TXB_macd.Text,
                TXB_macanho.Text,
                CBB_loaicd.SelectedItem,
                TXB_hovaten.Text,
                DTP_ngaysinh.Value,
                TXB_madinhdanh.Text,
                TXB_sdt.Text,
                TXB_email.Text,
                TXB_quoctich.Text,
                TXB_sothetamtru.Text,
                DTP_vao.Value,
                DTP_di.Value,
                CBB_nguoithan.SelectedItem,
                TXB_bienso.Text == "" ? "" : TXB_bienso.Text,
                (int)NUD_congno.Value,
                TXB_thunuoi.Text
            };
        }
        private Dictionary<string, object> AddParameter_Both()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCuDan", values_both[0] },
                { "@maCanHo", values_both[1] },
                { "@loaiCuDan", values_both[2] },
                { "@hoTen", values_both[3] },
                { "@ngayThangNamSinh", values_both[4] },
                { "@maDinhDanh", values_both[5] },
                { "@SDT", values_both[6] },
                { "@email", values_both[7] },
                { "@quocTich", values_both[8] },
                { "@soTheTamTru", values_both[9] },
                { "@ngayChuyenVao", values_both[10] },
                { "@ngayChuyenDi", values_both[11] },
                { "@maCuDanLuuTruCung", values_both[12] },
                { "@bienSoXeDangKy", values_both[13] },
                { "@tinhTrangCongNo", values_both[14] },
                { "@duLieuDangKyThuNuoi", values_both[15] }
            };
            return dict;
        }

        private Dictionary<string, object> AddParameter_CuDan_Both()
        {
            double temp = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCuDan", values_both[0] },
                { "@hoTen", values_both[3] },
                { "@ngaySinh", values_both[4] },
                { "@maDinhDanh", values_both[5] },
                { "@SDT", values_both[6] },
                { "@email", values_both[7] },
                { "@soTheTamTru", values_both[9] },
                { "@ngayChuyenVao", values_both[10] },
                { "@ngayChuyenDi", values_both[11] },
                { "@soDienNuocHangThang", temp},
                { "@tinhTrangCongNo", values_both[14] },
                { "@duLieuDangKyThuNuoi", values_both[15] },
                { "@quocTich", values_both[8] },
                { "@maCuDanNguoiThan", values_both[12] },      
            };
            return dict;
        }

        private void ThemUyQuyen()
        {
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_Both();
                ResidentBLL.Instance.AddCuDan(AddParameter_CuDan_Both());
                MessageBox.Show(NguoiDcUyQuyenChuHoBLL.Instance.AddNguoiUyQuyen(AddParameter_Both()));
                
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_uyquyen();
            }
        }
        private void ThemKhachNganNgay()
        {
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_Both();
                ResidentBLL.Instance.AddCuDan(AddParameter_CuDan_Both());
                MessageBox.Show(KhachNganNgayBLL.Instance.AddKhachNganNgay(AddParameter_Both()));
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_khachnganngay();
            }
        }
        private void SuaChuHo()
        {
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_diennuoc.Text == "")
            {
                LB_ediennuoc.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_CH();
                MessageBox.Show(ChuHoBLL.Instance.UpdateChuHo(AddParameter_CH()));
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_chuho();
            }
        }
        private void SuaUyQuyen()
        {
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_Both();
                MessageBox.Show(NguoiDcUyQuyenChuHoBLL.Instance.UpdateNguoiUyQuyen(AddParameter_Both()));
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_uyquyen();
            }
        }
        private void SuaKhachNganNgay()
        {
            int error = 0;
            if (TXB_macanho.Text == "")
            {
                LB_emacanho.Visible = true;
                error++;
            }
            if (CBB_loaicd.SelectedIndex == -1)
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_macd.Text == "")
            {
                LB_eloaicd.Visible = true;
                error++;
            }
            if (TXB_hovaten.Text == "")
            {
                LB_ehoten.Visible = true;
                error++;
            }
            if (TXB_quoctich.Text == "")
            {
                LB_equoctich.Visible = true;
                error++;
            }
            if (TXB_madinhdanh.Text == "")
            {
                LB_ecccd.Visible = true;
                error++;
            }
            if (TXB_sdt.Text == "")
            {
                LB_sdt.Visible = true;
                error++;
            }
            if (TXB_email.Text == "")
            {
                LB_eemail.Visible = true;
                error++;
            }
            if (TXB_sothetamtru.Text == "")
            {
                LB_etamtru.Visible = true;
                error++;
            }
            if (TXB_bienso.Text != "")
            {
                if (string.IsNullOrEmpty(TXB_loaixe.Text))
                {
                    LB_eloaixe.Visible = true;
                    error++;
                }
                if (string.IsNullOrEmpty(TXB_tinhtrangxe.Text))
                {
                    LB_etinhtrangxe.Visible = true;
                    error++;
                }
            }
            if (error > 0)
            {
                return;
            }
            else
            {
                InitializeValues_Both();
                MessageBox.Show(KhachNganNgayBLL.Instance.UpdateKhachNganNgay(AddParameter_Both()));
                if (!string.IsNullOrEmpty(TXB_bienso.Text))
                {
                    InitializeValues_PT();
                    VehicleBLL.Instance.AddVehicle(AddParameter_PT());
                }
                parent.DisplayGGC_khachnganngay();
            }
        }
        private void BTN_luu_Click(object sender, EventArgs e)
        {
            if (ResidentBLL.Instance.CheckMaCuDan(TXB_macd.Text))
            {
                MessageBox.Show("Mã cư dân đã tồn tại");
                return;
            }
            if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay == null)
            {
                switch(type)
                {
                    case 0:
                        ThemChuHo();
                        break;
                    case 1:
                        ThemUyQuyen();
                        break;
                    case 2:
                        ThemKhachNganNgay();
                        break;

                }
            }
            else
            {
                if (chuHo != null && nguoiDcUyQuyen == null && khachNganNgay == null)
                {
                    SuaChuHo();
                }
                else if (chuHo == null && nguoiDcUyQuyen != null && khachNganNgay == null)
                {
                    SuaUyQuyen();
                }
                else if (chuHo == null && nguoiDcUyQuyen == null && khachNganNgay != null)
                {
                    SuaKhachNganNgay();
                }
            }
        }

        private void TXB_macanho_TextChanged(object sender, EventArgs e)
        {
            LB_emacanho.Visible = false;
        }

        private void CBB_loaicd_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_eloaicd.Visible = false;
        }

        private void TXB_macd_TextChanged(object sender, EventArgs e)
        {
            LB_emacd.Visible = false;
        }

        private void TXB_hovaten_TextChanged(object sender, EventArgs e)
        {
            LB_ehoten.Visible = false;
        }

        private void TXB_quoctich_TextChanged(object sender, EventArgs e)
        {
            LB_equoctich.Visible = false;
        }

        private void TXB_madinhdanh_TextChanged(object sender, EventArgs e)
        {
            LB_ecccd.Visible = false;
        }

        private void TXB_sdt_TextChanged(object sender, EventArgs e)
        {
            LB_esdt.Visible = false;
        }

        private void TXB_email_TextChanged(object sender, EventArgs e)
        {
            LB_eemail.Visible = false;
        }

        private void TXB_sothetamtru_TextChanged(object sender, EventArgs e)
        {
            LB_etamtru.Visible = false;
        }

        private void TXB_diennuoc_TextChanged(object sender, EventArgs e)
        {
            LB_ediennuoc.Visible = false;
        }

        private void TXB_loaixe_TextChanged(object sender, EventArgs e)
        {
            LB_eloaixe.Visible = false;
        }

        private void TXB_tinhtrangxe_TextChanged(object sender, EventArgs e)
        {
            LB_etinhtrangxe.Visible = false;
        }

        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void TTCD_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void TTCD_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void TTCD_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
