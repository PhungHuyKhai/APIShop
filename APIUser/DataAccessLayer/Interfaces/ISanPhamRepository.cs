using System;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaTaAcessLayer
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetDataById(int id);
        List<SanPhamModel> GetAll();
        List<SanPhamModel> Top3banchay();
        public List<SanPhamModel> SearchTheoTen(int pageIndex, int pageSize, out long total, string tensanpham);
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, float giamax, float giamin);
    }
}
