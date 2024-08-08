using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Sıra No")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün Adı gereklidir.")]
        [Display(Name = "Ürün Adı")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat alanı pozitif bir değer olmalıdır.")]
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Resim")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Kategori gereklidir.")]
        [Display(Name = "Kategori")]
        public int? CategoryId { get; set; }

        [Display(Name = "Resim Dosyası")]
        [Required(ErrorMessage = "Lütfen bir resim dosyası yükleyin.")]
        public IFormFile? ImageFile { get; set; }
    }
}
