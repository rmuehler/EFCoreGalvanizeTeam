using Microsoft.EntityFrameworkCore;
using static EFCoreGalvanizeTeam.Student;

namespace EFCoreGalvanizeTeam.Data
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=app.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var grades = new Grade[] {
        new Grade { Id = 1, StudentId = 1, CourseName = "English I", Value = 90 },
        new Grade { Id = 2, StudentId = 1, CourseName = "Calculus II", Value = 70 },
        new Grade { Id = 3, StudentId = 2, CourseName = "Theater Appreciation", Value = 50 },
        new Grade { Id = 4, StudentId = 2, CourseName = "Dynamic Programming", Value = 85 },
        new Grade { Id = 5, StudentId = 2, CourseName = "Data Structures", Value = 15 },
        new Grade { Id = 6, StudentId = 3, CourseName = "Senior Design I", Value = 97 },
        new Grade { Id = 7, StudentId = 3, CourseName = "Cloud Computing", Value = 75 },
        new Grade { Id = 8, StudentId = 5, CourseName = "Mixology", Value = 20 },
        new Grade { Id = 9, StudentId = 5, CourseName = "Mixology II", Value = 95 },
        new Grade { Id = 10, StudentId = 6, CourseName = "Mixology", Value = 16 },
      };
      var students = new Student[] {
        new Student {Id = 1, FirstName = "Samuel", LastName = "Adams", Age = 14, Classification = Class.Freshman},
        new Student {Id = 2, FirstName = "Jack", LastName = "Daniels", Age = 16, Classification = Class.Sophomore},
        new Student {Id = 3, FirstName = "Jim", LastName = "Bean", Age = 17, Classification = Class.Senior},
        new Student {Id = 4, FirstName = "Johnnie", LastName = "Walker", Age = 15, Classification = Class.Junior},
        new Student {Id = 5, FirstName = "Don", LastName = "Julio", Age = 20, Classification = Class.Sophomore},
        new Student {Id = 6, FirstName = "Jose", LastName = "Cuervo", Age = 18, Classification = Class.Senior},
      };
      modelBuilder.Entity<Student>().HasData(students);
      modelBuilder.Entity<Grade>().HasData(grades);
    }
  }
}