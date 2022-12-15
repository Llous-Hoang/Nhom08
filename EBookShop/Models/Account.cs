using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EBookShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBookShop.Models
{
    public class Account
    {
        public static object Configuration { get; internal set; }
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

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} từ 6-50 kí tự")]
        public string fullname { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string avatar { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Là admin")]
        [DefaultValue(false)]
        public bool isAdmin { get; set; }

        [DisplayName("Được kích hoạt")]
        [DefaultValue(true)]
        public bool isActive { get; set; } = true ;

        // Collection reference property cho khóa ngoại từ Invoice
        public List<Invoice> Invoices { get; set; }

        // Collection reference property cho khóa ngoại từ Cart
        public List<Cart> Carts { get; set; }
    }
}

