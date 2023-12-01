using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Client.APIShop.Controllers
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
        [Route("Seach-HoaDon")]
        [HttpPost]
        public IActionResult Search(int pageIndex, int pageSize, string tenkh, DateTime fr_ngaytao)
        {
            try
            {
                long total;
                var result = _hoadonBusiness.Search(pageIndex, pageSize, out total, tenkh, fr_ngaytao);

                // Trả về 200 OK với dữ liệu và số liệu
                return Ok(new { Total = total, Data = result });
            }
            catch (Exception ex)
            {
                // Trả về lỗi 500 Internal Server Error với thông điệp lỗi
                return StatusCode(500, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message
                });
            }
        }
    }
}
