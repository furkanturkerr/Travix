namespace Travix.Dtos.AdminDtos.AboutDtos;

public class CreateAboutDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Features1 { get; set; }
    public string Features2 { get; set; }
    public string Features3 { get; set; }
    public string Features4 { get; set; }
    public string ImageUrl { get; set; }
    public bool IsStatus { get; set; }
}