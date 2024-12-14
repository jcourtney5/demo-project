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
public class EmployeesController : ControllerBase
{
    private readonly EmployeeData _data;

    public EmployeesController(EmployeeData data)
    {
        _data = data;
    }
    
    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        // Get data from EmployeeData abstraction layer
        var employee = await _data.GetEmployeeByIdAsync(id);

        // Check if employee is not found
        if (employee is null)
        {
            // Return 404 not found result
            var notFoundResult = new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Error = "Employee not found",
            };
            return NotFound(notFoundResult);
        }
        
        // Use Mapster to map to Dtos
        var getEmployeeDto = employee.Adapt<GetEmployeeDto>();
        
        var result = new ApiResponse<GetEmployeeDto>
        {
            Data = getEmployeeDto,
            Success = true
        };

        return Ok(result);
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        // Get data from EmployeeData abstraction layer
        var employees = await _data.GetEmployeesAsync();

        // Use Mapster to map to Dtos
        var getEmployeeDtoList = employees.Adapt<List<GetEmployeeDto>>();
        
        var result = new ApiResponse<List<GetEmployeeDto>>
        {
            Data = getEmployeeDtoList,
            Success = true
        };

        return Ok(result);
    }
}
