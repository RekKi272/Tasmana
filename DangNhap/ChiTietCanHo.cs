using BLL;
using DAO;
using DTO;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;
using System.IO;
using System.Globalization;

namespace DangNhap
{
    public partial class ChiTietCanHo : Form
    {
        private readonly CanHo parent;
        private readonly string maCanHoHienTai;
        private Apartment canHoHienTai;
        private ChuHo chuHo;
        private readonly Account currentAccount;
        //private readonly string[] arrLoai = { "PENTHOUSE", "01", "02", "03", "04", "04", "05", "06", "07", "08", "09", "10", "11" };
        private readonly string[] arrTinhTrang = { "Chưa bán", "Đã bán", "Chưa bàn giao - Cư dân đang ở", "Đã bàn giao - trống" };
        public ChiTietCanHo()
        {
            InitializeComponent();;
            PhanQuyen();
        }

        public ChiTietCanHo(Account currentAccount)
        {
            InitializeComponent();
            this.currentAccount = currentAccount;
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            if(!currentAccount.Level.Equals("CEO") && !currentAccount.Level.Equals("DV"))
            {
                BTN_luu.Enabled = false;
                BTN_luu.Visible = false;
                
                BTN_xoa.Enabled = false;
                BTN_xoa.Visible = false;
            }
        }
        public ChiTietCanHo(CanHo parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public ChiTietCanHo(CanHo parent, string maCanHo, Account currentAccount)
        {
            InitializeComponent();
            this.parent = parent;
            this.maCanHoHienTai = maCanHo;
            this.currentAccount = currentAccount;
            this.FormClosing += new FormClosingEventHandler(this.ChiTietCanHo_FormClosing);
            GetApartmentById(maCanHoHienTai);
            PhanQuyen();
        }
        private void GetApartmentById(string maCanHo)
        {
            canHoHienTai = ApartmentBLL.Instance.GetApartmentById(maCanHo);
        }
        private void GetResidentByApartmentId(string maCanHo)
        {
            chuHo = ChuHoBLL.Instance.GetChuHoByApartmentId(maCanHo);
        }

        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            currentFormChild?.Close();
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PN_hienthi.Controls.Add(childForm);
            PN_hienthi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BTN_lichsu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichSuCanHo(canHoHienTai));
            BTN_lichsu.BackColor = Color.FromArgb(51, 53, 55);
            BTN_chung.BackColor = Color.Transparent;
        }

        private void BTN_chung_Click(object sender, EventArgs e)
        {
            currentFormChild?.Close();
            BTN_chung.BackColor = Color.FromArgb(51, 53, 55);
            BTN_lichsu.BackColor = Color.Transparent;
        }

