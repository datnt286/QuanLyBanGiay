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
    public partial class frmTaiKhoan : Form
    {
        int maNV;
        NhanVienDTO nhanVien;
        int index = 0;
        int trangThai = 1;
        TaiKhoanDTO taiKhoan;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        public frmTaiKhoan(int maNV)
        {
            InitializeComponent();

            this.maNV = maNV;
            nhanVien = NhanVienBUS.Instance.LayThongTinNhanVien(this.maNV);

            if (nhanVien.MaLoaiNV == 2 || nhanVien.MaLoaiNV == 3)
            {
                panel1.Visible = false;
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan();
            txtMatKhauCu.Select();
            dgvTaiKhoan.Columns["colMaTK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachTaiKhoan()
        {
            dgvTaiKhoan.DataSource = TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
        }

        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTaiKhoan.Columns[e.ColumnIndex].Name == "colMaNV")
            {
                int maNV = Convert.ToInt32(e.Value);
                NhanVienDTO nhanVien = NhanVienBUS.Instance.LayThongTinNhanVien(maNV);
                if (nhanVien != null)
                {
                    e.Value = nhanVien.TenNV;
                    e.FormattingApplied = true;
                }
            }

            if (dgvTaiKhoan.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    int trangThai = (int)e.Value;
                    if (trangThai == 1)
                    {
                        e.Value = "Đang hoạt động";
                    }
                    else if (trangThai == 0)
                    {
                        e.Value = "Đã xoá";
                    }
                }
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtMaTK.Text = row.Cells["colMaTK"].Value.ToString();
                txtMaNV.Text = row.Cells["colMaNV"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["colTenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["colMatKhau"].Value.ToString();

                trangThai = int.Parse(dgvTaiKhoan.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString());

                if (trangThai == 1)
                {
                    btnXoa.Text = "Xoá";
                }
                else if (trangThai == 0)
                {
                    btnXoa.Text = "Thêm lại";
                }

                txtMaNV.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;

                btnTao.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            index = 1;

            txtMaTK.Text = (dgvTaiKhoan.RowCount + 1).ToString();
            txtMaNV.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";

            txtMaNV.ReadOnly = false;
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;

            btnTao.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtMaNV.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            index = 2;

            txtMaNV.ReadOnly = false;
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;

            btnTao.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtMaNV.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maTK = int.Parse(txtMaTK.Text);

            if (trangThai == 1)
            {
                if (TaiKhoanBUS.Instance.CapNhatTrangThaiTaiKhoan(maTK, 0))
                {
                    MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
                    LoadDanhSachTaiKhoan();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (trangThai == 0)
            {
                if (TaiKhoanBUS.Instance.CapNhatTrangThaiTaiKhoan(maTK, 1))
                {
                    MessageBox.Show("Thêm lại tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
                    LoadDanhSachTaiKhoan();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm lại tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Luu(index);
            }
        }

        void Luu(int index)
        {
            try
            {
                if (index == 1)
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaNV = int.Parse(txtMaNV.Text);
                    taiKhoan.TenDangNhap = txtTenDangNhap.Text;
                    taiKhoan.MatKhau = txtMatKhau.Text;

                    if (TaiKhoanBUS.Instance.TaoTaiKhoan(taiKhoan))
                    {
                        MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
                        LoadDanhSachTaiKhoan();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Tạo tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (index == 2)
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaTK = int.Parse(txtMaTK.Text); ;
                    taiKhoan.MaNV = int.Parse(txtMaNV.Text);
                    taiKhoan.TenDangNhap = txtTenDangNhap.Text;
                    taiKhoan.MatKhau = txtMatKhau.Text;

                    if (TaiKhoanBUS.Instance.CapNhatTaiKhoan(taiKhoan))
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
                        LoadDanhSachTaiKhoan();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin thất bại! Chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaTK.Text = "";
            txtMaNV.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            btnXoa.Text = "Xoá";

            txtMaNV.ReadOnly = true;
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;

            btnTao.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtMatKhauCu.Select();
        }

        private void chbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienMatKhau.Checked)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtNhapLaiMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtNhapLaiMK.UseSystemPasswordChar = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMK.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string matKhauCu = txtMatKhauCu.Text;
                string matKhauMoi = txtMatKhauMoi.Text;
                string nhapLaiMK = txtNhapLaiMK.Text;
                taiKhoan = TaiKhoanBUS.Instance.LayThongTinTaiKhoan(maNV);
                if (taiKhoan.MatKhau == matKhauCu && matKhauMoi == nhapLaiMK)
                {
                    if (TaiKhoanBUS.Instance.DoiMatKhau(maNV, matKhauMoi))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiKhoanBUS.Instance.LayDanhSachTaiKhoan();
                        LoadDanhSachTaiKhoan();
                        btnHuyDMK_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu hoặc nhập lại mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyDMK_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMK.Text = "";

            btnCapNhat.Enabled = false;
            btnHuyDMK.Enabled = false;
            txtMatKhauCu.Select();
        }

        private void txtMatKhauCu_TextChanged(object sender, EventArgs e)
        {
            btnHuyDMK.Enabled = true;

            if (txtMatKhauCu.Text.Length > 0 && txtMatKhauMoi.Text.Length > 0 && txtNhapLaiMK.Text.Length > 0)
            {
                btnXacNhan.Enabled = true;
            }

            if (txtMatKhauCu.Text.Length == 0 && txtMatKhauMoi.Text.Length == 0 && txtNhapLaiMK.Text.Length == 0)
            {
                btnXacNhan.Enabled = false;
                btnHuyDMK.Enabled = false;
            }
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            btnHuyDMK.Enabled = true;

            if (txtMatKhauCu.Text.Length > 0 && txtMatKhauMoi.Text.Length > 0 && txtNhapLaiMK.Text.Length > 0)
            {
                btnXacNhan.Enabled = true;
            }

            if (txtMatKhauCu.Text.Length == 0 && txtMatKhauMoi.Text.Length == 0 && txtNhapLaiMK.Text.Length == 0)
            {
                btnXacNhan.Enabled = false;
                btnHuyDMK.Enabled = false;
            }
        }

        private void txtNhapLaiMK_TextChanged(object sender, EventArgs e)
        {
            btnHuyDMK.Enabled = true;

            if (txtMatKhauCu.Text.Length > 0 && txtMatKhauMoi.Text.Length > 0 && txtNhapLaiMK.Text.Length > 0)
            {
                btnXacNhan.Enabled = true;
            }

            if (txtMatKhauCu.Text.Length == 0 && txtMatKhauMoi.Text.Length == 0 && txtNhapLaiMK.Text.Length == 0)
            {
                btnXacNhan.Enabled = false;
                btnHuyDMK.Enabled = false;
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
