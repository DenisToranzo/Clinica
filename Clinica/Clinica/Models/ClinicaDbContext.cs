using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Models;

public partial class ClinicaDbContext : DbContext
{
    public ClinicaDbContext()
    {
    }

    public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Facturacion> Facturacions { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-G8L5S41\\SQLEXPRESS; database=ClinicaDb; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Citas__3214EC07613A9CD9");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaCita).HasColumnType("datetime");
            entity.Property(e => e.Motivo).HasMaxLength(255);

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Citas__MedicoId__5812160E");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Citas__PacienteI__571DF1D5");
        });

        modelBuilder.Entity<Facturacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facturac__3214EC0749E39019");

            entity.ToTable("Facturacion");

            entity.Property(e => e.EstadoPago).HasMaxLength(50);
            entity.Property(e => e.FechaFacturacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cita).WithMany(p => p.Facturacions)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK__Facturaci__CitaI__5EBF139D");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicos__3214EC076F1E5FDF");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Especialidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC0777A5A8C8");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tratamie__3214EC07A6F7D0ED");

            entity.Property(e => e.Descripcion).HasMaxLength(255);

            entity.HasOne(d => d.Cita).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tratamien__CitaI__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
