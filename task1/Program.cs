using task1.Data;
using task1.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var database = new ApplicationDbContext())
        {
            database.Database.EnsureCreated();

            //Create
            AddData(database);

            //Read
            var studentQuery = from st in database.Students
                               where st.Name == "Alan"
                               select st;

            var student = studentQuery.FirstOrDefault();

            var gredeQuery = from g in database.Grades
                             where g.Student == student
                             select g;

            var grade = gredeQuery.FirstOrDefault();

            //Update
            student.Email = "wake@gmail.com";

            //Delete
            database.Remove(grade);
            database.SaveChanges();

        }
    }

    private static void AddData(ApplicationDbContext database)
    {
        var student = new Student
        {
            Name = "Alan",
            Surname = "Wake",
            Email = "alan@gmail.com",
        };

        var teacher = new Teacher
        {
            Name = "Garison",
            Surname = "Ford",
            Email = "ford@gmail.com",
        };

        var course = new Course
        {
            Name = "Survival",
            Description = null,
            Teacher = teacher,
            Students = new List<Student> { student }
        };

        var grade = new Grade
        {
            Course = course,
            GradeValue = 5,
            Student = student,
        };

        database.Add(student);
        database.Add(teacher);
        database.Add(course);
        database.Add(grade);

        database.SaveChanges();
    }
}