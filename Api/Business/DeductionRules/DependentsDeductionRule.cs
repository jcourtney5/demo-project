using Api.Models;

namespace Api.Business.DeductionRules;

public class DependentsDeductionRule : IDeductionRule
{
    private readonly decimal _deductionPerDependent;

    public DependentsDeductionRule(decimal deductionPerDependent)
    {
        _deductionPerDependent = deductionPerDependent;
    }
    
    public decimal GetDeductionPerMonth(Employee employee)
    {
        // Making assumption here that only children count as additional dependent deduction per month
        // and spouse and domestic partner are covered in base deduction
        
        int numberOfDependents = employee.GetNumberOfChildren();
        return numberOfDependents * _deductionPerDependent;
    }
}