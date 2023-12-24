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
    public partial class frmBanHang : Form
    {
        int maNV;
        decimal tienKhachTra = 0;
        decimal tienThanhToan = 0;

        public frmBanHang()
        {
            InitializeComponent();
        }

        public frmBanHang(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadComboboxLoaiSanPham();
            LoadComboboxNhaCungCap();
            LoadComboboxNhanVienLap();
            btnLamMoi_Click(sender, e);
            cbbNVLap.SelectedValue = maNV;
            txtSDT.Select();
            dgvSanPham.Columns["colMaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["colMaSP_HD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void LoadDanhSachSanPham()
        {
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanhVaConHang();
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

        void LoadComboboxNhanVienLap()
        {
            List<NhanVienDTO> listNVLap = NhanVienBUS.Instance.LayDanhSachNhanVienBanHang();
            cbbNVLap.DataSource = listNVLap;
            cbbNVLap.ValueMember = "MaNV";
            cbbNVLap.DisplayMember = "TenNV";
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
            }

            btnCong.Enabled = true;
            txtTenSP.Select();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(dgvSanPham.CurrentRow.Cells["colMaSP"].Value.ToString());
            if (!KiemTraSanPhamTrung(maSP))
            {
                dgvHoaDon.Rows.Add(dgvSanPham.CurrentRow.Cells["colMaSP"].Value, dgvSanPham.CurrentRow.Cells["colTenSP"].Value, dgvSanPham.CurrentRow.Cells["colGiaBan"].Value, 1);
                dgvHoaDon.CurrentCell = dgvHoaDon.Rows[dgvHoaDon.Rows.Count - 1].Cells["colSoLuong_HD"];
            }
            else
            {
                int maSP_HD = int.Parse(dgvHoaDon.CurrentRow.Cells["colMaSP_HD"].Value.ToString());
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    int cellMaSP = int.Parse(row.Cells["colMaSP"].Value.ToString());
                    if (cellMaSP == maSP_HD)
                    {
                        int soLuongCoSan = int.Parse(row.Cells["colSoLuong"].Value.ToString());
                        int soLuongMua = int.Parse(dgvHoaDon.CurrentRow.Cells["colSoLuong_HD"].Value.ToString());
                        if (soLuongMua > soLuongCoSan - 1)
                        {
                            MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            dgvHoaDon.CurrentRow.Cells["colSoLuong_HD"].Value = ++soLuongMua;
                        }
                        break;
                    }
                }
            }
            CapNhatTongHoaDon();

            btnTru.Enabled = true;
            btnHuy.Enabled = true;
        }

        bool KiemTraSanPhamTrung(int maSP)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                {
                    int spHD = int.Parse(dgvHoaDon.Rows[i].Cells["colMaSP_HD"].Value.ToString());
                    if (spHD == maSP)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            int soLuong = int.Parse(dgvHoaDon.CurrentRow.Cells["colSoLuong_HD"].Value.ToString());
            if (soLuong > 1)
            {
                dgvHoaDon.CurrentRow.Cells["colSoLuong_HD"].Value = --soLuong;
            }
            else
            {
                dgvHoaDon.Rows.RemoveAt(dgvHoaDon.CurrentRow.Index);
            }

            CapNhatTongHoaDon();
            btnHuy.Enabled = true;

            if (dgvHoaDon.Rows.Count == 0)
            {
                btnTru.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        void CapNhatTongHoaDon()
        {
            decimal tongHD = 0;
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                if (dgvHoaDon.Rows[i].Cells["colGiaBan_HD"] != null)
                {
                    decimal giaBan = decimal.Parse(dgvHoaDon.Rows[i].Cells["colGiaBan_HD"].Value.ToString());
                    int soLuong = int.Parse(dgvHoaDon.Rows[i].Cells["colSoLuong_HD"].Value.ToString());
                    tongHD = tongHD + giaBan * soLuong;
                }
            }
            txtThanhTien.Text = tongHD.ToString();
        }

        private void txtTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhachTra.Text == "")
            {
                txtTienKhachTra.Text = "0";
            }

            tienKhachTra = decimal.Parse(txtTienKhachTra.Text);
            tienThanhToan = 0;

            if (txtThanhTien.Text != "")
            {
                tienThanhToan = decimal.Parse(txtThanhTien.Text);
            }

            decimal tienThua = 0;

            if (tienKhachTra < tienThanhToan)
            {
                if (tienKhachTra < 0)
                {
                    txtTienKhachTra.Text = "0";
                }
            }
            else if (tienKhachTra == 0 || tienThanhToan == 0)
            {
                txtTienKhachTra.Text = "0";
            }
            else
            {
                tienThua = tienKhachTra - tienThanhToan;
            }

            decimal soDu = tienThua % 1000;
            tienThua = tienThua - soDu;
            txtTienThua.Text = tienThua.ToString();

            if (tienKhachTra > tienThanhToan && txtTenKH.Text.Length > 0 && txtSDT.Text.Length == 10)
            {
                btnThanhToan.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = false;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string SDT = txtSDT.Text;
                KhachHangDTO khachHang;
                if (!KhachHangBUS.Instance.KiemTraSDTTrung(SDT))
                {
                    khachHang = new KhachHangDTO();
                    khachHang.TenKH = txtTenKH.Text;
                    khachHang.SDT = SDT;
                    khachHang.NgayDangKy = DateTime.Now;
                    khachHang.Email = "";
                    khachHang.DiaChi = "";
                    KhachHangBUS.Instance.ThemKhachHang(khachHang);
                    khachHang = KhachHangBUS.Instance.LayThongTinKhachHangMoiNhat();
                }
                else
                {
                    khachHang = KhachHangBUS.Instance.LayThongTinKhachHangTheoSDT(SDT);
                }

                if (khachHang != null)
                {
                    HoaDonDTO hoaDon = new HoaDonDTO();
                    hoaDon.MaKH = khachHang.MaKH;
                    hoaDon.MaNV = int.Parse(cbbNVLap.SelectedValue.ToString());
                    hoaDon.NgayLap = DateTime.Now;
                    hoaDon.ThanhTien = decimal.Parse(txtThanhTien.Text);
                    HoaDonBUS.Instance.ThemHoaDon(hoaDon);
                    hoaDon = HoaDonBUS.Instance.LayThongTinHoaDonMoiNhat();

                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        ChiTietHoaDonDTO chiTietHD = new ChiTietHoaDonDTO();
                        chiTietHD.MaHD = hoaDon.MaHD;
                        chiTietHD.MaSP = int.Parse(dgvHoaDon.Rows[i].Cells["colMaSP_HD"].Value.ToString());
                        chiTietHD.SoLuong = int.Parse(dgvHoaDon.Rows[i].Cells["colSoLuong_HD"].Value.ToString());
                        chiTietHD.TongTien = decimal.Parse(dgvHoaDon.Rows[i].Cells["colGiaBan_HD"].Value.ToString())
                            * int.Parse(dgvHoaDon.Rows[i].Cells["colSoLuong_HD"].Value.ToString());
                        ChiTietHoaDonBUS.Instance.ThemChiTietHoaDon(chiTietHD);

                        SanPhamDTO sanPham = SanPhamBUS.Instance.LayThongTinSanPham(chiTietHD.MaSP);
                        int maSP = sanPham.MaSP;
                        int soLuong = sanPham.SoLuong - chiTietHD.SoLuong;
                        SanPhamBUS.Instance.CapNhatSoLuongSanPham(maSP, soLuong);
                        dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanhVaConHang();
                    }
                    MessageBox.Show("Thanh toán và lưu hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.Size = new Size(500, 600);
                    printPreviewDialog1.StartPosition = FormStartPosition.CenterScreen;
                    printPreviewDialog1.ShowDialog();
                    btnHuy_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán và lưu hoá đơn thất bại! Chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtSDT.Text = "";
            dgvHoaDon.Rows.Clear();
            ptbHinhAnh.Image = null;
            txtThanhTien.Text = "";
            txtTienKhachTra.Text = "0";
            btnTru.Enabled = false;
            btnThanhToan.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string SDT = txtSDT.Text;
            KhachHangDTO khachHang = KhachHangBUS.Instance.LayThongTinKhachHangTheoSDT(SDT);
            if (khachHang == null)
            {
                MessageBox.Show("Không tìm thấy tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtTenKH.Text = khachHang.TenKH;
            }
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text;
            dgvSanPham.DataSource = SanPhamBUS.Instance.TimKiemSanPham(tenSP);
            btnHuy_Click(btnHuy, EventArgs.Empty);
        }

        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        void TimKiemSanPham()
        {
            try
            {
                if (cbbNCC.SelectedIndex >= 0 && cbbLoaiSP.SelectedIndex >= 0)
                {
                    string tenSP = txtTenSP.Text;
                    int maLoaiSP = int.Parse(cbbLoaiSP.SelectedValue.ToString());
                    int maNCC = int.Parse(cbbNCC.SelectedValue.ToString());
                    dgvSanPham.DataSource = SanPhamBUS.Instance.TimKiemSanPhamTheoMaLoaiSanPhamVaMaNhaCungCap(tenSP, maLoaiSP, maNCC);
                    ptbHinhAnh.Image = null;
                }
            }
            catch
            { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ptbHinhAnh.Image = null;
            txtTenSP.Text = "";
            cbbLoaiSP.SelectedIndex = 0;
            cbbNCC.SelectedIndex = 0;
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDanhSachSanPhamDangKinhDoanhVaConHang();
            txtTenSP.Select();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int maNVL = int.Parse(cbbNVLap.SelectedValue.ToString());
            NhanVienDTO nhanVienLap = NhanVienBUS.Instance.LayThongTinNhanVien(maNVL);
            string tenNVL = nhanVienLap.TenNV;

            e.Graphics.DrawString("Ngày: " + DateTime.Now, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawString("Nhân Viên Lập: " + tenNVL, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 40));

            e.Graphics.DrawString("DOUBLE D STORE", new Font("Arial", 26, FontStyle.Regular), Brushes.Black, new Point(250, 80));
            e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 26, FontStyle.Regular), Brushes.Black, new Point(235, 120));

            e.Graphics.DrawString("Tên khách hàng: " + txtTenKH.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 160));

            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 180));
            e.Graphics.DrawString("Tên Sản Phẩm", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(480, 200));
            e.Graphics.DrawString("Đơn Giá", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(650, 200));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, 220));
            int yPos = 240;

            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                string tenSP = dgvHoaDon.Rows[i].Cells["colTenSP_HD"].Value.ToString();
                string soLuong = dgvHoaDon.Rows[i].Cells["colSoLuong_HD"].Value.ToString();
                string giaBan = dgvHoaDon.Rows[i].Cells["colGiaBan_HD"].Value.ToString();
                e.Graphics.DrawString(tenSP.Substring(0, 22) + "...", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, yPos));
                e.Graphics.DrawString(soLuong, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point((soLuong.Length == 1) ? 520 : 510, yPos));
                e.Graphics.DrawString("x", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(600, yPos));
                e.Graphics.DrawString(giaBan, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(660, yPos));
                yPos += 30;
            }

            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(10, yPos));
            e.Graphics.DrawString("Thành tiền: " + txtThanhTien.Text + " VNĐ", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(490, yPos + 30));
            e.Graphics.DrawString("Tiền khách trả: " + txtTienKhachTra.Text + " VNĐ", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(490, yPos + 60));
            e.Graphics.DrawString("Tiền thừa: " + txtTienThua.Text + " VNĐ", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(490, yPos + 90));
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Length == 0)
            {
                btnHuy.Enabled = false;
            }
            else
            {
                btnHuy.Enabled = true;
            }

            if (tienKhachTra > tienThanhToan && txtTenKH.Text.Length > 0 && txtSDT.Text.Length == 10)
            {
                btnThanhToan.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = false;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 10)
            {
                btnTimKiemKH.Enabled = true;
            }
            else
            {
                btnTimKiemKH.Enabled = false;
            }

            if (txtSDT.Text.Length == 0)
            {
                btnHuy.Enabled = false;
            }
            else
            {
                btnHuy.Enabled = true;
            }

            if (tienKhachTra > tienThanhToan && txtTenKH.Text.Length > 0 && txtSDT.Text.Length == 10)
            {
                btnThanhToan.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = false;
            }
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtSDT.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTienKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                string newText = textBox.Text;
                if (e.KeyChar != '\b')
                {
                    newText += e.KeyChar.ToString();
                }

                if (!string.IsNullOrEmpty(newText) && newText.Length <= 18)
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
