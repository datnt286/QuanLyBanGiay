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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhap();
            LoadDanhSachChiTietPhieuNhap();
            LoadComboboxNhaCungCap();
            btnLamMoi_Click(sender, e);
            dgvPhieuNhap.Columns["colMaPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietPN.Columns["colMaCTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietPN.Columns["colMaPN_CTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachPhieuNhap()
        {
            dgvPhieuNhap.DataSource = PhieuNhapBUS.Instance.LayDanhSachPhieuNhap();
        }

        void LoadDanhSachChiTietPhieuNhap()
        {
            dgvChiTietPN.DataSource = ChiTietPhieuNhapBUS.Instance.LayDanhSachChiTietPhieuNhap();
        }

        void LoadComboboxNhaCungCap()
        {
            List<NhaCungCapDTO> listNCC = NhaCungCapBUS.Instance.LayDanhSachNhaCungCap();
            cbbNCC.DataSource = listNCC;
            cbbNCC.ValueMember = "MaNCC";
            cbbNCC.DisplayMember = "TenNCC";
        }

        private void dgvPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "colMaNCC")
            {
                int maNCC = Convert.ToInt32(e.Value);
                NhaCungCapDTO nhaCungCap = NhaCungCapBUS.Instance.LayThongTinNhaCungCap(maNCC);
                if (nhaCungCap != null)
                {
                    e.Value = nhaCungCap.TenNCC;
                    e.FormattingApplied = true;
                }
            }

            if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "colMaNV")
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

        private void dgvChiTietPN_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTietPN.Columns[e.ColumnIndex].Name == "colMaSP")
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

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                int maPN = int.Parse(row.Cells["colMaPN"].Value.ToString());
                dgvChiTietPN.DataSource = ChiTietPhieuNhapBUS.Instance.LayDanhSachChiTietPhieuNhapTheoMaPhieuNhap(maPN);
            }
            btnLamMoi.Enabled = true;
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbNCC.SelectedIndex >= 0)
                {
                    int maNCC = int.Parse(cbbNCC.SelectedValue.ToString());
                    dgvPhieuNhap.DataSource = PhieuNhapBUS.Instance.LayDanhSachPhieuNhapTheoMaNhaCungCap(maNCC);
                    LoadDanhSachChiTietPhieuNhap();
                    btnLamMoi.Enabled = true;
                }
            }
            catch
            { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbNCC.SelectedIndex = 0;
            btnLamMoi.Enabled = false;
            LoadDanhSachPhieuNhap();
            LoadDanhSachChiTietPhieuNhap();
        }
    }
}
