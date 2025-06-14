using BLL;
using DTO;
using iTextSharp.text.pdf;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Licensing;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class ThongKeCanHo : Form
    {
        public ThongKeCanHo()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzIxOTI2MkAzMjM1MmUzMDJlMzBORkJZeFRVdUQxeERjT2xkWC9vdFgxS29wUmREOU9CZVdENkRUN0lrSStVPQ==;Mgo+DSMBaFt6QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRbQlliS3xTck1hW35Wcnc=");
            InitializeComponent();
        }

        private void CBB_DuLieuTK_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CBB_DuLieuTK.SelectedItem.Equals("Mã căn hộ")) 
            {
                CBB_DuLieuMuonThongKe.Enabled = true;
                string[] ListOption = {"Công nợ", "Danh sách yêu cầu", "Tổng chi phí điện/nước", "Tổng chi phí quản lý", "Các phí dịch vụ khác", "Tình trạng căn hộ", "Nhân viên phụ trách"};
                CBB_DuLieuMuonThongKe.Items.Clear();
                foreach(string option in ListOption) 
                {
                    CBB_DuLieuMuonThongKe.Items.Add(option);
                }
            }
            /*
            if(CBB_DuLieuTK.SelectedItem.Equals("Nhân viên"))
            {
                // Disable unused CBB
                CBB_DuLieuMuonThongKe.Enabled = false;
                CBB_LoaiThoiGian.Enabled = false;
                CBB_Nam.Enabled = false;
                CBB_ThoiGian.Enabled = false;
                // Reset selection
                CBB_DuLieuMuonThongKe.SelectedIndex = -1;
                CBB_LoaiThoiGian.SelectedIndex = -1;
                CBB_Nam.SelectedIndex = -1;
                CBB_ThoiGian.SelectedIndex = -1;
                // Clear old items
                CBB_DuLieuMuonThongKe.Items.Clear();
                CBB_LoaiThoiGian.Items.Clear();
                CBB_Nam.Items.Clear();
                CBB_ThoiGian.Items.Clear();
            } */
            if(CBB_DuLieuTK.SelectedItem.Equals("Cư dân"))
            {
                // Disable unused CBB
                CBB_DuLieuMuonThongKe.Enabled = false;
                CBB_LoaiThoiGian.Enabled = false;
                CBB_Nam.Enabled = false;
                CBB_ThoiGian.Enabled = false;
                // Reset selection
                CBB_DuLieuMuonThongKe.SelectedIndex = -1;
                CBB_LoaiThoiGian.SelectedIndex = -1;
                CBB_Nam.SelectedIndex = -1;
                CBB_ThoiGian.SelectedIndex = -1;
                // Clear old items
                CBB_DuLieuMuonThongKe.Items.Clear();
                CBB_LoaiThoiGian.Items.Clear();
                CBB_Nam.Items.Clear();
                CBB_ThoiGian.Items.Clear();

                string[] listOptions = { "Người nước ngoài" , "Người Việt Nam"};
                foreach(string option in listOptions)
                {
                    CBB_DuLieuMuonThongKe.Items.Add(option);
                }
                CBB_DuLieuMuonThongKe.Enabled = true;
                CBB_DuLieuMuonThongKe.Focus();  
            }
        }

        private void LoadApartment()
        {
            List<Apartment> list;   
            list = ApartmentBLL.Instance.GetApartmentList();
            CBB_LoaiThoiGian.Items.Clear();
            CBB_LoaiThoiGian.Items.Add("Tất cả");
            foreach(Apartment a in list)
            {
                CBB_LoaiThoiGian.Items.Add(a.MaCanHo);
            }
        }
        private void CBB_DuLieuMuonThongKe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CBB_DuLieuMuonThongKe.Enabled == true)
            {
                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Công nợ"))
                {
                    // Disabled all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();


                    LB_ThoiGianTK.Text = "Chọn mã căn hộ";
                    LoadApartment();
                    CBB_LoaiThoiGian.Enabled = true;
                    CBB_LoaiThoiGian.Focus();
                }
                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Danh sách yêu cầu"))
                {
                    // Disabled all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();
                    BTN_ThongKe.Focus();
                }
                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí điện/nước") || CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí quản lý") || CBB_DuLieuMuonThongKe.SelectedItem.Equals("Các phí dịch vụ khác"))
                {
                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();

                    LB_ThoiGianTK.Text = "Dữ liệu cần thống kê";
                    string[] optionList = { "Ngày", "Tháng", "Quý", "Năm" };
                    foreach (string option in optionList)
                    {
                        CBB_LoaiThoiGian.Items.Add(option);
                    }
                    CBB_LoaiThoiGian.Enabled = true;
                    CBB_LoaiThoiGian.Focus();
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tình trạng căn hộ"))
                {
                    // Disable all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;
                    
                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();
                    LB_ThoiGianTK.Text = "Dữ liệu cần thống kê";
                    string[] optionList = { "Chưa bán", "Đã bán", "Chưa bàn giao", "Đã bàn giao - Cư dân đang ở", "Đã bàn giao - Trống"};
                    foreach (string option in optionList)
                    {
                        CBB_LoaiThoiGian.Items.Add(option);
                    }
                    CBB_LoaiThoiGian.Enabled = true;
                    CBB_LoaiThoiGian.Focus();
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Nhân viên phụ trách"))
                {
                    // Disable all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();

                    LB_ThoiGianTK.Text = "Chọn mã căn hộ";
                    LoadApartment();
                    CBB_LoaiThoiGian.Enabled = true;
                    CBB_LoaiThoiGian.Focus();
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Người nước ngoài"))
                {
                    // Disable all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();
                    BTN_ThongKe.Focus();
                }
                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Người Việt Nam"))
                {
                    // Disable all unused CBB
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_LoaiThoiGian.Enabled = false;
                    CBB_LoaiThoiGian.SelectedIndex = -1;
                    CBB_LoaiThoiGian.Items.Clear();
                    BTN_ThongKe.Focus();
                }
            }
        }

        private void CBB_ThoiGian_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if(CBB_ThoiGian.SelectedIndex != -1 && !CBB_ThoiGian.SelectedItem.Equals("Năm"))
            {
                // Clear old CBB
                CBB_Nam.Enabled = false;
                CBB_Nam.Items.Clear();
                CBB_Nam.SelectedIndex = -1;
                List<int> years = ApartmentBLL.Instance.GetYearList();
                for (int i = 0; i < years.Count; i++)
                {
                    CBB_Nam.Items.Add(years[i]);
                }
                CBB_Nam.Enabled = true;
                CBB_Nam.Focus();
            }
        }
        private void CBB_Nam_SelectedValueChanged(object sender, EventArgs e)
        {
            if(CBB_Nam.SelectedIndex != -1 && CBB_ThoiGian.SelectedIndex != -1 && !CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
            {
                // Get the selected year
                int selectedYear = (int)CBB_Nam.SelectedItem;

                // Parse the selected month to extract the month number
                if (CBB_ThoiGian.SelectedItem.ToString().StartsWith("Tháng "))
                {
                    // Get the selected month (assuming it's in the format "Tháng x")
                    string selectedMonth = CBB_ThoiGian.SelectedItem.ToString();

                    // This will store the month number
                    if (int.TryParse(selectedMonth.Substring(6), out int monthNumber))
                    {
                        // Set the start date to the first day of the selected month and year
                        DateTime startDate = new DateTime(selectedYear, monthNumber, 1);

                        // Set the end date to the last day of the selected month and year
                        DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                        // Assign the start and end dates to the appropriate DateTimePicker controls
                        DTP_TuNgay.Value = startDate;
                        DTP_DenNgay.Value = endDate;
                    }
                }

                if (CBB_ThoiGian.SelectedItem.ToString().StartsWith("Quý "))
                {
                    // Get the selected quarter (assuming it's in the format "Quý x")
                    string selectedQuarter = CBB_ThoiGian.SelectedItem.ToString();

                    if (int.TryParse(selectedQuarter.Substring(4), out int quarterNumber))
                    {
                        // Calculate the start and end months of the selected quarter
                        int startMonth = (quarterNumber - 1) * 3 + 1; // First month of the quarter
                        int endMonth = startMonth + 2; // Last month of the quarter

                        // Set the start date to the first day of the selected quarter and year
                        DateTime startDate = new DateTime(selectedYear, startMonth, 1);

                        // Set the end date to the last day of the selected quarter and year
                        DateTime endDate = new DateTime(selectedYear, endMonth, DateTime.DaysInMonth(selectedYear, endMonth));

                        // Assign the start and end dates to the appropriate DateTimePicker controls
                        DTP_TuNgay.Value = startDate;
                        DTP_DenNgay.Value = endDate;
                    }
                }
            }
            if(CBB_Nam.SelectedIndex != -1 && CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
            {
                // Get the selected year
                int selectedYear = (int)CBB_Nam.SelectedItem;
                // Set the start date to the first day of the selected year
                DateTime startDate = new DateTime(selectedYear, 1, 1);

                // Set the end date to the last day of the selected year
                DateTime endDate = new DateTime(selectedYear, 12, 31);

                // Assign the start and end dates to the appropriate DateTimePicker controls
                DTP_TuNgay.Value = startDate;
                DTP_DenNgay.Value = endDate;
            }
        }
        private void CBB_LoaiThoiGian_SelectedValueChanged(object sender, EventArgs e)
        {
            DTP_TuNgay.Enabled = false;
            DTP_DenNgay.Enabled = false;
            if(CBB_DuLieuMuonThongKe.SelectedIndex == -1)
            {
                return;
            }
            if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí điện/nước") || CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí quản lý") || CBB_DuLieuMuonThongKe.SelectedItem.Equals("Các phí dịch vụ khác"))
            {
                if(CBB_LoaiThoiGian.SelectedIndex == -1)
                {
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;
                
                    return;
                }
                if (CBB_LoaiThoiGian.SelectedItem.Equals("Ngày"))
                {
                    //Clear old CBB
                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    DTP_TuNgay.Enabled = true;
                    DTP_DenNgay.Enabled = true;
                    DTP_TuNgay.Focus();
                }
                if (CBB_LoaiThoiGian.SelectedItem.Equals("Tháng"))
                {
                    //Clear old CBB
                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    string[] listMonth = {"Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6","Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"};
                    CBB_ThoiGian.Items.Clear();
                    foreach(string m in listMonth)
                    {
                        CBB_ThoiGian.Items.Add(m);
                    }
                    CBB_ThoiGian.Enabled = true;
                    CBB_Nam.Enabled = true;
                    CBB_ThoiGian.Focus();
                }
                if (CBB_LoaiThoiGian.SelectedItem.Equals("Quý"))
                {
                    //Clear old CBB
                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;
                    
                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    CBB_ThoiGian.Enabled = true;
                    string[] listQuy = {"Quý 1", "Quý 2", "Quý 3", "Quý 4"};
                    CBB_ThoiGian.Items.Clear();
                    foreach (string m in listQuy)
                    {
                        CBB_ThoiGian.Items.Add(m);
                    }
                    CBB_Nam.Enabled = true;
                    CBB_ThoiGian.Focus();
                }
                if (CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
                {
                    // Disable unused CBB
                    CBB_Nam.SelectedIndex = -1;
                    CBB_Nam.Items.Clear();
                    CBB_Nam.Enabled = false;

                    CBB_ThoiGian.SelectedIndex = -1;
                    CBB_ThoiGian.Items.Clear();
                    CBB_ThoiGian.Enabled = false;

                    List<int> years = ApartmentBLL.Instance.GetYearList();
                    for (int i = 0; i < years.Count; i++)
                    {
                        CBB_Nam.Items.Add(years[i]);
                    }
                    CBB_Nam.Enabled = true;
                    CBB_Nam.Focus();
                }
            }
        }
        private void LoadGGC()
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
        // Load Công nợ của tất cả căn hộ
        private void LoadDebtOfAllApartments()
        {
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetDebtOfAllApartments();
            // Clear old data
            GGC_ThongKe.DataSource = null;
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tình trạng công nợ";
            }
            LoadGGC();
        }
        // Load Công nợ của một căn hộ nhất định
        private void LoadDebtOfApartment(string maCanHo)
        {
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetDebtOfApartment(maCanHo);
            GGC_ThongKe.DataSource = null;
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tình trạng công nợ";
            }
            LoadGGC();
        }
        // Load danh sách yêu cầu
        private void LoadRequestList()
        {
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetRequestList();
            GGC_ThongKe.DataSource = null;
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Mã người yêu cầu";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Họ tên";
                GGC_ThongKe.TableDescriptor.Columns[3].HeaderText = "Trạng thái yêu cầu";
                GGC_ThongKe.TableDescriptor.Columns[4].HeaderText = "Nhân viên phụ trách";
            }
            LoadGGC();
        }
        // Load chi phí ĐIỆN / NƯỚC theo ngày
        private void LoadElectricity_WaterCost()
        {
            DateTime tuNgay = DTP_TuNgay.Value;
            DateTime denNgay = DTP_DenNgay.Value;
            // Clear old data
            GGC_ThongKe.DataSource = null;

            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetElectricity_WaterCost(tuNgay, denNgay);
            GGC_ThongKe.DataSource = dataSource;

            if (dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tổng số điện";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Tổng chỉ số nước";
            }
            LoadGGC();
        }
        private void LoadManagementFee()
        {
            DateTime tuNgay = DTP_TuNgay.Value;
            DateTime denNgay = DTP_DenNgay.Value;
            // Clear old data
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetManagementFee(tuNgay, denNgay);
            GGC_ThongKe.DataSource = dataSource;

            if (dataSource.Columns.Count > 0 && dataSource.Rows.Count >0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tổng phí quản lý";
            }
            LoadGGC();
        }
        private void LoadServiceCharge()
        {
            DateTime tuNgay = DTP_TuNgay.Value;
            DateTime denNgay = DTP_DenNgay.Value;
            // Clear old data
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetServiceFee(tuNgay, denNgay);
            GGC_ThongKe.DataSource = dataSource;

            if (dataSource.Columns.Count > 0 && dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tổng phí quản lý";
            }
            LoadGGC();
        }
        // Load tình trạng căn hộ
        private void LoadStateOfApartments()
        {
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetStateOfApartments(CBB_LoaiThoiGian.SelectedItem.ToString());
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Tình trạng căn hộ";
            }
            LoadGGC();
        }
        // Load all nhân viên đã tham gia thực hiện công việc
        private void LoadALLEmployeesOfApartments()
        {
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetAllEmployessOfApartments();
            GGC_ThongKe.DataSource = dataSource;
            if(dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Mã nhân viên phụ trách";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Từ ngày";
                GGC_ThongKe.TableDescriptor.Columns[3].HeaderText = "Đến ngày";
            }
            LoadGGC();
        }
        // Load Nhân viên đã thâm gia thực hiện công việc tại căn hộ nhất định
        private void LoadEmployeesOfApartment(string maCanHo)
        {
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ApartmentBLL.Instance.GetEmployeesOfSpecificApartment(maCanHo);
            GGC_ThongKe.DataSource = dataSource;
            if (dataSource.Rows.Count > 0)
            {
                GGC_ThongKe.TableDescriptor.Columns[0].HeaderText = "Mã căn hộ";
                GGC_ThongKe.TableDescriptor.Columns[1].HeaderText = "Mã nhân viên phụ trách";
                GGC_ThongKe.TableDescriptor.Columns[2].HeaderText = "Từ ngày";
                GGC_ThongKe.TableDescriptor.Columns[3].HeaderText = "Đến ngày";
            }
            LoadGGC();
        }
        // Load Cư dân là người nước ngoài
        private void LoadForeigner()
        {
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ResidentBLL.Instance.GetAllForeignNational();
            GGC_ThongKe.DataSource = dataSource;
            LoadGGC();
        }
        // Load Cư dân là người Việt Nam
        private void LoadVietnameses()
        {
            GGC_ThongKe.DataSource = null;
            DataTable dataSource;
            dataSource = ResidentBLL.Instance.GetVietResidents();
            GGC_ThongKe.DataSource = dataSource;
            LoadGGC();
        }
        private void BTN_ThongKe_Click(object sender, EventArgs e)
        {
            if(CBB_DuLieuTK.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng muốn thống kê");
                CBB_DuLieuTK.Focus();
                return;
            }
            if(CBB_DuLieuTK.SelectedItem.Equals("Cư dân"))
            {
                if(CBB_DuLieuMuonThongKe.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn quốc tịch muốn thống kê");
                    CBB_DuLieuMuonThongKe.Focus();
                    return;
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Người nước ngoài"))
                {
                    LoadForeigner();
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Người Việt Nam"))
                {
                    LoadVietnameses();
                }
            }
            if(CBB_DuLieuTK.SelectedItem.Equals("Mã căn hộ"))
            {
                if(CBB_DuLieuMuonThongKe.SelectedIndex == -1) 
                {
                    MessageBox.Show("Vui lòng chọn mục tiêu muốn thống kê");
                    CBB_DuLieuMuonThongKe.Focus();
                    return;
                }

                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Công nợ"))
                {
                    if(CBB_LoaiThoiGian.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn mã căn hộ muốn thống kê");
                        CBB_LoaiThoiGian.Focus();
                        return;
                    }
                    if(CBB_LoaiThoiGian.SelectedItem.Equals("Tất cả"))
                    {
                        LoadDebtOfAllApartments();
                    }
                    else
                    {
                        string maCanHo = CBB_LoaiThoiGian.SelectedItem.ToString();
                        LoadDebtOfApartment(maCanHo);
                    }
                }
                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Nhân viên phụ trách"))
                {
                    if (CBB_LoaiThoiGian.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn mã căn hộ muốn thống kê");
                        CBB_LoaiThoiGian.Focus();
                        return;
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Tất cả"))
                    {
                        LoadALLEmployeesOfApartments();
                    }
                    else
                    {
                        string maCanHo = CBB_LoaiThoiGian.SelectedItem.ToString();
                        LoadEmployeesOfApartment(maCanHo);
                    }
                }

                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Danh sách yêu cầu"))
                {
                    LoadRequestList();
                }

                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí điện/nước"))
                {
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Ngày"))
                    {
                        LoadElectricity_WaterCost();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Tháng")){
                        if(CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn tháng muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if(CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của tháng muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadElectricity_WaterCost();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Quý"))
                    {
                        if (CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn quý muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadElectricity_WaterCost();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
                    {
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadElectricity_WaterCost();
                    }
                }

                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tổng chi phí quản lý"))
                {
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Ngày"))
                    {
                        LoadManagementFee();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Tháng"))
                    {
                        if (CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn tháng muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của tháng muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadManagementFee();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Quý"))
                    {
                        if (CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn quý muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadManagementFee();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
                    {
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadManagementFee();
                    }
                }

                if (CBB_DuLieuMuonThongKe.SelectedItem.Equals("Các phí dịch vụ khác"))
                {
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Ngày"))
                    {
                        LoadServiceCharge();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Tháng"))
                    {
                        if (CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn tháng muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của tháng muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadServiceCharge();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Quý"))
                    {
                        if (CBB_ThoiGian.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn quý muốn thống kê");
                            CBB_ThoiGian.Focus();
                            return;
                        }
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadServiceCharge();
                    }
                    if (CBB_LoaiThoiGian.SelectedItem.Equals("Năm"))
                    {
                        if (CBB_Nam.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn năm của quý muốn thống kê");
                            CBB_Nam.Focus();
                            return;
                        }
                        LoadServiceCharge();
                    }
                }
                if(CBB_DuLieuMuonThongKe.SelectedItem.Equals("Tình trạng căn hộ"))
                {
                    if(CBB_LoaiThoiGian.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn tình trạng căn hộ muốn thống kê");
                        CBB_LoaiThoiGian.Focus();
                        return;
                    }
                    LoadStateOfApartments();
                }
            }
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
