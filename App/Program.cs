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
      foreach(var student in db.Students){
        Console.WriteLine($"{student.FirstName} {student.LastName}");
      }

      Console.WriteLine("\nShow Don Julio's grades!");
      var student1 = db.Students.Include(student => student.Grades).Where(student => student.FirstName == "Don").FirstOrDefault();
      student1.Grades.ToList().ForEach(grade => Console.WriteLine($"{grade.Value}") );

      Console.WriteLine("\nGiven a student's name find their average grade among all their courses");
      var student2 = db.Students.Include(student => student.Grades).Where(student => student.FirstName == "Jack").FirstOrDefault();
      var gpa = student2.Grades.Average(grade => grade.Value);
      Console.WriteLine($"Jack Daniel's GPA = {gpa}");

      Console.WriteLine("\n Find the student with the highest average grade");
      var student3 = db.Students.Include(student => student.Grades).OrderByDescending(student => student.Grades.Average(grade => (float)grade.Value)).FirstOrDefault();
      Console.WriteLine($"{student3.FirstName} {student3.LastName} has the highest GPA");
    }
  }
}