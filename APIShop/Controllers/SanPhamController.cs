﻿using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace API.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanphamBusiness;
        public SanPhamController(ISanPhamBusiness sanphamBusiness)
        {
            _sanphamBusiness = sanphamBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDataByID(int id)
        {
            return _sanphamBusiness.GetDataById(id);
        }
        [Route("get-all")]
        [HttpGet]
        public SanPhamModel GetAll()
        {
            return _sanphamBusiness.GetAll();
        }
        [Route("create-SanPham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Create(model);
            return model;
        }

        [Route("update-SanPham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Update(model);
            return model;
        }
        [Route("Delete-SanPham")]
        [HttpPost]
        public SanPhamModel DeleteItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Delete(model);
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
                var data = _sanphamBusiness.Search(page, pageSize, out total, tensp);
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