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

        bool Create (SanPhamModel model);

        bool Update (SanPhamModel model);

        bool Delete (SanPhamModel model);   
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string tensp);
        List<SanPhamBanChayModel> Top3banchay();
    }
}
