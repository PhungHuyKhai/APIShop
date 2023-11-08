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
}