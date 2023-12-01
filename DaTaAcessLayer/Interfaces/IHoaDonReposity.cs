using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaTaAcessLayer
{
    public partial interface IHoaDonRepository
    {
        HoaDonModel GetDatabyID(string id);
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        bool Delete(HoaDonModel model);
        public List<ThongKeHoaDonModel> Search(int pageIndex, int pageSize, out long total, string ten_khach_hang, DateTime fr_ngaytao);
    }
}
