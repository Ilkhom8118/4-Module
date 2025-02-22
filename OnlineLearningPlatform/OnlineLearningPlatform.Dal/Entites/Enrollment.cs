namespace OnlineLearningPlatform.Dal.Entites;

public class Enrollment
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
//Enrollment(ID, UserId, CourseId, EnrollmentDate)