using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class Hizmet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Klinik seçimi zorunludur.")]
        [Display(Name = "Klinik")]
        public int KlinikId { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [StringLength(120)]
        [Display(Name = "Hizmet Adı")]
        public string Ad { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Required(ErrorMessage = "Süre zorunludur.")]
        [Range(5, 480, ErrorMessage = "Hizmet süresi 5 ile 480 dakika arasında olmalıdır.")]
        [Display(Name = "Süre (Dakika)")]
        public int SureDakika { get; set; } = 30;

        [Required(ErrorMessage = "Ücret zorunludur.")]
        [Range(0, 1000000, ErrorMessage = "Ücret 0 veya daha büyük olmalıdır.")]
        [Display(Name = "Ücret (TL)")]
        public decimal Ucret { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; } = true;

        // İlişkiler
        public Klinik Klinik { get; set; } = null!;
        public ICollection<VeterinerHizmet> VeterinerHizmetleri { get; set; } = new List<VeterinerHizmet>();
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
    }
}

