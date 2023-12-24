using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiNhanVienDAL
    {
        private static LoaiNhanVienDAL instance;

        public static LoaiNhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiNhanVienDAL();
                }
                return instance;
            }
        }

        private LoaiNhanVienDAL() { }

        public List<LoaiNhanVienDTO> LayDanhSachLoaiNhanVien()
        {
            List<LoaiNhanVienDTO> dsLoaiNhanVien = new List<LoaiNhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM LoaiNhanVien";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LoaiNhanVienDTO loaiNV = new LoaiNhanVienDTO();
                    loaiNV.MaLoaiNV = reader.GetInt32(0);
                    loaiNV.TenLoaiNV = reader.GetString(1);
                    loaiNV.TrangThai = reader.GetInt32(2);
                    dsLoaiNhanVien.Add(loaiNV);
                }
                reader.Close();
            }
            return dsLoaiNhanVien;
        }

        public LoaiNhanVienDTO LayThongTinLoaiNhanVien(int maLoaiNV)
        {
            LoaiNhanVienDTO loaiNV = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM LoaiNhanVien WHERE MaLoaiNV=@MaLoaiNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaLoaiNV", maLoaiNV);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    loaiNV = new LoaiNhanVienDTO();
                    loaiNV.MaLoaiNV = reader.GetInt32(0);
                    loaiNV.TenLoaiNV = reader.GetString(1);
                    loaiNV.TrangThai = reader.GetInt32(2);
                }
                reader.Close();
            }
            return loaiNV;
        }
    }
}
