using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APIShop.Controllers
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
        public SanPhamModel GetAll()
        {
            return _sanPhamBusiness.GetAll();
        }

        [Route("get-Top3banchay")]
        [HttpGet]
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }
        [Route("Search-TenSP")]
        [HttpPost]
        public IActionResult SearchTheoTen([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tensanpham = "";
                if (formData.Keys.Contains("tensanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["tensanpham"]))) { tensanpham = Convert.ToString(formData["tensanpham"]); }
                var data = _sanPhamBusiness.SearchTheoTen(page, pageSize, tensanpham);
                return Ok(
                    new
                    {
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
        [Route("Search-Gia")]
        [HttpPost]
        public IActionResult SearchTheoGia([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var max = int.Parse(formData["giamax"].ToString());
                var min = int.Parse(formData["giamin"].ToString());

                long total = 0;
                var data = _sanPhamBusiness.SearchTheoGia(page, pageSize, out total, max, min);
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
