using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private const string NoNumbers = "";
        private const int DefaultAnswer = 0;
        private const char CommaDelimiter = ',';
        private const char NewLineDelimiter = '\n';

        public int Add(string numbers)
        {
            var noNumbersAreProvided = numbers == NoNumbers;
            return noNumbersAreProvided ? DefaultAnswer : AddNumbers(numbers);
        }

        private static int AddNumbers(string numbers)
        {
            var splitNumbers = numbers.Split(CommaDelimiter, NewLineDelimiter);
            return splitNumbers.Select(int.Parse).Sum();
        } 
    }
}
