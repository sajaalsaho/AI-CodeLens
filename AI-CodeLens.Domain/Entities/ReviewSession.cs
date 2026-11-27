
namespace AI_CodeLens.Domain.Entities;

public class ReviewSession
{
    public int Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";

    public List<Finding> Findings { get; set; } = new();
}
