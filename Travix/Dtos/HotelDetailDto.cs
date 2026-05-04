namespace Travix.Dtos;

public class HotelDetailDto
{
    public bool status { get; set; }
    public string message { get; set; }
    public long timestamp { get; set; }
    public Data data { get; set; }

    public class Data
    {
        // 🔹 Genel Bilgiler
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        // 🔹 Review
        public int review_nr { get; set; }

        // 🔹 Fiyat
        public ProductPriceBreakdown product_price_breakdown { get; set; }

        // 🔹 Highlight (ikonlu özellikler)
        public List<PropertyHighlight> property_highlight_strip { get; set; }

        // 🔹 Ana özellikler
        public FacilitiesBlock facilities_block { get; set; }

        // 🔹 Galeri (ODA FOTO)
        public Dictionary<string, Room> rooms { get; set; }

        // 🔹 Oda seçenekleri (sağ fiyat kutusu)
        public List<Block> block { get; set; }
    }

    // 🔥 FİYAT
    public class ProductPriceBreakdown
    {
        public GrossAmount gross_amount { get; set; }
        public GrossPerNight gross_amount_per_night { get; set; }
    }

    public class GrossAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
        public string amount_rounded { get; set; }
    }

    public class GrossPerNight
    {
        public string currency { get; set; }
        public double value { get; set; }
        public string amount_rounded { get; set; }
    }

    // 🔥 HIGHLIGHT (üst ikonlar)
    public class PropertyHighlight
    {
        public string name { get; set; }
    }

    // 🔥 FACILITIES
    public class FacilitiesBlock
    {
        public string name { get; set; }
        public List<Facility> facilities { get; set; }
    }

    public class Facility
    {
        public string name { get; set; }
    }

    // 🔥 ROOM (galeri)
    public class Room
    {
        public List<Photo> photos { get; set; }
        public string description { get; set; }
        public List<RoomFacility> facilities { get; set; }
    }

    public class Photo
    {
        public string url_max750 { get; set; }
        public string url_original { get; set; }
    }

    public class RoomFacility
    {
        public string name { get; set; }
    }

    // 🔥 ODA SEÇENEĞİ (SAĞ KART)
    public class Block
    {
        public string room_name { get; set; }
        public string mealplan { get; set; }
        public int refundable { get; set; }
        public int nr_adults { get; set; }

        public PaymentTerms paymentterms { get; set; }
    }

    public class PaymentTerms
    {
        public Cancellation cancellation { get; set; }
    }

    public class Cancellation
    {
        public string type_translation { get; set; }
        public string description { get; set; }
    }
}