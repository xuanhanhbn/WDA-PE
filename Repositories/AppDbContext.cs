using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;

namespace WDA_PE.Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty
            {
                FacultyId = new Guid("30000000-0000-0000-0000-000000000001"),
                Name = "Jayalakshmi"
            },
            new Faculty
            {
                FacultyId = new Guid("30000000-0000-0000-0000-000000000002"),
                Name = "John Carter"
            },
            new Faculty
            {
                FacultyId = new Guid("30000000-0000-0000-0000-000000000003"),
                Name = "HienPA"
            });
        modelBuilder.Entity<Classroom>().HasData(
            new Classroom
            {
                ClassroomId = new Guid("20000000-0000-0000-0000-000000000001"),
                RoomNo = "B10"
            },
            new Classroom
            {
                ClassroomId = new Guid("20000000-0000-0000-0000-000000000002"),
                RoomNo = "B14"
            },
            new Classroom
            {
                ClassroomId = new Guid("20000000-0000-0000-0000-000000000003"),
                RoomNo = "B16"
            }); 
        modelBuilder.Entity<Subject>().HasData(
            new Subject
            {
                SubjectId = new Guid("10000000-0000-0000-0000-000000000001"),
                SubjectName = "ASP.NET MVC"
            },
            new Subject
            {
                SubjectId = new Guid("10000000-0000-0000-0000-000000000002"),
                SubjectName = "Core Java"
            },
            new Subject
            {
                SubjectId = new Guid("10000000-0000-0000-0000-000000000003"),
                SubjectName = "C++"
            });
    }
}