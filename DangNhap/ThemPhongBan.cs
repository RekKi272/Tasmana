using BLL;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Licensing;
using Syncfusion.Windows.Forms.Grid.Grouping;
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
    public partial class ThemPhongBan : Form
    {
        public ThemPhongBan()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
        }
        private void LoadPhongBan()
        {
            GGC_PhongBan.DataSource = null;
            GGC_PhongBan.DataSource = DivisionBLL.Instance.GetAllDivision();
            GridColumnDescriptorCollection columns = GGC_PhongBan.TableDescriptor.Columns;
            if (columns.Count > 0)
            {
                foreach (GridColumnDescriptor column in columns)
                {
                    // Thiết lập thuộc tính cho mỗi cột
                    column.AllowFilter = true;
                }
                // Thiết lập các tiêu đề của cột

                //Tiếng Việt
                if(LB_Phongban.Text == "THÔNG TIN PHÒNG BAN")
                {
                    string[] headers = { "Mã bộ phận", "Tên bộ phận", "Số điện thoại", "Email" };
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }
                //Tiếng Anh
                else
                {
                    string[] headers = { "Division ID", "Division name", "Phone", "Email" };
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }
                
            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_PhongBan);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_PhongBan);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }

        private void ThemPhongBan_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GGC_PhongBan_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridTableCellStyleInfo style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex);
            GridTableCellStyleInfoIdentity id = style.TableCellIdentity;
            if (id.DisplayElement.Kind == DisplayElementKind.Record)
            {
                Record record = id.DisplayElement.GetRecord();
                if (record != null)
                {
                    TXB_maphongban.Text = record.GetValue("maBoPhan").ToString();
                    TXB_tenphongban.Text = record.GetValue("tenPB").ToString();
                    TXB_SDT.Text = record.GetValue("SDT").ToString();
                    TXB_Email.Text = record.GetValue("email").ToString();
                }
            }
        }

        private Dictionary<string, object> AddParameterEdit_Division()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"@maBoPhan", TXB_maphongban.Text},
                {"@tenPB", TXB_tenphongban.Text},
                {"@SDT", TXB_SDT.Text},
                {"@email", TXB_Email.Text}
            };
            return dict;
        }

        private bool EditDivision()
        {
            if (DivisionBLL.Instance.EditDivision(AddParameterEdit_Division()))
            {
                return true;
            }
            return false;
        }
        //Tiếng Việt
        private void ThongTinPhongBan_Vi()
        {
            if (string.IsNullOrEmpty(TXB_maphongban.Text))
            {
                MessageBox.Show("Vui lòng điền mã phòng ban");
                return;
            }
            if (string.IsNullOrEmpty(TXB_tenphongban.Text))
            {
                MessageBox.Show("Vui lòng không để trống tên phòng ban");
                return;
            }
            if (string.IsNullOrEmpty(TXB_SDT.Text))
            {
                MessageBox.Show("Vui lòng điền số điện thoại của phòng ban");
                return;
            }
            if (string.IsNullOrEmpty(TXB_Email.Text))
            {
                MessageBox.Show("Vui lòng điền địa chỉ email của phòng ban");
                return;
            }
            if (EditDivision())
            {
                MessageBox.Show("Thay đổi thành công");
                LoadPhongBan();
            }
            else
            {
                MessageBox.Show("Thay đổi thất bại");
            }
        }
        //Tiếng Anh
        private void ThongTinPhongBan_En()
        {
            if (string.IsNullOrEmpty(TXB_maphongban.Text))
            {
                MessageBox.Show("Please enter \"Division ID \"");
                return;
            }
            if (string.IsNullOrEmpty(TXB_tenphongban.Text))
            {
                MessageBox.Show("Please enter \"Division name\"");
                return;
            }
            if (string.IsNullOrEmpty(TXB_SDT.Text))
            {
                MessageBox.Show("\"Please enter \"Phone\"");
                return;
            }
            if (string.IsNullOrEmpty(TXB_Email.Text))
            {
                MessageBox.Show("\"Please enter \"Email\"");
                return;
            }
            if (EditDivision())
            {
                MessageBox.Show("Successful change");
                LoadPhongBan();
            }
            else
            {
                MessageBox.Show("Change failed");
            }
        }
        private void BTN_ok_Click(object sender, EventArgs e)
        {
            if(LB_Phongban.Text == "THÔNG TIN PHÒNG BAN")
            {
                ThongTinPhongBan_Vi();
            }
            else
            {
                ThongTinPhongBan_En();
            }
        }
        //Di chuyển form
        int mov;
        int movX;
        int movY;

        private void ThemPhongBan_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ThemPhongBan_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ThemPhongBan_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
