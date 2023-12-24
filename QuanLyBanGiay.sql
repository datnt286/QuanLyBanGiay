--CREATE DATABASE QuanLyBanGiay

CREATE TABLE LoaiNhanVien
(
	MaLoaiNV int IDENTITY(1,1) PRIMARY KEY,
	TenLoaiNV nvarchar(30) NOT NULL,
	TrangThai int DEFAULT 1,
)

CREATE TABLE NhanVien
(
	MaNV int IDENTITY(1,1) PRIMARY KEY,
	TenNV nvarchar(50) NOT NULL,
	HinhAnh nvarchar(100) NOT NULL,
	SDT char(10) NOT NULL,
	Email nvarchar(30) NOT NULL,
	DiaChi nvarchar(100) NOT NULL,
	NgayVaoLam date NOT NULL,
	Luong decimal NOT NULL,
	MaLoaiNV int FOREIGN KEY REFERENCES LoaiNhanVien(MaLoaiNV),
	TrangThai int DEFAULT 1,
)

CREATE TABLE TaiKhoan
(
	MaTK int IDENTITY(1,1) PRIMARY KEY,
	MaNV int FOREIGN KEY REFERENCES NhanVien(MaNV),
	TenDangNhap nvarchar(30) NOT NULL,
	MatKhau nvarchar(30) NOT NULL,
	TrangThai int DEFAULT 1,
)

CREATE TABLE KhachHang
(
	MaKH int IDENTITY(1,1) PRIMARY KEY,
	TenKH nvarchar(50) NOT NULL,
	SDT char(10) NOT NULL,
	NgayDangKy date NOT NULL,
	Email nvarchar(30),
	DiaChi nvarchar(100),
	TrangThai int DEFAULT 1,
)

CREATE TABLE LoaiSanPham
(
	MaLoaiSP int IDENTITY(1,1) PRIMARY KEY,
	TenLoaiSP nvarchar(30) NOT NULL,
	TrangThai int DEFAULT 1,
)	

CREATE TABLE NhaCungCap
(
	MaNCC int IDENTITY(1,1) PRIMARY KEY,
	TenNCC nvarchar(50) NOT NULL,
	SDT char(10) NOT NULL,
	Email nvarchar(30) NOT NULL,
	DiaChi nvarchar(100) NOT NULL,
	TrangThai int DEFAULT 1,
)

CREATE TABLE SanPham
(
	MaSP int IDENTITY(1,1) PRIMARY KEY,
	MaLoaiSP int FOREIGN KEY REFERENCES LoaiSanPham(MaLoaiSP),
	MaNCC int FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
	TenSP nvarchar(100) NOT NULL,
	HinhAnh nvarchar(100) NOT NULL,
	MauSac nvarchar(20) NOT NULL,
	Size int NOT NULL,
	SoLuong int NOT NULL,
	GiaNhap decimal NOT NULL,
	GiaBan decimal NOT NULL,
	MoTa nvarchar(50),
	TrangThai int DEFAULT 1,
)

CREATE TABLE HoaDon
(
	MaHD int IDENTITY(1,1) PRIMARY KEY,
	MaKH int FOREIGN KEY REFERENCES KhachHang(MaKH),
	MaNV int FOREIGN KEY REFERENCES NhanVien(MaNV),
	NgayLap date NOT NULL,
	ThanhTien decimal NOT NULL,
	TrangThai int DEFAULT 1,
)

CREATE TABLE ChiTietHoaDon
(
	MaCTHD int IDENTITY(1,1) PRIMARY KEY,
	MaHD int FOREIGN KEY REFERENCES HoaDon(MaHD),
	MaSP int FOREIGN KEY REFERENCES SanPham(MaSP),
	SoLuong int NOT NULL,
	TongTien decimal NOT NULL,
)

CREATE TABLE PhieuNhap
(
	MaPN int IDENTITY(1,1) PRIMARY KEY,
	MaNCC int FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
	MaNV int FOREIGN KEY REFERENCES NhanVien(MaNV),
	NgayNhap date NOT NULL,
	ThanhTien decimal NOT NULL,
	TrangThai int DEFAULT 1,
)

