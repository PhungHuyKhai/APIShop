namespace DataModel
{
    public class KhachModel
    {
        public int makhachhang { get; set; }
        public string? tenkhachhang { get; set; }
        public string? gioitinh { get; set; }
        public string? sdt { get; set; }
        public string? diachi { get; set; }
        public string? email { get; set; }

    }
    public class SearchParameters
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
    }
}