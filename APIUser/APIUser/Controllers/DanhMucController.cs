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
        public DanhMucModel GetAll()
        {
            return _danhMucBusiness.GetAll();
        }

        [Route("Search-DanhMuc")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tendanhmuc = "";
                if (formData.Keys.Contains("ten_danhmuc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_danhmuc"]))) { tendanhmuc = Convert.ToString(formData["ten_danhmuc"]); }
                string noidung = "";
                if (formData.Keys.Contains("noi_dung") && !string.IsNullOrEmpty(Convert.ToString(formData["noi_dung"]))) { noidung = Convert.ToString(formData["noi_dung"]); }
                long total = 0;
                var data = _danhMucBusiness.Search(page, pageSize, out total, tendanhmuc, noidung);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
