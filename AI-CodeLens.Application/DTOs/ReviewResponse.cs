using AI_CodeLens.Domain.Entities;

namespace AI_CodeLens.Application.DTOs;

public class ReviewResponse
{
    public int ReviewSessionId { get; set; }

    public string Status { get; set; } = string.Empty;

    public List<Finding> Findings { get; set; } = new();
}