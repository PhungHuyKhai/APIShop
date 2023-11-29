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

        public bool Delete(SanPhamModel spmodel)
        {
            return _res.Delete(spmodel);
        }

        public bool Update(SanPhamModel spmodel)
        {
            return _res.Update(spmodel);
        }

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string tensp)
        {
            return _res.Search(pageIndex, pageSize, out total, tensp);
        }
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _res.Top3banchay();
        }
    }
}
