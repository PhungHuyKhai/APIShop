
namespace DataModel
{
    public class HoaDonModel
    {
        public int mahoadon { get; set; }
        public int makhachhang { get; set; }
        public DateTime ngaytao { get; set; }
        public string tenKH { get; set; }
        public string diachi { get; set; }
        public  string sodt { get; set; }
        public Decimal tongtien { get; set; }
        public List<ChiTietHoaDonModel> list_json_chitiethoadon { get; set; }
    }
    public class ChiTietHoaDonModel
    {
        public int machitiethd { get; set; }
        public int mahoadon { get; set; }
        public int masanpham { get; set; }
        public int soluong { get; set; }
        public decimal gia { get; set; }

    }
}
