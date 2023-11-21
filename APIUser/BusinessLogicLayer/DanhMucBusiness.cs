
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessLogicLayer
{
    public class DanhMucBusiness : IDanhMucBusiness
    {
        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        public DanhMucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public DanhMucModel GetAll()
        {
            return _res.GetAll();
        }
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string tendanhmuc, string noidung)
        {
            return _res.Search(pageIndex, pageSize, out total, tendanhmuc, noidung);
        }


    }
}
