using NUnit.Framework;
using StringCalculator;

namespace Tests
{
    public class CalculatorTests
    {
        [Test]
        public void AddingNumbers_WhenNoNumbersAreSpecified_IsZero()
        {
            var calc = new Calculator();
            var result = calc.Add(string.Empty);
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void AddingNumbers_WhenSingleNumberIsSpecified_IsNumberSpecified()
        {
            var calc = new Calculator();
            var result = calc.Add("1");
            Assert.That(result, Is.EqualTo(1));
        }
    }
}