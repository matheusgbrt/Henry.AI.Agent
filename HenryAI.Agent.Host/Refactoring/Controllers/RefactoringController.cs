using HenryAI.Agent.Host.Documentation.Dtos;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace HenryAI.Agent.Host.Refactoring.Controllers;

[Route("agent/code/refactoring")]
public class RefactoringController : ControllerBase
{
    private readonly IActionServiceFactory _actionServiceFactory;

    public RefactoringController(IActionServiceFactory actionServiceFactory)
    {
        _actionServiceFactory = actionServiceFactory;
    }
    
    [HttpPost]
    [Route("rawcode")]
    public async Task<IActionResult> CreateRefactoring([FromBody] RefactoringRawCodeInputDto input)
    {
        var service = _actionServiceFactory.Get(ActionType.Refactoring);
        var response = await service.BaseAction(input.Code);
        if (!string.IsNullOrEmpty(response))
        {
            return Ok(new RefactoringRawCodeOutputDto(response));
        }
        
        return UnprocessableEntity();
    }
    
}