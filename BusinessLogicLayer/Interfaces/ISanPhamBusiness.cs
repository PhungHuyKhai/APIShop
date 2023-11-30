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
        List <SanPhamModel> GetAll();
        bool Update(SanPhamModel model);
        bool Delete(string masanpham);
        bool Create(SanPhamModel spmodel);
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string tensanpham);
        List<SanPhamBanChayModel> Top3banchay();

    }
}
