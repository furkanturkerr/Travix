namespace WebAPI.Entites;

public class HotelList
{
    public int HotelListId { get; set; }

    public string HomeHotelCity { get; set; } = "milano";
    public string HomeHotelCurrency { get; set; } = "EUR";
    public string HomeHotelLanguage { get; set; } = "en-us";
    public int HomeHotelAdults { get; set; } = 2;
    public string HomeHotelRoom { get; set; } = "1";
}