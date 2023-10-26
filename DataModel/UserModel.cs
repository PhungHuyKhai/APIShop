
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class UserModel
    {
        public int mataikhoan { get; set; }
        public int maloaitk { get; set; }
        public string tentk { get; set; }
        public string matkhau { get; set; }
        public string token { get; set; }
    }
    public class AuthenticateModel
    {
        public int mataikhoan { get; set; }
        [Required]
        public int maloaitk { get; set; }
        [Required]
        public string tentk { get; set; }

        [Required]
        public string matkhau { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        public int maloaitk { get; set; }
        [Required]
        public string tentk { get; set; }
        [Required]
        public string matkhau { get; set; }
    }
    public class UpdateModel
    {
        [Required]
        public int mataikhoan { get; set; }
        public int maloaitaikhoan { get; set; }
        [Required]
        public string tentk { get; set; }
        [Required]
        public string matkhau { get; set; }
    }
    
}


