using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityStats.Infrastructure.Entities;
using UniversityStats.Infrastructure.Identity;

namespace UniversityStats.Infrastructure.Data;

public class UniversityStatsContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public UniversityStatsContext(DbContextOptions<UniversityStatsContext> options) : base(options)
    {
    }

    public DbSet<University> Universities { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<University>()
            .HasMany(u => u.Departments)
            .WithOne(d => d.University)
            .HasForeignKey(d => d.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Faculties)
            .WithOne(f => f.Department)
            .HasForeignKey(f => f.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Faculty>()
            .HasMany(f => f.Specialties)
            .WithOne(s => s.Faculty)
            .HasForeignKey(s => s.FacultyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Specialty>()
            .HasMany(s => s.Groups)
            .WithOne(g => g.Specialty)
            .HasForeignKey(g => g.SpecialtyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<University>().HasData(
            new University { Id = 1, Name = "Технический университет", Description = "Ведущий технический университет" }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Факультет информационных технологий", UniversityId = 1 }
        );

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty { Id = 1, Name = "Кафедра программной инженерии", DepartmentId = 1 }
        );

        modelBuilder.Entity<Specialty>().HasData(
            new Specialty { Id = 1, Name = "Программная инженерия", FacultyId = 1 }
        );

        modelBuilder.Entity<Group>().HasData(
            new Group { Id = 1, Name = "ПИ-21", SpecialtyId = 1 }
        );
    }
}
