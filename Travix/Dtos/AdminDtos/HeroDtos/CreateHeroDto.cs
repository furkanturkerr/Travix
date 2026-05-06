namespace Travix.Dtos.AdminDtos.HeroDtos;

public class CreateHeroDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string SubTitle { get; set; }
    
    public string Card1 { get; set; }
    public string Card2 { get; set; }
    public string Card3 { get; set; }
    
    public bool IsStatus { get; set; }
}