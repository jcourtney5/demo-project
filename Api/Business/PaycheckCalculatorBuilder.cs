using Api.Business.DeductionRules;

namespace Api.Business;

public class PaycheckCalculatorBuilder
{
    public PaycheckCalculator Build()
    {
        DeductionsCalculator deductionsCalculator = new DeductionsCalculator(new List<IDeductionRule>()
        {
            new BaseDeductionRule(1000m),
            new DependentsDeductionRule(600m),
            new HighSalaryDeductionRule(80000, 0.02m),
            new AgeDeductionRule(50, 200m)
        });

        return new PaycheckCalculator(26, deductionsCalculator);
    }
}