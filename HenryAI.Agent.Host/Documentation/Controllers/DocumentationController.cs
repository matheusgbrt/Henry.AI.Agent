using HenryAI.Agent.Host.Documentation.Dtos;
using HenryAI.Agent.Host.Documentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HenryAI.Agent.Host.Documentation.Controllers;
[Route("/documentation")]
public class DocumentationController : ControllerBase
{
    private readonly IDocumentationService _documentationService;

    public DocumentationController(IDocumentationService documentationService)
    {
        _documentationService = documentationService;
    }


    [HttpPost]
    [Route("rawcode")]
    public async Task<IActionResult> CreateDocumentationFromRawCode([FromBody] DocumentationRawCodeInputDto input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await _documentationService.DocumentRawCode(input.Code);

        if (!string.IsNullOrEmpty(response))
        {
            return Ok(new DocumentationRawCodeOutputDto(response));
        }
        return UnprocessableEntity();
    }
    
}