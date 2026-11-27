namespace AI_CodeLens.Application.DTOs;

public class ReviewRequest
{
    public string Code { get; set; } = string.Empty;
    public string? FileName { get; set; }
}