        private object[] values_ch;
        private void InitializeValues_CH()
        {
            string chuhoParts = TXB_chuho.Text.Split('_')[0];
            string chuhoValue = !string.IsNullOrEmpty(TXB_chuho.Text) ? chuhoParts : null;

            values_ch = new object[]
            {
                TXB_macanho.Text,
                Convert.ToDouble(TXB_GSA.Text),
                Convert.ToDouble(TXB_NSA.Text),
                (int)NUD_vitritang.Value,
                (int)NUD_phongngu.Value,
                (int)NUD_toilet.Value,
                ConvertImageToBytes(PB_hinhcanho.Image),
                (int)NUD_mucphiql.Value,
                (int)NUD_thangmay.Value,
                CBB_tinhtrang.SelectedItem.ToString(),
                (int)NUD_thanhtoan.Value,
                chuhoValue
            };
        }
        private Dictionary<string, object> AddParemeter_CH()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCanHo", values_ch[0] },
                { "@dienTichGSA", values_ch[1] },
                { "@dienTichNSA", values_ch[2] },
                { "@viTriTang", values_ch[3] },
                { "@soLuongPhongNgu", values_ch[4] },
                { "@soLuongToilet", values_ch[5] },
                { "@soDoMatBang", values_ch[6] },
                { "@mucPhiQLHangThang", values_ch[7] },
                { "@soLuongTheThangMay", values_ch[8] },
                { "@tinhTrangGDHienTai", values_ch[9] },
                { "@tinhTrangThanhToan", values_ch[10] },
                { "@maCuDan", values_ch[11] },
            };
            return dict;
        }
        // Do not delete
        private void ChiTietCanHo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private int GetNoOfRoomsUsingApartmentId(string maCanHo)
        {
            // Lấy 2 ký tự cuối của mã căn hộ
            string last2Characters = maCanHo.Substring(Math.Max(0, maCanHo.Length - 2));
            switch (last2Characters)
            {
                case "01":
                case "02":
                case "07":
                case "08":
                case "11":
                    return 3;
                case "04":
                case "05":
                    return 2;
                case "03":
                case "09":
                case "10":
                    return 1;
                default:
                    return 5;
            }
        }
        private string GetApartmentType(string maCanHo)
        {
            string last2Characters = maCanHo.Substring(Math.Max(0, maCanHo.Length - 2));
            if (last2Characters == "HA" || last2Characters == "HB" ||
                last2Characters == "HC" || last2Characters == "HD")
            {
                return "PENTHOUSE";
            }
            return last2Characters;
        }
        // Chuyển file ảnh thành bytes để lưu vào csdl
        private byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        
        private void DisplayApartmenInfo()
        {
            GetApartmentById(maCanHoHienTai);
            GetResidentByApartmentId(maCanHoHienTai);
            if (canHoHienTai != null)
            {
                TXB_macanho.Text = maCanHoHienTai;
                if (chuHo != null)
                {
                    TXB_chuho.Text = chuHo.MaCuDan + "_" + chuHo.HoTen;
                }
                string tenKhachDangThue = "";
                if (canHoHienTai.LichSuGiaoDich != null)
                    tenKhachDangThue = KhachNganNgayBLL.Instance.GetNameByMaCuDan(canHoHienTai.LichSuGiaoDich.MaKhachDangThue);
                
                if (!string.IsNullOrEmpty(tenKhachDangThue))
                    TXB_khachdangthue.Text = canHoHienTai.LichSuGiaoDich.MaKhachDangThue + "_" + tenKhachDangThue;
                NUD_vitritang.Value = canHoHienTai.ViTriTang;
                NUD_toilet.Value = canHoHienTai.SoLuongToilet;
                NUD_phongngu.Value = GetNoOfRoomsUsingApartmentId(maCanHoHienTai);
                NUD_thangmay.Value = canHoHienTai.SoLuongTheThangMay;
                NUD_mucphiql.Value = canHoHienTai.MucPhiQuanLyHangThang;
                TXB_loaicanho.Text = GetApartmentType(maCanHoHienTai);
                CBB_tinhtrang.SelectedIndex = Array.IndexOf(arrTinhTrang, canHoHienTai.TinhTrangGiaoDichHienTai);
                NUD_thanhtoan.Value = canHoHienTai.TinhTrangThanhToan;
                TXB_GSA.Text = canHoHienTai.DienTichGSA.ToString();
                TXB_NSA.Text = canHoHienTai.DienTichNSA.ToString();
                if (canHoHienTai.SoDoMatBang != null)
                    PB_hinhcanho.Image = canHoHienTai.SoDoMatBang;
                else
                    PB_hinhcanho.Image = Tasmana.Properties.Resources.DefaulCanHoImage;
            }
        }

        private void ChiTietCanHo_Load(object sender, EventArgs e)
        {
            CBB_tinhtrang.DataSource = arrTinhTrang;
            CBB_tinhtrang.SelectedIndex = -1;
            if (canHoHienTai != null)
            {
                DisplayApartmenInfo();
            }
        }
        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //MoveForm
        int mov;
        int movX;
        int movY;

        private void ChiTietCanHo_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ChiTietCanHo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ChiTietCanHo_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_uploadanh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*" , Multiselect = false}) 
            { 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PB_hinhcanho.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void BTN_luu_Click(object sender, EventArgs e)
        {
            InitializeValues_CH();
            MessageBox.Show(ApartmentBLL.Instance.UpdateApartment(AddParemeter_CH()));
            parent.DisplayGGC_canho();
        }

        private void BTN_xoa_Click(object sender, EventArgs e)
        {
            //Tiếng Việt
            if(BTN_xoa.Text == "Xóa")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa căn hộ này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteMessage = ApartmentBLL.Instance.DeleteApartment(maCanHoHienTai);
                    MessageBox.Show(deleteMessage);
                    Close();
                }
            }
            //Tiếng Anh
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this apartment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteMessage = ApartmentBLL.Instance.DeleteApartment(maCanHoHienTai);
                    MessageBox.Show(deleteMessage);
                    Close();
                }
            }

        }
    }
}
