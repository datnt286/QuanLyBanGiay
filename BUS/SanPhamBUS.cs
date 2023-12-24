using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        private static SanPhamBUS instance;

        public static SanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamBUS();
                }
                return instance;
            }
        }

        private SanPhamBUS() { }

        public List<SanPhamDTO> LayDanhSachSanPham()
        {
            return SanPhamDAL.Instance.LayDanhSachSanPham();
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDangKinhDoanh()
        {
            return SanPhamDAL.Instance.LayDanhSachSanPhamDangKinhDoanh();
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDangKinhDoanhVaConHang()
        {
            return SanPhamDAL.Instance.LayDanhSachSanPhamDangKinhDoanhVaConHang();
        }

        public List<SanPhamDTO> LayDanhSachSanPhamDaXoa()
        {
            return SanPhamDAL.Instance.LayDanhSachSanPhamDaXoa();
        }

        public List<SanPhamDTO> LayDanhSachSanPhamTheoMaNhaCungCap(int maNCC)
        {
            return SanPhamDAL.Instance.LayDanhSachSanPhamTheoMaNhaCungCap(maNCC);
        }

        public SanPhamDTO LayThongTinSanPham(int maSP)
        {
            return SanPhamDAL.Instance.LayThongTinSanPham(maSP);
        }

        public SanPhamDTO LayThongTinSanPhamMoiNhat()
        {
            return SanPhamDAL.Instance.LayThongTinSanPhamMoiNhat();
        }

        public bool ThemSanPham(SanPhamDTO sanPham)
        {
            return SanPhamDAL.Instance.ThemSanPham(sanPham);
        }

        public bool CapNhatSanPham(SanPhamDTO sanPham)
        {
            return SanPhamDAL.Instance.CapNhatSanPham(sanPham);
        }

        public bool CapNhatSoLuongSanPham(int maSP, int soLuong)
        {
            return SanPhamDAL.Instance.CapNhatSoLuongSanPham(maSP, soLuong);
        }

        public bool CapNhatTrangThaiSanPham(int maSP, int trangThai)
        {
            return SanPhamDAL.Instance.CapNhatTrangThaiSanPham(maSP, trangThai);
        }

        public List<SanPhamDTO> TimKiemSanPham(string tenSP)
        {
            return SanPhamDAL.Instance.TimKiemSanPham(tenSP);
        }

        public List<SanPhamDTO> TimKiemSanPhamTheoMaLoaiSanPhamVaMaNhaCungCap(string tenSP, int maLoaiSP, int maNCC)
        {
            return SanPhamDAL.Instance.TimKiemSanPhamTheoMaLoaiSanPhamVaMaNhaCungCap(tenSP, maLoaiSP, maNCC);
        }
    }
}
