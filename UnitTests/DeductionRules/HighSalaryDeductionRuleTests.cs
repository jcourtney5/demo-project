using Api.Business.DeductionRules;

namespace UnitTests.DeductionRules;

public class HighSalaryDeductionRuleTests
{
    [Fact]
    public void GetDeductionPerMonth_BelowSalaryThreshold_ReturnsZero()
    {
        var highSalaryDeductionRule = new HighSalaryDeductionRule(20000m, 0.12m);
        var employee = Utils.CreateTestEmployee(10000m, 30, 0);
        
        var deductionPerMonth = highSalaryDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_EqualsSalaryThresholdOnePercentMultiplier_ReturnsZero()
    {
        var highSalaryDeductionRule = new HighSalaryDeductionRule(20000m, 0.12m);
        var employee = Utils.CreateTestEmployee(20000m, 30, 0);
        
        var deductionPerMonth = highSalaryDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_AboveSalaryThresholdOnePercentMultiplier_ReturnsFourHundred()
    {
        var highSalaryDeductionRule = new HighSalaryDeductionRule(20000m, 0.12m);
        var employee = Utils.CreateTestEmployee(40000m, 30, 0);
        
        var deductionPerMonth = highSalaryDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(400m, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_AboveSalaryThresholdFivePercentMultiplier_ReturnsTwoThousand()
    {
        var highSalaryDeductionRule = new HighSalaryDeductionRule(20000m, 0.6m);
        var employee = Utils.CreateTestEmployee(40000m, 30, 0);
        
        var deductionPerMonth = highSalaryDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(2000m, deductionPerMonth);
    }
}