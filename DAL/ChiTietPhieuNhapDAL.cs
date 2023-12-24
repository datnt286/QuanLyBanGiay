using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPhieuNhapDAL
    {
        private static ChiTietPhieuNhapDAL instance;

        public static ChiTietPhieuNhapDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChiTietPhieuNhapDAL();
                }
                return instance;
            }
        }

        private ChiTietPhieuNhapDAL() { }

        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhap()
        {
            List<ChiTietPhieuNhapDTO> dsChiTietPN = new List<ChiTietPhieuNhapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM ChiTietPhieuNhap";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietPhieuNhapDTO chiTietPN = new ChiTietPhieuNhapDTO();
                    chiTietPN.MaCTPN = reader.GetInt32(0);
                    chiTietPN.MaPN = reader.GetInt32(1);
                    chiTietPN.MaSP = reader.GetInt32(2);
                    chiTietPN.SoLuong = reader.GetInt32(3);
                    chiTietPN.TongTien = reader.GetDecimal(4);
                    dsChiTietPN.Add(chiTietPN);
                }
                reader.Close();
            }
            return dsChiTietPN;
        }

        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhapTheoMaPhieuNhap(int maPN)
        {
            List<ChiTietPhieuNhapDTO> dsChiTietPN = new List<ChiTietPhieuNhapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM ChiTietPhieuNhap WHERE MaPN=@MaPN";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaPN", maPN);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietPhieuNhapDTO chiTietPN = new ChiTietPhieuNhapDTO();
                    chiTietPN.MaCTPN = reader.GetInt32(0);
                    chiTietPN.MaPN = reader.GetInt32(1);
                    chiTietPN.MaSP = reader.GetInt32(2);
                    chiTietPN.SoLuong = reader.GetInt32(3);
                    chiTietPN.TongTien = reader.GetDecimal(4);
                    dsChiTietPN.Add(chiTietPN);
                }
                reader.Close();
            }
            return dsChiTietPN;
        }

        public bool ThemChiTietPhieuNhap(ChiTietPhieuNhapDTO chiTietPN)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) " +
                             "VALUES (@MaPN, @MaSP, @SoLuong, @TongTien)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaPN", chiTietPN.MaPN);
                command.Parameters.AddWithValue("@MaSP", chiTietPN.MaSP);
                command.Parameters.AddWithValue("@SoLuong", chiTietPN.SoLuong);
                command.Parameters.AddWithValue("@TongTien", chiTietPN.TongTien);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
