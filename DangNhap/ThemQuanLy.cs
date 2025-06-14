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

namespace DangNhap
{
    public partial class ThemQuanLy : Form
    {
        public ThemQuanLy()
        {
            InitializeComponent();
            ReadPhongBan();
        }
        public List<Division> GetPhongBan()
        {
            List<Division> listMaPB;
            listMaPB = DivisionBLL.Instance.GetDivisionList();
            return listMaPB;
        }
        private void ReadPhongBan()
        {
            List<Division> listPB;
            CBB_phongban.Enabled = true;
            CBB_phongban.Items.Clear();
            listPB = GetPhongBan();
            for (int i = 0; i < listPB.Count; i++)
            {
                CBB_phongban.Items.Add(listPB[i].MaBoPhan + "-" + listPB[i].TenBoPhan);
            }
        }
        public List<Employee> GetEmployee(string maBoPhan)
        {
            List<Employee> list;
            list = EmployeeBLL.Instance.GetEmployeeByDivision(maBoPhan);
            return list;
        }

        public void ReadNV()
        {
            List<Employee> employees;
            CBB_nhanvien.Enabled = true;
            CBB_nhanvien.Items.Clear();
            employees = GetEmployee(CBB_phongban.SelectedItem.ToString().Split('-')[0]);
            for (int i = 0; i < employees.Count; i++)
            {
                CBB_nhanvien.Items.Add(employees[i].MaNhanVien + "_" + employees[i].Ten);
            }
        }

        private void CBB_phongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBB_phongban.SelectedIndex != -1)
            {
                ReadNV();
            }
        }

        private Dictionary<string, object> AddParametersForManager()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maNhanVien", CBB_nhanvien.SelectedItem.ToString().Split('_')[0]},
                {"@maBoPhan", CBB_phongban.SelectedItem.ToString().Split('-')[0]}
            };
            return dict;
        }
        private bool SaveManager()
        {
            if(EmployeeBLL.Instance.AddManager(AddParametersForManager()))
            {
                return true;
            }
            return false;
        }
        private void BTN_ok_Click(object sender, EventArgs e)
        {   
            //Tiếng Việt
            if(LB_themmoi.Text == "THÊM QUẢN LÝ")
            {
                if(CBB_phongban.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phòng ban");
                    CBB_phongban.Focus();
                    return;
                }
                if(CBB_nhanvien.SelectedIndex == -1) 
                {
                    MessageBox.Show("Vui lòng chọn Nhân viên");
                    CBB_nhanvien.Focus();
                    return; 
                            }
                 if (SaveManager())
                 {
                     MessageBox.Show("Thêm thành công");
                     this.Close();
                 }
                 else
                 {
                    MessageBox.Show("Thêm thất bại");
                 }
            }
            //Tiếng Anh
            else
            {
                if (CBB_phongban.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select \"Division\"");
                    CBB_phongban.Focus();
                    return;
                }
                if (CBB_nhanvien.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select \"Manager ID\"");
                    CBB_nhanvien.Focus();
                    return;
                }
                if (SaveManager())
                {
                    MessageBox.Show("Added Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Added Failed");
                }
            }
            
        }
        
        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;
        private void ThemQuanLy_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ThemQuanLy_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ThemQuanLy_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
