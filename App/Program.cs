using System;
using System.Linq;
using EFCoreGalvanizeTeam.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGalvanizeTeam
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new DatabaseContext();

      Console.WriteLine("Show List of all students!");
      foreach (var student in db.Students.Select(student => new { fName = student.FirstName, lName = student.LastName }))
      {
        Console.WriteLine($"{student.fName} {student.lName}");
      }

      Console.WriteLine("\nShow Don Julio's grades!");
      var student1 = db.Students.Include(student => student.Grades)
          .Where(student => student.FirstName == "Don")
          .Select(student => new { grades = student.Grades })
          .FirstOrDefault();
      student1.grades.ToList().ForEach(grade => Console.WriteLine($"{grade.Value}"));

      Console.WriteLine("\nGiven a student's name find their average grade among all their courses");
      var student2 = db.Students.Include(student => student.Grades)
          .Where(student => student.FirstName == "Jack")
          .Select(student => new
          {
            average = student.Grades.Average(grade => (float)grade.Value),
            fName = student.FirstName,
            lName = student.LastName
          })
          .FirstOrDefault();
      Console.WriteLine($"{student2.fName} {student2.lName}'s GPA = {student2.average}");

      Console.WriteLine("\nFind the student with the highest average grade");
      var student3 = db.Students.Include(student => student.Grades)
          .OrderByDescending(student => student.Grades.Average(grade => (float)grade.Value)).FirstOrDefault();
      Console.WriteLine($"{student3.FirstName} {student3.LastName} has the highest GPA");

      Console.WriteLine("\nFind the student student with the highest number of courses");
      var student4 = db.Students.Include(student => student.Grades)
          .OrderByDescending(student => student.Grades.Count).FirstOrDefault();
      Console.WriteLine($"{student4.FirstName} {student4.LastName} the most number of courses");

      Console.Out.WriteLine("\nFind the student that is taking not courses");
      var student5 = db.Students.Include(student => student.Grades)
          .FirstOrDefault(student => student.Grades.Count == 0);
      Console.Out.WriteLine($"{student5.FirstName} {student5.LastName} is taking no courses");

      Console.Out.WriteLine("\nFind the number of Freshmen");
      var freshmenCount = db.Students.Count(student => student.Classification == Student.Class.Freshman);
      Console.Out.WriteLine($"The number of Freshmen is: {freshmenCount}");

      Console.Out.WriteLine("\nFind the number of Sophomores");
      var sophomoreAverages = db.Students.Include(student => student.Grades)
          .Where(student => student.Classification == Student.Class.Sophomore).Select(student =>
              new { Name = student.FirstName, Average = student.Grades.Average(grade => (float)grade.Value) }).ToList();
      sophomoreAverages.ForEach(student => Console.WriteLine($"{student.Name} has an average of {student.Average}"));
    }
  }
}