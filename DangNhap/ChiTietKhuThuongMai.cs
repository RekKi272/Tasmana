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
using BLL;
using System.IO;

namespace DangNhap
{
    public partial class ChiTietKhuThuongMai : Form
    {
        private readonly CanHo parent;
        private readonly string maKhuThuongMaiHienTai;
        private KhuThuongMai khuThuongMai;
        private KhachThueKhuThuongMai khachThue;
        private readonly Account currentAccount;
        public ChiTietKhuThuongMai()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        public ChiTietKhuThuongMai(CanHo parent, string maCanHo, Account currentAccount)
        {
            InitializeComponent();
            this.parent = parent;
            this.maKhuThuongMaiHienTai = maCanHo;
            this.FormClosing += new FormClosingEventHandler(this.ChiTietKhuThuongMai_FormClosing);
            GetKhuThuongMaiById(maKhuThuongMaiHienTai);
            this.currentAccount = currentAccount;
            PhanQuyen();
        }
        private void PhanQuyen()
        {
            if (!currentAccount.Level.Equals("CEO") && !currentAccount.Level.Equals("DV"))
            {
                BTN_luu.Enabled = false;
                BTN_luu.Visible = false;

                BTN_xoa.Enabled = false;
                BTN_xoa.Visible = false;
            }
        }
        private byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private object[] values_ktm;
        private void InitializeValues_KTM()
        {
            values_ktm = new object[]
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
                (int)NUD_thanhtoan.Value,
                TXB_khachdangthue.Text.Split('_')[0]
            };
        }
        private Dictionary<string, object> AddParemeter_KTM()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                { "@maCanHo", values_ktm[0] },
                { "@dienTichGSA", values_ktm[1] },
                { "@dienTichNSA", values_ktm[2] },
                { "@viTriTang", values_ktm[3] },
                { "@soLuongPhongNgu", values_ktm[4] },
                { "@soLuongToilet", values_ktm[5] },
                { "@soDoMatBang", values_ktm[6] },
                { "@mucPhiQLHangThang", values_ktm[7] },
                { "@soLuongTheThangMay", values_ktm[8] },
                { "@tinhTrangThanhToan", values_ktm[9] },
                { "@maKhachDangThue", values_ktm[10] },
            };
            return dict;
        }
        private void GetKhuThuongMaiById(string maKhuThuongMai)
        {
            khuThuongMai = KhuThuongMaiBLL.Instance.GetKhuThuongMaiById(maKhuThuongMai);
        }
        private void GetKhachThueById(string maKhachDangThue)
        {
            khachThue = KhachThueKhuThuongMaiBLL.Instance.GetKhachThueById(maKhachDangThue);
        }
        private void DisplayKTMInfo()
        {
            GetKhuThuongMaiById(maKhuThuongMaiHienTai);
            GetKhachThueById(khuThuongMai.MaKhachDangThue);
            TXB_macanho.Text = maKhuThuongMaiHienTai;
            NUD_vitritang.Value = khuThuongMai.ViTriTang;
            NUD_vitritang.Value = khuThuongMai.ViTriTang;
            NUD_toilet.Value = khuThuongMai.SoLuongToilet;
            NUD_phongngu.Value = khuThuongMai.SoLuongPhongNgu;
            NUD_thangmay.Value = khuThuongMai.SoLuongTheThangMay;
            NUD_mucphiql.Value = khuThuongMai.MucPhiQuanLyHangThang;
            NUD_thanhtoan.Value = khuThuongMai.TinhTrangThanhToan;
            TXB_GSA.Text = khuThuongMai.DienTichGSA.ToString();
            TXB_NSA.Text = khuThuongMai.DienTichNSA.ToString();
            TXB_khachdangthue.Text = khuThuongMai.MaKhachDangThue + "_" + khachThue.HoTenNguoiDaiDien;
            if (khuThuongMai.SoDoMatBang != null)
                PB_hinhcanho.Image = khuThuongMai.SoDoMatBang;
            else
                PB_hinhcanho.Image = Tasmana.Properties.Resources.DefaulCanHoImage;
        }

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

        //MoveForm
        int mov;
        int movX;
        int movY;
        private void KhuThuongMai_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void KhuThuongMai_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void KhuThuongMai_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_chung_Click(object sender, EventArgs e)
        {
            currentFormChild?.Close();
            BTN_chung.BackColor = Color.FromArgb(51, 53, 55);
            BTN_lichsu.BackColor = Color.Transparent;
        }

        private void BTN_lichsu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichSuKhuThuongMai(khuThuongMai));
            BTN_lichsu.BackColor = Color.FromArgb(51, 53, 55);
            BTN_chung.BackColor = Color.Transparent;
        }

        private void ChiTietKhuThuongMai_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChiTietKhuThuongMai_Load(object sender, EventArgs e)
        {
            DisplayKTMInfo();
        }

        private void BTN_luu_Click(object sender, EventArgs e)
        {
            InitializeValues_KTM();
            MessageBox.Show(KhuThuongMaiBLL.Instance.UpdateKhuThuongMai(AddParemeter_KTM()));
            parent.DisplayGGC_khuthuongmai();
            Close();
        }

        private void BTN_uploadanh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PB_hinhcanho.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void BTN_xoa_Click(object sender, EventArgs e)
        {
            //Tiếng Viêtk
            if (BTN_xoa.Text == "Xóa")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khu thương mại này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteMessage = KhuThuongMaiBLL.Instance.DeleteKhuThuongMai(maKhuThuongMaiHienTai);
                    MessageBox.Show(deleteMessage);
                    parent.DisplayGGC_khuthuongmai();
                    Close();
                }
            }
            //Tiếng Anh
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this mall?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteMessage = KhuThuongMaiBLL.Instance.DeleteKhuThuongMai(maKhuThuongMaiHienTai);
                    MessageBox.Show(deleteMessage);
                    parent.DisplayGGC_khuthuongmai();
                    Close();
                }
            }
        }
    }
}
