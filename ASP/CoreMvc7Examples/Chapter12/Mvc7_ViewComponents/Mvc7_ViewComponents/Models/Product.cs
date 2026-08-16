
namespace Mvc7_ViewComponents.Models
{
    public class Product
    {
        [StringLength(20)]
        [Display(Name ="產品Id")]
        public string ProductId { get; set; }
        [StringLength(30)]
        [Display(Name = "產品名稱")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "價格")]
        public decimal Price { get; set; }
        [StringLength(15)]
        [Display(Name = "分類")]
        public string Category { get; set; }
    }
}
