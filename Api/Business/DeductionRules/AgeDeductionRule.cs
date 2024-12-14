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
        // Get age as of today for this calculation which is flawed and needs to be fixed
        // For future it would be better to pass the date for the specific paycheck
        // and use that date to get age and deduction
        
        var age = employee.GetAgeAsOfToday();
      
        // Another assumption here, assuming if they are equal to the age, then it counts as "over"
        // since they are days, weeks, months, minutes "over" the age of 50
        
        return age >= _ageThreshold ? _deductionAmount : 0m;
    }
}