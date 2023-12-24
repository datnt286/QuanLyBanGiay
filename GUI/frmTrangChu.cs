using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblSPDaBan.Text = ChiTietHoaDonBUS.Instance.LayTongSoLuongSanPhamDaBan().ToString();
            lblTongDoanhThu.Text = HoaDonBUS.Instance.LayTongDoanhThu().ToString();
            lblTongKH.Text = KhachHangBUS.Instance.LayTongKhachHang().ToString();
            cbbThoiGian.SelectedIndex = 1;
            ThongKe();
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colMaSP")
            {
                int maSP = Convert.ToInt32(e.Value);
                SanPhamDTO sanPham = SanPhamBUS.Instance.LayThongTinSanPham(maSP);
                if (sanPham != null)
                {
                    e.Value = sanPham.TenSP;
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "colMaNV")
            {
                int maNV = Convert.ToInt32(e.Value);
                NhanVienDTO nhanVien = NhanVienBUS.Instance.LayThongTinNhanVien(maNV);
                if (nhanVien != null)
                {
                    e.Value = nhanVien.TenNV;
                    e.FormattingApplied = true;
                }
            }
        }

        private void cbbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        void ThongKe()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvHoaDon.AutoGenerateColumns = false;
            dgvKhachHang.AutoGenerateColumns = false;

            int thoiGian = int.Parse(cbbThoiGian.SelectedIndex.ToString());
            dgvSanPham.DataSource = ChiTietHoaDonBUS.Instance.LayDanhSachTop10SanPhamCoTongSoLuongBanNhieuNhat(thoiGian);
            dgvHoaDon.DataSource = HoaDonBUS.Instance.LayDanhSachTop5NhanVienCoTongDoanhThuCaoNhat(thoiGian);
            dgvKhachHang.DataSource = KhachHangBUS.Instance.LayDanhSachKhachHangMoi(thoiGian);
        }
    }
}
