using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuNhapBUS
    {
        private static PhieuNhapBUS instance;

        public static PhieuNhapBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhieuNhapBUS();
                }
                return instance;
            }
        }

        private PhieuNhapBUS() { }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            return PhieuNhapDAL.Instance.LayDanhSachPhieuNhap();
        }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhapTheoMaNhaCungCap(int maNCC)
        {
            return PhieuNhapDAL.Instance.LayDanhSachPhieuNhapTheoMaNhaCungCap(maNCC);
        }

        public PhieuNhapDTO LayThongTinPhieuNhapMoiNhat()
        {
            return PhieuNhapDAL.Instance.LayThongTinPhieuNhapMoiNhat();
        }

        public bool ThemPhieuNhap(PhieuNhapDTO phieuNhap)
        {
            return PhieuNhapDAL.Instance.ThemPhieuNhap(phieuNhap);
        }
    }
}
