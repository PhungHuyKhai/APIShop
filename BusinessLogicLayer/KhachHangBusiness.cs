using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class KhachBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachBusiness(IKhachHangRepository res)
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
        public List<KhachHangMuaNhieuModel> TopKhachMuaHang()
        {
            return _res.TopKhachMuaHang();
        }
        public bool Create(KhachModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MakhachHang)
        {
            return _res.Delete(MakhachHang);
        }
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach, dia_chi);
        }
    }
}