using DataModel;
using System.Net;
using System.Numerics;

namespace DataAccessLayer
{
    public class UserRepository : IUserRespository
    {
        private IDatabaseHelper _dbHelper;
        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public UserModel Login(string tentk, string matkhau)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",

                "@username", tentk,
                "@password", matkhau);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Register(string tentk, string matkhau)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_register",
                "@username", tentk,
                "@password", matkhau);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(int mataikhoan, int maloaitaikhoan, string tentk, string matkhau)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_taikhoan",
                "@mataikhoan", mataikhoan,
                "maloaitaikhoan", maloaitaikhoan,
                "@taikhoan", tentk,
                "@matkhau", matkhau);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public UserModel GetInfo(string tentk)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getinfo_accounts",
                "@username", tentk);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserModel> GetAll()
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getall_accounts");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteById(string mataikhoan)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_by_id",
                "@id", mataikhoan);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

