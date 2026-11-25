using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class EvcilHayvan
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hayvan Sahibi")]
        public string SahipId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Evcil hayvan adı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Adı")]
        public string Ad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tür zorunludur.")]
        [StringLength(60)]
        [Display(Name = "Türü")]
        public string Tur { get; set; } = string.Empty;

        [Required(ErrorMessage = "Irk zorunludur.")]
        [StringLength(80)]
        [Display(Name = "Irkı")]
        public string Irk { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [Display(Name = "Doğum Tarihi")]
        public DateOnly DogumTarihi { get; set; }

        [Required(ErrorMessage = "Kilo zorunludur.")]
        [Range(0.05, 500, ErrorMessage = "Kilo 0.05 ile 500 kg arasında olmalıdır.")]
        [Display(Name = "Kilo (kg)")]
        public decimal Kilo { get; set; }

        [StringLength(300)]
        [Display(Name = "Fotoğraf")]
        public string? FotografYolu { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; } = DateTime.UtcNow;

        // İlişkiler
        public Kullanici Sahip { get; set; } = null!;
        public ICollection<AsiKaydi> AsiKayitlari { get; set; } = new List<AsiKaydi>();
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
    }
}

