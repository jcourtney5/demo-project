namespace Api.Models;

public class Paycheck
{
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public decimal GrossEarnings { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetEarnings { get; set; }
}