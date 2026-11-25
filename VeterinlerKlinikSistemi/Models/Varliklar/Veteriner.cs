using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class Veteriner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Klinik seçimi zorunludur.")]
        [Display(Name = "Klinik")]
        public int KlinikId { get; set; }

        [Display(Name = "Kullanıcı Hesabı")]
        public string? KullaniciId { get; set; }

        [Required(ErrorMessage = "Hekim adı soyadı zorunludur.")]
        [StringLength(120)]
        [Display(Name = "Hekim Adı Soyadı")]
        public string AdSoyad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur.")]
        [StringLength(250)]
        [Display(Name = "Uzmanlık Alanları")]
        public string UzmanlikAlanlari { get; set; } = string.Empty;

        [StringLength(1000)]
        [Display(Name = "Biyografi")]
        public string? Biyografi { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; } = true;

        // İlişkiler
        public Klinik Klinik { get; set; } = null!;
        public Kullanici? Kullanici { get; set; }
        public ICollection<VeterinerHizmet> VeterinerHizmetleri { get; set; } = new List<VeterinerHizmet>();
        public ICollection<VeterinerMusaitlik> Musaitlikler { get; set; } = new List<VeterinerMusaitlik>();
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
        public ICollection<AsiKaydi> AsiKayitlari { get; set; } = new List<AsiKaydi>();
    }
}

