using DataModel;

namespace DataAccessLayer
{
    public class KhachRepository : IKhachRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public KhachModel GetDatabyID(string MaKhachHang)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_get_by_id",
                     "@MaKhachHang", MaKhachHang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KhachModel GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_Khach_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<KhachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
