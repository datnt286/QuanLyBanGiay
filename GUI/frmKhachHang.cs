using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        int index = 0;
        int trangThai = 1;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            txtTimKiemTenKH.Select();
            dgvKhachHang.Columns["colMaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachKhachHang()
        {
            dgvKhachHang.DataSource = KhachHangBUS.Instance.LayDanhSachKhachHangDaLuu();
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    int trangThai = (int)e.Value;
                    if (trangThai == 1)
                    {
                        e.Value = "Đã lưu";
                    }
                    else if (trangThai == 0)
                    {
                        e.Value = "Đã xoá";
                    }
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["colMaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["colTenKH"].Value.ToString();
                txtSDT.Text = row.Cells["colSDT"].Value.ToString();
                dtpNgayDangKy.Text = row.Cells["colNgayDangKy"].Value.ToString();
                txtEmail.Text = row.Cells["colEmail"].Value.ToString();
                txtDiaChi.Text = row.Cells["colDiaChi"].Value.ToString();

                trangThai = int.Parse(dgvKhachHang.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString());

                if (trangThai == 1)
                {
                    btnXoa.Text = "Xoá";
                }
                else if (trangThai == 0)
                {
                    btnXoa.Text = "Thêm lại";
                }

                txtTenKH.ReadOnly = true;
                txtSDT.ReadOnly = true;
                dtpNgayDangKy.Enabled = false;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;

                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                txtTimKiemTenKH.Select();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            index = 1;

            txtMaKH.Text = (dgvKhachHang.RowCount + 1).ToString();
            txtTenKH.Text = "";
            txtSDT.Text = "";
            dtpNgayDangKy.Value = DateTime.Now;
            txtEmail.Text = "";
            txtDiaChi.Text = "";

            txtTenKH.ReadOnly = false;
            txtSDT.ReadOnly = false;
            dtpNgayDangKy.Enabled = true;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenKH.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            index = 2;

            txtTenKH.ReadOnly = false;
            txtSDT.ReadOnly = false;
            dtpNgayDangKy.Enabled = true;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenKH.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maKH = int.Parse(txtMaKH.Text);

            if (trangThai == 1)
            {
                if (KhachHangBUS.Instance.CapNhatTrangThaiKhachHang(maKH, 0))
                {
                    MessageBox.Show("Xoá khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhachHangBUS.Instance.LayDanhSachKhachHang();
                    LoadDanhSachKhachHang();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (trangThai == 0)
            {
                if (KhachHangBUS.Instance.CapNhatTrangThaiKhachHang(maKH, 1))
                {
                    MessageBox.Show("Thêm lại khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhachHangBUS.Instance.LayDanhSachKhachHang();
                    LoadDanhSachKhachHang();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm lại khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@gmail\.com$") && txtEmail.Text.Length > 0)
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Luu(index);
                }
            }
        }

        private void Luu(int index)
        {
            try
            {
                if (index == 1)
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.TenKH = txtTenKH.Text;
                    khachHang.SDT = txtSDT.Text;
                    khachHang.NgayDangKy = dtpNgayDangKy.Value;
                    khachHang.Email = txtEmail.Text;
                    khachHang.DiaChi = txtDiaChi.Text;

                    if (KhachHangBUS.Instance.ThemKhachHang(khachHang))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhachHangBUS.Instance.LayDanhSachKhachHang();
                        LoadDanhSachKhachHang();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (index == 2)
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.MaKH = int.Parse(txtMaKH.Text);
                    khachHang.TenKH = txtTenKH.Text;
                    khachHang.SDT = txtSDT.Text;
                    khachHang.NgayDangKy = dtpNgayDangKy.Value;
                    khachHang.Email = txtEmail.Text;
                    khachHang.DiaChi = txtDiaChi.Text;

                    if (KhachHangBUS.Instance.CapNhatKhachHang(khachHang))
                    {
                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhachHangBUS.Instance.LayDanhSachKhachHang();
                        LoadDanhSachKhachHang();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            dtpNgayDangKy.Value = DateTime.Now;
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            btnXoa.Text = "Xoá";

            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            dtpNgayDangKy.Enabled = false;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiemTenKH.Select();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiemTenKH.Text = "";
            txtTimKiemTenKH.Select();
            dgvKhachHang.DataSource = KhachHangBUS.Instance.LayDanhSachKhachHangDaLuu();
            btnHuy_Click(sender, e);
        }

        private void btnXemKHDaXoa_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = KhachHangBUS.Instance.LayDanhSachKhachHangDaXoa();
            btnHuy_Click(sender, e);
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemTenKH_TextChanged(object sender, EventArgs e)
        {
            string tenKH = txtTimKiemTenKH.Text;
            dgvKhachHang.DataSource = KhachHangBUS.Instance.TimKiemKhachHang(tenKH);
            btnHuy_Click(sender, e);
        }
    }
}
