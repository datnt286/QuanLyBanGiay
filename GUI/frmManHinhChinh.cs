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
	public partial class frmManHinhChinh : Form
	{
		int maNV;
		NhanVienDTO nhanVien;
		Form curFrm = new Form();
		bool check = false;
		Button previousButton;

		public frmManHinhChinh(int maNV)
		{
			InitializeComponent();

			this.maNV = maNV;
			nhanVien = NhanVienBUS.Instance.LayThongTinNhanVien(this.maNV);

			try
			{
				ptbHinhAnh.Image = Image.FromFile(@"nhanvien/" + nhanVien.HinhAnh.ToString());
			}
			catch
			{
				ptbHinhAnh.Image = Image.FromFile(@"nhanvien/no_image.jpg");
			}

			lblTen.Text = nhanVien.TenNV.ToString();

			if (nhanVien.MaLoaiNV == 1)
			{
				lblQuyen.Text = "Quản lý";
			}
			else if (nhanVien.MaLoaiNV == 2)
			{
				lblQuyen.Text = "Nhân viên bán hàng";
				btnTrangChu.Visible = false;
				btnNhanVien.Visible = false;
				btnHang.Visible = false;
				btnNhapHang.Visible = false;
				btnPhieuNhap.Visible = false;
				btnNhaCungCap.Visible = false;
			}
			else if (nhanVien.MaLoaiNV == 3)
			{
				lblQuyen.Text = "Nhân viên kho";
				btnTrangChu.Visible = false;
				btnBanHang.Visible = false;
				btnHoaDon.Visible = false;
				btnKhachHang.Visible = false;
				btnNhanVien.Visible = false;
				btnNhaCungCap.Visible = false;
			}
		}

		private void frmManHinhChinh_Load(object sender, EventArgs e)
		{
			if (nhanVien.MaLoaiNV == 1)
			{
				btnTrangChu_Click(sender, e);
			}
			else if (nhanVien.MaLoaiNV == 2)
			{
				btnBanHang_Click(sender, e);
			}
			else if (nhanVien.MaLoaiNV == 3)
			{
				btnHang_Click(sender, e);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime currentTime = DateTime.Now;
			lblTime.Text = currentTime.ToString("hh:mm:ss tt");
		}

		void XuLyForm(Form frm)
		{
			if (check)
			{
				curFrm.Hide();
			}
			else
			{
				check = true;
			}
			curFrm = frm;
			curFrm.MdiParent = this;
			curFrm.TopLevel = false;
			curFrm.FormBorderStyle = FormBorderStyle.None;
			curFrm.Dock = DockStyle.Fill;
			curFrm.Show();
		}

		void ChangeButtonColor(Button button)
		{
			if (previousButton != null)
			{
				previousButton.BackColor = Color.LightSalmon;
			}
			button.BackColor = Color.Tomato;
			previousButton = button;
		}

		private void btnTrangChu_Click(object sender, EventArgs e)
		{
			frmTrangChu frm = new frmTrangChu();
			XuLyForm(frm);
			ChangeButtonColor(btnTrangChu);
		}

		private void btnBanHang_Click(object sender, EventArgs e)
		{
			frmBanHang frm = new frmBanHang(maNV);
			XuLyForm(frm);
			ChangeButtonColor(btnBanHang);
		}

		private void btnHoaDon_Click(object sender, EventArgs e)
		{
			frmHoaDon frm = new frmHoaDon();
			XuLyForm(frm);
			ChangeButtonColor(btnHoaDon);
		}

		private void btnKhachHang_Click(object sender, EventArgs e)
		{
			frmKhachHang frm = new frmKhachHang();
			XuLyForm(frm);
			ChangeButtonColor(btnKhachHang);
		}

		private void btnNhanVien_Click(object sender, EventArgs e)
		{
			frmNhanVien frm = new frmNhanVien();
			XuLyForm(frm);
			ChangeButtonColor(btnNhanVien);
		}

		private void btnHang_Click(object sender, EventArgs e)
		{
			frmHang frm = new frmHang();
			XuLyForm(frm);
			ChangeButtonColor(btnHang);
		}

		private void btnNhapHang_Click(object sender, EventArgs e)
		{
			frmNhapHang frm = new frmNhapHang(maNV);
			XuLyForm(frm);
			ChangeButtonColor(btnNhapHang);
		}

		private void btnPhieuNhap_Click(object sender, EventArgs e)
		{
			frmPhieuNhap frm = new frmPhieuNhap();
			XuLyForm(frm);
			ChangeButtonColor(btnPhieuNhap);
		}

		private void btnNhaCungCap_Click(object sender, EventArgs e)
		{
			frmNhaCungCap frm = new frmNhaCungCap();
			XuLyForm(frm);
			ChangeButtonColor(btnNhaCungCap);
		}

		private void btnTaiKhoan_Click(object sender, EventArgs e)
		{
			frmTaiKhoan frm = new frmTaiKhoan(maNV);
			XuLyForm(frm);
			ChangeButtonColor(btnTaiKhoan);
		}

		private void btnDangXuat_Click(object sender, EventArgs e)
		{
			frmDangNhap frm = new frmDangNhap();
			Hide();
			frm.ShowDialog();
			Close();
		}
	}
}
