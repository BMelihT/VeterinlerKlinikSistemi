using System.ComponentModel.DataAnnotations;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class VeterinerMusaitlik
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Veteriner Hekim")]
        public int VeterinerId { get; set; }

        [Required(ErrorMessage = "Gün seçimi zorunludur.")]
        [Display(Name = "Haftanın Günü")]
        public DayOfWeek Gun { get; set; }

        [Required(ErrorMessage = "Başlangıç saati zorunludur.")]
        [Display(Name = "Başlangıç Saati")]
        public TimeOnly BaslangicSaati { get; set; }

        [Required(ErrorMessage = "Bitiş saati zorunludur.")]
        [Display(Name = "Bitiş Saati")]
        public TimeOnly BitisSaati { get; set; }

        // İlişki
        public Veteriner Veteriner { get; set; } = null!;
    }
}