CREATE TABLE ChiTietPhieuNhap
(
	MaCTPN int IDENTITY(1,1) PRIMARY KEY,
	MaPN int FOREIGN KEY REFERENCES PhieuNhap(MaPN),
	MaSP int FOREIGN KEY REFERENCES SanPham(MaSP),
	SoLuong int NOT NULL,
	TongTien decimal NOT NULL,
)

--LoaiNhanVien
INSERT INTO LoaiNhanVien(TenLoaiNV) VALUES (N'Quản lý')
INSERT INTO LoaiNhanVien(TenLoaiNV) VALUES (N'Nhân viên bán hàng')
INSERT INTO LoaiNhanVien(TenLoaiNV) VALUES (N'Nhân viên kho')

--NhanVien
INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Nguyễn Thành Đạt','dat.jpg', '0123456789', 'dat@gmail.com', N'Quận Bình Thạnh, TP HCM', '4/4/2023', 10000000, 1)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Đào Hải Đăng','dang.jpg', '0987654321', 'dang@gmail.com', N'Quận 4, TP HCM', '4/5/2023', 10000000, 1)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Đinh Viết Thành', 'thanh.jpg', '0123498765', 'thanh@gmail.com', N'Quận 7, TP HCM', '4/7/2023', 6000000, 2)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Trần Thị Mai Liên', 'lien.jpg', '0987612345', 'lien@gmail.com', N'Quận 3, TP HCM', '4/16/2023', 6000000, 3)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV)
VALUES (N'Nguyễn Hữu Thuận', 'thuan.jpg', '0567891234', 'thuan@gmail.com', N'Quận 11, TP HCM', '5/5/2023', 6000000, 2)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV)
VALUES (N'Võ Trường Chinh', 'chinh.jpg', '0121212121', 'chinh@gmail.com', N'Quận 10, TP HCM', '5/12/2023', 6000000, 2)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Lê Gia Bảo','bao.jpg', '0343434343', 'bao@gmail.com', N'Quận 3, TP HCM', '5/15/2023', 6000000, 2)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Phạm Phú Hậu','hau.jpg', '0565656565', 'hau@gmail.com', N'Quận Tân Bình, TP HCM', '5/21/2023', 5000000, 3)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV)
VALUES (N'Trần Thành Nghĩa', 'nghia.jpg', '0787878787', 'nghia@gmail.com', N'Quận 4, TP HCM', '5/10/2023', 5000000, 3)

INSERT INTO NhanVien(TenNV, HinhAnh, SDT, Email, DiaChi, NgayVaoLam, Luong, MaLoaiNV) 
VALUES (N'Trần Thanh Tuấn','tuan.jpg', '0898989898', 'tuan@gmail.com', N'Quận 2, TP HCM', '4/8/2023', 5000000, 3)

--TaiKhoan
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (1, 'dat', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (2, 'dang', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (3, 'thanh', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (4, 'lien', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (5, 'thuan', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (6, 'nghia', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (7, 'chinh', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (8, 'bao', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (9, 'hau', '123')
INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau) VALUES (10, 'tuan', '123')

--KhachHang
INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) 
VALUES (N'Đặng Anh Kiệt', '0123459876', '5/15/2023', 'kiet@gmail.com', N'Quận Tân Bình, TP HCM')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) 
VALUES (N'Nguyễn Tuấn Khanh', '0123654789', '6/1/2023', 'khanh@gmail.com', N'Quận 2, TP HCM')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) 
VALUES (N'Đặng Quang Hiếu', '0987456123', '6/2/2023', 'hieu@gmail.com', N'Quận Tân Phú, TP HCM')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) 
VALUES (N'Âu Tuấn Hưng', '0676767676', '6/5/2023', 'hung@gmail.com', N'Quận 4, TP HCM')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy, Email, DiaChi) 
VALUES (N'Nguyễn Tuấn Dĩ', '0789789789', '6/9/2023', 'di@gmail.com', N'Quận 5, TP HCM')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy) 
VALUES (N'Lê Văn Đạt', '0456456456', '6/2/2023')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy) 
VALUES (N'Trần Đức Bo', '0678954321', '6/2/2023')

