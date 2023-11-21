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
        SanPhamModel GetAll();
        List<SanPhamBanChayModel> Top3banchay();
        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string tensanpham);
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin);

    }
}
