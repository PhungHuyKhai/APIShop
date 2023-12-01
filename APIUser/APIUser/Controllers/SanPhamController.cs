using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.User.Controllers
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
        public List<SanPhamModel> GetAll()
        {
            return _sanPhamBusiness.GetAll();
        }

        [Route("get-Top3banchay")]
        [HttpGet]
        public List<SanPhamModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }
        [Route("Search-TenSP")]
        [HttpPost]
        public IActionResult Search([FromBody] SearchTSP parameters)
        {
            try
            {
                var pageIndex = parameters.PageIndex;
                var pageSize = parameters.PageSize;
                string tensanPham = parameters.tensanpham ?? "";


                long total = 0;
                var data = _sanPhamBusiness.SearchTheoTen(pageIndex, pageSize, out total, tensanPham);

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
        //public IActionResult Search([FromBody] SearchMoney parameters)
        //{
        //    try
        //    {
        //        var pageIndex = parameters.PageIndex;
        //        var pageSize = parameters.PageSize;
        //        float giamax = parameters.giamax ?? "";
        //        float giamin = parameters.giamin ?? "";


        //        long total = 0;
        //        var data = _sanPhamBusiness.SearchTheoGia(pageIndex, pageSize, out total, giamax, giamin);

        //        return Ok(new
        //        {
        //            TotalItems = total,
        //            Data = data,
        //            Page = pageIndex,
        //            PageSize = pageSize
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
    }
}











