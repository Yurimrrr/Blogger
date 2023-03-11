using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blogger.Extensions.WebAPI.Base;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors).ToList();
        if (errors.Any())
        {
            errors.ForEach(error => AddError(error.ErrorMessage));
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }
        
        return modelState.IsValid 
            ? Ok() 
            : BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", _errors.ToArray() }
                }));
    }
    
    protected ActionResult CustomResponse(ValidationResult? result = null)
    {
        if (result == null)
            return NotFound();
            
        if (result.IsValid)
            return Ok(result);
        
        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", _errors.ToArray() }
        }));
    }

    protected bool IsOperationValid()
    {
        return !_errors.Any();
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }

    protected void ClearErrors()
    {
        _errors.Clear();
    }
}