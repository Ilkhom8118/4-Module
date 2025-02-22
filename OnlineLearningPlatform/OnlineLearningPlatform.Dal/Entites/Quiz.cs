namespace OnlineLearningPlatform.Dal.Entites;

public class Quiz
{
    public long Id { get; set; }
    public string Title { get; set; }
    public long CourseId { get; set; }
    public ICollection<Question> Questions { get; set; }
}
//Quiz(ID, Title, CourseId, Questions)