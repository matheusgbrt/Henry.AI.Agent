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
    private readonly IBaseServiceFactory _baseServiceFactory;

    public DocumentationController(IBaseServiceFactory baseServiceFactory)
    {
        _baseServiceFactory = baseServiceFactory;
    }
    
    [HttpPost]
    [Route("rawcode")]
    public async Task<IActionResult> CreateDocumentationFromRawCode([FromBody] DocumentationRawCodeInputDto input)
    {
        var service = _baseServiceFactory.Get(ActionType.Documentation);
        var response = await service.BaseAction(input.Code);

        if (!string.IsNullOrEmpty(response))
        {
            return Ok(new DocumentationRawCodeOutputDto(response));
        }
        return UnprocessableEntity();
    }
    
}