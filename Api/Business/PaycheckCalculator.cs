using Api.Business.DeductionRules;
using Api.Models;

namespace Api.Business;

public class PaycheckCalculator
{
    private readonly int _paychecksPerYear;
    private readonly DeductionsCalculator _deductionsCalculator;

    public PaycheckCalculator(int paychecksPerYear, DeductionsCalculator deductionsCalculator)
    {
        _deductionsCalculator = deductionsCalculator;
        _paychecksPerYear = paychecksPerYear;
    }

    public Paycheck CalculatePaycheck(Employee employee)
    {
        // Get deductions per paycheck
        var deductionsPerMonth = _deductionsCalculator.GetDeductionsPerMonth(employee);
        var deductionsPerPaycheck = (deductionsPerMonth * 12) / _paychecksPerYear;
        
        // Get gross amount before deductions per paycheck
        var grossEarnings = employee.Salary / _paychecksPerYear;
        
        // round to nearest cent
        deductionsPerPaycheck = Math.Round(deductionsPerPaycheck, 2);
        grossEarnings = Math.Round(grossEarnings, 2);
        
        var netEarnings = grossEarnings - deductionsPerPaycheck;
        var paycheck = new Paycheck()
        {
            EmployeeId = employee.Id,
            EmployeeName = $"{employee.FirstName} {employee.LastName}",
            GrossEarnings = grossEarnings,
            TotalDeductions = deductionsPerPaycheck,
            NetEarnings = netEarnings
        };
            
        return paycheck;
    }
}