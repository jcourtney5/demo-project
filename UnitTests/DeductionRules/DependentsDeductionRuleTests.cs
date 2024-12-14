using Api.Business.DeductionRules;
using Api.Models;

namespace UnitTests.DeductionRules;

public class DependentsDeductionRuleTests
{
    [Fact]
    public void GetDeductionPerMonth_NoDependentsNoPartner_ReturnsZero()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_NoDependentsWithSpouse_ReturnsZero()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        Utils.AddPartner(employee, Relationship.Spouse);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_NoDependentsWithDomesticPartner_ReturnsZero()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 0);
        Utils.AddPartner(employee, Relationship.DomesticPartner);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(0, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_TwoDependentsOneHundredEachNoPartner_ReturnsTwoHundred()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 2);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(200, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_TwoDependentsFiveHundredEachNoPartner_ReturnsOneThousand()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(500m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 2);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(1000, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_TwoDependentsOneHundredEachWithSpouse_ReturnsTwoHundred()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 2);
        Utils.AddPartner(employee, Relationship.Spouse);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(200, deductionPerMonth);
    }
    
    [Fact]
    public void GetDeductionPerMonth_TwoDependentsOneHundredEachWithDomesticPartner_ReturnsTwoHundred()
    {
        var dependentsDeductionRule = new DependentsDeductionRule(100m);
        var employee = Utils.CreateTestEmployee(52000m, 30, 2);
        Utils.AddPartner(employee, Relationship.DomesticPartner);
        
        var deductionPerMonth = dependentsDeductionRule.GetDeductionPerMonth(employee);
        
        Assert.Equal(200, deductionPerMonth);
    }
}