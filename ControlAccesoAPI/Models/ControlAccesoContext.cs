using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlAccesoAPI.Models
{
    public partial class ControlAccesoContext : DbContext
    {
        public ControlAccesoContext()
        {
        }

        public ControlAccesoContext(DbContextOptions<ControlAccesoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<HorariosDetalle> HorariosDetalle { get; set; }
        public virtual DbSet<Sedes> Sedes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server = 76.74.150.83,1433;Database=ControlAcceso;User Id = admin; Password = 2020; Integrated Security = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sede)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.SedeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Sedes");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horarios_Areas");
            });

            modelBuilder.Entity<HorariosDetalle>(entity =>
            {
                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.HorariosDetalle)
                    .HasForeignKey(d => d.HorarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HorariosDetalle_Horarios");
            });

            modelBuilder.Entity<Sedes>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sedes_Empresas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
