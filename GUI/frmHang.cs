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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHang : Form
    {
        int index = 0;
        int trangThai = 1;

        public frmHang()
        {
            InitializeComponent();
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadComboboxLoaiSanPham();
            LoadComboboxNhaCungCap();
            LoadComboboxTimKiemLoaiSanPham();
            LoadComboboxTimKiemNhaCungCap();
            btnLamMoi_Click(sender, e);
            txtTimKiemTenSP.Select();
            dgvSanPham.Columns["colMaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachSanPham()
        {
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanh();
        }

        void LoadComboboxLoaiSanPham()
        {
            List<LoaiSanPhamDTO> listLoaiSP = LoaiSanPhamBUS.Instance.LayDanhSachLoaiSanPham();
            cbbLoaiSP.DataSource = listLoaiSP;
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
        }

        void LoadComboboxNhaCungCap()
        {
            List<NhaCungCapDTO> listNCC = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDangHopTac();
            cbbNCC.DataSource = listNCC;
            cbbNCC.ValueMember = "MaNCC";
            cbbNCC.DisplayMember = "TenNCC";
        }

        void LoadComboboxTimKiemLoaiSanPham()
        {
            List<LoaiSanPhamDTO> listLoaiSP = LoaiSanPhamBUS.Instance.LayDanhSachLoaiSanPham();
            cbbTimKiemLoaiSP.DataSource = listLoaiSP;
            cbbTimKiemLoaiSP.ValueMember = "MaLoaiSP";
            cbbTimKiemLoaiSP.DisplayMember = "TenLoaiSP";
        }

        void LoadComboboxTimKiemNhaCungCap()
        {
            List<NhaCungCapDTO> listNCC = NhaCungCapBUS.Instance.LayDanhSachNhaCungCapDangHopTac();
            cbbTimKiemNCC.DataSource = listNCC;
            cbbTimKiemNCC.ValueMember = "MaNCC";
            cbbTimKiemNCC.DisplayMember = "TenNCC";
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
                if (e.Value != null)
                {
                    int size = (int)e.Value;
                    if (size == 0)
                    {
                        e.Value = "Free size";
                    }
                }
            }

            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colTrangThai")
            {
                if (e.Value != null)
                {
                    int trangThai = (int)e.Value;
                    if (trangThai == 1)
                    {
                        e.Value = "Đang kinh doanh";
                    }
                    else if (trangThai == 0)
                    {
                        e.Value = "Đã xoá";
                    }
                }
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                try
                {
                    ptbHinhAnh.Image = Image.FromFile(@"sanpham/" + row.Cells["colHinhAnh"].Value.ToString());
                }
                catch
                {
                    ptbHinhAnh.Image = Image.FromFile(@"sanpham/no_image.jpg");
                }
                txtMaSP.Text = row.Cells["colMaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["colTenSP"].Value.ToString();
                txtHinhAnh.Text = row.Cells["colHinhAnh"].Value.ToString();
                txtMauSac.Text = row.Cells["colMauSac"].Value.ToString();
                cbbSize.Text = row.Cells["colSize"].Value.ToString();
                txtSoLuong.Text = row.Cells["colSoLuong"].Value.ToString();
                txtGiaNhap.Text = row.Cells["colGiaNhap"].Value.ToString();
                txtGiaBan.Text = row.Cells["colGiaBan"].Value.ToString();
                decimal loiNhuan = decimal.Parse(row.Cells["colGiaBan"].Value.ToString()) - decimal.Parse(row.Cells["colGiaNhap"].Value.ToString());
                txtLoiNhuan.Text = loiNhuan.ToString();
                cbbLoaiSP.SelectedValue = int.Parse(row.Cells["colMaLoaiSP"].Value.ToString());
                cbbNCC.SelectedValue = int.Parse(row.Cells["colMaNCC"].Value.ToString());

                trangThai = int.Parse(dgvSanPham.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString());

                if (trangThai == 1)
                {
                    btnXoa.Text = "Xoá";
                }
                else if (trangThai == 0)
                {
                    btnXoa.Text = "Thêm lại";
                }

                txtMaSP.ReadOnly = Enabled;
                txtTenSP.ReadOnly = Enabled;
                txtHinhAnh.ReadOnly = Enabled;
                txtMauSac.ReadOnly = Enabled;
                cbbSize.Enabled = false;
                txtSoLuong.ReadOnly = Enabled;
                txtGiaNhap.ReadOnly = Enabled;
                txtGiaBan.ReadOnly = Enabled;
                cbbLoaiSP.Enabled = false;
                cbbNCC.Enabled = false;

                btnChonAnh.Enabled = false;
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                txtTimKiemTenSP.Select();
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

            SanPhamDTO sanPham = SanPhamBUS.Instance.LayThongTinSanPhamMoiNhat();
            txtMaSP.Text = (sanPham.MaSP + 1).ToString();
            txtTenSP.Text = "";
            txtHinhAnh.Text = "";
            txtMauSac.Text = "";
            cbbSize.SelectedValue = 0;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtLoiNhuan.Text = "";
            cbbLoaiSP.SelectedIndex = 0;
            cbbNCC.SelectedIndex = 0;
            ptbHinhAnh.Image = null;

            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = false;
            txtHinhAnh.ReadOnly = true;
            txtMauSac.ReadOnly = false;
            cbbSize.Enabled = true;
            txtSoLuong.ReadOnly = false;
            txtGiaNhap.ReadOnly = false;
            txtGiaBan.ReadOnly = false;
            cbbLoaiSP.Enabled = true;
            cbbNCC.Enabled = true;

            btnChonAnh.Enabled = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenSP.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            index = 2;

            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = false;
            txtHinhAnh.ReadOnly = true;
            txtMauSac.ReadOnly = false;
            cbbSize.Enabled = true;
            txtSoLuong.ReadOnly = false;
            txtGiaNhap.ReadOnly = false;
            txtGiaBan.ReadOnly = false;
            cbbLoaiSP.Enabled = true;
            cbbNCC.Enabled = true;

            btnChonAnh.Enabled = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTenSP.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(txtMaSP.Text);

            if (trangThai == 1)
            {
                if (SanPhamBUS.Instance.CapNhatTrangThaiSanPham(maSP, 0))
                {
                    MessageBox.Show("Xoá sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SanPhamBUS.Instance.LayDanhSachSanPham();
                    LoadDanhSachSanPham();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xoá sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (trangThai == 0)
            {
                if (SanPhamBUS.Instance.CapNhatTrangThaiSanPham(maSP, 1))
                {
                    MessageBox.Show("Thêm lại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SanPhamBUS.Instance.LayDanhSachSanPham();
                    LoadDanhSachSanPham();
                    btnHuy_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm lại sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ptbHinhAnh.Image == null || txtTenSP.Text == "" || txtMauSac.Text == "" || txtSoLuong.Text == "" || txtGiaNhap.Text == "" || txtGiaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (int.Parse(cbbSize.Text) < 35 || int.Parse(cbbSize.Text) > 49 || txtGiaBan.Text.Length > 9 || txtGiaNhap.Text.Length > 9 || txtSoLuong.Text.Length > 9 || decimal.Parse(txtGiaNhap.Text) > decimal.Parse(txtGiaBan.Text))
                {
                    MessageBox.Show("Thông tin sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = int.Parse(txtMaSP.Text);
                    sanPham.TenSP = txtTenSP.Text;
                    sanPham.HinhAnh = txtHinhAnh.Text;
                    sanPham.MauSac = txtMauSac.Text;
                    sanPham.Size = int.Parse(cbbSize.Text);
                    sanPham.SoLuong = int.Parse(txtSoLuong.Text);
                    sanPham.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                    sanPham.GiaBan = decimal.Parse(txtGiaBan.Text);
                    sanPham.MaLoaiSP = int.Parse(cbbLoaiSP.SelectedValue.ToString());
                    sanPham.MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());

                    string path = @"sanpham\" + txtHinhAnh.Text;

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

                    if (SanPhamBUS.Instance.ThemSanPham(sanPham))
                    {
                        ptbHinhAnh.Image.Save(@"sanpham/" + txtHinhAnh.Text);
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SanPhamBUS.Instance.LayDanhSachSanPham();
                        LoadDanhSachSanPham();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (index == 2)
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    sanPham.MaSP = int.Parse(txtMaSP.Text);
                    sanPham.TenSP = txtTenSP.Text;
                    sanPham.HinhAnh = txtHinhAnh.Text;
                    sanPham.MauSac = txtMauSac.Text;
                    sanPham.Size = int.Parse(cbbSize.Text);
                    sanPham.SoLuong = int.Parse(txtSoLuong.Text);
                    sanPham.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                    sanPham.GiaBan = decimal.Parse(txtGiaBan.Text);
                    sanPham.MaLoaiSP = int.Parse(cbbLoaiSP.SelectedValue.ToString());
                    sanPham.MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());

                    string path = @"sanpham\" + txtHinhAnh.Text;

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

                    if (SanPhamBUS.Instance.CapNhatSanPham(sanPham))
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SanPhamBUS.Instance.LayDanhSachSanPham();
                        LoadDanhSachSanPham();
                        btnHuy_Click(btnHuy, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtHinhAnh.Text = "";
            txtMauSac.Text = "";
            cbbSize.SelectedIndex = 0;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtLoiNhuan.Text = "";
            cbbLoaiSP.SelectedIndex = 0;
            cbbNCC.SelectedIndex = 0;
            btnXoa.Text = "Xoá";

            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = true;
            txtHinhAnh.ReadOnly = true;
            txtMauSac.ReadOnly = true;
            cbbSize.Enabled = false;
            txtSoLuong.ReadOnly = true;
            txtGiaNhap.ReadOnly = true;
            txtGiaBan.ReadOnly = true;
            cbbLoaiSP.Enabled = false;
            cbbNCC.Enabled = false;

            btnChonAnh.Enabled = false;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiemTenSP.Select();
        }

        private void txtTimKiemTenSP_TextChanged(object sender, EventArgs e)
        {
            string tenSP = txtTimKiemTenSP.Text;
            dgvSanPham.DataSource = SanPhamBUS.Instance.TimKiemSanPham(tenSP);
            btnHuy_Click(btnHuy, EventArgs.Empty);
        }

        private void cbbTimKiemLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        private void cbbTimKiemNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        void TimKiemSanPham()
        {
            try
            {
                if (cbbTimKiemNCC.SelectedIndex >= 0 && cbbTimKiemLoaiSP.SelectedIndex >= 0)
                {
                    string tenSP = txtTimKiemTenSP.Text;
                    int maLoaiSP = int.Parse(cbbTimKiemLoaiSP.SelectedValue.ToString());
                    int maNCC = int.Parse(cbbTimKiemNCC.SelectedValue.ToString());
                    dgvSanPham.DataSource = SanPhamBUS.Instance.TimKiemSanPhamTheoMaLoaiSanPhamVaMaNhaCungCap(tenSP, maLoaiSP, maNCC);
                    btnHuy_Click(btnHuy, EventArgs.Empty);
                }
            }
            catch
            { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiemTenSP.Text = "";
            cbbTimKiemLoaiSP.SelectedIndex = 0;
            cbbTimKiemNCC.SelectedIndex = 0;
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanh();
            btnHuy_Click(sender, e);
        }

        private void btnXemSPDaXoa_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDaXoa();
            btnHuy_Click(sender, e);
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBan.Text == "")
            {
                txtGiaBan.Text = "0";
            }

            decimal giaBan = decimal.Parse(txtGiaBan.Text);
            decimal temp = 0;

            if (txtGiaNhap.Text != "")
            {
                temp = decimal.Parse(txtGiaNhap.Text);
            }

            decimal loiNhuan = 0;

            if (giaBan < temp)
            {
                if (giaBan < 0)
                {
                    txtGiaBan.Text = "0";
                }
            }
            else if (giaBan == 0 || temp == 0)
            {
                txtGiaBan.Text = "0";
            }
            else
            {
                loiNhuan = giaBan - temp;
            }

            decimal soDu = loiNhuan % 1000;
            loiNhuan = loiNhuan - soDu;
            txtLoiNhuan.Text = loiNhuan.ToString();
        }

        private void txtMauSac_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}

