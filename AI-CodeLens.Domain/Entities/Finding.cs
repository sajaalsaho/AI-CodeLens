namespace AI_CodeLens.Domain.Entities;

public class Finding
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Severity { get; set; } = string.Empty;

    public int LineNumber { get; set; }

    public string Recommendation { get; set; } = string.Empty;
}