using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Models.Data
{
    public class KursKayit
    {
        [Key]
        public int KursKayitId { get; set; }

        [Display(Name = "Öğrenci ID")]
        public int OgrenciId { get; set; }

        [ForeignKey("OgrenciId")]
        [Display(Name = "Öğrenci")]
        public Ogrenci Ogrenci { get; set; } = null!;

        [Display(Name = "Kurs ID")]
        public int KursId { get; set; }

        [ForeignKey("KursId")]
        [Display(Name = "Kurs")]
        public Kurs Kurs { get; set; } = null!;

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }
    }
}