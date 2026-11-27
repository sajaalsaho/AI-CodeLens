
using Microsoft.AspNetCore.Mvc;
using AI_CodeLens.Application.Interfaces;

namespace AI_CodeLens.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CodeDocumentationController : ControllerBase
{
    private readonly IAIService _aiService;

    public CodeDocumentationController(IAIService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost]
    public async Task<IActionResult> GenerateDocumentation(
        [FromBody] DocumentationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return BadRequest("Belgelenecek kod boş olamaz.");
        }

        var documentation = await _aiService.GenerateDocumentationAsync(
            request.Code);

        return Ok(new
        {
            Documentation = documentation
        });
    }
}

public class DocumentationRequest
{
    public string Code { get; set; } = string.Empty;
}
