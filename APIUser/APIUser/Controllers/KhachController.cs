using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private IKhachBusiness _khachBusiness;
        public KhachController(IKhachBusiness khachBusiness)
        {
            _khachBusiness = khachBusiness;
        }

        [Route("get-by-id/{MaKhachHang}")]
        [HttpGet]
        public KhachModel GetDatabyID(string MaKhachHang)
        {
            return _khachBusiness.GetDatabyID(MaKhachHang);
        }

        [Route("get-all")]
        [HttpGet]
        public List<KhachModel> GetAll()
        {
            return _khachBusiness.GetAll();

        }
    }
}
