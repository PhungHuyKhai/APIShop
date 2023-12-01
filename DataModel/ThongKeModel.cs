using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SanPhamBanChayModel
    {
        public int masanpham { get; set; }
        public string? tensanpham { get; set; }
        public float gia { get; set; }
        public string? soluong { get; set; }

    }
    public class KhachHangMuaNhieuModel
    {
        public int makhachhang { get; set; }
        public string? tenkhachhang { get; set; }
        public string? sdt { get; set; }
        public string? diachi { get; set; }

        public string? soluongsanphamdamua { get; set; }
    }
    public class ThongKeHoaDonModel
    {
        public string? tenKH { get; set; }
        
        public DateTime ngaytao { get; set; }
    
    }
}