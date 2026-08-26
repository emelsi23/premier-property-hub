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
    public DbSet<StampSealContract> StampSealContracts => Set<StampSealContract>();
    public DbSet<StampSealSubmission> StampSealSubmissions => Set<StampSealSubmission>();
    public DbSet<Agente> Agentes => Set<Agente>();
    public DbSet<ReservaGenerica> ReservasGenericas => Set<ReservaGenerica>();
    public DbSet<ReservaPaymentSettings> ReservaPaymentSettings => Set<ReservaPaymentSettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.Property(p => p.PrecioMensual).HasPrecision(10, 2);
            entity.Property(p => p.MetrosCuadrados).HasPrecision(8, 2);
            entity.Property(p => p.DepositAmount).HasPrecision(10, 2);
            entity.Property(p => p.StampsAmount).HasPrecision(10, 2);
            entity.Property(p => p.SealsAmount).HasPrecision(10, 2);
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
            entity.Property(c => c.Salario).HasPrecision(10, 2);
            entity.Property(c => c.DisponibleParaAsegurar).HasPrecision(10, 2);
            entity.Property(c => c.AdminUsername).HasMaxLength(64);
            entity.HasIndex(c => c.FechaHora);
            entity.HasIndex(c => c.Estado);
            entity.HasIndex(c => c.PublicToken).IsUnique();
            entity.HasIndex(c => c.AdminUsername);
        });

        modelBuilder.Entity<LeaseContract>(entity =>
        {
            entity.Property(c => c.Id).UseIdentityByDefaultColumn();
            entity.HasOne(c => c.Propiedad)
                .WithOne(p => p.LeaseContract)
                .HasForeignKey<LeaseContract>(c => c.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.PropiedadId).IsUnique();
        });

        modelBuilder.Entity<StampSealContract>(entity =>
        {
            entity.Property(c => c.Id).UseIdentityByDefaultColumn();
            entity.HasOne(c => c.Propiedad)
                .WithOne(p => p.StampSealContract)
                .HasForeignKey<StampSealContract>(c => c.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.PropiedadId).IsUnique();
        });

        modelBuilder.Entity<StampSealSubmission>(entity =>
        {
            entity.Property(c => c.Id).UseIdentityByDefaultColumn();
            entity.HasOne(s => s.Propiedad)
                .WithMany()
                .HasForeignKey(s => s.PropiedadId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(c => c.SubmittedAt);
            entity.HasIndex(c => c.SubmissionType);
            entity.HasIndex(c => c.PropiedadId);
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

        modelBuilder.Entity<Agente>(entity =>
        {
            entity.Property(a => a.Calificacion).HasPrecision(3, 2);
            entity.Property(a => a.TiempoRespuestaHoras).HasPrecision(5, 2);
            entity.HasIndex(a => a.Slug).IsUnique();
            entity.HasIndex(a => a.Activo);
            entity.HasIndex(a => a.CodigoVerificacion);
        });

        modelBuilder.Entity<ReservaGenerica>(entity =>
        {
            entity.Property(r => r.DepositAmount).HasPrecision(10, 2);
            entity.Property(r => r.AdminUsername).HasMaxLength(64);
            entity.HasIndex(r => r.PublicToken).IsUnique();
            entity.HasIndex(r => r.CodigoConfirmacion).IsUnique();
            entity.HasIndex(r => r.Estado);
            entity.HasIndex(r => r.FechaSolicitud);
            entity.HasIndex(r => r.AdminUsername);
        });

        modelBuilder.Entity<ReservaPaymentSettings>(entity =>
        {
            entity.Property(s => s.DepositAmount).HasPrecision(10, 2);
            entity.Property(s => s.NoShowFee).HasPrecision(10, 2);
            entity.Property(s => s.AdminUsername).HasMaxLength(64);
            entity.HasIndex(s => s.AdminUsername).IsUnique();
        });
    }
}
