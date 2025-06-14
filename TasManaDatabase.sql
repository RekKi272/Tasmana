CREATE DATABASE Tasmana
GO
USE Tasmana
GO

CREATE TABLE PhongBan
(
  maBoPhan VARCHAR(10) NOT NULL,
  tenPB NVARCHAR(50) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100),
  PRIMARY KEY (maBoPhan)
);

CREATE TABLE Nhom
(
  maNhom VARCHAR(10) NOT NULL,
  maTruongNhom VARCHAR(10) NOT NULL,
  maBoPhan VARCHAR(10) NOT NULL,
  PRIMARY KEY (maNhom),
  FOREIGN KEY (maBoPhan) REFERENCES PhongBan(maBoPhan)
);

CREATE TABLE CongViec
(
  maCongViec VARCHAR(10) NOT NULL,
  noiDung NVARCHAR(200) NOT NULL,
  ngayGiao SMALLDATETIME NOT NULL,
  thoiHan SMALLDATETime,
  ngayHoanThanh SMALLDATETIME,
  ngayCapNhat SMALLDATETIME,
  trangThai NVARCHAR(100) NOT NULL,
  ghiChu NVARCHAR(200),
  quyenTruyCap int,
  phiDichVu int,
  PRIMARY KEY (maCongViec)
);

CREATE TABLE Congviec_PhongBan
(
  maCongViec VARCHAR(10) NOT NULL,
  maBoPhan VARCHAR(10) NOT NULL,
  PRIMARY KEY (maCongViec, maBoPhan),
  FOREIGN KEY (maCongViec) REFERENCES congViec(maCongViec),
  FOREIGN KEY (maBoPhan) REFERENCES PhongBan(maBoPhan)
);

CREATE TABLE CongViec_Nhom
(
  maNhom VARCHAR(10) NOT NULL,
  maCongViec VARCHAR(10) NOT NULL,
  PRIMARY KEY (maNhom, maCongViec),
  FOREIGN KEY (maNhom) REFERENCES Nhom(maNhom),
  FOREIGN KEY (maCongViec) REFERENCES congViec(maCongViec)
);

CREATE TABLE CongViec_PDF
(
	maCongViec VARCHAR(10) NOT NULL,
	pdfFile VARBINARY(MAX) NOT NULL ,
	tenFile NVARCHAR(50) NOT NULL,
	fileExten VARCHAR(10) NOT NULL
	PRIMARY KEY (maCongViec),
	FOREIGN KEY (maCongViec) REFERENCES congViec(maCongViec)
)
CREATE TABLE NhanVien
(
  maNhanVien VARCHAR(10) NOT NULL,
  email VARCHAR(100) NOT NULL,
  ho NVARCHAR(100) NOT NULL,
  ten NVARCHAR(100) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  ngaySinh DATE NOT NULL,
  gioiTinh BIT NOT NULL, -- 1 nam, 0 nu
  queQuan NVARCHAR(100) NOT NULL,
  maDinhDanh VARCHAR(20) NOT NULL,
  loaiNhanVien NVARCHAR(20) NOT NULL,
  tinhTrangHonNhan NVARCHAR(20) NOT NULL,
  maSoBHXH VARCHAR(20) NOT NULL,
  daTungLamNV BIT NOT NULL,
  ngayKyHDLD DATE NOT NULL,
  ngayHetHDLD DATE,
  dChiThuongTru NVARCHAR(100) NOT NULL,
  dChiTamTru NVARCHAR(100),
  tinhTrangHDLD NVARCHAR(100) NOT NULL,
  maBoPhan VARCHAR(10),
  maNhom VARCHAR(10),
  PRIMARY KEY (maNhanVien),
  FOREIGN KEY (maNhom) REFERENCES Nhom(maNhom),
  FOREIGN KEY (maBoPhan) REFERENCES PhongBan(maBoPhan),
  UNIQUE (maDinhDanh),
  UNIQUE (maSoBHXH),
  UNIQUE (email),
  UNIQUE (SDT)
);

CREATE TABLE TaiKhoan
(
  maNguoiDung VARCHAR(30) NOT NULL,
  matKhau VARCHAR(100) NOT NULL,
  maNhanVien VARCHAR(10) NOT NULL,
  disable BIT NOT NULL,
  rememberId BIT NOT NULL,
  PRIMARY KEY (maNguoiDung),
  FOREIGN KEY (maNhanVien) REFERENCES nhanVien(maNhanVien)
);


CREATE TABLE CEO
(
  maNhanVien VARCHAR(10) NOT NULL,
  PRIMARY KEY (maNhanVien),
  FOREIGN KEY (maNhanVien) REFERENCES nhanVien(maNhanVien)
);


CREATE TABLE QuanLy
(
  maNhanVien VARCHAR(10) NOT NULL,
  maBoPhan VARCHAR(10) NOT NULL,
  PRIMARY KEY (maNhanVien),
  FOREIGN KEY (maNhanVien) REFERENCES nhanVien(maNhanVien),
  FOREIGN KEY (maBoPhan) REFERENCES phongBan(maBoPhan)
);

CREATE TABLE Congviec_Nhanvien
(
  maNhanVien VARCHAR(10) NOT NULL,
  maCongViec VARCHAR(10) NOT NULL,
  PRIMARY KEY (maNhanVien, maCongViec),
  FOREIGN KEY (maNhanVien) REFERENCES nhanVien(maNhanVien),
  FOREIGN KEY (maCongViec) REFERENCES congViec(maCongViec)
);


CREATE TABLE CuDan
(
  maCuDan VARCHAR(10) NOT NULL,
  hoTen NVARCHAR(100) NOT NULL,
  ngaySinh DATE NOT NULL,
  maDinhDanh VARCHAR(20) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  soTheTamTru VARCHAR(20) NOT NULL,
  ngayChuyenVao DATE NOT NULL,
  ngayChuyenDi DATE NOT NULL,
  soDienNuocHangThang FLOAT NOT NULL,
  tinhTrangCongNo FLOAT NOT NULL,
  duLieuDangKyThuNuoi NVARCHAR(100),
  quocTich NVARCHAR(50) NOT NULL,
  maCuDanNguoiThan VARCHAR(10),
  PRIMARY KEY (maCuDan),
  FOREIGN KEY (maCuDanNguoiThan) REFERENCES CuDan(maCuDan),
  UNIQUE (maDinhDanh),
  UNIQUE (soTheTamTru),
  UNIQUE (email),
  UNIQUE (SDT),
  UNIQUE (soTheTamTru),
);

CREATE TABLE PhuongTien
(
  bienSo VARCHAR(50) NOT NULL,
  chungLoai NVARCHAR(50) NOT NULL,
  tinhTrangSoHuu NVARCHAR(50) NOT NULL,
  PRIMARY KEY (bienSo)
);


CREATE TABLE KhachThueKhuThuongMai
(
  maKhachDangThue VARCHAR(10) NOT NULL,
  tenCongTy NVARCHAR(200) NOT NULL,
  hoTenNguoiDaiDien NVARCHAR(200) NOT NULL,
  maNhanVienPhuTrach VARCHAR(10) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  ngayKyHopDongThue DATE NOT NULL,
  ngayChuyenVao DATE NOT NULL,
  ngayChuyenDi DATE,
  phiQuanLy INT NOT NULL,
  moTaKhuVucChoThue NVARCHAR(500),
  bienSoXeDangKy VARCHAR(50),
  PRIMARY KEY (maKhachDangThue),
  FOREIGN KEY (maNhanVienPhuTrach) REFERENCES NhanVien (maNhanVien),
);


CREATE TABLE KhuThuongMai
(
  maCanHo VARCHAR(10) NOT NULL,
  dienTichGSA FLOAT NOT NULL,
  dienTichNSA FLOAT NOT NULL,
  viTriTang INT NOT NULL,
  soLuongPhongNgu INT NOT NULL,
  soLuongToilet INT NOT NULL,
  soDoMatBang IMAGE,
  mucPhiQLHangThang INT NOT NULL,
  soLuongTheThangMay INT NOT NULL,
  tinhTrangThanhToan INT NOT NULL,
  maKhachDangThue VARCHAR(10) NOT NULL,
  PRIMARY KEY (maCanHo),
);

CREATE TABLE LichSuGiaoDichKhuThuongMai
(
  maCanHo VARCHAR(10) NOT NULL,
  maKhachDangThue VARCHAR(10),
  lichSuNopPhiDV DATE NOT NULL,
  lichSuDangKyDoXe DATE NOT NULL,
  tinhTrangCongNo INT NOT NULL,
  PRIMARY KEY (maCanHo, maKhachDangThue),
  FOREIGN KEY (maCanHo) REFERENCES KhuThuongMai(maCanHo),
);

CREATE TABLE CanHo
(
  maCanHo VARCHAR(10) NOT NULL,
  dienTichGSA FLOAT NOT NULL,
  dienTichNSA FLOAT NOT NULL,
  viTriTang INT NOT NULL,
  soLuongPhongNgu INT NOT NULL,
  soLuongToilet INT NOT NULL,
  soDoMatBang IMAGE,
  mucPhiQLHangThang INT NOT NULL,
  soLuongTheThangMay INT NOT NULL,
  tinhTrangGDHienTai NVARCHAR(100) NOT NULL,
  tinhTrangThanhToan INT NOT NULL,
  maCuDan VARCHAR(10),
  PRIMARY KEY (maCanHo),
  FOREIGN KEY (maCuDan) REFERENCES CuDan(maCuDan),
);


CREATE TABLE LichSuGiaoDich
(
  maCanHo VARCHAR(10) NOT NULL,
  maCuDanHienTai VARCHAR(10),
  maCuDanTruoc VARCHAR(10),
  maKhachDangThue VARCHAR(10),
  lichSuNopPhiDV DATE NOT NULL,
  lichSuDangKyDoXe DATE NOT NULL,
  tinhTrangCongNo INT NOT NULL,
  PRIMARY KEY (maCanHo),
  FOREIGN KEY (maCanHo) REFERENCES CanHo(maCanHo),
  FOREIGN KEY (maCuDanHienTai) REFERENCES CuDan(maCuDan),
  FOREIGN KEY (maCuDanTruoc) REFERENCES CuDan(maCuDan),
);

CREATE TABLE ChuHo
(
  maCuDan VARCHAR(10) NOT NULL,
  maCanHo VARCHAR(10) NOT NULL,
  loaiCuDan NVARCHAR(100) NOT NULL,
  hoTen NVARCHAR(100) NOT NULL,
  ngayThangNamSinh DATE NOT NULL,
  maDinhDanh VARCHAR(20) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  quocTich NVARCHAR(100) NOT NULL,
  soTheTamTru VARCHAR(20),
  ngayNhanBanGiaoCanHo DATE NOT NULL,
  ngayChuyenVao DATE NOT NULL,
  ngayChuyenDi DATE,
  soDienNuocNgayBanGiao FLOAT NOT NULL,
  bienSoXeDangKy VARCHAR(50),
  banGiao_maCuDan VARCHAR(10),
  maCuDanLuuTruCung VARCHAR(10),
  tinhTrangCongNo INT NOT NULL,
  duLieuDangKyThuNuoi NVARCHAR(100),
  PRIMARY KEY (maCuDan, maCanHo),
  FOREIGN KEY (maCuDan) REFERENCES CuDan(maCuDan),
  FOREIGN KEY (maCanHo) REFERENCES CanHo(maCanHo),
  FOREIGN KEY (maCuDanLuuTruCung) REFERENCES CuDan(maCuDan),
  UNIQUE (maDinhDanh),
  UNIQUE (soTheTamTru),
  UNIQUE (email),
  UNIQUE (SDT),
  UNIQUE (soTheTamTru),
);

CREATE TABLE NguoiDcUyQuyenChuHo
(
  maCuDan VARCHAR(10) NOT NULL,
  maCanHo VARCHAR(10) NOT NULL,
  loaiCuDan NVARCHAR(100) NOT NULL,
  hoTen NVARCHAR(100) NOT NULL,
  ngayThangNamSinh DATE NOT NULL,
  maDinhDanh VARCHAR(20) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  quocTich NVARCHAR(100) NOT NULL,
  soTheTamTru VARCHAR(20),
  ngayChuyenVao DATE NOT NULL,
  ngayChuyenDi DATE,
  maCuDanLuuTruCung VARCHAR(10),
  bienSoXeDangKy VARCHAR(50),
  tinhTrangCongNo INT NOT NULL,
  duLieuDangKyThuNuoi NVARCHAR(100),
  PRIMARY KEY (maCuDan, maCanHo),
  FOREIGN KEY (maCuDan) REFERENCES cuDan(maCuDan),
  FOREIGN KEY (maCanHo) REFERENCES CanHo(maCanHo),
  FOREIGN KEY (maCuDanLuuTruCung) REFERENCES CuDan(maCuDan),
  UNIQUE (maDinhDanh),
  UNIQUE (soTheTamTru),
  UNIQUE (email),
  UNIQUE (SDT),
  UNIQUE (soTheTamTru),
);


CREATE TABLE KhachNganNgay
(
  maCuDan VARCHAR(10) NOT NULL,
  maCanHo VARCHAR(10) NOT NULL,
  loaiCuDan NVARCHAR(100) NOT NULL,
  hoTen NVARCHAR(100) NOT NULL,
  ngayThangNamSinh DATE NOT NULL,
  maDinhDanh VARCHAR(20) NOT NULL,
  SDT VARCHAR(20) NOT NULL,
  email VARCHAR(100) NOT NULL,
  quocTich NVARCHAR(100) NOT NULL,
  soTheTamTru VARCHAR(20),
  ngayChuyenVao DATE NOT NULL,
  ngayChuyenDi DATE,
  maCuDanLuuTruCung VARCHAR(10),
  bienSoXeDangKy VARCHAR(50),
  tinhTrangCongNo INT NOT NULL,
  duLieuDangKyThuNuoi NVARCHAR(100),
  PRIMARY KEY (maCuDan, maCanHo),
  FOREIGN KEY (maCuDan) REFERENCES CuDan(maCuDan),
  FOREIGN KEY (maCanHo) REFERENCES CanHo(maCanHo),
  FOREIGN KEY (maCuDanLuuTruCung) REFERENCES CuDan(maCuDan),
  UNIQUE (maDinhDanh),
  UNIQUE (soTheTamTru),
  UNIQUE (email),
  UNIQUE (SDT),
  UNIQUE (soTheTamTru),
);


CREATE TABLE YeuCau
(
  maCongViec VARCHAR(10) NOT NULL,
  maCanHo VARCHAR(10) NOT NULL,
  PRIMARY KEY (maCongViec, maCanHo),
  FOREIGN KEY (maCongViec) REFERENCES congViec(maCongViec),
  FOREIGN KEY (maCanHo) REFERENCES canHo(maCanHo),
);

CREATE TABLE CuDan_sdtNguoiThan
(
  sdtNguoiThan VARCHAR(20) NOT NULL,
  maCuDan VARCHAR(10) NOT NULL,
  PRIMARY KEY (sdtNguoiThan, maCuDan),
  FOREIGN KEY (maCuDan) REFERENCES CuDan(maCuDan)
);

