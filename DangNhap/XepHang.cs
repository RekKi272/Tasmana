using BLL;
using DTO;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class XepHang : Form
    {
        public XepHang()
        {
            InitializeComponent();
        }

        private void SizeGCC()
        {
            //GGC_ThongKe.Size = new System.Drawing.Size(950, 404);
            GGC_ThongKe.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_ThongKe.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None;
            //GGC_ThongKe.ShowGroupDropArea = true;
            GGC_ThongKe.BorderStyle = BorderStyle.FixedSingle;
            // Tạo đối tượng GridColumnDescriptorCollection để quản lý các cột
            GridColumnDescriptorCollection columns = GGC_ThongKe.TableDescriptor.Columns;
            foreach (GridColumnDescriptor column in columns)
            {
                column.AllowFilter = true;
            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_ThongKe);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_ThongKe);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }
        // Tải dữ liệu thống kê/ xếp hạng NHÂN VIÊN theo DOANH THU lên GGC_ThongKe 
        private void LoadRatingOfEmployeeByRevenue()
        {
            DataTable dataSource;
            dataSource = JobBLL.Instance.GetRatingOfEmployeeByRevenue();
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Columns.Count > 0 )
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã nhân viên";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Họ tên";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Tổng doanh thu";
            }
            SizeGCC();
        }
        // Tải dữ liệu thống kê/ xếp hạng NHÂN VIÊN theo TỈ LỆ HOÀN THÀNH CÔNG VIỆC lên GGC_Thongke
        private void LoadRatingOfEmployeeByFinishRate()
        {
            DataTable dataSource;
            dataSource = JobBLL.Instance.GetRatingOfEmployeeByFinishRate();
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Columns.Count > 0 )
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã nhân viên";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Họ tên";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Tỉ lệ hoàn thành đúng hạn";
                GGC_ThongKe.TableDescriptor.Columns[3].HeaderText = "Tỉ lệ hoàn thành trước hạn";
                GGC_ThongKe.TableDescriptor.Columns[4].HeaderText = "Tỉ lệ hoàn thành trễ hạn";
                GGC_ThongKe.TableDescriptor.Columns[5].HeaderText = "Tỉ lệ không hoàn thành";
            }
            SizeGCC();
        }
        // Tải dữ liệu thống kê/ xếp hạng NHÂN VIÊN theo SỐ CÔNG VIỆC ĐÃ THỰC HIỆN TRONG KHOẢNG THỜI GIAN
        private void LoadRatingOfEmployeeByFinishedJob()
        {
            DataTable dataSource;
            DateTime tuNgay = DTP_TuNgay.Value;
            DateTime denNgay = DTP_DenNgay.Value;
            dataSource = JobBLL.Instance.GetRatingOfEmployeeByNumOfFinishedJob(tuNgay, denNgay);
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Columns.Count > 0 )
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã nhân viên";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Họ tên";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Số công việc đã thực hiện";
            }
            SizeGCC();
        }
        // Tải dữ liệu thống kê / Xếp hạng PHÒNG BAN (BỘ PHẬN) theo Doanh thu
        private void LoadRatingOfDivisionByRevenue()
        {
            DataTable dataSource;
            dataSource = JobBLL.Instance.GetRatingOfDivisionByRevenue();
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if (dataSource.Columns.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tên bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Tổng doanh thu";
            }
            SizeGCC();
        }

        // Tải dữ liệu thống kê / Xếp hạng PHÒNG BAN (BỘ PHẬN) theo Tỉ lệ hoàn thành công việc
        private void LoadRatingOfDivisionByFinishRate()
        {
            DataTable dataSource;
            dataSource = JobBLL.Instance.GetRatingofDivisionByFinishRate();
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if (dataSource.Columns.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tên bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Tỉ lệ hoàn thành đúng hạn";
                GGC_ThongKe.TableDescriptor.Columns[3].HeaderText = "Tỉ lệ hoàn thành trước hạn";
                GGC_ThongKe.TableDescriptor.Columns[4].HeaderText = "Tỉ lệ hoàn thành trễ hạn";
                GGC_ThongKe.TableDescriptor.Columns[5].HeaderText = "Tỉ lệ không hoàn thành";
            }
            SizeGCC();
        }
        // Tải dữ liệu thống kê / Xếp hạng PHÒNG BAN (BỘ PHẬN) theo SỐ CÔNG VIỆC ĐÃ THỰC HIỆN TRONG KHOẢNG THỜI GIAN
        private void LoadRatingOfDivisionOfFinishedJob()
        {
            DataTable dataSource;
            DateTime tuNgay = DTP_TuNgay.Value;
            DateTime denNgay = DTP_DenNgay.Value;
            dataSource = JobBLL.Instance.GetRatingOfDivisionByNumOfFinishedJob(tuNgay, denNgay);
            GGC_ThongKe.DataSource = null; // Clear previous data
            GGC_ThongKe.DataSource = dataSource;
            if (dataSource.Columns.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tên bộ phận";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Số công việc đã thực hiện";
            }
            SizeGCC();
        }
        private void BTN_XepHang_Click(object sender, EventArgs e)
        {
            if(!RBtn_PhongBan.Checked && !RBtn_NhanVien.Checked) 
            {
                MessageBox.Show("Vui lòng chọn mục tiêu muốn xếp hạng");
                return;
            }
            if(CBB_TieuChiXepHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí xếp hạng");
            }
            else
            {
                // Xếp hạng/ thống kê theo nhân viên
                if (RBtn_NhanVien.Checked)
                {
                    // Xếp hạng theo Doanh thu 
                    if (CBB_TieuChiXepHang.Text.Equals("Doanh thu")){
                        LoadRatingOfEmployeeByRevenue();
                    }
                    // Xếp hạng theo tỉ lệ hoàn thành công việc
                    if(CBB_TieuChiXepHang.Text.Equals("Tỉ lệ hoàn thành công việc"))
                    {
                        LoadRatingOfEmployeeByFinishRate();
                    }
                    // Xếp hạng theo số công việc đã thực hiện trong khoảng thời gian
                    if(CBB_TieuChiXepHang.Text.Equals("Số công việc thực hiện"))
                    {
                        LoadRatingOfEmployeeByFinishedJob();
                    }
                }
                // Xếp hạng / Thống kê theo Phòng ban (Bộ phận)
                if (RBtn_PhongBan.Checked)
                {
                    // Xếp hạng theo Doanh thu
                    if(CBB_TieuChiXepHang.Text.Equals("Doanh thu"))
                    {
                        LoadRatingOfDivisionByRevenue();
                    }
                    // Xếp hạng theo tỉ lệ hoàn thành công việc
                    if(CBB_TieuChiXepHang.Text.Equals("Tỉ lệ hoàn thành công việc"))
                    {
                        LoadRatingOfDivisionByFinishRate();
                    }
                    // Xếp hạng theo số công việc đã thực hiện trong khoảng thời gian
                    if (CBB_TieuChiXepHang.Text.Equals("Số công việc thực hiện"))
                    {
                        LoadRatingOfDivisionOfFinishedJob();
                    }
                }
            }
        }

        private void XepHang_Load(object sender, EventArgs e)
        {
            //GGC_ThongKe.Size = new System.Drawing.Size(950, 404);
            GGC_ThongKe.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_ThongKe.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None;
            //GGC_ThongKe.ShowGroupDropArea = true;
            GGC_ThongKe.BorderStyle = BorderStyle.FixedSingle;
        }

        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            string[] headers = new string[GGC_ThongKe.TableDescriptor.Columns.Count];
            for (int i = 0; i < GGC_ThongKe.TableDescriptor.Columns.Count; i++)
            {
                headers[i] = GGC_ThongKe.TableDescriptor.Columns[i].HeaderText;
            }
            foreach (string header in headers)
            {
                DataColumn col = new DataColumn(header);
                dataTable.Columns.Add(col);
            }
            foreach (Record record in GGC_ThongKe.Table.Records)
            {
                DataRow dtRow = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dtRow[i] = record.GetValue(GGC_ThongKe.TableDescriptor.Columns[i].Name);
                }

                dataTable.Rows.Add(dtRow);
            }

            return dataTable;
        }

        private void BTN_excel_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            DataTable dt = GetDataTable();
            export.ToExcel(dt, "Thong_Ke", "Thống Kê");
        }

        private void BTN_PDF_Click(object sender, EventArgs e)
        {
            if (GGC_ThongKe.Table.Records.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "ThongKe.pdf"
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
                            DataTable dataTable = GetDataTable();
                            Export export = new Export();
                            export.ToPDF(dataTable, save.FileName, "THỐNG KÊ");

                            MessageBox.Show("Successful", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No record found", "Info");
            }
        }

        private void BTN_in_Click(object sender, EventArgs e)
        {
            GGC_ThongKe.TableModel.Properties.PrintFrame = false;

            GridPrintDocumentAdv gridPrintDocument = new GridPrintDocumentAdv(GGC_ThongKe.TableControl);
            PrintDialog printDialog = new PrintDialog();
            gridPrintDocument.ScaleColumnsToFitPage = true;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = gridPrintDocument
            };

            printPreviewDialog.ShowDialog();
            printDialog.Document = gridPrintDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                gridPrintDocument.Print();
        }
    }
}
