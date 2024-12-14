using Api.Data;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly EmployeeData _data;

    public DependentsController(EmployeeData data)
    {
        _data = data;
    }
    
    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id)
    {
        // Get data from EmployeeData abstraction layer
        var dependent = await _data.GetDependentByIdAsync(id);

        // Check if dependent is not found
        if (dependent is null)
        {
            // Return 404 not found result
            var notFoundResult = new ApiResponse<GetDependentDto>
            {
                Success = false,
                Error = "Dependent not found",
            };
            return NotFound(notFoundResult);
        }
        
        // Use Mapster to map to Dtos
        var getDependentDto = dependent.Adapt<GetDependentDto>();
        
        var result = new ApiResponse<GetDependentDto>
        {
            Data = getDependentDto,
            Success = true
        };

        return Ok(result);
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        // Get data from EmployeeData abstraction layer
        var dependents = await _data.GetDependentsAsync();

        // Use Mapster to map to Dtos
        var getDependentDtoList = dependents.Adapt<List<GetDependentDto>>();
        
        var result = new ApiResponse<List<GetDependentDto>>
        {
            Data = getDependentDtoList,
            Success = true
        };

        return Ok(result);
    }
}
