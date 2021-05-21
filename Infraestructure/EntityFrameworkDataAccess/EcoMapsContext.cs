using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class EcoMapsContext : DbContext
    {
        public EcoMapsContext()
        {
        }

        public EcoMapsContext(DbContextOptions<EcoMapsContext> options)
            : base(options)
        {
 
        }

        public virtual DbSet<Estacion> Estacions { get; set; }
        public virtual DbSet<PuntosxVehiculo> PuntosxVehiculos { get; set; }
        public virtual DbSet<Rango> Rangos { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JUAN-RAMOS\\SQLEXPRESS01;Database=EcoMaps;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.HasKey(e => e.IdEstacion);

                entity.ToTable("Estacion");

                entity.Property(e => e.IdEstacion).HasColumnName("idEstacion");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PuntosxVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdPuntosxVehiculo);

                entity.ToTable("PuntosxVehiculo");

                entity.Property(e => e.IdPuntosxVehiculo).HasColumnName("idPuntosxVehiculo");

                entity.Property(e => e.MatriculaVehiculo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MatriculaVehiculoNavigation)
                    .WithMany(p => p.PuntosxVehiculos)
                    .HasForeignKey(d => d.MatriculaVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntosxVehiculo_Vehiculo");
            });

            modelBuilder.Entity<Rango>(entity =>
            {
                entity.HasKey(e => e.IdRango);

                entity.Property(e => e.IdRango).HasColumnName("idRango");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdEstacion).HasColumnName("idEstacion");

                entity.Property(e => e.MatriculaVehiculo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdEstacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Estacion");

                entity.HasOne(d => d.MatriculaVehiculoNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.MatriculaVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Vehiculo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.MatriculaVehiculo);

                entity.ToTable("Vehiculo");

                entity.Property(e => e.MatriculaVehiculo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaPropietario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaPropietarioNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.CedulaPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
