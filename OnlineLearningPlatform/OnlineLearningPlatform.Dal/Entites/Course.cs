namespace OnlineLearningPlatform.Dal.Entites;

public class Course
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long InstructorId { get; set; }
    public User Instructor { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Lesson> lessons { get; set; }
}
//Course(ID, Name, Description, InstructorId)