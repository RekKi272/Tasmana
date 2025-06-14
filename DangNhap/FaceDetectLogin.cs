using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Microsoft.VisualBasic.ApplicationServices;
using FaceRecognition;
using BLL;
using DTO;

namespace DangNhap
{
    public partial class FaceDetectLogin : Form
    {
        private Account currentAccount;
        private DangNhap formDangNhap;
        private string userId;
        private string pwd;
        public FaceDetectLogin()
        {
            InitializeComponent();
        }
        public FaceDetectLogin(DangNhap formDangNhap, Account currentAccount)
        {
            InitializeComponent();
            this.currentAccount = currentAccount;
            this.formDangNhap = formDangNhap;
        }
        Services.FaceRecognition faceRec = new Services.FaceRecognition();

        private void BTN_Opencam_Click(object sender, EventArgs e)
        {
            faceRec.OpenCamera(PB_Camera, PB_Capture);
        }

        private void BTN_save_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(TXB_userId.Text + "_" + TXB_MatKhau.Text);
            MessageBox.Show("Lưu thông tin đăng nhập thành công");
        }

        private void BTN_detect_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = true;
        }
        private bool CheckAccountExistence(string userId)
        {
            return AccountBLL.Instance.CheckAccountExistence(userId);
        }
        private bool CheckAccountPassword(string userId, string password)
        {
            return AccountBLL.Instance.CheckAccountPasword(userId, password);
        }
        private void GetAccount(string userId)
        {
            currentAccount = AccountBLL.Instance.GetAccount(userId);
        }
        private void BTN_login_Click(object sender, EventArgs e)
        {
            try
            {
                string credential = faceRec.GetCredential();
                userId = credential.Split('_')[0];
                pwd = credential.Split('_')[1];
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
            if (CheckAccountExistence(userId))
            {
                if (CheckAccountPassword(userId, pwd))
                {
                    GetAccount(userId);
                    if (!currentAccount.IsDisabled)
                    {
                        TrangHienThi formTrangChu = new TrangHienThi(currentAccount);
                        formTrangChu.Show();
                        this.Hide();
                        formDangNhap.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã bị vô hiệu hóa");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
        }

        private void BTN_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void Faceid_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Faceid_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Faceid_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
