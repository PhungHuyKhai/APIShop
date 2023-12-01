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
    public class SanPhamBusiness : ISanPhamBusiness
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
        public List<SanPhamModel> GetAll()
        {
            return _res.GetAll();
        }
        public List<SanPhamModel> Top3banchay()
        {
            return _res.Top3banchay();
        }
        public List<SanPhamModel> SearchTheoTen(int pageIndex, int pageSize,out long total, string tensanpham)
        {
            return _res.SearchTheoTen(pageIndex, pageSize, out total,tensanpham);
        }
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, float giamax, float giamin)
        {
            return _res.SearchTheoGia(pageIndex, pageSize, out total, giamax, giamin);

        }
    }
}
