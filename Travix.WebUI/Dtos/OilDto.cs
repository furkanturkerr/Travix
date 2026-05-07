public class OilDto
{
    public bool Success { get; set; }
    public List<OilResult> Result { get; set; }
}

public class OilResult
{
    public string Gasoline { get; set; }
    public string Country { get; set; }
}