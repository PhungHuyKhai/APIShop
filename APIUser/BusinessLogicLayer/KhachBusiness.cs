using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class KhachBusiness : IKhachBusiness
    {
        private IKhachRepository _res;
        public KhachBusiness(IKhachRepository res)
        {
            _res = res;
        }
        public KhachModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<KhachModel> GetAll()
        {
            return _res.GetAll();
        }
    }
}