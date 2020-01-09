using System;

namespace StringCalculator
{
    public class Calculator
    {
        private const string NoNumbers = "";

        public int Add(string numbers)
        {
            var noNumbersAreProvided = numbers == NoNumbers;
            return noNumbersAreProvided ? 0 : int.Parse(numbers);
        }
    }
}
