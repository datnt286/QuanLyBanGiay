using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return instance;
            }
        }

        private NhanVienDAL() { }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public List<NhanVienDTO> LayDanhSachNhanVienDangHoatDong()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public List<NhanVienDTO> LayDanhSachNhanVienDaXoa()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE TrangThai=0";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public List<NhanVienDTO> LayDanhSachNhanVienBanHang()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE (MaLoaiNV=1 OR MaLoaiNV=2) AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public List<NhanVienDTO> LayDanhSachNhanVienKho()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE (MaLoaiNV=1 OR MaLoaiNV=3) AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public NhanVienDTO LayThongTinNhanVien(int maNV)
        {
            NhanVienDTO nhanVien = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE MaNV=@MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                }
                reader.Close();
            }
            return nhanVien;
        }

        public NhanVienDTO LayThongTinNhanVienMoiNhat()
        {
            NhanVienDTO nhanVien = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 1 * FROM NhanVien ORDER BY MaNV DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                }
                reader.Close();
            }
            return nhanVien;
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) " +
                             "VALUES (@TenNV, @HinhAnh, @SDT, @Email, @DiaChi, @NgayVaoLam, @Luong, @MaLoaiNV)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                command.Parameters.AddWithValue("@HinhAnh", nhanVien.HinhAnh);
                command.Parameters.AddWithValue("@SDT", nhanVien.SDT);
                command.Parameters.AddWithValue("@Email", nhanVien.Email);
                command.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                command.Parameters.AddWithValue("@NgayVaoLam", nhanVien.NgayVaoLam);
                command.Parameters.AddWithValue("@Luong", nhanVien.Luong);
                command.Parameters.AddWithValue("@MaLoaiNV", nhanVien.MaLoaiNV);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE NhanVien SET TenNV=@TenNV, HinhAnh=@HinhAnh, SDT=@SDT, Email=@Email, DiaChi=@DiaChi, " +
                             "NgayVaoLam=@NgayVaoLam, Luong=@Luong, MaLoaiNV=@MaLoaiNV WHERE MaNV=@MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                command.Parameters.AddWithValue("@HinhAnh", nhanVien.HinhAnh);
                command.Parameters.AddWithValue("@SDT", nhanVien.SDT);
                command.Parameters.AddWithValue("@Email", nhanVien.Email);
                command.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                command.Parameters.AddWithValue("@NgayVaoLam", nhanVien.NgayVaoLam);
                command.Parameters.AddWithValue("@Luong", nhanVien.Luong);
                command.Parameters.AddWithValue("@MaLoaiNV", nhanVien.MaLoaiNV);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTrangThaiNhanVien(int maNV, int trangThai)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE NhanVien SET TrangThai=@TrangThai WHERE MaNV=@MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<NhanVienDTO> TimKiemNhanVien(string tenNV)
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE TenNV LIKE @TenNV AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }

        public List<NhanVienDTO> TimKiemNhanVienTheoMaLoaiNhanVien(string tenNV, int maLoaiNV)
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhanVien WHERE TenNV LIKE @TenNV AND MaLoaiNV=@MaLoaiNV AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                command.Parameters.AddWithValue("@MaLoaiNV", maLoaiNV);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = reader.GetInt32(0);
                    nhanVien.TenNV = reader.GetString(1);
                    nhanVien.HinhAnh = reader.GetString(2);
                    nhanVien.SDT = reader.GetString(3);
                    nhanVien.Email = reader.GetString(4);
                    nhanVien.DiaChi = reader.GetString(5);
                    nhanVien.NgayVaoLam = reader.GetDateTime(6);
                    nhanVien.Luong = reader.GetDecimal(7);
                    nhanVien.MaLoaiNV = reader.GetInt32(8);
                    nhanVien.TrangThai = reader.GetInt32(9);
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
            }
            return dsNhanVien;
        }
    }
}
