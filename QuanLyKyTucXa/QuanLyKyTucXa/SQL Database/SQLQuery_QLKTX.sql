﻿CREATE DATABASE QLKTX
GO


USE QLKTX

CREATE TABLE TAIKHOAN
(
	ID INT UNIQUE NOT NULL,
	USERNAME VARCHAR(20),
	PASS VARCHAR(20),

	PRIMARY KEY(ID,USERNAME)
)

CREATE TABLE HOPDONG
(
	MAHOPDONG VARCHAR(9) NOT NULL,
	HANHOPDONG NVARCHAR(20),

	PRIMARY KEY(MAHOPDONG)
)

CREATE TABLE PHANLOAI
(
	MAPHANLOAI VARCHAR(9) NOT NULL,
	TENPHANLOAI NVARCHAR(50),

	PRIMARY KEY(MAPHANLOAI)
)

CREATE TABLE KHU
(
	MAKHU		VARCHAR(9) NOT NULL,
	TENKHU		NVARCHAR(40),
	SOPHONG		INT,

	PRIMARY KEY(MAKHU)
)

CREATE TABLE PHONG
(
	MAPHONG		VARCHAR(9) NOT NULL,
	MAKHU		VARCHAR(9),
	SOLUONGTOIDA INT,
	SOLUONG		INT,

	PRIMARY KEY(MAPHONG)
)


CREATE TABLE THONGKE
(
	MAHOADON	VARCHAR(9) NOT NULL,
	MAPHONG		VARCHAR(9) NOT NULL,
	SOLUONGDIEN INT,
	SOLUONGNUOC INT,
	TIENDIEN INT,
	TIENNUOC INT,
	TIENPHONG INT,
	THANHTIEN INT,
	TRANGTHAI NVARCHAR(50),

	PRIMARY KEY(MAHOADON),
)

CREATE TABLE THONGTIN
(
	MASO		VARCHAR(9) NOT NULL,
	HOTEN		NVARCHAR(50) NOT NULL,
	NAMSINH		INT,
	GIOITINH	NVARCHAR(3) NOT	NULL,
	CMND		VARCHAR(10) NOT NULL,
	NGUYENQUAN	NVARCHAR(100) NOT NULL,
	DIENTHOAI	VARCHAR(13) NOT NULL,
	MAKHU		VARCHAR(9) NOT NULL,
	MAPHONG		VARCHAR(9) NOT NULL,
	MAHOPDONG	VARCHAR(9) NOT NULL,
	MAPHANLOAI		VARCHAR(9) NOT NULL,	

	PRIMARY KEY(MASO,CMND)
)

--THÊM FOREIGN KEY CHO CÁC TABLE

ALTER TABLE dbo.PHONG ADD CONSTRAINT FK_PHONG FOREIGN KEY(MAKHU) REFERENCES dbo.KHU(MAKHU)

ALTER TABLE dbo.THONGKE ADD CONSTRAINT FK_THONGKE FOREIGN KEY(MAPHONG) REFERENCES dbo.PHONG(MAPHONG)

ALTER TABLE dbo.THONGTIN ADD CONSTRAINT FK_THONGTIN3 FOREIGN KEY(MAPHANLOAI) REFERENCES dbo.PHANLOAI(MAPHANLOAI)
ALTER TABLE dbo.THONGTIN ADD CONSTRAINT FK_THONGTIN FOREIGN KEY(MAKHU) REFERENCES dbo.KHU(MAKHU)
ALTER TABLE dbo.THONGTIN ADD CONSTRAINT FK_THONGTIN1 FOREIGN KEY(MAPHONG) REFERENCES dbo.PHONG(MAPHONG)
ALTER TABLE dbo.THONGTIN ADD CONSTRAINT FK_THONGTIN2 FOREIGN KEY(MAHOPDONG) REFERENCES dbo.HOPDONG(MAHOPDONG)

--USE	master
--DROP	DATABASE QLKTX


--THÊM DỮ LIỆU VÀO PHÂN LOẠI
INSERT dbo.PHANLOAI
        ( MAPHANLOAI, TENPHANLOAI )
VALUES  ( 'NV', -- MAPHANLOAI - varchar(9)
          N'NHÂN VIÊN'  -- TENPHANLOAI - nvarchar(50)
          )
INSERT dbo.PHANLOAI
        ( MAPHANLOAI, TENPHANLOAI )
VALUES  ( 'SV', -- MAPHANLOAI - varchar(9)
          N'SINH VIÊN'  -- TENPHANLOAI - nvarchar(50)
          )
INSERT dbo.PHANLOAI
        ( MAPHANLOAI, TENPHANLOAI )
VALUES  ( 'GV', -- MAPHANLOAI - varchar(9)
          N'GIÁO VIÊN'  -- TENPHANLOAI - nvarchar(50)
          )


--THÊM DỮ LIỆU VÀO HỢP ĐỒNG
INSERT dbo.HOPDONG
        ( MAHOPDONG, HANHOPDONG )
VALUES  ( 'HD1', -- MAHOPDONG - varchar(9)
          N'1 NĂM'  -- HANHOPDONG - nvarchar(20)
          )
INSERT dbo.HOPDONG
        ( MAHOPDONG, HANHOPDONG )
VALUES  ( 'HD2', -- MAHOPDONG - varchar(9)
          N'2 NĂM'  -- HANHOPDONG - nvarchar(20)
          )
INSERT dbo.HOPDONG
        ( MAHOPDONG, HANHOPDONG )
VALUES  ( 'HD3', -- MAHOPDONG - varchar(9)
          N'3 THÁNG'  -- HANHOPDONG - nvarchar(20)
          )
