using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoadonBusiness;
        public HoaDonController(IHoaDonBusiness hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }

        [Route("get-by-id/{MaHoaDon}")]
        [HttpGet]
        public HoaDonModel GetDatabyID(string MaHoaDon)
        {
            return _hoadonBusiness.GetDatabyID(MaHoaDon);
        }

        [Route("create-HoaDon")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            _hoadonBusiness.Create(model);
            return model;
        }

        [Route("update-HoaDon")]
        [HttpPost]
        public HoaDonModel UpdateItem([FromBody] HoaDonModel model)
        {
            _hoadonBusiness.Update(model);
            return model;
        }



        [Route("Delete-HoaDon")]
        [HttpPost]
        public HoaDonModel DeleteItem([FromBody] HoaDonModel model)
        {
            _hoadonBusiness.Delete(model);
            return model;
        }
    }
}
