using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WebAPI.Services;

public class OpenAIService : IOpenAIService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public OpenAIService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> CreateMessageWithOpenAIAsync(string message)
    {
        var apiKey = _configuration["OpenAIKey:Key"];

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new Exception("OpenAI API key bulunamadı.");

        if (string.IsNullOrWhiteSpace(message))
            throw new Exception("Mesaj boş olamaz.");

        var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = @"Sen Travix adlı otel arama ve rezervasyon platformunun müşteri destek temsilcisisin.

Kullanıcının mesajına e-posta olarak gönderilecek profesyonel bir yanıt hazırla.

Kurallar:
- Cevap Türkçe olsun.
- E-posta formatında yaz.
- Samimi ama kurumsal bir dil kullan.
- Kullanıcıya adıyla hitap etme, çünkü isim bilinmiyor.
- Gereksiz uzun yazma.
- Sorunu anladığını belirt.
- Çözüm önerilerini net şekilde ver.
- Sonunda Travix ekibi adına kapanış yap.

Format:
Merhaba,

[yanıt metni]

Saygılarımızla,
Travix Destek Ekibi"
                },
                new
                {
                    role = "user",
                    content = message
                }
            }
        };

        var response = await client.PostAsJsonAsync(
            "https://api.openai.com/v1/chat/completions",
            requestBody
        );

        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(responseBody);

        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

        return result?.choices?.FirstOrDefault()?.message?.content
               ?? "Yanıt oluşturulamadı.";
    }
}

public class OpenAIResponse
{
    public List<Choice> choices { get; set; }
}

public class Choice
{
    public OpenAIMessage message { get; set; }
}

public class OpenAIMessage
{
    public string role { get; set; }
    public string content { get; set; }
}