USE [QuanLyBanGiay]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaCTHD] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NOT NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaCTPN] [int] IDENTITY(1,1) NOT NULL,
	[MaPN] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NOT NULL,
	[TongTien] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[MaNV] [int] NULL,
	[NgayLap] [date] NOT NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[NgayDangKy] [date] NOT NULL,
	[Email] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNV] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNV] [nvarchar](30) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](30) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[HinhAnh] [nvarchar](100) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[NgayVaoLam] [date] NOT NULL,
	[Luong] [decimal](18, 0) NOT NULL,
	[MaLoaiNV] [int] NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [int] IDENTITY(1,1) NOT NULL,
	[MaNCC] [int] NULL,
	[MaNV] [int] NULL,
	[NgayNhap] [date] NOT NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiSP] [int] NULL,
	[MaNCC] [int] NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[HinhAnh] [nvarchar](100) NOT NULL,
	[MauSac] [nvarchar](20) NOT NULL,
	[Size] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [decimal](18, 0) NOT NULL,
	[GiaBan] [decimal](18, 0) NOT NULL,
	[MoTa] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/5/2023 7:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTK] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[TenDangNhap] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](30) NOT NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (1, 1, 5, 10, CAST(5900000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (2, 1, 15, 5, CAST(1750000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (3, 1, 27, 2, CAST(1120000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (4, 2, 2, 2, CAST(1240000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (5, 2, 8, 3, CAST(1680000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (6, 3, 14, 3, CAST(1680000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (7, 3, 25, 5, CAST(2800000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (8, 3, 36, 1, CAST(450000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (9, 4, 10, 5, CAST(2450000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (10, 5, 22, 6, CAST(3120000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [TongTien]) VALUES (11, 5, 33, 10, CAST(4500000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 

INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (1, 1, 2, 50, CAST(31000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (2, 1, 5, 30, CAST(17700000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (3, 1, 10, 10, CAST(4900000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (4, 2, 18, 100, CAST(35000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (5, 2, 23, 60, CAST(31200000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (6, 3, 30, 20, CAST(8600000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (7, 3, 34, 50, CAST(22500000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (8, 3, 38, 40, CAST(26400000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (9, 3, 43, 15, CAST(6150000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (10, 4, 48, 100, CAST(55000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (11, 5, 4, 30, CAST(17700000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [MaSP], [SoLuong], [TongTien]) VALUES (12, 5, 51, 10, CAST(1200000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLap], [ThanhTien], [TrangThai]) VALUES (1, 1, 1, CAST(N'2023-06-01' AS Date), CAST(8870000 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLap], [ThanhTien], [TrangThai]) VALUES (2, 2, 2, CAST(N'2023-06-01' AS Date), CAST(2920000 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLap], [ThanhTien], [TrangThai]) VALUES (3, 3, 3, CAST(N'2023-06-02' AS Date), CAST(4930000 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLap], [ThanhTien], [TrangThai]) VALUES (4, 4, 4, CAST(N'2023-06-02' AS Date), CAST(2450000 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLap], [ThanhTien], [TrangThai]) VALUES (5, 5, 5, CAST(N'2023-06-02' AS Date), CAST(7620000 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (1, N'Hồ Minh Hưng', N'0987654321', CAST(N'2023-05-02' AS Date), N'hung@gmail.com', N'Quận Bình Thạnh, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (2, N'Nguyễn Thành Đạt', N'0987651234', CAST(N'2023-05-05' AS Date), N'dat@gmail.com', N'Quận 3, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (3, N'Nguyễn Mai Thiên Triệu', N'0123456789', CAST(N'2023-05-10' AS Date), N'trieu@gmail.com', N'Quận 4, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (4, N'Nguyễn Văn Nhớ', N'0123459876', CAST(N'2023-05-15' AS Date), N'nho@gmail.com', N'Quận Tân Bình, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (5, N'Nguyễn Tuấn Khanh', N'0123654789', CAST(N'2023-06-01' AS Date), N'khanh@gmail.com', N'Quận 2, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (6, N'Đặng Quang Hiếu', N'0987456123', CAST(N'2023-06-02' AS Date), N'hieu@gmail.com', N'Quận Tân Phú, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (7, N'Trần Thành Nghĩa', N'0123123123', CAST(N'2023-06-02' AS Date), N'nghia@gmail.com', N'Quận 4, TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (8, N'Lê Văn Đạt', N'0456456456', CAST(N'2023-06-02' AS Date), NULL, NULL, 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (9, N'Trần Đức Bo', N'0678954321', CAST(N'2023-06-02' AS Date), NULL, NULL, 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [NgayDangKy], [Email], [DiaChi], [TrangThai]) VALUES (10, N'Trần Dần', N'0112233445', CAST(N'2023-06-02' AS Date), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiNhanVien] ON 

INSERT [dbo].[LoaiNhanVien] ([MaLoaiNV], [TenLoaiNV], [TrangThai]) VALUES (1, N'Quản lý', 1)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNV], [TenLoaiNV], [TrangThai]) VALUES (2, N'Nhân viên bán hàng', 1)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNV], [TenLoaiNV], [TrangThai]) VALUES (3, N'Nhân viên kho', 1)
SET IDENTITY_INSERT [dbo].[LoaiNhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [TrangThai]) VALUES (1, N'Giày', 1)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [TrangThai]) VALUES (2, N'Tất', 1)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Email], [DiaChi], [TrangThai]) VALUES (1, N'Adidas', N'0987654321', N'adidas@gmail.com', N'Bình Dương', 1)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Email], [DiaChi], [TrangThai]) VALUES (2, N'Converse', N'0123498765', N'converse@gmail.com', N'Tp HCM', 1)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Email], [DiaChi], [TrangThai]) VALUES (3, N'Nike', N'0123456789', N'nike@gmail.com', N'Tp HCM', 1)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Email], [DiaChi], [TrangThai]) VALUES (4, N'Vans', N'0123498765', N'vans@gmail.com', N'Cần Thơ', 1)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (1, N'Nguyễn Thành Đạt', N'dat.jpg', N'0123456789', N'dat@gmail.com', N'Quận Bình Thạnh, TP HCM', CAST(N'2023-04-04' AS Date), CAST(10000000 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (2, N'Đào Hải Đăng', N'dang.jpg', N'0987654321', N'dang@gmail.com', N'Quận 4, TP HCM', CAST(N'2023-04-05' AS Date), CAST(6000000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (3, N'Trần Thế An', N'an.jpg', N'0123498765', N'an@gmail.com', N'Quận 7, TP HCM', CAST(N'2023-04-07' AS Date), CAST(6000000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (4, N'Lê Đức Minh', N'minh.jpg', N'0987612345', N'minh@gmail.com', N'Quận Củ Chi, TP HCM', CAST(N'2023-04-16' AS Date), CAST(6000000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (5, N'Võ Trường Chinh', N'chinh.jpg', N'0121212121', N'chinh@gmail.com', N'Quận 10, TP HCM', CAST(N'2023-05-10' AS Date), CAST(6000000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (6, N'Lê Gia Bảo', N'bao.jpg', N'0232323232', N'bao@gmail.com', N'Quận 3, TP HCM', CAST(N'2023-05-15' AS Date), CAST(6000000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (7, N'Trần Thanh Tuấn', N'tuan.jpg', N'0345345345', N'tuan@gmail.com', N'Quận 2, TP HCM', CAST(N'2023-04-08' AS Date), CAST(5000000 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (8, N'Âu Tuấn Hưng', N'hung.jpg', N'0676767676', N'hung@gmail.com', N'Quận 4, TP HCM', CAST(N'2023-04-24' AS Date), CAST(5000000 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (9, N'Nguyễn Tuấn Dĩ', N'di.jpg', N'0789789789', N'di@gmail.com', N'Quận 5, TP HCM', CAST(N'2023-05-11' AS Date), CAST(5000000 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [HinhAnh], [SDT], [Email], [DiaChi], [NgayVaoLam], [Luong], [MaLoaiNV], [TrangThai]) VALUES (10, N'Phạm Phú Hậu', N'hau.jpg', N'0454545454', N'hau@gmail.com', N'Quận Tân Bình, TP HCM', CAST(N'2023-05-21' AS Date), CAST(5000000 AS Decimal(18, 0)), 3, 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [MaNV], [NgayNhap], [ThanhTien], [TrangThai]) VALUES (1, 1, 1, CAST(N'2023-06-01' AS Date), CAST(53600000 AS Decimal(18, 0)), 1)
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [MaNV], [NgayNhap], [ThanhTien], [TrangThai]) VALUES (2, 2, 7, CAST(N'2023-06-01' AS Date), CAST(66200000 AS Decimal(18, 0)), 1)
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [MaNV], [NgayNhap], [ThanhTien], [TrangThai]) VALUES (3, 3, 8, CAST(N'2023-06-02' AS Date), CAST(63650000 AS Decimal(18, 0)), 1)
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [MaNV], [NgayNhap], [ThanhTien], [TrangThai]) VALUES (4, 4, 9, CAST(N'2023-06-02' AS Date), CAST(55000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [MaNV], [NgayNhap], [ThanhTien], [TrangThai]) VALUES (5, 1, 10, CAST(N'2023-06-02' AS Date), CAST(18900000 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (1, 1, 1, N'Adidas Pure Boost White Size 39', N'Adidas Pure Boost White.png', N'Trắng', 39, 100, CAST(570000 AS Decimal(18, 0)), CAST(620000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (2, 1, 1, N'Adidas Pure Boost White Size 40', N'Adidas Pure Boost White.png', N'Trắng', 40, 200, CAST(570000 AS Decimal(18, 0)), CAST(620000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (3, 1, 1, N'Adidas Pure Boost White Size 41', N'Adidas Pure Boost White.png', N'Trắng', 41, 150, CAST(570000 AS Decimal(18, 0)), CAST(620000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (4, 1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 39', N'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 39, 100, CAST(520000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (5, 1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 40', N'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 40, 200, CAST(520000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (6, 1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 41', N'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 41, 150, CAST(520000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (7, 1, 1, N'Adidas Yeezy 350v2 Static Non Reflective White Size 42', N'Adidas Yeezy 350v2 Static Non Reflective.png', N'Trắng', 42, 150, CAST(520000 AS Decimal(18, 0)), CAST(590000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (8, 1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 40', N'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 40, 200, CAST(440000 AS Decimal(18, 0)), CAST(490000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (9, 1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 41', N'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 41, 150, CAST(440000 AS Decimal(18, 0)), CAST(490000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (10, 1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 42', N'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 42, 100, CAST(440000 AS Decimal(18, 0)), CAST(490000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (11, 1, 1, N'Adidas Yeezy 700 OG Wave Runner Size 43', N'Adidas Yeezy 700 OG Wave Runner.jpg', N'Xám Đen', 43, 100, CAST(440000 AS Decimal(18, 0)), CAST(490000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (12, 1, 1, N'Adidas Yzy 700 V2 Static Size 39', N'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 39, 100, CAST(520000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (13, 1, 1, N'Adidas Yzy 700 V2 Static Size 40', N'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 40, 200, CAST(520000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (14, 1, 1, N'Adidas Yzy 700 V2 Static Size 41', N'Adidas Yzy 700 V2 Static.jpeg', N'Xám', 41, 150, CAST(520000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (15, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 39', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 39, 100, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (16, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 40', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 40, 200, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (17, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 41', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 41, 150, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (18, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 42', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 42, 120, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (19, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 43', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 43, 250, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (20, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 44', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 44, 100, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (21, 1, 2, N'Converse Chuck 70 Seasonal Color Ao Refresh Size 45', N'Converse Chuck 70 Seasonal Color Ao Refresh.jpg', N'Nâu', 45, 150, CAST(315000 AS Decimal(18, 0)), CAST(350000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (22, 1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 39', N'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 39, 100, CAST(450000 AS Decimal(18, 0)), CAST(520000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (23, 1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 40', N'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 40, 200, CAST(450000 AS Decimal(18, 0)), CAST(520000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (24, 1, 2, N'Converse Chuck 1970s Hybrid Floral Low Top Size 41', N'Converse Chuck 1970s Hybrid Floral Low Top.jpg', N'Hồng', 41, 150, CAST(450000 AS Decimal(18, 0)), CAST(520000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (25, 1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 40', N'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 40, 200, CAST(525000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (26, 1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 41', N'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 41, 150, CAST(525000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (27, 1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 42', N'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 42, 100, CAST(525000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (28, 1, 3, N'Nike Air Force 1 Canvas Smoke Grey Size 43', N'Nike Air Force 1 Canvas Smoke Grey.png', N'Xám Khói', 43, 140, CAST(525000 AS Decimal(18, 0)), CAST(560000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (29, 1, 3, N'Nike Air Force 1 Low Size 39', N'Nike Air Force 1 Low.png', N'Trắng', 39, 100, CAST(370000 AS Decimal(18, 0)), CAST(430000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (30, 1, 3, N'Nike Air Force 1 Low Size 40', N'Nike Air Force 1 Low.png', N'Trắng', 40, 200, CAST(370000 AS Decimal(18, 0)), CAST(430000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (31, 1, 3, N'Nike Air Force 1 Low Size 41', N'Nike Air Force 1 Low.png', N'Trắng', 41, 150, CAST(370000 AS Decimal(18, 0)), CAST(430000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (32, 1, 3, N'Nike Air Force 1 Low Size 42', N'Nike Air Force 1 Low.png', N'Trắng', 42, 50, CAST(370000 AS Decimal(18, 0)), CAST(430000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (33, 1, 3, N'Nike Air Force1 Shadow Team Size 39', N'Nike Air Force1 Shadow Team.jpg', N'Cam', 39, 100, CAST(415000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (34, 1, 3, N'Nike Air Force1 Shadow Team Size 40', N'Nike Air Force1 Shadow Team.jpg', N'Cam', 40, 200, CAST(415000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (35, 1, 3, N'Nike Air Force1 Shadow Team Size 41', N'Nike Air Force1 Shadow Team.jpg', N'Cam', 41, 150, CAST(415000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (36, 1, 3, N'Nike Air Force1 Shadow Team Size 42', N'Nike Air Force1 Shadow Team.jpg', N'Cam', 42, 150, CAST(415000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (37, 1, 3, N'Nike Air Force1 Shadow Team Size 43', N'Nike Air Force1 Shadow Team.jpg', N'Cam', 43, 150, CAST(415000 AS Decimal(18, 0)), CAST(450000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (38, 1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 39', N'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 39, 100, CAST(620000 AS Decimal(18, 0)), CAST(660000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (39, 1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 40', N'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 40, 200, CAST(620000 AS Decimal(18, 0)), CAST(660000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (40, 1, 3, N'Nike Air Jordan 4 Retro Fire Red 2020 Size 41', N'Nike Air Jordan 4 Retro Fire Red 2020.jpeg', N'Đỏ', 41, 150, CAST(620000 AS Decimal(18, 0)), CAST(660000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (41, 1, 3, N'Nike Ari Max 97 Size 39', N'Nike Ari Max 97.jpg', N'Trắng', 39, 100, CAST(365000 AS Decimal(18, 0)), CAST(410000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (42, 1, 3, N'Nike Ari Max 97 Size 40', N'Nike Ari Max 97.jpg', N'Trắng', 40, 200, CAST(365000 AS Decimal(18, 0)), CAST(410000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (43, 1, 3, N'Nike Ari Max 97 Size 41', N'Nike Ari Max 97.jpg', N'Trắng', 41, 150, CAST(365000 AS Decimal(18, 0)), CAST(410000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (44, 1, 3, N'Nike Ari Max 97 Size 42', N'Nike Ari Max 97.jpg', N'Trắng', 42, 50, CAST(365000 AS Decimal(18, 0)), CAST(410000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (45, 1, 4, N'Vans Old Skool Classic Black Size 39', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 39, 100, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (46, 1, 4, N'Vans Old Skool Classic Black Size 40', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 40, 200, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (47, 1, 4, N'Vans Old Skool Classic Black Size 41', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 41, 150, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (48, 1, 4, N'Vans Old Skool Classic Black Size 42', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 42, 250, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (49, 1, 4, N'Vans Old Skool Classic Black Size 43', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 43, 100, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (50, 1, 4, N'Vans Old Skool Classic Black Size 44', N'VANS OLD SKOOL CLASSIC BLACK.png', N'Đen', 44, 50, CAST(520000 AS Decimal(18, 0)), CAST(550000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (51, 2, 1, N'Tất Adidas Sneaker Đen', N'Tất Adidas Sneaker Đen.png', N'Đen', 0, 100, CAST(90000 AS Decimal(18, 0)), CAST(120000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (52, 2, 2, N'Tât Converse Core Single Footie Đen', N'Tât Converse Core Single Footie Đen.png', N'Đen', 0, 200, CAST(80000 AS Decimal(18, 0)), CAST(115000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (53, 2, 3, N'Tất Nike Cổ Thấp Xanh Dương', N'Tất Nike Cổ Thấp Xanh Dương.jpg', N'Xanh Dương', 0, 130, CAST(80000 AS Decimal(18, 0)), CAST(110000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (54, 2, 3, N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Tím', N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Tím.png', N'Tím', 0, 150, CAST(95000 AS Decimal(18, 0)), CAST(130000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (55, 2, 3, N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Xanh Da Trời', N'Tất Nike Dri-Fit Cao Cấp Cổ Lửng Xanh Da Trời.png', N'Xanh Da Trời', 0, 120, CAST(95000 AS Decimal(18, 0)), CAST(130000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (56, 2, 4, N'Tất Vans Mn Ap Cn Vans Trắng', N'Tất Vans Mn Ap Cn Vans Trắng.png', N'Trắng', 0, 160, CAST(100000 AS Decimal(18, 0)), CAST(140000 AS Decimal(18, 0)), NULL, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoaiSP], [MaNCC], [TenSP], [HinhAnh], [MauSac], [Size], [SoLuong], [GiaNhap], [GiaBan], [MoTa], [TrangThai]) VALUES (57, 2, 4, N'Tất Vans Wm Double Take Crew Sock Đen', N'Tất Vans Wm Double Take Crew Sock Đen.png', N'Đen', 0, 140, CAST(900000 AS Decimal(18, 0)), CAST(130000 AS Decimal(18, 0)), NULL, 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (1, 1, N'1', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (2, 2, N'2', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (3, 3, N'3', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (4, 4, N'4', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (5, 5, N'5', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (6, 6, N'6', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (7, 7, N'7', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (8, 8, N'8', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (9, 9, N'9', N'123', 1)
INSERT [dbo].[TaiKhoan] ([MaTK], [MaNV], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (10, 10, N'10', N'123', 1)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LoaiNhanVien] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaLoaiNV])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNV])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
