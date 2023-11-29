using DaTaAcessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }
        public HoaDonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(HoaDonModel model)
        {
            return _res.Delete(model);
        }
        public List<ThongKeHoaDonModel> Search(int pageIndex, int pageSize, out long total, string tenkh, DateTime? fr_ngaytao)
        {
            return _res.Search(pageIndex, pageSize, out total, tenkh, fr_ngaytao);
        }

    }
}
