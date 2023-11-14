using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SanPhamBanChayModel
    {
        public int MaSanPham { get; set; }
        public string? TenSanPham { get; set; }
        public float Gia { get; set; }
        public string? SoLuongMua { get; set; }

    }
    public class KhachHangMuaNhieuModel
    {
        public int MaKhachHang { get; set; }
        public string? TenKhachHang { get; set; }
        public string? Sđt { get; set; }
        public string? DiaChi { get; set; }

        public string? SoLuongSanPhamĐaMua { get; set; }
    }
    public class ThongKeHoaDonModel
    {
        public string? TenKhachHang { get; set; }
        public string? TenSanPham { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayDuyet { get; set; }
    }
}