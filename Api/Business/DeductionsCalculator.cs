using Api.Business.DeductionRules;
using Api.Models;

namespace Api.Business;

public class DeductionsCalculator : IDeductionsCalculator
{
    private readonly List<IDeductionRule> _deductionRules;

    public DeductionsCalculator(List<IDeductionRule> deductionRules)
    {
        _deductionRules = deductionRules;
    }

    public decimal GetDeductionPerMonth(Employee employee)
    {
        decimal deductions = 0;

        foreach (var deductionRule in _deductionRules)
        {
            deductions += deductionRule.GetDeductionPerMonth(employee);
        }
        
        return deductions;
    }
}