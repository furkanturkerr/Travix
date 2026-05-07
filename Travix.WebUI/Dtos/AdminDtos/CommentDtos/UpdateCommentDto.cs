namespace Travix.Dtos.AdminDtos.CommentDtos;

public class UpdateCommentDto
{
    public int CommentId { get; set; }
    public string CommantText { get; set; }
    public string NameSurname { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool IsStatus { get; set; }
}