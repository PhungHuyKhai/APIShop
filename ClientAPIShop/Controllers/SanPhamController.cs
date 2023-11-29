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
        [HttpPost]
        public SanPhamModel DeleteItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Delete(model);
            return model;
        }



        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tensp = "";
                if (formData.Keys.Contains("tensp") && !string.IsNullOrEmpty(Convert.ToString(formData["tensp"]))) { tensp = Convert.ToString(formData["tensp"]); }

                long total = 0;
                var data = _sanPhamBusiness.Search(page, pageSize, out total, tensp);
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
        [Route("get-Top3banchay")]
        [HttpGet]
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }
    }
}