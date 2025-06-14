using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class ThongBao : Form
    {
        private Account currentAccount;
        private Employee currentUser;
        public ThongBao(Account currentAccount)
        {
            InitializeComponent();
            this.currentAccount = currentAccount;
            this.currentUser = EmployeeBLL.Instance.GetEmployeeByEmployeeId(this.currentAccount.EmployeeId);
            BTN_quantrong.PerformClick();
        }

        private void BTN_biensoan_Click(object sender, EventArgs e)
        {
            SoanThongBao stb = new SoanThongBao(currentAccount);
            stb.ShowDialog();
        }
        private Dictionary<string, object> AddParameter(string maBoPhan, string maNhom, string maNhanVien)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            { 
                {"@maBoPhan", maBoPhan },
                {"@maNhom", maNhom },
                {"@maNhanVien", maNhanVien }
            };
            return dict;

        }
        private void BTN_quantrong_Click(object sender, EventArgs e)
        {
            FLP_thongbao.Controls.Clear();
            List<Notice> notices = NoticeBLL.Instance.GetNoticesPriority(AddParameter(currentUser.MaBoPhan, currentUser.MaNhom, currentUser.MaNhanVien));

            foreach (Notice notice in notices)
            {
                // Tạo một panel mới cho mỗi thông báo
                Panel panelNotice = new Panel();
                panelNotice.BorderStyle = BorderStyle.FixedSingle;
                panelNotice.Size = new Size(900, 100); // Thiết lập kích thước của panel

                // Tạo các nhãn (label) để hiển thị tiêu đề và nội dung của thông báo
                Label titleLabel = new Label();
                titleLabel.Text = notice.Title;
                titleLabel.Location = new Point(10, 10);
                titleLabel.AutoSize = true;
                // Tạo một Font mới với kích thước lớn hơn và in đậm
                Font boldFont = new Font("Times New Roman", 14, FontStyle.Bold);

                // Thiết lập Font mới cho Label
                titleLabel.Font = boldFont;

                Label authorLabel = new Label();
                authorLabel.Text = $"{notice.Author} {notice.Date}";
                authorLabel.Location = new Point(10, 50);
                authorLabel.AutoSize = true;

                LinkLabel ctLabel = new LinkLabel();
                ctLabel.Text = "Chi tiết";
                ctLabel.Location = new Point(10, 70);
                ctLabel.LinkColor = Color.White;
                ctLabel.AutoSize = true;
                ctLabel.Tag = notice;
                ctLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(ctLabel_LinkClicked);
                if (notice.File!= null)
                {
                    LinkLabel fileLabel = new LinkLabel();
                    fileLabel.Text = notice.FileName;
                    fileLabel.AutoSize = true;
                    fileLabel.LinkColor = Color.White;
                    fileLabel.Tag = notice;

                    // Tính toán độ dài của chuỗi notice.FileName
                    using (Graphics graphics = CreateGraphics())
                    {
                        SizeF textSize = graphics.MeasureString(notice.FileName, fileLabel.Font);
                        int labelWidth = (int)textSize.Width; // Lấy chiều rộng của chuỗi
                        fileLabel.Location = new Point(900 - (labelWidth + 30), 50); // Đặt vị trí của LinkLabel
                    }
                    // Gắn sự kiện LinkClicked vào fileLabel
                    fileLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(fileLabel_LinkClicked);
                    panelNotice.Controls.Add(fileLabel);
                    
                }
                

                // Thêm các nhãn vào panel
                panelNotice.Controls.Add(titleLabel);
                panelNotice.Controls.Add(authorLabel);
                panelNotice.Controls.Add(ctLabel);

                // Thêm panel vào FlowLayoutPanel
                FLP_thongbao.Controls.Add(panelNotice);

            }

        }

        private void BTN_tatca_Click(object sender, EventArgs e)
        {
            FLP_thongbao.Controls.Clear();
            List<Notice> notices = NoticeBLL.Instance.GetAllNotices(AddParameter(currentUser.MaBoPhan, currentUser.MaNhom, currentUser.MaNhanVien));

            foreach (Notice notice in notices)
            {
                // Tạo một panel mới cho mỗi thông báo
                Panel panelNotice = new Panel();
                panelNotice.BorderStyle = BorderStyle.FixedSingle;
                panelNotice.Size = new Size(900, 100); // Thiết lập kích thước của panel

                // Tạo các nhãn (label) để hiển thị tiêu đề và nội dung của thông báo
                Label titleLabel = new Label();
                titleLabel.Text = notice.Title;
                titleLabel.Location = new Point(10, 10);
                titleLabel.AutoSize = true;
                // Tạo một Font mới với kích thước lớn hơn và in đậm
                Font boldFont = new Font("Times New Roman", 14, FontStyle.Bold);

                // Thiết lập Font mới cho Label
                titleLabel.Font = boldFont;

                Label authorLabel = new Label();
                authorLabel.Text = $"{notice.Author} {notice.Date}";
                authorLabel.Location = new Point(10, 50);
                authorLabel.AutoSize = true;

                LinkLabel ctLabel = new LinkLabel();
                ctLabel.Text = "Chi tiết";
                ctLabel.Location = new Point(10, 70);
                ctLabel.LinkColor = Color.White;
                ctLabel.AutoSize = true;
                ctLabel.Tag = notice;
                ctLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(ctLabel_LinkClicked);

                if (notice.File != null)
                {
                    LinkLabel fileLabel = new LinkLabel();
                    fileLabel.Text = notice.FileName;
                    fileLabel.AutoSize = true;
                    fileLabel.LinkColor = Color.White;
                    fileLabel.Tag = notice;

                    // Tính toán độ dài của chuỗi notice.FileName
                    using (Graphics graphics = CreateGraphics())
                    {
                        SizeF textSize = graphics.MeasureString(notice.FileName, fileLabel.Font);
                        int labelWidth = (int)textSize.Width; // Lấy chiều rộng của chuỗi
                        fileLabel.Location = new Point(900 - (labelWidth + 30), 50); // Đặt vị trí của LinkLabel
                    }
                    // Gắn sự kiện LinkClicked vào fileLabel
                    fileLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(fileLabel_LinkClicked);
                    panelNotice.Controls.Add(fileLabel);
                }


                // Thêm các nhãn vào panel
                panelNotice.Controls.Add(titleLabel);
                panelNotice.Controls.Add(authorLabel);
                panelNotice.Controls.Add(ctLabel);

                // Thêm panel vào FlowLayoutPanel
                FLP_thongbao.Controls.Add(panelNotice);
            }

        }

        private void BTN_dagui_Click(object sender, EventArgs e)
        {
            FLP_thongbao.Controls.Clear();
            List<Notice> notices = NoticeBLL.Instance.GetNoticesSend(AddParameter(null, null, currentUser.MaNhanVien));

            foreach (Notice notice in notices)
            {
                // Tạo một panel mới cho mỗi thông báo
                Panel panelNotice = new Panel();
                panelNotice.BorderStyle = BorderStyle.FixedSingle;
                panelNotice.Size = new Size(900, 100); // Thiết lập kích thước của panel

                // Tạo các nhãn (label) để hiển thị tiêu đề và nội dung của thông báo
                Label titleLabel = new Label();
                titleLabel.Text = notice.Title;
                titleLabel.Location = new Point(10, 10);
                titleLabel.AutoSize = true;
                // Tạo một Font mới với kích thước lớn hơn và in đậm
                Font boldFont = new Font("Times New Roman", 14, FontStyle.Bold);

                // Thiết lập Font mới cho Label
                titleLabel.Font = boldFont;

                Label authorLabel = new Label();
                authorLabel.Text = $"{notice.Author} {notice.Date}";
                authorLabel.Location = new Point(10, 50);
                authorLabel.AutoSize = true;

                LinkLabel ctLabel = new LinkLabel();
                ctLabel.Text = "Chi tiết";
                ctLabel.Location = new Point(10, 70);
                ctLabel.LinkColor = Color.White;
                ctLabel.AutoSize = true;
                ctLabel.Tag = notice;
                ctLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(ctLabel_LinkClicked);

                if (notice.File != null)
                {
                    LinkLabel fileLabel = new LinkLabel();
                    fileLabel.Text = notice.FileName;
                    fileLabel.AutoSize = true;
                    fileLabel.LinkColor = Color.White;
                    fileLabel.Tag = notice;

                    // Tính toán độ dài của chuỗi notice.FileName
                    using (Graphics graphics = CreateGraphics())
                    {
                        SizeF textSize = graphics.MeasureString(notice.FileName, fileLabel.Font);
                        int labelWidth = (int)textSize.Width; // Lấy chiều rộng của chuỗi
                        fileLabel.Location = new Point(900 - (labelWidth + 30), 50); // Đặt vị trí của LinkLabel
                    }
                    // Gắn sự kiện LinkClicked vào fileLabel
                    fileLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(fileLabel_LinkClicked);

                    panelNotice.Controls.Add(fileLabel);
                }


                // Thêm các nhãn vào panel
                panelNotice.Controls.Add(titleLabel);
                panelNotice.Controls.Add(authorLabel);
                panelNotice.Controls.Add(ctLabel);

                // Thêm panel vào FlowLayoutPanel
                FLP_thongbao.Controls.Add(panelNotice);
            }
        }
        private void fileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Xử lý sự kiện khi LinkLabel được nhấp
            LinkLabel fileLabel = sender as LinkLabel;
            // Lấy thông tin của notice từ thuộc tính Tag của fileLabel
            Notice notice = fileLabel.Tag as Notice;
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = $"File (*{notice.FileExten})|*{notice.FileExten}",
                FileName = fileLabel.Text,
            };
            bool ErrorMessage = false;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    try
                    {
                        File.Delete(save.FileName);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = true;
                        MessageBox.Show("Unable to write data in disk" + ex.Message);
                    }
                }
                if (!ErrorMessage)
                {
                    try
                    {
                        byte[] bytes = notice.File;
                        File.WriteAllBytes(save.FileName, bytes);
                        MessageBox.Show("Successful", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while downloading" + ex.Message);
                    }
                }
            }

        }
        private void ctLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ctLabel = sender as LinkLabel;
            // Lấy thông tin của notice từ thuộc tính Tag của fileLabel
            Notice notice = ctLabel.Tag as Notice;
            ChiTietThongBao cttb = new ChiTietThongBao(notice);
            cttb.Show();
        }
    }
}
