using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : Controller
    {
        private IDanhMucBusiness _danhMucBusiness;
        public DanhMucController(IDanhMucBusiness danhMucBusiness)
        {
            _danhMucBusiness = danhMucBusiness;
        }

        [Route("get-by-id/{MaDanhMuc}")]
        [HttpGet]
        public DanhMucModel GetDatabyID(string MaDanhMuc)
        {
            return _danhMucBusiness.GetDatabyID(MaDanhMuc);
        }

        [Route("create-DanhMuc")]
        [HttpPost]
        public IActionResult Create([FromBody] DanhMucModel model)
        {
            var result = _danhMucBusiness.Create(model);
            if (result)
            {
                return Ok(new
                {
                    status = true,
                    message = "them thành công",
                    data = model
                });   
                    
            }
            else
            {
                return BadRequest(new
                {
                    status =false,
                    messahe = "thêm thất bại",
                    data = model

                });
            }
                
                
        }

        [Route("update-DanhMuc")]
        [HttpPost]
        public DanhMucModel UpdateItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Update(model);
            return model;
        }



        [Route("Delete-DanhMuc")]
        [HttpDelete]
        public IActionResult DeleteItem(string madanhmuc)
        {
            _danhMucBusiness.Delete(madanhmuc);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}

