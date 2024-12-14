using Api.Models;

namespace Api.Business.DeductionRules;

public class BaseDeductionRule : IDeductionRule
{
    private readonly decimal _baseAmountPerMonth;

    public BaseDeductionRule(decimal baseAmountPerMonth)
    {
        _baseAmountPerMonth = baseAmountPerMonth;
    }
    
    public decimal GetDeductionPerMonth(Employee employee)
    {
        return _baseAmountPerMonth;
    }
}