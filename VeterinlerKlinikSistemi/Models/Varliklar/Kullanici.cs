using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VeterinlerKlinikSistemi.Models.Varliklar
{
    public class Kullanici : IdentityUser
    {
        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [StringLength(120)]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; } = string.Empty;

        [StringLength(128)]
        [Display(Name = "MCP API Anahtarı")]
        public string? McpApiAnahtari { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; } = DateTime.UtcNow;

        // İlişkiler
        public ICollection<EvcilHayvan> EvcilHayvanlar { get; set; } = new List<EvcilHayvan>();
        public Veteriner? Veteriner { get; set; }
    }
}

