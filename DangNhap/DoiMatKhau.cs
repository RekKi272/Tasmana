using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace DangNhap
{
    public partial class DoiMatKhau : Form
    {
        private readonly Account currentAccount;
        public DoiMatKhau(Account currentAccount)
        {
            this.currentAccount = currentAccount;
            InitializeComponent();
        }
        // Hàm khởi tạo danh sách giá trị truyền vào SP
        private object[] values;
        private void InitializeValues()
        {
            values = new object[]
            {
                currentAccount.UserId,
                TXB_mkmoi.Text
            };
        }

        // Tạo dictionary để truyền vào DataProvider
        private Dictionary<string, object> AddParameter()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maNguoiDung", values[0] },
                {"@matKhau", values[1] }
            };
            return dict;
        }

        private void BTN_luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXB_mkhientai.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại");
                return;
            }
            if (string.IsNullOrEmpty(TXB_mkmoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
                return;
            }
            if (string.IsNullOrEmpty(TXB_xacnhanmk.Text))
            {
                MessageBox.Show("Vui xác nhận mật khẩu mới");
                return;
            }
            if (currentAccount.Password == TXB_mkhientai.Text)
            {
                if (TXB_mkmoi.Text == TXB_xacnhanmk.Text)
                {
                    InitializeValues();
                    MessageBox.Show(AccountBLL.Instance.UpdatePassword(AddParameter()));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng với mật khẩu xác nhận");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không trùng với mật khẩu hiện tại bạn đã nhập");
                return;
            }
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;

        private void DoiMatKhau_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void DoiMatKhau_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void DoiMatKhau_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
