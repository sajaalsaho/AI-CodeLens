using AI_CodeLens.Application.Interfaces;
using AI_CodeLens.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI yapılandırması
builder.Services.AddOpenApi();

// Controller yapılandırması
builder.Services.AddControllers();

// Kod inceleme servisinin kaydedilmesi
builder.Services.AddScoped<ICodeReviewService, CodeReviewService>();

var app = builder.Build();

// HTTP istekleri
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();