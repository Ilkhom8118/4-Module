namespace ChatBot.Dal.Entities;

public class User
{
    public long BotUserId { get; set; }
    public long TelegramUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public bool Isblocked { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
