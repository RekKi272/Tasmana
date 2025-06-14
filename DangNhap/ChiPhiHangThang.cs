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
    public partial class ChiPhiHangThang : Form
    {
        public ChiPhiHangThang()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
        }

        private void SizeGGC()
        {
            GGC_BillHangThang.Size = new System.Drawing.Size(950, 404);
            GGC_BillHangThang.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_BillHangThang.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None;
            //GGC_ThongKe.ShowGroupDropArea = true;
            GGC_BillHangThang.BorderStyle = BorderStyle.FixedSingle;
            // Tạo đối tượng GridColumnDescriptorCollection để quản lý các cột
            GridColumnDescriptorCollection columns = GGC_BillHangThang.TableDescriptor.Columns;
            foreach (GridColumnDescriptor column in columns)
            {
                column.AllowFilter = true;
            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_BillHangThang);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_BillHangThang);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }
        private void LoadHoaDonHangThang()
        {
            DataTable datasource = ApartmentBLL.Instance.GetMonthlyBill();
            // Clear old DataSource
            GGC_BillHangThang.DataSource = null;
            GGC_BillHangThang.DataSource = datasource;
            //Tiếng Việt
            if(LB_BillHangThang.Text == "HÓA ĐƠN HÀNG THÁNG")
            {
                if(datasource.Rows.Count > 0 )
                {
                    GGC_BillHangThang.TableDescriptor.Columns[0].HeaderText = "Mã hóa đơn";
                    GGC_BillHangThang.TableDescriptor.Columns[1].HeaderText = "Mã căn hộ";
                    GGC_BillHangThang.TableDescriptor.Columns[2].HeaderText = "Số điện hàng tháng";
                    GGC_BillHangThang.TableDescriptor.Columns[3].HeaderText = "Chỉ số nước hàng tháng";
                    GGC_BillHangThang.TableDescriptor.Columns[4].HeaderText = "Phí quản lý hàng tháng";
                    GGC_BillHangThang.TableDescriptor.Columns[5].HeaderText = "Tình trạng thanh toán";
                    GGC_BillHangThang.TableDescriptor.Columns[6].HeaderText = "Ngày ghi";
                    GGC_BillHangThang.TableDescriptor.Columns[7].HeaderText = "Ngày thanh toán";
                }
            }
            //Tiếng Anh
            else
            {
                if (datasource.Rows.Count > 0)
                {
                    GGC_BillHangThang.TableDescriptor.Columns[0].HeaderText = "Bill ID";
                    GGC_BillHangThang.TableDescriptor.Columns[1].HeaderText = "Apartment ID";
                    GGC_BillHangThang.TableDescriptor.Columns[2].HeaderText = "Monthly electricity number";
                    GGC_BillHangThang.TableDescriptor.Columns[3].HeaderText = "Monthly water numberg";
                    GGC_BillHangThang.TableDescriptor.Columns[4].HeaderText = "Monthly management fee";
                    GGC_BillHangThang.TableDescriptor.Columns[5].HeaderText = "Payment status";
                    GGC_BillHangThang.TableDescriptor.Columns[6].HeaderText = "Check date";
                    GGC_BillHangThang.TableDescriptor.Columns[7].HeaderText = "Payment date";
                }
            }
            
            SizeGGC();
        }
        private void ChiPhiHangThang_Load(object sender, EventArgs e)
        {
            LoadHoaDonHangThang();
        }

        private void BTN_ThemBill_Click(object sender, EventArgs e)
        {
            ThemHoaDonHangThang themHoaDon = new ThemHoaDonHangThang();
            themHoaDon.FormClosed += ThemHoaDon_FormClosed; // Hook up FormClosed event
            themHoaDon.ShowDialog();
        }
        private void ThemHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reload data after the ThemHoaDonHangThang form is closed
            LoadHoaDonHangThang();
        }

        private void GGC_BillHangThang_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridTableCellStyleInfo style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex);
            GridTableCellStyleInfoIdentity id = style.TableCellIdentity;
            if (id.DisplayElement.Kind == DisplayElementKind.Record)
            {
                Record record = id.DisplayElement.GetRecord();

                // Extract data from the record
                string billID = record.GetValue("billID").ToString();
                string maCanHo = record.GetValue("maCanHo").ToString();
                string soDien = record.GetValue("soDienHangThang").ToString();
                string soNuoc = record.GetValue("soNuocHangThang").ToString();
                string phiQuanLy = record.GetValue("phiQuanLyHangThang").ToString();
                string tinhTrang = record.GetValue("tinhTrangThanhToan").ToString();
                DateTime ngayGhi = (DateTime)record.GetValue("ngayGhi");

                // Add to ChiTietHoaDonHangThang
                ChiTietHoaDonHangThang cthdht = new ChiTietHoaDonHangThang();
                cthdht.TXB_BilliD.Text = billID;
                cthdht.TXB_MaCanHo.Text = maCanHo;
                cthdht.TXB_soDienHangThang.Text = soDien;
                cthdht.TXB_soNuocHangThang.Text = soNuoc;
                cthdht.TXB_phiQuanLy.Text = phiQuanLy;  
                cthdht.DTP_ngay.Value = ngayGhi;
                cthdht.CBB_tinhTrangThanhToan.Text = tinhTrang;

                cthdht.FormClosed += Cthdht_FormClosed; // Hook up FormClosed event
                cthdht.ShowDialog();
            }
        }
        private void Cthdht_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reload data after the ChiTietHoaDonHangThang form is closed
            LoadHoaDonHangThang();
        }

        //MoveForm
        int mov;
        int movX;
        int movY;
        private void HoaDon_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void HoaDon_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void HoaDon_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void BTN_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
