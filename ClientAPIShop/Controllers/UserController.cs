using BusinessLogicLayer;
using DataAcessLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRespository _userBusiness;
        public UserController(IUserRespository UserBusiness)
        {
            _userBusiness = UserBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.tentk, model.matkhau);
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
        public UserModel CreateItem(UserModel model)
        {
            _userBusiness.Create(model);
            return model;
        }
        [Route("get-by-id/{mataikhoan}")]
        [HttpGet]
        public UserModel GetDatabyID(string mataikhoan)
        {
            return _userBusiness.GetDatabyID(mataikhoan);
        }

        [Route("update-taikhoan")]
        [HttpPut]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _userBusiness.Update(model);
            return model;
        }



        [Route("Delete-taikhoan")]
        [HttpDelete]
        public IActionResult DeleteItem(string mataikhoan)
        {
            _userBusiness.Delete(mataikhoan);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}
