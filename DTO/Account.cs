using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string EmployeeId { get; set; }
        public string Level { get; set; } // Phân quyền
        public bool IsDisabled { get; set; }
        public bool RememberUserId { get; set; }

        public Account(string userId, string password, string employeeId)
        {
            UserId = userId;
            Password = password;
            EmployeeId = employeeId;
        }

        public Account(string userId, string password, string employeeId, bool isDisabled)
        {
            UserId = userId;
            Password = password;
            EmployeeId = employeeId;
            Level = PhanQuyen(UserId);
            IsDisabled = isDisabled;
        }
        public Account(string userId, string password, string employeeId, bool isDisabled, bool rememberId)
        {
            UserId = userId;
            Password = password;
            EmployeeId = employeeId;
            Level = PhanQuyen(UserId);
            IsDisabled = isDisabled;
            RememberUserId = rememberId;
        }
        private string PhanQuyen(string userID)
        {
            string level = "";
            string[] temp = userID.Split('.');
            if (!string.IsNullOrEmpty(temp[0]))
            {
                string loaiNV = temp[0].Substring(0, 2);
                switch (loaiNV)
                {
                    case "GD":
                        level = "CEO";
                        break;
                    case "DV":
                        level = "DV";
                        break;
                    case "TC":
                        level = "TC";
                        break;
                    case "VS":
                        level = "VS";
                        break;
                    case "AN":
                        level = "AN";
                        break;
                    case "KT":
                        level = "KT";
                        break;
                    case "XD":
                        level = "XD";
                        break;
                    default:
                        break;
                }
            }
            return level;
        }
    }
}
