using System;
using System.Collections.Generic;

namespace DaveSquared.StringsTheThing
{
    public class CalculatorExpressionParser : INumberParser
    {
        readonly IExpressionPartsParser _expressionPartsParser;
        readonly INumberParserFactory _numberParserFactory;

        public CalculatorExpressionParser(IExpressionPartsParser expressionPartsParser, INumberParserFactory numberParserFactory)
        {
            _expressionPartsParser = expressionPartsParser;
            _numberParserFactory = numberParserFactory;
        }

        public IEnumerable<int> Parse(string expression)
        {
            var parts = _expressionPartsParser.Parse(expression);
            var numberParser = _numberParserFactory.CreateForDelimiter(parts.Delimiter);
            return numberParser.Parse(parts.Remainder);
        }
    }
}