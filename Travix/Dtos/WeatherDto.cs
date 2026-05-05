namespace Travix.Dtos;

public class WeatherDto
{
    public Main Main { get; set; }
    public List<Weather> Weather { get; set; }
}

public class Main
{
    public double Temprature { get; set; }  // API'de yazım hatası var, aynı bırak
}

public class Weather
{
    public string Description { get; set; }
}