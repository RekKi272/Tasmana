using DAO;
using DTO;
using Syncfusion.GridHelperClasses;
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
using Syncfusion.Windows.Forms.Grid;
using BLL;

namespace DangNhap
{
    public partial class LichSuCanHo : Form
    {
        private readonly Apartment canHoHienTai;
        public LichSuCanHo()
        {
            InitializeComponent();
        }
        public LichSuCanHo(Apartment canHoHienTai)
        {
            InitializeComponent();
            this.canHoHienTai = canHoHienTai;
        }
        private void DisplayLichSu()
        {
            if (canHoHienTai.LichSuGiaoDich == null)
                return;
            TXB_congno.Text = canHoHienTai.LichSuGiaoDich.TinhTrangCongNo.ToString();
            TXB_dv.Text = canHoHienTai.LichSuGiaoDich.LichSuNopPhiDichVu.ToString();
            TXB_doxe.Text = canHoHienTai.LichSuGiaoDich.LichSuDangKyDoXe.ToString();
            string maCuDanTruoc = canHoHienTai.LichSuGiaoDich.MaCuDanTruoc;
            if (!string.IsNullOrEmpty(maCuDanTruoc))
                TXB_chuhotruoc.Text = maCuDanTruoc + "_" + ResidentBLL.Instance.GetNameOfMaCuDan(maCuDanTruoc);
        }
        private void DisplayGGC_Dichvu()
        {
            GGC_dichvu.DataSource = JobDAO.Instance.GetJobByApartmentId(canHoHienTai.MaCanHo);
            GGC_DataSourceChanged(GGC_dichvu);
            GGC_dichvu.Size = new System.Drawing.Size(950, 404);
            GGC_dichvu.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_dichvu.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            GGC_dichvu.ShowGroupDropArea = true;
            GGC_dichvu.BorderStyle = BorderStyle.FixedSingle;


            // Thiết lập cho từng cột
            GridColumnDescriptorCollection columns = GGC_dichvu.TableDescriptor.Columns;
            foreach (GridColumnDescriptor column in columns)
            {
                column.AllowFilter = true;
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }

            // Thiết lập Dynamic Filter và Excel Filter
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_dichvu);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_dichvu);

            GGC_dichvu.TableDescriptor.Columns[0].HeaderText = "Mã công việc";
            GGC_dichvu.TableDescriptor.Columns[1].HeaderText = "Nội dung";
            GGC_dichvu.TableDescriptor.VisibleColumns.Remove("ngayGiao");
            GGC_dichvu.TableDescriptor.VisibleColumns.Remove("thoiHan");
            GGC_dichvu.TableDescriptor.VisibleColumns.Remove("ngayHoanThanh");
            GGC_dichvu.TableDescriptor.VisibleColumns.Remove("ngayCapNhat");
            GGC_dichvu.TableDescriptor.Columns[6].HeaderText = "Trạng thái";
            GGC_dichvu.TableDescriptor.Columns[7].HeaderText = "Ghi chú";
            GGC_dichvu.TableDescriptor.VisibleColumns.Remove("quyenTruyCap");
            GGC_dichvu.TableDescriptor.Columns[9].HeaderText = "Mã nhân viên phụ trách";
            GGC_dichvu.TableDescriptor.Columns[10].HeaderText = "Họ nhân viên phụ trách";
            GGC_dichvu.TableDescriptor.Columns[11].HeaderText = "Tên nhân viên phụ trách";
        }
        private void GGC_DataSourceChanged(GridGroupingControl ggc)
        {
            if (ggc.TableDescriptor.Columns.Contains("NgayHoanThanh"))
            {
                var col = ggc.TableDescriptor.Columns["NgayHoanThanh"];
                col.Appearance.AnyCell.CellValueType = typeof(string);
                foreach (var comp in ggc.Table.Records)
                {
                    var cellValue = comp.GetValue("NgayHoanThanh");
                    if (cellValue.ToString().Contains("1/1/0001"))
                    {
                        cellValue = null;
                    }
                }
            }
            if (ggc.TableDescriptor.Columns.Contains("ThoiHan"))
            {
                var col = ggc.TableDescriptor.Columns["ThoiHan"];
                col.Appearance.AnyCell.CellValueType = typeof(string);
                foreach (var comp in ggc.Table.Records)
                {
                    var cellValue = comp.GetValue("ThoiHan");
                    if (cellValue.ToString().Contains("1/1/0001"))
                    {
                        cellValue = null;
                    }
                }
            }
        }
        private void LichSuCanHo_Load(object sender, EventArgs e)
        {
            DisplayGGC_Dichvu();
            DisplayLichSu();
        }
        
    }
}
