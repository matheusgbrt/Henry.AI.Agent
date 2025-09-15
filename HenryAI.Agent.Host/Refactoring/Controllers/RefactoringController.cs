using HenryAI.Agent.Host.Documentation.Dtos;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace HenryAI.Agent.Host.Refactoring.Controllers;

[Route("agent/refactoring")]
public class RefactoringController : ControllerBase
{
    private readonly IBaseServiceFactory _baseServiceFactory;

    public RefactoringController(IBaseServiceFactory baseServiceFactory)
    {
        _baseServiceFactory = baseServiceFactory;
    }
    
    [HttpPost]
    [Route("rawcode")]
    public async Task<IActionResult> CreateRefactoring([FromBody] RefactoringRawCodeInputDto input)
    {
        var service = _baseServiceFactory.Get(ActionType.Refactoring);
        var response = await service.BaseAction(input.Code);
        if (!string.IsNullOrEmpty(response))
        {
            return Ok(new RefactoringRawCodeOutputDto(response));
        }
        
        return UnprocessableEntity();
    }
    
}