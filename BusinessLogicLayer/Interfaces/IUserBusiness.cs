using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IUserBusiness
    {
        UserModel Login(string tentk, string matkhau);
        bool Register(string tentk, string matkhau);
        bool Update(int mataikhoan,int maloaitaikhoan, string tentk, string matkhau);
        UserModel GetInfo(string tentk);
        List<UserModel> GetAll();


        bool DeleteById(string mataikhoan);
        bool UpdateByAdmin(UpdateModelByAdmin model);

    }
}
