using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangBUS();
                }
                return instance;
            }
        }

        private KhachHangBUS() { }

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            return KhachHangDAL.Instance.LayDanhSachKhachHang();
        }

        public List<KhachHangDTO> LayDanhSachKhachHangDaLuu()
        {
            return KhachHangDAL.Instance.LayDanhSachKhachHangDaLuu();
        }

        public List<KhachHangDTO> LayDanhSachKhachHangDaXoa()
        {
            return KhachHangDAL.Instance.LayDanhSachKhachHangDaXoa();
        }

        public KhachHangDTO LayThongTinKhachHang(int maKH)
        {
            return KhachHangDAL.Instance.LayThongTinKhachHang(maKH);
        }

        public KhachHangDTO LayThongTinKhachHangMoiNhat()
        {
            return KhachHangDAL.Instance.LayThongTinKhachHangMoiNhat();
        }

        public KhachHangDTO LayThongTinKhachHangTheoSDT(string SDT)
        {
            return KhachHangDAL.Instance.LayThongTinKhachHangTheoSDT(SDT);
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            return KhachHangDAL.Instance.ThemKhachHang(khachHang);
        }

        public bool CapNhatKhachHang(KhachHangDTO khachHang)
        {
            return KhachHangDAL.Instance.CapNhatKhachHang(khachHang);
        }

        public bool CapNhatTrangThaiKhachHang(int maKH, int trangThai)
        {
            return KhachHangDAL.Instance.CapNhatTrangThaiKhachHang(maKH, trangThai);
        }

        public List<KhachHangDTO> TimKiemKhachHang(string tenKH)
        {
            return KhachHangDAL.Instance.TimKiemKhachHang(tenKH);
        }

        public bool KiemTraSDTTrung(string SDT)
        {
            return KhachHangDAL.Instance.KiemTraSDTTrung(SDT);
        }

        public int LayTongKhachHang()
        {
            return KhachHangDAL.Instance.LayTongKhachHang();
        }

        public List<KhachHangDTO> LayDanhSachKhachHangMoi(int thoiGian)
        {
            return KhachHangDAL.Instance.LayDanhSachKhachHangMoi(thoiGian);
        }
    }
}
