using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class frmNhaCungCap : Form
    {
        int index = 0;
        int trangThai = 1;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhaCungCap();
            txtTimKiemTenNCC.Select();
            dgvNhaCungCap.Columns["colMaNCC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachNhaCungCap()
        {
            dgvNhaCungCap.DataSource = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDangHopTac();
        }

        private void dgvNhaCungCap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhaCungCap.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    int trangThai = (int)e.Value;
                    if (trangThai == 1)
                    {
                        e.Value = "Đang hợp tác";
                    }
                    else if (trangThai == 0)
                    {
                        e.Value = "Đã xoá";
                    }
                }
            }
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["colMaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["colTenNCC"].Value.ToString();
                txtSDT.Text = row.Cells["colSDT"].Value.ToString();
                txtEmail.Text = row.Cells["colEmail"].Value.ToString();
                txtDiaChi.Text = row.Cells["colDiaChi"].Value.ToString();

                trangThai = int.Parse(dgvNhaCungCap.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString());

                if (trangThai == 1)
                {
                    btnXoa.Text = "Xoá";
                }
                else if (trangThai == 0)
                {
                    btnXoa.Text = "Thêm lại";
                }

                txtTenNCC.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;

                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                txtTimKiemTenNCC.Select();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            index = 1;

            txtMaNCC.Text = (dgvNhaCungCap.RowCount + 1).ToString();
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";

            txtTenNCC.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenNCC.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            index = 2;

            txtTenNCC.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenNCC.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNCC = int.Parse(txtMaNCC.Text);

            if (trangThai == 1)
            {
                if (NhaCungCapBUS.Instance.CapNhatTrangThaiNhaCungCap(maNCC, 0))
                {
                    MessageBox.Show("Xoá nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhaCungCapBUS.Instance.LayDanhSachNhaCungCap();
                    LoadDanhSachNhaCungCap();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá nhà cung cấp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (trangThai == 0)
            {
                if (NhaCungCapBUS.Instance.CapNhatTrangThaiNhaCungCap(maNCC, 1))
                {
                    MessageBox.Show("Thêm lại nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhaCungCapBUS.Instance.LayDanhSachNhaCungCap();
                    LoadDanhSachNhaCungCap();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm lại nhà cung cấp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Luu(index);
                }
            }
        }

        void Luu(int index)
        {
            try
            {
                if (index == 1)
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = int.Parse(txtMaNCC.Text);
                    nhaCungCap.TenNCC = txtTenNCC.Text;
                    nhaCungCap.SDT = txtSDT.Text;
                    nhaCungCap.Email = txtEmail.Text;
                    nhaCungCap.DiaChi = txtDiaChi.Text;

                    if (NhaCungCapBUS.Instance.ThemNhaCungCap(nhaCungCap))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NhaCungCapBUS.Instance.LayDanhSachNhaCungCap();
                        LoadDanhSachNhaCungCap();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (index == 2)
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNCC = int.Parse(txtMaNCC.Text);
                    nhaCungCap.TenNCC = txtTenNCC.Text;
                    nhaCungCap.SDT = txtSDT.Text;
                    nhaCungCap.Email = txtEmail.Text;
                    nhaCungCap.DiaChi = txtDiaChi.Text;

                    if (NhaCungCapBUS.Instance.CapNhatNhaCungCap(nhaCungCap))
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NhaCungCapBUS.Instance.LayDanhSachNhaCungCap();
                        LoadDanhSachNhaCungCap();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            btnXoa.Text = "Xoá";

            txtTenNCC.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiemTenNCC.Select();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiemTenNCC.Text = "";
            txtTimKiemTenNCC.Select();
            dgvNhaCungCap.DataSource = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDangHopTac();
            btnHuy_Click(sender, e);
        }

        private void btnXemNCCDaXoa_Click(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDaXoa();
            btnHuy_Click(sender, e);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemTenNCC_TextChanged(object sender, EventArgs e)
        {
            string tenNCC = txtTimKiemTenNCC.Text;
            dgvNhaCungCap.DataSource = NhaCungCapBUS.Instance.TimKiemNhaCungCap(tenNCC);
            btnHuy_Click(sender, e);
        }
    }
}
