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
        int numberOfDependents = employee.Dependents.Count;
        return numberOfDependents * _deductionPerDependent;
    }
}