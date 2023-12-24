using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int MaNV { set; get; }
        public string TenNV { set; get; }
        public string HinhAnh { set; get; }
        public string SDT { set; get; }
        public string Email { set; get; }
        public string DiaChi { set; get; }
        public DateTime NgayVaoLam { set; get; }
        public decimal Luong { set; get; }
        public int MaLoaiNV { set; get; }
        public int TrangThai { set; get; }
    }
}
