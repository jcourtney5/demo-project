using Api.Business.DeductionRules;

namespace UnitTests.DeductionRules;

public class AgeDeductionRuleTests
{
    [Fact]
    public void GetDeductionPerMonth_BelowThreshold_ReturnsZero()
    {
        var ageDeductionRule = new AgeDeductionRule(50, 100m);
        var employee = Utils.CreateTestEmployee(10000m, 40, 0);
        
        var deductionPerMonth = ageDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_EqualToThresholdAmountIsOneHundred_ReturnsOneHundred()
    {
        // If age is equal, we are assuming that counts as them being "over" since they are 
        // technically months, days, minutes, seconds over the age of 50
        
        var ageDeductionRule = new AgeDeductionRule(50, 100m);
        var employee = Utils.CreateTestEmployee(10000m, 50, 0);
        
        var deductionPerMonth = ageDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(100m, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_OverThresholdAmountIsOneHundred_ReturnsOneHundred()
    {
        var ageDeductionRule = new AgeDeductionRule(50, 100m);
        var employee = Utils.CreateTestEmployee(10000m, 51, 0);
        
        var deductionPerMonth = ageDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(100m, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_OverThresholdAmountIsTwoHundred_ReturnsTwoHundred()
    {
        var ageDeductionRule = new AgeDeductionRule(50, 200m);
        var employee = Utils.CreateTestEmployee(10000m, 51, 0);
        
        var deductionPerMonth = ageDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(200m, deductionPerMonth);
    }
}