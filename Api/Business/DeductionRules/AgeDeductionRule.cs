using Api.Models;

namespace Api.Business.DeductionRules;

public class AgeDeductionRule : IDeductionRule
{
    private readonly int _ageThreshold;
    private readonly decimal _deductionAmount;

    public AgeDeductionRule(int ageThreshold, decimal deductionAmount)
    {
        _ageThreshold = ageThreshold;
        _deductionAmount = deductionAmount;
    }

    public decimal GetDeductionPerMonth(Employee employee)
    {
        // Calculate Age as of Today
        var age = DateTime.Today.Year - employee.DateOfBirth.Year;
        if (employee.DateOfBirth > DateTime.Today.AddYears(-age)) age--;
      
        return age >= _ageThreshold ? _deductionAmount : 0m;
    }
}