using DataModel;

namespace DataAccessLayer
{
    public class KhachRepository : IKhachHangRepository
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

        public List<KhachModel> GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_Khach_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<KhachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(KhachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                   out msgError,
                   "sp_khach_create",
               "@TenKhachHang", model.TenKhachHang,
               "@GioiTinh", model.GioiTinh,
               "@Sđt", model.Sđt,
               "@DiaChi", model.DiaChi,
               "@Email", model.Email);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(KhachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_khach_update",
                "@makhachhang", model.MaKhachHang,
                "@tenKhachHang", model.TenKhachHang,
                "@gioiTinh", model.GioiTinh,
                "@sđt", model.Sđt,
                "@diaChi", model.DiaChi,
                "@email", model.Email);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string MakhachHang)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Khach_delete",
                "@MaKhachHang", MakhachHang);
                ;
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string DiaChi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khach", TenKhachHang,
                    "@dia_chi", DiaChi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhachHangMuaNhieuModel> TopKhachMuaHang()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_TopKhachHang");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<KhachHangMuaNhieuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
