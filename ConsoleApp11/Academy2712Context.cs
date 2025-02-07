using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp11;

public partial class Academy2712Context : DbContext
{
    public Academy2712Context()
    {
    }

    public Academy2712Context(DbContextOptions<Academy2712Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Curator> Curators { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupsCurator> GroupsCurators { get; set; }

    public virtual DbSet<GroupsLecture> GroupsLectures { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-005JK2O\\SQLEXPRESS;Database=Academy_27_12;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curators__3214EC07073BDE2E");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC070279D5E1");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F63B387C9C").IsUnique();

            entity.Property(e => e.Financing).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Faculties");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facultie__3214EC07ECD17DFC");

            entity.HasIndex(e => e.Name, "UQ__Facultie__737584F64BBB5631").IsUnique();

            entity.Property(e => e.Financing).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC071A82F6D3");

            entity.HasIndex(e => e.Name, "UQ__Groups__737584F631BE1C0D").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(10);

            entity.HasOne(d => d.Departament).WithMany(p => p.Groups)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Departments");
        });

        modelBuilder.Entity<GroupsCurator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupsCu__3214EC077C861AFD");

            entity.HasOne(d => d.Curator).WithMany(p => p.GroupsCurators)
                .HasForeignKey(d => d.CuratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsCurators_Curators");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupsCurators)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsCurators_Groups");
        });

        modelBuilder.Entity<GroupsLecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupsLe__3214EC0716CD218F");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupsLectures)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsLectures_Groups");

            entity.HasOne(d => d.Lecture).WithMany(p => p.GroupsLectures)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsLectures_Lectures");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lectures__3214EC07CAD856F1");

            entity.HasOne(d => d.Subject).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lectures_Subjects");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lectures_Teachers");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC075EB216D7");

            entity.HasIndex(e => e.Name, "UQ__Subjects__737584F61C4156F6").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC0723E99001");

            entity.Property(e => e.Salary).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
