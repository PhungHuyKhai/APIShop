create table loaitaikhoan (
	maloaitk int IDENTITY(1,1) not null primary key,
	tenloai nvarchar(50) null,
	mota nvarchar(max) null
)

create table taikhoan
(	mataikhoan int IDENTITY(1,1) not null primary key,
	maloaitk int references loaitaikhoan(maloaitk)
	on delete cascade,
	tentk char(50) null,
	matkhau char(50) null,
)
create table danhmuc (
	madanhmuc int identity (1,1) not null primary key,
	tendanhmuc nvarchar(max) null,
	noidung nvarchar(max) null
)
create table sanpham (
	masanpham int identity(1,1) not null  primary key,
	tensanpham nvarchar(max) null,
	madanhmuc int references danhmuc(madanhmuc) 
	on delete cascade,
	gia decimal (18,0) null,
	trangthai bit null,
	motasanpham nvarchar(max)
)
create table chitetsanpham(
    machitietsp int identity (1,1) not null primary key,
	masanpham int references sanpham(masanpham) 
	on delete cascade,
	soluong int null,
	mota nvarchar(max)
)
create table khachhang (
	makhachhang int identity (1,1) not null primary key,
	tenkhachhang nvarchar(50) null,
	gioitinh NVARCHAR(10) CHECK (gioitinh IN ('Nam', 'N?')) null,
	sdt nvarchar(10) null,
	diachi nvarchar(max) null,
	email nvarchar(max) null
)
Create table hoadon (
	mahoadon int identity (1,1) not null primary key,
	makhachhang int references khachhang(makhachhang)
	on delete cascade,
	ngaytao datetime null,
	tenKH nvarchar(50) null,
	diachi nvarchar(max) null,
	sodt char(10) null,
	tongtien decimal(18,0) null
)

create table chitiethd (
	machitiethd int identity(1,1) not null primary key,
	mahoadon int references hoadon(mahoadon)
	on delete cascade,
	masanpham int references sanpham(masanpham)
	on delete cascade, 
	soluong int null,
	gia decimal (18,0) null
)
create table hoadonnhap (
	mahoadonnhap int identity(1,1) not null primary key,
	ngaytao datetime null,
	mataikhoan int references taikhoan(mataikhoan)
	on delete cascade ,
	tongtien decimal(18,0) null
)

create table chitiethdnhap (
	machitietdnhap int identity(1,1) not null primary key,
	mahoadonnhap int references hoadonnhap(mahoadonnhap)
	on delete cascade,
	masanpham int references sanpham(masanpham)
	on delete cascade,
	soluong int null,
	gia decimal(18,0) null
)
----taikhoan----
Create proc [dbo].[sp_login](@username varchar(50), @password varchar(50))
as
begin
	select * from taikhoan where tentk = @username AND matkhau = @password
end

Create proc [dbo].[sp_register](@username varchar(50), @password varchar(50))
as
begin
	insert into taikhoan(maloaitk,tentk,matkhau) values (2,@username,@password)
end

---sanpham---
Create proc [dbo].[sp_sanpham_get_by_id] (@MaSanPham int)
as
	begin
		select sp.masanpham,tensanpham,madanhmuc,gia,trangthai,motasanpham
		from sanpham sp 
		where @MaSanPham=masanpham
	end
Create proc [dbo].[sp_sanpham_get_all]
	as
		begin
			select *
			from sanpham
		end
Create PROC [dbo].[sp_sanpham_create](
@TenSanPham nvarchar(max),
@MaDanhMuc int,
@Gia decimal,
@TrangThai bit,
@MoTaSanPham nvarchar(max)
)
AS
    BEGIN
       insert into SanPham(tensanpham,madanhmuc,gia,trangthai,motasanpham)
	   values(@TenSanPham,@MaDanhMuc,@Gia,@TrangThai,@MoTaSanPham);
    END;
Create PROC [dbo].[sp_SanPham_update] (
	@MaSanPham int,
	@TenSanPham nvarchar(150),
	@MaDanhMuc int,
	@Gia float,
	@Trangthai bit,
	@motasanpham nvarchar(max)
)
AS
BEGIN
	update SanPham
	set 
	    TenSanPham = @tenSanPham,
	    MaDanhMuc = @MaDanhMuc, 
		Gia = @gia,
		trangthai = @Trangthai,
		motasanpham = @motasanpham
		where  MaSanPham = @MaSanPham
END;
Create PROC [dbo].[sp_SanPham_delete] (
	 @MaSanPham int
)
AS
BEGIN
	delete SanPham where MaSanPham = @MaSanPham
END
---danhmuc---
Create PROC [dbo].[sp_DanhMuc_create](
@TenDanhMuc nvarchar(max),
@NoiDung nvarchar(max)
)
AS
    BEGIN
       insert into DanhMuc(tendanhmuc,noidung)
	   values(@TenDanhMuc,@NoiDung);
    END;
Create PROC [dbo].[sp_DanhMuc_delete] (
	 @MaDanhMuc int
)
AS
BEGIN
	delete SanPham where madanhmuc = @MaDanhMuc
END;
Create proc [dbo].[sp_DanhMuc_get_by_id] (@MaDanhMuc int)
as
	begin
		select dm.madanhmuc,tendanhmuc,noidung
		from danhmuc dm 
		where @MaDanhMuc=madanhmuc
	end
Create PROC [dbo].[sp_DanhMuc_update] (
	@MaDanhMuc int,
	@TenDanhMuc nvarchar(max),
    @NoiDung nvarchar(max)
)
AS
BEGIN
	update DanhMuc
	set 
	    tendanhmuc = @TenDanhMuc,
	    noidung = @NoiDung
		where  madanhmuc = @MaDanhMuc
END

--hoadon---

Create proc [dbo].[sp_HoaDon_get_by_id] (@MaHoaDon int)
as
	begin
		select sp.mahoadon,ngaytao,tenKH,diachi,sodt,tongtien
		from hoadon sp 
		where @MaHoaDon=mahoadon
	end


Create PROC [dbo].[sp_HoaDon_update] (
	@MaDanhMuc int,
	@TenDanhMuc nvarchar(max),
    @NoiDung nvarchar(max)
)
AS
BEGIN
	update DanhMuc
	set 
	    tendanhmuc = @TenDanhMuc,
	    noidung = @NoiDung
		where  madanhmuc = @MaDanhMuc
END

