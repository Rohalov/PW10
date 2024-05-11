
namespace task1.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
