namespace OnlineLearningPlatform.Dal.Entites;

public class Lesson
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string VideoURL { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
}
//Lesson(ID, Title, VideoURL, CourseId)