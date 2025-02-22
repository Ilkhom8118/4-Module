using OnlineLearningPlatform.Dal.Enums;

namespace OnlineLearningPlatform.Dal.Entites;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Roles Role { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}
//User(ID, Name, Email, Role)