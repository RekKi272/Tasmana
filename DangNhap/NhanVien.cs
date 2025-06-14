
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
using System.Windows.Forms;

namespace DangNhap
{
    public partial class NhanVien : Form
    {
        private string[] headers = null;
        private Employee nhanVienChiTiet;
        private List<Employee> employees;
        public NhanVien()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            DisplayGGC_danhsachnhanvien();
        }

        // Nhấn nút thêm nhân viên sẽ mở cửa sổ thông tin nhân viên
        private void BTN_themnhanvien_Click(object sender, EventArgs e)
        {
            // Truyền form để refresh dgv
            ThongTinCaNhan ttcn = new ThongTinCaNhan(this);
            ttcn.ShowDialog();
        }
        // Lấy thông tin nhân viên bằng mã nhân viên
        private void GetEmployeeByEmployeeId(string maNhanVien)
        {
            nhanVienChiTiet = EmployeeBLL.Instance.GetEmployeeByEmployeeId(maNhanVien);
        }
        // Phương thức refresh lại GGC
        public override void Refresh()
        {
            employees = new List<Employee>();
            DisplayGGC_danhsachnhanvien();
        }
        // Hiển thị dữ liệu lên GGC_danhsachnhanvien
        private void DisplayGGC_danhsachnhanvien()
        {
            //GGC_danhsachnv.Size = new System.Drawing.Size(950, 404);
            GGC_danhsachnv.DataSource = EmployeeBLL.Instance.GetEmployees();

            if (BTN_themnhanvien.Text == "Thêm nhân viên")
            {
                headers = new string[] { "Mã nhân viên", "Họ", "Tên", "Mã định danh", "Mã Bộ phận", "Chức vụ", "Tổng công việc", "Hoàn thành", "Chưa bắt đầu", "Đang thực hiện", "Trễ hạn", "Công việc Phòng ban", "Công việc Nhóm" };
                for (int i = 0; i < headers.Length && i < GGC_danhsachnv.TableDescriptor.Columns.Count; i++)
                {
                    GGC_danhsachnv.TableDescriptor.Columns[i].HeaderText = headers[i];
                }
            }
            else
            {
                headers = new string[] { "Employees ID", "Family name", "Name", "Crendential number", "Division ID", "Position", "Total tasks", "Completed tasks", "Not started tasks", "On going tasks", "Late tasks", "Division tasks", "Group tasks" };
                for (int i = 0; i < headers.Length && i < GGC_danhsachnv.TableDescriptor.Columns.Count; i++)
                {
                    GGC_danhsachnv.TableDescriptor.Columns[i].HeaderText = headers[i];
                }
            }


            GGC_danhsachnv.TopLevelGroupOptions.ShowFilterBar = true;
            GGC_danhsachnv.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            GGC_danhsachnv.ShowGroupDropArea = true;
            GGC_danhsachnv.BorderStyle = BorderStyle.FixedSingle;

            //// Tạo đối tượng GridColumnDescriptorCollection để quản lý các cột
            GridColumnDescriptorCollection columns = GGC_danhsachnv.TableDescriptor.Columns;
            foreach (GridColumnDescriptor column in columns)
            {
                column.AllowFilter = true;
            }
            GridDynamicFilter dynamicFilter = new GridDynamicFilter();
            dynamicFilter.WireGrid(GGC_danhsachnv);

            GridExcelFilter excelFilter = new GridExcelFilter();
            excelFilter.WireGrid(GGC_danhsachnv);
            // Thiết lập AutoSizeMode cho mỗi cột
            foreach (GridColumnDescriptor column in columns)
            {
                column.Appearance.AnyRecordFieldCell.AutoSize = true;
                column.Appearance.AnyRecordFieldCell.CellType = "TextBox";
            }
        }

        private void GGC_danhsachnv_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridTableCellStyleInfo style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex);
            GridTableCellStyleInfoIdentity id = style.TableCellIdentity;
            if (id.DisplayElement.Kind == DisplayElementKind.Record)
            {
                Record record = id.DisplayElement.GetRecord();
                // Extract data from the record
                string maNhanVien = record.GetValue("maNhanVien").ToString();
                GetEmployeeByEmployeeId(maNhanVien);
                ThongTinCaNhan ttcn = new ThongTinCaNhan(this, nhanVienChiTiet);
                ttcn.ShowDialog();
            }
        }

        private void BTN_themnhom_Click(object sender, EventArgs e)
        {
            ThemNhom tn = new ThemNhom();
            tn.Show();
        }
        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            foreach (string header in headers)
            {
                DataColumn col = new DataColumn(header);
                dataTable.Columns.Add(col);
            }
            foreach (Record record in GGC_danhsachnv.Table.Records)
            {
                DataRow dtRow = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dtRow[i] = record.GetValue(GGC_danhsachnv.TableDescriptor.Columns[i].Name);
                }

                dataTable.Rows.Add(dtRow);
            }
            return dataTable;
        }
        private void BTN_excel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = GetDataTable();
            Export export = new Export();
            export.ToExcel(dataTable, "Nhan_vien", "NHÂN VIÊN/EMPLOYEES");

        }

        private void BTN_PDF_Click(object sender, EventArgs e)
        {
            if (GGC_danhsachnv.Table.Records.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "NhanVien.pdf"
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
                            export.ToPDF(dataTable, save.FileName, "NHÂN VIÊN");

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
            GGC_danhsachnv.TableModel.Properties.PrintFrame = false;

            GridPrintDocumentAdv gridPrintDocument = new GridPrintDocumentAdv(GGC_danhsachnv.TableControl);
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

        private void BTN_PhongBan_Click(object sender, EventArgs e)
        {
            ThemPhongBan themPhongBan = new ThemPhongBan();
            themPhongBan.ShowDialog();
        }

        private void BTN_ThemQuanLy_Click(object sender, EventArgs e)
        {
            ThemQuanLy th = new ThemQuanLy();
            th.FormClosed += Th_FormClosed; // Thêm event handler cho sự kiện FormClosed
            th.ShowDialog();
        }

        private void Th_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Thực hiện các thao tác sau khi form được đóng
            // Ví dụ: refresh lại trang hiện tại
            Refresh();
        }
    }
}
