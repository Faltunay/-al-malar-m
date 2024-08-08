using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EfCoreApp.Models.Data
{
    public class KursViewModel
    {
        public int KursId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Kurs Başlığı")]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}