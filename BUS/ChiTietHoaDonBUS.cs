using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        private static ChiTietHoaDonBUS instance;

        public static ChiTietHoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChiTietHoaDonBUS();
                }
                return instance;
            }
        }

        private ChiTietHoaDonBUS() { }

        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDon()
        {
            return ChiTietHoaDonDAL.Instance.LayDanhSachChiTietHoaDon();
        }

        public ChiTietHoaDonDTO LayThongTinChiTietHoaDon(int maCTHD)
        {
            return ChiTietHoaDonDAL.Instance.LayThongTinChiTietHoaDon(maCTHD);
        }

        public List<ChiTietHoaDonDTO> LayDanhSachChiTietHoaDonTheoMaHoaDon(int maHD)
        {
            return ChiTietHoaDonDAL.Instance.LayDanhSachChiTietHoaDonTheoMaHoaDon(maHD);
        }

        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHD)
        {
            return ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(chiTietHD);
        }

        public int LayTongSoLuongSanPhamDaBan()
        {
            return ChiTietHoaDonDAL.Instance.LayTongSoLuongSanPhamDaBan();
        }

        public List<ChiTietHoaDonDTO> LayDanhSachTop10SanPhamCoTongSoLuongBanNhieuNhat(int thoiGian)
        {
            return ChiTietHoaDonDAL.Instance.LayDanhSachTop10SanPhamCoTongSoLuongBanNhieuNhat(thoiGian);
        }
    }
}
