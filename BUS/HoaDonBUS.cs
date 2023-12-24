using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;

        public static HoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonBUS();
                }
                return instance;
            }
        }

        private HoaDonBUS() { }

        public List<HoaDonDTO> LayDanhSachHoaDon()
        {
            return HoaDonDAL.Instance.LayDanhSachHoaDon();
        }

        public List<HoaDonDTO> LayDanhSachHoaDonTheoMaKhachHang(int maKH)
        {
            return HoaDonDAL.Instance.LayDanhSachHoaDonTheoMaKhachHang(maKH);
        }

        public HoaDonDTO LayThongTinHoaDon(int maHD)
        {
            return HoaDonDAL.Instance.LayThongTinHoaDon(maHD);
        }

        public HoaDonDTO LayThongTinHoaDonMoiNhat()
        {
            return HoaDonDAL.Instance.LayThongTinHoaDonMoiNhat();
        }

        public bool ThemHoaDon(HoaDonDTO hoaDon)
        {
            return HoaDonDAL.Instance.ThemHoaDon(hoaDon);
        }

        public decimal LayTongDoanhThu()
        {
            return HoaDonDAL.Instance.LayTongDoanhThu();
        }

        public List<HoaDonDTO> LayDanhSachTop5NhanVienCoTongDoanhThuCaoNhat(int thoiGian)
        {
            return HoaDonDAL.Instance.LayDanhSachTop5NhanVienCoTongDoanhThuCaoNhat(thoiGian);
        }
    }
}
