using BLL;
using DTO;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class ChiTietCongViec : Form
    {
        private readonly Account currentAccount;
        public ChiTietCongViec(Account currentAccount)
        {
            InitializeComponent();
            this.currentAccount = currentAccount;
            // Phân quyền chức năng
            PhanQuyen();
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void PN_nen_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void PN_nen_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void PN_nen_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Phân quyền
        private void PhanQuyen()
        {
            if (!currentAccount.Level.Equals("CEO")){
                gunaGradientButton1.Visible = false;
                gunaGradientButton1.Enabled = false;
            }
        }

        private bool GetNgayHoanThanhCongViec()
        {
            if (CBB_TrangThai.Text.Equals("Hoàn thành") || CBB_TrangThai.Text.Equals("Completed"))
            {
                return true;
            }
            return false;
        }

        private int GetQuyenTruyCap()
        {
            int ch = 0; // mặc định là riêng tư
            if (CBB_quyentruycap.SelectedItem.ToString().Equals("Bộ phận") || CBB_quyentruycap.SelectedItem.ToString().Equals("Division"))
            {
                ch = 1;
            }
            if (CBB_quyentruycap.SelectedItem.ToString().Equals("Công ty") || CBB_quyentruycap.SelectedItem.ToString().Equals("Company"))
            {
                ch = 2;
            }
            return ch;
        }
        private bool CheckThoiHan()
        {
            if (CB_thoihan.Checked)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, object> AddParameterEdit_Job()
        {
            DateTime combinedDateTime = DTP_ngay.Value.Date + DTP_gio.Value.TimeOfDay;
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maCongViec", TXB_MaCV.Text},
                {"@noiDung", TXB_noidung.Text},
                {"@thoiHan", CheckThoiHan() ? (object)combinedDateTime : null}, // Combine Date and Time components
                {"@ngayHoanThanh", GetNgayHoanThanhCongViec() ? (object)DateTime.Now : null}, // Use DateTime directly
                {"@ngayCapNhat", DateTime.Now},
                {"trangThai", CBB_TrangThai.SelectedItem.ToString()},
                {"@ghiChu", TXB_GhiChu.Text},
                {"@quyenTruyCap", GetQuyenTruyCap()},
                {"@phiDichVu", int.Parse(TXB_PhiDichVu.Text)}
            };
            return dict;
        }
        private void BTN_luu_Click(object sender, EventArgs e)
        {
            //Tiếng Việt
            if(LB_themcongviec.Text == "CHI TIẾT CÔNG VIỆC")
            {
                if (JobBLL.Instance.EditJobOfEmployee(AddParameterEdit_Job()))
                {
                    MessageBox.Show("Chỉnh sửa thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại");
                    //this.Close();
                }
            }
            //Tiếng Anh
            else
            {
                if (JobBLL.Instance.EditJobOfEmployee(AddParameterEdit_Job()))
                {
                    MessageBox.Show("Successful change");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Change failed");
                    //this.Close();
                }
            }

        }

        private Dictionary<string, object> AddParameterDeleteJobOfEmployee()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maCongViec", TXB_MaCV.Text},
            };
            return dict;
        }
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            //Tiếng Việt
            if(LB_themcongviec.Text == "CHI TIẾT CÔNG VIỆC")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa công việc của nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kiểm tra xem người dùng đã chọn Yes hay không
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa nếu người dùng chọn Yes
                    if (JobBLL.Instance.DeleteJobOfEmployee(AddParameterDeleteJobOfEmployee()))
                    {
                        MessageBox.Show("Xóa thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            //Tiếng Anh
            else
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Are you sure to delete this task?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kiểm tra xem người dùng đã chọn Yes hay không
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa nếu người dùng chọn Yes
                    if (JobBLL.Instance.DeleteJobOfEmployee(AddParameterDeleteJobOfEmployee()))
                    {
                        MessageBox.Show("Deleted Successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Deleted Failed");
                    }
                }
            }
            
        }

        private void LLB_chitietfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = LLB_chitietfile.Text,
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
                        byte[] bytes = JobBLL.Instance.GetFileOfJob(TXB_MaCV.Text);
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
