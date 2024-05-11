
namespace task1.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set;}
    }
}
