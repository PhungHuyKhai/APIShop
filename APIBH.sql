
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

create table chitiettk
(	machitiettk int IDENTITY(1,1) not null primary key,
	mataikhoan int references taikhoan(mataikhoan)
	on delete cascade,
	hoten nvarchar(50) null,
	diachi nvarchar(max) null,
	sdt char(10) null
)

create table danhmuc (
	madanhmuc int identity (1,1) not null primary key,
	tendanhmuc nvarchar(max) null,
	noidung nvarchar(max) null
)

create table donvitinh (
	madonvitinh int identity (1,1) not null primary key,
	tendonvitinh nvarchar(50) null ,
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

create table hoadon (
	mahoadon int identity (1,1) not null primary key,
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
	gia decimal (18,0) null)

create table hoadonnhap (
	mahoadonnhap int identity(1,1) not null primary key,
	ngaytao datetime null,
	mataikhoan int references taikhoan(mataikhoan)
	on delete cascade ,
	tongtien decimal(18,0) null)

create table chitiethdnhap (
	machitietdnhap int identity(1,1) not null primary key,
	mahoadonnhap int references hoadonnhap(mahoadonnhap)
	on delete cascade,
	masanpham int references sanpham(masanpham)
	on delete cascade,
	soluong int null,
	madonvitinh int references donvitinh(madonvitinh)
	on delete cascade,
	gia decimal(18,0) null)

-----------------------------------------------------------------------
----------------------------------------------------------------
--------------------------------------------------------------
---------------------------------------------

--create proc sp_create_hoadon
--(@ngaytao datetime ,
-- @tenkh nvarchar(50),
-- @diachi nvarchar(max),
-- @sodt char(10) ,
-- @list_json_chitiethoadon nvarchar (max) )
-- as 
--	begin
--	declare @mahoadon int
--  insert into hoadon (ngaytao,tenKH,diachi,sodt)
--  values (@ngaytao,@tenkh,@diachi,@sodt);

--  set @mahoadon=(select SCOPE_IDENTITY());
--  if (@list_json_chitiethoadon is not null)
--  begin 
--	insert into chitiethd(mahoadon,masanpham,soluong,gia)
--	select @mahoadon,
--			JSON_VALUE(p.value, '$.masanpham'),
--			JSON_VALUE(p.value, '$.soluong'), 
--			JSON_VALUE(p.value, '$.gia') 
--			FROM OPENJSON(@list_json_chitiethoadon) as p;
--	end;
--	select '';
--end;


--create proc sp_login (@taikhoan nvarchar(50),@matkhau nvarchar(50))
--as
--	begin
--	select * from taikhoan
--	where tentk=@taikhoan and matkhau=@matkhau
--	end


	--San Pham
create proc sp_sanpham_get_by_id (@MaSanPham int)
as
	begin
		select sp.masanpham,tensanpham,madanhmuc,gia,trangthai,motasanpham
		from sanpham sp 
		where @MaSanPham=masanpham
	end


create proc sp_sanpham_get_all
	as
		begin
			select *
			from sanpham
		end
CREATE PROC sp_sanpham_create(
@MaSanPham int,
@MaDanhMuc int,
@TenSanPham nvarchar(max),
@Gia decimal,
@TrangThai bit,
@MoTaSanPham nvarchar(max)
)
AS
    BEGIN
       insert into SanPham(masanpham,madanhmuc,tensanpham,gia,trangthai,motasanpham)
	   values(@MaSanPham,@MaDanhMuc,@TenSanPham,@Gia,@TrangThai,@MoTaSanPham);
    END;
Exec sp_SanPham_create '1','111', N'Iphone 15ProMax' ,'40000000' , 'True' ,'Titan'

CREATE PROC sp_SanPham_update (
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
	    MaDanhMuc = @MaDanhMuc, 
		TenSanPham = @tenSanPham,
		Gia = @gia,
		trangthai = @Trangthai,
		motasanpham = @motasanpham
		where  MaSanPham = @MaSanPham
END
CREATE PROC sp_SanPham_delete (
	 @MaSanPham int
)
AS
BEGIN
	delete SanPham where MaSanPham = @MaSanPham
END

create procedure sp_login(@taikhoan char(50), @matkhau char(50))
as
	begin
		select * from taikhoan where tentk = @taikhoan AND matkhau = @matkhau
	end
create proc sp_getlist_login
as
begin
	SELECT * FROM taikhoan
end	








