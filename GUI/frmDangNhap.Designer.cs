namespace GUI
{
    partial class frmDangNhap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
			this.panel1 = new System.Windows.Forms.Panel();
			this.ptbClose = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTenDangNhap = new System.Windows.Forms.TextBox();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.pnlMatKhau = new System.Windows.Forms.Panel();
			this.pnlTenDangNhap = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chbHienMatKhau = new System.Windows.Forms.CheckBox();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSalmon;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.ptbClose);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1035, 70);
			this.panel1.TabIndex = 0;
			// 
			// ptbClose
			// 
			this.ptbClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.ptbClose.Image = global::GUI.Properties.Resources.close_icon;
			this.ptbClose.Location = new System.Drawing.Point(965, 0);
			this.ptbClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ptbClose.Name = "ptbClose";
			this.ptbClose.Size = new System.Drawing.Size(68, 68);
			this.ptbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ptbClose.TabIndex = 1;
			this.ptbClose.TabStop = false;
			this.toolTip1.SetToolTip(this.ptbClose, "Đóng ứng dụng");
			this.ptbClose.Click += new System.EventHandler(this.ptbClose_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(24, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(249, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "Double D Store";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.txtTenDangNhap);
			this.panel2.Controls.Add(this.txtMatKhau);
			this.panel2.Controls.Add(this.pnlMatKhau);
			this.panel2.Controls.Add(this.pnlTenDangNhap);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.chbHienMatKhau);
			this.panel2.Controls.Add(this.btnDangNhap);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.Location = new System.Drawing.Point(0, 70);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1035, 674);
			this.panel2.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::GUI.Properties.Resources.icon;
			this.pictureBox1.Location = new System.Drawing.Point(412, 37);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(220, 202);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 29;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(389, 284);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(277, 55);
			this.label2.TabIndex = 28;
			this.label2.Text = "Đăng Nhập";
			// 
			// txtTenDangNhap
			// 
			this.txtTenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenDangNhap.ForeColor = System.Drawing.Color.Black;
			this.txtTenDangNhap.Location = new System.Drawing.Point(335, 362);
			this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTenDangNhap.Name = "txtTenDangNhap";
			this.txtTenDangNhap.Size = new System.Drawing.Size(550, 33);
			this.txtTenDangNhap.TabIndex = 1;
			this.txtTenDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDangNhap_KeyPress);
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatKhau.ForeColor = System.Drawing.Color.Black;
			this.txtMatKhau.Location = new System.Drawing.Point(335, 479);
			this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(405, 33);
			this.txtMatKhau.TabIndex = 2;
			this.txtMatKhau.UseSystemPasswordChar = true;
			// 
			// pnlMatKhau
			// 
			this.pnlMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pnlMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
			this.pnlMatKhau.Location = new System.Drawing.Point(116, 519);
			this.pnlMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlMatKhau.Name = "pnlMatKhau";
			this.pnlMatKhau.Size = new System.Drawing.Size(792, 2);
			this.pnlMatKhau.TabIndex = 23;
			// 
			// pnlTenDangNhap
			// 
			this.pnlTenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pnlTenDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(133)))), ((int)(((byte)(204)))));
			this.pnlTenDangNhap.Location = new System.Drawing.Point(116, 405);
			this.pnlTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlTenDangNhap.Name = "pnlTenDangNhap";
			this.pnlTenDangNhap.Size = new System.Drawing.Size(792, 2);
			this.pnlTenDangNhap.TabIndex = 22;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(111, 482);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 29);
			this.label4.TabIndex = 24;
			this.label4.Text = "Mật Khẩu:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(111, 371);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(203, 29);
			this.label3.TabIndex = 25;
			this.label3.Text = "Tên Đăng Nhập:";
			// 
			// chbHienMatKhau
			// 
			this.chbHienMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chbHienMatKhau.AutoSize = true;
			this.chbHienMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chbHienMatKhau.Location = new System.Drawing.Point(758, 488);
			this.chbHienMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chbHienMatKhau.Name = "chbHienMatKhau";
			this.chbHienMatKhau.Size = new System.Drawing.Size(151, 24);
			this.chbHienMatKhau.TabIndex = 12;
			this.chbHienMatKhau.Text = "Hiện mật khẩu";
			this.chbHienMatKhau.UseVisualStyleBackColor = true;
			this.chbHienMatKhau.CheckedChanged += new System.EventHandler(this.chbHienMatKhau_CheckedChanged);
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDangNhap.BackColor = System.Drawing.Color.LightSalmon;
			this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangNhap.ForeColor = System.Drawing.Color.White;
			this.btnDangNhap.Location = new System.Drawing.Point(385, 568);
			this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(291, 50);
			this.btnDangNhap.TabIndex = 11;
			this.btnDangNhap.Text = "Đăng Nhập";
			this.toolTip1.SetToolTip(this.btnDangNhap, "Đăng nhập vào ứng dụng");
			this.btnDangNhap.UseVisualStyleBackColor = false;
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// frmDangNhap
			// 
			this.AcceptButton = this.btnDangNhap;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1035, 744);
			this.ControlBox = false;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "frmDangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập";
			this.Load += new System.EventHandler(this.frmDangNhap_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.CheckBox chbHienMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Panel pnlMatKhau;
        private System.Windows.Forms.Panel pnlTenDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptbClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
	}
}

