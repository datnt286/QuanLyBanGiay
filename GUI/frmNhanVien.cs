using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        int index = 0;
        int trangThai = 1;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
            LoadComboboxLoaiNhanVien();
            LoadComboboxTimKiemLoaiNhanVien();
            btnLamMoi_Click(sender, e);
            txtTimKiemTenNV.Select();
            dgvNhanVien.Columns["colMaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachNhanVien()
        {
            dgvNhanVien.DataSource = NhanVienBUS.Instance.LayDanhSachNhanVienDangHoatDong();
        }

        void LoadComboboxLoaiNhanVien()
        {
            List<LoaiNhanVienDTO> listLoaiNV = LoaiNhanVienBUS.Instance.LayDanhSachLoaiNhanVien();
            cbbLoaiNV.DataSource = listLoaiNV;
            cbbLoaiNV.ValueMember = "MaLoaiNV";
            cbbLoaiNV.DisplayMember = "TenLoaiNV";
        }

        void LoadComboboxTimKiemLoaiNhanVien()
        {
            List<LoaiNhanVienDTO> listLoaiNV = LoaiNhanVienBUS.Instance.LayDanhSachLoaiNhanVien();
            cbbTimKiemLoaiNV.DataSource = listLoaiNV;
            cbbTimKiemLoaiNV.ValueMember = "MaLoaiNV";
            cbbTimKiemLoaiNV.DisplayMember = "TenLoaiNV";
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "colMaLoaiNV")
            {
                int maLoaiNV = Convert.ToInt32(e.Value);
                LoaiNhanVienDTO loaiNV = LoaiNhanVienBUS.Instance.LayThongTinLoaiNhanVien(maLoaiNV);
                if (loaiNV != null)
                {
                    e.Value = loaiNV.TenLoaiNV;
                    e.FormattingApplied = true;
                }
            }

            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "colTrangThai")
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                try
                {
                    ptbHinhAnh.Image = Image.FromFile(@"nhanvien/" + row.Cells["colHinhAnh"].Value.ToString());
                }
                catch
                {
                    ptbHinhAnh.Image = Image.FromFile(@"nhanvien/no_image.jpg");
                }
                txtMaNV.Text = row.Cells["colMaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["colTenNV"].Value.ToString();
                txtHinhAnh.Text = row.Cells["colHinhAnh"].Value.ToString();
                txtSDT.Text = row.Cells["colSDT"].Value.ToString();
                txtEmail.Text = row.Cells["colEmail"].Value.ToString();
                txtDiaChi.Text = row.Cells["colDiaChi"].Value.ToString();
                dtpNgayVaoLam.Text = row.Cells["colNgayVaoLam"].Value.ToString();
                txtLuong.Text = row.Cells["colLuong"].Value.ToString();
                cbbLoaiNV.SelectedValue = int.Parse(row.Cells["colMaLoaiNV"].Value.ToString());

                trangThai = int.Parse(dgvNhanVien.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString());

                if (trangThai == 1)
                {
                    btnXoa.Text = "Xoá";
                }
                else if (trangThai == 0)
                {
                    btnXoa.Text = "Thêm lại";
                }

                txtTenNV.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtLuong.ReadOnly = true;
                dtpNgayVaoLam.Enabled = false;
                cbbLoaiNV.Enabled = false;

                btnChonAnh.Enabled = false;
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                txtTimKiemTenNV.Select();
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Chọn ảnh";
                openFileDialog.Filter = "All files (*.*)|*.*|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    txtHinhAnh.Text = Path.GetFileName(filePath);
                    ptbHinhAnh.Image = Image.FromFile(filePath);
                }
            }
            catch
            {
                MessageBox.Show("Dung lượng ảnh quá lớn! Vui lòng chọn ảnh khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            index = 1;

            NhanVienDTO nhanVien = NhanVienBUS.Instance.LayThongTinNhanVienMoiNhat();
            txtMaNV.Text = (nhanVien.MaNV + 1).ToString();
            txtTenNV.Text = "";
            txtHinhAnh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
            dtpNgayVaoLam.Text = "";
            cbbLoaiNV.SelectedIndex = 0;
            ptbHinhAnh.Image = null;

            txtTenNV.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtLuong.ReadOnly = false;
            dtpNgayVaoLam.Enabled = true;
            cbbLoaiNV.Enabled = true;

            btnChonAnh.Enabled = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenNV.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            index = 2;

            txtTenNV.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtLuong.ReadOnly = false;
            dtpNgayVaoLam.Enabled = true;
            cbbLoaiNV.Enabled = true;

            btnChonAnh.Enabled = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenNV.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(txtMaNV.Text);

            if (trangThai == 1)
            {
                if (NhanVienBUS.Instance.CapNhatTrangThaiNhanVien(maNV, 0))
                {
                    MessageBox.Show("Xoá nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVienBUS.Instance.LayDanhSachNhanVien();
                    LoadDanhSachNhanVien();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (trangThai == 0)
            {
                if (NhanVienBUS.Instance.CapNhatTrangThaiNhanVien(maNV, 1))
                {
                    MessageBox.Show("Thêm lại nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVienBUS.Instance.LayDanhSachNhanVien();
                    LoadDanhSachNhanVien();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm lại nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ptbHinhAnh.Image == null || txtTenNV.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || txtDiaChi.Text == "" || txtLuong.Text == "")
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
                else if (txtLuong.Text.Length > 9)
                {
                    MessageBox.Show("Lương không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = int.Parse(txtMaNV.Text);
                    nhanVien.TenNV = txtTenNV.Text;
                    nhanVien.SDT = txtSDT.Text;
                    nhanVien.Email = txtEmail.Text;
                    nhanVien.DiaChi = txtDiaChi.Text;
                    nhanVien.NgayVaoLam = dtpNgayVaoLam.Value;
                    nhanVien.Luong = decimal.Parse(txtLuong.Text);
                    nhanVien.HinhAnh = txtHinhAnh.Text;
                    nhanVien.MaLoaiNV = int.Parse(cbbLoaiNV.SelectedValue.ToString());

                    string path = @"nhanvien\" + txtHinhAnh.Text;

                    if (File.Exists(path))
                    {
                        DialogResult result = MessageBox.Show("Hình đã tồn tại", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            return;
                        }
                    }

                    try
                    {
                        if (File.Exists(path))
                        {
                            using (Image image = Image.FromFile(path))
                            {
                                ptbHinhAnh.Image?.Dispose();
                                ptbHinhAnh.Image = new Bitmap(image);
                                string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
                                ptbHinhAnh.Image.Save(tempPath);
                                File.Delete(path);
                                File.Move(tempPath, path);
                            }
                        }
                        else
                        {
                            ptbHinhAnh.Image.Save(path);
                        }
                    }
                    catch
                    { }

                    if (NhanVienBUS.Instance.ThemNhanVien(nhanVien))
                    {
                        ptbHinhAnh.Image.Save(@"nhanvien/" + txtHinhAnh.Text);
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NhanVienBUS.Instance.LayDanhSachNhanVien();
                        LoadDanhSachNhanVien();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (index == 2)
                {
                    NhanVienDTO nhanVien = new NhanVienDTO();
                    nhanVien.MaNV = int.Parse(txtMaNV.Text);
                    nhanVien.TenNV = txtTenNV.Text;
                    nhanVien.SDT = txtSDT.Text;
                    nhanVien.Email = txtEmail.Text;
                    nhanVien.DiaChi = txtDiaChi.Text;
                    nhanVien.NgayVaoLam = dtpNgayVaoLam.Value;
                    nhanVien.Luong = decimal.Parse(txtLuong.Text);
                    nhanVien.HinhAnh = txtHinhAnh.Text;
                    nhanVien.MaLoaiNV = int.Parse(cbbLoaiNV.SelectedValue.ToString());

                    string path = @"nhanvien\" + txtHinhAnh.Text;

                    try
                    {
                        if (File.Exists(path))
                        {
                            using (Image image = Image.FromFile(path))
                            {
                                ptbHinhAnh.Image?.Dispose();
                                ptbHinhAnh.Image = new Bitmap(image);
                                string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
                                ptbHinhAnh.Image.Save(tempPath);
                                File.Delete(path);
                                File.Move(tempPath, path);
                            }
                        }
                        else
                        {
                            ptbHinhAnh.Image.Save(path);
                        }
                    }
                    catch
                    { }

                    if (NhanVienBUS.Instance.CapNhatNhanVien(nhanVien))
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NhanVienBUS.Instance.LayDanhSachNhanVien();
                        LoadDanhSachNhanVien();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ptbHinhAnh.Image = null;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtHinhAnh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
            dtpNgayVaoLam.Text = "";
            cbbLoaiNV.SelectedIndex = 0;
            btnXoa.Text = "Xoá";

            txtTenNV.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtLuong.ReadOnly = true;
            dtpNgayVaoLam.Enabled = true;
            cbbLoaiNV.Enabled = false;

            btnChonAnh.Enabled = false;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiemTenNV.Select();
        }

        private void txtTimKiemTenNV_TextChanged(object sender, EventArgs e)
        {
            string tenNV = txtTimKiemTenNV.Text;
            dgvNhanVien.DataSource = NhanVienBUS.Instance.TimKiemNhanVien(tenNV);
            btnHuy_Click(sender, e);
        }

        private void cbbTimKiemLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTimKiemLoaiNV.SelectedIndex >= 0)
                {
                    int maLoaiNV = int.Parse(cbbTimKiemLoaiNV.SelectedValue.ToString());
                    string tenNV = txtTimKiemTenNV.Text;
                    dgvNhanVien.DataSource = NhanVienBUS.Instance.TimKiemNhanVienTheoMaLoaiNhanVien(tenNV, maLoaiNV);
                    btnHuy_Click(sender, e);
                }
            }
            catch
            { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiemTenNV.Text = "";
            txtTimKiemTenNV.Select();
            cbbTimKiemLoaiNV.SelectedIndex = 0;
            dgvNhanVien.DataSource = NhanVienBUS.Instance.LayDanhSachNhanVienDangHoatDong();
            btnHuy_Click(sender, e);
        }

        private void btnXemNVDaXoa_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = NhanVienBUS.Instance.LayDanhSachNhanVienDaXoa();
            btnHuy_Click(sender, e);
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemTenNV_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
