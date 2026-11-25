using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class AsiKaydi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Evcil hayvan seçimi zorunludur.")]
        [Display(Name = "Evcil Hayvan")]
        public int EvcilHayvanId { get; set; }

        [Display(Name = "Uygulayan Hekim")]
        public int? VeterinerId { get; set; }

        [Required(ErrorMessage = "Aşı adı zorunludur.")]
        [StringLength(120)]
        [Display(Name = "Aşı Adı")]
        public string AsiAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yapıldığı tarih zorunludur.")]
        [Display(Name = "Yapıldığı Tarih")]
        public DateOnly YapildigiTarih { get; set; }

        [Display(Name = "Bir Sonraki Doz Tarihi")]
        public DateOnly? SonrakiDozTarihi { get; set; }

        [StringLength(500)]
        [Display(Name = "Notlar")]
        public string? Notlar { get; set; }

        // İlişkiler
        public EvcilHayvan EvcilHayvan { get; set; } = null!;
        public Veteriner? Veteriner { get; set; }
    }
}

