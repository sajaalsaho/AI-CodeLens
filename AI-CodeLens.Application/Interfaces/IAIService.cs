
namespace AI_CodeLens.Application.Interfaces;

public interface IAIService
{
    Task<string> AnalyzeCodeAsync(string code);
    Task<string> GenerateDocumentationAsync(string code);

}
