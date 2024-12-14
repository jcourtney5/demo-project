using Api.Business;
using Api.Business.DeductionRules;
using Api.Models;
using Moq;

namespace UnitTests;

public class DeductionsCalculatorTests
{
    [Fact]
    public void GetDeductionPerMonth_NoDeductionRules_ReturnsZero()
    {
        var deductionsCalculator = new DeductionsCalculator(new List<IDeductionRule>());
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        
        var deductionPerMonth = deductionsCalculator.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_OneDeductionRuleFiveHundred_ReturnsFiveHundred()
    {
        var deductionRule1Mock = new Mock<IDeductionRule>();
        deductionRule1Mock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(500m);
        
        var deductionRules = new List<IDeductionRule>()
        {
            deductionRule1Mock.Object
        };
        
        var deductionsCalculator = new DeductionsCalculator(deductionRules);
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        
        var deductionPerMonth = deductionsCalculator.GetDeductionPerMonth(employee);
        
        Assert.Equal(500m, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_ThreeDeductionRulesFiveHundredEach_ReturnsFifteenHundred()
    {
        var deductionRule1Mock = new Mock<IDeductionRule>();
        deductionRule1Mock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(500m);
        var deductionRule2Mock = new Mock<IDeductionRule>();
        deductionRule2Mock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(500m);
        var deductionRule3Mock = new Mock<IDeductionRule>();
        deductionRule3Mock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(500m);
        
        var deductionRules = new List<IDeductionRule>()
        {
            deductionRule1Mock.Object,
            deductionRule2Mock.Object,
            deductionRule3Mock.Object
        };
        
        var deductionsCalculator = new DeductionsCalculator(deductionRules);
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        
        var deductionPerMonth = deductionsCalculator.GetDeductionPerMonth(employee);
        
        Assert.Equal(1500m, deductionPerMonth);
    }
}