using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Models;

public partial class Parcial1Context : DbContext
{
    public Parcial1Context()
    {
    }

    public Parcial1Context(DbContextOptions<Parcial1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ALMS\\SQLEXPRESS; Database=Parcial1; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.IdComida);

            entity.Property(e => e.IdComida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Id_Comida");
            entity.Property(e => e.NombreComida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Comida");
            entity.Property(e => e.OrigenComida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Origen_Comida");
            entity.Property(e => e.PrecioComida).HasColumnName("Precio_Comida");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdRaza);

            entity.Property(e => e.IdRaza)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Id_raza");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NPatas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("N_Patas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.ToTable("Propietario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
