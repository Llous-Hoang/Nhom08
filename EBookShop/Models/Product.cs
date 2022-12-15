using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EBookShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBookShop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string SKU { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Price { get; set; } = 0;

        [DisplayName("Tồn kho")]
        [DefaultValue(0)]
        public int Stock { get; set; } = 0;

        public int ProductTypeId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SubmittedOn { get; set; } = DateTime.Now;

        // Navigation reference property cho khóa ngoại đến ProductType
        [DisplayName("Loại sản phẩm")]
        public ProductType ProductType { get; set; }

        [DisplayName("Ảnh minh họa")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Còn hiệu lực")]
        [DefaultValue(true)]
        public bool Status { get; set; } = true;
    }
}