INSERT INTO KhachHang(TenKH, SDT, NgayDangKy) 
VALUES (N'Trần Dần', '0112233445', '6/2/2023')

--LoaiSanPham
INSERT INTO LoaiSanPham(TenLoaiSP) VALUES (N'Giày')
INSERT INTO LoaiSanPham(TenLoaiSP) VALUES (N'Tất')

--NhaCungCap
INSERT INTO NhaCungCap(TenNCC, SDT, Email, DiaChi) 
VALUES ('Adidas', '0987654321', 'adidas@gmail.com', N'Bình Dương')

INSERT INTO NhaCungCap(TenNCC, SDT, Email, DiaChi) 
VALUES ('Converse', '0123498765', 'converse@gmail.com', N'Tp HCM')

INSERT INTO NhaCungCap(TenNCC, SDT, Email, DiaChi) 
VALUES ('Nike', '0123456789', 'nike@gmail.com', N'Tp HCM')

INSERT INTO NhaCungCap(TenNCC, SDT, Email, DiaChi) 
VALUES ('Vans', '0123498765', 'vans@gmail.com', N'Cần Thơ')

--SanPham
---Adidas
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Pure Boost White Size 39', 'Adidas Pure Boost White.png', N'Trắng', 39, 100, 570000, 620000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Pure Boost White Size 40', 'Adidas Pure Boost White.png', N'Trắng', 40, 200, 570000, 620000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Pure Boost White Size 41', 'Adidas Pure Boost White.png', N'Trắng', 41, 150, 570000, 620000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 39', 'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 39, 100, 520000, 590000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 40', 'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 40, 200, 520000, 590000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 41', 'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 41, 150, 520000, 590000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 42', 'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 42, 150, 520000, 590000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 40', 'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 40, 200, 440000, 490000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 41', 'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 41, 150, 440000, 490000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 42', 'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 42, 100, 440000, 490000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 43', 'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 43, 100, 440000, 490000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yzy 700 V2 Static Size 39', 'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 39, 100, 520000, 560000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yzy 700 V2 Static Size 40', 'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 40, 200, 520000, 560000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 1, N'Adidas Yzy 700 V2 Static Size 41', 'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 41, 150, 520000, 560000)

---Converse
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 39', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 39, 100, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 40', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 40, 200, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 41', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 41, 150, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 42', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 42, 120, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 43', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 43, 250, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 44', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 44, 100, 315000, 350000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 45', 'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 45, 150, 315000, 350000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 39', 'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 39, 100, 450000, 520000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 40', 'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 40, 200, 450000, 520000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 41', 'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 41, 150, 450000, 520000)

---Nike
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 40', 'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 40, 200, 525000, 560000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 41', 'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 41, 150, 525000, 560000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 42', 'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 42, 100, 525000, 560000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 43', 'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 43, 140, 525000, 560000)

---	
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Low Size 39', 'Nike Air Force 1 Low.png', N'Trắng', 39, 100, 370000, 430000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Low Size 40', 'Nike Air Force 1 Low.png', N'Trắng', 40, 200, 370000, 430000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Low Size 41', 'Nike Air Force 1 Low.png', N'Trắng', 41, 150, 370000, 430000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force 1 Low Size 42', 'Nike Air Force 1 Low.png', N'Trắng', 42, 50, 370000, 430000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force1 Shadow Team Size 39', 'Nike Air Force1 Shadow Team.jpg', N'Cam', 39, 100, 415000, 450000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force1 Shadow Team Size 40', 'Nike Air Force1 Shadow Team.jpg', N'Cam', 40, 200, 415000, 450000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force1 Shadow Team Size 41', 'Nike Air Force1 Shadow Team.jpg', N'Cam', 41, 150, 415000, 450000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force1 Shadow Team Size 42', 'Nike Air Force1 Shadow Team.jpg', N'Cam', 42, 150, 415000, 450000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Force1 Shadow Team Size 43', 'Nike Air Force1 Shadow Team.jpg', N'Cam', 43, 150, 415000, 450000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 39', 'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 39, 100, 620000, 660000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 40', 'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 40, 200, 620000, 660000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 41', 'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 41, 150, 620000, 660000)

