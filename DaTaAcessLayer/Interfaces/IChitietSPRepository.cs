using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IChiTietSPRepository
    {
        ChitietSPModel GetDatabyID(string id);
        List<ChitietSPModel> GetAll();
        bool Create(ChitietSPModel model);
        bool Update(ChitietSPModel model);
        bool Delete(string MaChiTietSanPham);
    }
}
