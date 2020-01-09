using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private const string NoNumbers = "";
        private const char NumbersDelimiter = ',';
        private const int DefaultAnswer = 0;

        public int Add(string numbers)
        {
            var noNumbersAreProvided = numbers == NoNumbers;
            return noNumbersAreProvided ? DefaultAnswer : AddNumbers(numbers);
        }

        private static int AddNumbers(string numbers)
        {
            var splitNumbers = numbers.Split(NumbersDelimiter);
            return splitNumbers.Select(int.Parse).Sum();
        } 
    }
}
