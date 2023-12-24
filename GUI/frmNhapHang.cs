using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNhapHang : Form
    {
        int maNV;

        public frmNhapHang()
        {
            InitializeComponent();
        }

        public frmNhapHang(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadComboboxNhaCungCap();
            txtSoLuong.Select();
            dgvSanPham.Columns["colMaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhieuNhap.Columns["colMaSP_PN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachSanPham()
        {
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanh();
        }

        void LoadComboboxNhaCungCap()
        {
            List<NhaCungCapDTO> listNCC = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDangHopTac();
            cbbNCC.DataSource = listNCC;
            cbbNCC.ValueMember = "MaNCC";
            cbbNCC.DisplayMember = "TenNCC";
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbNCC.SelectedIndex >= 0)
                {
                    int maNCC = int.Parse(cbbNCC.SelectedValue.ToString());
                    dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamTheoMaNhaCungCap(maNCC);
                }
            }
            catch
            { }
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colMaLoaiSP")
            {
                int maLoaiSP = Convert.ToInt32(e.Value);
                LoaiSanPhamDTO loaiSP = LoaiSanPhamBUS.Instance.LayThongTinLoaiSanPham(maLoaiSP);
                if (loaiSP != null)
                {
                    e.Value = loaiSP.TenLoaiSP;
                    e.FormattingApplied = true;
                }
            }

            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colMaNCC")
            {
                int maNCC = Convert.ToInt32(e.Value);
                NhaCungCapDTO nhaCungCap = NhaCungCapBUS.Instance.LayThongTinNhaCungCap(maNCC);
                if (nhaCungCap != null)
                {
                    e.Value = nhaCungCap.TenNCC;
                    e.FormattingApplied = true;
                }
            }

            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colSize")
            {
                int size = (int)e.Value;
                if (size == 0)
                {
                    e.Value = "Free size";
                }
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["colMaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["colTenSP"].Value.ToString();
                txtGiaNhap.Text = row.Cells["colGiaNhap"].Value.ToString();
                txtSoLuong.ReadOnly = true;

                if (KiemTraSanPhamTrung(int.Parse(row.Cells["colMaSP"].Value.ToString())))
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
                else
                {
                    txtSoLuong.Text = "1";
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["colMaSP_PN"].Value.ToString();
                txtTenSP.Text = row.Cells["colTenSP_PN"].Value.ToString();
                txtGiaNhap.Text = row.Cells["colGiaNhap_PN"].Value.ToString();
                txtSoLuong.Text = row.Cells["colSoLuong_PN"].Value.ToString();
                txtSoLuong.ReadOnly = false;
                txtSoLuong.Select();

                if (KiemTraSanPhamTrung(int.Parse(row.Cells["colMaSP_PN"].Value.ToString())))
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
                else
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow.Index >= 0)
            {
                int maSP = int.Parse(dgvSanPham.CurrentRow.Cells["colMaSP"].Value.ToString());
                if (!KiemTraSanPhamTrung(maSP))
                {
                    dgvPhieuNhap.Rows.Add(dgvSanPham.CurrentRow.Cells["colMaSP"].Value, dgvSanPham.CurrentRow.Cells["colTenSP"].Value, dgvSanPham.CurrentRow.Cells["colGiaBan"].Value, 1);
                    dgvPhieuNhap.CurrentCell = dgvPhieuNhap.Rows[dgvPhieuNhap.Rows.Count - 1].Cells["colSoLuong_PN"];
                }
            }
            CapNhatTongPhieuNhap();

            cbbNCC.Enabled = false;
            txtSoLuong.Text = "1";
            txtSoLuong.ReadOnly = false;
            txtSoLuong.Select();
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        bool KiemTraSanPhamTrung(int maSP)
        {
            if (dgvPhieuNhap.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    int spHD = int.Parse(dgvPhieuNhap.Rows[i].Cells["colMaSP_PN"].Value.ToString());
                    if (spHD == maSP)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow.Index >= 0)
            {
                dgvPhieuNhap.Rows.RemoveAt(dgvPhieuNhap.CurrentRow.Index);
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtGiaNhap.Text = "";
                txtSoLuong.Text = "1";
                btnXoa.Enabled = false;
                cbbNCC.Enabled = false;
            }
            CapNhatTongPhieuNhap();

            if (dgvPhieuNhap.RowCount == 0)
            {
                cbbNCC.Enabled = true;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                txtSoLuong.Text = "1";
            }
            for (int i = 0; i < dgvPhieuNhap.RowCount; i++)
            {
                string maSP = dgvPhieuNhap.Rows[i].Cells["colMaSP_PN"].Value.ToString();
                if (maSP == txtMaSP.Text)
                {
                    dgvPhieuNhap.Rows[i].Cells["colSoLuong_PN"].Value = txtSoLuong.Text;
                }
            }
            CapNhatTongPhieuNhap();
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoLuong.ReadOnly = true;
            }
        }

        void CapNhatTongPhieuNhap()
        {
            decimal tongPN = 0;
            int soLuong = 1;
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                if (dgvPhieuNhap.Rows[i].Cells["colGiaNhap_PN"] != null)
                {
                    decimal giaNhap = decimal.Parse(dgvPhieuNhap.Rows[i].Cells["colGiaNhap_PN"].Value.ToString());

                    if (txtSoLuong.Text != "")
                    {
                        soLuong = int.Parse(dgvPhieuNhap.Rows[i].Cells["colSoLuong_PN"].Value.ToString());
                    }
                    tongPN = tongPN + giaNhap * soLuong;
                }
            }
            txtThanhTien.Text = tongPN.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
                phieuNhap.MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());
                phieuNhap.MaNV = maNV;
                phieuNhap.NgayNhap = DateTime.Now;
                phieuNhap.ThanhTien = decimal.Parse(txtThanhTien.Text);
                PhieuNhapBUS.Instance.ThemPhieuNhap(phieuNhap);
                phieuNhap = PhieuNhapBUS.Instance.LayThongTinPhieuNhapMoiNhat();

                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    ChiTietPhieuNhapDTO chiTietPN = new ChiTietPhieuNhapDTO();
                    chiTietPN.MaPN = phieuNhap.MaPN;
                    chiTietPN.MaSP = int.Parse(dgvPhieuNhap.Rows[i].Cells["colMaSP_PN"].Value.ToString());
                    chiTietPN.SoLuong = int.Parse(dgvPhieuNhap.Rows[i].Cells["colSoLuong_PN"].Value.ToString());
                    chiTietPN.TongTien = decimal.Parse(dgvPhieuNhap.Rows[i].Cells["colGiaNhap_PN"].Value.ToString())
                        * int.Parse(dgvPhieuNhap.Rows[i].Cells["colSoLuong_PN"].Value.ToString());
                    ChiTietPhieuNhapBUS.Instance.ThemChiTietPhieuNhap(chiTietPN);

                    SanPhamDTO sanPham = SanPhamBUS.Instance.LayThongTinSanPham(chiTietPN.MaSP);
                    int maSP = sanPham.MaSP;
                    int soLuong = sanPham.SoLuong + chiTietPN.SoLuong;
                    SanPhamBUS.Instance.CapNhatSoLuongSanPham(maSP, soLuong);
                    dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanh();
                }
                MessageBox.Show("Thanh toán và lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHuy_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán và lưu phiếu nhập thất bại! Chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cbbNCC.SelectedIndex = 0;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaNhap.Text = "";
            txtSoLuong.Text = "1";
            txtThanhTien.Text = "";
            cbbNCC.Enabled = true;
            txtSoLuong.ReadOnly = true;
            dgvPhieuNhap.Rows.Clear();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtSoLuong.Select();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                string newText = textBox.Text;
                if (e.KeyChar != '\b')
                {
                    newText += e.KeyChar.ToString();
                }

                if (!string.IsNullOrEmpty(newText) && newText.Length <= 10)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
