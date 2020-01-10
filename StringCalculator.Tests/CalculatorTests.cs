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
        [TestCase("1,1,1", 3)]
        [TestCase("2,2,2", 6)]
        [TestCase("99,99,99", 297)]
        [TestCase("1,1,1,1", 4)]
        [TestCase("2,2,2,2", 8)]
        [TestCase("99,99,99,99", 396)]
        public void AddingNumbers_WhenMultipleNumbersAreSpecified_IsSumOfNumbers(string input, int expectedResult)
        {
            var calc = new Calculator();
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("1\n1", 2)]
        [TestCase("2\n2", 4)]
        [TestCase("99\n99", 198)]
        [TestCase("1\n1,1", 3)]
        [TestCase("2\n2,2", 6)]
        [TestCase("99\n99,99", 297)]
        [TestCase("1\n1\n1,1", 4)]
        [TestCase("2\n2\n2,2", 8)]
        [TestCase("99\n99\n99,99", 396)]
        public void AddingNumbers_WhenUsingNewLineDelimiters_IsSumOfNumbers(string input, int expectedResult)
        {
            var calc = new Calculator();
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddingNumbers_WhenChangingDelimiter_IsSumOfNumbers()
        {
            var calc = new Calculator();
            var result = calc.Add("//;\n1;2");
            Assert.That(result, Is.EqualTo(3));
        }
    }
}