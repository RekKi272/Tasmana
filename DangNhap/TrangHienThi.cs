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
using System.Threading;
using System.Globalization;

namespace DangNhap
{
    public partial class TrangHienThi : Form
    {
        // Khởi tạo các giá trị, biến
        private int appTime;
        private bool isClosed = true;
        private readonly Account currentAccount;
        public TrangHienThi(Account currentAccount)
        {
            InitializeComponent();
            Timer_KTCongViec.Start();
            appTime = 0;
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
            PN_main.Controls.Add(childForm);
            PN_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BTN_congviec_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CongViecChung(currentAccount));
            BTN_congviec.BackColor = Color.FromArgb(51,53,55);
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
        }

        private void BTN_thongbao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongBao(currentAccount));
            BTN_thongbao.BackColor = Color.FromArgb(51, 53, 55);
            BTN_congviec.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
        }

        private void BTN_thongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
            BTN_thongke.BackColor = Color.FromArgb(51, 53, 55);
            BTN_congviec.BackColor = Color.Transparent;
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
        }

        private void BTN_nhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            BTN_nhanvien.BackColor = Color.FromArgb(51, 53, 55);
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
            BTN_congviec.BackColor = Color.Transparent;
        }

        private void BTN_cudan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CuDan(currentAccount));
            BTN_cudan.BackColor = Color.FromArgb(51, 53, 55);
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
            BTN_congviec.BackColor = Color.Transparent;
        }

        private void BTN_canho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CanHo(currentAccount));
            BTN_canho.BackColor = Color.FromArgb(51, 53, 55);
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_congviec.BackColor = Color.Transparent;
        }

        private void BTN_logout_Click(object sender, EventArgs e)
        {
            isClosed = false;
            this.Close();
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
        }

        private void BTN_thongtin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongTinNhanVien(currentAccount.EmployeeId));
            BTN_thongbao.BackColor = Color.Transparent;
            BTN_thongke.BackColor = Color.Transparent;
            BTN_nhanvien.BackColor = Color.Transparent;
            BTN_cudan.BackColor = Color.Transparent;
            BTN_congviec.BackColor = Color.Transparent;
            BTN_canho.BackColor = Color.Transparent;
        }

        //MoveForm
        private int mov;
        private int movX;
        private int movY;
        private void TrangHienThi_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void TrangHienThi_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void TrangHienThi_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_x_Click(object sender, EventArgs e)
        {
            if (isClosed)
                Application.Exit();
        }

        private void BTN_square_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;   
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // Thông báo khi sắp tới thời hạn hoàn thành công việc
        public DateTime tomorrowDay = DateTime.Today.AddDays(1); // Lấy thời gian là 1 ngày sau đó là mốc kiểm tra gaanf tới hạn hoàn thành
        public DateTime curDay = DateTime.Today;
        int soCongViec = 0;
        int undoJob = 0;
        int AllUndoJob = 0;
        private void Timer_KTCongViec_Tick(object sender, EventArgs e)
        {
            appTime++;
            if (appTime < Constraint.NotifyTime)
                return;
            else if (appTime == Constraint.NotifyTime)
            {
                // Kiểm tra những công việc gần đến hạn nhưng chưa hoàn thành
                int curUnfJob = 0;
                string maNV = currentAccount.EmployeeId;
                List<Job> tomorowJobs;
                tomorowJobs = JobBLL.Instance.GetJobOfEmployeeByDate(maNV, tomorrowDay.Date.ToString("yyyy-MM-dd"));
                foreach (Job job in tomorowJobs)
                {
                    if (!job.TrangThai.Equals("Hoàn thành"))
                    {
                        curUnfJob++;
                    }
                }
                if (curUnfJob > 0 && soCongViec != curUnfJob)
                {
                    soCongViec = tomorowJobs.Count;
                    ShowNotification("Thông báo công việc chưa hoàn thành", string.Format("Bạn có {0} công việc sắp đến hạn vào ngày mai", soCongViec));
                }

                // Kiểm tra những công việc của NHÂN VIÊN chưa bắt đầu làm
                // Chỉ thông báo cho nhân viên như yêu cầu 10
                if (currentAccount.Level.Equals("CEO"))
                {
                    List<Job> allJobs;
                    allJobs = JobBLL.Instance.GetAllJob();
                    int curAllJobs = 0; // số công việc chưa cập nhật tình trạng
                    foreach (Job job in allJobs)
                    {
                        if (!job.TrangThai.Equals("Hoàn thành"))
                        {
                            curAllJobs++;
                        }
                    }
                    if (curAllJobs > 0 && curAllJobs != AllUndoJob)
                    {
                        AllUndoJob = curAllJobs;
                        ShowNotification("Thông báo công việc chưa cập nhật của toàn bộ Nhân viên", string.Format("Có {0} công việc chưa được cập nhật tình trạng", curAllJobs));
                    }
                }
                else
                {
                    List<Job> allJobs;
                    allJobs = JobBLL.Instance.GetAllJobOfEmployee(maNV);
                    int curUndoJob = 0;
                    foreach (Job job in allJobs)
                    {
                        if (job.TrangThai.Equals("Chưa bắt đầu"))
                        {
                            curUndoJob++;
                        }
                    }
                    if (curUndoJob > 0 && curUndoJob != undoJob)
                    {
                        undoJob = curUndoJob;
                        ShowNotification("Thông báo công việc chưa bắt đầu", string.Format("Bạn có {0} công việc chưa bắt đầu", curUndoJob));
                    }
                }
            }
            // reset timer
            Timer_KTCongViec.Stop();
        }

        private void ShowNotification(string title, string content)
        {
            NTFIcon_ThongBaoCV.Visible = true;
            NTFIcon_ThongBaoCV.ShowBalloonTip(Constraint.NotifyTimeOut, title, content, ToolTipIcon.Info);
            NTFIcon_ThongBaoCV.Dispose();
        }

        private void CountJobState()
        {
            // Hiện thông tin
            LB_SoCongViecCBD.Visible = true;
            LB_SoCV_DangTienHanh.Visible = true;
            LB_SoCV_TreHan.Visible = true;
            LB_SoCV_CoCapNhat.Visible = true;

            // Nếu là CEO thì load toàn bộ tình trạng công việc của toàn công ty
            if (currentAccount.Level.Equals("CEO"))
            {
                // Lấy thông tin
                DataTable data = JobBLL.Instance.GetAllJobsState();
                if(data.Rows.Count > 0)
                {
                    LB_SoCongViecCBD.Text = data.Rows[0]["TongSoCVChuaBatDau"].ToString();
                    LB_SoCV_DangTienHanh.Text = data.Rows[0]["TongSoCVDangLam"].ToString();
                    LB_SoCV_TreHan.Text = data.Rows[0]["TongSoCVTreHan"].ToString();
                    LB_SoCV_CoCapNhat.Text = data.Rows[0]["TongCVCoCapNhat"].ToString();
                }
                else
                {
                    LB_SoCongViecCBD.Text = "0";
                    LB_SoCV_DangTienHanh.Text = "0";
                    LB_SoCV_TreHan.Text = "0";
                    LB_SoCV_CoCapNhat.Text = "0";
                }
            }
            else
            {
                // Lấy thông tin
                DataTable data = JobBLL.Instance.GetJobsStateOfEmployee(currentAccount.EmployeeId);
                if (data.Rows.Count > 0)
                {
                    LB_SoCongViecCBD.Text = data.Rows[0]["TongSoCVChuaBatDau"].ToString();
                    LB_SoCV_DangTienHanh.Text = data.Rows[0]["TongSoCVDangLam"].ToString();
                    LB_SoCV_TreHan.Text = data.Rows[0]["TongSoCVTreHan"].ToString();
                    LB_SoCV_CoCapNhat.Text = data.Rows[0]["TongCVCoCapNhat"].ToString();
                }
                else
                {
                    LB_SoCongViecCBD.Text = "0";
                    LB_SoCV_DangTienHanh.Text = "0";
                    LB_SoCV_TreHan.Text = "0";
                    LB_SoCV_CoCapNhat.Text = "0";
                }
            }
        }
        // Phân quyền chức năng
        private void PhanQuyen()
        {
            LB_tendangnhap.Text = $"Hello, {currentAccount.EmployeeId} - {currentAccount.Level}";
            // kiểm tra có phải là quản lý hay không
            DataTable listQuanLy = EmployeeBLL.Instance.GetManager();
            bool isManager = false;

            foreach (DataRow row in listQuanLy.Rows)
            {
                if (row["maNhanVien"].ToString().Equals(currentAccount.EmployeeId))
                {
                    isManager = true;
                    break;
                }
            }

            if (isManager)
            {
                // Là quản lý
                return;
            }

            // Vệ sinh 
            if (currentAccount.Level.Equals("VS"))
            {
                // Thống kê 
                BTN_thongke.Enabled = false;
                BTN_thongke.Visible = false;

                // Cư dân
                BTN_cudan.Enabled = false;
                BTN_cudan.Visible = false;

                // Nhân viên
                BTN_nhanvien.Enabled = false;
                BTN_nhanvien.Visible = false;

                // Đổi lại vị trí các Button
                BTN_canho.Location = new Point(0, 145);
            }
            
            // Tài chính
            if (currentAccount.Level.Equals("TC"))
            {
                // Nhân viên
                BTN_nhanvien.Enabled = false;
                BTN_nhanvien.Visible = false;

                // Đổi lại vị trí các Button
                BTN_canho.Location = new Point(0, 180);
            }
            
            // Hành chính Nhân sự & Dịch vụ Cư dân
            if (currentAccount.Level.Equals("DV"))
            {
                // Thống kê 
                BTN_thongke.Enabled = false;
                BTN_thongke.Visible = false;

                // Đổi lại vị trí các Button
                BTN_canho.Location = new Point(0, 145);
            }
            // An ninh || Kỹ thuật || Xây dựng
            if (currentAccount.Level.Equals("AN") || currentAccount.Level.Equals("KT") || currentAccount.Level.Equals("XD"))
            {
                // Thống kê 
                BTN_thongke.Enabled = false;
                BTN_thongke.Visible = false;

                // Nhân viên
                BTN_nhanvien.Enabled = false;
                BTN_nhanvien.Visible = false;

                // Đổi lại vị trí các Button
                BTN_cudan.Location = new Point(0, 145);
                BTN_canho.Location = new Point(0, 180);
            }
            // Hiển thị tình trạng công việc hiện tại
            CountJobState();
        }

        private void TrangHienThi_Load(object sender, EventArgs e)
        {
            // Set Default Language
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
            Controls.Clear();
            UpdateWindowsState();
            InitializeComponent();
            //Phân Quyền
            PhanQuyen();
        }

        private void UpdateWindowsState()
        { 
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void PB_language_Click(object sender, EventArgs e)
        {
            if(BTN_congviec.Text == "Công Việc")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
            }
            Controls.Clear();
            UpdateWindowsState();
            InitializeComponent();
            // Phân quyền chức năng khi load lại 
            PhanQuyen();
            // Load lại tình trạng công việc
            CountJobState();
        }

        private void PB_question_Click(object sender, EventArgs e)
        {
            CauHoiThuongGap chtg = new CauHoiThuongGap();
            chtg.ShowDialog();
        }
    }
}
