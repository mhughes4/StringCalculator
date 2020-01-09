using NUnit.Framework;
using StringCalculator;

namespace Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddingNumbers_WhenNoNumbersAreSpecified_IsZero()
        {
            var calc = new Calculator();
            var result = calc.Add(string.Empty);
            Assert.That(result, Is.Zero);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("99", 99)]
        public void AddingNumbers_WhenSingleNumberIsSpecified_IsNumberSpecified(string input, int expectedResult)
        {
            var calc = new Calculator();
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("1,1", 2)]
        [TestCase("2,2", 4)]
        [TestCase("99,99", 198)]
        public void AddingNumbers_WhenTwoNumbersAreSpecified_IsSumOfNumbers(string input, int expectedResult)
        {
            var calc = new Calculator();
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}