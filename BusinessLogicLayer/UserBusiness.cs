using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRespository _res;
        private string secret;
        public UserBusiness(IUserRespository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        public UserModel Login(string tentk, string matkhau)
        {
            var user = _res.Login(tentk, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.tentk.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
        public bool Register(string tentk, string matkhau)
        {
            return _res.Register(tentk, matkhau);
        }

        public bool Update(int mataikhoan,int maloaitaikhoan, string tentk, string matkhau)
        {
            return _res.Update(mataikhoan, maloaitaikhoan, tentk, matkhau);
        }
        public UserModel GetInfo(string tentk)
        {
            return _res.GetInfo(tentk);
        }
        public List<UserModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool DeleteById(string mataikhoan)
        {
            return _res.DeleteById(mataikhoan);
        }

    }
}