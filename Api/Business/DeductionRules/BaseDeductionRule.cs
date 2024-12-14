using Api.Models;

namespace Api.Business.DeductionRules;

public class BaseDeductionRule : IDeductionRule
{
    private readonly decimal _baseAmount;

    public BaseDeductionRule(decimal baseAmount)
    {
        _baseAmount = baseAmount;
    }
    
    public decimal GetDeductionPerMonth(Employee employee)
    {
        return _baseAmount;
    }
}