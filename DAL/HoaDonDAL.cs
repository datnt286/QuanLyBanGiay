using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAL();
                }
                return instance;
            }
        }

        private HoaDonDAL() { }

        public List<HoaDonDTO> LayDanhSachHoaDon()
        {
            List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM HoaDon";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonDTO hoaDon = new HoaDonDTO();
                    hoaDon.MaHD = reader.GetInt32(0);
                    hoaDon.MaKH = reader.GetInt32(1);
                    hoaDon.MaNV = reader.GetInt32(2);
                    hoaDon.NgayLap = reader.GetDateTime(3);
                    hoaDon.ThanhTien = reader.GetDecimal(4);
                    hoaDon.TrangThai = reader.GetInt32(5);
                    dsHoaDon.Add(hoaDon);
                }
                reader.Close();
            }
            return dsHoaDon;
        }

        public List<HoaDonDTO> LayDanhSachHoaDonTheoMaKhachHang(int maKH)
        {
            List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM HoaDon WHERE MaKH=@MaKH";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonDTO hoaDon = new HoaDonDTO();
                    hoaDon.MaHD = reader.GetInt32(0);
                    hoaDon.MaKH = reader.GetInt32(1);
                    hoaDon.MaNV = reader.GetInt32(2);
                    hoaDon.NgayLap = reader.GetDateTime(3);
                    hoaDon.ThanhTien = reader.GetDecimal(4);
                    hoaDon.TrangThai = reader.GetInt32(5);
                    dsHoaDon.Add(hoaDon);
                }
                reader.Close();
            }
            return dsHoaDon;
        }

        public HoaDonDTO LayThongTinHoaDon(int maHD)
        {
            HoaDonDTO hoaDon = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM HoaDon WHERE MaHD=@MaHD";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hoaDon = new HoaDonDTO();
                    hoaDon.MaHD = reader.GetInt32(0);
                    hoaDon.MaKH = reader.GetInt32(1);
                    hoaDon.MaNV = reader.GetInt32(2);
                    hoaDon.NgayLap = reader.GetDateTime(3);
                    hoaDon.ThanhTien = reader.GetDecimal(4);
                    hoaDon.TrangThai = reader.GetInt32(5);
                }
                reader.Close();
            }
            return hoaDon;
        }

        public HoaDonDTO LayThongTinHoaDonMoiNhat()
        {
            HoaDonDTO hoaDon = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 1 * FROM HoaDon ORDER BY MaHD DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hoaDon = new HoaDonDTO();
                    hoaDon.MaHD = reader.GetInt32(0);
                    hoaDon.MaKH = reader.GetInt32(1);
                    hoaDon.MaNV = reader.GetInt32(2);
                    hoaDon.NgayLap = reader.GetDateTime(3);
                    hoaDon.ThanhTien = reader.GetDecimal(4);
                    hoaDon.TrangThai = reader.GetInt32(5);
                }
                reader.Close();
            }
            return hoaDon;
        }

        public bool ThemHoaDon(HoaDonDTO hoaDon)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) " +
                             "VALUES (@MaKH, @MaNV, @NgayLap, @ThanhTien)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKH", hoaDon.MaKH);
                command.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                command.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                command.Parameters.AddWithValue("@ThanhTien", hoaDon.ThanhTien);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public decimal LayTongDoanhThu()
        {
            decimal tongDoanhThu = 0;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT SUM(ThanhTien) FROM HoaDon";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        tongDoanhThu = reader.GetDecimal(0);
                    }
                }
                reader.Close();
            }
            return tongDoanhThu;
        }

        public List<HoaDonDTO> LayDanhSachTop5NhanVienCoTongDoanhThuCaoNhat(int thoiGian)
        {
            List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 5 MaNV, SUM(ThanhTien) AS 'TongDoanhThu' FROM HoaDon ";

                if (thoiGian == 0)
                {
                    sql += "WHERE DAY(NgayLap) = DAY(GETDATE()) AND MONTH(NgayLap) = MONTH(GETDATE()) AND YEAR(NgayLap) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 1)
                {
                    sql += "WHERE MONTH(NgayLap) = MONTH(GETDATE()) AND YEAR(NgayLap) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 2)
                {
                    sql += "WHERE YEAR(NgayLap) = YEAR(GETDATE()) ";
                }

                sql += "GROUP BY MaNV ORDER BY SUM(ThanhTien) DESC";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonDTO hoaDon = new HoaDonDTO();
                    hoaDon.MaNV = reader.GetInt32(0);
                    hoaDon.ThanhTien = reader.GetDecimal(1);
                    dsHoaDon.Add(hoaDon);
                }
                reader.Close();
            }
            return dsHoaDon;
        }
    }
}
