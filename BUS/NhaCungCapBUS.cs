using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCapBUS
    {
        private static NhaCungCapBUS instance;

        public static NhaCungCapBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaCungCapBUS();
                }
                return instance;
            }
        }

        private NhaCungCapBUS() { }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCap()
        {
            return NhaCungCapDAL.Instance.LayDanhSachNhaCungCap();
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCapDangHopTac()
        {
            return NhaCungCapDAL.Instance.LayDanhSachNhaCungCapDangHopTac();
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCapDaXoa()
        {
            return NhaCungCapDAL.Instance.LayDanhSachNhaCungCapDaXoa();
        }

        public NhaCungCapDTO LayThongTinNhaCungCap(int maNCC)
        {
            return NhaCungCapDAL.Instance.LayThongTinNhaCungCap(maNCC);
        }

        public bool ThemNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return NhaCungCapDAL.Instance.ThemNhaCungCap(nhaCungCap);
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            return NhaCungCapDAL.Instance.CapNhatNhaCungCap(nhaCungCap);
        }

        public bool CapNhatTrangThaiNhaCungCap(int maNCC, int trangThai)
        {
            return NhaCungCapDAL.Instance.CapNhatTrangThaiNhaCungCap(maNCC, trangThai);
        }

        public List<NhaCungCapDTO> TimKiemNhaCungCap(string tenNCC)
        {
            return NhaCungCapDAL.Instance.TimKiemNhaCungCap(tenNCC);
        }
    }
}
