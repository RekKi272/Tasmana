using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;
        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set { instance = value; }
        }
        private EmployeeDAO() { }

        public bool AddEmployee(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedureWithNullValue("SP_ThemNhanVien", parameters);
            return result > 0;
        }
        public DataTable GetAllEmployee()
        {
            string query = "select * from NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetEmployeeByEmployeeId(string maNhanVien)
        {
            string query = $"select * from NhanVien where maNhanVien = '{maNhanVien}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetGroupByEmployeeId(string maNhanVien)
        {
            string query = "exec SP_LayNhomTheoMaNhanVien @maNhanVien";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maNhanVien });
        }

        public bool UpdateEmployee(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("SP_CapNhatNhanVien", parameters);
            return result > 0;
        }
        public DataTable GetEmployeeByGroup(string maNhom) 
        {
            string query = $"select * from NhanVien where maNhom = '{maNhom}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetEmployeeByDivision(string maBoPhan)
        {
            string query = $"Select * from NhanVien Where maBoPhan = '{maBoPhan}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetEmployees()
        {
            string query = $"EXEC [dbo].[Count_Job_State]";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        // cập nhật lại nhóm của nhân viên là nhóm trưởng
        public bool EditEmployeeGroup(Dictionary<string, object> parameters)
        {
            int result = DataProvider.Instance.ExecuteStoredProcedure("EditEmployeeGroup", parameters);
            return result > 0;
        }
        public bool AddCEO(string maNhanVien)
        {
            string query = $"insert into CEO values('{maNhanVien}')";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        // Thêm Quản lý
        public bool AddManager(Dictionary<string, object> parameters)
        {
            return DataProvider.Instance.ExecuteStoredProcedure("AddManager", parameters) > 0;
        }
        public DataTable GetManager()
        {
            string query = $"SELECT * FROM QuanLy";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
