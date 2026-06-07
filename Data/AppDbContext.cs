using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Propiedad> Propiedades => Set<Propiedad>();
    public DbSet<FotoPropiedad> FotosPropiedad => Set<FotoPropiedad>();
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<LeaseContract> LeaseContracts => Set<LeaseContract>();
    public DbSet<ContractSubmission> ContractSubmissions => Set<ContractSubmission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.Property(p => p.PrecioMensual).HasPrecision(10, 2);
            entity.Property(p => p.MetrosCuadrados).HasPrecision(8, 2);
            entity.Property(p => p.DepositAmount).HasPrecision(10, 2);
            entity.HasIndex(p => p.Slug).IsUnique();
            entity.HasIndex(p => p.Ciudad);
        });

        modelBuilder.Entity<FotoPropiedad>(entity =>
        {
            entity.HasOne(f => f.Propiedad)
                .WithMany(p => p.Fotos)
                .HasForeignKey(f => f.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasOne(c => c.Propiedad)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.FechaHora);
            entity.HasIndex(c => c.Estado);
            entity.HasIndex(c => c.PublicToken).IsUnique();
        });

        modelBuilder.Entity<LeaseContract>(entity =>
        {
            entity.HasOne(c => c.Propiedad)
                .WithOne(p => p.LeaseContract)
                .HasForeignKey<LeaseContract>(c => c.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.PropiedadId).IsUnique();
        });

        modelBuilder.Entity<ContractSubmission>(entity =>
        {
            entity.HasOne(s => s.Propiedad)
                .WithMany()
                .HasForeignKey(s => s.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.SubmittedAt);
            entity.HasIndex(c => c.SubmissionType);
            entity.HasIndex(c => c.PropiedadId);
        });
    }
}
