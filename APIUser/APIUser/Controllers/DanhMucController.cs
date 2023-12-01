using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
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
        [Route("get-all")]
        [HttpGet]
        public List<DanhMucModel> GetAll()
        {
            return _danhMucBusiness.GetAll();
        }

        [Route("Search-DanhMuc")]
        [HttpPost]
        public IActionResult Search([FromBody] SearchTDM parameters)
        {
            try
            {
                var pageIndex = parameters.PageIndex;
                var pageSize = parameters.PageSize;
                string tendanhmuc = parameters.tendanhmuc ?? "";
                string noidung = parameters.noidung ?? "";

                long total = 0;
                var data = _danhMucBusiness.Search(pageIndex, pageSize, out total, tendanhmuc, noidung);

                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = pageIndex,
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
