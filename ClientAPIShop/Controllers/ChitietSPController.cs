using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietSPController : Controller
    {
        private IChiTietSPBusiness _CTSPBusiness;
        public ChiTietSPController(IChiTietSPBusiness CTSPBusiness)
        {
            _CTSPBusiness = CTSPBusiness;
        }

        [Route("get-by-id/{ChiTietSanPham}")]
        [HttpGet]
        public ChitietSPModel GetDatabyID(string MaChiTietSanPham)
        {
            return _CTSPBusiness.GetDatabyID(MaChiTietSanPham);
        }
        [Route("get-all")]
        [HttpGet]
        public List<ChitietSPModel> GetAll()
        {
            return _CTSPBusiness.GetAll();
        }

        [Route("create-ChiTietSanPham")]
        [HttpPost]
        public ChitietSPModel CreateItem([FromBody] ChitietSPModel model)
        {
            _CTSPBusiness.Create(model);
            return model;
        }

        [Route("update-ChiTietSanPham")]
        [HttpPut]
        public ChitietSPModel UpdateItem([FromBody] ChitietSPModel model)
        {
            _CTSPBusiness.Update(model);
            return model;
        }



        [Route("Delete-ChiTietSanPham")]
        [HttpDelete]
        public IActionResult DeleteItem(string MaKhachHang)
        {
            _CTSPBusiness.Delete(MaKhachHang);
            return Ok(new { message = "Xóa thành công" });
        }



    }
}
