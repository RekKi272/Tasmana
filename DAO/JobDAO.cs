using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace DAO
{
    public class JobDAO
    {
        private static JobDAO instance;

        public static JobDAO Instance
        {
            get { if (instance == null) instance = new JobDAO(); return instance; }
        }
        private JobDAO() { }

        public DataTable GetAllJob()
        {
            string query = "select * from CongViec";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool AddJob(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_ThemCongViec", parameters);
            return result > 0;
        }

        public string GetNewJobID()
        {
            // Define the output parameter dictionary
            Dictionary<string, SqlDbType> outputParams = new Dictionary<string, SqlDbType>();
            outputParams.Add("@nextJobId", SqlDbType.VarChar);

            // Call the method to execute the stored procedure and retrieve output parameters
            Dictionary<string, object> outputValues = DataProvider.Instance.ExecuteStoredProcedureWithOutput("[dbo].[Auto_Create_Job]", outputParams);

            // Retrieve the value of the output parameter '@nextJobId'
            string nextJobId = outputValues["@nextJobId"].ToString();
            return nextJobId;
        }

        public bool AddJob_Employee(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemCongViec_NhanVien", parameters);
            return result > 0;
        }

        public bool AddJob_Group(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemCongViec_Nhom", parameters);
            return result > 0;
        }

        public bool AddJob_Division(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemCongViec_PhongBan", parameters);
            return result > 0;
        }

        public bool AddJob_PDF(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemFile", parameters);
            return result > 0;
        }

        public bool AddRequestFromCustom(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("ThemYeuCau", parameters);
            return result > 0;
        }

        // Lấy Công việc của NV theo thời hạn hoàn thành công việc
        public DataTable GetJobOfEmployeeByDate(string maNV, string thoiHan)
        {
            string query = $"Select CV.* From CongViec CV, Congviec_Nhanvien CNV Where CV.maCongViec = CNV.maCongViec and CNV.maNhanVien = '{maNV}' and CONVERT(date, CV.thoiHan) = '{thoiHan}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // Lây tất cả công việc của một NV
        public DataTable GetAllJobOfEmployee(string maNV)
        {
            string query = $"Select CV.* From CongViec CV, Congviec_Nhanvien CNV Where CV.maCongViec = CNV.maCongViec and CNV.maNhanVien = '{maNV}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        // Chỉnh sửa công việc 
        public bool EditJobOfEmployee(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_EditCongViec", parameters);
            return result > 0;
        }

        // Xóa công việc
        public bool DeleteJobOfEmployee(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_XoaCongViec_NhanVien", parameters);
            return result > 0;
        }

        //Lấy tên tệp đính kèm theo mã công việc
        public DataTable GetNameOfFile(string maCongViec)
        {
            string query = $"SELECT * FROM CongViec_PDF WHERE maCongViec = '{maCongViec}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //Lấy tệp đính kèm theo tên của nó
        public DataTable GetFileOfJob(string tenFile)
        {
            string query = $"SELECT * FROM CongViec_PDF WHERE tenFile = '{tenFile}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // Lấy công việc theo mã
        public DataTable GetJobFromJobID(string maCV)
        {
            string query = $"SELECT * FROM CongViec Where maCongViec = '{maCV}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //Lấy tất cả công việc của nhân viên phân quyền
        public DataTable GetJobOfEmployees(int quyen)
        {
            string query = $"EXEC [dbo].[Job_Of_Employees] @quyen ='{quyen}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //Lấy tất cả công việc của nhóm phân quyền
        public DataTable GetJobOfGroups(int quyen)
        {
            string query = $"EXEC [dbo].[Job_Of_Groups] @quyen ='{quyen}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        //Lấy tất cả công việc của phòng ban phân quyền
        public DataTable GetJobOfDivisions(int quyen)
        {
            string query = $"EXEC [dbo].[Job_Of_Divisions] @quyen ='{quyen}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable StatisticAllJob(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);

            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("SP_ThongKeCongViecCongTy", parameters);

            return result;
        }
        public DataTable StatisticDivisionJob(DateTime tuNgay, DateTime denNgay, string maPhongBan)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            parameters.Add("@maBoPhan", maPhongBan);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("SP_ThongKeCongViecPhongBan", parameters);
            return result;
        }
        public DataTable StatisticEmployeeJob(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            parameters.Add("@maNhanVien", maNhanVien);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("SP_ThongKeCongViecNhanVien", parameters);
            return result;
        }
        public DataTable GetJobByApartmentId(string maCanHo)
        {
            string query = $"exec SP_LayDichVuTheoMaCanHo @maCanHo = '{maCanHo}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //Lấy công việc Phòng ban theo mã phòng ban
        public DataTable GetJobPbId(string maPhongBan)
        {
            string query = $"SELECT * FROM Congviec_PhongBan WHERE maBoPhan = '{maPhongBan}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //Lấy công việc nhóm theo mã nhóm
        public DataTable GetJobGroupId(string maNhom)
        {
            string query = $"SELECT * FROM Congviec_Nhom WHERE maNhom = '{maNhom}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Xếp hạng nhân viên theo doanh thu
        public DataTable GetRatingOfEmployeeByRevenue()
        {
            string query = "EXEC XepHangDoanhThuTheoNV";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Xếp hạng nhân viên theo tỉ lệ hoàn thành công việc
        public DataTable GetRatingOfEmployeeByFinishRate()
        {
            string query = "EXEC XepHangTiLeHoanThanhCVTheoNhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Xếp hạng nhân viên theo số công việc đã thực hiện trong khoảng thời gian cho trước
        public DataTable GetRatingOfEmployeeByNumOfFinishedJob(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("XepHangNhanVienTheoSoCongViecDaHoanThanh", parameters);
            return result;
        }
        // Xếp hạng Phòng ban (Bộ phận) theo doanh thu
        public DataTable GetRatingOfDivisionByRevenue()
        {
            string query = "EXEC XepHangDoanhThuTheoPhongBan";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Xếp hạng Phòng ban (Bộ phận) theo tỉ lệ hoành thành công việc
        public DataTable GetRatingOfDivisionByFinishRate()
        {
            string query = "EXEC XepHangTheoTiLeHoanThanhCongViecTheoPhongBan";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // Xếp hạng phòng ban (Bộ phận) theo số công việc ĐÃ thực hiện trong khoảng thời gian cho trước
        public DataTable GetRatingOfDivisionByNumOfFinishedJob(DateTime tuNgay, DateTime denNgay)
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@tuNgay", tuNgay);
            parameters.Add("@denNgay", denNgay);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("XepHangPhongBanTheoSoCongViecDaHoanThanh", parameters);
            return result;
        }
        public DataTable GetAllJobsState()
        {
            string query = "EXEC CountAllJobsState";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetJobsStateOfEmployee(string maNhanVien) 
        {
            // Tạo dictionary chứa các tham số cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@maNhanVien", maNhanVien);
            // Gọi stored procedure và nhận kết quả vào một DataTable
            DataTable result = DataProvider.Instance.ExecuteStoredProcedureWithTableReturn("CountJobsStateOfEmployees", parameters);
            return result;
        }
    }
}
