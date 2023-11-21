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
        SanPhamModel GetAll();
        List<SanPhamBanChayModel> Top3banchay();
        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string tensanpham);
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin);
    }
}
