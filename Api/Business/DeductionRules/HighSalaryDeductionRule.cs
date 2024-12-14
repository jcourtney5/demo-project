using Api.Models;

namespace Api.Business.DeductionRules;

public class HighSalaryDeductionRule : IDeductionRule
{
    private readonly decimal _salaryThreshold;
    private readonly decimal _deductionMultiplierPerMonth;

    public HighSalaryDeductionRule(decimal salaryThreshold, decimal deductionMultiplierPerYear)
    {
        _salaryThreshold = salaryThreshold;
        _deductionMultiplierPerMonth = deductionMultiplierPerYear / 12;
    }
    
    public decimal GetDeductionPerMonth(Employee employee)
    {
        decimal deduction = 0;
        if (employee.Salary > _salaryThreshold)
        {
            deduction = employee.Salary * _deductionMultiplierPerMonth;
        }
        return deduction;
    }
}