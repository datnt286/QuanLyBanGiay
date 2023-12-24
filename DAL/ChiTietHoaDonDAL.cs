using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL instance;

        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChiTietHoaDonDAL();
                }
                return instance;
            }
        }

        private ChiTietHoaDonDAL() { }

        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDon()
        {
            List<ChiTietHoaDonDTO> dsChiTietHD = new List<ChiTietHoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM ChiTietHoaDon";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonDTO chiTietHD = new ChiTietHoaDonDTO();
                    chiTietHD.MaCTHD = reader.GetInt32(0);
                    chiTietHD.MaHD = reader.GetInt32(1);
                    chiTietHD.MaSP = reader.GetInt32(2);
                    chiTietHD.SoLuong = reader.GetInt32(3);
                    chiTietHD.TongTien = reader.GetDecimal(4);
                    dsChiTietHD.Add(chiTietHD);
                }
                reader.Close();
            }
            return dsChiTietHD;
        }

        public ChiTietHoaDonDTO LayThongTinChiTietHoaDon(int maCTHD)
        {
            ChiTietHoaDonDTO chiTietHD = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM ChiTietHoaDon WHERE MaCTHD=@MaCTHD";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaCTHD", maCTHD);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    chiTietHD = new ChiTietHoaDonDTO();
                    chiTietHD.MaCTHD = reader.GetInt32(0);
                    chiTietHD.MaHD = reader.GetInt32(1);
                    chiTietHD.MaSP = reader.GetInt32(2);
                    chiTietHD.SoLuong = reader.GetInt32(3);
                    chiTietHD.TongTien = reader.GetDecimal(4);
                }
                reader.Close();
            }
            return chiTietHD;
        }

        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDonTheoMaHoaDon(int maHD)
        {
            List<ChiTietHoaDonDTO> dsChiTietHD = new List<ChiTietHoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM ChiTietHoaDon WHERE MaHD=@MaHD";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonDTO chiTietHD = new ChiTietHoaDonDTO();
                    chiTietHD.MaCTHD = reader.GetInt32(0);
                    chiTietHD.MaHD = reader.GetInt32(1);
                    chiTietHD.MaSP = reader.GetInt32(2);
                    chiTietHD.SoLuong = reader.GetInt32(3);
                    chiTietHD.TongTien = reader.GetDecimal(4);
                    dsChiTietHD.Add(chiTietHD);
                }
                reader.Close();
            }
            return dsChiTietHD;
        }

        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHD)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) " +
                             "VALUES (@MaHD, @MaSP, @SoLuong, @TongTien)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaHD", chiTietHD.MaHD);
                command.Parameters.AddWithValue("@MaSP", chiTietHD.MaSP);
                command.Parameters.AddWithValue("@SoLuong", chiTietHD.SoLuong);
                command.Parameters.AddWithValue("@TongTien", chiTietHD.TongTien);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public int LayTongSoLuongSanPhamDaBan()
        {
            int tongSL = 0;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT SUM(SoLuong) FROM ChiTietHoaDon";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        tongSL = reader.GetInt32(0);
                    }
                }
                reader.Close();
            }
            return tongSL;
        }

        public List<ChiTietHoaDonDTO> LayDanhSachTop10SanPhamCoTongSoLuongBanNhieuNhat(int thoiGian)
        {
            List<ChiTietHoaDonDTO> dsChiTietHD = new List<ChiTietHoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 10 CTHD.MaSP, SUM(CTHD.SoLuong) AS 'TongSoLuong' ";
                sql += "FROM ChiTietHoaDon CTHD ";
                sql += "INNER JOIN HoaDon HD ON CTHD.MaHD = HD.MaHD ";

                if (thoiGian == 0)
                {
                    sql += "WHERE DAY(HD.NgayLap) = DAY(GETDATE()) AND MONTH(HD.NgayLap) = MONTH(GETDATE()) AND YEAR(HD.NgayLap) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 1)
                {
                    sql += "WHERE MONTH(HD.NgayLap) = MONTH(GETDATE()) AND YEAR(HD.NgayLap) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 2)
                {
                    sql += "WHERE YEAR(HD.NgayLap) = YEAR(GETDATE()) ";
                }

                sql += "GROUP BY CTHD.MaSP ";
                sql += "ORDER BY SUM(CTHD.SoLuong) DESC";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonDTO chiTietHD = new ChiTietHoaDonDTO();
                    chiTietHD.MaSP = reader.GetInt32(0);
                    chiTietHD.SoLuong = reader.GetInt32(1);
                    dsChiTietHD.Add(chiTietHD);
                }
                reader.Close();
            }
            return dsChiTietHD;
        }
    }
}
