namespace Travix.Dtos;

public class HotelListDto
{
    public bool status { get; set; }
    public string message { get; set; }
    public long timestamp { get; set; }
    public Data data { get; set; }
}

public class Data
{
    public List<Hotel> hotels { get; set; }
    public List<Meta> meta { get; set; }
    public List<Appear> appear { get; set; }
}

public class Hotel
{
    public string accessibilityLabel { get; set; }
    public Property property { get; set; }
}

public class Property
{
    public string reviewScoreWord { get; set; }
    public int? accuratePropertyClass { get; set; }
    public int? reviewCount { get; set; }
    public int? ufi { get; set; }
    public bool? isPreferred { get; set; }
    public bool? isFirstPage { get; set; }
    public Checkin checkin { get; set; }
    public int? qualityClass { get; set; }
    public int? rankingPosition { get; set; }
    public double? reviewScore { get; set; }
    public string countryCode { get; set; }
    public int? propertyClass { get; set; }
    public List<string> photoUrls { get; set; }
    public string checkoutDate { get; set; }
    public int? position { get; set; }
    public double? latitude { get; set; }
    public Checkout checkout { get; set; }
    public PriceBreakdown priceBreakdown { get; set; }
    public int? optOutFromGalleryChanges { get; set; }
    public string wishlistName { get; set; }
    public List<string> blockIds { get; set; }
    public string currency { get; set; }
    public string checkinDate { get; set; }
    public int id { get; set; }
    public int? mainPhotoId { get; set; }
    public string name { get; set; }
    public double? longitude { get; set; }
    public bool? isPreferredPlus { get; set; }
}

public class Checkin
{
    public string untilTime { get; set; }
    public string fromTime { get; set; }
}

public class Checkout
{
    public string fromTime { get; set; }
    public string untilTime { get; set; }
}

public class PriceBreakdown
{
    public List<object> benefitBadges { get; set; }
    public GrossPrice grossPrice { get; set; }
    public List<object> taxExceptions { get; set; }
    public StrikethroughPrice strikethroughPrice { get; set; }
}

public class GrossPrice
{
    public string currency { get; set; }
    public double? value { get; set; }
}

public class StrikethroughPrice
{
    public double? value { get; set; }
    public string currency { get; set; }
}

public class Meta
{
    public string title { get; set; }
}

public class Appear
{
    public Component component { get; set; }
    public string id { get; set; }
    public string contentUrl { get; set; }
}

public class Component
{
    public Props props { get; set; }
}

public class Props
{
    public bool? fill { get; set; }
    public Content content { get; set; }
    public string title { get; set; }
    public string text { get; set; }
}

public class Content
{
    public Props1 props { get; set; }
}

public class Props1
{
    public bool? fitContentWidth { get; set; }
    public List<Items> items { get; set; }
}

public class Items
{
    public Props2 props { get; set; }
}

public class Props2
{
    public Component1 component { get; set; }
}

public class Component1
{
    public Props3 props { get; set; }
}

public class Props3
{
    public string spacing { get; set; }
    public List<Items1> items { get; set; }
    public string accessibilityLabel { get; set; }
    public string icon { get; set; }
    public string tertiaryTintedColor { get; set; }
    public string variant { get; set; }
}

public class Items1
{
    public Props4 props { get; set; }
}

public class Props4
{
    public List<Text> text { get; set; }
}

public class Text
{
    public string text { get; set; }
    public string font { get; set; }
    public string color { get; set; }
    public List<LinkActions> linkActions { get; set; }
}

public class LinkActions
{
    public Props5 props { get; set; }
}

public class Props5
{
    public string url { get; set; }
}