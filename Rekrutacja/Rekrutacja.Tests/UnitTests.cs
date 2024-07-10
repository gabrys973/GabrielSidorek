/*using Rekrutacja.Workers.Calculator;
using Rekrutacja.Workers.Operations;

namespace Rekrutacja.Tests;

public class UnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(20.1, 34.51, Operation.Addition, 20.1 + 34.51)]
    [TestCase(15.2, -41.2, Operation.Addition, 15.2 + -41.2)]
    [TestCase(112.31, 65.23, Operation.Subtraction, 112.31 - 65.23)]
    [TestCase(46.21, 66.21, Operation.Subtraction, 46.21 - 66.21)]
    [TestCase(15.3, 3.2, Operation.Multiplication, 15.3 * 3.2)]
    [TestCase(-23.1, 12.0, Operation.Multiplication, -23.1 * 12.0)]
    [TestCase(132.6, 5.6, Operation.Division, 132.6 / 5.6)]
    [TestCase(-51.12, 3.4, Operation.Division, -51.12 / 3.4)]
    public void CalculatorServiceWillReturnTrueResults(double x, double y, Operation operation, double excpetedResult)
    {
        var result = CalculatorService.Calculate(x, y, operation);

        Assert.AreEqual(excpetedResult, result);
    }

    [Test]
    [TestCase(-51.12, 0, Operation.Division)]
    [TestCase(132.6, 0, Operation.Division)]
    [TestCase(0, 0, Operation.Division)]
    public void DivideByZeroWillThrowException(double x, double y, Operation operation)
    {
        Assert.Throws<DivideByZeroException>(() => CalculatorService.Calculate(4, 0, operation));
    }
}*/