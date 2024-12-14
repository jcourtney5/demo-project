using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Dtos.Employee;
using Api.Dtos.GetPaycheckDto;
using Xunit;

namespace ApiTests.IntegrationTests;

public class PaycheckIntegrationTests : IntegrationTest
{
    [Fact]
    public async Task WhenAskedForAnEmployeesPaycheck1_ShouldReturnCorrectPaycheck()
    {
        var response = await HttpClient.GetAsync("/api/v1/paychecks?employeeId=1");
        var paycheck = new GetPaycheckDto()
        {
            EmployeeId = 1,
            EmployeeName = "LeBron James",
            GrossEarnings = 2900.80m,
            TotalDeductions = 461.54m,
            NetEarnings = 2439.26m
        };
        await response.ShouldReturn(HttpStatusCode.OK, paycheck);
    }
    
    [Fact]
    public async Task WhenAskedForAnEmployeesPaycheck2_ShouldReturnCorrectPaycheck()
    {
        var response = await HttpClient.GetAsync("/api/v1/paychecks?employeeId=2");
        var paycheck = new GetPaycheckDto()
        {
            EmployeeId = 2,
            EmployeeName = "Ja Morant",
            GrossEarnings = 3552.50m,
            TotalDeductions = 1086.43m,
            NetEarnings = 2466.07m
        };
        await response.ShouldReturn(HttpStatusCode.OK, paycheck);
    }
    
    [Fact]
    public async Task WhenAskedForAnEmployeesPaycheck3_ShouldReturnCorrectPaycheck()
    {
        var response = await HttpClient.GetAsync("/api/v1/paychecks?employeeId=3");
        var paycheck = new GetPaycheckDto()
        {
            EmployeeId = 3,
            EmployeeName = "Michael Jordan",
            GrossEarnings = 5508.12m,
            TotalDeductions = 664.01m,
            NetEarnings = 4844.11m
        };
        await response.ShouldReturn(HttpStatusCode.OK, paycheck);
    }
   
    [Fact]
    public async Task WhenAskedForANonexistentEmployeePaycheck_ShouldReturn404()
    {
        var response = await HttpClient.GetAsync($"/api/v1/paychecks?employeeId={int.MinValue}");
        await response.ShouldReturn(HttpStatusCode.NotFound);
    }
}