using Microsoft.EntityFrameworkCore;
using Adresgegevens.Models;

namespace Adresgegevens.Data
{
    public partial class AdresgegevensContext : DbContext
    {
        public AdresgegevensContext(DbContextOptions<AdresgegevensContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresgegeven> Adresgegevens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresgegeven>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
