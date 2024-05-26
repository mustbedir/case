using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Models;

public partial class AdessoContext : DbContext
{
    public AdessoContext()
    {
    }

    public AdessoContext(DbContextOptions<AdessoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Draw> Draws { get; set; }

    public virtual DbSet<DrawGroup> DrawGroups { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupTeam> GroupTeams { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PAYGATE-1\\SQLEXPRESS;Database=Adesso;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Draw>(entity =>
        {
            entity.ToTable("Draw");

            entity.Property(e => e.FullName).HasMaxLength(200);
        });

        modelBuilder.Entity<DrawGroup>(entity =>
        {
            entity.ToTable("DrawGroup");

            entity.Property(e => e.GroupId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Draw).WithMany(p => p.DrawGroups)
                .HasForeignKey(d => d.DrawId)
                .HasConstraintName("FK_DrawGroup_Draw");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Group_1");

            entity.ToTable("Group");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupTeam>(entity =>
        {
            entity.ToTable("GroupTeam");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Team_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
