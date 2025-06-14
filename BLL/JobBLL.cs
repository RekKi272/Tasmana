using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class JobBLL
    {
        private static JobBLL instance;

        public static JobBLL Instance
        {
            get { if (instance == null) instance = new JobBLL(); return instance; }
            private set { instance = value; }
        }
        private JobBLL() { }
        public bool AddJob(Dictionary<string, object> parameters)
        {
            if(JobDAO.Instance.AddJob(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetNewJobID()
        {
            string newJobID = JobDAO.Instance.GetNewJobID();
            return newJobID;
        }
        public bool AddJob_Employee(Dictionary<string, object> parameters)
        {
            if(JobDAO.Instance.AddJob_Employee(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddJob_Group(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.AddJob_Group(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddJob_PDF(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.AddJob_PDF(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddJob_Division(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.AddJob_Division(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddRequestFromCustom(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.AddRequestFromCustom(parameters))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Lấy danh sách công việc nhân viên theo ngày thời hạn hoàn thành công việc
        public List<Job> GetJobOfEmployeeByDate(string maNV, string thoiHan)
        {
            List<Job> jobs = new List<Job>();
            DataTable dt = JobDAO.Instance.GetJobOfEmployeeByDate(maNV, thoiHan);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maCongViec = dt.Rows[i]["maCongViec"].ToString();
                string noiDung = dt.Rows[i]["noiDung"].ToString();
                DateTime ngayGiao = (DateTime)dt.Rows[i]["ngayGiao"];
                DateTime thoihan = dt.Rows[i]["thoiHan"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["thoiHan"];
                DateTime ngayHoanThanh = dt.Rows[i]["ngayHoanThanh"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayHoanThanh"];
                DateTime ngayCapNhat = dt.Rows[i]["ngayCapNhat"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayCapNhat"];
                string trangThai = dt.Rows[i]["trangThai"].ToString();
                string ghiChu = dt.Rows[i]["ghiChu"].ToString();
                int quyenTruyCap = (int)dt.Rows[i]["quyenTruyCap"];
                Job job = new Job(maCongViec, noiDung, ngayGiao, thoihan, ngayHoanThanh, ngayCapNhat, trangThai, ghiChu, quyenTruyCap);
                jobs.Add(job);
            }
            return jobs;
        }
        // Lấy toàn bộ danh sách công việc của một nhân viên
        public List<Job> GetAllJobOfEmployee(string maNV)
        {
            List<Job> jobs = new List<Job>();
            DataTable dt = JobDAO.Instance.GetAllJobOfEmployee(maNV);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maCongViec = dt.Rows[i]["maCongViec"].ToString();
                string noiDung = dt.Rows[i]["noiDung"].ToString();
                DateTime ngayGiao = (DateTime)dt.Rows[i]["ngayGiao"];
                DateTime thoihan = dt.Rows[i]["thoiHan"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["thoiHan"];
                DateTime ngayHoanThanh = dt.Rows[i]["ngayHoanThanh"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayHoanThanh"];
                DateTime ngayCapNhat = dt.Rows[i]["ngayCapNhat"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayCapNhat"];
                string trangThai = dt.Rows[i]["trangThai"].ToString();
                string ghiChu = dt.Rows[i]["ghiChu"].ToString();
                int quyenTruyCap = (int)dt.Rows[i]["quyenTruyCap"];
                Job job = new Job(maCongViec, noiDung, ngayGiao, thoihan, ngayHoanThanh, ngayCapNhat, trangThai, ghiChu, quyenTruyCap);
                jobs.Add(job);
            }
            return jobs;
        }
        // Lấy toàn bộ tất cả công việc
        public List<Job> GetAllJob()
        {
            List <Job> jobs = new List<Job>();
            DataTable dt = JobDAO.Instance.GetAllJob();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maCongViec = dt.Rows[i]["maCongViec"].ToString();
                string noiDung = dt.Rows[i]["noiDung"].ToString();
                DateTime ngayGiao = (DateTime)dt.Rows[i]["ngayGiao"];
                DateTime thoihan = dt.Rows[i]["thoiHan"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["thoiHan"];
                DateTime ngayHoanThanh = dt.Rows[i]["ngayHoanThanh"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayHoanThanh"];
                DateTime ngayCapNhat = dt.Rows[i]["ngayCapNhat"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayCapNhat"];
                string trangThai = dt.Rows[i]["trangThai"].ToString();
                string ghiChu = dt.Rows[i]["ghiChu"].ToString();
                int quyenTruyCap = (int)dt.Rows[i]["quyenTruyCap"];
                Job job = new Job(maCongViec, noiDung, ngayGiao, thoihan, ngayHoanThanh, ngayCapNhat, trangThai, ghiChu, quyenTruyCap);
                jobs.Add(job);
            }
            return jobs;
        }

        // lấy công việc theo mã công việc
        public Job GetJobFromJobID(string maCV)
        {
            DataTable dt = JobDAO.Instance.GetJobFromJobID(maCV);
            int i = 0;
            string maCongViec = dt.Rows[i]["maCongViec"].ToString();
            string noiDung = dt.Rows[i]["noiDung"].ToString();
            DateTime ngayGiao = (DateTime)dt.Rows[i]["ngayGiao"];
            DateTime thoihan = dt.Rows[i]["thoiHan"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["thoiHan"];
            DateTime ngayHoanThanh = dt.Rows[i]["ngayHoanThanh"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayHoanThanh"];
            DateTime ngayCapNhat = dt.Rows[i]["ngayCapNhat"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[i]["ngayCapNhat"];
            string trangThai = dt.Rows[i]["trangThai"].ToString();
            string ghiChu = dt.Rows[i]["ghiChu"].ToString();
            int quyenTruyCap = (int)dt.Rows[i]["quyenTruyCap"];
            int phiDichVu = (int)dt.Rows[i]["phiDichVu"];
            Job job = new Job(maCongViec, noiDung, ngayGiao, thoihan, ngayHoanThanh, ngayCapNhat, trangThai, ghiChu, quyenTruyCap, phiDichVu);
            return job;
        }

        // Chỉnh sửa công việc
        public bool EditJobOfEmployee(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.EditJobOfEmployee(parameters))
            {
                return true;
            }

            return false;
        }

        // Xóa công việc của nhân viên theo mã công việc
        public bool DeleteJobOfEmployee(Dictionary<string, object> parameters)
        {
            if (JobDAO.Instance.DeleteJobOfEmployee(parameters))
            {
                return true;
            }
            return false;
        }
        // Lấy tên file bằng mã công việc
        public string GetNameFile(string maCongViec)
        {
            string tenFile = null;
            DataTable dt = JobDAO.Instance.GetNameOfFile(maCongViec);
            if (dt.Rows.Count > 0)
            {
               tenFile = dt.Rows[0]["tenFile"].ToString();
            }
            return tenFile;
        }
        // Lấy file pdf bằng mã công việc
        public byte[] GetFileOfJob(string maCongViec)
        {
            byte[] bytes = null;
            DataTable dt = JobDAO.Instance.GetFileOfJob(maCongViec);
            if (dt.Rows.Count > 0)
            {
                bytes = (byte[])dt.Rows[0]["pdfFile"];
            }
            return bytes;
        }
        // Thống kê công việc của toàn công ty
        public DataTable StatisticAllJob(DateTime tuNgay, DateTime denNgay)
        {
            return JobDAO.Instance.StatisticAllJob(tuNgay, denNgay);
        }
        // Thống kê công việc của bộ phận
        public DataTable StatisticDivisionJob(DateTime tuNgay, DateTime denNgay, string maPhongBan)
        {
            return JobDAO.Instance.StatisticDivisionJob(tuNgay, denNgay, maPhongBan);
        }
        // Thống kê công việc của nhân viên
        public DataTable StatisticEmployeeJob(DateTime tuNgay, DateTime denNgay, string maNhanVien)
        {
            return JobDAO.Instance.StatisticEmployeeJob(tuNgay, denNgay , maNhanVien);
        }

        //Lấy công việc phân quyền
        public DataTable GetJobOfEmployeesPQ(int quyen,Employee e, String level)
        {
            DataTable jobs = JobDAO.Instance.GetJobOfEmployees(quyen);
            // kiểm tra có phải là quản lý hay không
            DataTable listQuanLy = EmployeeBLL.Instance.GetManager();
            bool isManager = false;

            foreach (DataRow row in listQuanLy.Rows)
            {
                if (row["maNhanVien"].ToString().Equals(e.MaNhanVien))
                {
                    isManager = true;
                    break;
                }
            }

            DataTable GetJob0()
            {
                DataTable jobs0 = new DataTable();
                DataTable j = JobDAO.Instance.GetJobOfEmployees(0);

                // Create columns in the DataTable based on the columns in 'j' DataTable
                foreach (DataColumn column in j.Columns)
                {
                    jobs0.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                }

                // Iterate through each row in 'j' DataTable and copy rows for the specified employee to 'jobs0' DataTable
                foreach (DataRow jRow in j.Rows)
                {
                    if (jRow["Mã nhân viên"].ToString().Equals(e.MaNhanVien))
                    {
                        DataRow newRow = jobs0.NewRow();
                        foreach (DataColumn column in j.Columns)
                        {
                            newRow[column.ColumnName] = jRow[column.ColumnName];
                        }
                        jobs0.Rows.Add(newRow);
                    }
                }
                return jobs0;
            }
            DataTable GetJob1()
            {
                DataTable jobs1 = new DataTable();
                DataTable j = JobDAO.Instance.GetJobOfEmployees(1);

                // Create columns in the DataTable based on the columns in 'j' DataTable
                foreach (DataColumn column in j.Columns)
                {
                    jobs1.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                }

                // Iterate through each row in 'j' DataTable and copy rows for the specified department to 'jobs1' DataTable
                foreach (DataRow jRow in j.Rows)
                {
                    if (jRow["Mã Bộ phận"].ToString() == e.MaBoPhan)
                    {
                        jobs1.ImportRow(jRow);
                    }
                }

                return jobs1;
            }

            DataTable GetJob2()
            {
                DataTable j = JobDAO.Instance.GetJobOfEmployees(2);
                return j;
            }
            if (level != "CEO")
            {
                if (quyen == 0)
                {
                    if (isManager)
                    {
                        DataTable job = new DataTable();

                        foreach (DataColumn column in jobs.Columns)
                        {
                            job.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                        }

                        foreach (DataRow jRow in jobs.Rows)
                        {
                            if (jRow["Mã Bộ phận"].ToString().Equals(e.MaBoPhan))
                            {
                                DataRow newRow = job.NewRow();
                                foreach (DataColumn column in jobs.Columns)
                                {
                                    newRow[column.ColumnName] = jRow[column.ColumnName];
                                }
                                job.Rows.Add(newRow);
                            }
                        }
                        return job;
                    }
                    else
                        return GetJob0();
                }
                else if(quyen == 1)
                {
                        return GetJob1();
                }
                else if(quyen == 2)
                    return GetJob2();
                else 
                {
                    DataTable rs = GetJob0();
                    rs.Merge(GetJob1());
                    rs.Merge(GetJob2());
                    return rs;
                }
            }
            return jobs;
        }
        public DataTable GetJobOfGroupsPQ(int quyen, Employee e, String level)
        {
            DataTable jobs = JobDAO.Instance.GetJobOfGroups(quyen);
            // kiểm tra có phải là quản lý hay không
            DataTable listQuanLy = EmployeeBLL.Instance.GetManager();
            bool isManager = false;

            foreach (DataRow row in listQuanLy.Rows)
            {
                if (row["maNhanVien"].ToString().Equals(e.MaNhanVien))
                {
                    isManager = true;
                    break;
                }
            }

            DataTable GetJob0()
            {
                DataTable jobs0 = new DataTable();
                DataTable j = JobDAO.Instance.GetJobOfGroups(0);

                // Create columns in the DataTable based on the columns in 'j' DataTable
                foreach (DataColumn column in j.Columns)
                {
                    jobs0.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                }

                // Iterate through each row in 'j' DataTable and copy rows for the specified group to 'jobs0' DataTable
                foreach (DataRow jRow in j.Rows)
                {
                    if (jRow["Mã nhóm"].ToString() == e.MaNhom)
                    {
                        jobs0.ImportRow(jRow);
                    }
                }

                return jobs0;
            }

            DataTable GetJob1()
            {
                DataTable jobs1 = new DataTable();
                DataTable j = JobDAO.Instance.GetJobOfGroups(1);

                // Create columns in the DataTable based on the columns in 'j' DataTable
                foreach (DataColumn column in j.Columns)
                {
                    jobs1.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                }

                // Iterate through each row in 'j' DataTable and copy rows for the specified department to 'jobs1' DataTable
                foreach (DataRow jRow in j.Rows)
                {
                    if (jRow["Mã Bộ phận"].ToString() == e.MaBoPhan)
                    {
                        jobs1.ImportRow(jRow);
                    }
                }

                return jobs1;
            }

            DataTable GetJob2()
            {
                DataTable j = JobDAO.Instance.GetJobOfGroups(2);
                return j;
            }
            if (level != "CEO")
            {
                if (quyen == 0)
                {
                    if (isManager)
                    {
                        DataTable job = new DataTable();

                        foreach (DataColumn column in jobs.Columns)
                        {
                            job.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                        }

                        foreach (DataRow jRow in jobs.Rows)
                        {
                            if (jRow["Mã Bộ phận"].ToString().Equals(e.MaBoPhan))
                            {
                                DataRow newRow = job.NewRow();
                                foreach (DataColumn column in jobs.Columns)
                                {
                                    newRow[column.ColumnName] = jRow[column.ColumnName];
                                }
                                job.Rows.Add(newRow);
                            }
                        }
                        return job;
                    }
                    else
                        return GetJob0();
                }
                else if (quyen == 1)
                {
                    return GetJob1();
                }
                else if (quyen == 2)
                    return GetJob2();
                else
                {
                    DataTable rs = GetJob0();
                    rs.Merge(GetJob1());
                    rs.Merge(GetJob2());
                    return rs;
                }
            }
            return jobs;
        }
        public DataTable GetJobOfDivisionsPQ(int quyen, Employee e, String level)
        {
            if(quyen == 0)
                quyen = 1;
            DataTable jobs = JobDAO.Instance.GetJobOfDivisions(quyen);
            DataTable GetJob1()
            {
                DataTable jobs1 = new DataTable();
                DataTable j = JobDAO.Instance.GetJobOfGroups(1);

                // Create columns in the DataTable based on the columns in 'j' DataTable
                foreach (DataColumn column in j.Columns)
                {
                    jobs1.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                }

                // Iterate through each row in 'j' DataTable and copy rows for the specified department to 'jobs1' DataTable
                foreach (DataRow jRow in j.Rows)
                {
                    if (jRow["Mã Bộ phận"].ToString() == e.MaBoPhan)
                    {
                        jobs1.ImportRow(jRow);
                    }
                }

                return jobs1;
            }

            DataTable GetJob2()
            {
                DataTable j = JobDAO.Instance.GetJobOfGroups(2);
                return j;
            }
            if (level != "CEO")
            {
                 if (quyen == 1)
                {
                    return GetJob1();
                }
                else if (quyen == 2)
                    return GetJob2();
                else
                {
                    DataTable rs = GetJob1();
                    rs.Merge(GetJob2());
                    return rs;
                }
            }
            return jobs;
        }
        public List<Job> GetJobPbId(string maPhongBan)
        {
            List<Job> jobs = new List<Job>();
            DataTable dt = JobDAO.Instance.GetJobPbId(maPhongBan);
            for(int i = 0;i < dt.Rows.Count; i++)
            {
                Job j = GetJobFromJobID(dt.Rows[i]["maCongViec"].ToString());
                jobs.Add(j);
            }
            return jobs;
        }

        public List<Job> GetJobGroupId(string maNhom)
        {
            List<Job> jobs = new List<Job>();
            DataTable dt = JobDAO.Instance.GetJobGroupId(maNhom);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Job j = GetJobFromJobID(dt.Rows[i]["maCongViec"].ToString());
                jobs.Add(j);
            }
            return jobs;
        }

        // Xếp hạng nhân viên theo doanh thu
        public DataTable GetRatingOfEmployeeByRevenue()
        {
            DataTable dt = new DataTable();
            dt = JobDAO.Instance.GetRatingOfEmployeeByRevenue();
            return dt;
        }
        // Xếp hạng nhân viên theo tỉ lệ hoàn thành công việc
        public DataTable GetRatingOfEmployeeByFinishRate()
        {
            DataTable dt = new DataTable();
            dt = JobDAO.Instance.GetRatingOfEmployeeByFinishRate();
            return dt;
        }
        // Xếp hạng nhân viên theo số công việc đã thực hiện trong khoảng thời gian cho trước
        public DataTable GetRatingOfEmployeeByNumOfFinishedJob(DateTime tuNgay, DateTime denNgay)
        {
            return JobDAO.Instance.GetRatingOfEmployeeByNumOfFinishedJob(tuNgay, denNgay);
        }
        // Xếp hạng Phòng ban (Bộ phận) theo doanh thu
        public DataTable GetRatingOfDivisionByRevenue()
        {
            return JobDAO.Instance.GetRatingOfDivisionByRevenue();
        }
        // Xếp hạng Phòng ban (Bộ phận) theo tỉ lệ hoành thành công việc
        public DataTable GetRatingofDivisionByFinishRate()
        {
            return JobDAO.Instance.GetRatingOfDivisionByFinishRate();
        }
        // Xếp hạng phòng ban (Bộ phận) theo số công việc ĐÃ thực hiện trong khoảng thời gian cho trước
        public DataTable GetRatingOfDivisionByNumOfFinishedJob(DateTime tuNgay, DateTime denNgay)
        {
            return JobDAO.Instance.GetRatingOfDivisionByNumOfFinishedJob(tuNgay, denNgay);
        }
        // Đếm tổng tình trạng công việc hiện tại của công ty
        public DataTable GetAllJobsState()
        {
            return JobDAO.Instance.GetAllJobsState();
        }
        public DataTable GetJobsStateOfEmployee(string maNhanVien)
        {
            return JobDAO.Instance.GetJobsStateOfEmployee(maNhanVien);
        }
    }
}
