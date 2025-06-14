using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class SoanThongBao : Form
    {
        private readonly Account currentAccount;
        private readonly Employee currentUser;
        private byte[] buffer = null;
        private string fileName = null;
        private string fileExten = null;
        public SoanThongBao(Account currentAccount)
        {
            InitializeComponent();
            this.currentAccount = currentAccount;
            this.currentUser = EmployeeBLL.Instance.GetEmployeeByEmployeeId(this.currentAccount.EmployeeId);
            DataView view = new DataView(GetDataTable());
            this.MSCBB_thongbao.DataSource = view;
            this.MSCBB_thongbao.DisplayMember = "Tên";
            this.MSCBB_thongbao.ValueMember = "ID";
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void SoanThongBao_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void SoanThongBao_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void SoanThongBao_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Tên");
            DataRow dr = dt.NewRow();
            dr[0] = "Ct";
            dr[1] = "Công ty";
            dt.Rows.Add(dr);
            List<Division> dv = DivisionBLL.Instance.GetDivisionList();
            foreach (Division d in dv)
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = d.MaBoPhan;
                dataRow[1] = d.TenBoPhan;
                dt.Rows.Add(dataRow);
            }
            List<Group> groups = GroupBLL.Instance.GetGroupsList();
            foreach (Group gr in groups)
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = gr.MaNhom;
                dataRow[1] = $"{gr.MaBoPhan}-N:{gr.MaNhom}";
                dt.Rows.Add(dataRow);
            }
            List<Employee> employees = EmployeeBLL.Instance.GetEmployeeList();
            foreach (Employee e in employees)
            {
                DataRow dataRow = dt.NewRow();
                dataRow[0] = e.MaNhanVien;
                if (e.MaNhanVien.Split('-')[0] == "GD")
                {
                    dataRow[1] = $"CEO: {e.MaNhanVien}";
                }
                else
                    dataRow[1] = $"{e.MaNhanVien}-NV:{e.Ho} {e.Ten}";
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        private Dictionary<string, object> AddParameterNotice()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@title", TXB_tieude.Text},
                {"@content", TXB_noidung.Text},
                {"@dateN", DateTime.Now },
                {"@author", currentUser.MaNhanVien },
                {"@fileN", buffer},
                {"@fileName", fileName },
                {"@fileExten", fileExten },
                {"@priority", CB_priority.Checked }
            };
            return dict;

        }
        private Dictionary<string, object> AddParameterNoticeWithout()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@title", TXB_tieude.Text},
                {"@content", TXB_noidung.Text},
                {"@dateN", DateTime.Now },
                {"@author", currentUser.MaNhanVien },
                {"@priority", CB_priority.Checked }
            };
            return dict;

        }
        private Dictionary<string, object> AddParameterNoticeTo(string maBoPhan, string maNhom, string maNhanVien, int isFull)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@stt", NoticeBLL.Instance.GetSTT() },
                {"@maBoPhan", maBoPhan },
                {"@maNhom", maNhom },
                {"@maNhanVien", maNhanVien },
                {"@isFull", isFull }
            };
            return dict;

        }
        private bool Save()
        {
            bool check = false;
            if (buffer == null)
            {
                check = NoticeBLL.Instance.AddNoticeWithout(AddParameterNoticeWithout());
            }
            else
            {
                check = NoticeBLL.Instance.AddNotice(AddParameterNotice());
            }
            if (check)
            {
                bool containsct = MSCBB_thongbao.SelectedItems.Cast<DataRowView>().Any(value => value["ID"].ToString() == "Ct");
                if (containsct)
                    if (NoticeBLL.Instance.AddNoticeTo(AddParameterNoticeTo(null, null, null, 1)))
                    {
                        List<Employee> emp = EmployeeBLL.Instance.GetEmployeeList();
                        foreach (Employee employee in emp)
                        {
                            string to, from, pass;
                            to = employee.Email;
                            from = "tasmanahr@gmail.com";
                            pass = "aakj tdjj vpsa kkap";
                            MailMessage message = new MailMessage();
                            message.To.Add(to);
                            message.From = new MailAddress(from);
                            message.Subject = $"Thông báo/Báo cáo từ {currentUser.MaNhanVien}";
                            message.Body = $"Bạn vừa nhận được 1 thông báo/báo cáo từ {currentUser.Ho} {currentUser.Ten} \nVui lòng đăng nhập vào phần mềm Tasmana để xem chi tiết";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                            {
                                UseDefaultCredentials = false,
                                EnableSsl = true,
                                Port = 587,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                Credentials = new NetworkCredential(from, pass)
                            };
                            try
                            {
                                smtp.Send(message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Có lỗi xảy ra khi gửi thông báo đến với nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return true;
                        }
                    }
                    else
                        return false;

                foreach (DataRowView item in MSCBB_thongbao.SelectedItems)
                {
                    List<Division> dv = DivisionBLL.Instance.GetDivisionList();
                    foreach (Division d in dv)
                    {
                        if (d.MaBoPhan == item["ID"].ToString())
                        {
                            if (NoticeBLL.Instance.AddNoticeTo(AddParameterNoticeTo(d.MaBoPhan, null, null, 0)))
                            {
                                List<Employee> emp = EmployeeBLL.Instance.GetEmployeeByDivision(item["ID"].ToString());
                                foreach(Employee employee in emp)
                                {
                                    string to, from, pass;
                                    to = employee.Email;
                                    from = "tasmanahr@gmail.com";
                                    pass = "aakj tdjj vpsa kkap";
                                    MailMessage message = new MailMessage();
                                    message.To.Add(to);
                                    message.From = new MailAddress(from);
                                    message.Subject = $"Thông báo/Báo cáo từ {currentUser.MaNhanVien}";
                                    message.Body = $"Bạn vừa nhận được 1 thông báo/báo cáo từ {currentUser.Ho} {currentUser.Ten} \nVui lòng đăng nhập vào phần mềm Tasmana để xem chi tiết";
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                                    {
                                        UseDefaultCredentials = false,
                                        EnableSsl = true,
                                        Port = 587,
                                        DeliveryMethod = SmtpDeliveryMethod.Network,
                                        Credentials = new NetworkCredential(from, pass)
                                    };
                                    try
                                    {
                                        smtp.Send(message);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Có lỗi xảy ra khi gửi thông báo đến với nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            }
                                
                            else
                                return false;
                        }
                    }
                    List<Group> groups = GroupBLL.Instance.GetGroupsList();
                    foreach (Group gr in groups)
                    {
                        bool containsgr = MSCBB_thongbao.SelectedItems.Cast<DataRowView>().Any(value => value["ID"].ToString() == gr.MaBoPhan);
                        if (containsgr)
                            break;

                        if (gr.MaNhom == item["ID"].ToString())
                        {
                            if (NoticeBLL.Instance.AddNoticeTo(AddParameterNoticeTo(null, gr.MaNhom, null, 0)))
                            {
                                List<Employee> emp = EmployeeBLL.Instance.GetEmployeeByDivision(item["ID"].ToString());
                                foreach (Employee employee in emp)
                                {
                                    string to, from, pass;
                                    to = employee.Email;
                                    from = "tasmanahr@gmail.com";
                                    pass = "aakj tdjj vpsa kkap";
                                    MailMessage message = new MailMessage();
                                    message.To.Add(to);
                                    message.From = new MailAddress(from);
                                    message.Subject = $"Thông báo/Báo cáo từ {currentUser.MaNhanVien}";
                                    message.Body = $"Bạn vừa nhận được 1 thông báo/báo cáo từ {currentUser.Ho} {currentUser.Ten} \nVui lòng đăng nhập vào phần mềm Tasmana để xem chi tiết";
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                                    {
                                        UseDefaultCredentials = false,
                                        EnableSsl = true,
                                        Port = 587,
                                        DeliveryMethod = SmtpDeliveryMethod.Network,
                                        Credentials = new NetworkCredential(from, pass)
                                    };
                                    try
                                    {
                                        smtp.Send(message);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Có lỗi xảy ra khi gửi thông báo đến với nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            }
                                
                            else
                                return false;
                        }
                    }
                    List<Employee> employees = EmployeeBLL.Instance.GetEmployeeList();
                    foreach (Employee e in employees)
                    {
                        bool containsem = MSCBB_thongbao.SelectedItems.Cast<DataRowView>().Any(value => value["ID"].ToString() == e.MaNhom);
                        bool containsgr = MSCBB_thongbao.SelectedItems.Cast<DataRowView>().Any(value => value["ID"].ToString() == e.MaBoPhan);
                        if (containsem || containsgr)
                            break;
                        if (e.MaNhanVien == item["ID"].ToString())
                        {
                            if (NoticeBLL.Instance.AddNoticeTo(AddParameterNoticeTo(null, null, e.MaNhanVien, 0)))
                            {
                                string to, from, pass;
                                to = e.Email;
                                from = "tasmanahr@gmail.com";
                                pass = "aakj tdjj vpsa kkap";
                                MailMessage message = new MailMessage();
                                message.To.Add(to);
                                message.From = new MailAddress(from);
                                message.Subject = $"Bạn vừa nhận được 1 thông báo/báo cáo từ {currentUser.MaNhanVien}";
                                message.Body = $"Bạn vừa nhận được 1 thông báo/báo cáo từ {currentUser.Ho} {currentUser.Ten} \nVui lòng đăng nhập vào phần mềm Tasmana để xem chi tiết";
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                                {
                                    UseDefaultCredentials = false,
                                    EnableSsl = true,
                                    Port = 587,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    Credentials = new NetworkCredential(from, pass)
                                };
                                try
                                {
                                    smtp.Send(message);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Có lỗi xảy ra khi gửi thông báo đến với nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            else
                                return false;
                        }
                    }

                }
                return true;

            }
            else
            {
                return false;
            }
        }
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MSCBB_thongbao.Items.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn người nhận");
                return;
            }
            if (TXB_tieude.Text == null)
            {
                MessageBox.Show("Vui lòng nhập tiêu đề");
                return;
            }
            if (TXB_noidung.Text == null)
            {
                MessageBox.Show("Vui lòng điền nội dung");
                return;
            }
            if (Save())
            {
                MessageBox.Show("Gửi thành công");

                this.Close();
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
        }

        private void BTN_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.ValidateNames = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Bạn có chắc muốn upload file này chứ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        string file = dlg.FileName;
                        buffer = File.ReadAllBytes(file);
                        string[] words = file.Split('\\');
                        int length = words.Length;
                        fileName = words[length - 1];
                        string[] w = fileName.Split('.');
                        int l = w.Length;
                        fileExten = w[l - 1];
                    }
                }
            }
            LLB_hienfile.Text = fileName;
            LLB_hienfile.Show();
        }
    }
}
