namespace Travix.Dtos.AdminDtos.BlogDtos;

public class ResultBlogDto
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDescription { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreateTime { get; set; }
    public bool IsStatus { get; set; }
}