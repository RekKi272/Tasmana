using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VehicleBLL
    {
        private static VehicleBLL instance;
        public static VehicleBLL Instance
        {
            get { if (instance == null) instance = new VehicleBLL(); return instance; }
            private set { instance = value; }
        }
        private VehicleBLL() { }
        public Vehicle GetVehicleByBienSo(string bienSo)
        {
            DataTable dt = VehicleDAO.Instance.GetVehicleByBienSo(bienSo);
            if (dt.Rows.Count > 0 )
            {
                return new Vehicle(bienSo, dt.Rows[0]["chungLoai"].ToString(), dt.Rows[0]["tinhTrangSoHuu"].ToString());
            }
            return null;
        }
        public string AddVehicle(Dictionary<string, object> parameters)
        {
            if (VehicleDAO.Instance.AddVehicle(parameters))
            {
                return "Thêm thành công";
            }
            return "Thêm thất bại";
        }
        public string UpdateVehicle(Dictionary<string, object> parameters)
        {
            if (VehicleDAO.Instance.UpdateVehicle(parameters))
            {
                return "Sửa thành công";
            }
            return "Sửa thất bại";
        }
    }
}
