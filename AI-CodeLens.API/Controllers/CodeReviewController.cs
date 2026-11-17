using Microsoft.AspNetCore.Mvc;
using AI_CodeLens.Application.DTOs;
using AI_CodeLens.Application.Interfaces;

namespace AI_CodeLens.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CodeReviewController : ControllerBase
{
    private readonly ICodeReviewService _codeReviewService;

    public CodeReviewController(ICodeReviewService codeReviewService)
    {
        _codeReviewService = codeReviewService;
    }

    [HttpPost]
    public async Task<ActionResult<ReviewResponse>> ReviewCode(
        [FromBody] ReviewRequest request)
    {
        var session = await _codeReviewService.ReviewCodeAsync(request.Code);

        var response = new ReviewResponse
        {
            ReviewSessionId = session.Id,
            Status = session.Status,
            Findings = session.Findings
        };

        return Ok(response);
    }
}