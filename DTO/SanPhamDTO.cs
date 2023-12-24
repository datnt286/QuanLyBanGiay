using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO 
    {
        public int MaSP { set; get; }
        public int MaLoaiSP { set; get; }
        public int MaNCC { set; get; }
        public string TenSP { set; get; }
        public string HinhAnh { set; get; }
        public string MauSac { set; get; }
        public int Size { set; get; }
        public int SoLuong { set; get; }
        public decimal GiaNhap { set; get; }
        public decimal GiaBan { set; get; }
        public string MoTa { set; get; }
        public int TrangThai { set; get; }
    }
}
