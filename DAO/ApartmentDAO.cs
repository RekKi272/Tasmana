using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ApartmentDAO
    {
        private static ApartmentDAO instance;
        public static ApartmentDAO Instance
        {
            get { if (instance == null) instance = new ApartmentDAO(); return instance; }
            private set { instance = value; }
        }
        private ApartmentDAO() { }
        public DataTable GetAllApartments()
        {
            string query = "select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetApartmentById(string maCanHo)
        {
            string query = $"select * from CanHo where maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool UpdateApartment(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_CapNhatCanHo", parameters);
            return result > 0;
        }
        public bool DeleteApartment(string maCanHo)
        {
            string query = $"exec SP_XoaCanHo @maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool AddMonthlyBill(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedure("SP_ThemChiPhiHangThang", parameters) > 0;
        }
        public DataTable GetMonthlyBill()
        {
            string query = $"Select * From ChiPhiHangThang";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool EditMonthlyBill(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedure("EditHoaDonHangThang", parameters) > 0;
        }
        // Lấy công nợ của tất cả căn hộ
        public DataTable GetDebtOfAllApartments()
        {
            string query = "EXEC ThongKeCongNo";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Lấy công nợ của căn hộ nhất định
        public DataTable GetDebtOfApartment(string maCanHo) 
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@maCanHo", maCanHo);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("ThongKeCongNoTheoCanHo", parameters);
            return result;
        }
        // Lấy danh sách yêu cầu
        public DataTable GetRequestList()
        {
            string query = "EXEC DanhSachYeuCauSuaChua";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // List Năm có trong csdl
        public DataTable GetYearList()
        {
            string query = "SELECT DISTINCT YEAR(ngayGhi) AS Nam FROM ChiPhiHangThang ORDER BY Nam";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Lấy tổng chi phí điện / nước theo khoảng thời gian
        public DataTable GetElectricity_WaterCost(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("ChiPhiDienNuoc", parameters);
            return result;
        }
        // Lấy tổng chi phí quản lý hàng tháng theo khoảng thời gian
        public DataTable GetManagementFee(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("ChiPhiQuanLy", parameters);
            return result;
        }
        // Lấy tổng phí dịch vụ khác theo khoảng thòi gian
        public DataTable GetServiceFee(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("TongPhiDichVuKhac", parameters);
            return result;
        }
        // Thống kê tình trạng căn hộ
        public DataTable GetStateOfApartments(string tinhTrangCanHo)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tinhTrangCanHo", tinhTrangCanHo);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("ThongKeTinhTrangCanHo", parameters);
            return result;
        }
        // Thống kê tất cả nhân viên phụ trách các căn hộ 
        public DataTable GetAllEmployessOfApartments()
        {
            string query = "EXEC ThongKeAllNhanVienOfAparments";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // Thống kê nhân viên phụ trách công việc tại căn hộ nhất định
        public DataTable GetEmployeesOfSpecificApartment(string maCanHo)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@maCanHo", maCanHo);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("ThongKeNhanVienPhuTrachCanHo", parameters);
            return result;
        }
    }
}
