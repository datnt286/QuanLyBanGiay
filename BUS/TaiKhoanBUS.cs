using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;

        public static TaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanBUS();
                }
                return instance;
            }
        }

        private TaiKhoanBUS() { }

        public TaiKhoanDTO DangNhap(string taiKhoan, string matKhau)
        {
            return TaiKhoanDAL.Instance.DangNhap(taiKhoan, matKhau);
        }

        public List<TaiKhoanDTO> LayDanhSachTaiKhoan()
        {
            return TaiKhoanDAL.Instance.LayDanhSachTaiKhoan();
        }

        public TaiKhoanDTO LayThongTinTaiKhoan(int maNV)
        {
            return TaiKhoanDAL.Instance.LayThongTinTaiKhoan(maNV);
        }

        public bool TaoTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return TaiKhoanDAL.Instance.TaoTaiKhoan(taiKhoan);
        }

        public bool CapNhatTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            return TaiKhoanDAL.Instance.CapNhatTaiKhoan(taiKhoan);
        }

        public bool CapNhatTrangThaiTaiKhoan(int maTK, int trangThai)
        {
            return TaiKhoanDAL.Instance.CapNhatTrangThaiTaiKhoan(maTK, trangThai);
        }

        public bool DoiMatKhau(int maNV, string matKhau)
        {
            return TaiKhoanDAL.Instance.DoiMatKhau(maNV, matKhau);
        }
    }
}
