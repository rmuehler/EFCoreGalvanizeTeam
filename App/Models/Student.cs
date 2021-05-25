using System.Collections.Generic;

namespace EFCoreGalvanizeTeam
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Class Classification { get; set; }
        public List<Grade> Grades { get; set; }

        public enum Class
        {
            Freshman,
            Sophomore,
            Junior,
            Senior
        }
    }
}