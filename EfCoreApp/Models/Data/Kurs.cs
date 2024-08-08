using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Models.Data
{
    public class Kurs
    {
        public int KursId { get; set; }
        [Display(Name = "Kurs Adı")]
        public string? Baslik { get; set; }
        public int? OgretmenId { get; set; }
        public Ogretmen? Ogretmen { get; set; }
        public ICollection<KursKayit> KursKayitlari {get;set;}=new List<KursKayit>();
    }
}