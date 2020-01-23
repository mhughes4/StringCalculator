using NUnit.Framework;
using StringCalculator;

namespace Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private readonly char[] _defaultDelimiters = new []{',', '\n'};
        private const int DefaultAnswer = 0;

        [Test]
        public void AddingNumbers_WhenNoNumbersAreSpecified_IsZero()
        {
            var calc = new Calculator(DefaultAnswer, _defaultDelimiters);
            var result = calc.Add(string.Empty);
            Assert.That(result, Is.Zero);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("99", 99)]
        public void AddingNumbers_WhenSingleNumberIsSpecified_IsNumberSpecified(string input, int expectedResult)
        {
            var calc = new Calculator(DefaultAnswer, _defaultDelimiters);
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
            var calc = new Calculator(DefaultAnswer, _defaultDelimiters);
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
            var calc = new Calculator(DefaultAnswer, _defaultDelimiters);
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;3", 4)]
        [TestCase("//+\n1+10", 11)]
        [TestCase("//-\n2-10", 12)]
        [TestCase("//*\n2*10*14*5", 31)]
        public void AddingNumbers_WhenOverridingDelimiters_IsSumOfNumbers(string input, int expectedResult)
        {
            var calc = new Calculator(DefaultAnswer, _defaultDelimiters);
            var result = calc.Add(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}