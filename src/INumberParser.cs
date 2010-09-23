using System;
using System.Collections.Generic;
using System.Linq;

namespace DaveSquared.StringsTheThing
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(string expression);
    }

    public class NumberParser : INumberParser
    {
        readonly char _delimiter;

        public NumberParser(char delimiter)
        {
            _delimiter = delimiter;
        }

        public IEnumerable<int> Parse(string expression)
        {
            return expression
                .Split(new[] {_delimiter}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x));
        }
    }
}