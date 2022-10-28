using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EBookShop.Models
{
    public class Account
    {
        public int Id { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string username { get; set; }

        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string password { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string email { get; set; }

        [DisplayName("SĐT")]
        [RegularExpression("0\\d{9}", ErrorMessage = "SĐT không hợp lệ")]
        public string phone { get; set; }

        [DisplayName("Địa chỉ")]
        public string address { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string avatar { get; set; }

        [DisplayName("Là admin")]
        [DefaultValue(true)]
        public bool isAdmin { get; set; } = true;

        [DisplayName("Được kích hoạt")]
        [DefaultValue(true)]
        public bool isActive { get; set; } = true ;


    }
}
