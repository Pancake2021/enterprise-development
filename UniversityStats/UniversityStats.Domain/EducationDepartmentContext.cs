using UniversityStats.Domain.Entity;
using UniversityStats.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UniversityStats.Domain;

public class UniversityStatsContext : DbContext
{
    /// <summary>
    /// Departments collection
    /// </summary>
    public DbSet<Department> Department { get; set; }
    /// <summary>
    /// Departments and Specialties collection
    /// </summary>
    public DbSet<DepartmentSpecialty> DepartmentSpecialty { get; set; }
    /// <summary>
    /// Faculties collection
    /// </summary>
    public DbSet<Faculty> Faculty { get; set; }
    /// <summary>
    /// Specialties collection
    /// </summary>
    public DbSet<Specialty> Specialty { get; set; }
    /// <summary>
    /// Universities colections
    /// </summary>
    public DbSet<University> University { get; set; }
    private DatabaseSeeder _seed = null!;
    private readonly ILogger<UniversityStatsContext> _logger;

    /// <summary>
    /// Database creating
    /// </summary>
    /// <param name="dbContextOptions">option</param>
    /// <param name="logger">Logger for database context</param>
    public UniversityStatsContext(DbContextOptions dbContextOptions, ILogger<UniversityStatsContext> logger) : base(dbContextOptions)
    {
        _logger = logger;
        try 
        {
            Database.EnsureCreated();
            _logger.LogInformation("Database ensured created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating database");
            throw;
        }
    }

    /// <summary>
    /// Values to database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _seed = new DatabaseSeeder();

        modelBuilder.Entity<Department>().HasData(_seed.DepartmentsList);

        modelBuilder.Entity<DepartmentSpecialty>().HasData(_seed.DepartmentSpecialtyList);

        modelBuilder.Entity<Faculty>().HasData(_seed.FacultyList);

        modelBuilder.Entity<Specialty>().HasData(_seed.SpecialtyList);

        modelBuilder.Entity<University>().HasData(_seed.UniversityList);

        modelBuilder.Entity<University>().HasKey(university => university.RegistrationNumber);
        modelBuilder.Entity<Department>().HasKey(department => department.DepartmentId);
        modelBuilder.Entity<Faculty>().HasKey(faculty => faculty.FacultyId);
        modelBuilder.Entity<Specialty>().HasKey(specialty => specialty.SpecialtyId);
        modelBuilder.Entity<DepartmentSpecialty>().HasKey(x => x.SpecialtyId);

        modelBuilder.Entity<Faculty>()
            .HasOne<University>()
            .WithMany()
            .HasForeignKey(f => f.RegistrationNumber)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Department>()
            .HasOne<Faculty>()
            .WithMany()
            .HasForeignKey(d => d.FacultyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DepartmentSpecialty>()
            .HasOne<Department>()
            .WithMany()
            .HasForeignKey(ds => ds.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DepartmentSpecialty>()
            .HasOne<Specialty>()
            .WithMany()
            .HasForeignKey(ds => ds.SpecialtyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
