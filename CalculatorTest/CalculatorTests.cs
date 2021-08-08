using NUnit.Framework;
using SimpleCalculator;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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

        [Test]
        [TestCase(10.3, 0, 10.3)]
        [TestCase(-10, 10, -20)]
        public void MinusTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('-'));
        }

        [Test]
        [TestCase(10.3, 0, 0)]
        [TestCase(-10, 10, -100)]
        public void MultiplyTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('*'));
        }

        [Test]
        [TestCase(10.4, 2, 5.2)]
        [TestCase(-10, 10, -1)]
        public void DivideTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('/'));
        }

        [Test]
        [TestCase(2, 0, double.PositiveInfinity)]
        public void DivideByZeroTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('/'));
        }

        [Test]
        [TestCaseSource(nameof(DataSource))]
        public void WithInputFileTest(double a, double b, double result)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(result, calculator.Calculate('+'));
        }

        private static IEnumerable<double[]> DataSource()
        {
            var data = ReadFromTestData("CalculatorData.txt");
            List<double[]> result = new List<double[]>(); 
            foreach (var line in data.Split(Environment.NewLine).Skip(1))
            {
                var lineData = line.Split(",").Select(x=>double.Parse(x)).ToArray();
                result.Add(lineData);
            }

            return result;

        }

        private static string ReadFromTestData(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("CalculatorTest.TestData." + fileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


    }
}