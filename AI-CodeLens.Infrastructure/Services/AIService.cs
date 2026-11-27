
using System.Net.Http.Json;
using System.Text.Json;
using AI_CodeLens.Application.Interfaces;

namespace AI_CodeLens.Infrastructure.Services;

public class AIService : IAIService
{
    private readonly HttpClient _httpClient;

    public AIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


public async Task<string> AnalyzeCodeAsync(string code)
{
    var prompt = $"""
        Sen deneyimli bir C# yazılım mühendisi ve kod inceleme uzmanısın.

        Aşağıdaki C# kodunu dikkatlice analiz et.
        Yanıtını tamamen Türkçe ver.

        ANALİZ KURALLARI:
        1. Yalnızca kodda gerçekten görülen sorunları belirt.
        2. Olmayan hataları veya riskleri uydurma.
        3. Kesin olmayan durumları kesin hata gibi sunma.
        4. Gereksiz mimari değişiklikler önerme.
        5. C# terminolojisini doğru kullan.
        6. Her bulgu için mümkünse gerçek satır numarasını belirt.
        7. Kodda sorun yoksa bunu açıkça söyle.
        8. Aynı sorunu farklı başlıklarla tekrar etme.

        ANALİZ BAŞLIKLARI:
        - Gerçek hatalar
        - Güvenlik sorunları
        - Kod kalitesi
        - Performans
        - İyileştirme önerileri

        Her bulguyu şu formatta sun:
        Başlık:
        Açıklama:
        Önem: Critical / High / Medium / Low / Info
        Satır:
        Öneri:

        Kod:
        {code}
        """;

    return await SendToAIAsync(prompt);
}


    public async Task<string> GenerateDocumentationAsync(string code)
    {
        var prompt = $"""
            Sen deneyimli bir yazılım dokümantasyon uzmanısın.
            Aşağıdaki C# kodu için Türkçe dokümantasyon oluştur.

            Şunları açıkla:
            1. Kodun genel amacı.
            2. Metotların görevleri.
            3. Parametreler.
            4. Dönüş değerleri.
            5. Kodun çalışma mantığı.

            Kodda bulunmayan özellikleri uydurma.

            Kod:
            {code}
            """;

        return await SendToAIAsync(prompt);
    }

    private async Task<string> SendToAIAsync(string prompt)
    {
        var request = new
        {
            model = "qwen2.5-coder:3b",
            prompt = prompt,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync(
            "/api/generate", request);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();

        return result.GetProperty("response").GetString() ?? "";
    }
}
