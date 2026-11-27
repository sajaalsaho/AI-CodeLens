
using AI_CodeLens.Application.Interfaces;
using AI_CodeLens.Application.Services;
using AI_CodeLens.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI yapılandırması
builder.Services.AddOpenApi();

// Controller yapılandırması
builder.Services.AddControllers();

// Kod inceleme servisinin kaydedilmesi
builder.Services.AddScoped<ICodeReviewService, CodeReviewService>();

// Yapay zekâ servisinin Ollama'ya bağlanması
builder.Services.AddHttpClient<IAIService, AIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434");
    client.Timeout = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

// HTTP istekleri
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// Web arayüzü için statik dosyalar
app.UseDefaultFiles();
app.UseStaticFiles();

// API Controller'ları
app.MapControllers();

app.Run();
