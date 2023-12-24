using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        private static LoaiSanPhamBUS instance;

        public static LoaiSanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamBUS();
                }
                return instance;
            }
        }

        private LoaiSanPhamBUS() { }

        public List<LoaiSanPhamDTO> LayDanhSachLoaiSanPham()
        {
            return LoaiSanPhamDAL.Instance.LayDanhSachLoaiSanPham();
        }

        public LoaiSanPhamDTO LayThongTinLoaiSanPham(int maLoaiSP)
        {
            return LoaiSanPhamDAL.Instance.LayThongTinLoaiSanPham(maLoaiSP);
        }
    }
}
