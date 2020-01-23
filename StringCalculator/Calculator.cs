using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly int _defaultAnswer;
        private readonly char[] _defaultDelimiters;
        private readonly string _noNumbers = string.Empty;
        private const string DelimiterOverridePattern = @"//(.)\n(.*)";
        private const int DelimiterOverrideIndex = 1;
        private const int NumbersIndex = 2;

        public Calculator(int defaultAnswer, char[] defaultDelimiters)
        {
            _defaultAnswer = defaultAnswer;
            _defaultDelimiters = defaultDelimiters;
        }

        public int Add(string input)
        {
            return NoInputProvided(input) ? _defaultAnswer : AddNumbers(input);
        }

        private bool NoInputProvided(string input)
        {
            return input == _noNumbers;
        }

        private int AddNumbers(string input)
        {
            var regex = new Regex(DelimiterOverridePattern);
            var match = regex.Match(input);
            return match.Success
                ? AddNumbersThatAreDelimitedByOverride(match)
                : AddNumbersThatAreDelimited(input);
        }

        private int AddNumbersThatAreDelimited(string numbers)
        {
            var splitNumbers = numbers.Split(_defaultDelimiters);
            return splitNumbers.Select(int.Parse).Sum();
        }

        private static int AddNumbersThatAreDelimitedByOverride(Match match)
        {
            var delimiterOverride = match.Groups[DelimiterOverrideIndex].Value;
            var numbers = match.Groups[NumbersIndex].Value;
            var splitNumbers = numbers.Split(Convert.ToChar(delimiterOverride));
            return splitNumbers.Select(int.Parse).Sum();
        }
    }
}
