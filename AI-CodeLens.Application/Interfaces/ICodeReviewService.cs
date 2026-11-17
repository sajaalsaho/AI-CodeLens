using AI_CodeLens.Domain.Entities;

namespace AI_CodeLens.Application.Interfaces;

public interface ICodeReviewService
{
    Task<ReviewSession> ReviewCodeAsync(string code);
}