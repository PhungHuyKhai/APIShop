using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIShop.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        //Kiểm tra đăng nhập OK
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
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            bool register = _userBusiness.Register(model.tentk, model.matkhau);
            if (!register)
            {
                return Ok(new
                {
                    status = false,
                    message = "Đăng kí tài khoản không thành công !"
                });
            }

            return Ok(new
            {
                status = true,
                message = "Đăng kí tài khoản thành công !",
                username = model.tentk,
                password = model.matkhau
            });
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateModel model)
        {

            bool Update = _userBusiness.Update(model.ma, model.tentk, model.matkhau);
            if (Update)
            {
                return Ok(new
                {
                    status = true,
                    message = "Cập nhật thông tin thành công!"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    message = "Cập nhật thông tin thất bại!"
                });
            }
        }
        //Lấy danh sách tài khoản OK 
        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result = _userBusiness.GetAll();
            return Ok(new
            {
                result
            });
        }
        

    }
}


       