CREATE TABLE ChiPhiHangThang
(
	billID int NOT NULL,
	maCanHo VARCHAR(10) NOT NULL,
	soDienHangThang FLOAT,
	soNuocHangThang FLOAT,
	phiQuanLyHangThang INT,
	tinhTrangThanhToan NVARCHAR(100),
	ngayGhi SMALLDATETIME,
	ngayThanhToan SMALLDATETIME,
	PRIMARY KEY (billID, maCanHo),
	FOREIGN KEY (maCanHo) REFERENCES CanHo(maCanHo)
);

CREATE TABLE Notice
(
	stt int NOT NULL,
	title NVARCHAR(100) NOT NULL,
	content NVARCHAR(500) NOT NULL,
	dateN SMALLDATETIME NOT NULL,
	author VARCHAR(10) NOT NULL,
	fileN VARBINARY(MAX),
	nameFile NVARCHAR(100),
	fileExten VARCHAR(10),
	priority BIT,
	PRIMARY KEY(stt)
);

CREATE TABLE Notice_To
(
	stt int NOT NULL,
	maBoPhan VARCHAR(10),
	maNhom VARCHAR(10),
	maNhanVien VARCHAR(10),
	isFull BIT,
	FOREIGN KEY (stt) REFERENCES Notice(stt)
);
go


-- Insert thông tin phòng ban
INSERT INTO PhongBan VALUES('DV', N'Hành chính Nhân sự & Dịch vụ Cư dân','0123456789','BCMP_HCNS@gmail.com')
INSERT INTO PhongBan VALUES('VS', N'Vệ Sinh','0123456889','BCMP_VS@gmail.com')
INSERT INTO PhongBan VALUES('TC', N'Tài chính kế toán', '01234444444' ,'BCMP_TCKT@gmail.com')
INSERT INTO PhongBan VALUES('AN', N'An Ninh', '0133333333', 'BCMP_AN@gmail.com')
INSERT INTO PhongBan VALUES('KT', N'Kỹ Thuật Bảo Trì', '01234567912', '@BCM_KT@gmail.com')
INSERT INTO PhongBan VALUES('XD', N'Xây Dựng', '02645816328', '@BCMP_XD@gmail.com')

-- Insert thông tin nhóm
INSERT INTO Nhom VALUES('VSN01', 'VS-002', 'VS')
INSERT INTO Nhom VALUES('VSN02', 'VS-002', 'VS')

-- Insert thông tin tài khoản
INSERT INTO NhanVien VALUES('GD-001', 'jd@gmail.com', 'Ho', 'Khang', '111111111', '1/1/2002', 1, 'TP.HCM', '123456', 'Full-time', N'Độc thân', '1111111', 1, '2024-01-01', '2025-12-31', 'TP.HCM', N'Địa chỉ thường trú GD-001', N'Tốt', null, null)
INSERT INTO NhanVien VALUES('VS-002', 'VS002@gmail.com', 'Vu', 'Quang', '1321312', '1/2/2004', 1, 'TP.HCM', '1234576', 'Part-time', N'Độc thân', '1111211', 1, '2024-01-01', '2025-12-31', 'TP.HCM', 'Chua co', N'Tốt', 'VS','VSN02')
INSERT INTO NhanVien VALUES('VS-003', 'email_nv001@example.com', 'Tran', 'An', '0123456669', '2000-01-01', 0, N'Hà Nội', '072947182653', 'Full-time', N'Độc thân', '01231230213', 1, '2024-01-01', '2025-12-31', N'Địa chỉ thường trú NV001', 'Chua co', N'Tốt', 'VS','VSN01')

--INSERT INTO NhanVien VALUES('KT-005', 'hih@gmail.com', 'Ho', 'Khuyen', '121111111', '1/1/2002', 1, 'TP.HCM', '133456', 'Full-time', N'Độc thân', '1121111', 1, '2024-01-01', '2025-12-31', 'TP.HCM', N'Địa chỉ thường trú KT-005', N'Tốt', 'VS', 'KT01')
--INSERT INTO NhanVien VALUES('XD-006', 'xd006@gmail.com', 'Vo', 'Van F', '147258369', '6/6/1985', 1, N'Hà Nội', '123461', 'Full-time', N'Độc thân', '1111611', 1, '2024-01-01', '2025-12-31', N'Hà Nội', N'Địa chỉ thường trú XD-006', N'Tốt', 'XD01')
--INSERT INTO NhanVien VALUES('HCNS-007', 'hcns007@gmail.com', 'Nguyen', 'Thi G', '258369147', '7/7/1993', 1, 'TP.HCM', '123462', 'Part-time', N'Độc thân', '1111711', 1, '2024-01-01', '2025-12-31', 'TP.HCM', N'Địa chỉ thường trú Q8', N'Tốt', 'HCNS02')
--INSERT INTO NhanVien VALUES('AN-010', 'an010@gmail.com', 'Pham', 'Van K', '258369147', '10/10/1989', 1, 'TP.HCM', '123465', 'Full-time', N'Độc thân', '1111011', 1, '2024-01-01', '2025-12-31', 'TP.HCM', N'Địa chỉ thường trú Q7', N'Tốt', 'AN02')
--INSERT INTO NhanVien VALUES('TC-003', 'tc01@gmail.com', 'Phan', 'Quoc Linh', '40284746', '12/10/2003', 1, 'TP.HCM', '12334', 'Full-time', N'Độc thân', '1111016', 1, '2024-01-03', '2025-12-31', 'TP.HCM', N'Địa chỉ thường trú Q7', N'Tốt', 'TC01')

-- Insert thông tin NV
INSERT INTO TaiKhoan VALUES('GD-001.KHANG.111111111', '123', 'GD-001', 0, 1)
INSERT INTO TaiKhoan VALUES('VS-002.QUANG.1321312', '123', 'VS-002', 0, 0)
INSERT INTO TaiKhoan VALUES('VS-003.AN.0123456669', '123', 'VS-003', 0, 0)

--INSERT INTO TaiKhoan VALUES('KT-005.E.369258147', '123', 'KT-005', 0);
--INSERT INTO TaiKhoan VALUES('XD-006.F.147258369', '123', 'XD-006', 0);
--INSERT INTO TaiKhoan VALUES('HCNS-007.G.258369147', '123', 'HCNS-007', 0);
--INSERT INTO TaiKhoan VALUES('AN-010.K.258369147', '123', 'AN-010', 0);
--INSERT INTO TaiKhoan VALUES('TC-003.LINH.40284746', '123', 'TC-003', 0);
--INSERT INTO TaiKhoan VALUES('ABC-001.THANG.789456', '123', 'ABC-001', 0);
--INSERT INTO TaiKhoan VALUES('XYZ-002.DUONG.456789', '123', 'XYZ-002', 0);

SELECT * FROM TaiKhoan
SELECT * FROM NhanVien

insert into CEO values('GD-001')

SELECT * FROM PhongBan
SELECT * FROM Nhom
-- Insert dữ liệu mẫu cư dân

