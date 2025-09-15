using HenryAI.Agent.Host.Documentation.Dtos;
using HenryAI.Agent.Host.Documentation.Services;
using HenryAI.Agent.Host.Services;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace HenryAI.Agent.Host.Documentation.Controllers;
[Route("agent/code/documentation")]
public class DocumentationController : ControllerBase
{
    private readonly IActionServiceFactory _actionServiceFactory;

    public DocumentationController(IActionServiceFactory actionServiceFactory)
    {
        _actionServiceFactory = actionServiceFactory;
    }
    
    [HttpPost]
    [Route("rawcode")]
    public async Task<IActionResult> CreateDocumentationFromRawCode([FromBody] DocumentationRawCodeInputDto input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var service = _actionServiceFactory.Get(ActionType.Documentation);
        var response = await service.BaseAction(input.Code);

        if (!string.IsNullOrEmpty(response))
        {
            return Ok(new DocumentationRawCodeOutputDto(response));
        }
        return UnprocessableEntity();
    }
    
}