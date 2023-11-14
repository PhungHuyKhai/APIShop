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
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKhachHang = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { TenKhachHang = Convert.ToString(formData["ten_khach"]); }
                string DiaChi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { DiaChi = Convert.ToString(formData["dia_chi"]); }
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
                throw new Exception(ex.Message);
            }
        }
    }
}
