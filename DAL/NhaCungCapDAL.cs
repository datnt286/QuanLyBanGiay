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
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaCungCapDAL();
                }
                return instance;
            }
        }

        private NhaCungCapDAL() { }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCap()
        {
            List<NhaCungCapDTO> dsNhaCungCap = new List<NhaCungCapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhaCungCap";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = reader.GetInt32(0);
                    nhaCungCap.TenNCC = reader.GetString(1);
                    nhaCungCap.SDT = reader.GetString(2);
                    nhaCungCap.Email = reader.GetString(3);
                    nhaCungCap.DiaChi = reader.GetString(4);
                    nhaCungCap.TrangThai = reader.GetInt32(5);
                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
            }
            return dsNhaCungCap;
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCapDangHopTac()
        {
            List<NhaCungCapDTO> dsNhaCungCap = new List<NhaCungCapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhaCungCap WHERE TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = reader.GetInt32(0);
                    nhaCungCap.TenNCC = reader.GetString(1);
                    nhaCungCap.SDT = reader.GetString(2);
                    nhaCungCap.Email = reader.GetString(3);
                    nhaCungCap.DiaChi = reader.GetString(4);
                    nhaCungCap.TrangThai = reader.GetInt32(5);
                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
            }
            return dsNhaCungCap;
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCapDaXoa()
        {
            List<NhaCungCapDTO> dsNhaCungCap = new List<NhaCungCapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhaCungCap WHERE TrangThai=0";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = reader.GetInt32(0);
                    nhaCungCap.TenNCC = reader.GetString(1);
                    nhaCungCap.SDT = reader.GetString(2);
                    nhaCungCap.Email = reader.GetString(3);
                    nhaCungCap.DiaChi = reader.GetString(4);
                    nhaCungCap.TrangThai = reader.GetInt32(5);
                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
            }
            return dsNhaCungCap;
        }

        public NhaCungCapDTO LayThongTinNhaCungCap(int maNCC)
        {
            NhaCungCapDTO nhaCungCap = null;
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhaCungCap WHERE MaNCC=@MaNCC";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", maNCC);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = reader.GetInt32(0);
                    nhaCungCap.TenNCC = reader.GetString(1);
                    nhaCungCap.SDT = reader.GetString(2);
                    nhaCungCap.Email = reader.GetString(3);
                    nhaCungCap.DiaChi = reader.GetString(4);
                    nhaCungCap.TrangThai = reader.GetInt32(5);
                }
                reader.Close();
            }
            return nhaCungCap;
        }

        public bool ThemNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "INSERT INTO NhaCungCap(TenNCC, SDT, Email, DiaChi) " +
                             "VALUES (@TenNCC, @SDT, @Email, @DiaChi)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", nhaCungCap.MaNCC);
                command.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
                command.Parameters.AddWithValue("@SDT", nhaCungCap.SDT);
                command.Parameters.AddWithValue("@Email", nhaCungCap.Email);
                command.Parameters.AddWithValue("@DiaChi", nhaCungCap.DiaChi);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE NhaCungCap SET TenNCC=@TenNCC, SDT=@SDT, " +
                             "Email=@Email, DiaChi=@DiaChi WHERE MaNCC=@MaNCC";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", nhaCungCap.MaNCC);
                command.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
                command.Parameters.AddWithValue("@SDT", nhaCungCap.SDT);
                command.Parameters.AddWithValue("@Email", nhaCungCap.Email);
                command.Parameters.AddWithValue("@DiaChi", nhaCungCap.DiaChi);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CapNhatTrangThaiNhaCungCap(int maNCC, int trangThai)
        {
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "UPDATE NhaCungCap SET TrangThai=@TrangThai WHERE MaNCC=@MaNCC";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaNCC", maNCC);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<NhaCungCapDTO> TimKiemNhaCungCap(string tenNCC)
        {
            List<NhaCungCapDTO> dsNhaCungCap = new List<NhaCungCapDTO>();
            using (SqlConnection connection = DataProvider.Instance.Openconnect())
            {
                string sql = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE @TenNCC AND TrangThai=1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TenNCC", "%" + tenNCC + "%");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = reader.GetInt32(0);
                    nhaCungCap.TenNCC = reader.GetString(1);
                    nhaCungCap.SDT = reader.GetString(2);
                    nhaCungCap.Email = reader.GetString(3);
                    nhaCungCap.DiaChi = reader.GetString(4);
                    nhaCungCap.TrangThai = reader.GetInt32(5);
                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
            }
            return dsNhaCungCap;
        }
    }
}
