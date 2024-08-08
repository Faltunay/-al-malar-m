using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Models.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }

        [Display(Name = "Ad")]
        public string? OgrenciAd { get; set; }

        [Display(Name = "Soyad")]
        public string? OgrenciSoyad { get; set; }

        [Display(Name = "E-Posta")]
        public string? EPosta { get; set; }

        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }

        [Display(Name = "Ad Soyad")]
        public string? AdSoyad
        {
            get
            {
                return $"{OgrenciAd} {OgrenciSoyad}";
            }
        }

        public ICollection<KursKayit> KursKayitlari {get;set;}=new List<KursKayit>();
    }
}
