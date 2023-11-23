using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAcessLayer
{
    public partial interface IUserRespository
    {

        UserModel Login(string tentk, string matkhau);
        bool Create(UserModel model);
        UserModel GetDatabyID(string id);
        bool Update(UserModel model);
        bool Delete(string mataikhoan);
    }
}

