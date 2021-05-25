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

    }
  }
}