INSERT INTO CuDan VALUES('CD-001','Nguyen Thi An','2024-01-01','195052003','0987654331','nguyenthian@example.com', '9126543','2024-01-01','2022-01-01', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-002','Tran Van Binh','1980-09-10','198092035','0124456789','tranvanbinh@example.com', '1234567','2024-01-02','2022-01-02', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-003','Le Thi Mai','1999-12-25','139312253','0365947412','lethimai@example.com', '9871235','2024-01-03','2022-01-03', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-004','Pham Van Cuong','1988-08-08','198838083','0123456789','phamvancuong@example.com', '4561238','2024-01-04','2022-01-04', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-005','Hoang Thi Thu','1992-03-18','199203182','0987654341','hoangthithu@example.com', '7894661','2024-01-05','2022-01-05', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-006','Vu Duc Trung','1985-11-30','198512502','0362987412','vuductrung@example.com', '1237894','2024-01-06','2022-01-06', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-007','Nguyen Van An','1996-02-14','199602143','0911234567','nguyenvanan@example.com', '1593572','2024-01-07','2022-01-07', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-008','Tran Thi Hoa','1982-07-05','198207053','0987654351','tranthihoa@example.com', '7539515','2024-01-08','2022-01-08', 2, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-009','Le Van Hieu','1976-04-12','197604223','2123456789','levanhieu@example.com', '4239872','2024-01-09','2022-01-09', 0, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-010','Nguyen Thi Ann','2024-01-01','195052533','0987654371','nguyenthian2@example.com', '9876543','2024-01-01','2022-01-01', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-011','Tran Van Binh','1980-09-10','193095035','1123456789','tranvanbinh2@example.com', '1234537','2024-01-02','2022-01-02', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-012','Le Thi Mai','1999-12-25','199912253','0365917412','lethimai2@example.com', '9871236','2024-01-03','2022-01-03', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-013','Pham Van Cuong','1988-08-08','198808083','0112456789','phamvancuong2@example.com', '4561239','2024-01-04','2022-01-04', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-014','Hoang Thi Thuu','1992-03-18','399203182','0987654311','hoangthithy2@example.com', '7894561','2024-01-05','2022-01-05', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-015','Vu Duc Trungg','1985-11-30','198511302','0361987412','vuductrung2@example.com', '1223894','2024-01-06','2022-01-06', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-016','Nguyen Van Ann','1996-02-14','179602143','0921234567','nguyenvanan2@example.com', '1593532','2024-01-07','2022-01-07', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-017','Tran Thi Hoaa','1982-07-05','198207753','0987354321','tranthihoa2@example.com', '7539514','2024-01-08','2022-01-08', 2, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-018','Le Van Hieuu','1976-04-12','197604123','0113476789','levanhieu2@example.com', '4569872','2024-01-09','2022-01-09', 0, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-019','Pham Thi Lann','1989-01-30','198901302','0365987412','phamthilan2@example.com', '9517532','2024-01-10','2022-01-10', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-020','Nguyen Van Namm','1998-06-22','199806223','0931234567','nguyenvannam2@example.com', '3698521','2024-01-11','2022-01-11', 35, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-021','Tran Thi Hien','1983-09-17','198309173','0987654391','tranthihien2@example.com', '1472583','2024-01-12','2022-01-12', 4, 0, 'cat', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-022','Hoang Van Quann','1975-08-02','197508023','0123456589','hoangvanquan2@example.com', '3698522','2024-01-13','2022-01-13', 25, 0, 'dog', 'vietnam', null);
INSERT INTO CuDan VALUES('CD-023','Le Thi Kimm','1987-03-10','198703103','5365987412','lethikim2@example.com', '9517536','2024-01-14','2022-01-14', 4, 0, 'dog', 'korea', null);
INSERT INTO CuDan VALUES('CD-024','Pham Van Sonn','1997-10-15','199710153','0941234567','phamvanson2@example.com', '1237893','2024-01-15','2022-01-15', 13, 0, 'cat', 'china', null);
select * from CuDan

-- Insert Dữ liệu thử của căn hộ
INSERT INTO CanHo VALUES ('WPHA', 100.5, 100, 36, 5, 2, NULL, 2000000, 2, N'Chưa bán', 50,'CD-001');
INSERT INTO CanHo VALUES ('WPHB', 90.2, 100, 36, 5, 1, NULL, 1500000, 1, N'Đã bán', 75, 'CD-002');
INSERT INTO CanHo VALUES ('WPHC', 110.8, 100, 37, 5, 2, NULL, 2500000, 2, N'Đã bán', 50, 'CD-003');
INSERT INTO CanHo VALUES ('WPHD', 80.0, 100, 37, 5, 1, NULL, 200000, 1, N'Đã bán', 25, 'CD-004');

INSERT INTO CanHo VALUES ('W3501', 80.0, 100, 35, 3, 1, NULL, 100000, 1, N'Chưa bán', 10, 'CD-005');
INSERT INTO CanHo VALUES ('W3502', 80.0, 100, 35, 3, 1, NULL, 1800000, 1, N'Chưa bàn giao - Cư dân đang ở', 15, 'CD-006');
INSERT INTO CanHo VALUES ('W3503', 80.0, 100, 35, 1, 1, NULL, 310000, 1, N'Đã bàn giao - trống', 0, NULL);
INSERT INTO CanHo VALUES ('W3504', 80.0, 100, 35, 2, 1, NULL, 1800000, 1, N'Đã bàn giao - trống', 0, NULL);
INSERT INTO CanHo VALUES ('W3505', 110, 100, 35, 2, 3, NULL, 200, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3506', 75, 100, 35, 1, 1, NULL, 130, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3507', 100, 100, 35, 3, 2, NULL, 170, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3508', 90, 100, 35, 3, 1, NULL, 160, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3509', 80, 100, 35, 1, 2, NULL, 140, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3510', 80.0, 100, 35, 1, 1, NULL, 18000000, 1, N'Chưa bàn giao - Cư dân đang ở', 25, 'CD-009');
INSERT INTO CanHo VALUES ('W3511', 80.0, 100, 35, 3, 1, NULL, 150000, 1, N'Chưa bán', 0, NULL);

INSERT INTO CanHo VALUES ('W3401', 60, 100, 34, 3, 1, NULL, 100, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3402', 110, 100, 34, 3, 1, NULL, 150, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3403', 130, 100, 34, 1, 1, NULL, 180, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3404', 140, 100, 34, 2, 1, NULL, 190, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3405', 90, 100, 34, 2, 1, NULL, 200, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3406', 70, 100, 34, 1,  1, NULL, 130, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3407', 80, 100, 34, 3, 1, NULL, 170, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3408', 100, 100, 34, 3, 1, NULL, 160, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3409', 150, 100, 34, 1, 1, NULL, 140, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3410', 120, 100, 34, 1, 1, NULL, 195, 3, N'Đã bàn giao - trống', 15, NULL);
INSERT INTO CanHo VALUES ('W3411', 80, 100, 34, 3, 1, NULL, 155, 3, N'Đã bàn giao - trống', 15, NULL);

-- Insert statements for W3301 to W3311 with specified values
INSERT INTO CanHo VALUES ('W3301', 60, 100, 33, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3302', 110, 100, 33, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3303', 130, 100, 33, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3304', 140, 100, 33, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3305', 90, 100, 33, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3306', 70, 100, 33, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3307', 80, 100, 33, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3308', 100, 100, 33, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3309', 150, 100, 33, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3310', 120, 100, 33, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3311', 80, 100, 33, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- Insert statements for W3201 to W3211 with random second values between 60 and 150, constant third value of 32, and specified
INSERT INTO CanHo VALUES ('W3201', 60, 100, 32, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3202', 110, 100, 32, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3203', 130, 100, 32, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3204', 140, 100, 32, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3205', 90, 100, 32, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3206', 70, 100, 32, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3207', 80, 100, 32, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3208', 100, 100, 32, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3209', 150, 100, 32, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3210', 120, 100, 32, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3211', 80, 100, 32, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- Insert statements for W3101 to W3111 with random second values between 60 and 150, constant third value of 32, and specified
INSERT INTO CanHo VALUES ('W3101', 60, 100, 31, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3102', 110, 100, 31, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3103', 130, 100, 31, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3104', 140, 100, 31, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3105', 90, 100, 31, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3106', 70, 100, 31, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3107', 80, 100, 31, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3108', 100, 100, 31, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3109', 150, 100, 31, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3110', 120, 100, 31, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3111', 80, 100, 31, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W30
INSERT INTO CanHo VALUES ('W3001', 60, 100, 30, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3002', 110, 100, 30, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3003', 130, 100, 30, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3004', 140, 100, 30, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3005', 90, 100, 30, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3006', 70, 100, 30, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3007', 80, 100, 30, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3008', 100, 100, 30, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3009', 150, 100, 30, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3010', 120, 100, 30, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W3011', 80, 100, 30, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W29
INSERT INTO CanHo VALUES ('W2901', 60, 100, 29, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2902', 110, 100, 29, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2903', 130, 100, 29, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2904', 140, 100, 29, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2905', 90, 100, 29, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2906', 70, 100, 29, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2907', 80, 100, 29, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2908', 100, 100, 29, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2909', 150, 100, 29, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2910', 120, 100, 29, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2911', 80, 100, 29, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W28
INSERT INTO CanHo VALUES ('W2801', 60, 100, 28, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2802', 110, 100, 28, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2803', 130, 100, 28, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2804', 140, 100, 28, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2805', 90, 100, 28, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2806', 70, 100, 28, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2807', 80, 100, 28, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2808', 100, 100, 28, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2809', 150, 100, 28, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2810', 120, 100, 28, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2811', 80, 100, 28, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W27
INSERT INTO CanHo VALUES ('W2701', 60, 100, 27, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2702', 110, 100, 27, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2703', 130, 100, 27, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2704', 140, 100, 27, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2705', 90, 100, 27, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2706', 70, 100, 27, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2707', 80, 100, 27, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2708', 100, 100, 27, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2709', 150, 100, 27, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2710', 120, 100, 27, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2711', 80, 100, 27, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W26
INSERT INTO CanHo VALUES ('W2601', 60, 100, 26, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2602', 110, 100, 26, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2603', 130, 100, 26, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2604', 140, 100, 26, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2605', 90, 100, 26, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2606', 70, 100, 26, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2607', 80, 100, 26, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2608', 100, 100, 26, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2609', 150, 100, 26, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2610', 120, 100, 26, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2611', 80, 100, 26, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W25
INSERT INTO CanHo VALUES ('W2501', 60, 100, 25, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2502', 110, 100, 25, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2503', 130, 100, 25, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2504', 140, 100, 25, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2505', 90, 100, 25, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2506', 70, 100, 25, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2507', 80, 100, 25, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2508', 100, 100, 25, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2509', 150, 100, 25, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2510', 120, 100, 25, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2511', 80, 100, 25, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W24
INSERT INTO CanHo VALUES ('W2401', 60, 100, 24, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2402', 110, 100, 24, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2403', 130, 100, 24, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2404', 140, 100, 24, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2405', 90, 100, 24, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2406', 70, 100, 24, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2407', 80, 100, 24, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2408', 100, 100, 24, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2409', 150, 100, 24, 1, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2410', 120, 100, 24, 1, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2411', 80, 100, 24, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W23
INSERT INTO CanHo VALUES ('W2301', 60, 100, 23, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2302', 110, 100, 23, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2303', 130, 100, 23, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2304', 140, 100, 23, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2305', 90, 100, 23, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2306', 70, 100, 23, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2307', 80, 100, 23, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);

-- W22
INSERT INTO CanHo VALUES ('W2201', 60, 100, 22, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2202', 110, 100, 22, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2203', 130, 100, 22, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2204', 140, 100, 22, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2205', 90, 100, 22, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2206', 70, 100, 22, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2207', 80, 100, 22, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2208', 100, 100, 22, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2209', 150, 100, 22, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2210', 120, 100, 22, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2211', 80, 100, 22, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W21
INSERT INTO CanHo VALUES ('W2101', 60, 100, 21, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2102', 110, 100, 21, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2103', 130, 100, 21, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2104', 140, 100, 21, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2105', 90, 100, 21, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2106', 70, 100, 21, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2107', 80, 100, 21, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2108', 100, 100, 21, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2109', 150, 100, 21, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2110', 120, 100, 21, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2111', 80, 100, 21, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W20
INSERT INTO CanHo VALUES ('W2001', 60, 100, 20, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2002', 110, 100, 20, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2003', 130, 100, 20, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2004', 140, 100, 20, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2005', 90, 100, 20, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2006', 70, 100, 20, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2007', 80, 100, 20, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2008', 100, 100, 20, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2009', 150, 100, 20, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2010', 120, 100, 20, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W2011', 80, 100, 20, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W19
INSERT INTO CanHo VALUES ('W1901', 60, 100, 19, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1902', 110, 100, 19, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1903', 130, 100, 19, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1904', 140, 100, 19, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1905', 90, 100, 19, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1906', 70, 100, 19, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1907', 80, 100, 19, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1908', 100, 100, 19, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1909', 150, 100, 19, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1910', 120, 100, 19, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1911', 80, 100, 19, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W18
INSERT INTO CanHo VALUES ('W1801', 60, 100, 18, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1802', 110, 100, 18, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1803', 130, 100, 18, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1804', 140, 100, 18, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1805', 90, 100, 18, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1806', 70, 100, 18, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1807', 80, 100, 18, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1808', 100, 100, 18, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1809', 150, 100, 18, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1810', 120, 100, 18, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1811', 80, 100, 18, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W17
INSERT INTO CanHo VALUES ('W1701', 60, 100, 17, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1702', 110, 100, 17, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1703', 130, 100, 17, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1704', 140, 100, 17, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1705', 90, 100, 17, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1706', 70, 100, 17, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1707', 80, 100, 17, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1708', 100, 100, 17, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1709', 150, 100, 17, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1710', 120, 100, 17, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1711', 80, 100, 17, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W16
INSERT INTO CanHo VALUES ('W1601', 60, 100, 16, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1602', 110, 100, 16, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1603', 130, 100, 16, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1604', 140, 100, 16, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1605', 90, 100, 16, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1606', 70, 100, 16, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1607', 80, 100, 16, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1608', 100, 100, 16, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1609', 150, 100, 16, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1610', 120, 100, 16, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1611', 80, 100, 16, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W15
INSERT INTO CanHo VALUES ('W1501', 60, 100, 15, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1502', 110, 100, 15, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1503', 130, 100, 15, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1504', 140, 100, 15, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1505', 90, 100, 15, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1506', 70, 100, 15, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1507', 80, 100, 15, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1508', 100, 100, 15, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1509', 150, 100, 15, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1510', 120, 100, 15, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1511', 80, 100, 15, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

-- W14
INSERT INTO CanHo VALUES ('W1401', 60, 100, 14, 3, 3, NULL, 100, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1402', 110, 100, 14, 3, 3, NULL, 150, 2, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1403', 130, 100, 14, 1, 1, NULL, 180, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1404', 140, 100, 14, 2, 2, NULL, 190, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1405', 90, 100, 14, 2, 2, NULL, 200, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1406', 70, 100, 14, 1, 1, NULL, 130, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1407', 80, 100, 14, 3, 3, NULL, 170, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1408', 100, 100, 14, 3, 3, NULL, 160, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1409', 150, 100, 14, 2, 1, NULL, 140, 1, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1410', 120, 100, 14, 2, 1, NULL, 195, 3, N'Chưa bán', 0, NULL);
INSERT INTO CanHo VALUES ('W1411', 80, 100, 14, 3, 3, NULL, 155, 3, N'Chưa bán', 0, NULL);

select * from CanHo

INSERT INTO ChuHo VALUES('CD-001', 'WPHA', N'Chủ hộ', N'Nguyen Dan', '1980-05-10', '123426739', '0123456489', 'test@example.com', N'Việt Nam', '1234367890', '2023-01-01', '2023-01-01', NULL, 50.5, '51J9', 'CD-016', NULL, 20000000, N'Mèo');
INSERT INTO ChuHo VALUES('CD-002', 'WPHB', N'Chủ hộ', N'Hoang Thi Thanh', '1980-05-10', '223456739', '0123156789', 'xoadi@example.com', N'Việt Nam', '2234567890', '2023-01-01', '2023-01-01', NULL, 50.5, '57G2', 'CD-016', NULL, 20000000, N'Mèo');
INSERT INTO ChuHo VALUES('CD-003', 'WPHC', N'Chủ hộ', N'Nguyen An', '1980-05-10', '123436789', '0123456719', 'annguyen@example.com', N'Việt Nam', '3234567890', '2023-01-01', '2023-01-01', NULL, 50.5, '62G4', 'CD-016', NULL, 20000000, N'Mèo');
INSERT INTO ChuHo VALUES('CD-004', 'WPHD', N'Chủ hộ', N'Thi Thao', '1980-05-10', '123256789', '0123456589', 'nguyenthanh@example.com', N'Việt Nam', '4234567890', '2023-01-01', '2023-01-01', NULL, 50.5, '72L3', 'CD-016', NULL, 20000000, N'Mèo');
INSERT INTO ChuHo VALUES('CD-005', 'W3501', N'Chủ hộ', N'Hoang Thi Thu', '1980-05-10', '124456789', '0123455789', 'nguyenvana@example.com', N'Việt Nam', '5234567890', '2023-01-01', '2023-01-01', NULL, 50.5, '93M2', 'CD-016', NULL, 20000000, N'Mèo');
INSERT INTO ChuHo VALUES('CD-006', 'W3502', N'Chủ hộ', N'Vu Duc Trung', '1975-08-20', '987654321', '0987654321', 'phamthib@example.com', N'Việt Nam', '0987654321', '2023-02-01', '2023-02-01', NULL, 45.3, '81L8', 'CD-016', NULL, 0, N'Cún con');
INSERT INTO ChuHo VALUES('CD-009', 'W3510', N'Chủ hộ', N'Le Van Huy', '1990-03-15', '246810235', '1369852471', 'tranan@example.com', N'Việt Nam', '0369252471', '2023-03-01', '2023-03-01', NULL, 60.2, NULL, 'CD-015', 'CD-017', 150000, N'Cún con');
select * from ChuHo



-- Do not delete
INSERT INTO NguoiDcUyQuyenChuHo VALUES('CD-007', 'W3504', N'Người được ủy quyền của chủ hộ', N'Nguyen Thi An', '1988-11-05', '369852147', '0369852472', 'lethid@example.com', N'Việt Nam', '0369852472', '2023-04-01', NULL, NULL, '40P5', 0, N'Chó');
INSERT INTO NguoiDcUyQuyenChuHo VALUES('CD-008', 'W3505', N'Người được ủy quyền của chủ hộ', N'Tran Van Binh', '1982-07-25', '159263478', '0987654322', 'huynhvane@example.com', N'Việt Nam', '0987654322', '2023-05-01', NULL, 'CD-018', '62G4', 0, N'Mèo');
INSERT INTO NguoiDcUyQuyenChuHo VALUES('CD-010', 'W3506', N'Người được ủy quyền của chủ hộ', N'Le Thi Mai', '1970-12-30', '753159246', '0123456780', 'dangthif@example.com', N'Việt Nam', '0123456780', '2023-06-01', '2023-06-01', 'CD-019', '81L8', 1500000, NULL);
INSERT INTO NguoiDcUyQuyenChuHo VALUES('CD-011', 'W3507', N'Người được ủy quyền của chủ hộ', N'Le Van Minh', '1970-12-30', '753151246', '1123456780', 'danga@example.com', N'Việt Nam', '0222456780', '2023-06-01', '2023-06-01', 'CD-020', '93M2', 1500000, NULL);
select * from NguoiDcUyQuyenChuHo


INSERT INTO KhachNganNgay VALUES ('CD-017', 'W3501', N'Khách ngắn ngày', N'Nguyen Van A', '1990-01-15', '123456', '0901234567', 'nguoimau@email.com', N'Việt Nam', '12345678', '2024-04-28', NULL, NULL, '93M2', 20000, N'Chó');
INSERT INTO KhachNganNgay VALUES ('CD-018', 'W3502', N'Khách vãng lai', N'Nguyen Van C', '1985-05-20', '987654', '0909876543', 'ky.su@email.com', N'Việt Nam', '87654321', '2024-04-29', NULL, NULL, '92H3', 3684000, N'Chó');
INSERT INTO KhachNganNgay VALUES ('CD-021', 'W3510', N'Khách ngắn ngày', N'Nguyen Van B', '1988-10-10', '333333', '0987654321', 'ke.toan@email.com', N'Việt Nam', '33333333', '2024-04-30', NULL, NULL, '88N1', 100000, N'Chó');
INSERT INTO KhachNganNgay VALUES ('CD-012', 'WPHA', N'Nhân viên của chủ hộ', N'Nguyen Van D', '1983-12-25', '555555', '0902234567', 'dev@email.com', N'Việt Nam', '55555555', '2024-05-01', NULL, NULL, '81L8', 0, N'Mèo');
INSERT INTO KhachNganNgay VALUES ('CD-013', 'WPHB', N'Khách vãng lai', N'Nguyen Van E', '1995-08-12', '111111', '0912345678', 'lam.dep@email.com', N'Việt Nam', '11111111', '2024-05-02', NULL, NULL, '76T5', 2000000, N'Chó');
INSERT INTO KhachNganNgay VALUES ('CD-014', 'WPHC', N'Khách ngắn ngày', N'Nguyen Van A', '2000-03-05', '222222', '0967654321', 'hoc.sinh@email.com', N'Việt Nam', '22222222', '2024-05-03', NULL, NULL, '40P5', 0, N'Chó');
INSERT INTO KhachNganNgay VALUES ('CD-015', 'WPHD', N'Nhân viên của chủ hộ', N'Nguyen Van F', '1999-07-20', '999999', '0909999999', 'du.hoc.sinh@email.com', N'Việt Nam', '99999999', '2024-05-04', NULL, NULL, '75K3', 1500000, N'Chó');
select * from KhachNganNgay 


insert into LichSuGiaoDich values('WPHA', 'CD-001', 'CD-021', 'CD-012', '1-1-2023', '1-1-2024', 100000000)
insert into LichSuGiaoDich values('WPHB', 'CD-002', 'CD-014', 'CD-013', '1-1-2023', '1-1-2024', 400000000)
insert into LichSuGiaoDich values('WPHC', 'CD-003', 'CD-010', 'CD-014', '1-1-2023', '1-1-2024', 600000000)
insert into LichSuGiaoDich values('WPHD', 'CD-004', 'CD-011', 'CD-015', '1-1-2023', '1-1-2024', 600000000)
insert into LichSuGiaoDich values('W3501', 'CD-005', 'CD-016', 'CD-017', '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3502', 'CD-006', 'CD-016', 'CD-018', '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3503', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3504', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3505', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3506', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3507', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3508', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3509', NULL, NULL, NULL, '1-1-2023', '1-1-2024', 200000000)
insert into LichSuGiaoDich values('W3510', 'CD-009', 'CD-015', 'CD-021', '1-1-2023', '1-1-2024', 200000000)
INSERT INTO LichSuGiaoDich VALUES ('W3401', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3402', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3403', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3404', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3405', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3406', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3407', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3408', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3409', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3410', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
INSERT INTO LichSuGiaoDich VALUES ('W3411', NULL, NULL, NULL, '2023-01-01', '2024-01-01', 200000000);
select * from LichSuGiaoDich


insert into PhuongTien values('59N2', N'Xe máy', N'Đang sở hữu')
insert into PhuongTien values('59H1', N'Xe tải', N'Đang thuê')
INSERT INTO PhuongTien VALUES('62G4', N'Xe buýt', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('51J9', N'Xe khách', N'Đang thuê');
INSERT INTO PhuongTien VALUES('75K3', N'Xe hơi', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('81L8', N'Xe chở hàng', N'Đang thuê');
INSERT INTO PhuongTien VALUES('93M2', N'Xe đạp', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('40P5', N'Xe du lịch', N'Đang thuê');
INSERT INTO PhuongTien VALUES('27R9', N'Xe cứu thương', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('19S6', N'Xe quân sự', N'Đang thuê');
INSERT INTO PhuongTien VALUES('51HB', N'Xe máy', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('65K9', N'Xe buýt', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('37F8', N'Xe tải', N'Đang thuê');
INSERT INTO PhuongTien VALUES('72L3', N'Xe công nông', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('88N1', N'Xe chở học sinh', N'Đang thuê');
INSERT INTO PhuongTien VALUES('14P6', N'Xe khách', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('29X4', N'Xe cảnh sát', N'Đang thuê');
INSERT INTO PhuongTien VALUES('43R7', N'Xe cẩu', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('57G2', N'Xe chở hàng hóa', N'Đang thuê');
INSERT INTO PhuongTien VALUES('76T5', N'Xe vận tải hàng hóa', N'Đang sở hữu');
INSERT INTO PhuongTien VALUES('92H3', N'Xe cứu hỏa', N'Đang thuê');
select * from PhuongTien


insert into KhachThueKhuThuongMai values('K01', N'Công ty A', N'Nguyễn Văn B', 'VS-002', 1234321, 'hyr@gmail.com', '1-1-2023', '1-1-2023', NULL, 10000000, '', '59N2')
insert into KhachThueKhuThuongMai values('K02', N'Công ty B', N'Nguyễn Huỳnh A', 'VS-002', 1234321, 'hihi@gmail.com', '1-1-2023', '1-1-2023', '1-1-2023', 20000000, '', '')
select * from KhachThueKhuThuongMai

INSERT INTO KhuThuongMai VALUES ('KTM1', 1000.5, 1000, 1, 0, 0, NULL, 200000000, 0, 25, 'K01');
INSERT INTO KhuThuongMai VALUES ('KTM2', 1000.5, 1000, 1, 0, 0, NULL, 200000000, 0, 15, 'K02');
INSERT INTO KhuThuongMai VALUES ('KTM3', 1000.5, 1000, 1, 0, 0, NULL, 200000000, 0, 35, 'K01');
INSERT INTO KhuThuongMai VALUES ('KTM4', 1000.5, 1000, 1, 0, 0, NULL, 200000000, 0, 40, 'K02');
INSERT INTO KhuThuongMai VALUES ('KTM5', 1000.5, 1000, 1, 0, 0, NULL, 200000000, 0, 15, 'K01');
select * from KhuThuongMai


insert into LichSuGiaoDichKhuThuongMai values('KTM1', 'K01', '1-1-2023', '1-1-2024', 100000000)
insert into LichSuGiaoDichKhuThuongMai values('KTM2', 'K01', '1-1-2023', '1-1-2024', 400000000)
insert into LichSuGiaoDichKhuThuongMai values('KTM3', 'K01', '1-1-2023', '1-1-2024', 600000000)
insert into LichSuGiaoDichKhuThuongMai values('KTM4', 'K02', '1-1-2023', '1-1-2024', 600000000)
insert into LichSuGiaoDichKhuThuongMai values('KTM5', 'K02', '1-1-2023', '1-1-2024', 200000000)
select * from LichSuGiaoDichKhuThuongMai

-- Insert mẫu công việc
INSERT INTO CongViec VALUES('CV1', N'Quét nhà', '2024-04-08 9:12:00','2024-04-04 12:30:00',null, '2024-04-08 9:12:00',N'Chưa bắt đầu',null,2,100000)
Insert into CongViec_NhanVien Values ('VS-003', 'CV1')
Insert INTO YeuCau VALUES('CV1', 'WPHA')
go

----------------------------------- PROCEDURE -------------------------------------------------------
-- Procedure thêm hóa đơn hàng tháng cho căn hộ
CREATE PROCEDURE [dbo].[SP_ThemChiPhiHangThang]
	@maCanHo VARCHAR(10),
	@soDienHangThang float,
	@soNuocHangThang float,
	@phiQuanLyHangThang int,
	@tinhTrangThanhToan NVARCHAR(100),
	@ngayGhi SMALLDATETIME,
	@ngayThanhToan SMALLDATETIME
AS
BEGIN
	DECLARE @NewBillID int

    -- Tìm giá trị lớn nhất của billID hiện tại trong bảng
    SELECT @NewBillID = ISNULL(MAX(billID), 0) + 1
    FROM ChiPhiHangThang

    -- Trả về giá trị mới cho billID
    SELECT @NewBillID AS NewBillID
	
	-- Thêm hóa đơn 
	INSERT INTO ChiPhiHangThang 
	VALUES (@NewBillID, @maCanHo, @soDienHangThang, @soNuocHangThang, @phiQuanLyHangThang, @tinhTrangThanhToan, @ngayGhi, @ngayThanhToan)
END
-----------------------------------------------
GO
-- Procedure Sửa hóa đơn hàng tháng
CREATE PROCEDURE [dbo].[EditHoaDonHangThang]
	@billID int,
	@maCanHo VARCHAR(10),
	@soDienHangThang float,
	@soNuocHangThang float,
	@phiQuanLyHangThang int,
	@tinhTrangThanhToan NVARCHAR(100),
	@ngayGhi SMALLDATETIME,
	@ngayThanhToan SMALLDATETIME
AS
BEGIN
	UPDATE ChiPhiHangThang
	SET soDienHangThang = @soDienHangThang, 
	soNuocHangThang = @soNuocHangThang, 
	phiQuanLyHangThang = @phiQuanLyHangThang, 
	tinhTrangThanhToan = @tinhTrangThanhToan, 
	ngayGhi = @ngayGhi,
	ngayThanhToan = @ngayThanhToan
	WHERE billID = @billID
END
GO
--Procedure thêm một nhân viên mới
create procedure [dbo].[SP_ThemNhanVien]
	@maNhanVien varchar(10),
	@email varchar(100),
	@ho nvarchar(100),
	@ten nvarchar(100),
	@SDT varchar(20),
	@ngaySinh date,
	@gioiTinh bit,
	@queQuan nvarchar(100),
	@maDinhDanh varchar(20),
	@loaiNhanVien nvarchar(20),
	@tinhTrangHonNhan nvarchar(20),
	@maSoBHXH varchar(20),
	@daTungLamNV bit,
	@ngayKyHDLD date,
	@ngayHetHDLD date,
	@dChiThuongTru nvarchar(100),
	@dChiTamTru nvarchar(100),
	@tinhTrangHDLD nvarchar(100),
	@maBoPhan varchar(10),
	@maNhom varchar(10)
as
begin
	insert into NhanVien 
    values(
        @maNhanVien,
        @email,
        @ho,
		@ten,
        @SDT,
        @ngaySinh,
        @gioiTinh,
        @queQuan,
        @maDinhDanh,
        @loaiNhanVien,
        @tinhTrangHonNhan,
        @maSoBHXH,
        @daTungLamNV,
        @ngayKyHDLD,
        @ngayHetHDLD,
        @dChiThuongTru,
        @dChiTamTru,
        @tinhTrangHDLD,
		@maBoPhan,
        @maNhom
    )
end
go


-- Procedure lấy thông tin nhóm theo mã nhân viên
create procedure [dbo].[SP_LayNhomTheoMaNhanVien]
	@maNhanVien varchar(10)
as
begin
	select n.*
	from NhanVien nv
	inner join Nhom n on n.maNhom = nv.maNhom
	where nv.maNhanVien = @maNhanVien
end
go

-- Procedure lấy thông tin phòng ban theo mã nhóm
create procedure [dbo].[SP_LayPhongBanTheoMaNhom]
	@maNhom varchar(10)
as
begin
	select pb.*
	from Nhom n
	inner join PhongBan pb on pb.maBoPhan = n.maBoPhan
	where n.maNhom = @maNhom
end
go

--Lấy phòng ban theo mã nhân viên
create procedure [dbo].[SP_LayPhongBanTheoMaNhanVien]
	@maNhanVien varchar(10)
as
begin
	select pb.*
	from PhongBan pb
	inner join NhanVien nv on nv.maBoPhan = pb.maBoPhan
	where nv.maNhanVien = @maNhanVien
end
go

-- Procedure cập nhật thông tin nhân viên
create procedure [dbo].[SP_CapNhatNhanVien]
    @maNhanVien varchar(10),
    @email varchar(100),
    @ho nvarchar(100),
    @ten nvarchar(100),
    @SDT varchar(20),
    @ngaySinh date,
    @gioiTinh bit,
    @queQuan nvarchar(100),
    @maDinhDanh varchar(20),
    @loaiNhanVien nvarchar(20),
    @tinhTrangHonNhan nvarchar(20),
    @maSoBHXH varchar(20),
    @daTungLamNV bit,
    @ngayKyHDLD date,
    @ngayHetHDLD date,
    @dChiThuongTru nvarchar(100),
    @dChiTamTru nvarchar(100),
    @tinhTrangHDLD nvarchar(100),
	@maBoPhan varchar(10),
    @maNhom varchar(10)
as
begin
    update NhanVien
    set email = @email,
        ho = @ho,
        ten = @ten,
        SDT = @SDT,
        ngaySinh = @ngaySinh,
        gioiTinh = @gioiTinh,
        queQuan = @queQuan,
        maDinhDanh = @maDinhDanh,
        loaiNhanVien = @loaiNhanVien,
        tinhTrangHonNhan = @tinhTrangHonNhan,
        maSoBHXH = @maSoBHXH,
        daTungLamNV = @daTungLamNV,
        ngayKyHDLD = @ngayKyHDLD,
        ngayHetHDLD = @ngayHetHDLD,
        dChiThuongTru = @dChiThuongTru,
        dChiTamTru = @dChiTamTru,
        tinhTrangHDLD = @tinhTrangHDLD,
		maBoPhan = @maBoPhan,
        maNhom = @maNhom
    where maNhanVien = @maNhanVien;
end
go

-- Procedure auto tự tạo mã công việc
CREATE PROCEDURE [dbo].[Auto_Create_Job]
    @nextJobId VARCHAR(10) OUTPUT
AS
BEGIN
    DECLARE @curNumOfJob INT;
    DECLARE @candidateId VARCHAR(10);
    DECLARE @found BIT = 0;

    -- Lấy số lượng công việc hiện tại
    SELECT @curNumOfJob = COUNT(maCongViec) FROM CongViec;

    -- Tạo mã công việc tiếp theo
    SET @candidateId = 'CV' + CAST(@curNumOfJob + 1 AS VARCHAR(3));

    -- Kiểm tra và tăng mã công việc cho đến khi không còn trùng
    WHILE @found = 0
    BEGIN
        -- Kiểm tra xem mã công việc có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM CongViec WHERE maCongViec = @candidateId)
        BEGIN
            -- Nếu không tồn tại, gán giá trị cho @nextJobId và thoát khỏi vòng lặp
            SET @nextJobId = @candidateId;
            SET @found = 1;
        END
        ELSE
        BEGIN
            -- Nếu tồn tại, tăng mã công việc lên 1 và kiểm tra lại
            SET @curNumOfJob = @curNumOfJob + 1;
            SET @candidateId = 'CV' + CAST(@curNumOfJob + 1 AS VARCHAR(3));
        END
    END
END
--Declare @maCongViec Varchar(10) Exec Auto_Create_Job @maCongViec OUTPUT Print @maCongViec
go
-- Procedure Thêm Công Việc
CREATE PROCEDURE [dbo].[SP_ThemCongViec]
           @noiDung NVARCHAR(200),
           @ngayGiao SMALLDATETIME,
           @thoiHan SMALLDATETIME,
           @ngayHoanThanh SMALLDATETIME,
           @ngayCapNhat SMALLDATETIME,
           @trangThai NVARCHAR(100),
           @ghiChu NVARCHAR(200),
		   @quyenTruyCap int,
		   @phiDichVu int
AS
BEGIN
    DECLARE @maCongViec VARCHAR(10);
    -- Execute Auto_Create_Job to generate the next job ID
    EXEC [dbo].[Auto_Create_Job] @nextJobId = @maCongViec OUTPUT;
    
    -- Insert the new job into the CongViec table
    INSERT INTO CongViec (maCongViec, noiDung, ngayGiao, thoiHan, ngayHoanThanh, ngayCapNhat, trangThai, ghiChu, quyenTruyCap, phiDichVu)
    VALUES (@maCongViec, @noiDung, @ngayGiao, @thoiHan, @ngayHoanThanh, @ngayCapNhat, @trangThai, @ghiChu, @quyenTruyCap, @phiDichVu);
END
go
	
-- Procedure Thêm CongViec_NhanVien
CREATE PROCEDURE [dbo].[ThemCongViec_NhanVien]
           @maNhanVien varchar(10),
		   @maCongViec varchar(10)
AS
BEGIN
    INSERT INTO Congviec_Nhanvien
    VALUES (
           @maNhanVien,
		   @maCongViec
    )
END
go
-- Procedure Thêm CongViec_Nhom
Create PROCEDURE [dbo].[ThemCongViec_Nhom]
           @maNhom varchar(10),
		   @maCongViec varchar(10)
AS
BEGIN
    INSERT INTO CongViec_Nhom
    VALUES (
           @maNhom,
		   @maCongViec
    )
END
go
-- Procedure Thêm CongViec_PhongBan
Create Procedure [dbo].[ThemCongViec_PhongBan]
		   @maCongViec varchar(10),
		   @maBoPhan varchar(10)
AS
BEGIN
    INSERT INTO Congviec_PhongBan
    VALUES (
		   @maCongViec,
		   @maBoPhan
    )
END
go
Create Procedure [dbo].[ThemyeuCau]
			@maCongViec varchar(10),
			@maCanHo varchar(10)
AS
BEGIN
	INSERT INTO YeuCau
    VALUES (
		   @maCongViec,
		   @maCanHo
    )
END
go

--Thêm file PDF
Create Procedure [dbo].[ThemFile]
			@maCongViec varchar(10),
			@pdfFile VARBINARY(MAX),
			@tenFile VARCHAR(50),
			@fileExten VARCHAR(10)
AS
BEGIN
	INSERT INTO CongViec_PDF
    VALUES (
		   @maCongViec,
		   @pdfFile,
		   @tenFile,
		   @fileExten
    )
END
go
-- Procedure Lấy dữ liệu công việc của nhân viên theo ngày
Create Procedure [dbo].[LayCongViecNVTheoNgay]
           @maNhanVien varchar(10),
		   @thoiHan SmallDateTime
AS
BEGIN
    Select CV.*
	From CongViec CV, Congviec_Nhanvien CNV
	Where CV.maCongViec = CNV.maCongViec and CNV.maNhanVien = @maNhanVien and CONVERT(date, CV.thoiHan) = @thoiHan
END
go

-- Procedure thêm tài khoản
create procedure [dbo].[SP_ThemTaiKhoan]
	@maNguoiDung varchar(30),
	@matKhau varchar(100),
	@maNhanVien varchar(10),
	@disable bit
as
begin
	insert into TaiKhoan
	values(@maNguoiDung,
		   @matKhau,
		   @maNhanVien,
		   @disable,
		   0)
end
go

-- Procedure sửa tài khoản nhân viên
create procedure [dbo].[SP_SuaTaiKhoan]
	@maNguoiDung varchar(30),
	@matKhau varchar(100),
	@maNhanVien varchar(10),
	@disable bit
as
begin
	update TaiKhoan
	set maNguoiDung = @maNguoiDung,
		matKhau = @matKhau,
		disable = @disable
	where maNhanVien = @maNhanVien
end
go

--Procedure thay đổi mật khẩu tài khoản
create procedure [dbo].[SP_DoiMatKhau]
	@maNguoiDung varchar(30),
	@matKhau varchar(100)
as
begin
	update TaiKhoan
	set matKhau = @matKhau
	where maNguoiDung = @maNguoiDung
end
go
-- Procedure Cập nhật Công Việc
Create Procedure [dbo].[SP_EditCongViec]
	@maCongViec Varchar(10),
	@noiDung NVARCHAR(200),
	@thoiHan SMALLDATETIME,
	@ngayHoanThanh SMALLDATETIME,
	@ngayCapNhat SMALLDATETIME,
	@trangThai NVARCHAR(100),
	@ghiChu NVARCHAR(200),
	@quyenTruyCap int,
	@phiDichVu int
as
begin
	Update CongViec
	SET noiDung = @noiDung, thoiHan = @thoiHan, ngayHoanThanh = @ngayHoanThanh, ngayCapNhat = @ngayCapNhat, trangThai = @trangThai, ghiChu = @ghiChu, quyenTruyCap = @quyenTruyCap, phiDichVu = @phiDichVu
	WHERE maCongViec = @maCongViec
end
go
Create Procedure [dbo].[SP_XoaCongViec_NhanVien]
	@maCongViec Varchar(10)
as
begin
	-- Xóa File công việc
	if Exists (Select * From CongViec_PDF Where maCongViec = @maCongViec)
	Begin
		Delete From CongViec_PDF
		Where maCongViec = @maCongViec
	End
	-- Xóa Yêu cầu Công việc
	Delete From YeuCau
	Where maCongViec = @maCongViec
	-- Xóa Công việc nhân viên
	Delete From Congviec_Nhanvien
	Where maCongViec = @maCongViec
	-- Xóa Công việc 
	Delete From CongViec
	Where maCongViec = @maCongViec
end
go


--Procedure cập nhật căn hộ
create procedure [dbo].[SP_CapNhatCanHo]
	@maCanHo varchar(10),
	@dienTichGSA float,
	@dienTichNSA float,
	@viTriTang int,
	@soLuongPhongNgu int,
	@soLuongToilet int,
	@soDoMatBang image,
	@mucPhiQLHangThang int,
	@soLuongTheThangMay int,
	@tinhTrangGDHienTai nvarchar(100),
	@tinhTrangThanhToan int,
	@maCuDan varchar(10)
as
begin
	update CanHo
	set dienTichGSA = @dienTichGSA,
		dienTichNSA = @dienTichNSA,
		viTriTang = @viTriTang,
		soLuongPhongNgu = @soLuongPhongNgu,
		soLuongToilet = @soLuongToilet,
		soDoMatBang = @soDoMatBang,
		mucPhiQLHangThang = @mucPhiQLHangThang,
		soLuongTheThangMay = @soLuongTheThangMay,
		tinhTrangGDHienTai = @tinhTrangGDHienTai,
		tinhTrangThanhToan = @tinhTrangThanhToan,
		maCuDan = @maCuDan
	where maCanHo = @maCanHo
end
GO

--Procedure cập nhật khu thương mại
create procedure [dbo].[SP_CapNhatKhuThuongMai]
	@maCanHo varchar(10),
	@dienTichGSA float,
	@dienTichNSA float,
	@viTriTang int,
	@soLuongPhongNgu int,
	@soLuongToilet int,
	@soDoMatBang image,
	@mucPhiQLHangThang int,
	@soLuongTheThangMay int,
	@tinhTrangThanhToan int,
	@maKhachDangThue varchar(10)
as
begin
	update KhuThuongMai
	set dienTichGSA = @dienTichGSA,
		dienTichNSA = @dienTichNSA,
		viTriTang = @viTriTang,
		soLuongPhongNgu = @soLuongPhongNgu,
		soLuongToilet = @soLuongToilet,
		soDoMatBang = @soDoMatBang,
		mucPhiQLHangThang = @mucPhiQLHangThang,
		soLuongTheThangMay = @soLuongTheThangMay,
		tinhTrangThanhToan = @tinhTrangThanhToan,
		maKhachDangThue = @maKhachDangThue
	where maCanHo = @maCanHo
end
GO

create procedure [dbo].[SP_XoaKhuThuongMai]
	@maCanHo varchar(10)
as
begin
	delete from LichSuGiaoDichKhuThuongMai where maCanHo = @maCanHo
	delete from KhuThuongMai where maCanHo = @maCanHo
end
go

create procedure [dbo].[SP_XoaCanHo]
	@maCanHo varchar(10)
as
begin
	delete from LichSuGiaoDich where maCanHo = @maCanHo
	delete from CanHo where maCanHo = @maCanHo
end
go


create procedure [dbo].[ThemPhuongTien]
	@bienSo VARCHAR(50),
	@chungLoai NVARCHAR(50),
	@tinhTrangSoHuu NVARCHAR(50)
as
begin
	insert into PhuongTien
	values(@bienSo, @chungLoai, @tinhTrangSoHuu)
end
go

create procedure [dbo].[SuaPhuongTien]
	@bienSo VARCHAR(50),
	@chungLoai NVARCHAR(50),
	@tinhTrangSoHuu NVARCHAR(50)
as
begin
	update PhuongTien
	set chungLoai = @chungLoai,
		tinhTrangSoHuu = @tinhTrangSoHuu
	where bienSo = @bienSo
end
go



CREATE PROCEDURE [dbo].[SP_ThemKhachThueKTM]
    @maKhachDangThue VARCHAR(10),
    @tenCongTy NVARCHAR(200),
    @hoTenNguoiDaiDien NVARCHAR(200),
    @maNhanVienPhuTrach VARCHAR(10),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @ngayKyHopDongThue DATE,
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @phiQuanLy INT,
    @moTaKhuVucChoThue NVARCHAR(500),
    @bienSoXeDangKy VARCHAR(50)
AS
BEGIN
    INSERT INTO KhachThueKhuThuongMai 
    VALUES (
        @maKhachDangThue,
        @tenCongTy,
        @hoTenNguoiDaiDien,
        @maNhanVienPhuTrach,
        @SDT,
        @email,
        @ngayKyHopDongThue,
        @ngayChuyenVao,
        @ngayChuyenDi,
        @phiQuanLy,
        @moTaKhuVucChoThue,
        @bienSoXeDangKy
    );
END
go

CREATE PROCEDURE [dbo].[SuaKhachThueKTM]
    @maKhachDangThue VARCHAR(10),
    @tenCongTy NVARCHAR(200),
    @hoTenNguoiDaiDien NVARCHAR(200),
    @maNhanVienPhuTrach VARCHAR(10),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @ngayKyHopDongThue DATE,
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @phiQuanLy INT,
    @moTaKhuVucChoThue NVARCHAR(500),
    @bienSoXeDangKy VARCHAR(50)
AS
BEGIN
    UPDATE KhachThueKhuThuongMai
    SET tenCongTy = @tenCongTy,
        hoTenNguoiDaiDien = @hoTenNguoiDaiDien,
        maNhanVienPhuTrach = @maNhanVienPhuTrach,
        SDT = @SDT,
        email = @email,
        ngayKyHopDongThue = @ngayKyHopDongThue,
        ngayChuyenVao = @ngayChuyenVao,
        ngayChuyenDi = @ngayChuyenDi,
        phiQuanLy = @phiQuanLy,
        moTaKhuVucChoThue = @moTaKhuVucChoThue,
        bienSoXeDangKy = @bienSoXeDangKy
    WHERE maKhachDangThue = @maKhachDangThue;
END
GO


create procedure [dbo].[XoaKhachThueKTM]
	@maKhachDangThue varchar(10),
	@bienSo varchar(10)
as
begin
	delete from KhachThueKhuThuongMai where maKhachDangThue = @maKhachDangThue
	delete from PhuongTien where bienSo = @bienSo
end
go

CREATE PROCEDURE [dbo].[ThemChuHo]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayNhanBanGiaoCanHo DATE,
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @soDienNuocNgayBanGiao FLOAT,
    @bienSoXeDangKy VARCHAR(50),
    @banGiao_maCuDan VARCHAR(10),
    @maCuDanLuuTruCung VARCHAR(10),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    INSERT INTO ChuHo
    VALUES (
        @maCuDan, 
        @maCanHo, 
        @loaiCuDan, 
        @hoTen, 
        @ngayThangNamSinh, 
        @maDinhDanh, 
        @SDT, 
        @email,
        @quocTich,
        @soTheTamTru,
        @ngayNhanBanGiaoCanHo,
        @ngayChuyenVao,
        @ngayChuyenDi,
        @soDienNuocNgayBanGiao,
        @bienSoXeDangKy,
        @banGiao_maCuDan,
        @maCuDanLuuTruCung,
        @tinhTrangCongNo,
        @duLieuDangKyThuNuoi
    );
END
GO

CREATE PROCEDURE [dbo].[SuaChuHo]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayNhanBanGiaoCanHo DATE,
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @soDienNuocNgayBanGiao FLOAT,
    @bienSoXeDangKy VARCHAR(50),
    @banGiao_maCuDan VARCHAR(10),
    @maCuDanLuuTruCung VARCHAR(10),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    UPDATE ChuHo
    SET
        loaiCuDan = @loaiCuDan,
        hoTen = @hoTen,
        ngayThangNamSinh = @ngayThangNamSinh,
        maDinhDanh = @maDinhDanh,
        SDT = @SDT,
        email = @email,
        quocTich = @quocTich,
        soTheTamTru = @soTheTamTru,
        ngayNhanBanGiaoCanHo = @ngayNhanBanGiaoCanHo,
        ngayChuyenVao = @ngayChuyenVao,
        ngayChuyenDi = @ngayChuyenDi,
        soDienNuocNgayBanGiao = @soDienNuocNgayBanGiao,
        bienSoXeDangKy = @bienSoXeDangKy,
        banGiao_maCuDan = @banGiao_maCuDan,
        maCuDanLuuTruCung = @maCuDanLuuTruCung,
        tinhTrangCongNo = @tinhTrangCongNo,
        duLieuDangKyThuNuoi = @duLieuDangKyThuNuoi
    WHERE maCuDan = @maCuDan AND maCanHo = @maCanHo;
END
GO

create procedure [dbo].[XoaChuHo]
	@maCuDan varchar(10),
	@bienSo varchar(10)
as
begin
	delete from ChuHo where maCuDan = @maCuDan
	delete from PhuongTien where bienSo = @bienSo
end
go
CREATE PROCEDURE [dbo].[ThemNguoiUyQuyen]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @maCuDanLuuTruCung VARCHAR(10),
    @bienSoXeDangKy VARCHAR(50),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    INSERT INTO NguoiDcUyQuyenChuHo
    VALUES (
        @maCuDan, 
        @maCanHo, 
        @loaiCuDan, 
        @hoTen, 
        @ngayThangNamSinh, 
        @maDinhDanh, 
        @SDT, 
        @email,
        @quocTich,
        @soTheTamTru,
        @ngayChuyenVao,
        @ngayChuyenDi,
        @maCuDanLuuTruCung,
        @bienSoXeDangKy,
        @tinhTrangCongNo,
        @duLieuDangKyThuNuoi
    );
END
GO



CREATE PROCEDURE [dbo].[SuaNguoiUyQuyen]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @maCuDanLuuTruCung VARCHAR(10),
    @bienSoXeDangKy VARCHAR(50),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    UPDATE NguoiDcUyQuyenChuHo
    SET
        loaiCuDan = @loaiCuDan,
        hoTen = @hoTen,
        ngayThangNamSinh = @ngayThangNamSinh,
        maDinhDanh = @maDinhDanh,
        SDT = @SDT,
        email = @email,
        quocTich = @quocTich,
        soTheTamTru = @soTheTamTru,
        ngayChuyenVao = @ngayChuyenVao,
        ngayChuyenDi = @ngayChuyenDi,
        maCuDanLuuTruCung = @maCuDanLuuTruCung,
        bienSoXeDangKy = @bienSoXeDangKy,
        tinhTrangCongNo = @tinhTrangCongNo,
        duLieuDangKyThuNuoi = @duLieuDangKyThuNuoi
    WHERE maCuDan = @maCuDan AND maCanHo = @maCanHo;
END
GO

create procedure [dbo].[XoaNguoiUyQuyen]
	@maCuDan varchar(10),
	@bienSo varchar(10)
as
begin
	delete from NguoiDcUyQuyenChuHo where maCuDan = @maCuDan
	delete from PhuongTien where bienSo = @bienSo
end
go

CREATE PROCEDURE [dbo].[ThemKhachNganNgay]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @maCuDanLuuTruCung VARCHAR(10),
    @bienSoXeDangKy VARCHAR(50),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    INSERT INTO KhachNganNgay
    VALUES (
        @maCuDan, 
        @maCanHo, 
        @loaiCuDan, 
        @hoTen, 
        @ngayThangNamSinh, 
        @maDinhDanh, 
        @SDT, 
        @email,
        @quocTich,
        @soTheTamTru,
        @ngayChuyenVao,
        @ngayChuyenDi,
        @maCuDanLuuTruCung,
        @bienSoXeDangKy,
        @tinhTrangCongNo,
        @duLieuDangKyThuNuoi
    );
END
GO


CREATE PROCEDURE [dbo].[SuaKhachNganNgay]
    @maCuDan VARCHAR(10),
    @maCanHo VARCHAR(10),
    @loaiCuDan NVARCHAR(100),
    @hoTen NVARCHAR(100),
    @ngayThangNamSinh DATE,
    @maDinhDanh VARCHAR(20),
    @SDT VARCHAR(20),
    @email VARCHAR(100),
    @quocTich NVARCHAR(100),
    @soTheTamTru VARCHAR(20),
    @ngayChuyenVao DATE,
    @ngayChuyenDi DATE,
    @maCuDanLuuTruCung VARCHAR(10),
    @bienSoXeDangKy VARCHAR(50),
    @tinhTrangCongNo INT,
    @duLieuDangKyThuNuoi NVARCHAR(100)
AS
BEGIN
    UPDATE KhachNganNgay
    SET
        loaiCuDan = @loaiCuDan,
        hoTen = @hoTen,
        ngayThangNamSinh = @ngayThangNamSinh,
        maDinhDanh = @maDinhDanh,
        SDT = @SDT,
        email = @email,
        quocTich = @quocTich,
        soTheTamTru = @soTheTamTru,
        ngayChuyenVao = @ngayChuyenVao,
        ngayChuyenDi = @ngayChuyenDi,
        maCuDanLuuTruCung = @maCuDanLuuTruCung,
        bienSoXeDangKy = @bienSoXeDangKy,
        tinhTrangCongNo = @tinhTrangCongNo,
        duLieuDangKyThuNuoi = @duLieuDangKyThuNuoi
    WHERE maCuDan = @maCuDan AND maCanHo = @maCanHo;
END
--------------------------------
GO
-- Xóa khách ngắn ngày
create procedure [dbo].[XoaKhachNganNgay]
	@maCuDan varchar(10),
	@bienSo varchar(10)
as
begin
	delete from KhachNganNgay where maCuDan = @maCuDan
	delete from PhuongTien where bienSo = @bienSo
end
go
-- Kiểm tra trùng mã cư dân
CREATE PROCEDURE [dbo].[KiemTraTrungMaCuDan]
    @maCuDan VARCHAR(10),
    @exists BIT OUTPUT
AS
BEGIN
    DECLARE @user_count INT;

    -- Check Table 1
    SELECT @user_count = COUNT(*)
    FROM ChuHo
    WHERE maCuDan = @maCuDan;

    IF @user_count > 0
    BEGIN
        SET @exists = 1;
        RETURN;
    END

    -- Check Table 2
    SELECT @user_count = COUNT(*)
    FROM NguoiDcUyQuyenChuHo
    WHERE maCuDan = @maCuDan;

    IF @user_count > 0
    BEGIN
        SET @exists = 1;
        RETURN;
    END

    -- Check Table 3
    SELECT @user_count = COUNT(*)
    FROM KhachNganNgay
    WHERE maCuDan = @maCuDan;

    IF @user_count > 0
    BEGIN
        SET @exists = 1;
        RETURN;
    END

    SET @exists = 0;
END
---------------------------------------------------------------------------------
go
-- Procedure thêm Nhóm
Create PROCEDURE [dbo].[SP_ThemNhom]
	@maNhom VARCHAR(10),
	@maTruongNhom VARCHAR(10),
	@maBoPhan VARCHAR(10)
AS
BEGIN
	INSERT INTO Nhom
	Values (@maNhom, @maTruongNhom, @maBoPhan)
END
GO

---Lấy danh sách nhân viên có chức vụ
CREATE PROCEDURE [dbo].[Count_Job_State]
AS
BEGIN
    SELECT NV.maNhanVien,
           NV.ho,
           NV.ten,
           NV.maDinhDanh,
           NV.maBoPhan,
           CASE
               WHEN QL.maNhanVien IS NOT NULL AND N.maNhom IS NOT NULL THEN N'Quản Lý/Trưởng Nhóm'
               WHEN QL.maNhanVien IS NOT NULL THEN N'Quản Lý'
               WHEN CEO.maNhanVien IS NOT NULL THEN 'CEO'
               WHEN NV.maNhanVien IN (SELECT maTruongNhom FROM Nhom) THEN N'Trưởng Nhóm'
               ELSE 'Nhân viên'
           END AS chucVu,
           ISNULL(TongCongViec.Count, 0) + ISNULL(congViecPhongBan.Count, 0) + ISNULL(congViecNhom.Count, 0) AS tongCongViec,
           ISNULL(HoanThanh.Count, 0) AS hoanThanh,
           ISNULL(ChuaBatDau.Count, 0) AS chuaBatDau,
           ISNULL(DangThucHien.Count, 0) AS dangThucHien,
           ISNULL(TreHan.Count, 0) AS treHan,
           ISNULL(congViecPhongBan.Count, 0) AS congViecPhongBan,
           ISNULL(congViecNhom.Count, 0) AS congViecNhom
    FROM NhanVien NV
        LEFT JOIN QuanLy QL ON NV.maNhanVien = QL.maNhanVien
        LEFT JOIN CEO ON NV.maNhanVien = CEO.maNhanVien
        LEFT JOIN Nhom N ON NV.maNhom = N.maNhom
        LEFT JOIN (
            SELECT maNhanVien, COUNT(*) AS Count
            FROM Congviec_Nhanvien
            GROUP BY maNhanVien
        ) AS TongCongViec ON NV.maNhanVien = TongCongViec.maNhanVien
        LEFT JOIN (
            SELECT maNhanVien, COUNT(*) AS Count
            FROM Congviec_Nhanvien CNV
            JOIN CongViec CV ON CNV.maCongViec = CV.maCongViec AND CV.trangThai = N'Hoàn thành'
            GROUP BY maNhanVien
        ) AS HoanThanh ON NV.maNhanVien = HoanThanh.maNhanVien
        LEFT JOIN (
            SELECT maNhanVien, COUNT(*) AS Count
            FROM Congviec_Nhanvien CNV
            JOIN CongViec CV ON CNV.maCongViec = CV.maCongViec AND CV.trangThai = N'Chưa bắt đầu'
            GROUP BY maNhanVien
        ) AS ChuaBatDau ON NV.maNhanVien = ChuaBatDau.maNhanVien
        LEFT JOIN (
            SELECT maNhanVien, COUNT(*) AS Count
            FROM Congviec_Nhanvien CNV
            JOIN CongViec CV ON CNV.maCongViec = CV.maCongViec AND CV.trangThai = N'Đang thực hiện'
            GROUP BY maNhanVien
        ) AS DangThucHien ON NV.maNhanVien = DangThucHien.maNhanVien
        LEFT JOIN (
            SELECT maNhanVien, COUNT(*) AS Count
            FROM Congviec_Nhanvien CNV
            JOIN CongViec CV ON CNV.maCongViec = CV.maCongViec AND CV.trangThai = N'Trễ hạn'
            GROUP BY maNhanVien
        ) AS TreHan ON NV.maNhanVien = TreHan.maNhanVien
        LEFT JOIN (
            SELECT QL.maNhanVien, CPB.maBoPhan, COUNT(*) AS Count
            FROM QuanLy QL
            JOIN CongViec_PhongBan CPB ON QL.maBoPhan = CPB.maBoPhan
            GROUP BY QL.maNhanVien, CPB.maBoPhan
        ) AS congViecPhongBan ON NV.maNhanVien = congViecPhongBan.maNhanVien AND NV.maBoPhan = congViecPhongBan.maBoPhan
        LEFT JOIN (
            SELECT NV.maNhanVien, N.maNhom, COUNT(*) AS Count
            FROM Nhom N
            JOIN NhanVien NV ON N.maNhom = NV.maNhom
            JOIN CongViec_Nhom CN ON N.maNhom = CN.maNhom
            GROUP BY NV.maNhanVien, N.maNhom
        ) AS congViecNhom ON NV.maNhanVien = congViecNhom.maNhanVien;
END
GO

-- Tạo Trigger tự động kiểm tra tình trạng công việc
CREATE TRIGGER CheckLateJob
ON CongViec
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra các bản ghi bị cập nhật
    IF UPDATE(trangThai) OR UPDATE(ngayHoanThanh) OR UPDATE(thoiHan)
    BEGIN
        -- Cập nhật trạng thái thành 'Trễ hạn' nếu trạng thái không phải 'Hoàn thành', ngày hoàn thành là NULL, và thời hạn đã qua hoặc ngày hoàn thành muộn hơn thời hạn
        UPDATE CongViec
        SET trangThai = N'Trễ hạn'
        WHERE ngayHoanThanh != null and ((CAST(thoiHan AS datetime) < CAST(GETDATE() AS datetime) OR CAST(ngayHoanThanh AS datetime) > CAST(thoiHan AS datetime))) ;
    END
END;
GO

---Lấy công việc của nhân viên có phân quyền
CREATE PROCEDURE [dbo].[Job_Of_Employees]
    @quyen int
AS
BEGIN
    IF @quyen = 3
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               Congviec_Nhanvien.maNhanVien as N'Mã nhân viên', 
               NhanVien.ho as N'Họ', 
               NhanVien.ten as N'Tên', 
               NhanVien.maNhom as N'Mã nhóm', 
               NhanVien.maBoPhan as N'Mã Bộ phận', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM NhanVien, CongViec, Congviec_Nhanvien, YeuCau 
        WHERE NhanVien.maNhanVien = Congviec_Nhanvien.maNhanVien 
              AND Congviec_Nhanvien.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec;
    END
    ELSE
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               Congviec_Nhanvien.maNhanVien as N'Mã nhân viên', 
               NhanVien.ho as N'Họ', 
               NhanVien.ten as N'Tên', 
               NhanVien.maNhom as N'Mã nhóm', 
               NhanVien.maBoPhan as N'Mã Bộ phận', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM NhanVien, CongViec, Congviec_Nhanvien, YeuCau 
        WHERE NhanVien.maNhanVien = Congviec_Nhanvien.maNhanVien 
              AND Congviec_Nhanvien.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec 
              AND CongViec.quyenTruyCap = @quyen;
    END
END
GO

---Lấy công việc của nhóm có phân quyền
CREATE PROCEDURE [dbo].[Job_Of_Groups]
    @quyen int
AS
BEGIN
    IF @quyen = 3
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               CongViec_Nhom.maNhom as N'Mã nhóm', 
               Nhom.maTruongNhom as N'Mã Trưởng Nhóm', 
               Nhom.maBoPhan as N'Mã Bộ phận', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM Nhom, CongViec, Congviec_Nhom, YeuCau 
        WHERE Nhom.maNhom = Congviec_Nhom.maNhom 
              AND Congviec_Nhom.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec;
    END
    ELSE
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               CongViec_Nhom.maNhom as N'Mã nhóm', 
               Nhom.maTruongNhom as N'Mã Trưởng Nhóm', 
               Nhom.maBoPhan as N'Mã Bộ phận', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM Nhom, CongViec, Congviec_Nhom, YeuCau 
        WHERE Nhom.maNhom = Congviec_Nhom.maNhom 
              AND Congviec_Nhom.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec 
              AND CongViec.quyenTruyCap = @quyen;
    END
END
GO

insert into QuanLy Values ('VS-002','VS')
GO
--Lấy công việc phòng ban có phân quyền
CREATE PROCEDURE [dbo].[Job_Of_Divisions]
    @quyen int
AS
BEGIN
    IF @quyen = 3
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               Congviec_PhongBan.maBoPhan as N'Mã Bộ phận', 
               QuanLy.maNhanVien as N'Mã quản lý', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM PhongBan, CongViec, Congviec_PhongBan, YeuCau, QuanLy
        WHERE PhongBan.maBoPhan = Congviec_PhongBan.maBoPhan 
              AND Congviec_PhongBan.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec 
              AND QuanLy.maBoPhan = PhongBan.maBoPhan;
    END
    ELSE
    BEGIN
        SELECT CongViec.maCongViec as N'Mã công việc', 
               Congviec_PhongBan.maBoPhan as N'Mã Bộ phận', 
               QuanLy.maNhanVien as N'Mã quản lý', 
               CongViec.noiDung as N'Nội dung', 
               YeuCau.maCanHo as N'Mã căn hộ', 
               CongViec.ngayGiao as N'Ngày giao', 
               CongViec.ngayCapNhat as N'Ngày cập nhật', 
               CongViec.thoiHan as N'Thời hạn', 
               CongViec.ngayHoanThanh as N'Ngày hoàn thành', 
               CongViec.trangThai as N'Trạng thái', 
               CongViec.ghiChu as N'Ghi chú' 
        FROM PhongBan, CongViec, Congviec_PhongBan, YeuCau, QuanLy
        WHERE PhongBan.maBoPhan = Congviec_PhongBan.maBoPhan 
              AND Congviec_PhongBan.maCongViec=CongViec.maCongViec 
              AND YeuCau.maCongViec = CongViec.maCongViec 
              AND QuanLy.maBoPhan = PhongBan.maBoPhan 
              AND CongViec.quyenTruyCap = @quyen;
    END
END
GO
---Tự động tạo số thứ tự thông báo
CREATE PROCEDURE [dbo].[Auto_Create_STT]
    @STT INT OUTPUT
AS
BEGIN
    DECLARE @curNum INT;
    -- Lấy số lượng công việc hiện tại
    SELECT @curNum = COUNT(stt) FROM Notice;
	SET @STT = @curNum +1;
END
go
---Lưu thông báo 
Create Procedure [dbo].[ThemThongBao]
			@title NVARCHAR(100),
			@content NVARCHAR(500),
			@dateN SMALLDATETIME,
			@author VARCHAR(10),
			@fileN VARBINARY(MAX),
			@fileName NVARCHAR(100),
			@fileExten VARCHAR(10),
			@priority int
AS
BEGIN
	DECLARE @stt INT;
	EXEC [dbo].[Auto_Create_STT] @STT = @stt OUTPUT
	INSERT INTO Notice
    VALUES (@stt,@title,@content,@dateN,@author,@fileN,@fileName,@fileExten,@priority)
END
go

---Thêm thông báo không có file đính kèm
Create Procedure [dbo].[ThemThongBaoWithout]
			@title NVARCHAR(100),
			@content NVARCHAR(500),
			@dateN SMALLDATETIME,
			@author VARCHAR(10),
			@priority int
AS
BEGIN
	DECLARE @stt INT;
	DECLARE @fileN VARBINARY(MAX) = NULL; 
	DECLARE @fileName NVARCHAR(100) = NULL;
	DECLARE @fileExten VARCHAR(10) = NULL;
	EXEC [dbo].[Auto_Create_STT] @STT = @stt OUTPUT
	INSERT INTO Notice
    VALUES (@stt,@title,@content,@dateN,@author,@fileN,@fileName,@fileExten,@priority)
END
go

---Thêm người nhận
Create Procedure [dbo].[ThemNguoiNhan]
			@stt int, 
			@maBoPhan varchar(10),
			@maNhom varchar(10),
			@maNhanVien varchar(10),
			@isFull bit
AS
BEGIN
	INSERT INTO Notice_To
    VALUES (@stt,@maBoPhan,@maNhom,@maNhanVien,@isFull)
END
go

-- Thống kê tình trạng công việc của toàn công ty
CREATE PROCEDURE [dbo].[SP_ThongKeCongViecCongTy]
    @tuNgay SMALLDATETIME,
    @denNgay SMALLDATETIME
As
Begin
    SELECT 
        nv.maNhanVien,
        nv.ho,
        nv.ten,
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) = CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'dungHan',
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) < CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'trcHan',
        COUNT(CASE WHEN cv.thoiHan IS NOT NULL AND (cv.trangThai = N'Trễ hạn' OR cv.thoiHan < GETDATE()) THEN 1 END) AS 'treHan',
        COUNT(CASE WHEN cv.trangThai != N'Trễ hạn' and cv.trangThai != N'Hoàn thành' THEN 1 END) AS 'chuaBatDau'
    FROM 
        CongViec cv
    INNER JOIN 
        Congviec_Nhanvien cnv ON cv.maCongViec = cnv.maCongViec
    INNER JOIN 
        NhanVien nv ON cnv.maNhanVien = nv.maNhanVien
    WHERE 
        cv.ngayGiao between @tuNgay and @denNgay
    GROUP BY 
        nv.maNhanVien, nv.ho, nv.ten;
End
GO
-- Thống kê tình trạng công việc của phòng ban
CREATE PROCEDURE [dbo].[SP_ThongKeCongViecPhongBan]
    @tuNgay SMALLDATETIME,
    @denNgay SMALLDATETIME,
	@maBoPhan VARCHAR(10)
As
Begin
    SELECT 
        nv.maNhanVien,
        nv.ho,
        nv.ten,
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) = CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'dungHan',
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) < CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'trcHan',
        COUNT(CASE WHEN cv.thoiHan IS NOT NULL AND (cv.trangThai = N'Trễ hạn' OR cv.thoiHan < GETDATE()) THEN 1 END) AS 'treHan',
        COUNT(CASE WHEN cv.trangThai != N'Trễ hạn' and cv.trangThai != N'Hoàn thành' THEN 1 END) AS 'chuaBatDau'
    FROM 
        CongViec cv
    INNER JOIN 
        Congviec_Nhanvien cnv ON cv.maCongViec = cnv.maCongViec
    INNER JOIN 
        NhanVien nv ON cnv.maNhanVien = nv.maNhanVien
    WHERE 
        cv.ngayGiao between @tuNgay and @denNgay and nv.maBoPhan = @maBoPhan 
    GROUP BY 
        nv.maNhanVien, nv.ho, nv.ten;
End
GO
-- Thống kê tình trạng công việc của Nhân viên
CREATE PROCEDURE [dbo].[SP_ThongKeCongViecNhanVien]
    @tuNgay SMALLDATETIME,
    @denNgay SMALLDATETIME,
	@maNhanVien VARCHAR(10)
As
Begin
    SELECT 
        nv.maNhanVien,
        nv.ho,
        nv.ten,
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) = CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'dungHan',
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL AND CAST(cv.ngayHoanThanh AS DATE) < CAST(cv.thoiHan AS DATE) AND cv.trangThai = N'Hoàn thành' THEN 1 END) AS 'trcHan',
        COUNT(CASE WHEN cv.thoiHan IS NOT NULL AND (cv.trangThai = N'Trễ hạn' OR cv.thoiHan < GETDATE()) THEN 1 END) AS 'treHan',
        COUNT(CASE WHEN cv.trangThai != N'Trễ hạn' and cv.trangThai != N'Hoàn thành' and cv.thoiHan >= GETDATE()THEN 1 END) AS 'chuaBatDau'
    FROM 
        CongViec cv
    INNER JOIN 
        Congviec_Nhanvien cnv ON cv.maCongViec = cnv.maCongViec
    INNER JOIN 
        NhanVien nv ON cnv.maNhanVien = nv.maNhanVien
    WHERE 
        cv.ngayGiao between @tuNgay and @denNgay and nv.maNhanVien = @maNhanVien
    GROUP BY 
        nv.maNhanVien, nv.ho, nv.ten;
End
GO

-- Lấy dịch vụ yêu cầu hiện tại của mã căn hộ
create procedure [dbo].[SP_LayDichVuTheoMaCanHo]
	@maCanHo varchar(10)
as
begin
	select cv.*, nv.maNhanVien, nv.ho, nv.ten from CongViec cv
	inner join YeuCau yc on yc.maCongViec = cv.maCongViec
	inner join Congviec_Nhanvien cvnv on cvnv.maCongViec = cv.maCongViec
	inner join NhanVien nv on nv.maNhanVien = cvnv.maNhanVien
	where yc.maCanHo = @maCanHo
end
------------------------------------ XẾP HẠNG/THỐNG KÊ DỮ LIỆU CHUNG --------------------------------------
GO
-------------------- XẾP HẠNG THEO DOANH THU -----------------------------
-- Xếp hạng Phòng Ban theo doanh thu phí dịch vụ 
Create Procedure [dbo].[XepHangDoanhThuTheoPhongBan]
As 
Begin
	SELECT maBoPhan, tenPB, SUM(TongDoanhThu) AS TongDoanhThu
	FROM (
		SELECT PB.maBoPhan, PB.tenPB, SUM(CV.phiDichVu) AS TongDoanhThu
		FROM PhongBan PB
		JOIN NhanVien NV ON PB.maBoPhan = NV.maBoPhan
		JOIN Congviec_NhanVien CVNV ON NV.maNhanVien = CVNV.maNhanVien
		JOIN CongViec CV ON CVNV.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan, PB.tenPB

		UNION ALL

		SELECT PB.maBoPhan, PB.tenPB, SUM(CV.phiDichVu) AS TongDoanhThu
		FROM PhongBan PB
		JOIN Nhom N ON PB.maBoPhan = N.maBoPhan
		JOIN CongViec_Nhom CVN ON N.maNhom = CVN.maNhom
		JOIN CongViec CV ON CVN.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan, PB.tenPB

		UNION ALL

		SELECT PB.maBoPhan, PB.tenPB, SUM(CV.phiDichVu) AS TongDoanhThu
		FROM PhongBan PB
		JOIN Congviec_PhongBan CVPB ON PB.maBoPhan = CVPB.maBoPhan
		JOIN CongViec CV ON CVPB.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan, PB.tenPB
	) AS TongHop
	GROUP BY maBoPhan, tenPB
	ORDER BY TongDoanhThu DESC;
End
-------------------------------------------------------------------------------------
GO
-- Xếp hạng doanh thu theo Nhân viên
CREATE Procedure [dbo].[XepHangDoanhThuTheoNV]
AS
BEGIN
	SELECT NV.maNhanVien, NV.ho + ' ' + NV.ten AS HoTen, SUM(CV.phiDichVu) AS TongDoanhThu
	FROM NhanVien NV
	JOIN CongViec_NhanVien CVNV ON NV.maNhanVien = CVNV.maNhanVien
	JOIN CongViec CV ON CVNV.maCongViec = CV.maCongViec
	GROUP BY NV.maNhanVien, NV.ho, NV.ten
	ORDER BY TongDoanhThu DESC;
END
-------------------- HẾT XẾP HẠNG THEO DOANH THU -----------------------------
GO
-------------------- XẾP HẠNG THEO TỈ LỆ HOÀN THÀNH CÔNG VIỆC -----------------------------
-- THEO NHÂN VIÊN
CREATE Procedure [dbo].[XepHangTiLeHoanThanhCVTheoNhanVien]
AS
BEGIN
	SELECT 
		NV.maNhanVien, 
		NV.ho + ' ' + NV.ten AS TenNhanVien, 
		ROUND(SUM(TongHoanThanhDungHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhDungHan,
		ROUND(SUM(TongHoanThanhTruocHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhTruocHan,
		ROUND(SUM(TongHoanThanhTreHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhTreHan,
		ROUND(SUM(TongKhongHoanThanh) * 100.0 / SUM(TongSoCV), 2) AS TiLeKhongHoanThanh
	FROM (
		SELECT NV.maNhanVien,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM NhanVien NV
		JOIN Congviec_NhanVien CVNV ON NV.maNhanVien = CVNV.maNhanVien
		JOIN CongViec CV ON CVNV.maCongViec = CV.maCongViec
		GROUP BY NV.maNhanVien

		UNION ALL

		SELECT NV.maNhanVien,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM NhanVien NV
		JOIN Nhom N ON NV.maNhom = N.maNhom
		JOIN CongViec_Nhom CVN ON N.maNhom = CVN.maNhom
		JOIN CongViec CV ON CVN.maCongViec = CV.maCongViec
		GROUP BY NV.maNhanVien

		UNION ALL

		SELECT NV.maNhanVien,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM NhanVien NV
		JOIN Congviec_NhanVien CVNV ON NV.maNhanVien = CVNV.maNhanVien
		JOIN CongViec_PhongBan CVPB ON NV.maBoPhan = CVPB.maBoPhan
		JOIN CongViec CV ON CVNV.maCongViec = CV.maCongViec AND CV.maCongViec = CVPB.maCongViec
		GROUP BY NV.maNhanVien
	) AS TongHop
	JOIN NhanVien NV ON TongHop.maNhanVien = NV.maNhanVien
	GROUP BY NV.maNhanVien, NV.ho, NV.ten
	ORDER BY  TiLeHoanThanhTruocHan DESC, TiLeHoanThanhDungHan DESC, TiLeHoanThanhTreHan DESC, TiLeKhongHoanThanh DESC;
END
GO

-- Xếp hạng theo tỉ lệ hoàn thành công việc Theo Phòng ban
CREATE Procedure [dbo].[XepHangTheoTiLeHoanThanhCongViecTheoPhongBan]
AS
BEGIN
	SELECT 
		PB.maBoPhan, 
		PB.tenPB AS TenPhongBan, 
		ROUND(SUM(TongHoanThanhDungHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhDungHan,
		ROUND(SUM(TongHoanThanhTruocHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhTruocHan,
		ROUND(SUM(TongHoanThanhTreHan) * 100.0 / SUM(TongSoCV), 2) AS TiLeHoanThanhTreHan,
		ROUND(SUM(TongKhongHoanThanh) * 100.0 / SUM(TongSoCV), 2) AS TiLeKhongHoanThanh
	FROM (
		SELECT PB.maBoPhan,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM PhongBan PB
		JOIN Congviec_PhongBan CVPB ON PB.maBoPhan = CVPB.maBoPhan
		JOIN CongViec CV ON CVPB.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan

		UNION ALL

		SELECT PB.maBoPhan,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM PhongBan PB
		JOIN Nhom N ON PB.maBoPhan = N.maBoPhan
		JOIN CongViec_Nhom CVN ON N.maNhom = CVN.maNhom
		JOIN CongViec CV ON CVN.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan

		UNION ALL

		SELECT PB.maBoPhan,
			SUM(CASE WHEN CONVERT(date, CV.ngayHoanThanh) = CONVERT(date, CV.thoiHan) THEN 1 ELSE 0 END) AS TongHoanThanhDungHan,
			SUM(CASE WHEN CV.ngayHoanThanh < CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTruocHan,
			SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan THEN 1 ELSE 0 END) AS TongHoanThanhTreHan,
			SUM(CASE WHEN CV.ngayHoanThanh IS NULL THEN 1 ELSE 0 END) AS TongKhongHoanThanh,
			COUNT(*) AS TongSoCV
		FROM PhongBan PB
		JOIN Congviec_PhongBan CVPB ON PB.maBoPhan = CVPB.maBoPhan
		JOIN CongViec CV ON CVPB.maCongViec = CV.maCongViec
		GROUP BY PB.maBoPhan
	) AS TongHop
	JOIN PhongBan PB ON TongHop.maBoPhan = PB.maBoPhan
	GROUP BY PB.maBoPhan, PB.tenPB
	ORDER BY  TiLeHoanThanhTruocHan DESC, TiLeHoanThanhDungHan DESC, TiLeHoanThanhTreHan DESC, TiLeKhongHoanThanh DESC;
END
-------------------- HẾT XẾP HẠNG THEO TỈ LỆ HOÀN THÀNH CÔNG VIỆC -----------------------------
GO
-------------------- XẾP HẠNG NHÂN VIÊN THEO SỐ CÔNG VIỆC ĐÃ HOÀN THÀNH ---------------------------------
CREATE Procedure [dbo].[XepHangNhanVienTheoSoCongViecDaHoanThanh]
					@tuNgay SMALLDATETIME,
					@denNgay SMALLDATETIME
AS
BEGIN
	SELECT 
		NV.maNhanVien, 
		NV.ho + ' ' + NV.ten AS TenNhanVien, 
		COUNT(CV.ngayHoanThanh) AS SoCongViecHoanThanh
	FROM NhanVien NV
	LEFT JOIN Congviec_NhanVien CVNV ON NV.maNhanVien = CVNV.maNhanVien
	LEFT JOIN CongViec CV ON CVNV.maCongViec = CV.maCongViec
	WHERE CV.ngayHoanThanh IS NOT NULL and CV.ngayGiao between @tuNgay AND @denNgay
	GROUP BY NV.maNhanVien, NV.ho, NV.ten
	ORDER BY SoCongViecHoanThanh DESC;
END
--------------------------------------------------------------------------------------------------
GO
-------------------- XẾP HẠNG PHÒNG BAN THEO SỐ CÔNG VIỆC ĐÃ HOÀN THÀNH THEO NGÀY------------------------------
CREATE PROCEDURE [dbo].[XepHangPhongBanTheoSoCongViecDaHoanThanh]
					@tuNgay SMALLDATETIME,
					@denNgay SMALLDATETIME
AS
BEGIN
    SELECT 
        pb.maBoPhan,
        pb.tenPB AS TenPhongBan,
        COUNT(CASE WHEN cv.ngayHoanThanh IS NOT NULL THEN 1 END) AS SoCongViecHoanThanh
    FROM 
        PhongBan pb
    LEFT JOIN 
        NhanVien nv ON pb.maBoPhan = nv.maBoPhan
    LEFT JOIN 
        Congviec_Nhanvien cnv ON nv.maNhanVien = cnv.maNhanVien
    LEFT JOIN 
        CongViec cv ON cnv.maCongViec = cv.maCongViec
	WHERE cv.ngayGiao BETWEEN @tuNgay AND @denNgay
    GROUP BY 
        pb.maBoPhan, pb.tenPB
	ORDER BY SoCongViecHoanThanh;
END
----------------------------------------------------------------------------------------------------------------
------------------------------------HẾT XẾP HẠNG/THỐNG KÊ DỮ LIỆU CHUNG --------------------------------------
GO
--------------------------- THỐNG KÊ DỮ LIỆU CƯ DÂN -------------------------------------------
------------------------- Thống kê công nợ theo MÃ CĂN HỘ -------------------------------------
-- Thống kê công nợ của TẤT CẢ CĂN HỘ
CREATE PROCEDURE [dbo].[ThongKeCongNo]
AS
BEGIN
	SELECT CH.maCanHo, LSGD.tinhTrangCongNo
	FROM CanHo CH, LichSuGiaoDich LSGD
	WHERE CH.maCanHo = LSGD.maCanHo
	ORDER BY LSGD.tinhTrangCongNo DESC
END
------------------------------------------------------------------------------------------------
GO
-------------------------- Thống kê công nợ của TỪNG CĂN HỘ ---------------------------------------
CREATE PROCEDURE  [dbo].[ThongKeCongNoTheoCanHo]
	@maCanHo VARCHAR(10)
AS
BEGIN
	SELECT CH.maCanHo, LSGD.tinhTrangCongNo
	FROM CanHo CH, LichSuGiaoDich LSGD
	WHERE CH.maCanHo = LSGD.maCanHo and CH.maCanHo = @maCanHo
	ORDER BY LSGD.tinhTrangCongNo DESC
END
------------------------------------------------------------------------------------------------
GO
--------------------------  Danh sách các yêu cầu sửa chữa -------------------------------------
CREATE PROCEDURE [dbo].[DanhSachYeuCauSuaChua]
AS
BEGIN
	SELECT CH.maCanHo, CH.maCuDan, CD.hoTen, CV.trangThai, CVNV.maNhanVien
	FROM CongViec CV, CanHo CH, Congviec_Nhanvien CVNV, YeuCau YC, CuDan CD
	WHERE CV.maCongViec = CVNV.maCongViec and YC.maCanHo = CH.maCanHo and YC.maCongViec = CV.maCongViec and CD.maCuDan = CH.maCuDan
END
------------------------------------------------------------------------------------------------
GO
--------------------------  Tổng chi phí điện nước theo thời gian -------------------------------------
CREATE PROCEDURE [dbo].[ChiPhiDienNuoc]
    @tuNgay SMALLDATETIME,
    @denNgay SMALLDATETIME
AS
BEGIN
    SELECT maCanHo, SUM(soDienHangThang) AS TongDien, SUM(soNuocHangThang) AS TongNuoc
    FROM ChiPhiHangThang
    WHERE CONVERT(date, ngayGhi) BETWEEN CONVERT(date, @tuNgay) AND CONVERT(date, @denNgay)
    GROUP BY maCanHo
END
--------------------------------------------------------------------------------------------------------
GO
--------------------------  Tổng chi phí Quản lý theo thời gian ----------------------------------------
CREATE PROCEDURE [dbo].[ChiPhiQuanLy]
	@tuNgay SMALLDATETIME,
	@denNgay SMALLDATETIME
AS
BEGIN
	SELECT maCanHo, SUM(phiQuanLyHangThang) AS TongPhiQuanLy
    FROM ChiPhiHangThang
    WHERE CONVERT(date, ngayGhi) BETWEEN CONVERT(date, @tuNgay) AND CONVERT(date, @denNgay)
    GROUP BY maCanHo
END
---------------------------------------------------------------------------------------------------------
GO
--------------------------------- Tổng các phí dịch vụ khác----- ----------------------------------------
CREATE PROCEDURE [dbo].[TongPhiDichVuKhac]
	@tuNgay SMALLDATETIME,
	@denNgay SMALLDATETIME
AS
BEGIN
	SELECT YC.maCanHo, SUM(CV.phiDichVu) AS TongPhiDichVuKhac
	FROM CongViec CV, YeuCau YC
	WHERE CV.maCongViec = YC.maCongViec and  CONVERT(date, ngayGiao) BETWEEN CONVERT(date, @tuNgay) AND CONVERT(date, @denNgay)
	GROUP BY YC.maCanHo
END
--------------------------------------------------------------------------------------------------------------
GO
----------------------------------- Thống kê tình trạng căn hộ -----------------------------------------------
CREATE PROCEDURE [dbo].[ThongKeTinhTrangCanHo]
	@tinhTrangCanHo NVARCHAR(100)
AS
BEGIN
	SELECT maCanHo as N'Mã căn hộ', tinhTrangGDHienTai
	FROM CanHo
	WHERE tinhTrangGDHienTai = @tinhTrangCanHo
END
--------------------------------------------------------------------------------------------------------------
GO
----------------------------------- Thống kê tất cả Nhân viên phụ trách công việc tại căn hộ -----------------------------------------
CREATE PROCEDURE [dbo].[ThongKeAllNhanVienOfAparments]
AS
BEGIN
	SELECT  YC.maCanHo, CVNV.maNhanVien, CV.ngayGiao, CV.thoiHan
	FROM CongViec CV, Congviec_Nhanvien CVNV, YeuCau YC
	WHERE CV.maCongViec = CVNV.maCongViec and YC.maCongViec = CV.maCongViec
END
--------------------------------------------------------------------------------------------------------------------------------------
GO
----------------------------------- Thống kê Nhân viên phụ trách công việc tại căn hộ nhất định -----------------------------------------
CREATE PROCEDURE [dbo].[ThongKeNhanVienPhuTrachCanHo]
	@maCanHo VARCHAR(10)
AS
BEGIN
	SELECT YC.maCanHo, CVNV.maNhanVien, CV.ngayGiao, CV.thoiHan
	FROM CongViec CV, Congviec_Nhanvien CVNV, YeuCau YC
	WHERE CV.maCongViec = CVNV.maCongViec and CV.maCongViec = YC.maCongViec and YC.maCanHo = @maCanHo
END
------------------------------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------- Thống kê Cư dân là người nước ngoài --------------------------------------------------------
CREATE PROCEDURE [dbo].[ThongKeCuDanNguocNgoai]
AS
BEGIN
	SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM ChuHo
    WHERE quocTich != 'vietnam' and quocTich != N'Việt Nam'
	UNION

    SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM KhachNganNgay
    WHERE quocTich != 'vietnam' and quocTich != N'Việt Nam'
	UNION

    SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM NguoiDcUyQuyenChuHo
    WHERE quocTich != 'vietnam' and quocTich != N'Việt Nam'
END
------------------------------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------- Thống kê Cư dân là người Việt Nam --------------------------------------------------------
CREATE PROCEDURE [dbo].[ThongKeCuDanVietNam]
AS
BEGIN
    SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM ChuHo
    WHERE quocTich = 'vietnam' OR quocTich = N'Việt Nam'
	UNION

    SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM KhachNganNgay
    WHERE quocTich = 'vietnam' OR quocTich = N'Việt Nam'
	UNION

    SELECT maCuDan as N'Mã cư dân', hoTen as N'Họ tên', SDT as N'Số điện thoại', quocTich as 'Quốc tịch' 
    FROM NguoiDcUyQuyenChuHo
    WHERE quocTich = 'vietnam' OR quocTich = N'Việt Nam'
END
------------------------------------------------------------------------------------------------------------------------------------------
GO
-------------------------------------------------Xong thống kê cư dân---------------------------------------------------------------------
------------------------ Sửa thông tin phòng ban -------------------------------------
CREATE PROCEDURE [dbo].[SP_EditPhongBan]
	@maBoPhan VARCHAR(10),
	@tenPB NVARCHAR(50),
	@SDT VARCHAR(20),
	@email VARCHAR(100)
AS
BEGIN
	Update PhongBan
	SET tenPB = @tenPB, SDT = @SDT, email = @email
	WHERE maBoPhan = @maBoPhan
END
---------------------------------------------------------------------------------------
GO
------------------------- Đếm tổng số công việc của toàn công ty ------------------------------------
CREATE PROCEDURE [dbo].[CountAllJobsState]
AS
BEGIN
    SELECT 
        SUM(SoCVChuaBD) AS TongSoCVChuaBatDau,
        SUM(SoCVDangLam) AS TongSoCVDangLam,
        SUM(SoCVTreHan) AS TongSoCVTreHan,
        SUM(SoCVCoCapNhat) AS TongCVCoCapNhat
    FROM (
        SELECT
            SUM(CASE WHEN CV.trangThai = N'Chưa bắt đầu' THEN 1 ELSE 0 END) AS SoCVChuaBD,
            SUM(CASE WHEN CV.trangThai = N'Đang thực hiện' THEN 1 ELSE 0 END) AS SoCVDangLam,
            SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan AND CV.ngayHoanThanh IS NOT NULL THEN 1 ELSE 0 END) AS SoCVTreHan,
            SUM(CASE WHEN  CV.ngayCapNhat IS NOT NULL AND CONVERT(date,CV.ngayCapNhat) = CONVERT(date, GETDATE()) THEN 1 ELSE 0 END) AS SoCVCoCapNhat
        FROM CongViec CV

        UNION ALL

        SELECT
            SUM(CASE WHEN CV.trangThai = N'Chưa bắt đầu' THEN 1 ELSE 0 END) AS SoCVChuaBD,
            SUM(CASE WHEN CV.trangThai = N'Đang thực hiện' THEN 1 ELSE 0 END) AS SoCVDangLam,
            SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan AND CV.ngayHoanThanh IS NOT NULL THEN 1 ELSE 0 END) AS SoCVTreHan,
            SUM(CASE WHEN CV.ngayCapNhat IS NOT NULL AND CONVERT(date,CV.ngayCapNhat) = CONVERT(date, GETDATE()) THEN 1 ELSE 0 END) AS SoCVCoCapNhat
        FROM CongViec CV
        JOIN CongViec_Nhom CVN ON CV.maCongViec = CVN.maCongViec

        UNION ALL

        SELECT
            SUM(CASE WHEN CV.trangThai = N'Chưa bắt đầu' THEN 1 ELSE 0 END) AS SoCVChuaBD,
            SUM(CASE WHEN CV.trangThai = N'Đang thực hiện' THEN 1 ELSE 0 END) AS SoCVDangLam,
            SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan AND CV.ngayHoanThanh IS NOT NULL THEN 1 ELSE 0 END) AS SoCVTreHan,
            SUM(CASE WHEN CV.ngayCapNhat IS NOT NULL AND CONVERT(date,CV.ngayCapNhat) = CONVERT(date, GETDATE()) THEN 1 ELSE 0 END) AS SoCVCoCapNhat
        FROM CongViec CV
        JOIN CongViec_PhongBan CVPB ON CV.maCongViec = CVPB.maCongViec
    ) AS TongHop
END
--------------------------------------------------------------------------------------------------------
GO
------------------------- Đếm tổng số công việc của toàn nhân viên -------------------------------------
CREATE PROCEDURE [dbo].[CountJobsStateOfEmployees]
    @maNhanVien VARCHAR(10)
AS
BEGIN
    SELECT
        SUM(CASE WHEN CV.trangThai = N'Chưa bắt đầu' THEN 1 ELSE 0 END) AS TongSoCVChuaBatDau,
        SUM(CASE WHEN CV.trangThai = N'Đang thực hiện' THEN 1 ELSE 0 END) AS TongSoCVDangLam,
        SUM(CASE WHEN CV.ngayHoanThanh > CV.thoiHan AND CV.ngayHoanThanh IS NOT NULL THEN 1 ELSE 0 END) AS TongSoCVTreHan,
        SUM(CASE WHEN CV.ngayCapNhat IS NOT NULL THEN 1 ELSE 0 END) AS TongCVCoCapNhat
    FROM CongViec CV
    JOIN Congviec_Nhanvien CVNV ON CV.maCongViec = CVNV.maCongViec
    WHERE CVNV.maNhanVien = @maNhanVien
END
--------------------------------------------------------------------------------------------------------
GO
---Lấy thông báo quan trọng
CREATE PROCEDURE [dbo].[GetNoticesPriority]
    @maBoPhan VARCHAR(10) = NULL,
    @maNhom VARCHAR(10) = NULL,
    @maNhanVien VARCHAR(10) = NULL
AS
BEGIN
    SELECT N.*
    FROM Notice N
    INNER JOIN Notice_To NT ON N.stt = NT.stt
    WHERE N.priority = 1
        AND (
            NT.isFull = 1
            OR NT.maBoPhan = @maBoPhan
            OR NT.maNhom = @maNhom
            OR NT.maNhanVien = @maNhanVien
        )
    ORDER BY N.dateN DESC;
END;
GO

---Lấy tất cả thông báo
CREATE PROCEDURE [dbo].[GetAllNotices]
    @maBoPhan VARCHAR(10) = NULL,
    @maNhom VARCHAR(10) = NULL,
    @maNhanVien VARCHAR(10) = NULL
AS
BEGIN
    SELECT N.*
    FROM Notice N
    INNER JOIN Notice_To NT ON N.stt = NT.stt
    WHERE (
            NT.isFull = 1
            OR NT.maBoPhan = @maBoPhan
            OR NT.maNhom = @maNhom
            OR NT.maNhanVien = @maNhanVien
        )
    ORDER BY N.dateN DESC;
END;
GO

---Lấy tất cả thông báo đã gửi
CREATE PROCEDURE [dbo].[GetNoticesSend]
    @maBoPhan VARCHAR(10) = NULL,
    @maNhom VARCHAR(10) = NULL,
    @maNhanVien VARCHAR(10)
AS
BEGIN
    SELECT N.*
    FROM Notice N
	INNER JOIN (
	    SELECT DISTINCT stt
	    FROM Notice_To
	) NT ON N.stt = NT.stt
    WHERE N.author = @maNhanVien
	ORDER BY N.dateN DESC;
END;
GO
--- Cập nhật nhóm của nhân viên
CREATE PROCEDURE [dbo].[EditEmployeeGroup]
	@maNhanVien VARCHAR(10),
	@maNhom VARCHAR(10)
AS
BEGIN
	UPDATE NhanVien
	SET maNhom = @maNhom
	WHERE maNhanVien = @maNhanVien
END
GO
-- Thêm Quản lý
CREATE PROCEDURE [dbo].[AddManager]
	@maNhanVien VARCHAR(10),
	@maBoPhan VARCHAR(10)
AS
BEGIN
	INSERT INTO QuanLy
	VALUES (@maNhanVien, @maBoPhan)
END
GO
-- Procedure Thêm cư dân
CREATE PROCEDURE [dbo].[AddCuDan]
  @maCuDan VARCHAR(10),
  @hoTen NVARCHAR(100),
  @ngaySinh DATE,
  @maDinhDanh VARCHAR(20),
  @SDT VARCHAR(20),
  @email VARCHAR(100),
  @soTheTamTru VARCHAR(20),
  @ngayChuyenVao DATE,
  @ngayChuyenDi DATE,
  @soDienNuocHangThang FLOAT,
  @tinhTrangCongNo FLOAT,
  @duLieuDangKyThuNuoi NVARCHAR(100),
  @quocTich NVARCHAR(50),
  @maCuDanNguoiThan VARCHAR(10)
AS
BEGIN
  SET NOCOUNT ON;
  IF NOT EXISTS (SELECT 1 FROM CuDan WHERE maCuDan = @maCuDan)
  BEGIN
    INSERT INTO CuDan (
      maCuDan, hoTen, ngaySinh, maDinhDanh, SDT, email, soTheTamTru, ngayChuyenVao,
      ngayChuyenDi, soDienNuocHangThang, tinhTrangCongNo, duLieuDangKyThuNuoi,
      quocTich, maCuDanNguoiThan
    )
    VALUES (
      @maCuDan, @hoTen, @ngaySinh, @maDinhDanh, @SDT, @email,
      @soTheTamTru, @ngayChuyenVao, @ngayChuyenDi, @soDienNuocHangThang,
      @tinhTrangCongNo, @duLieuDangKyThuNuoi, @quocTich, @maCuDanNguoiThan
    );
  END
END

GO

-- Procedure Xóa Cư dân
CREATE PROCEDURE [dbo].[DeleteCuDan]
	  @maCuDan VARCHAR(10)
AS
BEGIN
	DELETE From CuDan
	WHERE maCuDan = @maCuDan
END

GO