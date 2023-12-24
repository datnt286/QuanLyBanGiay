using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietPhieuNhapBUS
    {
        private static ChiTietPhieuNhapBUS instance;

        public static ChiTietPhieuNhapBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChiTietPhieuNhapBUS();
                }
                return instance;
            }
        }

        private ChiTietPhieuNhapBUS() { }

        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhap()
        {
            return ChiTietPhieuNhapDAL.Instance.LayDanhSachChiTietPhieuNhap();
        }

        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhapTheoMaPhieuNhap(int maPN)
        {
            return ChiTietPhieuNhapDAL.Instance.LayDanhSachChiTietPhieuNhapTheoMaPhieuNhap(maPN);
        }

        public bool ThemChiTietPhieuNhap(ChiTietPhieuNhapDTO chiTietPN)
        {
            return ChiTietPhieuNhapDAL.Instance.ThemChiTietPhieuNhap(chiTietPN);
        }
    }
}
