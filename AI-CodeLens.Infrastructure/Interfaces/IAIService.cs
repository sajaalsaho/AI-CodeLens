namespace AI_CodeLens.Infrastructure.Interfaces;

public interface IAIService
{
    Task<string> AnalyzeCodeAsync(string code);
}