using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDAL();
                }
                return instance;
            }
        }

        private SanPhamDAL() { }

        public List<SanPhamDTO> LayDanhSachSanPham()
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDangKinhDoanh()
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDangKinhDoanhVaConHang()
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TrangThai=1 AND SoLuong>0";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDaXoa()
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TrangThai=0";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public List<SanPhamDTO> LayDanhSachSanPhamTheoMaNhaCungCap(int maNCC)
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE MaNCC=@MaNCC AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", maNCC);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public SanPhamDTO LayThongTinSanPham(int maSP)
        {
            SanPhamDTO sanPham = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE MaSP=@MaSP";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                }
                reader.Close();
            }
            return sanPham;
        }

        public SanPhamDTO LayThongTinSanPhamMoiNhat()
        {
            SanPhamDTO sanPham = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT TOP 1 * FROM SanPham ORDER BY MaSP DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                }
                reader.Close();
            }
            return sanPham;
        }

        public bool ThemSanPham(SanPhamDTO sanPham)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan) " +
                             "VALUES (@MaLoaiSP, @MaNCC, @TenSP, @HinhAnh, @MauSac, @Size, @SoLuong, @GiaNhap, @GiaBan)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaLoaiSP", sanPham.MaLoaiSP);
                command.Parameters.AddWithValue("@MaNCC", sanPham.MaNCC);
                command.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                command.Parameters.AddWithValue("@HinhAnh", sanPham.HinhAnh);
                command.Parameters.AddWithValue("@MauSac", sanPham.MauSac);
                command.Parameters.AddWithValue("@Size", sanPham.Size);
                command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                command.Parameters.AddWithValue("@GiaNhap", sanPham.GiaNhap);
                command.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatSanPham(SanPhamDTO sanPham)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE SanPham SET MaLoaiSP=@MaLoaiSP, MaNCC=@MaNCC, TenSP=@TenSP, HinhAnh=@HinhAnh, " +
                             "MauSac=@MauSac, Size=@Size, SoLuong=@SoLuong, GiaNhap=@GiaNhap, GiaBan=@GiaBan WHERE MaSP=@MaSP";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaSP", sanPham.MaSP);
                command.Parameters.AddWithValue("@MaLoaiSP", sanPham.MaLoaiSP);
                command.Parameters.AddWithValue("@MaNCC", sanPham.MaNCC);
                command.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                command.Parameters.AddWithValue("@HinhAnh", sanPham.HinhAnh);
                command.Parameters.AddWithValue("@MauSac", sanPham.MauSac);
                command.Parameters.AddWithValue("@Size", sanPham.Size);
                command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                command.Parameters.AddWithValue("@GiaNhap", sanPham.GiaNhap);
                command.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatSoLuongSanPham(int maSP, int soLuong)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE SanPham SET SoLuong=@SoLuong WHERE MaSP=@MaSP";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTrangThaiSanPham(int maSP, int trangThai)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE SanPham SET TrangThai=@TrangThai WHERE MaSP=@MaSP";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<SanPhamDTO> TimKiemSanPham(string tenSP)
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TenSP LIKE @TenSP AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenSP", "%" + tenSP + "%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }

        public List<SanPhamDTO> TimKiemSanPhamTheoMaLoaiSanPhamVaMaNhaCungCap(string tenSP, int maLoaiSP, int maNCC)
        {
            List<SanPhamDTO> dsSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM SanPham WHERE TenSP LIKE @TenSP AND MaLoaiSP=@MaLoaiSP AND MaNCC=@MaNCC AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenSP", "%" + tenSP + "%");
                command.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                command.Parameters.AddWithValue("@MaNCC", maNCC);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = reader.GetInt32(0);
                    sanPham.MaLoaiSP = reader.GetInt32(1);
                    sanPham.MaNCC = reader.GetInt32(2);
                    sanPham.TenSP = reader.GetString(3);
                    sanPham.HinhAnh = reader.GetString(4);
                    sanPham.MauSac = reader.GetString(5);
                    sanPham.Size = reader.GetInt32(6);
                    sanPham.SoLuong = reader.GetInt32(7);
                    sanPham.GiaNhap = reader.GetDecimal(8);
                    sanPham.GiaBan = reader.GetDecimal(9);
                    sanPham.MoTa = "";
                    sanPham.TrangThai = reader.GetInt32(11);
                    dsSanPham.Add(sanPham);
                }
                reader.Close();
            }
            return dsSanPham;
        }
    }
}
