using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IDanhMucRepository
    {
        DanhMucModel GetDatabyID(string id);
        List<DanhMucModel> GetAll();
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string ten_danhmuc, string noi_dung);
    }
}