INSERT dbo.HOPDONG
        ( MAHOPDONG, HANHOPDONG )
VALUES  ( 'HD4', -- MAHOPDONG - varchar(9)
          N'6 THÁNG'  -- HANHOPDONG - nvarchar(20)
          )
INSERT dbo.HOPDONG
        ( MAHOPDONG, HANHOPDONG )
VALUES  ( 'HD5', -- MAHOPDONG - varchar(9)
          N'9 THÁNG'  -- HANHOPDONG - nvarchar(20)
          )

INSERT dbo.KHU
        ( MAKHU, TENKHU, SOPHONG )
VALUES  ( 'KHS', -- MAKHU - varchar(9)
          N'KHU HỌC SINH', -- TENKHU - nvarchar(40)
          10  -- SOPHONG - int
          )
INSERT dbo.PHONG
        ( MAPHONG ,
          MAKHU ,
          SOLUONGTOIDA ,
          SOLUONG
        )
VALUES  ( '1' , -- MAPHONG - int
          'KHS' , -- MAKHU - varchar(9)
          6 , -- SOLUONGTOIDA - int
          0  -- SOLUONG - int
        )
INSERT dbo.THONGTIN
        ( MASO ,
          HOTEN ,
          NAMSINH ,
          GIOITINH ,
          CMND ,
          NGUYENQUAN ,
          DIENTHOAI ,
          MAKHU ,
          MAPHONG ,
          MAHOPDONG ,
          MAPHANLOAI
        )
VALUES  ( 'MA1' , -- MASO - varchar(9)
          N'NGUYỄN VĂN A' , -- HOTEN - nvarchar(50)
          2000 , -- NAMSINH - int
          N'NAM' , -- GIOITINH - nvarchar(3)
          '9876' , -- CMND - varchar(10)
          N'AG' , -- NGUYENQUAN - nvarchar(100)
          '09876' , -- DIENTHOAI - varchar(13)
          'KHS' , -- MAKHU - varchar(9)
          '1' , -- MAPHONG - int
          'HD4' , -- MAHOPDONG - varchar(9)
          'NV'  -- MAPHANLOAI - varchar(9)
        )

SELECT t.* , pl.TENPHANLOAI FROM THONGTIN AS t , PHANLOAI AS pl WHERE t.MAPHANLOAI = pl.MAPHANLOAI

GO
CREATE PROC USP_UPDATETHONGTIN
@MASO VARCHAR(9) , @HOTEN NVARCHAR(50) , @NAMSINH INT, @GIOITINH	NVARCHAR(3) , @CMND	VARCHAR(10) , @NGUYENQUAN	NVARCHAR(100) , @DIENTHOAI	VARCHAR(13) , @MAHOPDONG	VARCHAR(9) , @MAPHANLOAI	VARCHAR(9) , @MASOBACKUP VARCHAR(9)
AS
BEGIN	
	UPDATE dbo.THONGTIN SET MASO = @MASO , HOTEN = @HOTEN , NAMSINH = @NAMSINH , GIOITINH = @GIOITINH , CMND = @CMND , NGUYENQUAN = @NGUYENQUAN , DIENTHOAI = @DIENTHOAI , MAHOPDONG = @MAHOPDONG , MAPHANLOAI = @MAPHANLOAI WHERE MASO = @MASOBACKUP
END
GO


CREATE PROC USP_ADDTHONGTIN_AND_UPDATEPHONG
@MASO VARCHAR(9) , @HOTEN NVARCHAR(50) , @NAMSINH	INT, @GIOITINH	NVARCHAR(3) , @CMND	VARCHAR(10) , @NGUYENQUAN	NVARCHAR(100) , @DIENTHOAI	VARCHAR(13) , @MAKHU	VARCHAR(9) , @MAPHONG	VARCHAR(9) , @MAHOPDONG	VARCHAR(9) , @MAPHANLOAI	VARCHAR(9)
AS
BEGIN
	INSERT THONGTIN VALUES ( @MASO , @HOTEN , @NAMSINH , @GIOITINH , @CMND , @NGUYENQUAN , @DIENTHOAI , @MAKHU , @MAPHONG , @MAHOPDONG , @MAPHANLOAI )
	UPDATE dbo.PHONG SET SOLUONG = SOLUONG +1 WHERE MAPHONG = @MAPHONG
END
GO

CREATE PROC USP_DELETETHONGTIN_AND_UPDATEPHONG
@MASO VARCHAR(9), @MAPHONG VARCHAR(9)
AS
BEGIN
	DELETE THONGTIN WHERE MASO = @MASO
	UPDATE dbo.PHONG SET SOLUONG = SOLUONG - 1 WHERE MAPHONG = @MAPHONG
END

GO
CREATE PROC USP_CHUYENPHONG
@MAPHONGMOI VARCHAR(9), @MAPHONGCU VARCHAR(9), @MASO VARCHAR(9) 
AS
BEGIN
	UPDATE dbo.THONGTIN SET MAPHONG = @MAPHONGMOI WHERE MASO = @MASO
	UPDATE dbo.PHONG SET SOLUONG=SOLUONG+1 WHERE MAPHONG = @MAPHONGMOI
	UPDATE dbo.PHONG SET SOLUONG = SOLUONG -1 WHERE MAPHONG = @MAPHONGCU
END


--XEM DỮ LIÊU TRONG TABLE
SELECT * FROM dbo.HOPDONG
SELECT * FROM dbo.KHU
SELECT * FROM dbo.PHONG
SELECT * FROM dbo.THONGKE
SELECT * FROM dbo.THONGTIN
SELECT * FROM dbo.PHANLOAI
SELECT * FROM dbo.TAIKHOAN
