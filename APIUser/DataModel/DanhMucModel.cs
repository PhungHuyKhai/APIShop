

namespace DataModel
{
    public class DanhMucModel
    {
        public int madanhmuc { get; set; }
        public string tendanhmuc { get; set; }
        public string noidung { get; set; }
    }
    public class SearchTDM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string tendanhmuc { get; set; }
        public string noidung { get; set; }
    }
}
