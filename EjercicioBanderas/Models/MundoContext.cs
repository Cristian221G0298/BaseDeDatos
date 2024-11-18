using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EjercicioBanderas.Models;

public partial class MundoContext : DbContext
{
    public MundoContext()
    {
    }

    public MundoContext(DbContextOptions<MundoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paises> Paises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;user=root;database=Mundo;password=root;port=3307", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Paises>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("paises");

            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Continente).HasMaxLength(15);
            entity.Property(e => e.FormaGobierno)
                .HasMaxLength(45)
                .HasDefaultValueSql("''")
                .IsFixedLength();
            entity.Property(e => e.Gnp).HasColumnName("GNP");
            entity.Property(e => e.Gnpold).HasColumnName("GNPOld");
            entity.Property(e => e.IndepYear).HasColumnType("smallint(6)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(52)
                .IsFixedLength();
            entity.Property(e => e.NumeroHabitantes).HasColumnType("int(11)");
            entity.Property(e => e.Presidente)
                .HasMaxLength(60)
                .IsFixedLength();
            entity.Property(e => e.Region)
                .HasMaxLength(26)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
