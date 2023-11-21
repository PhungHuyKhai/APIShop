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
    public class TaiKhoanBusiness : ITaiKhoanBusiness
    {
        private ITaiKhoanRepository _res;
        private string secret;
        public TaiKhoanBusiness(ITaiKhoanRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public TaiKhoanModel Login(string tentk, string matkhau)
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
                    new Claim(ClaimTypes.Name, user.tentk.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
        public bool Create(TaiKhoanModel model)
        {
            return _res.Create(model);
        }
        public TaiKhoanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Update(TaiKhoanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string mataikhoan)
        {
            return _res.Delete(mataikhoan);
        }
        
    }

}