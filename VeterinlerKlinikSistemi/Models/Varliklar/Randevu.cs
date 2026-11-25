using System.ComponentModel.DataAnnotations;
using VeterinlerKlinikSistemi.Models.Enumlar;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Klinik")]
        public int KlinikId { get; set; }

        [Required(ErrorMessage = "Evcil hayvan seçimi zorunludur.")]
        [Display(Name = "Evcil Hayvan")]
        public int EvcilHayvanId { get; set; }

        [Required(ErrorMessage = "Veteriner hekim seçimi zorunludur.")]
        [Display(Name = "Veteriner Hekim")]
        public int VeterinerId { get; set; }

        [Required(ErrorMessage = "Hizmet seçimi zorunludur.")]
        [Display(Name = "Hizmet")]
        public int HizmetId { get; set; }

        [Required(ErrorMessage = "Randevu başlangıç tarihi ve saati zorunludur.")]
        [Display(Name = "Başlangıç Tarih/Saat")]
        public DateTime BaslangicTarihSaat { get; set; }

        [Display(Name = "Bitiş Tarih/Saat")]
        public DateTime BitisTarihSaat { get; set; }

        [Range(5, 480)]
        [Display(Name = "Süre (Dakika)")]
        public int SureDakika { get; set; }

        [Range(0, 1000000)]
        [Display(Name = "Ücret (TL)")]
        public decimal Ucret { get; set; }

        [Display(Name = "Durum")]
        public RandevuDurumu Durum { get; set; } = RandevuDurumu.Bekliyor;

        [StringLength(2000)]
        [Display(Name = "Muayene Notu")]
        public string? MuayeneNotu { get; set; }

        [StringLength(500)]
        [Display(Name = "Red Nedeni")]
        public string? RedNedeni { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.UtcNow;

        // İlişkiler
        public Klinik Klinik { get; set; } = null!;
        public EvcilHayvan EvcilHayvan { get; set; } = null!;
        public Veteriner Veteriner { get; set; } = null!;
        public Hizmet Hizmet { get; set; } = null!;
    }
}

