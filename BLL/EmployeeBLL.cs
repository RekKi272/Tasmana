using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BLL
{
    public class EmployeeBLL
    {
        private static EmployeeBLL instance;
        public static EmployeeBLL Instance
        {
            get { if (instance == null) instance = new EmployeeBLL(); return instance; }
            private set { instance = value; }
        }
        private EmployeeBLL() { }
        public string AddEmployee(Dictionary<string, object> parameters)
        {
            if (EmployeeDAO.Instance.AddEmployee(parameters))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public List<Employee> GetEmployeeList()
        {
            DataTable dt = EmployeeDAO.Instance.GetAllEmployee();

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maNhanVien = dt.Rows[i]["maNhanVien"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string ho = dt.Rows[i]["ho"].ToString();
                string ten = dt.Rows[i]["ten"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[i]["ngaySinh"];
                bool gioiTinh = (bool)dt.Rows[i]["gioiTinh"];
                string queQuan = dt.Rows[i]["queQuan"].ToString();
                string maDinhDanh = dt.Rows[i]["maDinhDanh"].ToString();
                string loaiNhanVien = dt.Rows[i]["loaiNhanVien"].ToString();
                string tinhTrangHonNhan = dt.Rows[i]["tinhTrangHonNhan"].ToString();
                string maSoBHXH = dt.Rows[i]["maSoBHXH"].ToString();
                bool daTungLamNV = (bool)dt.Rows[i]["daTungLamNV"];
                DateTime ngayKyHDLD = (DateTime)dt.Rows[i]["ngayKyHDLD"];
                DateTime ngayHetHDLD = (DateTime)dt.Rows[i]["ngayHetHDLD"];
                string diaChiThuongTru = dt.Rows[i]["dChiThuongTru"].ToString();
                string diaChiaTamTru = dt.Rows[i]["dChiTamTru"].ToString();
                string tinhTrangHDLD = dt.Rows[i]["tinhTrangHDLD"].ToString();
                string maBoPhan = dt.Rows[i]["maBoPhan"].ToString();
                string maNhom = dt.Rows[i]["maNhom"].ToString();

                DataTable dt1 = AccountDAO.Instance.GetAccountByEmployeeId(maNhanVien);
                string maNguoiDung = dt1.Rows[0]["maNguoiDung"].ToString();
                string matKhau = dt1.Rows[0]["matKhau"].ToString();
                bool disable = (bool)dt1.Rows[0]["disable"];
                Account account = new Account(maNguoiDung, matKhau, maNhanVien, disable);
                Employee employee = new Employee(maNhanVien, email, ho, ten, soDienThoai, ngaySinh, gioiTinh, queQuan, maDinhDanh,
                                                 loaiNhanVien, tinhTrangHonNhan, maSoBHXH, daTungLamNV, ngayKyHDLD, ngayHetHDLD,
                                                 diaChiThuongTru, diaChiaTamTru, tinhTrangHDLD, maBoPhan, maNhom, account);
                employees.Add(employee);
            }
            return employees;
        }
        public Employee GetEmployeeByEmployeeId(string maNhanVien)
        {
            DataTable dt = EmployeeDAO.Instance.GetEmployeeByEmployeeId(maNhanVien);
            if (dt.Rows.Count > 0)
            {
                string email = dt.Rows[0]["email"].ToString();
                string ho = dt.Rows[0]["ho"].ToString();
                string ten = dt.Rows[0]["ten"].ToString();
                string soDienThoai = dt.Rows[0]["SDT"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[0]["ngaySinh"];
                bool gioiTinh = (bool)dt.Rows[0]["gioiTinh"];
                string queQuan = dt.Rows[0]["queQuan"].ToString();
                string maDinhDanh = dt.Rows[0]["maDinhDanh"].ToString();
                string loaiNhanVien = dt.Rows[0]["loaiNhanVien"].ToString();
                string tinhTrangHonNhan = dt.Rows[0]["tinhTrangHonNhan"].ToString();
                string maSoBHXH = dt.Rows[0]["maSoBHXH"].ToString();
                bool daTungLamNV = (bool)dt.Rows[0]["daTungLamNV"];
                DateTime ngayKyHDLD = (DateTime)dt.Rows[0]["ngayKyHDLD"];
                DateTime ngayHetHDLD = (DateTime)dt.Rows[0]["ngayHetHDLD"];
                string diaChiThuongTru = dt.Rows[0]["dChiThuongTru"].ToString();
                string diaChiaTamTru = dt.Rows[0]["dChiTamTru"].ToString();
                string tinhTrangHDLD = dt.Rows[0]["tinhTrangHDLD"].ToString();
                string maBoPhan = dt.Rows[0]["maBoPhan"].ToString();
                string maNhom = dt.Rows[0]["maNhom"].ToString();

                DataTable dt1 = AccountDAO.Instance.GetAccountByEmployeeId(maNhanVien);
                string maNguoiDung = dt1.Rows[0]["maNguoiDung"].ToString();
                string matKhau = dt1.Rows[0]["matKhau"].ToString();
                bool disable = (bool)dt1.Rows[0]["disable"];
                Account account = new Account(maNguoiDung, matKhau, maNhanVien, disable);
                Employee employee = new Employee(maNhanVien, email, ho, ten, soDienThoai, ngaySinh, gioiTinh, queQuan, maDinhDanh,
                                                    loaiNhanVien, tinhTrangHonNhan, maSoBHXH, daTungLamNV, ngayKyHDLD, ngayHetHDLD,
                                                    diaChiThuongTru, diaChiaTamTru, tinhTrangHDLD, maBoPhan, maNhom, account);
                return employee;
            }
            return null;
        }
        public Group GetGroupByEmployeeId(string maNhanVien)
        {
            DataTable dt = EmployeeDAO.Instance.GetGroupByEmployeeId(maNhanVien);

            // Check if the DataTable is not empty
            if (dt != null && dt.Rows.Count > 0)
            {
                string maNhom = dt.Rows[0]["maNhom"].ToString();
                string maTruongNhom = dt.Rows[0]["maTruongNhom"].ToString();
                string maBoPhan = dt.Rows[0]["maBoPhan"].ToString();
                Group group = new Group(maNhom, maTruongNhom, maBoPhan);
                return group;
            }
            else
            {
                // Return null when no records are found
                return null;
            }
        }
        public string UpdateEmployee(Dictionary<string, object> parameters)
        {
            if (EmployeeDAO.Instance.UpdateEmployee(parameters))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public List<Employee> GetEmployeesByGroup(string maNhom)
        {
            DataTable dt = EmployeeDAO.Instance.GetEmployeeByGroup(maNhom);

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maNhanVien = dt.Rows[i]["maNhanVien"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string ho = dt.Rows[i]["ho"].ToString();
                string ten = dt.Rows[i]["ten"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[i]["ngaySinh"];
                bool gioiTinh = (bool)dt.Rows[i]["gioiTinh"];
                string queQuan = dt.Rows[i]["queQuan"].ToString();
                string maDinhDanh = dt.Rows[i]["maDinhDanh"].ToString();
                string loaiNhanVien = dt.Rows[i]["loaiNhanVien"].ToString();
                string tinhTrangHonNhan = dt.Rows[i]["tinhTrangHonNhan"].ToString();
                string maSoBHXH = dt.Rows[i]["maSoBHXH"].ToString();
                bool daTungLamNV = (bool)dt.Rows[i]["daTungLamNV"];
                DateTime ngayKyHDLD = (DateTime)dt.Rows[i]["ngayKyHDLD"];
                DateTime ngayHetHDLD = (DateTime)dt.Rows[i]["ngayHetHDLD"];
                string diaChiThuongTru = dt.Rows[i]["dChiThuongTru"].ToString();
                string diaChiaTamTru = dt.Rows[i]["dChiTamTru"].ToString();
                string tinhTrangHDLD = dt.Rows[i]["tinhTrangHDLD"].ToString();
                string maBoPhan = dt.Rows[i]["maBoPhan"].ToString();

                DataTable dt1 = AccountDAO.Instance.GetAccountByEmployeeId(maNhanVien);
                string maNguoiDung = dt1.Rows[0]["maNguoiDung"].ToString();
                string matKhau = dt1.Rows[0]["matKhau"].ToString();
                bool disable = (bool)dt1.Rows[0]["disable"];
                Account account = new Account(maNguoiDung, matKhau, maNhanVien, disable);
                Employee employee = new Employee(maNhanVien, email, ho, ten, soDienThoai, ngaySinh, gioiTinh, queQuan, maDinhDanh,
                                                loaiNhanVien, tinhTrangHonNhan, maSoBHXH, daTungLamNV, ngayKyHDLD, ngayHetHDLD,
                                                diaChiThuongTru, diaChiaTamTru, tinhTrangHDLD, maBoPhan, maNhom, account);
                employees.Add(employee);
            }
            return employees;
        }
        public List<Employee> GetEmployeeByDivision(string maBoPhan)
        {
            DataTable dt = EmployeeDAO.Instance.GetEmployeeByDivision(maBoPhan);

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maNhanVien = dt.Rows[i]["maNhanVien"].ToString();
                string email = dt.Rows[i]["email"].ToString();
                string ho = dt.Rows[i]["ho"].ToString();
                string ten = dt.Rows[i]["ten"].ToString();
                string soDienThoai = dt.Rows[i]["SDT"].ToString();
                DateTime ngaySinh = (DateTime)dt.Rows[i]["ngaySinh"];
                bool gioiTinh = (bool)dt.Rows[i]["gioiTinh"];
                string queQuan = dt.Rows[i]["queQuan"].ToString();
                string maDinhDanh = dt.Rows[i]["maDinhDanh"].ToString();
                string loaiNhanVien = dt.Rows[i]["loaiNhanVien"].ToString();
                string tinhTrangHonNhan = dt.Rows[i]["tinhTrangHonNhan"].ToString();
                string maSoBHXH = dt.Rows[i]["maSoBHXH"].ToString();
                bool daTungLamNV = (bool)dt.Rows[i]["daTungLamNV"];
                DateTime ngayKyHDLD = (DateTime)dt.Rows[i]["ngayKyHDLD"];
                DateTime ngayHetHDLD = (DateTime)dt.Rows[i]["ngayHetHDLD"];
                string diaChiThuongTru = dt.Rows[i]["dChiThuongTru"].ToString();
                string diaChiaTamTru = dt.Rows[i]["dChiTamTru"].ToString();
                string tinhTrangHDLD = dt.Rows[i]["tinhTrangHDLD"].ToString();
                string maNhom = dt.Rows[i]["maNhom"].ToString();
                Employee employee = new Employee(maNhanVien, email, ho, ten, soDienThoai, ngaySinh, gioiTinh, queQuan, maDinhDanh,
                                                loaiNhanVien, tinhTrangHonNhan, maSoBHXH, daTungLamNV, ngayKyHDLD, ngayHetHDLD,
                                                diaChiThuongTru, diaChiaTamTru, tinhTrangHDLD, maBoPhan, maNhom);
                employees.Add(employee);
            }
            return employees;
        }

        public DataTable GetEmployees()
        {
            DataTable employees = EmployeeDAO.Instance.GetEmployees();
            for (int i = 0; i < employees.Rows.Count; i++)
            {
                if ((int)employees.Rows[i]["congViecPhongBan"] > 0)
                {
                    List<Job> jobs = JobBLL.Instance.GetJobPbId(employees.Rows[i]["maBoPhan"].ToString());
                    if ( jobs.Count > 0)
                    {
                        foreach (Job job in jobs)
                        {
                            if (job.TrangThai.Equals("Hoàn thành"))
                            {
                                int value = (int)employees.Rows[i]["hoanThanh"];
                                employees.Rows[i].SetField("hoanThanh", value + 1);
                            }
                            else if (job.TrangThai.Equals("Đang thực hiện"))
                            {
                                int value = (int)employees.Rows[i]["dangThucHien"];
                                employees.Rows[i].SetField("dangThucHien", value + 1);
                            }
                            else if (job.TrangThai.Equals("Chưa bắt đầu"))
                            {
                                int value = (int)employees.Rows[i]["chuaBatDau"];
                                employees.Rows[i].SetField("chuaBatDau", value + 1);
                            }
                            else
                            {
                                int value = (int)employees.Rows[i]["treHan"];
                                employees.Rows[i].SetField("treHan", value + 1);
                            }
                        }
                    }
                }
                if ((int)employees.Rows[i]["congViecNhom"] > 0)
                {
                    Employee emp = EmployeeBLL.Instance.GetEmployeeByEmployeeId(employees.Rows[i]["maNhanVien"].ToString());
                    List<Job> jobs = JobBLL.Instance.GetJobGroupId(emp.MaNhom);
                    if (jobs.Count > 0)
                    {
                        foreach (Job job in jobs)
                        {
                            if (job.TrangThai.Equals("Hoàn thành"))
                            {
                                int value = (int)employees.Rows[i]["hoanThanh"];
                                employees.Rows[i].SetField("hoanThanh", value + 1);
                            }
                            else if (job.TrangThai.Equals("Đang thực hiện"))
                            {
                                int value = (int)employees.Rows[i]["dangThucHien"];
                                employees.Rows[i].SetField("dangThucHien", value + 1);
                            }
                            else if (job.TrangThai.Equals("Chưa bắt đầu"))
                            {
                                int value = (int)employees.Rows[i]["chuaBatDau"];
                                employees.Rows[i].SetField("chuaBatDau", value + 1);
                            }
                            else
                            {
                                int value = (int)employees.Rows[i]["treHan"];
                                employees.Rows[i].SetField("treHan", value + 1);
                            }
                        }
                    }
                }
            }
            return employees;
        }
        // cập nhật lại nhóm của nhân viên là nhóm trưởng
        public bool EditEmployeeGroup(Dictionary<string, object> parameters)
        {
            return EmployeeDAO.Instance.EditEmployeeGroup(parameters);
        }
        public string AddCEO(string maNhanVien)
        {
            if (EmployeeDAO.Instance.AddCEO(maNhanVien))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }

        // Thêm Quản lý
        public bool AddManager(Dictionary<string, object> parameters)
        {
            return EmployeeDAO.Instance.AddManager(parameters);
        }

        // lấy quản lý
        public DataTable GetManager()
        {
            return EmployeeDAO.Instance.GetManager();
        }
    }
}
