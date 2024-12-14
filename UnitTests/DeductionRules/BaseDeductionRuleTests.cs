using Api.Business.DeductionRules;
using Api.Models;

namespace UnitTests.DeductionRules;

public class BaseDeductionRuleTests
{
    [Fact]
    public void GetDeductionPerMonth_BaseAmountOneThousand_ReturnsOneThousand()
    {
        var baseDeductionRule = new BaseDeductionRule(1000m);
        var employee = Utils.CreateTestEmployee(52000m, 30);
        
        var deductionPerMonth = baseDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(1000m, deductionPerMonth);
    }
}