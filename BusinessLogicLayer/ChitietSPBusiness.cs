
using DataAcessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ChiTietSPBusiness : IChiTietSPBusiness
    {
        private IChiTietSPRepository _res;
        public ChiTietSPBusiness(IChiTietSPRepository res)
        {
            _res = res;
        }
        public ChitietSPModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ChitietSPModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(ChitietSPModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ChitietSPModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string machitietsp)
        {
            return _res.Delete(machitietsp);
        }
    }
}
