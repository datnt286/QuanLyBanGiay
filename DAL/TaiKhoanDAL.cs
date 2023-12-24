using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;

        public static TaiKhoanDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanDAL();
                }
                return instance;
            }
        }

        private TaiKhoanDAL() { }

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            TaiKhoanDTO taiKhoan = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", matKhau);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaTK = reader.GetInt32(0);
                    taiKhoan.MaNV = reader.GetInt32(1);
                    taiKhoan.TenDangNhap = reader.GetString(2);
                    taiKhoan.MatKhau = reader.GetString(3);
                    taiKhoan.TrangThai = reader.GetInt32(4);
                }
                reader.Close();
            }
            return taiKhoan;
        }

        public List<TaiKhoanDTO> LayDanhSachTaiKhoan()
        {
            List<TaiKhoanDTO> dsTaiKhoan = new List<TaiKhoanDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM TaiKhoan";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaTK = reader.GetInt32(0);
                    taiKhoan.MaNV = reader.GetInt32(1);
                    taiKhoan.TenDangNhap = reader.GetString(2);
                    taiKhoan.MatKhau = reader.GetString(3);
                    taiKhoan.TrangThai = reader.GetInt32(4);
                    dsTaiKhoan.Add(taiKhoan);
                }
                reader.Close();
            }
            return dsTaiKhoan;
        }

        public TaiKhoanDTO LayThongTinTaiKhoan(int maNV)
        {
            TaiKhoanDTO taiKhoan = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM TaiKhoan WHERE MaNV=@MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaTK = reader.GetInt32(0);
                    taiKhoan.MaNV = reader.GetInt32(1);
                    taiKhoan.TenDangNhap = reader.GetString(2);
                    taiKhoan.MatKhau = reader.GetString(3);
                    taiKhoan.TrangThai = reader.GetInt32(4);
                }
                reader.Close();
            }
            return taiKhoan;
        }

        public bool TaoTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (@MaNV, @TenDangNhap, @MatKhau)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV);
                command.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE TaiKhoan SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau WHERE MaTK=@MaTK";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);
                command.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV);
                command.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTrangThaiTaiKhoan(int maTK, int trangThai)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE TaiKhoan SET TrangThai=@TrangThai WHERE MaTK=@MaTK";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaTK", maTK);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DoiMatKhau(int maNV, string matKhau)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE TaiKhoan SET MatKhau=@MatKhau WHERE MaNV=@MaNV";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@MatKhau", matKhau);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
