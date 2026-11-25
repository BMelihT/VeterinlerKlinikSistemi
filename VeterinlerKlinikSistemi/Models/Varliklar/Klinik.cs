using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class Klinik
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Klinik adı zorunludur.")]
        [StringLength(150)]
        [Display(Name = "Klinik Adı")]
        public string Ad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres zorunludur.")]
        [StringLength(300)]
        [Display(Name = "Adres")]
        public string Adres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [StringLength(25)]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150)]
        [Display(Name = "E-Posta")]
        public string? Eposta { get; set; }

        [Required(ErrorMessage = "Açılış saati zorunludur.")]
        [Display(Name = "Açılış Saati")]
        public TimeOnly AcilisSaati { get; set; } = new TimeOnly(9, 0);

        [Required(ErrorMessage = "Kapanış saati zorunludur.")]
        [Display(Name = "Kapanış Saati")]
        public TimeOnly KapanisSaati { get; set; } = new TimeOnly(18, 0);

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; } = true;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.UtcNow;

        // İlişkiler
        public ICollection<Hizmet> Hizmetler { get; set; } = new List<Hizmet>();
        public ICollection<Veteriner> Veterinerler { get; set; } = new List<Veteriner>();
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
    }
}

