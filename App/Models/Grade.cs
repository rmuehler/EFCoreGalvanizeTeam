namespace EFCoreGalvanizeTeam
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public decimal Value { get; set; }
        public Student Student { get; set; }
    }
}