using NUnit.Framework;
using SimpleCalculator;

namespace CalculatorTest
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase (10.3, 0, 10.3)]
        [TestCase (-10, 10, 0)]
        public void AdditionTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('+'));
        }


    }
}