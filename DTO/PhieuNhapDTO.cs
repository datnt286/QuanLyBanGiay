using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        public int MaPN { set; get; }
        public int MaNCC { set; get; }
        public int MaNV { set; get; }
        public DateTime NgayNhap { set; get; }
        public decimal ThanhTien { set; get; }
        public int TrangThai { set; get; }
    }
}
