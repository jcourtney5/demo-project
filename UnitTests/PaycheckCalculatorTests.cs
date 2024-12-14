using Api.Business;
using Api.Models;
using Moq;

namespace UnitTests;

public class PaycheckCalculatorTests
{
    [Fact]
    public void CalculatePaycheck_OneThousandMonthlyOneHundredDeductionPerMonth_ReturnsValidPaycheck()
    {
        var deductionsCalculatorMock = new Mock<IDeductionsCalculator>();
        deductionsCalculatorMock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(100m);
        int paychecksPerYear = 12;
        
        var paycheckCalculator = new PaycheckCalculator(paychecksPerYear, deductionsCalculatorMock.Object);
        var employee = Utils.CreateTestEmployee(1000m * paychecksPerYear, 30, 0);
        
        var paycheck = paycheckCalculator.CalculatePaycheck(employee);
        
        Assert.Equal(1000m, paycheck.GrossEarnings);
        Assert.Equal(100m, paycheck.TotalDeductions);
        Assert.Equal(900m, paycheck.NetEarnings);
    }
    
    [Fact]
    public void CalculatePaycheck_OneThousandMonthlyZeroDeductionPerMonth_ReturnsValidPaycheck()
    {
        var deductionsCalculatorMock = new Mock<IDeductionsCalculator>();
        deductionsCalculatorMock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(0);
        int paychecksPerYear = 12;
        
        var paycheckCalculator = new PaycheckCalculator(paychecksPerYear, deductionsCalculatorMock.Object);
        var employee = Utils.CreateTestEmployee(1000m * paychecksPerYear, 30, 0);
        
        var paycheck = paycheckCalculator.CalculatePaycheck(employee);
        
        Assert.Equal(1000m, paycheck.GrossEarnings);
        Assert.Equal(0, paycheck.TotalDeductions);
        Assert.Equal(1000m, paycheck.NetEarnings);
    }
    
    [Fact]
    public void CalculatePaycheck_OneThousandBiWeeklyOneHundredDeductionPerMonth_ReturnsValidPaycheck()
    {
        var deductionsCalculatorMock = new Mock<IDeductionsCalculator>();
        deductionsCalculatorMock.Setup(d => d.GetDeductionPerMonth(It.IsAny<Employee>())).Returns(100m);
        int paychecksPerYear = 26;
        
        var paycheckCalculator = new PaycheckCalculator(paychecksPerYear, deductionsCalculatorMock.Object);
        var employee = Utils.CreateTestEmployee(1000m * paychecksPerYear, 30, 0);
        
        var paycheck = paycheckCalculator.CalculatePaycheck(employee);
        
        Assert.Equal(1000m, paycheck.GrossEarnings);
        Assert.Equal(46.15m, paycheck.TotalDeductions);
        Assert.Equal(953.85m, paycheck.NetEarnings);
    }
}