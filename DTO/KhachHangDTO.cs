using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int MaKH { set; get; }
        public string TenKH { set; get; }
        public string SDT { set; get; }
        public DateTime NgayDangKy { set; get; }
        public string Email { set; get; }
        public string DiaChi { set; get; }
        public int TrangThai { set; get; }
    }
}
