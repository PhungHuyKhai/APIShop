using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Client.APIShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDataByID(int id)
        {
            return _sanPhamBusiness.GetDataById(id);
        }
        [Route("get-all")]
        [HttpGet]
        public List <SanPhamModel> GetAll()
        {
            return _sanPhamBusiness.GetAll();
        }
        [Route("create-SanPham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }
        [Route("update-SanPham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }

        [Route("Delete-SanPham")]
        [HttpDelete]
        public IActionResult DeleteItem(string masanpham)
        {
            _sanPhamBusiness.Delete(masanpham);
            return Ok(new { message = "Xóa thành công" });
        }



        [Route("search")]
        [HttpPost]
        
        public IActionResult Search([FromBody] SearchTSP parameters)
        {
            try
            {
                var pageIndex = parameters.PageIndex;
                var pageSize = parameters.PageSize;
                string tensanPham = parameters.tensanpham ?? "";
               

                long total = 0;
                var data = _sanPhamBusiness.Search(pageIndex, pageSize, out total, tensanPham);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = pageIndex,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    
        [Route("get-Top3SPbanchay")]
        [HttpGet]
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }
    }
}