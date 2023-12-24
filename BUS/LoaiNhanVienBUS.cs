using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiNhanVienBUS
    {
        private static LoaiNhanVienBUS instance;

        public static LoaiNhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiNhanVienBUS();
                }
                return instance;
            }
        }

        private LoaiNhanVienBUS() { }

        public List<LoaiNhanVienDTO> LayDanhSachLoaiNhanVien()
        {
            return LoaiNhanVienDAL.Instance.LayDanhSachLoaiNhanVien();
        }

        public LoaiNhanVienDTO LayThongTinLoaiNhanVien(int maLoaiNV)
        {
            return LoaiNhanVienDAL.Instance.LayThongTinLoaiNhanVien(maLoaiNV);
        }
    }
}
