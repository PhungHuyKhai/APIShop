using BusinessLogicLayer;
using DaTaAcessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class  SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }

        public SanPhamModel GetDataById(int id)
        {
            return _res.GetDataById(id);
        }
        public List <SanPhamModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(SanPhamModel spmodel)
        {
            return _res.Create(spmodel);
        }

        public bool Delete(string masanpham)
        {
            return _res.Delete(masanpham);
        }

        public bool Update(SanPhamModel spmodel)
        {
            return _res.Update(spmodel);
        }

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string tensanpham)
        {
            return _res.Search(pageIndex, pageSize, out total, tensanpham);
        }
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _res.Top3banchay();
        }
    }
}
