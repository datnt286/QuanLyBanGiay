using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        private static LoaiSanPhamDAL instance;

        public static LoaiSanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamDAL();
                }
                return instance;
            }
        }

        private LoaiSanPhamDAL() { }

        public List<LoaiSanPhamDTO> LayDanhSachLoaiSanPham()
        {
            List<LoaiSanPhamDTO> dsLoaiSP = new List<LoaiSanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM LoaiSanPham";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LoaiSanPhamDTO loaiSP = new LoaiSanPhamDTO();
                    loaiSP.MaLoaiSP = reader.GetInt32(0);
                    loaiSP.TenLoaiSP = reader.GetString(1);
                    loaiSP.TrangThai = reader.GetInt32(2);
                    dsLoaiSP.Add(loaiSP);
                }
                reader.Close();
            }
            return dsLoaiSP;
        }

        public LoaiSanPhamDTO LayThongTinLoaiSanPham(int maLoaiSP)
        {
            LoaiSanPhamDTO loaiSP = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM LoaiSanPham WHERE MaLoaiSP=@MaLoaiSP";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    loaiSP = new LoaiSanPhamDTO();
                    loaiSP.MaLoaiSP = reader.GetInt32(0);
                    loaiSP.TenLoaiSP = reader.GetString(1);
                    loaiSP.TrangThai = reader.GetInt32(2);
                }
                reader.Close();
            }
            return loaiSP;
        }
    }
}
