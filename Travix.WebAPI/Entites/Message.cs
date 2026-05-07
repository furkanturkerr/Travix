namespace WebAPI.Entites;

public class Message
{
    public int MessageId { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Messages { get; set; }
    public string? MessageAI { get; set; }
    public bool IsRead { get; set; }
}