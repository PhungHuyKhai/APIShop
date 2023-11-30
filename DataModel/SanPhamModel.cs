
namespace DataModel
{
    public class SanPhamModel
    {
        public int masanpham { get; set; }
        public string tensanpham { get; set; }
        public int madanhmuc { get; set; }
        public decimal gia { get; set; }
        public bool trangthai { get; set; }
        public string motasanpham { get; set; }
        public int soluong { get; set; }

    }
    public class SearchProductParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string tensanpham { get; set; }
        
    }
}