---
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Ari Max 97 Size 39', 'Nike Ari Max 97.jpg', N'Trắng', 39, 100, 365000, 410000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Ari Max 97 Size 40', 'Nike Ari Max 97.jpg', N'Trắng', 40, 200, 365000, 410000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Ari Max 97 Size 41', 'Nike Ari Max 97.jpg', N'Trắng', 41, 150, 365000, 410000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 3, N'Nike Ari Max 97 Size 42', 'Nike Ari Max 97.jpg', N'Trắng', 42, 50, 365000, 410000)

---Vans
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 39', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 39, 100, 520000, 550000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 40', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 40, 200, 520000, 550000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 41', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 41, 150, 520000, 550000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 42', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 42, 250, 520000, 550000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 43', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 43, 100, 520000, 550000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (1, 4, N'Vans Old Skool Classic Black Size 44', 'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 44, 50, 520000, 550000)

---Tất
INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 1, N'Tất Adidas Sneaker Đen', N'Tất Adidas Sneaker Đen.png', N'Đen', 0, 100, 90000, 120000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 2, N'Tât Converse Core Single Footie Đen', N'Tât Converse Core Single Footie Đen.png', N'Đen', 0, 200, 80000, 115000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 3, N'Tất Nike Cổ Thấp Xanh Dương', N'Tất Nike Cổ Thấp Xanh Dương.jpg', N'Xanh Dương', 0, 130, 80000, 110000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 3, N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Tím', N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Tím.png', N'Tím', 0, 150, 95000, 130000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 3, N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Xanh Da Trời', N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Xanh Da Trời.png', N'Xanh Da Trời', 0, 120, 95000, 130000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 4, N'Tất Vans Mn Ap Cn Vans Trắng', N'Tất Vans Mn Ap Cn Vans Trắng.png', N'Trắng', 0, 160, 100000, 140000)

INSERT INTO SanPham(MaLoaiSP, MaNCC, TenSP, HinhAnh, MauSac, Size, SoLuong, GiaNhap, GiaBan)
VALUES (2, 4, N'Tất Vans Wm Double Take Crew Sock Đen', N'Tất Vans Wm Double Take Crew Sock Đen.png', N'Đen', 0, 140, 900000, 130000)

--HoaDon
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) VALUES (1, 1, '6/1/2023', 8870000)
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) VALUES (2, 2, '6/1/2023', 2920000)
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) VALUES (3, 3, '6/2/2023', 4930000)
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) VALUES (4, 4, '6/2/2023', 2450000)
INSERT INTO HoaDon(MaKH, MaNV, NgayLap, ThanhTien) VALUES (5, 5, '6/2/2023', 7620000)

--ChiTietHoaDon
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (1, 5, 10, 5900000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (1, 15, 5, 1750000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (1, 27, 2, 1120000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (2, 2, 2, 1240000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (2, 8, 3, 1680000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (3, 14, 3, 1680000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (3, 25, 5, 2800000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (3, 36, 1, 450000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (4, 10, 5, 2450000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (5, 22, 6, 3120000)
INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, TongTien) VALUES (5, 33, 10, 4500000)

--PhieuNhap
INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) VALUES (1, 1, '6/1/2023', 53600000)
INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) VALUES (2, 7, '6/1/2023', 66200000)
INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) VALUES (3, 8, '6/2/2023', 63650000)
INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) VALUES (4, 9, '6/2/2023', 55000000)
INSERT INTO PhieuNhap(MaNCC, MaNV, NgayNhap, ThanhTien) VALUES (1, 10, '6/2/2023', 18900000)

--ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (1, 2, 50, 31000000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (1, 5, 30, 17700000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (1, 10, 10, 4900000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (2, 18, 100, 35000000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (2, 23, 60, 31200000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (3, 30, 20, 8600000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (3, 34, 50, 22500000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (3, 38, 40, 26400000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (3, 43, 15, 6150000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (4, 48, 100, 55000000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (5, 4, 30, 17700000)
INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuong, TongTien) VALUES (5, 51, 10, 1200000)
