using Api.Models;

namespace Api.Business.DeductionRules;

public interface IDeductionRule
{
    decimal GetDeductionPerMonth(Employee employee);
}