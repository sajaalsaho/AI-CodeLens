
using System.Threading;
using AI_CodeLens.Domain.Entities;
using AI_CodeLens.Application.Interfaces;

namespace AI_CodeLens.Application.Services;

public class CodeReviewService : ICodeReviewService
{
    private readonly IAIService _aiService;


    public CodeReviewService(IAIService aiService)
    {
        _aiService = aiService;
    }

    public async Task<ReviewSession> ReviewCodeAsync(string code, string? fileName)
    {
string finalFileName = string.IsNullOrWhiteSpace(fileName)
    ? "Yeni dosya"
    : fileName.Trim();

        var session = new ReviewSession
        {
            FileName = finalFileName,
            Code = code,
            CreatedAt = DateTime.UtcNow,
            Status = "Completed"
        };

        if (string.IsNullOrWhiteSpace(code))
        {
            session.Findings.Add(new Finding
            {
                Title = "Boş Kod",
                Description = "İncelenecek kod girilmemiş.",
                Severity = "High",
                LineNumber = 0,
                Recommendation = "Lütfen incelemek için kod girin."
            });

            return session;
        }

        var lines = code.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length > 120)
            {
                session.Findings.Add(new Finding
                {
                    Title = "Uzun Kod Satırı",
                    Description = "Kod satırı 120 karakterden uzun.",
                    Severity = "Low",
                    LineNumber = i + 1,
                    Recommendation = "Kod satırını daha okunabilir olacak şekilde düzenleyin."
                });
            }

            if (lines[i].Contains("TODO"))
            {
                session.Findings.Add(new Finding
                {
                    Title = "Tamamlanmamış Kod",
                    Description = "Kod satırında TODO ifadesi bulundu.",
                    Severity = "Medium",
                    LineNumber = i + 1,
                    Recommendation = "TODO ifadesiyle belirtilen işi tamamlayın."
                });
            }
        }

        var aiAnalysis = await _aiService.AnalyzeCodeAsync(code);

        session.Findings.Add(new Finding
        {
            Title = "Yapay Zekâ Kod Analizi",
            Description = aiAnalysis,
            Severity = "Info",
            LineNumber = 0,
            Recommendation = "Yapay zekâ tarafından sunulan önerileri inceleyin."
        });

        return session;
    }
}
