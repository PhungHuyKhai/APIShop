using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetDataById(int id);
        List<SanPhamModel> GetAll();
        List<SanPhamModel> Top3banchay();
        public List<SanPhamModel> SearchTheoTen(int pageIndex, int pageSize, out long total, string tensanpham);
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, float giamax, float giamin);

    }
}
