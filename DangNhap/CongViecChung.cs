using BLL;
using DTO;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Licensing;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace DangNhap
{
    public partial class CongViecChung : Form
    {
        private readonly Account currentAccount;
        private readonly Employee currentUser;
        private int index = 0;
        private int quyen = 0;
        private string[] hd = null;

        public CongViecChung(Account currentAccount)
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
            this.currentAccount = currentAccount;
            this.currentUser = EmployeeBLL.Instance.GetEmployeeByEmployeeId(this.currentAccount.EmployeeId);
        }
        private void BTN_themcongviec_Click(object sender, EventArgs e)
        {
            ThemCongViecNhanVien tcv = new ThemCongViecNhanVien(this, currentAccount);
            tcv.Show();
        }

        private void BTN_chitietcongviec_Click(object sender, EventArgs e)
        {
            ChiTietCongViec ctcv = new ChiTietCongViec(currentAccount);
            ctcv.Show();
        }

        private void PhanQuyen()
        {
            DataTable listQuanLy = EmployeeBLL.Instance.GetManager();
            bool isManager = false;

            foreach (DataRow row in listQuanLy.Rows)
            {
                if (row["maNhanVien"].ToString().Equals(currentAccount.EmployeeId))
                {
                    isManager = true;
                    break;
                }
            }

            if (isManager)
            {
                BTN_themcongviec.Enabled = true;
                BTN_themcongviec.Visible = true;
                return;
            }

            if (currentAccount.Level.Equals("CEO") || currentAccount.Level.Equals("DV"))
            {
                BTN_themcongviec.Enabled = true;
                BTN_themcongviec.Visible = true;
            }
            else
            {
                BTN_themcongviec.Enabled = false;
                BTN_themcongviec.Visible = false;
            }
        }
        private void CongViecChung_Load(object sender, EventArgs e)
        {
            CBB_loaicv.SelectedIndex = index;
            CBB_phanquyen.SelectedIndex = quyen;
            GGC_hienthicongviec.TableDescriptor.Columns.Clear();
            GGC_hienthicongviec.DataSource = null;
            if (index == 0)
            {
                Display_GGC_nhanvien();
            }
            else if (index == 1)
            {
                Display_GGC_nhom();
            }
            else if (index == 2)
            {
                Display_GGC_phongban();
            }
            else
                GGC_hienthicongviec.DataSource = null;
            PhanQuyen();
        }
        public void Display_GGC_nhanvien()
        {
            //GGC_hienthicongviec.Size = new System.Drawing.Size(1254, 404);
            GGC_hienthicongviec.DataSource = JobBLL.Instance.GetJobOfEmployeesPQ(quyen, this.currentUser, this.currentAccount.Level);

            GGC_hienthicongviec.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_hienthicongviec.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            GGC_hienthicongviec.ShowGroupDropArea = true;
            GGC_hienthicongviec.BorderStyle = BorderStyle.FixedSingle;

            GridColumnDescriptorCollection columns = GGC_hienthicongviec.TableDescriptor.Columns;
            if (columns.Count > 0)
            {
                foreach (GridColumnDescriptor column in columns)
                {
                    // Thiết lập thuộc tính cho mỗi cột
                    column.AllowFilter = true;
                }

                // Thiết lập các tiêu đề của cột
                //Tiếng Việt
                if(LB_loai.Text == "Chọn loại công việc")
                {
                    string[] headers = { "Mã công việc", "Mã nhân viên", "Họ", "Tên", "Mã nhóm", "Mã Bộ phận", "Nội dung", "Mã căn hộ", "Ngày giao", "Ngày cập nhật", "Thời hạn", "Ngày hoàn thành", "Trạng thái", "Ghi chú" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }
                //Tiếng Anh
                else
                {
                    string[] headers = { "Task ID", "Employee ID", "Family name", "Name", "Group ID", "Division ID", "Content", "Apartment ID", "Received date", "Updated date", "Deadline", "Completed date", "Status", "Notes" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }

            }

            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_hienthicongviec);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_hienthicongviec);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }

        public void Display_GGC_nhom()
        {
            //GGC_hienthicongviec.Size = new System.Drawing.Size(1254, 404);
            GGC_hienthicongviec.DataSource = JobBLL.Instance.GetJobOfGroupsPQ(quyen, this.currentUser, this.currentAccount.Level);

            GGC_hienthicongviec.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_hienthicongviec.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            GGC_hienthicongviec.ShowGroupDropArea = true;
            GGC_hienthicongviec.BorderStyle = BorderStyle.FixedSingle;

            GridColumnDescriptorCollection columns = GGC_hienthicongviec.TableDescriptor.Columns;
            if (columns.Count > 0)
            {
                foreach (GridColumnDescriptor column in columns)
                {
                    // Thiết lập thuộc tính cho mỗi cột
                    column.AllowFilter = true;
                }

                // Thiết lập tiêu đề cho các cột
                //Tiếng Việt
                if(LB_loai.Text == "Chọn loại công việc")
                {
                    string[] headers = { "Mã công việc", "Mã nhóm", "Mã Trưởng nhóm", "Mã Bộ phận", "Nội dung", "Mã căn hộ", "Ngày giao", "Ngày cập nhật", "Thời hạn", "Ngày hoàn thành", "Trạng thái", "Ghi chú" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }
                //Tiếng Anh
                else
                {
                    string[] headers = { "Task ID", "Group ID", "Group Leader ID", "Division ID", "Content", "Apartment ID", "Received dated", "Updated date", "Deadline", "Completed date", "Status", "Notes" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }

            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_hienthicongviec);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_hienthicongviec);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }

        public void Display_GGC_phongban()
        {
            //GGC_hienthicongviec.Size = new System.Drawing.Size(1254, 404);
            GGC_hienthicongviec.DataSource = JobBLL.Instance.GetJobOfDivisionsPQ(quyen, this.currentUser, this.currentAccount.Level);

            GGC_hienthicongviec.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_hienthicongviec.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            GGC_hienthicongviec.ShowGroupDropArea = true;
            GGC_hienthicongviec.BorderStyle = BorderStyle.FixedSingle;

            GridColumnDescriptorCollection columns = GGC_hienthicongviec.TableDescriptor.Columns;
            if (columns.Count > 0)
            {
                foreach (GridColumnDescriptor column in columns)
                {
                    // Thiết lập thuộc tính cho mỗi cột
                    column.AllowFilter = true;
                }

                // Thiết lập tiêu đề cho các cột
                //Tiếng Việt
                if (LB_loai.Text == "Chọn loại công việc")
                {
                    string[] headers = { "Mã công việc", "Mã Bộ phận", "Mã quản lý", "Nội dung", "Mã căn hộ", "Ngày giao", "Ngày cập nhật", "Thời hạn", "Ngày hoàn thành", "Trạng thái", "Ghi chú" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }
                //Tiếng Anh
                else
                {
                    string[] headers = { "Task ID", "Division ID", "Manager ID", "Content", "Apartment ID", "Received date", "Updated date", "Deadline", "Completed date", "Status", "Notes" };
                    hd = headers;
                    for (int i = 0; i < columns.Count && i < headers.Length; i++)
                    {
                        columns[i].HeaderText = headers[i];
                    }
                }

            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_hienthicongviec);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_hienthicongviec);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }

        }

        private DataTable GetDataTable(string[] headers)
        {
            DataTable dt = new DataTable();

            // Khởi tạo các cột trong DataTable từ mảng headers
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            // Lấy dữ liệu từ GridGroupingControl và thêm vào DataTable
            foreach (GridRecord record in GGC_hienthicongviec.Table.Records.Cast<GridRecord>())
            {
                DataRow row = dt.NewRow();

                // Đọc giá trị từ mỗi cột của record và thêm vào row tương ứng
                for (int i = 0; i < headers.Length; i++)
                {
                    row[i] = record.GetValue(headers[i]);
                }

                // Thêm row vào DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
        private void BTN_PDF_Click(object sender, EventArgs e)
        {
            if (GGC_hienthicongviec.Table.Records.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "CongViec.pdf"
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
                            DataTable dataTable = GetDataTable(hd);
                            Export export = new Export();
                            export.ToPDF(dataTable, save.FileName,"CÔNG VIỆC");

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
        private void BTN_excel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = GetDataTable(hd);
            Export export = new Export();
            export.ToExcel(dataTable, "Cong_viec", "CÔNG VIỆC CHUNG");

        }

        private void BTN_in_Click(object sender, EventArgs e)
        {
            GGC_hienthicongviec.TableModel.Properties.PrintFrame = false;

            GridPrintDocumentAdv gridPrintDocument = new GridPrintDocumentAdv(GGC_hienthicongviec.TableControl);
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

        private void CBB_loaicv_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CBB_loaicv.SelectedIndex;
            if (quyen != -1)
            {
                CongViecChung_Load(sender, e);
            }
            else
            {
                index = 0;
                CongViecChung_Load(sender, e);
            }
        }

        private void CBB_phanquyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            quyen = CBB_phanquyen.SelectedIndex;
            if (quyen != -1)
            {
                CongViecChung_Load(sender, e);
            }
            else
            {
                quyen = 0;
                CongViecChung_Load(sender, e);
            }
        }
        private ChiTietCongViec ctcv;
        private void GGC_hienthicongviec_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridTableCellStyleInfo style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex);
            GridTableCellStyleInfoIdentity id = style.TableCellIdentity;
            if (id.DisplayElement.Kind == DisplayElementKind.Record)
            {
                Record record = id.DisplayElement.GetRecord();

                // Extract data from the record
                string maCongViec = record.GetValue("Mã công việc").ToString();
                string maNhanVien;

                if (index != 0)
                {
                    maNhanVien = null;
                }
                else
                    maNhanVien = record.GetValue("Mã nhân viên").ToString();
                string maCanHo = record.GetValue("Mã căn hộ").ToString();
                string maPhongBan = record.GetValue("Mã Bộ phận").ToString();
                string maNhom;
                if (index == 2)
                {
                    maNhom = null;
                }
                else
                    maNhom = record.GetValue("Mã nhóm").ToString();
                if (string.IsNullOrEmpty(maCongViec))
                {
                    return;
                }
                Job curJob = JobBLL.Instance.GetJobFromJobID(maCongViec);
                string noiDungCV = curJob.NoiDung.ToString();
                string ghiChu = curJob.GhiChu.ToString();
                string trangThai = curJob.TrangThai.ToString();
                DateTime thoiHan = curJob.ThoiHan;
                int phiDichVu = curJob.PhiDichVu;

                // Add to ChiTietCongViec 
                ctcv = new ChiTietCongViec(currentAccount);
                ctcv.TXB_PhongBan.Text = maPhongBan;
                ctcv.TXB_Nhom.Text = maNhom;
                ctcv.TXB_MaNV.Text = maNhanVien;
                ctcv.TXB_noidung.Text = noiDungCV;
                ctcv.TXB_macanho.Text = maCanHo;
                ctcv.TXB_GhiChu.Text = ghiChu;
                ctcv.TXB_MaCV.Text = maCongViec;
                ctcv.CBB_TrangThai.Text = trangThai;
                ctcv.TXB_PhiDichVu.Text = phiDichVu.ToString();

                if (thoiHan > DateTime.MinValue)
                {
                    ctcv.CB_thoihan.Checked = true;
                    DateTime date = thoiHan.Date;
                    ctcv.DTP_ngay.Text = date.ToString();
                    ctcv.DTP_gio.Text = thoiHan.TimeOfDay.ToString();
                }

                ctcv.LLB_chitietfile.Text = JobBLL.Instance.GetNameFile(maCongViec);
                ctcv.LLB_chitietfile.Show();
                ctcv.CBB_quyentruycap.SelectedIndex = curJob.QuyenTruyCap;

                // Show Form
                ctcv.FormClosed += Ctcv_FormClosed; // Attach event handler for form closed event
                ctcv.ShowDialog();
            }
        }
        private void Ctcv_FormClosed(object sender, FormClosedEventArgs e)
        {
            CongViecChung_Load(sender, e);
        }

    }
}