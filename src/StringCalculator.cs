using System;

namespace DaveSquared.StringsTheThing
{
    public class StringCalculator
    {
        readonly INumberParser _numberParser;
        readonly IAdder _adder;

        public StringCalculator(INumberParser numberParser, IAdder adder)
        {
            _numberParser = numberParser;
            _adder = adder;
        }

        public int Add(string expression)
        {
            var numbers = _numberParser.Parse(expression);
            return _adder.Add(numbers);
        }
    }
}