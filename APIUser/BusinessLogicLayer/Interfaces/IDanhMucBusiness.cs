using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IDanhMucBusiness
    {
        DanhMucModel GetDatabyID(string id);
        List<DanhMucModel> GetAll();
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string tendanhmuc, string noidung);
    }
}
