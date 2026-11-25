using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeterinlerKlinikSistemi.Models.Varliklar;

namespace VeterinlerKlinikSistemi.Veri
{
    public class UygulamaDbContext : IdentityDbContext<Kullanici>
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klinik> Klinikler => Set<Klinik>();
        public DbSet<Hizmet> Hizmetler => Set<Hizmet>();
        public DbSet<Veteriner> Veterinerler => Set<Veteriner>();
        public DbSet<VeterinerHizmet> VeterinerHizmetleri => Set<VeterinerHizmet>();
        public DbSet<VeterinerMusaitlik> VeterinerMusaitlikleri => Set<VeterinerMusaitlik>();
        public DbSet<EvcilHayvan> EvcilHayvanlar => Set<EvcilHayvan>();
        public DbSet<AsiKaydi> AsiKayitlari => Set<AsiKaydi>();
        public DbSet<Randevu> Randevular => Set<Randevu>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Kullanici
            builder.Entity<Kullanici>(entity =>
            {
                entity.HasIndex(k => k.McpApiAnahtari)
                      .IsUnique()
                      .HasFilter("[McpApiAnahtari] IS NOT NULL");
            });

            // Klinik
            builder.Entity<Klinik>(entity =>
            {
                entity.ToTable("Klinikler");
            });

            // Hizmet
            builder.Entity<Hizmet>(entity =>
            {
                entity.ToTable("Hizmetler");

                entity.Property(h => h.Ucret)
                      .HasPrecision(18, 2);

                entity.HasOne(h => h.Klinik)
                      .WithMany(k => k.Hizmetler)
                      .HasForeignKey(h => h.KlinikId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Veteriner
            builder.Entity<Veteriner>(entity =>
            {
                entity.ToTable("Veterinerler");

                entity.HasOne(v => v.Klinik)
                      .WithMany(k => k.Veterinerler)
                      .HasForeignKey(v => v.KlinikId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Kullanici)
                      .WithOne(u => u.Veteriner)
                      .HasForeignKey<Veteriner>(v => v.KullaniciId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(v => v.KullaniciId)
                      .IsUnique()
                      .HasFilter("[KullaniciId] IS NOT NULL");
            });

            // VeterinerHizmet (Coka-cok birlesik anahtar)
            builder.Entity<VeterinerHizmet>(entity =>
            {
                entity.ToTable("VeterinerHizmetleri");

                entity.HasKey(vh => new { vh.VeterinerId, vh.HizmetId });

                entity.HasOne(vh => vh.Veteriner)
                      .WithMany(v => v.VeterinerHizmetleri)
                      .HasForeignKey(vh => vh.VeterinerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(vh => vh.Hizmet)
                      .WithMany(h => h.VeterinerHizmetleri)
                      .HasForeignKey(vh => vh.HizmetId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // VeterinerMusaitlik
            builder.Entity<VeterinerMusaitlik>(entity =>
            {
                entity.ToTable("VeterinerMusaitlikleri");

                entity.HasOne(vm => vm.Veteriner)
                      .WithMany(v => v.Musaitlikler)
                      .HasForeignKey(vm => vm.VeterinerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(vm => new { vm.VeterinerId, vm.Gun });
            });

            // EvcilHayvan
            builder.Entity<EvcilHayvan>(entity =>
            {
                entity.ToTable("EvcilHayvanlar");

                entity.Property(e => e.Kilo)
                      .HasPrecision(5, 2);

                entity.HasOne(e => e.Sahip)
                      .WithMany(u => u.EvcilHayvanlar)
                      .HasForeignKey(e => e.SahipId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // AsiKaydi
            builder.Entity<AsiKaydi>(entity =>
            {
                entity.ToTable("AsiKayitlari");

                entity.HasOne(a => a.EvcilHayvan)
                      .WithMany(e => e.AsiKayitlari)
                      .HasForeignKey(a => a.EvcilHayvanId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Veteriner)
                      .WithMany(v => v.AsiKayitlari)
                      .HasForeignKey(a => a.VeterinerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(a => new { a.EvcilHayvanId, a.SonrakiDozTarihi });
            });

            // Randevu (SQL Server coklu cascade silme hatasini onlemek icin Restrict)
            builder.Entity<Randevu>(entity =>
            {
                entity.ToTable("Randevular");

                entity.Property(r => r.Ucret)
                      .HasPrecision(18, 2);

                entity.HasOne(r => r.Klinik)
                      .WithMany(k => k.Randevular)
                      .HasForeignKey(r => r.KlinikId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.EvcilHayvan)
                      .WithMany(e => e.Randevular)
                      .HasForeignKey(r => r.EvcilHayvanId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Veteriner)
                      .WithMany(v => v.Randevular)
                      .HasForeignKey(r => r.VeterinerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Hizmet)
                      .WithMany(h => h.Randevular)
                      .HasForeignKey(r => r.HizmetId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(r => new { r.VeterinerId, r.BaslangicTarihSaat, r.BitisTarihSaat });
                entity.HasIndex(r => new { r.EvcilHayvanId, r.BaslangicTarihSaat });
            });
        }
    }
}

