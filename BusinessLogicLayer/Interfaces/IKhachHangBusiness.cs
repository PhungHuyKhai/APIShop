using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IKhachHangBusiness
    {
        KhachModel GetDatabyID(string id);
        List<KhachModel> GetAll();
        List<KhachHangMuaNhieuModel> TopKhachMuaHang();
        bool Create(KhachModel model);
        bool Update(KhachModel model);
        bool Delete(string MaKhachHang);
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string DiaChi);
    }
}
