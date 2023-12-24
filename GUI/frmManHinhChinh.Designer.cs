namespace GUI
{
    partial class frmManHinhChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Timer timer1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManHinhChinh));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnTaiKhoan = new System.Windows.Forms.Button();
			this.btnNhaCungCap = new System.Windows.Forms.Button();
			this.btnPhieuNhap = new System.Windows.Forms.Button();
			this.btnNhapHang = new System.Windows.Forms.Button();
			this.btnHang = new System.Windows.Forms.Button();
			this.btnNhanVien = new System.Windows.Forms.Button();
			this.btnKhachHang = new System.Windows.Forms.Button();
			this.btnHoaDon = new System.Windows.Forms.Button();
			this.btnBanHang = new System.Windows.Forms.Button();
			this.btnTrangChu = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ptbHinhAnh = new System.Windows.Forms.PictureBox();
			this.lblQuyen = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTen = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDangXuat = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblTime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Interval = 1000;
			timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSalmon;
			this.panel1.Controls.Add(this.btnTaiKhoan);
			this.panel1.Controls.Add(this.btnNhaCungCap);
			this.panel1.Controls.Add(this.btnPhieuNhap);
			this.panel1.Controls.Add(this.btnNhapHang);
			this.panel1.Controls.Add(this.btnHang);
			this.panel1.Controls.Add(this.btnNhanVien);
			this.panel1.Controls.Add(this.btnKhachHang);
			this.panel1.Controls.Add(this.btnHoaDon);
			this.panel1.Controls.Add(this.btnBanHang);
			this.panel1.Controls.Add(this.btnTrangChu);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(350, 974);
			this.panel1.TabIndex = 0;
			// 
			// btnTaiKhoan
			// 
			this.btnTaiKhoan.AutoSize = true;
			this.btnTaiKhoan.BackColor = System.Drawing.Color.LightSalmon;
			this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
			this.btnTaiKhoan.Location = new System.Drawing.Point(0, 879);
			this.btnTaiKhoan.Name = "btnTaiKhoan";
			this.btnTaiKhoan.Size = new System.Drawing.Size(350, 71);
			this.btnTaiKhoan.TabIndex = 28;
			this.btnTaiKhoan.Text = "Tài Khoản\r\n";
			this.btnTaiKhoan.UseVisualStyleBackColor = false;
			this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
			// 
			// btnNhaCungCap
			// 
			this.btnNhaCungCap.AutoSize = true;
			this.btnNhaCungCap.BackColor = System.Drawing.Color.LightSalmon;
			this.btnNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNhaCungCap.ForeColor = System.Drawing.Color.White;
			this.btnNhaCungCap.Location = new System.Drawing.Point(0, 808);
			this.btnNhaCungCap.Name = "btnNhaCungCap";
			this.btnNhaCungCap.Size = new System.Drawing.Size(350, 71);
			this.btnNhaCungCap.TabIndex = 27;
			this.btnNhaCungCap.Text = "Nhà Cung Cấp";
			this.btnNhaCungCap.UseVisualStyleBackColor = false;
			this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
			// 
			// btnPhieuNhap
			// 
			this.btnPhieuNhap.AutoSize = true;
			this.btnPhieuNhap.BackColor = System.Drawing.Color.LightSalmon;
			this.btnPhieuNhap.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPhieuNhap.ForeColor = System.Drawing.Color.White;
			this.btnPhieuNhap.Location = new System.Drawing.Point(0, 737);
			this.btnPhieuNhap.Name = "btnPhieuNhap";
			this.btnPhieuNhap.Size = new System.Drawing.Size(350, 71);
			this.btnPhieuNhap.TabIndex = 26;
			this.btnPhieuNhap.Text = "Phiếu Nhập";
			this.btnPhieuNhap.UseVisualStyleBackColor = false;
			this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
			// 
			// btnNhapHang
			// 
			this.btnNhapHang.AutoSize = true;
			this.btnNhapHang.BackColor = System.Drawing.Color.LightSalmon;
			this.btnNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNhapHang.ForeColor = System.Drawing.Color.White;
			this.btnNhapHang.Location = new System.Drawing.Point(0, 669);
			this.btnNhapHang.Name = "btnNhapHang";
			this.btnNhapHang.Size = new System.Drawing.Size(350, 68);
			this.btnNhapHang.TabIndex = 23;
			this.btnNhapHang.Text = "Nhập Hàng";
			this.btnNhapHang.UseVisualStyleBackColor = false;
			this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
			// 
			// btnHang
			// 
			this.btnHang.AutoSize = true;
			this.btnHang.BackColor = System.Drawing.Color.LightSalmon;
			this.btnHang.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHang.ForeColor = System.Drawing.Color.White;
			this.btnHang.Location = new System.Drawing.Point(0, 598);
			this.btnHang.Name = "btnHang";
			this.btnHang.Size = new System.Drawing.Size(350, 71);
			this.btnHang.TabIndex = 22;
			this.btnHang.Text = "Sản phẩm";
			this.btnHang.UseVisualStyleBackColor = false;
			this.btnHang.Click += new System.EventHandler(this.btnHang_Click);
			// 
			// btnNhanVien
			// 
			this.btnNhanVien.AutoSize = true;
			this.btnNhanVien.BackColor = System.Drawing.Color.LightSalmon;
			this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNhanVien.ForeColor = System.Drawing.Color.White;
			this.btnNhanVien.Location = new System.Drawing.Point(0, 524);
			this.btnNhanVien.Name = "btnNhanVien";
			this.btnNhanVien.Size = new System.Drawing.Size(350, 74);
			this.btnNhanVien.TabIndex = 21;
			this.btnNhanVien.Text = "Nhân Viên";
			this.btnNhanVien.UseVisualStyleBackColor = false;
			this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
			// 
			// btnKhachHang
			// 
			this.btnKhachHang.AutoSize = true;
			this.btnKhachHang.BackColor = System.Drawing.Color.LightSalmon;
			this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnKhachHang.ForeColor = System.Drawing.Color.White;
			this.btnKhachHang.Location = new System.Drawing.Point(0, 449);
			this.btnKhachHang.Name = "btnKhachHang";
			this.btnKhachHang.Size = new System.Drawing.Size(350, 75);
			this.btnKhachHang.TabIndex = 20;
			this.btnKhachHang.Text = "Khách Hàng";
			this.btnKhachHang.UseVisualStyleBackColor = false;
			this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
			// 
			// btnHoaDon
			// 
			this.btnHoaDon.AutoSize = true;
			this.btnHoaDon.BackColor = System.Drawing.Color.LightSalmon;
			this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHoaDon.ForeColor = System.Drawing.Color.White;
			this.btnHoaDon.Location = new System.Drawing.Point(0, 378);
			this.btnHoaDon.Name = "btnHoaDon";
			this.btnHoaDon.Size = new System.Drawing.Size(350, 71);
			this.btnHoaDon.TabIndex = 13;
			this.btnHoaDon.Text = "Hoá Đơn";
			this.btnHoaDon.UseVisualStyleBackColor = false;
			this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
			// 
			// btnBanHang
			// 
			this.btnBanHang.AutoSize = true;
			this.btnBanHang.BackColor = System.Drawing.Color.LightSalmon;
			this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBanHang.ForeColor = System.Drawing.Color.White;
			this.btnBanHang.Location = new System.Drawing.Point(0, 305);
			this.btnBanHang.Name = "btnBanHang";
			this.btnBanHang.Size = new System.Drawing.Size(350, 73);
			this.btnBanHang.TabIndex = 2;
			this.btnBanHang.Text = "Bán Hàng";
			this.btnBanHang.UseVisualStyleBackColor = false;
			this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
			// 
			// btnTrangChu
			// 
			this.btnTrangChu.AutoSize = true;
			this.btnTrangChu.BackColor = System.Drawing.Color.LightSalmon;
			this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTrangChu.ForeColor = System.Drawing.Color.White;
			this.btnTrangChu.Location = new System.Drawing.Point(0, 232);
			this.btnTrangChu.Name = "btnTrangChu";
			this.btnTrangChu.Size = new System.Drawing.Size(350, 73);
			this.btnTrangChu.TabIndex = 1;
			this.btnTrangChu.Text = "Trang Chủ";
			this.btnTrangChu.UseVisualStyleBackColor = false;
			this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.ptbHinhAnh);
			this.panel2.Controls.Add(this.lblQuyen);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.lblTen);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(350, 232);
			this.panel2.TabIndex = 0;
			// 
			// ptbHinhAnh
			// 
			this.ptbHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ptbHinhAnh.Location = new System.Drawing.Point(114, 19);
			this.ptbHinhAnh.Name = "ptbHinhAnh";
			this.ptbHinhAnh.Size = new System.Drawing.Size(105, 105);
			this.ptbHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ptbHinhAnh.TabIndex = 4;
			this.ptbHinhAnh.TabStop = false;
			// 
			// lblQuyen
			// 
			this.lblQuyen.AutoSize = true;
			this.lblQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuyen.ForeColor = System.Drawing.Color.White;
			this.lblQuyen.Location = new System.Drawing.Point(109, 186);
			this.lblQuyen.Name = "lblQuyen";
			this.lblQuyen.Size = new System.Drawing.Size(153, 25);
			this.lblQuyen.TabIndex = 3;
			this.lblQuyen.Text = "<Quyền User>";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(26, 186);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Quyền:";
			// 
			// lblTen
			// 
			this.lblTen.AutoSize = true;
			this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTen.ForeColor = System.Drawing.Color.White;
			this.lblTen.Location = new System.Drawing.Point(109, 139);
			this.lblTen.Name = "lblTen";
			this.lblTen.Size = new System.Drawing.Size(127, 25);
			this.lblTen.TabIndex = 1;
			this.lblTen.Text = "<Tên User>";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(26, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên:";
			// 
			// btnDangXuat
			// 
			this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDangXuat.BackColor = System.Drawing.Color.Salmon;
			this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangXuat.ForeColor = System.Drawing.Color.White;
			this.btnDangXuat.Location = new System.Drawing.Point(609, 14);
			this.btnDangXuat.Name = "btnDangXuat";
			this.btnDangXuat.Size = new System.Drawing.Size(173, 40);
			this.btnDangXuat.TabIndex = 19;
			this.btnDangXuat.Text = "Đăng xuất";
			this.toolTip1.SetToolTip(this.btnDangXuat, "Đăng xuất khỏi ứng dụng");
			this.btnDangXuat.UseVisualStyleBackColor = false;
			this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.lblTime);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.btnDangXuat);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel3.Location = new System.Drawing.Point(350, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(795, 68);
			this.panel3.TabIndex = 2;
			// 
			// lblTime
			// 
			this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(435, 19);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(157, 29);
			this.lblTime.TabIndex = 2;
			this.lblTime.Text = "<Time>";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(20, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(249, 37);
			this.label2.TabIndex = 0;
			this.label2.Text = "Double D Store";
			// 
			// frmManHinhChinh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Coral;
			this.ClientSize = new System.Drawing.Size(1145, 974);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MaximizeBox = false;
			this.Name = "frmManHinhChinh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản Lý Cửa Hàng Bán Giày";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmManHinhChinh_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbHinhAnh)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox ptbHinhAnh;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnHang;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnNhaCungCap;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}