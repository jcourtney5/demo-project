using Api.Models;

namespace Api.Business.DeductionRules;

public class HighSalaryDeductionRule : IDeductionRule
{
    private readonly decimal _salaryThreshold;
    private readonly decimal _deductionMultiplier;

    public HighSalaryDeductionRule(decimal salaryThreshold, decimal deductionMultiplier)
    {
        _salaryThreshold = salaryThreshold;
        _deductionMultiplier = deductionMultiplier;
    }
    
    public decimal GetDeductionPerMonth(Employee employee)
    {
        decimal deduction = 0;
        if (employee.Salary > _salaryThreshold)
        {
            deduction = employee.Salary * _deductionMultiplier;
        }
        return deduction;
    }
}