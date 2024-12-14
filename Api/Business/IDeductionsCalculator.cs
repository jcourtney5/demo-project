using Api.Models;

namespace Api.Business;

public interface IDeductionsCalculator
{
    decimal GetDeductionPerMonth(Employee employee);
}