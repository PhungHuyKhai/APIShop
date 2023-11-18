using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AdminAPIShop.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private IKhachHangBusiness _khachBusiness;
        public KhachController(IKhachHangBusiness khachBusiness)
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
