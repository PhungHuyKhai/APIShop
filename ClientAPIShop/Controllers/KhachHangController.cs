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


        [Route("get-TopKhachMuaNhieu")]
        [HttpGet]
        public List<KhachHangMuaNhieuModel> TopKhachMuaHang()
        {
            return _khachBusiness.TopKhachMuaHang();
        }


        [Route("create-khach")]
        [HttpPost]
        public KhachModel CreateItem([FromBody] KhachModel model)
        {
            _khachBusiness.Create(model);
            return model;
        }



        [Route("update-khach")]
        [HttpPut]
        public KhachModel UpdateItem([FromBody] KhachModel model)
        {
            _khachBusiness.Update(model);
            return model;
        }



        [Route("Delete-Khach")]
        [HttpDelete]
        public IActionResult DeleteItem(string MaKhachHang)
        {
            _khachBusiness.Delete(MaKhachHang);
            return Ok(new { message = "Xóa thành công" });
        }



        [Route("Seach-Khach")]
        [HttpPost]
        public IActionResult Search([FromBody] SearchParameters parameters)
        {
            try
            {
                var page = parameters.Page;
                var pageSize = parameters.PageSize;
                string TenKhachHang = parameters.TenKhachHang ?? "";
                string DiaChi = parameters.DiaChi ?? "";

                long total = 0;
                var data = _khachBusiness.Search(page, pageSize, out total, TenKhachHang, DiaChi);

                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


    }
}
