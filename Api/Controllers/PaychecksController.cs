using Api.Business;
using Api.Data;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Dtos.GetPaycheckDto;
using Api.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaychecksController : ControllerBase
{
    private readonly EmployeeData _data;
    private readonly PaycheckCalculator _calculator;

    public PaychecksController(EmployeeData data, PaycheckCalculatorBuilder calcBuilder)
    {
        _data = data;
        _calculator = calcBuilder.Build();
    }

    [SwaggerOperation(Summary = "Gets a sample paycheck for an employee with the given id")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<GetPaycheckDto>>> Get(int id)
    {
        // Get data from EmployeeData abstraction layer
        var employee = await _data.GetEmployeeByIdAsync(id);

        // Check if employee is not found
        if (employee is null)
        {
            // Return 404 not found result
            var notFoundResult = new ApiResponse<GetPaycheckDto>
            {
                Success = false,
                Error = "Employee not found",
            };
            return NotFound(notFoundResult);
        }

        // Calculate a sample paycheck for the employee
        var paycheck = _calculator.CalculatePaycheck(employee);
        
        // Use Mapster to map to Dtos
        var getPaycheckDto = paycheck.Adapt<GetPaycheckDto>();

        var result = new ApiResponse<GetPaycheckDto>
        {
            Data = getPaycheckDto,
            Success = true
        };

        return Ok(result);
    }
}
