using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using Syncfusion.Licensing;
using Services;
using Meziantou.Framework.Win32;

namespace DangNhap
{
    public partial class DangNhap : Form
    {
        private Account currentAccount;
        private string userId;
        private string pwd;
        int mov;
        int movX;
        int movY;
        public DangNhap()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
            BTN_show.Visible = true;
            BTN_show.Enabled = true;
            BTN_hide.Visible = false;
            BTN_hide.Enabled = false;
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

        private void BT_DangNhap_Click(object sender, EventArgs e)
        {
            userId = CBBB_manguoidung.Text;
            pwd = TB_MatKhau.Text;

            if (string.IsNullOrEmpty(CBBB_manguoidung.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
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
                        AccountBLL.Instance.UpdateRememberId(userId, CHB_luuid.Checked);
                        CredentialHandler.SaveCredential(userId, pwd, CHB_luuid.Checked);
                    }
                    else
                    {
                        LB_Wrong.Text = "Tài khoản đã bị vô hiệu hóa";
                        LB_Wrong.Visible = true;
                        return;
                    }
                }
                else
                {
                    LB_Wrong.Text = "Mật khẩu không đúng";
                    LB_Wrong.Visible = true;
                    return;
                }
            }
            else
            {
                LB_Wrong.Text = "Tài khoản không tồn tại";
                return;
            }
        }

        private void BTN_close_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void DangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void DangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void DangNhap_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void BTN_show_Click(object sender, EventArgs e)
        {
            TB_MatKhau.UseSystemPasswordChar = true;
            BTN_show.Visible = false;
            BTN_show.Enabled = false;
            BTN_hide.Visible = true;
            BTN_hide.Enabled = true;
        }
        private void BTN_hide_Click(object sender, EventArgs e)
        {
            TB_MatKhau.UseSystemPasswordChar = false;
            BTN_show.Visible = true;
            BTN_show.Enabled = true;
            BTN_hide.Visible = false;
            BTN_hide.Enabled = false;
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            List<Credential> credentials = CredentialHandler.LoadCredential();
            List<string> usernames = new List<string>();
            foreach (Credential c in credentials)
            {
                usernames.Add(c.UserName);
            }
            System.Windows.Forms.ListBox listBox = new System.Windows.Forms.ListBox
            {
                DataSource = usernames
            };
            CBBB_manguoidung.ListControl = listBox;
            CBBB_manguoidung.ListControl.BackColor = Color.Black;
            CBBB_manguoidung.ListControl.ForeColor = Color.White;
        }
        private void CBBB_manguoidung_SelectionChangeCommitted(object sender, EventArgs e)
        {
            userId = CBBB_manguoidung.Text;
            if (CheckAccountExistence(userId))
            {
                GetAccount(userId);
                if (currentAccount.RememberUserId)
                {
                    CHB_luuid.Checked = true;
                }
            }
        }

        private void BTN_facelogin_Click(object sender, EventArgs e)
        {
            FaceDetectLogin faceDetectLogin = new FaceDetectLogin(this, currentAccount);
            faceDetectLogin.ShowDialog();
        }

        private void LB_quenpw_Click(object sender, EventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }
    }
}
