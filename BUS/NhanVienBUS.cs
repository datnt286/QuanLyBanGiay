using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienBUS();
                }
                return instance;
            }
        }

        private NhanVienBUS() { }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return NhanVienDAL.Instance.LayDanhSachNhanVien();
        }

        public List<NhanVienDTO> LayDanhSachNhanVienDangHoatDong()
        {
            return NhanVienDAL.Instance.LayDanhSachNhanVienDangHoatDong();
        }

        public List<NhanVienDTO> LayDanhSachNhanVienDaXoa()
        {
            return NhanVienDAL.Instance.LayDanhSachNhanVienDaXoa();
        }

        public List<NhanVienDTO> LayDanhSachNhanVienBanHang()
        {
            return NhanVienDAL.Instance.LayDanhSachNhanVienBanHang();
        }

        public List<NhanVienDTO> LayDanhSachNhanVienKho()
        {
            return NhanVienDAL.Instance.LayDanhSachNhanVienKho();
        }

        public NhanVienDTO LayThongTinNhanVien(int maNV)
        {
            return NhanVienDAL.Instance.LayThongTinNhanVien(maNV);
        }

        public NhanVienDTO LayThongTinNhanVienMoiNhat()
        {
            return NhanVienDAL.Instance.LayThongTinNhanVienMoiNhat();
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            return NhanVienDAL.Instance.ThemNhanVien(nhanVien);
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            return NhanVienDAL.Instance.CapNhatNhanVien(nhanVien);
        }

        public bool CapNhatTrangThaiNhanVien(int maNV, int trangThai)
        {
            return NhanVienDAL.Instance.CapNhatTrangThaiNhanVien(maNV, trangThai);
        }

        public List<NhanVienDTO> TimKiemNhanVien(string tenNV)
        {
            return NhanVienDAL.Instance.TimKiemNhanVien(tenNV);
        }

        public List<NhanVienDTO> TimKiemNhanVienTheoMaLoaiNhanVien(string tenNV, int maLoaiNV)
        {
            return NhanVienDAL.Instance.TimKiemNhanVienTheoMaLoaiNhanVien(tenNV, maLoaiNV);
        }
    }
}
