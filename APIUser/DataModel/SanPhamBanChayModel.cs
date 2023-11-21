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

    public class SeachTheoTenModel
    {
        public int masanpham { get; set; }
        public string? tensanpham { get; set; }
        public float gia { get; set; }
        public int soluong { get; set; }

    }
}
