using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _taiKhoanBusiness;
        public TaiKhoanController(ITaiKhoanBusiness taiKhoanBusiness)
        {
            _taiKhoanBusiness = taiKhoanBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _taiKhoanBusiness.Login(model.tentk, model.matkhau);
            if (user == null)
                return Ok(new
                {
                    status = false,
                    message = "Tài khoản hoặc mật khẩu không chính xác !"
                });

            return Ok(new
            {
                status = true,
                username = user.tentk,
                token = user.token
            });
        }

        

        [Route("create-taikhoan")]
        [HttpPost]
        public TaiKhoanModel CreateItem(TaiKhoanModel model)
        {
            _taiKhoanBusiness.Create(model);
            return model;
        }
        [Route("get-by-id/{mataikhoan}")]
        [HttpGet]
        public TaiKhoanModel GetDatabyID(string mataikhoan)
        {
            return _taiKhoanBusiness.GetDatabyID(mataikhoan);
        }

        [Route("update-taikhoan")]
        [HttpPut]
        public TaiKhoanModel UpdateItem([FromBody] TaiKhoanModel model)
        {
            _taiKhoanBusiness.Update(model);
            return model;
        }



        [Route("Delete-taikhoan")]
        [HttpDelete]
        public IActionResult DeleteItem(string mataikhoan)
        {
            _taiKhoanBusiness.Delete(mataikhoan);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}
