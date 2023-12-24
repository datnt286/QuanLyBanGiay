using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAL();
                }
                return instance;
            }
        }

        private KhachHangDAL() { }

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                    dsKhachHang.Add(khachHang);
                }
                reader.Close();
            }
            return dsKhachHang;
        }

        public List<KhachHangDTO> LayDanhSachKhachHangDaLuu()
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                    dsKhachHang.Add(khachHang);
                }
                reader.Close();
            }
            return dsKhachHang;
        }

        public List<KhachHangDTO> LayDanhSachKhachHangDaXoa()
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE TrangThai=0";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                    dsKhachHang.Add(khachHang);
                }
                reader.Close();
            }
            return dsKhachHang;
        }

        public KhachHangDTO LayThongTinKhachHang(int maKH)
        {
            KhachHangDTO khachHang = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE MaKH=@MaKH";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                }
                reader.Close();
            }
            return khachHang;
        }

        public KhachHangDTO LayThongTinKhachHangMoiNhat()
        {
            KhachHangDTO khachHang = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 1 * FROM KhachHang ORDER BY MaKH DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                }
                reader.Close();
            }
            return khachHang;
        }

        public KhachHangDTO LayThongTinKhachHangTheoSDT(string SDT)
        {
            KhachHangDTO khachHang = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE SDT=@SDT";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SDT", SDT);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                }
                reader.Close();
            }
            return khachHang;
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) VALUES (@TenKH, @SDT, @NgayDangKy, @Email, @DiaChi)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@SDT", khachHang.SDT);
                command.Parameters.AddWithValue("@NgayDangKy", khachHang.NgayDangKy);
                command.Parameters.AddWithValue("@Email", khachHang.Email);
                command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatKhachHang(KhachHangDTO khachHang)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE KhachHang SET TenKH=@TenKH, SDT=@SDT, NgayDangKy=@NgayDangKy, Email=@Email, DiaChi=@DiaChi WHERE MaKH=@MaKH";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@SDT", khachHang.SDT);
                command.Parameters.AddWithValue("@NgayDangKy", khachHang.NgayDangKy);
                command.Parameters.AddWithValue("@Email", khachHang.Email);
                command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTrangThaiKhachHang(int maKH, int trangThai)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE KhachHang SET TrangThai=@TrangThai WHERE MaKH=@MaKH";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<KhachHangDTO> TimKiemKhachHang(string tenKH)
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE TenKH LIKE @TenKH AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenKH", "%" + tenKH + "%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                    dsKhachHang.Add(khachHang);
                }
                reader.Close();
            }
            return dsKhachHang;
        }

        public bool KiemTraSDTTrung(string SDT)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT COUNT(*) FROM KhachHang WHERE SDT=@SDT AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SDT", SDT);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public int LayTongKhachHang()
        {
            int tongKH = 0;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT COUNT(DISTINCT SDT) FROM KhachHang";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        tongKH = reader.GetInt32(0);
                    }
                }
                reader.Close();
            }
            return tongKH;
        }

        public List<KhachHangDTO> LayDanhSachKhachHangMoi(int thoiGian)
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE TrangThai = 1 ";

                if (thoiGian == 0)
                {
                    sql += "AND DAY(NgayDangKy) = DAY(GETDATE()) AND MONTH(NgayDangKy) = MONTH(GETDATE()) AND YEAR(NgayDangKy) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 1)
                {
                    sql += "AND MONTH(NgayDangKy) = MONTH(GETDATE()) AND YEAR(NgayDangKy) = YEAR(GETDATE()) ";
                }
                else if (thoiGian == 2)
                {
                    sql += "AND YEAR(NgayDangKy) = YEAR(GETDATE()) ";
                }

                sql += "ORDER BY NgayDangKy";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = reader.GetInt32(0);
                    khachHang.TenKH = reader.GetString(1);
                    khachHang.SDT = reader.GetString(2);
                    khachHang.NgayDangKy = reader.GetDateTime(3);
                    try
                    {
                        khachHang.Email = reader.GetString(4);
                    }
                    catch
                    {
                        khachHang.Email = "";
                    }
                    try
                    {
                        khachHang.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        khachHang.DiaChi = "";
                    }
                    khachHang.TrangThai = reader.GetInt32(6);
                    dsKhachHang.Add(khachHang);
                }
                reader.Close();
            }
            return dsKhachHang;
        }
    }
}
