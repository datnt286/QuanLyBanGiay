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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
            LoadDanhSachChiTietHoaDon();
            txtSDT.Select();
            dgvHoaDon.Columns["colMaHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietHD.Columns["colMaCTHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietHD.Columns["colMaHD_CTHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachHoaDon()
        {
            dgvHoaDon.DataSource = HoaDonBUS.Instance.LayDanhSachHoaDon();
        }

        void LoadDanhSachChiTietHoaDon()
        {
            dgvChiTietHD.DataSource = ChiTietHoaDonBUS.Instance.LayDanhSachChiTietHoaDon();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "colMaKH")
            {
                int maKH = Convert.ToInt32(e.Value);
                KhachHangDTO khachHang = KhachHangBUS.Instance.LayThongTinKhachHang(maKH);
                if (khachHang != null)
                {
                    e.Value = khachHang.SDT;
                    e.FormattingApplied = true;
                }
            }

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

        private void dgvChiTietHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTietHD.Columns[e.ColumnIndex].Name == "colMaSP")
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                int maHD = int.Parse(row.Cells["colMaHD"].Value.ToString());
                dgvChiTietHD.DataSource = ChiTietHoaDonBUS.Instance.LayDanhSachChiTietHoaDonTheoMaHoaDon(maHD);
            }
            btnLamMoi.Enabled = true;
            txtSDT.Select();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string SDT = txtSDT.Text;
            KhachHangDTO khachHang = KhachHangBUS.Instance.LayThongTinKhachHangTheoSDT(SDT);

            if (khachHang == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn có số điện thoại trên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvHoaDon.DataSource = HoaDonBUS.Instance.LayDanhSachHoaDonTheoMaKhachHang(khachHang.MaKH);
                LoadDanhSachChiTietHoaDon();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSDT.Text = "";
            LoadDanhSachHoaDon();
            LoadDanhSachChiTietHoaDon();
            btnLamMoi.Enabled = false;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 10)
            {
                btnTimKiem.Enabled = true;
            }
            else
            {
                btnTimKiem.Enabled = false;
            }

            if (txtSDT.Text.Length > 0)
            {
                btnLamMoi.Enabled = true;
            }
            else
            {
                btnLamMoi.Enabled = false;
            }

            LoadDanhSachChiTietHoaDon();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtSDT.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
