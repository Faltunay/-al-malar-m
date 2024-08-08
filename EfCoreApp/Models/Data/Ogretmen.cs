using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EfCoreApp.Models.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string AdSoyad
        {
            get
            {
                return this.Ad + " " + this.Soyad;
            }
        }
        public string? EPosta { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Başlama Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}