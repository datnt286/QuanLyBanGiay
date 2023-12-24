using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        private static PhieuNhapDAL instance;

        public static PhieuNhapDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhieuNhapDAL();
                }
                return instance;
            }
        }

        private PhieuNhapDAL() { }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            List<PhieuNhapDTO> dsPhieuNhap = new List<PhieuNhapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM PhieuNhap";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
                    phieuNhap.MaPN = reader.GetInt32(0);
                    phieuNhap.MaNCC = reader.GetInt32(1);
                    phieuNhap.MaNV = reader.GetInt32(2);
                    phieuNhap.NgayNhap = reader.GetDateTime(3);
                    phieuNhap.ThanhTien = reader.GetDecimal(4);
                    phieuNhap.TrangThai = reader.GetInt32(5);
                    dsPhieuNhap.Add(phieuNhap);
                }
                reader.Close();
            }
            return dsPhieuNhap;
        }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhapTheoMaNhaCungCap(int maNCC)
        {
            List<PhieuNhapDTO> dsPhieuNhap = new List<PhieuNhapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM PhieuNhap WHERE MaNCC=@MaNCC";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", maNCC);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
                    phieuNhap.MaPN = reader.GetInt32(0);
                    phieuNhap.MaNCC = reader.GetInt32(1);
                    phieuNhap.MaNV = reader.GetInt32(2);
                    phieuNhap.NgayNhap = reader.GetDateTime(3);
                    phieuNhap.ThanhTien = reader.GetDecimal(4);
                    phieuNhap.TrangThai = reader.GetInt32(5);
                    dsPhieuNhap.Add(phieuNhap);
                }
                reader.Close();
            }
            return dsPhieuNhap;
        }

        public PhieuNhapDTO LayThongTinPhieuNhapMoiNhat()
        {
            PhieuNhapDTO phieuNhap = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 1 * FROM PhieuNhap ORDER BY MaPN DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    phieuNhap = new PhieuNhapDTO();
                    phieuNhap.MaPN = reader.GetInt32(0);
                    phieuNhap.MaNCC = reader.GetInt32(1);
                    phieuNhap.MaNV = reader.GetInt32(2);
                    phieuNhap.NgayNhap = reader.GetDateTime(3);
                    phieuNhap.ThanhTien = reader.GetDecimal(4);
                    phieuNhap.TrangThai = reader.GetInt32(5);
                }
                reader.Close();
            }
            return phieuNhap;
        }

        public bool ThemPhieuNhap(PhieuNhapDTO phieuNhap)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) " +
                             "VALUES (@MaNCC, @MaNV, @NgayNhap, @ThanhTien)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", phieuNhap.MaNCC);
                command.Parameters.AddWithValue("@MaNV", phieuNhap.MaNV);
                command.Parameters.AddWithValue("@NgayNhap", phieuNhap.NgayNhap);
                command.Parameters.AddWithValue("@ThanhTien", phieuNhap.ThanhTien);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
