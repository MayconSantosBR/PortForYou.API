using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PortForYouProject.Data.Entities;

namespace PortForYouProject.Data.Contexts;

public partial class PortforyouContext : DbContext
{
    public PortforyouContext()
    {
    }

    public PortforyouContext(DbContextOptions<PortforyouContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Functionary> Functionaries { get; set; }

    public virtual DbSet<Project> Projects { get; set; }
    public DbSet<AssociatedProjects> AssociatedProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=portforyou;User Id=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Functionary>(entity =>
        {
            entity.HasKey(e => e.IdFunctionary).HasName("functionary_pkey");

            entity.ToTable("functionary");

            entity.Property(e => e.IdFunctionary).HasColumnName("idFunctionary");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Ocuppation)
                .HasMaxLength(100)
                .HasColumnName("ocuppation");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.IdProject).HasColumnName("idProject");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EstimatedDate).HasColumnName("estimatedDate");
            entity.Property(e => e.FinishDate).HasColumnName("finishDate");
            entity.Property(e => e.Manager)
                .HasMaxLength(255)
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Risk)
                .HasColumnName("risk");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasColumnName("status");
            entity.Property(e => e.TotalBudget).HasColumnName("totalBudget");

            entity.HasMany(d => d.IdFunctionaries).WithMany(p => p.IdProjects)
                .UsingEntity<Dictionary<string, object>>(
                    "AssociatedProject",
                    r => r.HasOne<Functionary>().WithMany()
                        .HasForeignKey("idFunctionary")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("functionary"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("idProject")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("project"),
                    j =>
                    {
                        j.HasKey("idProject", "idFunctionary").HasName("associatedProject_pkey");
                        j.ToTable("associatedProject");
                    });
        });

        modelBuilder.Entity<AssociatedProjects>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
